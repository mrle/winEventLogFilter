using System;
using System.Windows.Forms;

namespace WinEventLog_Filter
{
    class SearchConditions
    {
        public string[] SearchTerms;
        public string EventID;
        public string EventLog;
        public string EventSource;
        public string EventType;
        public DateTime StartDate;
        public DateTime EndDate;
        public bool MatchExactEventSource;
        public bool MissingLinksFiltering;
        public string MachineIP;
        public string MachineName;


        /// <summary>
        /// Helper method that extract search condition sontrols values and sets them as attributes of the class.
        /// </summary>
        public void GetSearchConditions(MainForm mainform)
        {

        }

        /// <summary>
        /// Helper method which prints the search condition into resulting text box
        /// </summary>
        public string  PrintSearchConditions()
        {
            string txtResults = "MACHINE_NAME: " + MachineName;
            txtResults += "\r\nMACHINE_IP_ADDRESS: " + MachineIP + "\r\n";
            txtResults += "\r\n**************************************************";
            txtResults += "\r\nSEARCH CONDITIONS:";
            txtResults += "\r\n Search terms:";
            if (SearchTerms != null)
            {
                for (var i = 0; i < SearchTerms.Length; i++)
                    txtResults += " " + SearchTerms[i] + ",";
                txtResults = txtResults.TrimEnd(',');
            }
            txtResults += "\r\n Event ID: " + EventID;
            txtResults += "\r\n Event Type: " + EventType;
            txtResults += "\r\n Event Log: " + EventLog;
            txtResults += "\r\n Event Source: " + EventSource + (MatchExactEventSource ? " (exact)" : "");
            txtResults += "\r\n Start Date: " + StartDate;
            txtResults += "\r\n End Date: " + EndDate;
            txtResults += "\r\n Use missing links filtering: " + (MissingLinksFiltering ? "Yes" : "No");
            txtResults += "\r\n**************************************************\r\n";

            return txtResults;
        }

        /// <summary>
        /// Helper method that checks if start and end dates are in proper format and limits
        /// </summary>
        public ValidationStatus ValidateDateConditions()
        {
            // If start and and dates are equal, substract one day from start date
            if (StartDate.ToShortDateString().Equals(EndDate.ToShortDateString()))
                return ValidationStatus.DatesEqual;
                //StartDate.Value = StartDate.AddDays(-1);
            // If date span is greater then 15 days promt the user
            if ((EndDate - StartDate).Days > 15)
            {
                if (MessageBox.Show("You have selected the date span which is greater then 15 days! " +
                    "Consequently, greater number of the windows events has to be filtered, which may prolong the execution time." +
                    "\r\n\r\nIf you want to proceed select Ok (or press Enter). \r\nIf you want to abort the action select Cancel.",
                    "Question",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Cancel)
                    return ValidationStatus.DateSpanTooLong;
            }

            return ValidationStatus.ValidationPassed;
        }


        public enum ValidationStatus { 
            /// <summary>
            /// All search conditions are in proper format.
            /// </summary>
            ValidationPassed = 1,
            /// <summary>
            /// Start and End dates have the same value.
            /// </summary>
            DatesEqual = 2,
            /// <summary>
            /// Date span is longer then 15 days.
            /// </summary>
            DateSpanTooLong = 3
        }
    }
}
