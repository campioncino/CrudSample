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

using CrudSample.Business.Model;
using System.Diagnostics;

namespace CrudSample.Business.Dao
{
    class TruckMapper
    {
        //questa stringa mi servirà per la connessione
        private static string dbPath = DatabaseConnection.dbPath;
        

        public static async Task InsertTruck(Truck truck) 
        {
            using (var db = new SQLiteConnection(dbPath))
            {
                db.Insert(truck);

            }
        }

        public static async Task UpdateTruck(Truck truck)
        {
            using (var db = new SQLiteConnection(dbPath))
            {
                db.Update(truck);
                
            }
        }

        public static async Task DeleteTruck(Truck truck)
        {
            using (var db = new SQLiteConnection(dbPath))
            {
                
                db.Trace = true;

                //Object
                db.Delete(truck);

                //Sql 
                //db.Execute("DELETE FROM tmpona WHERE ID =?", tmpon.Id);
            }
        }


        /* FUNZIONI DI RICERCA */

        //Elenco completo di tutti i Truck presenti
        public static async Task<ObservableCollection<TruckExt>> GetAllTruck()
        {
            List<TruckExt> list;
            using (var db = new SQLiteConnection(dbPath))
            {
                // Activate Tracing
                db.Trace = true;

                list = (from p in db.Table<TruckExt>()
                                select p).ToList();

            }
            var coll = new ObservableCollection<TruckExt>();
            foreach (var item in list)
            {
                coll.Add(item);
            }
            return coll;
        }

        public static async Task<ObservableCollection<TruckExt>> SearchTruck(TruckExt Truck)
        {
            List<TruckExt> list;

            using (var db = new SQLiteConnection(dbPath))
            {
                var tmp = from p in db.Table<TruckExt>() select p;

                // [crudgen:truck:where]start

                if (Truck.truckId != null)
                    tmp = tmp.Where(p => p.truckId == Truck.truckId);

                if (!string.IsNullOrEmpty(Truck.url))
                    tmp = tmp.Where(p => p.url.Contains(Truck.url));

                if (!string.IsNullOrEmpty(Truck.vin))
                    tmp = tmp.Where(p => p.vin.Contains(Truck.vin));

                if (!string.IsNullOrEmpty(Truck.code))
                    tmp = tmp.Where(p => p.code.Contains(Truck.code));

                if (Truck.trId!=null)
                   tmp = tmp.Where(p=>p.trId==Truck.trId);

                // parte della ricerca sui dati Transporter
                if (!string.IsNullOrEmpty(Truck.trName))
                    tmp = tmp.Where(p => p.trName.Contains(Truck.trName));

                if (!string.IsNullOrEmpty(Truck.trUrl))
                    tmp = tmp.Where(p => p.trUrl.Contains(Truck.trUrl));

                if (!string.IsNullOrEmpty(Truck.trCode))
                    tmp = tmp.Where(p => p.trCode.Contains(Truck.trCode));

                // [crudgen:truck:where]start

                list = tmp.ToList();

            }
            var coll = new ObservableCollection<TruckExt>();
            foreach (var item in list)
            {
                coll.Add(item);
            }
            return coll;
        }

    }
}
