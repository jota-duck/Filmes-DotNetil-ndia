using System;

namespace Filmes
{
    class Program
    {
        static FilmesRepositorio repositorio = new FilmesRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
			{
				switch (opcaoUsuario)
				{
					case "1":
						ListarFilmesBase();
						break;
					case "2":
						InserirFilmesBase();
						break;
					case "3":
						AtualizarFilmesBase();
						break;
					case "4":
						ExcluirFilmesBase();
						break;
					case "5":
						VisualizarFilmesBase();
						break;
					case "C":
						Console.Clear();
						break;

					default:
						throw new ArgumentOutOfRangeException();
				}

				opcaoUsuario = ObterOpcaoUsuario();
			}

			Console.WriteLine("Obrigado por utilizar nossos serviços.");
			Console.ReadLine();
        }

        private static void ExcluirFilmesBase()
		{
			Console.Write("Digite o id do Filme: ");
			int indiceFilmesBase = int.Parse(Console.ReadLine());

			repositorio.Exclui(indiceFilmesBase);
		}

        private static void VisualizarFilmesBase()
		{
			Console.Write("Digite o id do Filme: ");
			int indiceFilmesBase = int.Parse(Console.ReadLine());

			var filmesBase = repositorio.RetornaPorId(indiceFilmesBase);

			Console.WriteLine(filmesBase);
		}

        private static void AtualizarFilmesBase()
		{
			Console.Write("Digite o id do Filme: ");
			int indiceFilmesBase = int.Parse(Console.ReadLine());

			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título do Filme: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano do lançamento do Filme: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição do Filme: ");
			string entradaDescricao = Console.ReadLine();

            Console.Write("Digite a Continuação do Filme (caso exista): ");
			string entradaContinuacao = Console.ReadLine();

			FilmesBase atualizaFilmesBase = new FilmesBase(id: indiceFilmesBase,
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao,
                                        continuacao: entradaContinuacao);

			repositorio.Atualiza(indiceFilmesBase, atualizaFilmesBase);
		}
        private static void ListarFilmesBase()
		{
			Console.WriteLine("Listar filme");

			var lista = repositorio.Lista();

			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhum filme cadastrado.");
				return;
			}

			foreach (var serie in lista)
			{
                var excluido = serie.retornaExcluido();
                
				Console.WriteLine("#ID {0}: - {1} {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "*Excluído*" : ""));
			}
		}

        private static void InserirFilmesBase()
		{
			Console.WriteLine("Inserir novo filme");

			
			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título do Filme: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano do lançamento do Filme: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição do Filme: ");
			string entradaDescricao = Console.ReadLine();

            Console.Write("Digite a Continuação do Filme (caso exista): ");
			string entradaContinuacao = Console.ReadLine();

			FilmesBase novaFilmeBase = new FilmesBase(id: repositorio.ProximoId(),
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao,
                                        continuacao: entradaContinuacao);

			repositorio.Insere(novaFilmeBase);
		}

        private static string ObterOpcaoUsuario()
		{
			Console.WriteLine();
			Console.WriteLine("Bem vindo(a) a Filmes DotNetilândia!!!");
			Console.WriteLine("Informe a opção desejada:");

			Console.WriteLine("1- Listar filmes");
			Console.WriteLine("2- Inserir novo filme");
			Console.WriteLine("3- Atualizar filme");
			Console.WriteLine("4- Excluir filme");
			Console.WriteLine("5- Visualizar filme");
			Console.WriteLine("C- Limpar Tela");
			Console.WriteLine("X- Sair");
			Console.WriteLine();

			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
		}
    }
}


