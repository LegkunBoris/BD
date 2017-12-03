using System;
using System.Collections.Generic;
using Npgsql;

namespace BaseFiller
{
	public class PlayersFiller
	{
		public PlayersFiller(NpgsqlConnection con,int records)
		{
			//Генерация массива случайных записей Game
			List<Player> players = new List<Player>();
			for (int i = 0; i < records; i++)
			{
				var player = new Player();
				player.Name = Tools.GenerateName(Tools.RandomToRange(10));
				player.Rank = Tools.RandomToRange(5) + 1;
				player.Status = Tools.RandomToRange(4) + 1;
				player.Server = Tools.RandomToRange(4) + 1;
				players.Add(player);
			}
			//Создание подключения
			con.Open();
			string request = "INSERT INTO players (name,server,status,rank) Values (@name,@server,@status,@rank)";
			NpgsqlCommand com = null;
			//Выполнение инсертов в таблицу
			foreach (var player in players)
			{
				com = new NpgsqlCommand(request, con);
				com.Parameters.AddWithValue("@name", player.Name);
				com.Parameters.AddWithValue("@server", player.Server);
				com.Parameters.AddWithValue("@status", player.Status);
				com.Parameters.AddWithValue("@rank", player.Rank);
				//Console.WriteLine(game.STime);
				int writen = com.ExecuteNonQuery();
			}
			Console.WriteLine("Players table filled!");
			con.Close();
		}
	}
}
