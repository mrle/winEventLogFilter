using System;
using System.Diagnostics;
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
        /// <returns>Vallidation fails if user selects Cancel in 'More then 15 days' question box.</returns>
        public ValidationStatus ValidateDateConditions()
        {
            // If start and end dates are equal, substract one day from start date
            if (StartDate.ToShortDateString().Equals(EndDate.ToShortDateString()))
                throw new Exception("Start and End date cannot have the same value!");

            // If date span is greater then 15 days promt the user
            if ((EndDate - StartDate).Days > 15)
            {
                if (MessageBox.Show("You have selected the date span which is greater then 15 days! " +
                    "Consequently, greater number of the windows events has to be filtered, which may prolong the execution time." +
                    "\r\n\r\nIf you want to proceed select Ok (or press Enter). \r\nIf you want to abort the action select Cancel.",
                    "Question",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Cancel)
                    return ValidationStatus.QuestionDialogCancellation;
            }

            return ValidationStatus.ValidationPassed;
        }


        public ValidationStatus DoesCurrentEventMeetSearchCriteria(EventLogEntry ele)
        {
            // Break the loop if the current event entry creation date is older then start date search parameter
            if (ele.TimeGenerated < StartDate)
                return ValidationStatus.EndOfDateSpanReached;
            // Skip the iteration if the current event entirty creation date is newer thrn end date search parameter
            if (ele.TimeGenerated >= EndDate)
                return ValidationStatus.SearchCriteriaIsNotMeet;
            // Skip the iteration if search term exist and if current event message does not contain it
            if (SearchTerms != null && !EventMessageContainSearchedTerm(ele.Message))
                return ValidationStatus.SearchCriteriaIsNotMeet;
            // Skip the iteration if event ID condition is NOT empty or if it is NOT the same as of the current event entry
            if (!(EventID.Equals("") || ele.EventID == int.Parse(EventID)))
                return ValidationStatus.SearchCriteriaIsNotMeet;
            // Skip the iteration if event source condition is NOT empty or if it is NOT the same as of the current event entry (exact phrase condition is also considered)
            if (!(EventSource.Equals("")
                || (MatchExactEventSource ?
                    ele.Source.ToString().ToLower().Equals(EventSource.ToLower()) :
                    ele.Source.ToString().ToLower().Contains(EventSource.ToLower()))))
                return ValidationStatus.SearchCriteriaIsNotMeet;
            // Skip the iteration if event type condition is NOT All or if it is NOT the same as of the current event entry
            if (!(EventType.Equals("All") || EventType.Equals(ele.EntryType.ToString())))
                return ValidationStatus.SearchCriteriaIsNotMeet;

            return ValidationStatus.SearchCriteriaMeet;
        }

        /// <summary>
        /// Helper method whish checks if passed string contains the search term od the search conditions
        /// </summary>
        /// <param name="msg">Event message to be searched</param>
        /// <returns>Returns true if message contains the searched term</returns>
        private bool EventMessageContainSearchedTerm(string msg)
        {
            if (SearchTerms == null) return false;

            for (var i = 0; i < SearchTerms.Length; i++)
                if (msg.ToLower().Contains(SearchTerms[i])) return true;

            return false;
        }


        public enum ValidationStatus { 
            /// <summary>
            /// All search conditions are in proper format.
            /// </summary>
            ValidationPassed = 1,
            /// <summary>
            /// User clicked on cancel button of question dialog.
            /// </summary>
            QuestionDialogCancellation = 2,
            /// <summary>
            /// Search criteria meet for current event.
            /// </summary>
            SearchCriteriaMeet = 3,
            /// <summary>
            /// Curent event doesnt meet search criteria.
            /// </summary>
            SearchCriteriaIsNotMeet = 4,
            /// <summary>
            /// End od date span reached in current event, iteration ends.
            /// </summary>
            EndOfDateSpanReached = 5
        }
    }
}
