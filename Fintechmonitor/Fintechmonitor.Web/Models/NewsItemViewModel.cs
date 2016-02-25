using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fintechmonitor.Web.Models
{
    public class NewsItemViewModel
    {
        public int Id { get; set; }
        public string Headline { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
        public DateTime DateTime { get; set; }
        public string Body { get; set; }
        public int TypeId { get; set; }
        public string Type { get; set; }

        public string BodyFormatted
        {
            get
            {
                return Body.Replace(Environment.NewLine, "<br/>");
            }
        }
    }
}