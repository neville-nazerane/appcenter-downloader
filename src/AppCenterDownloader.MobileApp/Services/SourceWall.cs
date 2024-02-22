using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCenterDownloader.MobileApp.Services
{
    public class SourceWall
    {

        public string EditingAccountId { get; set; }

        public static string LastLocation 
        { 
            get => Preferences.Get(nameof(LastLocation), "apps");
            set => Preferences.Set(nameof(LastLocation), value);
        }

    }
}
