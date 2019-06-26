using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PlanAssistant
{
    public class FileDownloader : Entity
    {
        public string Url { get; set; }
        public string To { get; set; }

        public void DownloadFile()
        {
            using (WebClient wc = new WebClient())
            {
                wc.DownloadFileAsync(
                    new Uri(Url), To
                );
            }
        }
    }
}
