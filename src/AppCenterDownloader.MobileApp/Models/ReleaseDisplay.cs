using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCenterDownloader.MobileApp.Models
{
    public class ReleaseDisplay
    {

        public string Version { get; set; }

        public DateTime CreatedOn { get; set; }
        public int Id { get; internal set; }
    }
}
