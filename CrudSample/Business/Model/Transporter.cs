using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudSample.Business.Model
{
    public class Transporter : Entity
    {
        public String trId { get; set; }
        public String trName { get; set; }
        public String trCode { get; set; }
        public String trUrl { get; set; }
    }
}
