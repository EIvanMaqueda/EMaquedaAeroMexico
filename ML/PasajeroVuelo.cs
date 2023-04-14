using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class PasajeroVuelo
    {
        public int IdPasajeroVuelo { get; set; }
        public List<ML.Vuelo> Vuelo { get; set; }
        
        public List<ML.Pasajero> Pasajero { get; set; }
    }
}
