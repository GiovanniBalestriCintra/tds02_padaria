using backPadaria.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backPadaria.Service
{
    public static class MarcaService
    {
        public static void MenuMarca()
        {
            bool sair = false;

            while (!sair)
            {
                Console.WriteLine("----- GESTÃO DE MARCAS -----");

                Console.WriteLine("1 - Cadastrar Marca");
                Console.WriteLine("2 - Listar Todas as Marcas");
                Console.WriteLine("3 - Buscar Marca por Id");
                Console.WriteLine("4 - Atualizar Marca");
                Console.WriteLine("5 - Excluir Marca");
                Console.WriteLine("0 - Sair");

                Console.WriteLine("------------------------------");
                Console.WriteLine("Digite uma opção: ");

                string opcao = Console.ReadLine();
                Console.Clear();

                try
                {
                    switch (opcao)
                    {
                        case "1":
                            CadastrarMarcaMenu();
                            break;

                        case "2":
                            ListarMarcasMenu();
                            break;

                        case "3":
                            BuscarMarcaPorIdMenu();
                            break;

                        case "4":
                            AtualizarMarcaMenu();
                            break;

                        case "5":
                            ExcluirMarcaMenu();
                            break;

                        case "0":
                            sair = true;
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"\n[ERRO DE VALIDAÇÃO]: {ex.Message}");
                }
            }
        }

    
        


        private static void CadastrarMarcaMenu()
        {
            Console.WriteLine("----- CADASTRAR MARCA -----");

            Console.WriteLine("Digite o nome da Marca: ");
            string nomeMarca = Console.ReadLine();

            Console.WriteLine("Digite o telefone da Marca: ");
            string telefoneMarca = Console.ReadLine();


            Marca novaMarca = new Marca(nome: nomeMarca, telefone: telefoneMarca);

            int resultadoDoInsert = Marca.Inserir(novaMarca);
            Console.Clear();

            if (resultadoDoInsert > 0)
            {
                Console.WriteLine("Marca cadastrado com sucesso. ");
            }

        }




        private static void ListarMarcasMenu()
        {

            Console.WriteLine("----- LISTA DE MARCAS -----");

            List<Marca> lista = Marca.ListarTodos();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma Marca cadastrado no sistema.");
            }
            else
            {
                foreach (var marca in lista)
                {
                    Console.WriteLine($"ID: {marca.Id} ");
                    Console.WriteLine($"Nome: {marca.Nome}");
                    Console.WriteLine($"Telefone: {marca.Telefone}");
                }
            }

            Console.WriteLine("\nPressione uma tecla para continuar...");
            Console.ReadKey();
            Console.Clear();

        }




        public static void BuscarMarcaPorIdMenu()
        {

            Console.WriteLine("----- BUSCAR MARCA POR ID -----");

            int.TryParse(Console.ReadLine(), out int idMarca);

            Marca marca = Marca.ListarPorId(idMarca);

            if (idMarca != null)
            {
                Console.WriteLine($"ID: {marca.Id}");
                Console.WriteLine($"Nome: {marca.Nome}");
                Console.WriteLine($"Telefone: {marca.Telefone}");
            }
            else
            {
                Console.WriteLine("Cliente não encontrado. ");
            }

            Console.WriteLine("\nPressione uma tecla para continuar...");
            Console.ReadKey();
            Console.Clear();

        }



        private static void AtualizarMarcaMenu()
        {
            Console.WriteLine("----- ATUALIZAR MARCA POR ID -----");
            Console.WriteLine("Digite o id do cliente que deseja atualizar: ");

            int idBusca = 0;
            int.TryParse(Console.ReadLine(), out idBusca);
            Console.WriteLine($"-------> {idBusca}");

            Marca marcaParaAtualizar = Marca.ListarPorId(idBusca);

            if (marcaParaAtualizar != null)
            {
                Console.WriteLine($"Atualizar dados de {marcaParaAtualizar.Nome}");
                Console.WriteLine("Pressione ENTER sem digitar nada para manter os dados atuais ");
                Console.WriteLine($"Novo Telefone: Atual ({marcaParaAtualizar.Telefone} )");

                string novoTelefone = Console.ReadLine();
                if (!string.IsNullOrEmpty(novoTelefone)) marcaParaAtualizar.Telefone = novoTelefone;

            }
            else
            {
                Console.WriteLine("Marca não encontrado");
            }

            Console.WriteLine("\nPressione uma tecla para continuar...");
            Console.ReadKey();
            Console.Clear();

        } // FIM ATUALIZAR CLIENTE


        private static void ExcluirMarcaMenu()
        {

            Console.WriteLine("----- EXCLUIR MARCA POR ID -----");
            Console.WriteLine("Digite o id da Marca que deseja excluir");

            int idBusca = 0;
            int.TryParse(Console.ReadLine(), out idBusca);

            Marca? marcaParaExcluir = Marca.ListarPorId(idBusca);

            if (marcaParaExcluir != null)
            {
                Marca.Deletar(marcaParaExcluir);
                Console.WriteLine("Marca excluída com sucesso");
            }
            else
            {

                Console.WriteLine("Marca não encontrado");

            }

            Console.ReadKey();

        }

    }
}

