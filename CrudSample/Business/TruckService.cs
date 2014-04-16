using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//questo mi serve per i container dinamici observable collection
using System.Collections.ObjectModel;

using CrudSample.Business.Dao;
using CrudSample.Business.Model;

namespace CrudSample.Business
{
    public class TruckService
    {
        

        public static async Task UpdateTruck(Truck truck)
        {
            await TruckMapper.UpdateTruck(truck);
        }

        public static async Task InsertTruck(Truck truck)
        {
            await TruckMapper.InsertTruck(truck);
        }


        public static async Task DeleteTruck(Truck truck)
        {
            await TruckMapper.DeleteTruck(truck);
        }

        /* SEARCH FUNCTIONS */

        public static async Task<ObservableCollection<TruckExt>> GetAll()
        {
            var list = new ObservableCollection<TruckExt>();
            list = await TruckMapper.GetAllTruck();
            return list;
        }

        public static async Task<ObservableCollection<TruckExt>> Search(TruckExt truckporter)
        {
            ObservableCollection<TruckExt> truckList = new ObservableCollection<TruckExt>();
            truckList = await TruckMapper.SearchTruck(truckporter);
            return truckList;
        }

    }
}
