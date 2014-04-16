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

        public static async Task InsertTransporter(Transporter trans)
        {
            await TransporterMapper.InsertTransporter(trans);
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

        public static async Task<ObservableCollection<TransporterExt>> GetAll()
        {
            var list = new ObservableCollection<TransporterExt>();
            list = await TransporterMapper.GetAllTransporters();
            return list;
        }

        public static async Task<ObservableCollection<TransporterExt>> Search(TransporterExt transporter)
        {
            ObservableCollection<TransporterExt> list = new ObservableCollection<TransporterExt>();
            list = await TransporterMapper.SearchTransporter(transporter);
            return list;
        }

        public static async Task<ObservableCollection<TransporterExt>> Search_StartsWith(TransporterExt transporter)
        {
            ObservableCollection<TransporterExt> list = new ObservableCollection<TransporterExt>();
            list = await TransporterMapper.SearchTransporter_StartsWith(transporter);
            return list;
        }
    }
}
