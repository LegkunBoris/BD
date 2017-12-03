using System;
using System.Collections.Generic;
using Npgsql;

namespace BaseFiller
{
	class Tools
	{
		private static Random gen = new Random();
		public static DateTime RandomDate()
		{
			DateTime start = new DateTime(2005, 1, 1);
			int range = (DateTime.Today - start).Days;
			return start.AddDays(gen.Next(range)).AddHours(RandomToRange(24)).AddMinutes(RandomToRange(60)).AddSeconds(RandomToRange(60));
		}
		public static int RandomToRange(int range)
		{
			return gen.Next(range);
		}
		public static string GenerateName(int len)
		{
			string[] consonants = { "b", "c", "d", "f", "g", "h", "j", "k", "l", "m", "l", "n", "p", "q", "r", "s", "sh", "zh", "t", "v", "w", "x" };
			string[] vowels = { "a", "e", "i", "o", "u", "ae", "y" };
			string Name = "";
			Name += consonants[gen.Next(consonants.Length)].ToUpper();
			Name += vowels[gen.Next(vowels.Length)];
			int b = 2; //b tells how many times a new letter has been added. It's 2 right now because the first two letters are already in the name.
			while (b < len)
			{
				Name += consonants[gen.Next(consonants.Length)];
				b++;
				Name += vowels[gen.Next(vowels.Length)];
				b++;
			}

			return Name;
		}
		public static void Main(string[] args)
		{
			// PostgeSQL-style connection string
			string server = "127.0.0.1";
			int port = 5432;
			string userid = "postgres";
			string password = "tremors321";
			string database = "gamedb";
			string connstring = String.Format($"Server={server};Port={port};" +
			                                  $"User Id={userid};Password={password};Database={database};");
			// Making connection with Npgsql provider
			using (NpgsqlConnection con = new NpgsqlConnection(connstring))
			{
				int GamesCount = 1000;
				int PlayersCount = 1000;
				PlayersFiller pfiller = new PlayersFiller(con, PlayersCount);
				GamesFiller filler = new GamesFiller(con,GamesCount);
				FillIngame ifiller = new FillIngame(con, GamesCount,PlayersCount,20);
			}
		}
	}
}
