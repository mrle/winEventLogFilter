using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

namespace WinEventLog_Filter
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            // Initialisation
            InitializeComponent();
            searchConditions = new SearchConditions();

            // Set defaults
            dateEnd.CustomFormat = FormDateFormatBasedOnLocalSystemSettings();
            dateStart.CustomFormat = FormDateFormatBasedOnLocalSystemSettings();
            dateStart.Value = DateTime.Now.AddDays(-1);
            GetEventTypes();
            GetEventLogs();
            if (Properties.Settings.Default.SaveSearchConditions)
                RestoreSearchParameters();
        }

        #region Events
        /// <summary>
        /// Event which is called if the user selects Filter button. 
        /// 1.) Get the search conditions
        /// 2.) Validate them
        /// 3.) Access Windows event log
        /// 4.) Loop throught the event entries of that log
        /// 5.) Filter the entries that match the search conditions
        /// 6.) Pussh the unique filtered entries in the resulting list
        /// 7.) Print the results
        /// 8.) Save search conditions in app settings
        /// </summary>
        private void btnFilter_Click(object sender, EventArgs e)
        {
            try
            {
                //do {
                //    GetSearchConditions();
                //    if (searchConditions.ValidateDateConditions() == SearchConditions.ValidationStatus.DatesEqual)

                //} while(searchConditions.ValidateDateConditions() != SearchConditions.ValidationStatus.ValidationPassed);
                // If start and edn dates are equal, substract one day from start date
                if (dateStart.Value.ToShortDateString().Equals(dateEnd.Value.ToShortDateString()))
                    dateStart.Value = dateStart.Value.AddDays(-1);
                // If date span is greater then 15 days promt the user
                if ((dateEnd.Value - dateStart.Value).Days > 15)
                {
                    if (MessageBox.Show("You have selected the date span which is greater then 15 days! " +
                        "Consequently, greater number of the windows events has to be filtered, which may prolong the execution time." +
                        "\r\n\r\nIf you want to proceed select Ok (or press Enter). \r\nIf you want to abort the action select Cancel.",
                        "Question",
                        MessageBoxButtons.OKCancel,
                        MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Cancel)
                        return;
                }

                // Load search conditions
                GetSearchConditions();
                txtResults.ForeColor = Color.Green;
                txtResults.Text = searchConditions.PrintSearchConditions();

                
                missingLinksTcms = new List<string>();
                events = new Dictionary<int, EventLogEntry>();
                bool connected = false;
                // Load selected Windows log
                //using (EventLog log = new EventLog(searchConditions.EventLog, cmbLocalNetworkAdrs.Text))
                using (EventLog log = new EventLog(searchConditions.EventLog, searchConditions.MachineName))
                {
                    connected = true;
                    this.Enabled = false;
                    // Loop throught selected log event entries, begin from the entry which is last created
                    for (var i = log.Entries.Count - 1; i >= 0; i--)
                    {
                        using (EventLogEntry ele = log.Entries[i])
                        {
                            // Break the loop if the current event entry creation date is older then start date search parameter
                            if (ele.TimeGenerated < searchConditions.StartDate)
                                break;
                            // Skip the iteration if the current event entirty creation date is newer thrn end date search parameter
                            if (ele.TimeGenerated >= searchConditions.EndDate)
                                continue;
                            // Skip the iteration if search term exist and if current event message does not contain it
                            if (searchConditions.SearchTerms != null && !MessageContainSearchedTerm(ele.Message))
                                continue;
                            // Skip the iteration if event ID condition is NOT empty or if it is NOT the same as of the current event entry
                            if (!(searchConditions.EventID.Equals("") || ele.EventID == int.Parse(searchConditions.EventID)))
                                continue;
                            // Skip the iteration if event source condition is NOT empty or if it is NOT the same as of the current event entry (exact phrase condition is also considered)
                            if (!(searchConditions.EventSource.Equals("")
                                || (searchConditions.MatchExactEventSource ?
                                    ele.Source.ToString().ToLower().Equals(searchConditions.EventSource.ToLower()) :
                                    ele.Source.ToString().ToLower().Contains(searchConditions.EventSource.ToLower()))))
                                continue;
                            // Skip the iteration if event type condition is NOT All or if it is NOT the same as of the current event entry
                            if (!(searchConditions.EventType.Equals("All") || searchConditions.EventType.Equals(ele.EntryType.ToString())))
                                continue;

                            // When all validation have passes, push event entry into the resulting list
                            PushEventMessage(ele);
                        }
                    }
                    this.Enabled = true;
                }

                if (!connected) 
                    throw new Exception("Unable to access '" + searchConditions.EventLog + "' event log!");



                // Print the results
                for (var i = 0; i < events.Count; i++)
                {
                    txtResults.Text += "\r\n [EVENT No " + (i + 1) + "]";
                    txtResults.Text += "\r\n " + events.ElementAt(i).Value.Message.Replace("  ", "\r\n").Replace("\n", "\r\n");
                    txtResults.Text += "\r\n -------------------------------------------------------------------------------------------------------------------------------";
                }
                if (events != null && events.Count > 0)
                    txtResults.Text += "\r\n\r\n ||||| >>> RESULT: " + events.Count + " unique events founded!!! <<< |||||";
                else
                    txtResults.Text += "\r\n\r\n There is no Windows events that match the search criteria :'(";


                // Print missing links summary results, if missing links filtering is turned on
                if (searchConditions.MissingLinksFiltering)
                    txtResults.Text += "\r\n " + GetMissingLinksSummary();

                // Save search conditions in app settings
                StoreSearchParameters();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
            finally
            {
                txtResults.SelectionStart = txtResults.Text.Length;
                txtResults.ScrollToCaret();
            }
        }

        /// <summary>
        /// Event which enables compying the whole results into clipboard.
        /// </summary>
        private void btnCopy_Click(object sender, EventArgs e)
        {
            try
            {
                string res = txtResults.Text;
                if (res != null && !res.Equals(""))
                    Clipboard.SetText(res);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        /// <summary>
        /// Event which opens Save File Dialog and ebables saving the results into a file.
        /// </summary>
        private void btnSaveToFile_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Text File|*.txt";
                saveFileDialog.Title = "Save an Text File";

                if (saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK && saveFileDialog.FileName != null)
                    using (var file = File.CreateText(saveFileDialog.FileName))
                        file.Write(txtResults.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        /// <summary>
        /// Event which disables entering non-numeric characters into Even ID text box.
        /// </summary>
        private void txtEventId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        /// <summary>
        /// Event which hides ot unhides "Copy Summary" button regarding of "Use missing links filtering" checked state.
        /// </summary>
        private void chkMissingLinksFiltering_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMissingLinksFiltering.Checked)
            {
                btnCopySummary.Enabled = true;
                btnCopySummary.Visible = true;
            }
            else
            {
                btnCopySummary.Enabled = false;
                btnCopySummary.Visible = false;
            }
        }

        /// <summary>
        /// Event which copies the missing links summary report into clipboard.
        /// </summary>
        private void btnCopySummary_Click(object sender, EventArgs e)
        {
            try
            {
                string res = GetMissingLinksSummary();
                if (res != null && !res.Equals(""))
                    Clipboard.SetText(res);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        /// <summary>
        /// Event which enables the results text box focus as sone as the user hover over it.
        /// </summary>
        private void txtResults_MouseHover(object sender, EventArgs e)
        {
            txtResults.Focus();
        }

        /// <summary>
        /// Event that is fired when the folrm is closed. Stores Remember search conditions check box value
        /// in application settings.
        /// </summary>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.chkSaveSearchConditions.Checked)
                StoreSearchParameters();
            else
            {
                Properties.Settings.Default.SaveSearchConditions = this.chkSaveSearchConditions.Checked;
                Properties.Settings.Default.FormSize = new System.Drawing.Size(this.Width, this.Height);
                Properties.Settings.Default.Save();
            }
        }

        /// <summary>
        /// Event that is fired when user click on date reload button. It sets end date to current value of 
        /// date and time.
        /// </summary>
        private void btnReloadCurrentDate_Click(object sender, EventArgs e)
        {
            dateEnd.Value = DateTime.Now;
        }

        #endregion





        #region Helper Methods
        /// <summary>
        /// Helper method which populates Event Type combo box.
        /// </summary>
        private void GetEventTypes()
        {
            cmbEvenType.Items.Add(EventLogEntryType.Error);
            cmbEvenType.Items.Add(EventLogEntryType.FailureAudit);
            cmbEvenType.Items.Add(EventLogEntryType.Information);
            cmbEvenType.Items.Add(EventLogEntryType.SuccessAudit);
            cmbEvenType.Items.Add(EventLogEntryType.Warning);
            cmbEvenType.Items.Add("All");
            cmbEvenType.SelectedIndex = 0;
        }

        /// <summary>
        /// Helper method which populates Event Logs combo box with the event logs that exist on the local computer.
        /// </summary>
        private void GetEventLogs()
        {
            try
            {
                bool tridionLogFound = false;
                EventLog[] localhostLogs = EventLog.GetEventLogs(System.Environment.MachineName);

                for (var i = 0; i < localhostLogs.Length; i++)
                {
                    cmbEventLog.Items.Add(localhostLogs[i].Log);
                    if (localhostLogs[i].Log.Equals("Tridion Content Manager"))
                    {
                        tridionLogFound = true;
                        cmbEventLog.SelectedIndex = i;
                    }
                }
                if (!tridionLogFound && cmbEventLog.Items.Count > 0)
                    cmbEventLog.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                txtResults.ForeColor = Color.Red;
                txtResults.Text = ex.Message;
                txtResults.Text += "\r\n" + ex.StackTrace;
            }
        }

        /// <summary>
        /// Helper method which creates missing links summary output. If there are no missing links output is empty.
        /// </summary>
        /// <returns>Missing links summary string output</returns>
        private string GetMissingLinksSummary()
        {
            string retVal = "";

            if (missingLinksTcms == null) return retVal;

            missingLinksTcms.Sort();
            if (missingLinksTcms.Count > 0)
            {
                retVal = "\r\n\r\n\r\n===================================================================\r\n";
                retVal += "\r\n[MISSING LINKS SUMMARY]";
                retVal += "\r\n Machine IP: " + searchConditions.MachineIP;
                retVal += "\r\n Time span: " + dateStart.Value + " - " + dateEnd.Value;
                retVal += "\r\n Items:";
            }
            for (var i = 0; i < missingLinksTcms.Count; i++)
                retVal += "\r\n " + missingLinksTcms[i].ToString();

            return retVal;
        }

        /// <summary>
        /// Helper method which pushes the current event entry in the resulting list, but only if it is unique.
        /// </summary>
        /// <param name="e">Event entry object</param>
        private void PushEventMessage(EventLogEntry e)
        {
            int hashCode = e.Message.GetHashCode();
            if (!events.ContainsKey(hashCode))
            {
                events.Add(hashCode, e);
                if (chkMissingLinksFiltering.Checked)
                {
                    string msgPart = "MISSING LITERATURE LINK: Resource ";
                    if (e.Message.Contains(msgPart))
                    {
                        string tcm = e.Message.Substring(e.Message.IndexOf(msgPart, 0) + msgPart.Length, 13);
                        if (!tcm.Equals("") && !missingLinksTcms.Contains(tcm))
                            missingLinksTcms.Add(tcm);
                    }
                }
            }
        }

        /// <summary>
        /// Gets the IP address of the local computer.
        /// </summary>
        private string getMachineIPAddress()
        {
            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                    return ip.ToString();
            return "";
        }

        /// <summary>
        /// Helper method which parses and sats the search terms into local string array
        /// </summary>
        private string[] LoadSearchTerms()
        {
            if (txtSearchTerm.Text.Trim().Equals("")) return null;

            char[] delimiters = new char[] { ',', ';' };
            string[] searchTerms = txtSearchTerm.Text.Trim().ToLower().Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

            for (var i = 0; i < searchTerms.Length; i++)
                searchTerms[i] = searchTerms[i].Trim();

            return searchTerms;
        }

        /// <summary>
        /// Helper method whish checks if passed string contains the search term od the search conditions
        /// </summary>
        /// <param name="msg">Event message to be searched</param>
        /// <returns>Returns true if message contains the searched term</returns>
        private bool MessageContainSearchedTerm(string msg)
        {
            if (searchConditions.SearchTerms == null) return false;

            for (var i = 0; i < searchConditions.SearchTerms.Length; i++)
                if (msg.ToLower().Contains(searchConditions.SearchTerms[i])) return true;

            return false;
        }

        /// <summary>
        /// Adding keyboard shortcuts to the MainForm action buttons.
        /// </summary>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.S))
            {
                btnSaveToFile_Click(null, null);
                return true;
            }
            if (keyData == (Keys.Control | Keys.M))
            {
                btnCopySummary_Click(null, null);
                return true;
            }
            if (keyData == (Keys.Control | Keys.C))
            {
                btnCopy_Click(null, null);
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        /// <summary>
        /// Gets the search conditions from main form and store them into local searchConditions attrinute.
        /// </summary>
        private void GetSearchConditions()
        {
            searchConditions.SearchTerms = LoadSearchTerms();
            searchConditions.EventID = txtEventId.Text;
            searchConditions.EventType = cmbEvenType.SelectedItem.ToString();
            searchConditions.EventLog = cmbEventLog.SelectedItem.ToString();
            searchConditions.EventSource = txtEventSource.Text.Trim();
            searchConditions.MatchExactEventSource = chkMachExact.Checked;
            searchConditions.StartDate = dateStart.Value;
            searchConditions.EndDate = dateEnd.Value;
            searchConditions.MissingLinksFiltering = chkMissingLinksFiltering.Checked;
            searchConditions.MachineIP = getMachineIPAddress();
            searchConditions.MachineName = Environment.MachineName;
        }

        /// <summary>
        /// Helper method that is used for storing current search parameters in application settings so that they can be loaded
        /// on next application start. Date fields are excluded.
        /// </summary>
        private void StoreSearchParameters()
        {
            try
            {
                Properties.Settings.Default.SearchForTerm = this.txtSearchTerm.Text;
                Properties.Settings.Default.EventID = this.txtEventId.Text;
                Properties.Settings.Default.EventType = this.cmbEvenType.Text;
                Properties.Settings.Default.EventLog = this.cmbEventLog.Text;
                Properties.Settings.Default.EventSource = this.txtEventSource.Text;
                Properties.Settings.Default.MissingLinksFiltering = this.chkMissingLinksFiltering.Checked;
                Properties.Settings.Default.MachSourcePhrase = this.chkMachExact.Checked;
                Properties.Settings.Default.EndDate = this.dateEnd.Value;
                Properties.Settings.Default.SaveSearchConditions = this.chkSaveSearchConditions.Checked;
                Properties.Settings.Default.FormSize = new System.Drawing.Size(this.Width, this.Height);
                Properties.Settings.Default.Save();
            }
            catch (Exception ex)
            {
                txtResults.ForeColor = Color.Red;
                txtResults.Text = ex.Message;
                txtResults.Text += "\r\n" + ex.StackTrace;
            }
        }

        /// <summary>
        /// Helper method that restore search parameters from application settings. Date fields are excluded.
        /// </summary>
        private void RestoreSearchParameters()
        {
            try
            {
                this.txtSearchTerm.Text = Properties.Settings.Default.SearchForTerm;
                this.txtEventId.Text = Properties.Settings.Default.EventID;
                this.cmbEvenType.Text = Properties.Settings.Default.EventType;
                this.cmbEventLog.Text = Properties.Settings.Default.EventLog;
                this.txtEventSource.Text = Properties.Settings.Default.EventSource;
                this.chkMissingLinksFiltering.Checked = Properties.Settings.Default.MissingLinksFiltering;
                this.chkMachExact.Checked = Properties.Settings.Default.MachSourcePhrase;
                this.dateStart.Value = Properties.Settings.Default.EndDate;
                this.Width = Properties.Settings.Default.FormSize.Width;
                this.Height = Properties.Settings.Default.FormSize.Height;
                this.chkSaveSearchConditions.Checked = Properties.Settings.Default.SaveSearchConditions;
            }
            catch (Exception ex)
            {
                txtResults.ForeColor = Color.Red;
                txtResults.Text = ex.Message;
                txtResults.Text += "\r\n" + ex.StackTrace;
            }
        }

        /// <summary>
        /// Helper method which creates a custom date format ment for date picker controls usin local sustem culture info
        /// </summary>
        private string FormDateFormatBasedOnLocalSystemSettings()
        {
            DateTimeFormatInfo sysFormat = CultureInfo.CurrentCulture.DateTimeFormat;
            
            return sysFormat.ShortDatePattern + " " + sysFormat.LongTimePattern;
        }




        //private void GetLocalNetworkComputersNames()
        //{
            
        //}

        //private void PopulateLocalNetworkIPs()
        //{
        //    var nics = NetworkInterface.GetAllNetworkInterfaces();
        //    foreach (var nic in nics)
        //    {
        //        var ipProps = nic.GetIPProperties();

        //        // We're only interested in IPv4 addresses for this example.
        //        var ipv4Addrs = ipProps.UnicastAddresses.Where(addr => addr.Address.AddressFamily == AddressFamily.InterNetwork);

        //        foreach (var addr in ipv4Addrs)
        //        {
        //            var network = CalculateNetwork(addr);
        //            if (network != null)
        //                cmbLocalNetworkAdrs.Items.Add("Addr: " + addr.Address + " Mask: " + addr.IPv4Mask + "  Network: " + network);
        //        }
        //    }
        //}
        //private IPAddress CalculateNetwork(UnicastIPAddressInformation addr)
        //{
        //    // The mask will be null in some scenarios, like a dhcp address 169.254.x.x
        //    if (addr.IPv4Mask == null)
        //        return null;

        //    var ip = addr.Address.GetAddressBytes();
        //    var mask = addr.IPv4Mask.GetAddressBytes();
        //    var result = new Byte[4];
        //    for (int i = 0; i < 4; ++i)
        //    {
        //        result[i] = (Byte)(ip[i] & mask[i]);
        //    }

        //    return new IPAddress(result);
        //}
        #endregion
    }
}
