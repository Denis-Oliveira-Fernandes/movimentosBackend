using Microsoft.AspNetCore.Mvc;
using Movimentos.Domain.Entities;
using Movimentos.Domain.Interfaces;
using Movimentos.Service.Validators;
using System;

namespace Movimentos.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovimentosController : ControllerBase
    {
        private IBaseService<Movimento> _baseService;

        public MovimentosController(IBaseService<Movimento> baseService)
        {
            _baseService = baseService;
        }

        [HttpPost]
        public IActionResult Create([FromBody] Movimento movimento)
        {
            if (movimento == null)
                return NotFound();

            return Execute(() => _baseService.Add<MovimentoValidator>(movimento));
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Execute(() => _baseService.GetMovimentosLanding());
        }

        private IActionResult Execute(Func<object> func)
        {
            try
            {
                var result = func();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
