using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudSample.Business.Model
{
    public class Transporter : Entity
    {
        public Transporter(String id, String name, String code, String url) 
        {
            trId = id;
            trName = name;
            trCode = code;
            trUrl = url;
        }

        public Transporter()
        {
            // questa è stata inserita perchè al momento c'è un criterio di salvataggio preciso su questa condizione
            // non possono esistere due transporter con lo stesso trId... ma è giusto una convenzione non è vincolante. 
            // Vedere TransporterMapper.SaveOrUpdate(transporter)
            //Random rnd = new Random();
            
            //trId = rnd.Next(1024, 19999);
            trId = null;
            trName = null;
            trCode = null;
            trUrl = null;
        }
        public String trId { get; set; }
        public String trName { get; set; }
        public String trCode { get; set; }
        public String trUrl { get; set; }
    }
}
