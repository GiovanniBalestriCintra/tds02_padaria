using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backPadaria.Model
{
    internal class Cliente
    {

        private int id;
        private string nome;
        private string cpf;
        private string telefone;
        private string endereco;
        private int pontos;

        public int Id { get => id; set => id = value; }
        public string Nome { get => nome; set => nome = value; }
        public string Cpf { get => cpf; set => cpf = value; }
        public string Telefone { get => telefone; set => telefone = value; }
        public string Endereco { get => endereco; set => endereco = value; }
        public int Pontos { get => pontos; set => pontos = value; }

        public Cliente(int id, string nome, string cpf, string telefone, string endereco, int pontos)
        {

            if (nome == "") throw new Exception("O nome do cliente não pode ser vazio.");

            this.Id = id;
            this.Nome = nome;
            this.Cpf = cpf;
            this.Telefone = telefone;
            this.Endereco = endereco;
            this.Pontos = pontos;
        }


        public Cliente(string nome, string cpf, string telefone, string endereco, int pontos)
        {
 
            this.Nome = nome;
            this.Cpf = cpf;
            this.Telefone = telefone;
            this.Endereco = endereco;
            this.Pontos = pontos;
        }

        public void AdicionarPontos(int pontos)
        {
            this.Pontos += pontos;
        }


        public static int inserir(Cliente cliente)
        {
            // Instrução SQL: Define o comando de inserção (INSERT).
            // 0 uso de marcações com '0' (ex: ONone) é una pratica de segurança crucial chanada de "Paranetrização".
            // Ela impede ataques de SQL Injection, pois o banco entende o que e comando e o que e apenas texto do usuário.

            string sql = "INSERT INTO `Cliente` (`nome`, `CPF`, `Telefone`, `Endereco`, `Pontos`) VALUES (@Nome, @CPF, @Telefone, @Endereco, @Pontos)";
           
            // Gerenciamento de recursos: Cria o objeto de comando ja passando a instrução SQL.
            // 0 'using' garante que os recursos de nemoria ocupados pelo comando sejam Liberados ao final do bloco.
            using (var cmd = new MySqlCommand(sql))
            {
                // Vinculação de Dados: Pega as propriedades do objeto C# (cliente.Nome, cliente.cpf, etc.)
                // e substitui de forna segura as narcacões '0' da string SQL com os valores reais,

                cmd.Parameters.AddWithValue("@Nome", cliente.Nome);
                cmd.Parameters.AddWithValue("@CPF", cliente.Cpf);
                cmd.Parameters.AddWithValue("@Telefone", cliente.Telefone);
                cmd.Parameters.AddWithValue("@Endereco", cliente.Endereco);
                cmd.Parameters.AddWithValue("@Pontos", cliente.Pontos);

                // Execucão: Como o comando de INSERT nao retorna tabelas (apenas executa una ação),
                // ele envia o comando configurado para o metodo generico 'executarComando' da classe 'Banco'.
                // O metodo retorna 1 (se o usuario for inserido con sucesso) ou -1 (se houver erro no banco).

                return Banco.executarComando(cmd);
            }
        }

    }
}
