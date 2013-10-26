using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinEventLog_TestApp
{
    public class Application
    {
        static void Main(string[] args)
        {
            EventLog log = new EventLog(); 
            
            string message = "MISSING LITERATURE LINK: Resource tcm:405-14143 link is missing on site";
            string source = "Application";

            EventLog.WriteEntry(source, message);
            EventLog.WriteEntry(source, message, EventLogEntryType.Error, 11111);
            message = "MISSING LITERATURE LINK: Resource tcm:402-14143 link is missing on site";
            EventLog.WriteEntry(source, message, EventLogEntryType.Error, 11111);
            message = "MISSING LITERATURE LINK: Resource tcm:403-14143 link is missing on site";
            EventLog.WriteEntry(source, message, EventLogEntryType.Error, 11111);

            Console.Read();
        }
    }
}
