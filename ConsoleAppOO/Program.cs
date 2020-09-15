using ConsoleAppOO.Models;
using ConsoleAppOO.Repositorio;
using System;
using System.Linq;

namespace ConsoleAppOO
{
    class Program
    {
        static void Main(string[] args)
        {
            var repositorio = new Repository();
            var escolha = 1;
            do
            {
                Console.Clear();
                Console.WriteLine("=======================");
                Console.WriteLine("Digite a opção que você deseja : ");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("1 - Cadastrar Pessoa");
                Console.WriteLine("2 - Listar Pessoas");
                Console.WriteLine("3 - Cadastrar Candidato");
                Console.WriteLine("4 - Listar Candidatos");
                Console.WriteLine("5 - VOTAR");
                Console.WriteLine("6 - Apurar Eleição");
                Console.WriteLine("7 - Sair");
                escolha = Convert.ToInt32(Console.ReadLine());
                switch (escolha)
                {
                    case 1:
                        try
                        {
                            Console.WriteLine("digite o nome :");
                            var nome = Console.ReadLine();
                            Console.WriteLine("digite  a idade :");
                            var idade = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("digite o sexo :");
                            var sexo = Console.ReadLine();

                            Pessoa pessoa = new Pessoa(nome, idade, sexo);

                            repositorio.adicionarPessoa(pessoa);

                            Console.WriteLine("Adicionado com sucesso!");

                            break;
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("ocorreu algum problema, por favor reinicie o procedimento");
                            Console.ReadKey();
                            break;
                        }

                    case 2:
                        foreach (var item in repositorio.consultarTodasPessoas())
                        {
                            Console.WriteLine(item.getNome() + ", " + item.getIdade() + " Anos", ", sexo : " + item.getSexo());
                        }
                        Console.ReadKey();
                        break;


                    case 3:
                        try
                        {
                            Console.WriteLine("digite o número da pessoa que você deseja candidatar :  ");
                            var listapessoas = repositorio.consultarTodasPessoas();
                            var cont = 0;

                            foreach (var item in repositorio.consultarTodasPessoas())
                            {
                                Console.WriteLine("( " + cont + " )" + listapessoas[cont].getNome());
                                cont++;
                            }

                            var choice = Convert.ToInt32(Console.ReadLine());
                            Pessoa pessoaEscolhida = listapessoas[choice];

                            Console.Clear();
                            Console.WriteLine("Ok, você escolheu o (a) " + pessoaEscolhida.getNome() + " para ser candidato");
                            Console.ReadKey();
                            Console.WriteLine("Digite o nome do partido");

                            var partidoEscolhido = Console.ReadLine();
                            Console.Clear();
                            Console.WriteLine("Ok, Agora digite o número do candidato : ");
                            var numeroDoPartido = Convert.ToInt32(Console.ReadLine());

                            foreach (var item in repositorio.consultarTodosCandidatos())
                            {
                                if (numeroDoPartido == item.getNumeroPartido())
                                {
                                    //Console.WriteLine("este número já existe, escolha outro");
                                    Console.ReadKey();
                                    throw new Exception("este número já existe, escolha outro");

                                }
                            }

                            Candidato novoCandidato = new Candidato(pessoaEscolhida, partidoEscolhido, numeroDoPartido);

                            repositorio.adicionarCandidato(novoCandidato);
                            Console.Clear();

                            Console.WriteLine("Candidato adicionado!");
                            break;
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            Console.ReadKey();
                            break;
                        }

                    case 4:
                        foreach (var item in repositorio.consultarTodosCandidatos())
                        {
                            Console.WriteLine(item.getNome() + ", " + item.getIdade() + " Anos, Partido : " + item.getPartido() + " Total de votos : " + item.getQtdVotos());
                        }
                        Console.ReadKey();
                        break;

                    case 5:
                        try
                        {
                            Console.Clear();
                            Console.WriteLine("Escolha um candidato pelo seu número");
                            var listaCandidato = repositorio.consultarTodosCandidatos();
                            foreach (var item in listaCandidato)
                            {
                                Console.WriteLine(item.getNome() + ", ( " + item.getNumeroPartido() + " )");
                            }

                            var escolhaVoto = Convert.ToInt32(Console.ReadLine());
                            if (!listaCandidato.Select(p => p.getNumeroPartido()).Contains(escolhaVoto))
                            {
                                throw new Exception();
                            }


                            listaCandidato.Where(p => p.getNumeroPartido() == escolhaVoto).FirstOrDefault().incrementarVoto();
                            //candidato.incrementarVoto();
                            Console.WriteLine("voto computado com sucesso!!");
                            Console.ReadKey();

                            break;

                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Não foi possível realizar o voto");
                            Console.ReadKey();
                            break;
                        }

                    case 6:
                        string resultado = "";
                        int posicao = 1;
                        foreach (var item in repositorio.consultarTodosCandidatos().OrderByDescending(p => p.getQtdVotos()))
                        {
                            resultado = posicao + "º)" + "O Candidato (a) " + item.getNome() + " está com o total de  " + item.getQtdVotos() + " votos";
                            Console.WriteLine(resultado);
                            posicao++;
                        }
                        Console.ReadKey();
                        break;

                    default:

                        Console.WriteLine("opção inválida");
                        Console.ReadKey();
                        break;
                }
            } while (escolha >= 1 && escolha < 7);




        }
    }
}
