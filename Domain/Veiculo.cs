using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Veiculo
    {
        public Guid Id { get; set; }
        public String Placa { get; set; }    
        public String Marca { get; set; }    
        public String AnoFabricacao { get; set; }    
    }
}
