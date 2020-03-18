using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectNASA
{
    /*I decided that in this case, given the cirumstances that I'm in, it'd be better to create a new class specifically for the items that get saved to user's list.
     This class thus will contain both APOD and MarsPicsObj objects.
     To distinguish between the objects, for MarsPicsObj I'll be leaving the media_type field empty.*/
    public class myListObject
    {
        public string title { get; set; }
        public string img_url { get; set; }
        public string date { get; set; }
        public string media_type { get; set; }
        public string expl { get; set; }

        public myListObject()
        {
            this.title = "";
            this.img_url = "";
            this.date = "";
            this.media_type = "";
            this.expl = "";
        }
        public myListObject(string title, string img_url, string date, string media_type, string expl)
        {
            this.title = title;
            this.img_url = img_url;
            this.date = date;
            this.media_type = media_type;
            this.expl = expl;
        }
    }
}
