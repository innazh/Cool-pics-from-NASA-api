using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectNASA
{
    public class APOD
    {
        public string date { get; set; }
        public string explanation { get; set; }
        public string media_type { get; set; }
        public string service_version { get; set; }
        public string title { get; set; }
        public string url { get; set; }

        public APOD() { }
        public APOD(string title, string date, string expl, string type, string url)
        {
            this.title = title;
            this.explanation = expl;
            this.date = date;
            this.media_type = type;
            this.url = url;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder("Title: ");
            sb.Append(title);
            sb.Append('\n');
            sb.Append("Date: ");
            sb.Append(date);
            sb.Append('\n');
            sb.Append("Explanation: ");
            sb.Append(explanation);
            sb.Append('\n');
            sb.Append("Type: ");
            sb.Append(media_type);
            sb.Append('\n');
            sb.Append("URL: ");
            sb.Append(url);

            return sb.ToString();
        }
    }
}
