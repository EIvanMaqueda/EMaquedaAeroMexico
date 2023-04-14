using System.Web.Http;


namespace SL_WEB_API.Controllers
{
    public class PasajeroController : ApiController
    {
        [HttpPost]
        [Route("Api/Pasajero/Add")]
        public IHttpActionResult Update([FromBody] ML.Pasajero pasajero)
        {
            ML.Result result = BL.Pasajero.Add(pasajero);
            if (result.Correct)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }

        }
    }
}