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
    public class TransporterService
    {

        public static void createDb()
        {
            TransporterMapper.CreateDatabase();
        }

        public async static Task<bool> Exist(string transId)
        {
            bool exist = await TransporterMapper.Exisits(transId);
            return exist;
        }
        public static async Task SaveTransporter(Transporter trans)
        {
            await TransporterMapper.SaveOrUpdate(trans);
        }

        public static async Task UpdateTransporter(Transporter trans)
        {
            await TransporterMapper.UpdateTransporter(trans);
        }

        public static async Task DeleteTransporter(Transporter trans)
        {
            await TransporterMapper.DeleteTransporter(trans);
        }

        /* SEARCH FUNCTIONS */ 

        public static async Task<ObservableCollection<Transporter>> GetAll()
        {
            var list = new ObservableCollection<Transporter>();
            list = await TransporterMapper.GetAllTransporters();
            return list;
        }

        public static async Task<ObservableCollection<Transporter>> Search(Transporter transporter)
        {
            ObservableCollection<Transporter> transList = new ObservableCollection<Transporter>();
            transList = await TransporterMapper.SearchTransporter(transporter);
            return transList;
        }

        public static async Task<Int32> GetId(int transId)
        {
            Int32 tableId;
            tableId = await TransporterMapper.GetTransporterId(transId);
            return tableId;
        }
        public static async Task<int> getId(string id)
        {

            Transporter t = await TransporterMapper.GetTransporterById(id);
            return t.Id;
        }

        public static async Task<ObservableCollection<Transporter>> Search(string id, string name, string url, string code)
        {

            Transporter trans = new Transporter();
            ObservableCollection<Transporter> transList = new ObservableCollection<Transporter>();

            if (id != null)
            {
                trans = await TransporterMapper.GetTransporterById(id);
                transList.Add(trans);
            }

            else if ((!string.IsNullOrEmpty(name)) || (!string.IsNullOrEmpty(url)) || (!string.IsNullOrEmpty(code)))
            {
                if (!string.IsNullOrEmpty(name))
                {
                    transList = await TransporterMapper.GetTransporterByName(name);
                }
                else if (!string.IsNullOrEmpty(url))
                {
                    transList = await TransporterMapper.GetTransporterByUrl(url);
                }
                else if (!string.IsNullOrEmpty(code))
                {
                    transList = await TransporterMapper.GetTransporterByCode(code);
                }

            }

            else if ((string.IsNullOrEmpty(name)) && (string.IsNullOrEmpty(id)) && (string.IsNullOrEmpty(url)) && (string.IsNullOrEmpty(code)))
            {
                transList = await TransporterMapper.GetAllTransporters();
            }

            return transList;

        }
    }
}
