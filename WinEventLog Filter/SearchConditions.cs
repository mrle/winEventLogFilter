using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
        /// Helper method which prints the search condition into resulting text box
        /// </summary>
        public string  PrintSearchConditions()
        {
            string txtResults;

            txtResults = "MACHINE_NAME: " + MachineName;
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
            txtResults += "\r\n Start Date: " + StartDate;
            txtResults += "\r\n End Date: " + EndDate;
            txtResults += "\r\n Use missing links filtering: " + (MissingLinksFiltering ? "Yes" : "No");
            txtResults += "\r\n**************************************************\r\n";

            return txtResults;
        }
    }
}
