
using System;
using System.Data;
using System.Web.Http;

namespace SL_WEB_API.Controllers
{
    public class VueloController : ApiController
    {
        [HttpGet]
        [Route("Api/Vuelo/GetByDate/{fecha1}/{fecha2}")]
        public IHttpActionResult GetByDate(DateTime fecha1, DateTime fecha2)
        {
            ML.Result result = BL.Vuelo.GetByDate(fecha1, fecha2);
            if (result.Correct)
            {
                return Ok(result.Objects);
            }
            else
            {
                return NotFound();
            }

        }

        [HttpPost]
        [Route("Api/Vuelo/Recervacion")]
        public IHttpActionResult Add([FromBody]ML.PasajeroVuelo pasajeroVuelo)
        {
           ML.Result result =BL.Vuelo.Add(pasajeroVuelo);
            if (result.Correct)
            {
                return Ok(result.Message);
            }
            else
            {
                return NotFound();
            }

        }
    }
}