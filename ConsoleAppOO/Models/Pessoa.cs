using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppOO.Models
{
    public class Pessoa
    {
     
        protected Guid Id { get; set; }
        protected string Nome { get; set; }
        protected int Idade { get; set; }
        protected string Sexo { get; set; }


        public Pessoa(string Nome, int Idade, string Sexo)
        {
            this.Id = Guid.NewGuid();
            this.Nome = Nome;
            this.Idade = Idade;
            this.Sexo = Sexo;
        }

        public Pessoa()
        {

        }

        public void IncrementarIdade()
        {
            this.Idade++;
        }

        public string getNome() 
        {
            return this.Nome;
        
        }
        public int getIdade()
        {
            return this.Idade;

        }
        public string getSexo()
        {
            return this.Sexo;
        }

    }
}
