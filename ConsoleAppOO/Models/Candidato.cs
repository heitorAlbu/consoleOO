using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppOO.Models
{
    public class Candidato : Pessoa
    {
        private string NomePartido { get; }
        private int NumeroPartido { get; }
        private int QtdVotos { get; set; }

        public Candidato(Pessoa pessoa,  string NomePartido, int NumeroPartido)
        {
            this.Id = Guid.NewGuid();
            this.Nome = pessoa.getNome();
            this.Idade = pessoa.getIdade();
            this.Sexo = pessoa.getSexo();
            this.NomePartido = NomePartido;
            this.NumeroPartido = NumeroPartido;
            this.QtdVotos = 0;
        }

        public string getPartido() 
        {
            return this.NomePartido;
        }

        public int getNumeroPartido() 
        {
            return this.NumeroPartido;
        }

        public int getQtdVotos() 
        {
            return this.QtdVotos;
        }

        public void incrementarVoto() 
        {
            this.QtdVotos++;
        }

    }
}
