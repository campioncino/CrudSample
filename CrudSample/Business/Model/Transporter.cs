using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SQLite;

namespace CrudSample.Business.Model
{
    [Table("TRANSPORTER")]
    public class Transporter
    {
        [PrimaryKey, AutoIncrement]
        [Column("TR_ID")]
        public int? trId { get; set; }

        [Column("CODE")]
        public String code { get; set; }

        [Column("NAME")]
        public String name { get; set; }

        [Column("URL")]
        public String url { get; set; }
    }
}
