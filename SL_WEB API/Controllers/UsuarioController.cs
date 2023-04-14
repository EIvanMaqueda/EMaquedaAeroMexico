using System.Web.Http;
using System.Net;

namespace SL_WEB_API.Controllers
{
    public class UsuarioController : ApiController
    {


        [HttpPost]
        [Route("Api/Usuario/Login")]
        public IHttpActionResult Login([FromBody] ML.Usuario usuario)
        {
            ML.Result result = BL.Usuario.Login(usuario);
            if (result.Correct)
            {
                return Ok(result.Message);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, result.Message);
            }

        }
    }
}