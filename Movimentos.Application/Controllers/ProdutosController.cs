using Microsoft.AspNetCore.Mvc;
using Movimentos.Domain.Entities;
using Movimentos.Domain.Interfaces;
using System;

namespace Movimentos.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private IBaseService<Produto> _baseService;

        public ProdutosController(IBaseService<Produto> baseService)
        {
            _baseService = baseService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Execute(() => _baseService.Get());
        }

        [HttpGet("{cod}")]
        public IActionResult Get(string cod)
        {
            if (String.IsNullOrEmpty(cod))
                return NotFound();

            return Execute(() => _baseService.GetProdutoByCod(cod));
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
