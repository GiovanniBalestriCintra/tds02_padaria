using backPadaria.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backPadaria.Service
{
    public static class ProdutoService
    {

        public static void MenuProduto()
        {

            bool sair = false;

            while (!sair)
            {
                Console.WriteLine("----- GESTÃO DE PRODUTOS -----");

                Console.WriteLine("1 - Cadastrar Produto");
                Console.WriteLine("2 - Listar Todos os Produtos");
                Console.WriteLine("3 - Buscar Produto por Id");
                Console.WriteLine("4 - Atualizar Produto");
                Console.WriteLine("5 - Excluir Produto");
                Console.WriteLine("0 - Sair");

                Console.WriteLine("------------------------------");
                Console.WriteLine("Digite uma opção: ");

                string opcao = Console.ReadLine();
                Console.Clear();


                try
                {
                    switch (opcao)
                    {
                        case "1": // Cadastrar
                            CadastrarProdutoMenu();
                            break;

                        case "2": // Listar
                            ListarprodutosMenu();
                            break;

                        case "3": // Buscar
                            BuscarProdutoPorIdMenu();
                            break;

                        case "4": // Atualizar
                            AtualizarProdutoMenu();
                            break;

                        case "5": // Excluir
                            ExcluirProdutoMenu();
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"\n[ERRO DE VALIDAÇÃO]: {ex.Message}");
                }
            }

        }


        private static void CadastrarProdutoMenu()
        {
            Console.WriteLine("----- CADASTRAR PRODUTO -----");

            Console.WriteLine("Digite o nome do Produto: ");
            string nomeProduto = Console.ReadLine();

            Console.WriteLine("Digite o preço do Produto: ");
            decimal.TryParse(Console.ReadLine(), out decimal precoProduto);

            Console.WriteLine("Digite a categoria do Produto: ");
            string categoriaProduto = Console.ReadLine();

            Console.WriteLine("O Produto é fabricado? (true/False): ");
            bool fabricadoProduto = bool.Parse(Console.ReadLine());

            Console.WriteLine("Digite o ID da marca desse Produto: ");
            int.TryParse(Console.ReadLine(), out int idMarca);


            Produto novoProduto = new Produto(nome: nomeProduto, preco: precoProduto, categoria: categoriaProduto, fabricado: fabricadoProduto, marcaId: idMarca);

            int resultadoDoInsert = Produto.Inserir(novoProduto);
            Console.Clear();

            if (resultadoDoInsert > 0)
            {
                Console.WriteLine("Produto cadastrado com sucesso. ");
            }

        }

        private static void ListarprodutosMenu()
        {

            Console.WriteLine("----- LISTA DE PRODUTOS -----");

            List<Produto> lista = Produto.ListarTodos();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhum produto cadastrado no sistema.");
            }
            else
            {
                foreach (var produto in lista)
                {
                    Console.WriteLine($"ID: {produto.Id} ");
                    Console.WriteLine($"Nome: {produto.Nome}");
                    Console.WriteLine($"Preco: {produto.Preco}");
                    Console.WriteLine($"Categoria: {produto.Categoria}");
                    Console.WriteLine($"Fabricado: {produto.Fabricado}");
                    Console.WriteLine($"MarcaId: {produto.MarcaId}");
                }
            }

            Console.WriteLine("\nPressione uma tecla para continuar...");
            Console.ReadKey();
            Console.Clear();

        }

        public static void BuscarProdutoPorIdMenu()
        {

            Console.WriteLine("----- BUSCAR PRODUTO POR ID -----");

            int.TryParse(Console.ReadLine(), out int idProduto);

            Produto produto = Produto.ListarPorId(idProduto);

            if (idProduto != null)
            {
                Console.WriteLine($"ID: {produto.Id} ");
                Console.WriteLine($"Nome: {produto.Nome}");
                Console.WriteLine($"Preco: {produto.Preco}");
                Console.WriteLine($"Categoria: {produto.Categoria}");
                Console.WriteLine($"Fabricado: {produto.Fabricado}");
                Console.WriteLine($"MarcaId: {produto.MarcaId}");
            }
            else
            {
                Console.WriteLine("Produto não encontrado. ");
            }

            Console.WriteLine("\nPressione uma tecla para continuar...");
            Console.ReadKey();
            Console.Clear();

        }



        private static void AtualizarProdutoMenu()
        {
            Console.WriteLine("----- ATUALIZAR PRODUTO POR ID -----");
            Console.WriteLine("Digite o id do produto que deseja atualizar: ");

            int idBusca = 0;
            int.TryParse(Console.ReadLine(), out idBusca);
            Console.WriteLine($"-------> {idBusca}");

            Produto produtoParaAtualizar = Produto.ListarPorId(idBusca);

            if (produtoParaAtualizar != null)
            {
                Console.WriteLine($"Atualizar dados de {produtoParaAtualizar.Nome}");
                Console.WriteLine("Pressione ENTER sem digitar nada para manter os dados atuais ");

                Console.WriteLine($"Novo Preço: Atual ({produtoParaAtualizar.Preco} )");
                string novoPreco = Console.ReadLine();
                if (decimal.TryParse(novoPreco, out decimal preco)) produtoParaAtualizar.Preco = preco;

                Console.WriteLine($"Nova Categoria: Atual ({produtoParaAtualizar.Categoria}) ");
                string? novaCategoria = Console.ReadLine();
                if (string.IsNullOrEmpty(novaCategoria)) produtoParaAtualizar.Categoria = novaCategoria;
               
                Console.WriteLine($"Novo Fabricado: Atual ({produtoParaAtualizar.Fabricado}) ");
                string? novoFabricado = Console.ReadLine();
                if (bool.TryParse(novoFabricado, out bool fabricado)) produtoParaAtualizar.Fabricado = fabricado;

                Console.WriteLine($"Nova MarcaId: Atual ({produtoParaAtualizar.MarcaId}) ");
                string? novaMarcaId = Console.ReadLine();
                if (int.TryParse(novaMarcaId, out int marcaId)) produtoParaAtualizar.MarcaId = marcaId;


                int resultadoAtualizacao = Produto.Atualizar(produtoParaAtualizar);
                if (resultadoAtualizacao > 0) Console.WriteLine("Produto atualizado com sucesso! ");

            }
            else
            {
                Console.WriteLine("Produto não encontrado");
            }

            Console.WriteLine("\nPressione uma tecla para continuar...");
            Console.ReadKey();
            Console.Clear();

        } // FIM ATUALIZAR CLIENTE


        private static void ExcluirProdutoMenu()
        {

            Console.WriteLine("----- EXCLUIR PRODUTO POR ID -----");
            Console.WriteLine("Digite o id do produto que deseja excluir");

            int idBusca = 0;
            int.TryParse(Console.ReadLine(), out idBusca);

            Produto? produtoParaExcluir = Produto.ListarPorId(idBusca);

            if (produtoParaExcluir != null)
            {
                Produto.Deletar(produtoParaExcluir);
                Console.WriteLine("Produto excluído com sucesso");
            }
            else
            {

                Console.WriteLine("Produto não encontrado");

            }

            Console.ReadKey();

        }

    }
}
