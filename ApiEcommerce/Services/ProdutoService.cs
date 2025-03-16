using ApiEcommerce.Models;

namespace ApiEcommerce.Services
{
    public class ProdutoService : IProdutoService
    {
        /*
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoService(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        */

        public async Task<IEnumerable<Produto>> FindAll()
        {
            var criarProdutos = await CriarProduto();
            return criarProdutos;
        }

        public async Task<List<Produto>> CriarProduto()
        {
            List<Produto> listaProduto = new List<Produto>();
            
            for (int i = 0; i < 10;  i++)
            {
                Produto objProduto = new Produto();

                objProduto.Id = i;
                objProduto.nomeProduto = "Nome Produto" + i;
                objProduto.descricao = "descrição" + i;
                objProduto.imgURL = "url" + i;

                 listaProduto.Add(objProduto);
            }

            return await Task.FromResult(listaProduto); ;
        }
    }
}
