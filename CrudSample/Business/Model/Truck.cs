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

    }
}
