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
        

        public async static Task<bool> Exist(string truckId)
        {
            bool exist = await TruckMapper.Exisits(truckId);
            return exist;
        }
        public static async Task SaveTruck(Truck truck)
        {
            await TruckMapper.SaveOrUpdate(truck);
        }

        public static async Task UpdateTruck(Truck truck)
        {
            await TruckMapper.UpdateTruck(truck);
        }

        public static async Task DeleteTruck(Truck truck)
        {
            await TruckMapper.DeleteTruck(truck);
        }

        /* SEARCH FUNCTIONS */

        public static async Task<ObservableCollection<Truck>> GetAll()
        {
            var list = new ObservableCollection<Truck>();
            list = await TruckMapper.GetAllTrucks();
            return list;
        }

        public static async Task<ObservableCollection<Truck>> Search(Truck truckporter)
        {
            ObservableCollection<Truck> truckList = new ObservableCollection<Truck>();
            truckList = await TruckMapper.SearchTruck(truckporter);
            return truckList;
        }

        //public static async Task<Int32> GetId(int truckId)
        //{
        //    Int32 tableId;
        //    tableId = await TruckMapper.GetTruckId(truckId);
        //    return tableId;
        //}
        //public static async Task<int> getId(string id)
        //{

        //    Truck t = await TruckMapper.GetTruckById(id);
        //    return t.Id;
        //}

        //public static async Task<ObservableCollection<Truck>> Search(string id, string name, string url, string code)
        //{

        //    Truck truck = new Truck();
        //    ObservableCollection<Truck> truckList = new ObservableCollection<Truck>();

        //    if (id != null)
        //    {
        //        truck = await TruckMapper.GetTruckById(id);
        //        truckList.Add(truck);
        //    }

        //    else if ((!string.IsNullOrEmpty(name)) || (!string.IsNullOrEmpty(url)) || (!string.IsNullOrEmpty(code)))
        //    {
        //        if (!string.IsNullOrEmpty(name))
        //        {
        //            truckList = await TruckMapper.GetTruckByName(name);
        //        }
        //        else if (!string.IsNullOrEmpty(url))
        //        {
        //            truckList = await TruckMapper.GetTruckByUrl(url);
        //        }
        //        else if (!string.IsNullOrEmpty(code))
        //        {
        //            truckList = await TruckMapper.GetTruckByCode(code);
        //        }

        //    }

        //    else if ((string.IsNullOrEmpty(name)) && (string.IsNullOrEmpty(id)) && (string.IsNullOrEmpty(url)) && (string.IsNullOrEmpty(code)))
        //    {
        //        truckList = await TruckMapper.GetAllTrucks();
        //    }

        //    return truckList;

        //}
    }
}
