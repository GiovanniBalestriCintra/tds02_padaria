using backPadaria.Model;
using backPadaria.Service;

namespace backPadaria
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //Console.WriteLine("Digite o nome do cliente: ");
            //string nomeCliente = Console.ReadLine();

            //Console.WriteLine("Digite o cpf do cliente: ");
            //string cpfCliente = Console.ReadLine();

            //Console.WriteLine("Digite o telefone do cliente: ");
            //string telefoneCliente = Console.ReadLine();

            //Console.WriteLine("Digite o endereco do cliente: ");
            //string enderecoCliente = Console.ReadLine();

            //Console.WriteLine("Digite a quantidade de pontos: ");
            //int pontosCliente = int.Parse(Console.ReadLine());



            //// Refatoração //
            //Cliente cliente1 = new Cliente(
            //       nome: nomeCliente,
            //       cpf: cpfCliente,
            //       telefone: telefoneCliente,
            //       endereco: enderecoCliente,
            //       pontos: pontosCliente
            //   );

            //Cliente.inserir(cliente1);

            // ------------------------------------------------------------ //

            //Cliente clienteParaDeletar = new Cliente(5);
            //if (Cliente.Deletar(clienteParaDeletar) >= 1)
            //{
            //    Console.WriteLine("Cliente excluido com sucesso.");
            //}
            //else
            //{
            //    Console.WriteLine("Não foi possivel excluir o cliente.");
            //}

            // ------------------------------------------------------------ //


            //List<Cliente> clientes = Cliente.ListarTodos();

            //foreach(Cliente cliente in clientes )
            //{
            //    Console.WriteLine($"ID: {cliente.Id}");
            //    Console.WriteLine($"Nome: {cliente.Nome}");
            //    Console.WriteLine($"CPF: {cliente.Cpf}");
            //    Console.WriteLine($"Telefone: {cliente.Telefone}");
            //    Console.WriteLine($"Endereço: {cliente.Endereco}");
            //    Console.WriteLine($"Pontos: {cliente.Pontos}");

            //    Console.WriteLine("-----------------------------------");


            //}


            // ------------------------------------------------------------ //



            //Cliente? cli01 = Cliente.listarPorId(1);

            //if(cli01 != null)
            //{
            //    Console.WriteLine("-----------------------------------");

            //    Console.WriteLine($"ID: {cli01.Id}");
            //    Console.WriteLine($"Nome: {cli01.Nome}");
            //    Console.WriteLine($"CPF: {cli01.Cpf}");
            //    Console.WriteLine($"Telefone: {cli01.Telefone}");
            //    Console.WriteLine($"Endereço: {cli01.Endereco}");
            //    Console.WriteLine($"Pontos: {cli01.Pontos}");

            //    Console.WriteLine("-----------------------------------");

            //}
            //else
            //{
            //    Console.WriteLine("O cliente não foi encontrado");
            //}


            // ------------------------------------------------------------ //


            //Cliente? meuCliente = Cliente.ListarPorId(1);

            //if(meuCliente != null)
            //{
            //    meuCliente.Endereco = "Rua das ruas";
            //    meuCliente.Telefone = "1199999-9999";

            //    int resultado = Cliente.Atualizar(meuCliente);

            //    if (resultado > 0)
            //    {
            //        Console.WriteLine("Cliente atualizado com sucesso.");
            //    }


            //}


            // ------------------------------------------------------------ //


            //Funcionario funcionario1 = new Funcionario(
            //    nome: "Erick",
            //    cpf: "123.456.789-00",
            //    cargo: "Padeiro"
            //);

            //Funcionario.Inserir(funcionario1);


            ClienteService.MenuCliente();

           


        }
    }
}
