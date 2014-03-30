using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudSample.Business.Model
{
    public class Truck : Entity
    {
        /*
        * truck
        */
        public string truckId { get; set; }
        public string Code { get; set; }
        public string Vin { get; set; }
        public string Url { get; set; }

        /*
         * transporter
         */
        public string trId { get; set; }
        public string trName { get; set; }
        public string trCode { get; set; }
        public string trUrl { get; set; }

        public Truck(string truckid, string code, string vin, string url,
            string trid, string trname, string trcode, string trurl) 
        {
            truckId = truckid;
            Code = code;
            Vin = vin;
            Url = url;
            trId = trid;
            trName = trname;
            trUrl = trurl;
            trCode = trcode;
        }

        public Truck() 
        {
            truckId = null;
            Code = null;
            Vin = null;
            Url = null;
            trId = null;
            trName = null;
            trUrl = null;
            trCode = null;
        }
    }
}
