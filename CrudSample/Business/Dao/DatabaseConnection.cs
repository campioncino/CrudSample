using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// mi serve per gestire Path.Combine ... concatena la Stringa con il path del db
using System.IO;

//con windows.storage recupero i percorso tramite l'application data
using Windows.Storage;

using SQLite;

using CrudSample.Business.Model;
using System.Diagnostics;

namespace CrudSample.Business.Dao
{
    public sealed class DatabaseConnection
    {
        //private static volatile DatabaseConnection instance;
        //private static object syncRoot = new Object();

        private static String _dbPath = string.Empty;

        public static String dbPath
        {
            get
            {
                if (String.IsNullOrEmpty(_dbPath))
                {
                    _dbPath = Path.Combine(ApplicationData.Current.LocalFolder.Path, "myDb.sqlite");
                }

                return _dbPath;
            }

        }


        public static bool CheckDatabase()
        {
            using (SQLiteConnection db = new SQLiteConnection(dbPath)) 
            { 
            if(db!=null)
                return true;
            else
                return false;
            }
        }

    }
        
}
