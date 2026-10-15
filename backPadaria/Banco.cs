using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace backPadaria
{
    public static class Banco
    {

        private static string stringConexao = "Server=10.91.45.43;Port3306;Database=padaria_bd;Uid=admin;Pwd=12345678";


        public static void connectAndTest()
        {
            using (var connection = new MySqlConnection(stringConexao))
            {

                // Tenta fazer
                try 
                {

                    Console.WriteLine("Tentando conectar ao banco de dados");
                    
                    connection.Open();

                    Console.WriteLine("Conexão bem sucedida");

                    using (var command = new MySqlCommand("SELECT VERSION();", connection))
                    {
                        string version = command.ExecuteScalar()?.ToString();
                        Console.WriteLine($"Versão do MariaDB {version}");
                    }

                // Captura o erro
                }catch (MySqlException ex)
                {
                    Console.WriteLine("Erro ao conectar no banco de dados");
                    Console.WriteLine(ex.Message);
                }

            }
        }

    }
}
