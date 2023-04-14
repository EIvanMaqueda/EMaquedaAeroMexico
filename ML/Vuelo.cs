using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Vuelo
    {
        public int IdVuelo { get; set; }
        public string NumeroVuelo { get; set; }
        public ML.Origen Origen { get; set; }
        public ML.Destino Destino { get; set; }
        public DateTime FechaSalida { get; set; }
    }
}
