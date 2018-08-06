using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleApp5
{
	partial class Program
	{

		private static readonly int[] numeros = new int[] { 1, 3, 4, 6, 7, 8, 11, 15 };

		private static readonly string[] prenoms = new string[] {
			"Thierry", "Alexina", "Alexandre", "Frédéric",
			"Youcef", "Stéphane", "Laura", "Chi Trung", "Julien",
			"Cristtiano", "Hatem", "Laynet", "Anne", "Thi Tuong" };

		private static readonly List<Ville> villes = new List<Ville> {
			new Ville { Nom = "Paris", CodePostal = "75013" },
			new Ville { Nom = "Bordeaux", CodePostal = "33000" },
			new Ville { Nom = "Sarlat-La-Canéda", CodePostal = "24200" },
			new Ville { Nom = "Marseille", CodePostal = "13000" },
		};

		private static readonly List<Departement> departements = new List<Departement> {
			new Departement { Nom = "Paris", Numero = "75" },
			new Departement { Nom = "Dordogne", Numero = "24" },
			new Departement { Nom = "Charente", Numero = "16" },
			new Departement { Nom = "Gironde", Numero = "33" },
};

		static void Main(string[] args)
		{


			Req();
			ReqA();
			ReqB();
			ReqC();

		}

		static void Req()
		{
			Console.WriteLine("list");
			//synth request
			var requete = from prenom in prenoms
						   select prenom;

			foreach (var resultat in requete)
				Console.WriteLine(resultat);
			Console.WriteLine(new string('-', 35));
			//synt methode
			var requete2 = prenoms.Select(prenom => prenom);
			foreach (var resultat in requete2)
				Console.WriteLine(resultat);
			Console.WriteLine(new string('-', 35));
		}
		static void ReqA()
		{
			Console.WriteLine("debute par A");
			var requete = from prenom in prenoms
					  where prenom.StartsWith("A")
					  select prenom;
			foreach (var resultat in requete)
				Console.WriteLine(resultat);
			Console.WriteLine(new string ('-', 35));

			var requete2 = prenoms.Where(prenom => prenom.StartsWith("A"))
							.Select(prenom => prenom);
			foreach (var resultat in requete2)
				Console.WriteLine(resultat);
			Console.WriteLine(new string ('-', 35));
		}
		static void ReqB()
		{
			Console.WriteLine("par ordre decroissant");
			var requete = from prenom in prenoms
						  orderby prenom descending
						  select prenom;
			foreach (var resultat in requete)
				Console.WriteLine(resultat);
			Console.WriteLine(new string('-', 35));

			var requete2 = prenoms.OrderByDescending(prenom => prenom).Select(prenom => prenom);
			foreach (var resultat in requete2)
				Console.WriteLine(resultat);
			Console.WriteLine(new string('-', 35));
		}
		static void ReqC()
		{

			Console.WriteLine("par group");
			var requete = from prenom in prenoms
						  group prenom by prenom[0] into groupe
						  select new
						  {
							  Lettre = groupe.Key,
							  Prenoms = groupe.ToList()
						  };
			foreach (var resultat in requete)
			{
				Console.WriteLine(resultat.Lettre);
				foreach (var prenom in resultat.Prenoms)
				{
					Console.WriteLine($"\t{prenom}");
				}
			}

			Console.WriteLine("par group");
			var requeteB = from prenom in prenoms
						  orderby prenom ascending
						  group prenom by prenom[0] into groupe
						  let lettre = groupe.Key
						  orderby lettre
						  select new
						  {
							  Lettre = lettre,
							  Prenoms = groupe.ToList()
						  };

			foreach (var resultat in requete)
			{
				Console.WriteLine(resultat.Lettre);
				foreach (var prenom in resultat.Prenoms)
				{
					Console.WriteLine($"\t{prenom}");
				}
			}

			Console.WriteLine(new string('-', 35));

			var requete2 = prenoms.OrderBy(prenom => prenom)
									.GroupBy(prenom => prenom[0])
									.OrderBy(groupe => groupe.Key)
									.Select(groupe => new
									{
										Lettre = groupe.Key,
										Prenoms = groupe.ToList()

									});
			foreach (var resultat in requete2)
			{
				Console.WriteLine(resultat.Lettre);
				foreach (var prenom in resultat.Prenoms)
				{
					Console.WriteLine($"\t{prenom}");
				}
			}
			
			Console.WriteLine(new string('-', 35));
		}
	}
}
