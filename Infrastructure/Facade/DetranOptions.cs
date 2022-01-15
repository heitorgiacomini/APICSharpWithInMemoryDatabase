using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Facade
{
    public class DetranOptions
    {
        public Guid Id { get; } = Guid.NewGuid();
        public String BaseUrl { get; set; }
        public String VistoriaUri { get; set; }
        public int QuantidadeDiasParaAgendamento { get; set; }
    }
}
