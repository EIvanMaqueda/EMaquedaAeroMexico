using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Usuario
    {
        public static ML.Result Login(ML.Usuario usuario) { 
        
            ML.Result result = new ML.Result();
            try
            {
                using (DL.EMaquedaAeroMexicoEntities context=new DL.EMaquedaAeroMexicoEntities())
                {
                    var query=context.UsuarioLogin(usuario.Username,usuario.Password).FirstOrDefault();
                    if (query != null)
                    {

                        result.Correct = true;
                        result.Message = "Autorice";
                    }
                    else {
                        result.Correct = false;
                        result.Message = "No Autorice";
                    }
                }
            }
            catch (Exception ex)
            {

                result.Correct=false;
                result.Message= "No Autorice";
            }
            return result;
        }
    }
}
