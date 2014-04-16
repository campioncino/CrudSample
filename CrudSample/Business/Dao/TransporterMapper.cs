using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SQLite;

using Windows.ApplicationModel;
// mi serve per gestire Path.Combine ... concatena la stringa con il path del db
using System.IO;
//con windows.storage recupero i percorso tramite l'application data
using Windows.Storage;

//questo mi serve per i container dinamici observable collection
using System.Collections.ObjectModel;

//uso caliburn per adottare i container dinamici osservabili e bindabili
//ovvero i bindable collections


using CrudSample.Business.Model;
using System.Diagnostics;



namespace CrudSample.Business.Dao
{
    public class TransporterMapper
    
    {
        //questa stringa mi servirà per la connessione
        private static string dbPath = DatabaseConnection.dbPath;


        public static async Task InsertTransporter(Transporter trans)
        {
            using (var db = new SQLiteConnection(dbPath))
            {
                db.Insert(trans);
            }
        }

        public static async Task UpdateTransporter(Transporter trans)
        {
            using (var db = new SQLiteConnection(dbPath))
            {
                db.Update(trans);
            }
        }

        public static async Task DeleteTransporter(Transporter trans)
        {
            using (var db = new SQLiteConnection(dbPath))
            {
                //sempre il tracing
                db.Trace = true;

                //Object
                db.Delete(trans);

                //Sql 
                //db.Execute("DELETE FROM tmpona WHERE ID =?", tmpon.Id);
            }
        }

        
        /* FUNZIONI DI RICERCA */

        //Elenco completo di tutti i Transporter presenti
        public static async Task<ObservableCollection<TransporterExt>> GetAllTransporters()
        {
            List<TransporterExt> list;
            using (var db = new SQLiteConnection(dbPath))
            {
                // Activate Tracing
                db.Trace = true;

                list = (from p in db.Table<TransporterExt>()
                                select p).ToList();

            }
            var coll = new ObservableCollection<TransporterExt>();
            foreach (var item in list)
            {
                coll.Add(item);
            }
            return coll;
        }

        public static async Task<ObservableCollection<TransporterExt>> SearchTransporter(TransporterExt transporter) 
        {
            List<TransporterExt> list;

            using (var db = new SQLiteConnection(dbPath))
            {
                var tmp = from p in db.Table<TransporterExt>() select p;
               
                if (transporter.trId !=null)
                    tmp = tmp.Where(p => p.trId==transporter.trId);
                
                if (!string.IsNullOrEmpty(transporter.code))
                    tmp = tmp.Where(p => p.code.Contains(transporter.code));
                
                if (!string.IsNullOrEmpty(transporter.url))
                    tmp = tmp.Where(p => p.url.Contains(transporter.url));

                if (!string.IsNullOrEmpty(transporter.name))
                    tmp = tmp.Where(p => p.name.Contains(transporter.name));

                list = tmp.ToList();

            }
            var coll = new ObservableCollection<TransporterExt>();
            foreach (var item in list)
            {
                coll.Add(item);
            }
            return coll;
        }


        // search transporter StartsWith
        public static async Task<ObservableCollection<TransporterExt>> SearchTransporter_StartsWith(TransporterExt transporter)
        {
            List<TransporterExt> list;

            using (var db = new SQLiteConnection(dbPath))
            {
                var tmp = from p in db.Table<TransporterExt>() select p;

                if (transporter.trId != null)
                    tmp = tmp.Where(p => p.trId == transporter.trId);

                if (!string.IsNullOrEmpty(transporter.code))
                    tmp = tmp.Where(p => p.code.StartsWith(transporter.code));

                if (!string.IsNullOrEmpty(transporter.url))
                    tmp = tmp.Where(p => p.url.StartsWith(transporter.url));

                if (!string.IsNullOrEmpty(transporter.name))
                    tmp = tmp.Where(p => p.name.StartsWith(transporter.name));

                list = tmp.ToList();

            }
            var coll = new ObservableCollection<TransporterExt>();
            foreach (var item in list)
            {
                coll.Add(item);
            }
            return coll;
        }

      
        
    }//end class
}


