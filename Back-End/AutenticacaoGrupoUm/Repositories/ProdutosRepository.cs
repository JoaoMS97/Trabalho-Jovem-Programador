using AutenticacaoGrupoUm.Entities;

namespace AutenticacaoGrupoUm.Repositories
{
    public class ProdutosRepository: IProdutosRepository
    {
        public List<ProdutoEntity> Produtos = new List<ProdutoEntity>()
        {
            new ProdutoEntity
            {
               Id = Guid.Parse("4d97cc39-309b-4bb0-9ae8-08c847a81e41"),
               Nome = "Vaca Eliana",
               //Especie = "Suino",
               Valor = 22900.00m,
               Src = "img/Vaca Eliana.gif"
            },
            new ProdutoEntity
            {
               Id = Guid.Parse("094f84b5-682c-4815-acc1-e261596fc1a7"),
               Nome = "Galinha Virgínia",
               Valor = 129.00m,
               Src = "img/floquinho3.jpg"
            },
            new ProdutoEntity
            {
               Id = Guid.Parse("ae745063-7416-4842-b897-741e9ccceda3"),
               Nome = "Flash o porquinho",
               Valor = 400.00m,
               Src = "img/flash2.jpeg."
            },
            new ProdutoEntity
            {
               Id = Guid.Parse("b1d1b115-aee9-494c-9704-12c164af0826"),
               Nome = "Galo Robô (da concorrência)",
               Valor = 789.00m,
               Src = "img/galorobo.png"
            },
            new ProdutoEntity
            {
               Id = Guid.Parse("3415745c-b7d2-47a2-b4d4-b0838612f5cb"),
               Nome = "Galinha do Pica Pau",
               Valor = 500.00m,
               Src = "img/galinhadopicapau.gif"
            },
            new ProdutoEntity
            {
               Id = Guid.Parse("63797725-6210-4519-a47b-05d1d8118210"),
               Nome = "Galo Cego",
               Valor = 5.00m,
               Src = "img/galocego.jfif"
            },
            new ProdutoEntity
            {
               Id = Guid.Parse("11d8f4fe-c73a-418d-962e-e0c58be024cf"),
               Nome = "Porco Arranha",
               Valor = 350.00m,
               Src = "img/spiderpig.gif"
            },
            new ProdutoEntity
            {
               Id = Guid.Parse("4876bc30-88b6-44dd-9aa4-ace7eda41fdd"),
               Nome = "Porquinho Bruninho",
               Valor = 699.00m,
               Src = "img/bruninho2.jpg"
            },
            new ProdutoEntity
            {
               Id = Guid.Parse("cc8ae80f-91b2-40b3-88be-aec1ea34756e"),
               Nome = "Leitão (aquele do Ursinho Pooh)",
               Valor = 40.00m,
               Src = "img/leitao.jpg"
            },
            new ProdutoEntity
            {
               Id = Guid.Parse("221cfba4-2f50-4c82-ae7b-a57e48422dde"),
               Nome = "Touro Raiz",
               Valor = 8300.00m,
               Src = "img/raiz.webp"
            },
            new ProdutoEntity
            {
               Id = Guid.Parse("03fb1011-5ef1-422d-b7a8-b1cb77f3cdac"),
               Nome = "Vaquinha Anchieta",
               Valor = 4700.00m,
               Src = "img/anchieta3.jpg"
            },
            new ProdutoEntity
            {
               Id = Guid.Parse("cd169c84-b0e9-4acb-b794-b89092bf4cb5"),
               Nome = "Lobo (aquele de wallstreet)",
               Valor = 1000000.00m,
               Src = "img/wallstreet.jpg."
            },
        };

        public List<ProdutoEntity> Carroca = new List<ProdutoEntity>();

        public ProdutoEntity? GetProduto(ProdutoEntity produtoEntity) => Produtos.Find(x => x.Id == produtoEntity.Id);

        public ProdutoEntity? GetProdutoCarroca(ProdutoEntity produtoEntity) => Carroca.Find(x => x.Id == produtoEntity.Id);

        public void AddProduto(ProdutoEntity produtoEntity) =>  Carroca.Add(new ProdutoEntity
        {
            Id = produtoEntity.Id,
            Nome = produtoEntity.Nome,
            //Raca = produtoEntity.Raca,
            Src = produtoEntity.Src,
            Valor = produtoEntity.Valor,
            Quantidade = 1
            
        });

        public void AddProdutoExistente(ProdutoEntity produtoEntity)
        {

            int localizacao = Carroca.IndexOf(produtoEntity);

            Carroca[localizacao].Quantidade++;

        }

        public List<ProdutoEntity> GetCarroca() => Carroca;

        public void DeleteCarroca(ProdutoEntity produtoEntity)
        {
            if (produtoEntity.Quantidade == 1)
            {
                Carroca.Remove(produtoEntity);
            }
            else
            {
                int localizacao = Carroca.IndexOf(produtoEntity);

                Carroca[localizacao].Quantidade--;
            }
        }
    }
}
