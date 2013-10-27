using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace WinEventLog_Browser
{
    public partial class MainFormCreator : Form
    {
        public MainFormCreator()
        {
            InitializeComponent();
            GetEventLogs();
            GetEventTypes();
            txtEventId.Text = "11111";
            rtxEventMessage.Text = "MISSING LITERATURE LINK: Resource tcm:402-14143 link is missing on site";
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < numRepeatNo.Value; i++)
                {
                    EventLog log = new EventLog();

                    string message = rtxEventMessage.Text;
                    string source = cmbEventLog.Text;

                    if (txtEventId.Text == "")
                        EventLog.WriteEntry(source, message);
                    else
                        EventLog.WriteEntry(source, message, GetLogType(cmbEvenType.Text), Convert.ToInt16(txtEventId.Text));
                }
                MessageBox.Show("Event(s) created!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }


        private EventLogEntryType GetLogType(string logString)
        {
            switch (logString)
            {
                case "Error": return EventLogEntryType.Error;
                case "FailureAudit": return EventLogEntryType.FailureAudit;
                case "Information": return EventLogEntryType.Information;
                case "SuccessAudit": return EventLogEntryType.SuccessAudit;
                case "Warning": return EventLogEntryType.Warning;
                default: return EventLogEntryType.Error;
            }
        }


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
                    if (localhostLogs[i].Log.Equals("Tridion Content Manager") || localhostLogs[i].Log.Equals("Application"))
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
                MessageBox.Show(ex.Message);
            }
        }

        private void txtEventId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }
    }
}
