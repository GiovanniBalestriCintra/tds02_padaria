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

        public Cliente(int id, string nome, string cpf, string telefone, string endereco, int pontos)
        {

            if (nome == "") throw new Exception("O nome do cliente não pode ser vazio.");

            this.id = id;
            this.nome = nome;
            this.cpf = cpf;
            this.telefone = telefone;
            this.endereco = endereco;
            this.pontos = pontos;
        }


        public Cliente(string nome, string cpf, string telefone, string endereco, int pontos)
        {
 
            this.nome = nome;
            this.cpf = cpf;
            this.telefone = telefone;
            this.endereco = endereco;
            this.pontos = pontos;
        }

        public void AdicionarPontos(int pontos)
        {
            this.pontos += pontos;
        }

    }
}
