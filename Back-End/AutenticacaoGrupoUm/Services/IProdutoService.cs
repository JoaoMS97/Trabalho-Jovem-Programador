using AutenticacaoGrupoUm.Dto;
using AutenticacaoGrupoUm.Entities;

namespace AutenticacaoGrupoUm.Services
{
    public interface IProdutoService
    {
        public RetornoDto GetAddProduto(InputDto inputDto);

        public RetornoDto GetCarroca();

        public RetornoDto DeleteCarroca(InputDto inputDto);
    }
}
