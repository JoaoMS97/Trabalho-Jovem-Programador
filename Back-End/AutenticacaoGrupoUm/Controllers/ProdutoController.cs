using AutenticacaoGrupoUm.Dto;
using AutenticacaoGrupoUm.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace AutenticacaoGrupoUm.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProdutoController: ControllerBase
    {
        private readonly IProdutoService _ProdutoService;

        public ProdutoController(IProdutoService produtoService)
        {
            _ProdutoService = produtoService;
        }


        [HttpPost(Name = "ProdutoPost")]
        public IActionResult Post([FromBody]InputDto inputDto)
        {
            var sit = _ProdutoService.GetAddProduto(inputDto);

            if (sit.StatusCode == 404) return NotFound(sit);

            return Ok(sit);
        }

        [HttpGet(Name = "CarrocaGet")]
        public IActionResult Get() => Ok(_ProdutoService.GetCarroca());



        [HttpDelete(Name = "CarrocaDelete")]
        public IActionResult Delete([FromBody]InputDto inputDto) {

            var Sit = _ProdutoService.DeleteCarroca(inputDto);

            if (Sit.StatusCode == 404) return NotFound(Sit);

            return Ok(Sit);
        }
    }
}