using System;

namespace Fintechmonitor.Domain
{
    public class NewsItem
    {
        public int Id { get; set; }
        public string Headline { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
       
        public string Body { get; set; }
        public int TypeId { get; set; }
        public string Type { get; set; }

        public DateTime DateTime
        {
            get
            {
                return Date.Add(Time);
            }
        }
    }
}
