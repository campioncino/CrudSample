using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SQLite;
namespace CrudSample.Business.Model
{
    [Table("TRUCK")]
    public class Truck
    {
        [PrimaryKey, AutoIncrement]
        [Column("TRUCK_ID")]
        public int? truckId { get; set; }
        
        [Column("CODE")]
        public string code { get; set; }

        [Column("VIN")]
        public string vin { get; set; }

        [Column("URL")]
        public string url { get; set; }

        [Column("TR_ID")]
        public int? trId { get; set; }
        
    }
}
