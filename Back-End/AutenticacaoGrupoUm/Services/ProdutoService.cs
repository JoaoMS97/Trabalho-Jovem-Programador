using AutenticacaoGrupoUm.Dto;
using AutenticacaoGrupoUm.Entities;
using AutenticacaoGrupoUm.Repositories;

namespace AutenticacaoGrupoUm.Services
{
    public class ProdutoService: IProdutoService
    {
        private readonly IProdutosRepository _ProdutoRepository;

        public ProdutoService(IProdutosRepository usuarioRepository)
        {
            _ProdutoRepository = usuarioRepository;
        }

        public RetornoDto GetAddProduto(InputDto inputDto)
        {
            var produto = new ProdutoEntity()
            {
                Id = inputDto.Id
            };

            var produtoEncontrado = _ProdutoRepository.GetProduto(produto);

            if (produtoEncontrado == null) return new RetornoDto { StatusCode = 404, Retorno = new RetornoProdutoDto { mensagem = "Produto não foi encontrado!" } };

            var existeCarroca = _ProdutoRepository.GetProdutoCarroca(produtoEncontrado);

            if (existeCarroca == null) _ProdutoRepository.AddProduto(produtoEncontrado);
            else _ProdutoRepository.AddProdutoExistente(existeCarroca);

            return new RetornoDto {StatusCode = 200, Retorno = new RetornoProdutoDto { mensagem = "Produto Adicionado ao carrinho!" } };
        }

        public RetornoDto GetCarroca()
        {
            
            return new RetornoDto { StatusCode = 200, Retorno = new RetornoCarrocaDto { Carroca = _ProdutoRepository.GetCarroca() , valorFinal = CalcularValorFinal() } };
        }

        private decimal? CalcularValorFinal()
        {
            var itens = _ProdutoRepository.GetCarroca();
            decimal? valor = 0m;

            foreach (var x in itens)
            {
                valor += (x.Valor * x.Quantidade);
            };
            return valor;
        }

        public RetornoDto DeleteCarroca(InputDto inputDto)
        {
            var produto = new ProdutoEntity() {   
                Id = inputDto.Id          
            };

            bool produtoEncontrado = _ProdutoRepository.GetProduto(produto) == null ? true: false;

            if (produtoEncontrado == true) return new RetornoDto { StatusCode = 404, Retorno = new RetornoProdutoDto { mensagem = "Produto não foi encontrado!" } };

            var ProdutoDaCarroca = _ProdutoRepository.GetProdutoCarroca(produto);

            if (ProdutoDaCarroca == null) return new RetornoDto { StatusCode = 400, Retorno = new RetornoProdutoDto { mensagem = "Produto não existe no carrinho!" } };

            _ProdutoRepository.DeleteCarroca(ProdutoDaCarroca);

            return new RetornoDto { StatusCode = 200, Retorno = new RetornoProdutoDto { mensagem = "Produto excluido com sucesso" } };
        }

    }
}
