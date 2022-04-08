namespace AutenticacaoGrupoUm.Entities
{
    public class ProdutoEntity
    { 
        public Guid Id { get; set; }

        public string Nome { get; set; }

        //public string Raca { get; set; }

        public decimal? Valor { get; set; }

        public int? Quantidade { get; set; }

        public string Src { get; set; }


    }
}
