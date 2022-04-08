using AutenticacaoGrupoUm.Entities;

namespace AutenticacaoGrupoUm.Repositories
{
    public interface IProdutosRepository
    {
        public ProdutoEntity? GetProduto(ProdutoEntity produtoEntity);

        public ProdutoEntity? GetProdutoCarroca(ProdutoEntity produtoEntity);

        public void AddProduto(ProdutoEntity produtoEntity);

        public void AddProdutoExistente(ProdutoEntity produtoEntity);

        public List<ProdutoEntity> GetCarroca();

        public void DeleteCarroca(ProdutoEntity produtoEntity);
    }
}
