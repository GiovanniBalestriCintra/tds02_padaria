using backPadaria.Model;

namespace backPadaria
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Banco.connectAndTest();

            try
            {
                Cliente cliente1 = new Cliente(
                nome: "",
                cpf: "1234",
                telefone: "1111",
                endereco: "Rua rua",
                pontos: 123);
            }
            catch (Exception err) 
            {
                Console.WriteLine(err.Message);          
            }
            
            

        }
    }
}
