﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCenterDownloader.MobileApp.Models
{
    public class AccountDisplay
    {

        public string Key { get; set; }

        public string DisplayName { get; set; }

        public ObservableCollection<AppDisplay> Apps { get; set; }

    }
}
