using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Pasajero
    {
        public static ML.Result Add(ML.Pasajero pasajero) {

            ML.Result result = new ML.Result();
            try
            {
                using (DL.EMaquedaAeroMexicoEntities context=new DL.EMaquedaAeroMexicoEntities())
                {
                    int query = context.PasajeroAdd(pasajero.Nombre,pasajero.Apellidos);
                    if (query>0)
                    {
                        result.Correct = true;
                    }
                }
            }
            catch (Exception ex)
            {

                result.Correct = false;
                result.Message = ex.Message;
            }
            return result;
        }
    }
}
