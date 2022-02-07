using Microsoft.AspNetCore.Mvc;
using Movimentos.Domain.Entities;
using Movimentos.Domain.Interfaces;
using System;

namespace Movimentos.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoCosifController : ControllerBase
    {
        private IBaseService<ProdutoCosif> _baseService;

        public ProdutoCosifController(IBaseService<ProdutoCosif> baseService)
        {
            _baseService = baseService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Execute(() => _baseService.Get());
        }

        [HttpGet("{produtoCod}")]
        public IActionResult Get(string produtoCod)
        {
            if (String.IsNullOrEmpty(produtoCod))
                return NotFound();

            return Execute(() => _baseService.GetProdutoCosifByProdutoCod(produtoCod));
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
