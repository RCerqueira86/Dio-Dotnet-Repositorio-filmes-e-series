using System;

namespace DIO.Series
{
    class Program
    {
        static SerieRepositorio repositorioS = new SerieRepositorio();
		static FilmeRepositorio repositorioF = new FilmeRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuarioFS = ObterOpcaoUsuarioFS();
			
			
			
			while (opcaoUsuarioFS.ToUpper() != "X")
			{
				switch (opcaoUsuarioFS)
				{
					case "1":           //Goto Filmes
						goto Filmes;
						//break;
					case "2":			//Goto Séries
						goto Series;
						//break;
					case "C":
						Console.Clear();
						break;

					default:
						throw new ArgumentOutOfRangeException();
				}

				opcaoUsuarioFS = ObterOpcaoUsuarioFS();
			}

			Console.WriteLine("Obrigado por utilizar nossos serviços.");
			Console.ReadLine();
//////////////////////////////SERIES///////////////////////////////////////
			Series:
			string opcaoUsuarioS = ObterOpcaoUsuarioS();
			while (opcaoUsuarioS.ToUpper() != "X")
			{
				switch (opcaoUsuarioS)
				{
					case "1":
						ListarSeries();
						break;
					case "2":
						InserirSerie();
						break;
					case "3":
						AtualizarSerie();
						break;
					case "4":
						System.Console.WriteLine("Deseja excluir a série? [s/n]");
						char escolha;
						escolha=char.Parse(Console.ReadLine());
						if(escolha=='s'|escolha=='S'){ 
							ExcluirSerie();
						}else{
							goto Series;
						}
						break;
					case "5":
						VisualizarSerie();
						break;
					case "F":
						goto Filmes;
					case "C":
						Console.Clear();
						break;

					default:
						throw new ArgumentOutOfRangeException();
				}

				opcaoUsuarioS = ObterOpcaoUsuarioS();
			}

			Console.WriteLine("Obrigado por utilizar nossos serviços.");
			Console.ReadLine();
			////////////////////FILMES/////////////////////////// 
			Filmes:
			string opcaoUsuarioF = ObterOpcaoUsuarioF();
			while (opcaoUsuarioF.ToUpper() != "X")
			{
				switch (opcaoUsuarioF)
				{
					case "1":
						ListarFilmes();
						break;
					case "2":
						InserirFilme();
						break;
					case "3":
						AtualizarFilme();
						break;
					case "4":
						System.Console.WriteLine("Tem certeza? [s/n]");
						char escolha;
						escolha=char.Parse(Console.ReadLine());
						if(escolha=='s'|escolha=='S'){
							ExcluirFilme();
						}else{
							goto Filmes;
						}						
						break;
					case "5":
						VisualizarFilme();
						break;
					case "S":
						goto Series;
					case "C":
						Console.Clear();
						break;

					default:
						throw new ArgumentOutOfRangeException();
				}

				opcaoUsuarioF = ObterOpcaoUsuarioF();
			}

			Console.WriteLine("Obrigado por utilizar nossos serviços.");
			Console.ReadLine();
			
			
        }
/////////////////////Funções series///////////////////////////////////////
        private static void ExcluirSerie()
		{
			Console.Write("Digite o id da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			repositorioS.Exclui(indiceSerie);
		}

        private static void VisualizarSerie()
		{
			Console.Write("Digite o id da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			var serie = repositorioS.RetornaPorId(indiceSerie);

			Console.WriteLine(serie);
		}

        private static void AtualizarSerie()
		{
			Console.Write("Digite o id da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título da Série: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início da Série: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição da Série: ");
			string entradaDescricao = Console.ReadLine();

			Serie atualizaSerie = new Serie(IdS: indiceSerie,
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorioS.Atualiza(indiceSerie, atualizaSerie);
		}
        private static void ListarSeries()
		{
			Console.WriteLine("Listar séries");

			var lista = repositorioS.Lista();

			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhuma série cadastrada.");
				return;
			}

			foreach (var serie in lista)
			{
                var excluido = serie.retornaExcluido();
                
				Console.WriteLine("#ID {0}: - {1} {2}", serie.retornaIdS(), serie.retornaTitulo(), (excluido ? "*Excluído*" : ""));
			}
		}

        private static void InserirSerie()
		{
			Console.WriteLine("Inserir nova série");

			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título da Série: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início da Série: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição da Série: ");
			string entradaDescricao = Console.ReadLine();

			Serie novaSerie = new Serie(IdS: repositorioS.ProximoId(),
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorioS.Insere(novaSerie);
		}
		/////////////////////Fucoes Filmes///////////////////////////////////////
		
        private static void ExcluirFilme()
		{
			Console.Write("Digite o id do filme: ");
			int indiceFilme = int.Parse(Console.ReadLine());

			repositorioF.ExcluiF(indiceFilme);
		}

        private static void VisualizarFilme()
		{
			Console.Write("Digite o id do filme: ");
			int indiceFilme = int.Parse(Console.ReadLine());

			var filme = repositorioF.RetornaPorIdF(indiceFilme);

			Console.WriteLine(filme);
		}

        private static void AtualizarFilme()
		{
			Console.Write("Digite o id do Filme: ");
			int indiceFilme = int.Parse(Console.ReadLine());

			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título do Filme: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início do Filme: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição do Filme: ");
			string entradaDescricao = Console.ReadLine();

			Filme atualizaFilme = new Filme(IdF: indiceFilme,
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorioF.AtualizaF(indiceFilme, atualizaFilme);
		}
        private static void ListarFilmes()
		{
			Console.WriteLine("Listar Filmes");

			var lista = repositorioF.ListaF();

			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhum filme cadastrada.");
				return;
			}

			foreach (var filme in lista)
			{
                var excluido = filme.retornaExcluido();
                
				Console.WriteLine("#ID {0}: - {1} {2}", filme.retornaIdF(), filme.retornaTitulo(), (excluido ? "*Excluído*" : ""));
			}
		}

        private static void InserirFilme()
		{
			Console.WriteLine("Inserir novo Filme");

			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título do Filme: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano do Filme: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição do Filme: ");
			string entradaDescricao = Console.ReadLine();

			Filme novoFilme = new Filme(IdF: repositorioF.ProximoIdF(),
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorioF.InsereF(novoFilme);
		}
								//Funções de entrada
        private static string ObterOpcaoUsuarioS()
		{
			Console.WriteLine();
			Console.WriteLine("DIO Séries a seu dispor!!!");
			Console.WriteLine("Informe a opção desejada:");

			Console.WriteLine("1- Listar séries");
			Console.WriteLine("2- Inserir nova série");
			Console.WriteLine("3- Atualizar série");
			Console.WriteLine("4- Excluir série");
			Console.WriteLine("5- Visualizar série");
			Console.WriteLine("F- Ir para repositório de Filmes");
			Console.WriteLine("C- Limpar Tela");
			Console.WriteLine("X- Sair");
			Console.WriteLine();

			string opcaoUsuarioS = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuarioS;
		}

		private static string ObterOpcaoUsuarioFS()
		{
			Console.WriteLine();
			Console.WriteLine("DIO Filmes ou Séries a seu dispor!!!");
			Console.WriteLine("Informe a opção desejada:");

			Console.WriteLine("1- Repositório Filmes");
			Console.WriteLine("2- Repositório Séries");
			Console.WriteLine("C- Limpar Tela");
			Console.WriteLine("X- Sair");
			Console.WriteLine();

			string opcaoUsuarioFS = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuarioFS;
		}
		private static string ObterOpcaoUsuarioF()
		{
			Console.WriteLine();
			Console.WriteLine("DIO Filmes a seu dispor!!!");
			Console.WriteLine("Informe a opção desejada:");

			Console.WriteLine("1- Listar filme");
			Console.WriteLine("2- Inserir novo filme");
			Console.WriteLine("3- Atualizar filme");
			Console.WriteLine("4- Excluir filme");
			Console.WriteLine("5- Visualizar filme");
			Console.WriteLine("S- Ir para repositório de Séries");
			Console.WriteLine("C- Limpar Tela");
			Console.WriteLine("X- Sair");
			Console.WriteLine();

			string opcaoUsuarioF = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuarioF;
		}
    }
}
