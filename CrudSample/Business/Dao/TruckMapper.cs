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
        private static string _dbPath = string.Empty;

        private static string dbPath
        {
            get
            {
                if (string.IsNullOrEmpty(_dbPath))
                {
                    _dbPath = Path.Combine(ApplicationData.Current.LocalFolder.Path, "myDb.sqlite");
                }

                return _dbPath;
            }

        }

        public static async Task<bool> Exists(string id)
        {
            Truck truck;
            truck = await GetTransporterById(id);
            if (truck != null)
                return true;
            else
                return false;

        }

        public static async Task SaveOrUpdate(Truck truck)
        {
            using (var db = new SQLiteConnection(dbPath))
            {
                if (await Exists(truck.truckId))
                {
                    await UpdateTruck(truck);
                   
                }


                else
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
                //sempre il tracing
                db.Trace = true;

                //possiamo usare due diversi modi per cancellare gli oggetti
                //sempre perchè stiamo usando una libreria progettata da
                //altri, che in teoria non ci costringe a dover aprire/chiudere
                //esplicitamente ogni volta il db...operazioni trasparenti

                //Object
                db.Delete(truck);

                //Sql 
                //db.Execute("DELETE FROM tmpona WHERE ID =?", tmpon.Id);
            }
        }


        /* FUNZIONI DI RICERCA */

        //Elenco completo di tutti i Truck presenti
        public static async Task<ObservableCollection<Truck>> GetAllTrucks()
        {
            List<Truck> trucks;
            using (var db = new SQLiteConnection(dbPath))
            {
                // Activate Tracing
                db.Trace = true;

                trucks = (from p in db.Table<Truck>()
                                select p).ToList();

            }
            var obsTrucks = new ObservableCollection<Truck>();
            foreach (var item in trucks)
            {
                obsTrucks.Add(item);
            }
            return obsTrucks;
        }

        public static async Task<ObservableCollection<Truck>> SearchTruck(Truck Truck)
        {
            List<Truck> trucks;

            using (var db = new SQLiteConnection(dbPath))
            {
                var tmp = from p in db.Table<Truck>() select p;

                if(!string.IsNullOrEmpty(Truck.truckId))
                    tmp = tmp.Where(p => p.truckId.Contains(Truck.truckId));

                if (!string.IsNullOrEmpty(Truck.Url))
                    tmp = tmp.Where(p => p.Url.Contains(Truck.Url));

                if (!string.IsNullOrEmpty(Truck.Vin))
                    tmp = tmp.Where(p => p.Vin.Contains(Truck.Vin));

                if (!string.IsNullOrEmpty(Truck.Code))
                    tmp = tmp.Where(p => p.Code.Contains(Truck.Code));

                // parte della ricerca sui dati Transporter

                if (!string.IsNullOrEmpty(Truck.trId))
                    tmp = tmp.Where(p => p.trId.Contains(Truck.trId));

                if (!string.IsNullOrEmpty(Truck.trName))
                    tmp = tmp.Where(p => p.trName.Contains(Truck.trName));

                if (!string.IsNullOrEmpty(Truck.trUrl))
                    tmp = tmp.Where(p => p.trUrl.Contains(Truck.trUrl));

                if (!string.IsNullOrEmpty(Truck.trCode))
                    tmp = tmp.Where(p => p.trCode.Contains(Truck.trCode));

                trucks = tmp.ToList();

            }
            var obsTransporters = new ObservableCollection<Truck>();
            foreach (var item in trucks)
            {
                obsTransporters.Add(item);
            }
            return obsTransporters;
        }

        // search by Truck.Id
        public static async Task<Truck> GetTransporterById(string id)
        {
            using (var db = new SQLiteConnection(dbPath))
            {
                Truck truck = (from p in db.Table<Truck>()
                                     where p.truckId.Equals(id)
                                     select p).FirstOrDefault();
                return truck;
            }

        }

        //// seach by Truck.Name
        //public static async Task<ObservableCollection<Truck>> GetTransporterByName(string name)
        //{
        //    List<Truck> truck;
        //    using (var db = new SQLiteConnection(dbPath))
        //    {
        //        truck = (from p in db.Table<Truck>()
        //                 where p.trName.Contains(name)
        //                 select p).ToList();
        //    }
        //    var obsTransporters = new ObservableCollection<Truck>();
        //    foreach (var item in truck)
        //    {
        //        obsTransporters.Add(item);
        //    }
        //    return obsTransporters;
        //}


        //// search by Truck.Url  
        //public static async Task<ObservableCollection<Truck>> GetTransporterByUrl(string url)
        //{
        //    List<Truck> truck;
        //    using (var db = new SQLiteConnection(dbPath))
        //    {
        //        truck = (from p in db.Table<Truck>() where p.trUrl.Contains(url) select p).ToList();
        //    }
        //    var obsTransporters = new ObservableCollection<Truck>();
        //    foreach (var item in truck)
        //    {
        //        obsTransporters.Add(item);
        //    }
        //    return obsTransporters;
        //}

        //// search by Truck.Code 
        //public static async Task<ObservableCollection<Truck>> GetTransporterByCode(string code)
        //{
        //    List<Truck> truck;
        //    using (var db = new SQLiteConnection(dbPath))
        //    {
        //        truck = (from p in db.Table<Truck>() where p.trCode.Contains(code) select p).ToList();
        //    }
        //    var obsTransporters = new ObservableCollection<Truck>();
        //    foreach (var item in truck)
        //    {
        //        obsTransporters.Add(item);
        //    }
        //    return obsTransporters;
        //}

        ///* DEBUG FUNCTIONS */

        ////ci ritorna l'id cercato...funzione usata per qlc debug..mi sa che se po levà
        //public static async Task<Int32> GetTransporterId(int truckId)
        //{
        //    using (var db = new SQLiteConnection(dbPath))
        //    {
        //        Truck truck = (from p in db.Table<Truck>()
        //                             where p.trId == Convert.ToString(truckId)
        //                             select p).FirstOrDefault();

        //        return truck.Id;
        //    }

        //}
    }
}
