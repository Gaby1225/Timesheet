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
            if (id > 0)
            {
                var categoria = await _categoriasRepository.Get(id);
                return Ok(categoria);
            }
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Post(Categoria model)
        {
            if (model.Titulo != "")
            {
                var categoria = await _categoriasRepository.Create(model);
                return Ok(categoria);
            }
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Categoria m, int id)
        {
            m.Id = id;
            if (m.Titulo != "")
            {
                var categoria = await _categoriasRepository.Update(m);
                return Ok(categoria);
            }
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var categoria = await _categoriasRepository.Delete(id);
            return Ok(categoria);
        }
    }
}
