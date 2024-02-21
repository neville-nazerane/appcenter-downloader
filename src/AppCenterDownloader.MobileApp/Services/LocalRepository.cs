using AppCenterDownloader.MobileApp.Models;
using AppCenterDownloader.MobileApp.Models.LocalDb;
using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCenterDownloader.MobileApp.Services
{
    public class LocalRepository(ILiteDatabase database)
    {
        private readonly ILiteDatabase database = database;

        public ILiteCollection<DbAccount> Accounts => database.GetCollection<DbAccount>("accounts");

        public ILiteCollection<AppDisplay> FavoriteApps => database.GetCollection<AppDisplay>("favApps");


    }
}
