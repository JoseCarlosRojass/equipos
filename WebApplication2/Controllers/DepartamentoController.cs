using Microsoft.AspNetCore.Mvc;
using WebApplication2.Context;
using WebApplication2.Models;

namespace WebApplication2.DepartamentoControllers
{
    [ApiController]
    [Route("[controller]")]
    public class DepartamentoController : ControllerBase
    {

        private readonly ILogger<DepartamentoController> _logger;

        public DepartamentoController(
            ILogger<DepartamentoController> logger)
        {
            _logger = logger;
        }

        //Create
        [Route("")]
        [HttpPost]
        public IActionResult Post(
            [FromBody] Departamento departamento)
        {
            _aplicacionContexto.Departamento.Add(departamento);
            _aplicacionContexto.SaveChanges();
            return Ok(departamento);
        }

        //READ

        [Route("")]
        [HttpGet]
        public IEnumerable<Departamento> GetDepartamentos()
        {
            return _aplicacionContexto.Departamento.ToList();
        }

        //Update
        [Route("departamento")]
        [HttpPut]
        public IActionResult PutDepartamento(
            [FromBody] Departamento departamento)
        {
            _aplicacionContexto.Departamento.Update(departamento);
            _aplicacionContexto.SaveChanges();
            return Ok(departamento);
        }

        //Delete
        [Route("departamento/{departamentoId}")]
        [HttpDelete]
        public IActionResult DeleteDepartamento(int departamentoId)
        {
            _aplicacionContexto.Departamento.Remove(
                _aplicacionContexto.Departamento.ToList()
                .Where(x => x.IdDepartamento == departamentoId)
                .FirstOrDefault());
            _aplicacionContexto.SaveChanges();
            return Ok(departamentoId);
        }
    }
}
