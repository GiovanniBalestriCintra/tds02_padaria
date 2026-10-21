using backPadaria.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backPadaria.Service
{
    public static class FuncionarioService
    {

        public static void MenuFuncionario()
        {
            bool sair = false;

            while (!sair)
            {
                Console.WriteLine("----- GESTÃO DE FUNCIONARIO -----");

                Console.WriteLine("1 - Cadastrar Funcionario");
                Console.WriteLine("2 - Listar Todos os Funcionarios");
                Console.WriteLine("3 - Buscar Funcionario por Id");
                Console.WriteLine("4 - Atualizar Funcionario");
                Console.WriteLine("5 - Excluir Funcionario");
                Console.WriteLine("0 - Sair do Programa");

                Console.WriteLine("------------------------------");
                Console.WriteLine("Digite uma opção: ");

                string opcao = Console.ReadLine();
                Console.Clear();

                try
                {
                    switch (opcao)
                    {
                        case "1": // Cadastrar
                            CadastrarFuncionarioMenu();
                            break;

                        case "2": // Listar
                            ListarFuncionariosMenu();
                            break;

                        case "3": // Buscar
                            BuscarFuncionarioPorIdMenu();
                            break;

                        case "4": // Atualizar
                            AtualizarFuncionarioMenu();
                            break;

                        case "5": // Excluir
                            ExcluirFuncionarioMenu();
                            break;

                        
                    }
                }
                catch (Exception ex) 
                {
                    Console.WriteLine($"\n[ERRO DE VALIDAÇÂO] {ex.Message}");
                }
            }

        } // FIM MENU


        private static void CadastrarFuncionarioMenu()
        {
            Console.WriteLine("----- CADASTRAR FUNCIONARIO -----");

            Console.WriteLine("Digite o nome do Funcionario: ");
            string nomeFuncionario = Console.ReadLine();

            Console.WriteLine("Digite o CPF do Funcionario: ");
            string cpfFuncionario = Console.ReadLine();

            Console.WriteLine("Digite o cargo do Funcionario: ");
            string cargoFuncionario = Console.ReadLine();

            Funcionario novoFuncionario = new Funcionario(nome: nomeFuncionario, cpf: cpfFuncionario, cargo: cargoFuncionario);

            int resultadoDoInsert = Funcionario.Inserir(novoFuncionario);
            Console.Clear();

            if (resultadoDoInsert > 0)
            {
                Console.WriteLine("Funcionario cadastrado com sucesso. ");
            }

        }


        private static void ListarFuncionariosMenu()
        {
            Console.WriteLine("----- LISTA DE FUNCIONARIOS -----");

            List<Funcionario> lista = Funcionario.ListarTodos();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhum funcionario cadastrado no sistema. ");
            }
            else
            {
                foreach (var funcionario in lista)
                {
                    Console.WriteLine($"ID: {funcionario.Id}");
                    Console.WriteLine($"Nome: {funcionario.Nome}");
                    Console.WriteLine($"CPF: {funcionario.Cpf}");
                    Console.WriteLine($"Cargo: {funcionario.Cargo}");
                }
            }

            Console.WriteLine("\nPressione uma tecla para continuar...");
            Console.ReadKey();
            Console.Clear();

        }

        public static void BuscarFuncionarioPorIdMenu()
        {
            Console.WriteLine("----- BUSCAR FUNCIONARIO POR ID -----");

            int.TryParse( Console.ReadLine(), out int idFuncionario);

            Funcionario funcionario = Funcionario.ListarPorId(idFuncionario);

            if (idFuncionario != null)
            {
                Console.WriteLine($"ID: {funcionario.Id}");
                Console.WriteLine($"Nome: {funcionario.Nome}");
                Console.WriteLine($"CPF: {funcionario.Cpf}");
                Console.WriteLine($"Cargo: {funcionario.Cargo}");
            }
            else
            {
                Console.WriteLine("Funcionario não encontrado.");
            }

            Console.WriteLine("\nPressione uma tecla para continuar...");
            Console.ReadKey();
            Console.Clear();

        }

        public static void AtualizarFuncionarioMenu()
        {

            Console.WriteLine("----- ATUALIZAR CLIENTE POR ID -----");
            Console.WriteLine("Digite o id do funcionario que deseja atualizar: ");

            int idBusca = 0;
            int.TryParse ( Console.ReadLine(), out idBusca);
            Console.WriteLine($"-------> {idBusca}");

            Funcionario funcionarioParaAtualizar = Funcionario.ListarPorId(idBusca);

            if (funcionarioParaAtualizar != null)
            {
                Console.WriteLine($"Atualizar dados de {funcionarioParaAtualizar.Nome}");
                Console.WriteLine("Pressione ENTER sem digitar nada para manter os dados atuais ");
                Console.WriteLine($"Novo Endereço: Atual ({funcionarioParaAtualizar.Cargo}");

                string novoCargo = Console.ReadLine();
                if (!string.IsNullOrEmpty(novoCargo)) funcionarioParaAtualizar.Cargo = novoCargo;

                int resultadoAtualizacao = Funcionario.Atualizar(funcionarioParaAtualizar);
                if (resultadoAtualizacao > 0) Console.WriteLine("Funcionario atualizado com sucesso. ");
            }
            else
            {
                Console.WriteLine("Funcionario não encontrado. ");
            }

            Console.Clear();

        }

        private static void ExcluirFuncionarioMenu()
        {
            Console.WriteLine("----- EXCLUIR FUNCIONARIO POR ID -----");
            Console.WriteLine("Digite o id do Funcionario que deseja excluir");

            int idBusca = 0;
            int.TryParse( Console.ReadLine(), out idBusca);

            Funcionario? funcionarioParaExcluir = Funcionario.ListarPorId(idBusca);

            if (funcionarioParaExcluir != null )
            {
                Funcionario.Deletar(funcionarioParaExcluir);
                Console.WriteLine("Cliente excluído com sucesso");
            }
            else
            {
                Console.WriteLine("Funcionario não encontrado");
            }

            Console.ReadKey();

        }





    }
}
