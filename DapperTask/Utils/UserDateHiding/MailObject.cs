using System;

namespace DapperTask.Utils.UserDateHiding
{
    public class MailObject
    {
        public string To { get; set; }

        public string From { get; set; }

        public string Subject { get; set; }

        public string Letter { get; set; }

        public DateTime Date { get; set; }
    }
}
