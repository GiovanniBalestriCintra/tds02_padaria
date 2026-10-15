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

        private static string stringConexao = "Server=10.91.45.43;Port=3306;Database=padaria_bd;Uid=admin;Pwd=12345678";


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
                        string? version = command.ExecuteScalar()?.ToString();
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


        /* Declaração do método: público e estatico, retorna um número inteiro (linhas afetadas)
         e recebe um objeto MysqlCommand com a intrução SQL já confirmada como parâmetro. */
        public static int executarComando(MySqlCommand command)
        {
           /* O bloco 'using' garante que a conexao sera automaticanente fechada e Liberada
           da memória ao final do bloco, mesmo que ocorram erros no meio do processo. 
           
           Cria a conexão utilizando a variável de ambiente
           */

            using (var conexao = new MySqlConnection(stringConexao))
            {
                // Vincular: Diz ao comando SQL em qual conexão ele deve ser executada.
                command.Connection = conexao;

                // tratamento de erros: Inicia um bloco de tentativa para proteger o programa de falhas abruptas.
                try
                {
                    // Abertura da conexão: Estabelece efetivamente a comunicação com o servidor MSQL.
                    conexao.Open();


                    // Execução: 0 ExecuteNonQuery dispara comandos de ação (INSERT, UPDATE, DELETE).
                    // Ele nao retorna registros, mas sim o numero inteiro de linhas que foram alteradas,
                    // e o 'return' devolve esse nunero para quem chanou o metodo.
                    return command.ExecuteNonQuery();
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine($"Erro de Banco de Dados {ex.Message}");

                    return -1;
                }
            }
        }

    }
}
