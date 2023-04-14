using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Vuelo
    {
        public static ML.Result GetByDate(DateTime fecha1,DateTime fecha2) { 

            ML.Result result = new ML.Result();
            try
            {
                using (DL.EMaquedaAeroMexicoEntities context=new DL.EMaquedaAeroMexicoEntities())
                {
                    var query = context.VueloGetByDate(fecha1,fecha2).ToList();
                    if (query!=null)
                    {
                        result.Objects = new List<object>();
                        foreach (var obj in query)
                        {
                            ML.Vuelo vuelo = new ML.Vuelo();
                            vuelo.IdVuelo = obj.IdVuelo;
                            vuelo.NumeroVuelo = obj.NumeroVuelo;
                            vuelo.Destino=new ML.Destino();
                            vuelo.Destino.IdDestino=obj.IdDestino;
                            vuelo.Origen=new ML.Origen();
                            vuelo.Origen.IdOrigen = obj.IdOrigen;
                            vuelo.FechaSalida = obj.FechaSalida.Value;

                            result.Objects.Add(vuelo);
                        }
                        result.Correct = true;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct=false;
                result.Message=ex.Message;
                throw;
            }
            return result;

        }

        public static ML.Result Add(ML.PasajeroVuelo reservacion)
        {

            ML.Result result = new ML.Result();
            try
            {
                using (DL.EMaquedaAeroMexicoEntities context = new DL.EMaquedaAeroMexicoEntities())
                {
                    ML.Pasajero[] pasajeros=new ML.Pasajero[reservacion.Pasajero.Count];
                    ML.Vuelo[] vuelos=new ML.Vuelo[reservacion.Vuelo.Count];
                    
                    for (int i = 0; i < pasajeros.Length; i++)
                    {
                        foreach (ML.Pasajero pasajero in reservacion.Pasajero)
                        {
                            pasajeros[i] = pasajero;
                        }
                        foreach (ML.Vuelo vuelo in reservacion.Vuelo)
                        {
                            vuelos[i] = vuelo;
                        }

                        int query = context.Reservacion(vuelos[i].IdVuelo, pasajeros[i].IdPasajero);
                    
                    if (query > 0)
                    {
                        result.Correct = true;
                            result.Message = "Vuelo reservado exitosamente";

                    }
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
