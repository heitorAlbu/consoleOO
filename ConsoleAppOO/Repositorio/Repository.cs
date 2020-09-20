using ConsoleAppOO.Models;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleAppOO.Repositorio
{
    public class Repository
    {

        private List<Pessoa> ListaPessoas { get; set; }
        private List<Candidato> ListaCandidato { get; set; }

        private int QtdBrancos { get; set; }

        private int QtdNulos { get; set; }
        public Repository()
        {
            this.ListaCandidato = new List<Candidato>();

            this.ListaPessoas = new List<Pessoa>();
            Pessoa p1 = new Pessoa("Arlindo", 23, "Maculino");
            Pessoa p2 = new Pessoa("Sabrina", 33, "Feminino");
            Pessoa p3 = new Pessoa("Lucio", 21, "Maculino");
            Pessoa p4 = new Pessoa("Katia", 36, "Feminino");
            this.ListaPessoas.Add(p1);
            this.ListaPessoas.Add(p2);
            this.ListaPessoas.Add(p3);
            this.ListaPessoas.Add(p4);
            QtdBrancos = 0;
            QtdNulos = 0;

        }


        public List<Pessoa> consultarTodasPessoas()
        {
            return this.ListaPessoas;
        }

        public List<Candidato> consultarTodosCandidatos()
        {
            return this.ListaCandidato;
        }


        public List<Pessoa> adicionarPessoa(Pessoa pessoa)
        {
            this.ListaPessoas.Add(pessoa);
            return this.ListaPessoas;
        }
        public List<Candidato> adicionarCandidato(Candidato candidato)
        {
            this.ListaCandidato.Add(candidato);
            return this.ListaCandidato;
        }

        public Pessoa aumentarIdade(string nome)
        {
            var pessoa = consultarTodasPessoas().Where(p => p.getNome().Equals(nome)).FirstOrDefault();
            pessoa.IncrementarIdade();
            return pessoa;
        }
        public int getQtdBrancos()
        {
            return this.QtdBrancos;
        }
        public int getQtdNulos()
        {
            return this.QtdNulos;
        }
        public void incrementarBrancos()
        {
            this.QtdBrancos++;
        }
        public void incrementarNulos()
        {
            this.QtdNulos++;
        }

    }
}
