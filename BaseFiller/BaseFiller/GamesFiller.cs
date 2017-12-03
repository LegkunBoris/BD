using System;
using System.Collections.Generic;
using Npgsql;

namespace BaseFiller
{
	public class GamesFiller
	{
		public GamesFiller(NpgsqlConnection con, int records)
		{
			//Генерация массива случайных записей Game
			List<Game> games = new List<Game>();
			for (int i = 0; i < records; i++)
			{
				var game = new Game();
				game.STime = Tools.RandomDate();
				game.ETime = game.STime.AddMinutes(Tools.RandomToRange(60)).AddSeconds(Tools.RandomToRange(60));
				game.Team = Tools.RandomToRange(5) + 1;
				games.Add(game);
			}
			//Сортировка массива
			games.Sort((a, b) => a.STime.CompareTo(b.STime));
			//Создание подключения
			con.Open();
			string request = "INSERT INTO games (s_time,e_time,win_team) Values (@s_time,@e_time,@win_team)";
			NpgsqlCommand com = null;
			//Выполнение инсертов в таблицу
			foreach (var game in games)
			{
				com = new NpgsqlCommand(request, con);
				com.Parameters.AddWithValue("@s_time", game.STime);
				com.Parameters.AddWithValue("@e_time", game.ETime);
				com.Parameters.AddWithValue("@win_team", game.Team);
				Console.WriteLine(game.STime);
				int writen = com.ExecuteNonQuery();
			}
			Console.WriteLine("Games table filled!");
			con.Close();
		}
	}
}
