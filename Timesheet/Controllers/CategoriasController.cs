using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using Timesheet.Domain.Interfaces;
using Timesheet.Domain.Models;

namespace Timesheet.Controllers
{
    [ApiController]
    [Route("/api/V1/categorias")]
    public class CategoriasController : ControllerBase
    {
        private readonly IGenerateMethodsCrud<Categoria> _categoriasRepository;
        private readonly ILogger<CategoriasController> _logger;

        public CategoriasController(ILogger<CategoriasController> logger, IGenerateMethodsCrud<Categoria> categoriasRepository)
        {
            _logger = logger;
            _categoriasRepository = categoriasRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Categoria>>> Get()
        {

            var retorno = await _categoriasRepository.Get();
            return Ok(retorno);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Categoria>> Get(int id)
        {
            var categoria = await _categoriasRepository.Get(id);
            return Ok(categoria);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Categoria model)
        {
            var categoria = await _categoriasRepository.Create(model);
            return Ok(categoria);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Categoria m, int id)
        {
            m.Id = id;
            var categoria = await _categoriasRepository.Update(m);
            return Ok(categoria);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var categoria = await _categoriasRepository.Delete(id);
            return Ok(categoria);
        }
    }
}
