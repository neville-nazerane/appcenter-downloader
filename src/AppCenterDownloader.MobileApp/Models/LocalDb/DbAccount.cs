using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCenterDownloader.MobileApp.Models.LocalDb
{
    public class DbAccount
    {

        [BsonId]
        public string Key { get; set; }

        public string DisplayName { get; set; }


    }
}
