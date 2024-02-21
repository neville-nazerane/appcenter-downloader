using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCenterDownloader.MobileApp.Models
{
    public class AppDisplay
    {

        [BsonId]
        public Guid Id { get; set; }

        public string DisplayName { get; set; }

        public string IconUrl { get; set; }

        public string AppName { get; set; }

        public string OwnerName { get; set; }

        public bool IsFavorite { get; set; }

    }
}
