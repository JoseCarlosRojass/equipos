﻿using Microsoft.AspNetCore.Mvc;
using WebApplication2.Context;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SalarioController : ControllerBase
    {
        private readonly ILogger<SalarioController> _logger;
        private readonly AplicacionContexto _aplicacionContexto;
        public SalarioController(
            ILogger<SalarioController> logger,
            AplicacionContexto aplicacionContexto)
        {
            _logger = logger;
            _aplicacionContexto = aplicacionContexto;
        }
        //Create: Crear estudiantes
        [Route("")]
        [HttpPost]
        public IActionResult Post(
            [FromBody] Salario salario)
        {
            _aplicacionContexto.Salario.Add(salario);
            _aplicacionContexto.SaveChanges();
            return Ok(salario);
        }
        //READ: Obtener lista de estudiantes
        [Route("")]
        [HttpGet]
        public IEnumerable<Salario> Get()
        {
            return _aplicacionContexto.Salario.ToList();
        }
        //Update: Modificar estudiantes
        [Route("/id")]
        [HttpPut]
        public IActionResult Put([FromBody] Salario salario)
        {
            _aplicacionContexto.Salario.Update(salario);
            _aplicacionContexto.SaveChanges();
            return Ok(salario);
        }
        //Delete: Eliminar estudiantes
        [Route("/id")]
        [HttpDelete]
        public IActionResult Delete(int salarioId)
        {
            _aplicacionContexto.Salario.Remove(
                _aplicacionContexto.Salario.ToList()
                .Where(x => x.idSalario == salarioId)
                .FirstOrDefault());
            _aplicacionContexto.SaveChanges();
            return Ok(salarioId);
        }
    }
}