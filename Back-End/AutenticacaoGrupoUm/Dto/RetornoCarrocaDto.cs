using AutenticacaoGrupoUm.Entities;

namespace AutenticacaoGrupoUm.Dto
{
    public class RetornoCarrocaDto
    {
        public List<ProdutoEntity>? Carroca { get; set; }

        public decimal? valorFinal { get; set; }

    }
}
