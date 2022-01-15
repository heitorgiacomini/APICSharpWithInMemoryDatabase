using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ApplicationAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class VeiculoController : ControllerBase
    {
        private readonly IVeiculoRepository veiculoRepository;
        private readonly IVeiculoDetranFacade veiculoDetran;

        public VeiculoController(IVeiculoRepository veiculoRepository, IVeiculoDetranFacade veiculoDoDetran)
        {
            this.veiculoRepository = veiculoRepository;
            this.veiculoDetran = veiculoDoDetran;
        }

        [HttpGet]
        public IActionResult Get() => Ok(veiculoRepository.GetAll());


        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var veiculo = veiculoRepository.GetById(id);
            if (veiculo == null)
                return NotFound();
            return Ok(veiculo);
        }
        [HttpPost]
        public IActionResult Post([FromBody] Veiculo veiculo)
        {
            veiculoRepository.Add(veiculo);
            return CreatedAtAction(nameof(Get), new { id = veiculo.Id }, veiculo);
        }

        [HttpPut("id")]
        public IActionResult Put(Guid id, [FromBody] Veiculo veiculo)
        {
            veiculoRepository.Update(veiculo);
            return NoContent();
        }
        [HttpDelete("id")]
        public IActionResult Delete(Guid id)
        {
            var veiculo = veiculoRepository.GetById(id);
            if (veiculo == null)
                return NotFound();

            veiculoRepository.Delete(veiculo);

            return NoContent();
        }

        [HttpPut("{id}/vistoria")]
        public IActionResult Put(Guid id)
        {
            veiculoDetran.AgendarVistoriaDetran(id);
            return NoContent();
        }




    }
}
