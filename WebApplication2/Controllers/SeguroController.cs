using Microsoft.AspNetCore.Mvc;
using WebApplication2.Context;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SeguroController : ControllerBase
    {
        private readonly ILogger<SeguroController> _logger;
        private readonly AplicacionContexto _aplicacionContexto;
        public SeguroController(
            ILogger<SeguroController> logger,
            AplicacionContexto aplicacionContexto)
        {
            _logger = logger;
            _aplicacionContexto = aplicacionContexto;
        }
        //Create: Crear estudiantes
        [Route("")]
        [HttpPost]
        public IActionResult Post(
            [FromBody] Seguro nuevoSeguro)
        {
            _aplicacionContexto.Seguro.Add(nuevoSeguro);
            _aplicacionContexto.SaveChanges();
            return Ok(nuevoSeguro);
        }
        //READ: Obtener lista de estudiantes
        [Route("")]
        [HttpGet]
        public IEnumerable<Seguro> Get()
        {
            return _aplicacionContexto.Seguro.ToList();
        }
        //Update: Modificar estudiantes
        [Route("/id")]
        [HttpPut]
        public IActionResult Put([FromBody] Seguro actualizarSeguro)
        {
            _aplicacionContexto.Seguro.Update(actualizarSeguro);
            _aplicacionContexto.SaveChanges();
            return Ok(actualizarSeguro);
        }
        //Delete: Eliminar estudiantes
        [Route("/id")]
        [HttpDelete]
        public IActionResult Delete(string seguroID)
        {
            _aplicacionContexto.Seguro.Remove(
                _aplicacionContexto.Seguro.ToList()
                .Where(x => x.idSeguro == seguroID)
                .FirstOrDefault());
            _aplicacionContexto.SaveChanges();
            return Ok(seguroID);
        }
    }
}
