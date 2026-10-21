using backPadaria.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backPadaria.Service
{
    public static class ClienteService
    {

        public static void MenuCliente()
        {

            bool sair = false;

            while (!sair)
            {
                Console.WriteLine("===== GESTÃO DE CLIENTES =====");

                Console.WriteLine("1 - Cadastrar Cliente");
                Console.WriteLine("2 - Listar Todos os Clientes");
                Console.WriteLine("3 - Buscar Cliente por Id");
                Console.WriteLine("4 - Atualizar Cliente");
                Console.WriteLine("5 - Excluir Cliente");
                Console.WriteLine("6 - Visualizar Pontuação");
                Console.WriteLine("0 - Sair do Programa");

                Console.WriteLine("==============================");
                Console.WriteLine("Digite uma opção: ");

                string opcao = Console.ReadLine();
                Console.Clear();


                try
                {
                    switch (opcao)
                    {
                        case "1": // Cadastrar
                            CadastrarClienteMenu();
                            break;

                        case "2": // Listar
                            ListarClientesMenu();
                            break;

                        case "3": // Buscar
                            BuscarClientePorIdMenu();
                            break;

                        case "4": // Atualizar
                            AtualizarClienteMenu();
                            break;

                        case "5": // Excluir
                            ExcluirClienteMenu();
                            break;

                        case "6": // VisualizarPontuação
                            VisualizarPontuaçãoClienteMenu();
                            break;

                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"\n[ERRO DE VALIDAÇÃO]: {ex.Message}");
                }
            }
        } // FIM MENU



        private static void CadastrarClienteMenu()
        {
            Console.WriteLine("----- CADASTRAR CLIENTE -----");

            Console.WriteLine("Digite o nome do cliente: ");
            string nomeCliente = Console.ReadLine();

            Console.WriteLine("Digite o endereço do cliente: ");
            string enderecoCliente = Console.ReadLine();

            Console.WriteLine("Digite o CPF do cliente: ");
            string cpfCliente = Console.ReadLine();

            Console.WriteLine("Digite o telefone do cliente: ");
            string telefoneCliente = Console.ReadLine();

            Console.WriteLine("Digite a quantidade de pontos: ");
            int.TryParse(Console.ReadLine(), out int pontosCliente);


            Cliente NovoCliente = new Cliente (nome: nomeCliente, endereco: enderecoCliente, cpf :  cpfCliente, telefone : telefoneCliente, pontos: pontosCliente);

            int resultadoDoInsert = Cliente.Inserir(NovoCliente);
            Console.Clear();

            if (resultadoDoInsert > 0)
            {
                Console.WriteLine("Cliente cadastrado com sucesso. ");
            }

        }

        private static void ListarClientesMenu()
        {

            Console.WriteLine("----- LISTA DE CLIENTES -----");

            List<Cliente> lista = Cliente.ListarTodos();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhum cliente cadastrado no sistema.");
            }
            else
            {
                foreach (var cliente in lista)
                {
                    Console.WriteLine($"ID: {cliente.Id} | Nome: {cliente.Nome} | CPF: {cliente.Cpf} | Pontos: {cliente.Pontos} ");
                }
            }

            Console.WriteLine("\nPressione uma tecla para continuar...");
            Console.ReadKey();
            Console.Clear();

        }

        public static void BuscarClientePorIdMenu()
        {

            Console.WriteLine("----- BUSCAR CLIENTE POR ID -----");

            int.TryParse(Console.ReadLine(), out int idCliente);

            Cliente cliente = Cliente.ListarPorId(idCliente);

            if (idCliente != null)
            {
                Console.WriteLine($"ID: {cliente.Id}");
                Console.WriteLine($"Nome: {cliente.Nome}");
                Console.WriteLine($"CPF: {cliente.Cpf}");
                Console.WriteLine($"Telefone: {cliente.Telefone}");
                Console.WriteLine($"Pontos: {cliente.Pontos}");
            }
            else
            {
                Console.WriteLine("Cliente não encontrado. ");
            }

            Console.WriteLine("\nPressione uma tecla para continuar...");
            Console.ReadKey();
            Console.Clear();

        }



        private static void AtualizarClienteMenu()
        {
            Console.WriteLine("----- ATUALIZAR CLIENTE POR ID -----");
            Console.WriteLine("Digite o id do cliente que deseja atualizar: ");

            int idBusca = 0;
            int.TryParse(Console.ReadLine(), out idBusca);
            Console.WriteLine($"-------> {idBusca}");

            Cliente clienteParaAtualizar = Cliente.ListarPorId(idBusca);

            if (clienteParaAtualizar != null)
            {
                Console.WriteLine($"Atualizar dados de {clienteParaAtualizar.Nome}");
                Console.WriteLine("Pressione ENTER sem digitar nada para manter os dados atual ");
                Console.WriteLine($"Novo Endereço: Atual ({clienteParaAtualizar.Endereco} )");

                string novoEndereco = Console.ReadLine();
                if (!string.IsNullOrEmpty(novoEndereco)) clienteParaAtualizar.Endereco = novoEndereco;

                Console.WriteLine($"Novo Telefone Atual: ({clienteParaAtualizar.Telefone}) ");
                string? novoTelefone = Console.ReadLine();
                if (!string.IsNullOrEmpty(novoTelefone)) clienteParaAtualizar.Telefone = novoTelefone;

                int resultadoAtualizacao = Cliente.Atualizar(clienteParaAtualizar);
                if (resultadoAtualizacao > 0) Console.WriteLine("Cliente atualizado com sucesso! ");

            }
            else
            {
                Console.WriteLine("Cliente não encontrado");
            }

            Console.ReadKey();

        } // FIM ATUALIZAR CLIENTE


        private static void ExcluirClienteMenu()
        {

            Console.WriteLine("----- EXCLUIR CLIENTE POR ID -----");
            Console.WriteLine("Digite o id do cliente que deseja excluir");

            int idBusca = 0;
            int.TryParse(Console.ReadLine(), out idBusca);

            Cliente? clienteParaExcluir = Cliente.ListarPorId(idBusca);

            if (clienteParaExcluir != null)
            {
                Cliente.Deletar(clienteParaExcluir);
                Console.WriteLine("Cliente excluído com sucesso");
            }
            else
            {

                Console.WriteLine("Cliente não encontrado");

            }

            Console.ReadKey();

        }


        private static void ExibirPotuacaoClienteMenu()
        {
            Console.WriteLine("------ EXIBIR PONTUAÇÃO ----- ");
            Console.WriteLine("Digite o id do cliente: ");

            int idConsole;

            int.TryParse(Console.ReadLine(), out idConsole);

            Cliente? clienteBusca = Cliente.ListarPorId(idConsole);

            if (clienteBusca == null)
            {

                Console.WriteLine("Cliente não encontrado");

            }
            else
            {

                Console.WriteLine($"ID: {clienteBusca.Id} " +
                    $"\nNome {clienteBusca.Nome} " +
                    $"\nCPF: {clienteBusca.Cpf} " +
                    $"\nPontos: {clienteBusca.Pontos} ");


            }

            Console.WriteLine("\nPressione uma tecla para continuar...");
            Console.ReadKey();
        } // 


    }



    
}      
    
