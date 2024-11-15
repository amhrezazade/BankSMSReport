using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace BankSMSReport.Model
{
    public class BankSMS
    {
        public string PhoneId { get; set; }
        public string ThreadId { get; set; }
        public string Address { get; set; }
        public string Person { get; set; }
        public string Date { get; set; }
        public string Body { get; set; }
        public string Type { get; set; }
        public string BankType { get; set; }
        public string Side { get; set; }
    }
}
