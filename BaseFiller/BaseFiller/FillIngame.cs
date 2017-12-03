using System;
using System.Collections.Generic;
using Npgsql;

namespace BaseFiller
{
	public class FillIngame
	{
		public FillIngame(NpgsqlConnection con, int records,int maxPlayers,int champions)
		{
			//Генерация массива случайных записей Game
			List<Description> descs = new List<Description>();
			for (int i = 0; i < records; i++)
			{
				var d = new Description();
				d.ID1 = Tools.RandomToRange(maxPlayers - 1) + 1;
				d.ID2 = Tools.RandomToRange(maxPlayers - 1) + 1;
				d.ID3 = Tools.RandomToRange(maxPlayers - 1) + 1;
				d.ID4 = Tools.RandomToRange(maxPlayers - 1) + 1;
				d.ID5 = Tools.RandomToRange(maxPlayers - 1) + 1;
				d.ID6 = Tools.RandomToRange(maxPlayers - 1) + 1;
				d.ID7 = Tools.RandomToRange(maxPlayers - 1) + 1;
				d.ID8 = Tools.RandomToRange(maxPlayers - 1) + 1;
				d.ID9 = Tools.RandomToRange(maxPlayers - 1) + 1;
				d.ID10 = Tools.RandomToRange(maxPlayers - 1) + 1;

				d.Champion1 = Tools.RandomToRange(champions - 1) + 1;
				d.Champion2 = Tools.RandomToRange(champions - 1) + 1;
				d.Champion3 = Tools.RandomToRange(champions - 1) + 1;
				d.Champion4 = Tools.RandomToRange(champions - 1) + 1;
				d.Champion5 = Tools.RandomToRange(champions - 1) + 1;
				d.Champion6 = Tools.RandomToRange(champions - 1) + 1;
				d.Champion7 = Tools.RandomToRange(champions - 1) + 1;
				d.Champion8 = Tools.RandomToRange(champions - 1) + 1;
				d.Champion9 = Tools.RandomToRange(champions - 1) + 1;
				d.Champion10 = Tools.RandomToRange(champions - 1) + 1;

				d.Team1 = Tools.RandomToRange(2) + 1;
				d.Team2 = Tools.RandomToRange(2) + 1;
				d.Team3 = Tools.RandomToRange(2) + 1;
				d.Team4 = Tools.RandomToRange(2) + 1;
				d.Team5 = Tools.RandomToRange(2) + 1;
				d.Team6 = Tools.RandomToRange(2) + 1;
				d.Team7 = Tools.RandomToRange(2) + 1;
				d.Team8 = Tools.RandomToRange(2) + 1;
				d.Team9 = Tools.RandomToRange(2) + 1;
				d.Team10 = Tools.RandomToRange(2) + 1;

				d.Kills1 = Tools.RandomToRange(20) + 1;
				d.Kills2 = Tools.RandomToRange(20) + 1;
				d.Kills3 = Tools.RandomToRange(20) + 1;
				d.Kills4 = Tools.RandomToRange(20) + 1;
				d.Kills5 = Tools.RandomToRange(20) + 1;
				d.Kills6 = Tools.RandomToRange(20) + 1;
				d.Kills7 = Tools.RandomToRange(20) + 1;
				d.Kills8 = Tools.RandomToRange(20) + 1;
				d.Kills9 = Tools.RandomToRange(20) + 1;
				d.Kills10 = Tools.RandomToRange(20) + 1;

				d.Deaths1 = Tools.RandomToRange(20);
				d.Deaths2 = Tools.RandomToRange(20);
				d.Deaths3 = Tools.RandomToRange(20);
				d.Deaths4 = Tools.RandomToRange(20);
				d.Deaths5 = Tools.RandomToRange(20);
				d.Deaths6 = Tools.RandomToRange(20);
				d.Deaths7 = Tools.RandomToRange(20);
				d.Deaths8 = Tools.RandomToRange(20);
				d.Deaths9 = Tools.RandomToRange(20);
				d.Deaths10 = Tools.RandomToRange(20);

				d.Minions1 = Tools.RandomToRange(200);
				d.Minions2 = Tools.RandomToRange(200);
				d.Minions3 = Tools.RandomToRange(200);
				d.Minions4 = Tools.RandomToRange(200);
				d.Minions5 = Tools.RandomToRange(200);
				d.Minions6 = Tools.RandomToRange(200);
				d.Minions7 = Tools.RandomToRange(200);
				d.Minions8 = Tools.RandomToRange(200);
				d.Minions9 = Tools.RandomToRange(200);
				d.Minions10 = Tools.RandomToRange(200);

				d.Gold1 = Tools.RandomToRange(15000);
				d.Gold2 = Tools.RandomToRange(15000);
				d.Gold3 = Tools.RandomToRange(15000);
				d.Gold4 = Tools.RandomToRange(15000);
				d.Gold5 = Tools.RandomToRange(15000);
				d.Gold6 = Tools.RandomToRange(15000);
				d.Gold7 = Tools.RandomToRange(15000);
				d.Gold8 = Tools.RandomToRange(15000);
				d.Gold9 = Tools.RandomToRange(15000);
				d.Gold10 = Tools.RandomToRange(15000);

				d.WinTeam = Tools.RandomToRange(2) + 1;

				descs.Add(d);
			}
			//Создание подключения
			con.Open();

			NpgsqlCommand com = null;
			//Выполнение инсертов в таблицу
			foreach (var desc in descs)
			{
				com = new NpgsqlCommand(request, con);
				com.Parameters.AddWithValue("@p1_id", desc.ID1);
				com.Parameters.AddWithValue("@p2_id", desc.ID2);
				com.Parameters.AddWithValue("@p3_id", desc.ID3);
				com.Parameters.AddWithValue("@p4_id", desc.ID4);
				com.Parameters.AddWithValue("@p5_id", desc.ID5);
				com.Parameters.AddWithValue("@p6_id", desc.ID6);
				com.Parameters.AddWithValue("@p7_id", desc.ID7);
				com.Parameters.AddWithValue("@p8_id", desc.ID8);
				com.Parameters.AddWithValue("@p9_id", desc.ID9);
				com.Parameters.AddWithValue("@p10_id", desc.ID10);

				com.Parameters.AddWithValue("@p1_champ", desc.Champion1);
				com.Parameters.AddWithValue("@p2_champ", desc.Champion2);
				com.Parameters.AddWithValue("@p3_champ", desc.Champion3);
				com.Parameters.AddWithValue("@p4_champ", desc.Champion4);
				com.Parameters.AddWithValue("@p5_champ", desc.Champion5);
				com.Parameters.AddWithValue("@p6_champ", desc.Champion6);
				com.Parameters.AddWithValue("@p7_champ", desc.Champion7);
				com.Parameters.AddWithValue("@p8_champ", desc.Champion8);
				com.Parameters.AddWithValue("@p9_champ", desc.Champion9);
				com.Parameters.AddWithValue("@p10_champ", desc.Champion10);

				com.Parameters.AddWithValue("@p1_team", desc.Team1);
				com.Parameters.AddWithValue("@p2_team", desc.Team2);
				com.Parameters.AddWithValue("@p3_team", desc.Team3);
				com.Parameters.AddWithValue("@p4_team", desc.Team4);
				com.Parameters.AddWithValue("@p5_team", desc.Team5);
				com.Parameters.AddWithValue("@p6_team", desc.Team6);
				com.Parameters.AddWithValue("@p7_team", desc.Team7);
				com.Parameters.AddWithValue("@p8_team", desc.Team8);
				com.Parameters.AddWithValue("@p9_team", desc.Team9);
				com.Parameters.AddWithValue("@p10_team", desc.Team10);

				com.Parameters.AddWithValue("@p1_kills", desc.Kills1);
				com.Parameters.AddWithValue("@p2_kills", desc.Kills2);
				com.Parameters.AddWithValue("@p3_kills", desc.Kills3);
				com.Parameters.AddWithValue("@p4_kills", desc.Kills4);
				com.Parameters.AddWithValue("@p5_kills", desc.Kills5);
				com.Parameters.AddWithValue("@p6_kills", desc.Kills6);
				com.Parameters.AddWithValue("@p7_kills", desc.Kills7);
				com.Parameters.AddWithValue("@p8_kills", desc.Kills8);
				com.Parameters.AddWithValue("@p9_kills", desc.Kills9);
				com.Parameters.AddWithValue("@p10_kills", desc.Kills10);

				com.Parameters.AddWithValue("@p1_deaths", desc.Deaths1);
				com.Parameters.AddWithValue("@p2_deaths", desc.Deaths2);
				com.Parameters.AddWithValue("@p3_deaths", desc.Deaths3);
				com.Parameters.AddWithValue("@p4_deaths", desc.Deaths4);
				com.Parameters.AddWithValue("@p5_deaths", desc.Deaths5);
				com.Parameters.AddWithValue("@p6_deaths", desc.Deaths6);
				com.Parameters.AddWithValue("@p7_deaths", desc.Deaths7);
				com.Parameters.AddWithValue("@p8_deaths", desc.Deaths8);
				com.Parameters.AddWithValue("@p9_deaths", desc.Deaths9);
				com.Parameters.AddWithValue("@p10_deaths", desc.Deaths10);

				com.Parameters.AddWithValue("@p1_minions", desc.Minions1);
				com.Parameters.AddWithValue("@p2_minions", desc.Minions2);
				com.Parameters.AddWithValue("@p3_minions", desc.Minions3);
				com.Parameters.AddWithValue("@p4_minions", desc.Minions4);
				com.Parameters.AddWithValue("@p5_minions", desc.Minions5);
				com.Parameters.AddWithValue("@p6_minions", desc.Minions6);
				com.Parameters.AddWithValue("@p7_minions", desc.Minions7);
				com.Parameters.AddWithValue("@p8_minions", desc.Minions8);
				com.Parameters.AddWithValue("@p9_minions", desc.Minions9);
				com.Parameters.AddWithValue("@p10_minions", desc.Minions10);

				com.Parameters.AddWithValue("@p1_gold", desc.Gold1);
				com.Parameters.AddWithValue("@p2_gold", desc.Gold2);
				com.Parameters.AddWithValue("@p3_gold", desc.Gold3);
				com.Parameters.AddWithValue("@p4_gold", desc.Gold4);
				com.Parameters.AddWithValue("@p5_gold", desc.Gold5);
				com.Parameters.AddWithValue("@p6_gold", desc.Gold6);
				com.Parameters.AddWithValue("@p7_gold", desc.Gold7);
				com.Parameters.AddWithValue("@p8_gold", desc.Gold8);
				com.Parameters.AddWithValue("@p9_gold", desc.Gold9);
				com.Parameters.AddWithValue("@p10_gold", desc.Gold10);

				com.Parameters.AddWithValue("@win_team", desc.WinTeam);

				//Console.WriteLine(game.STime);
				int writen = com.ExecuteNonQuery();
			}
			Console.WriteLine("gamesdescription table filled!");
			con.Close();
		}
		string request = "INSERT INTO gamesdescription (" +
			"p1_id,p1_champ,p1_team,p1_kills,p1_deaths,p1_minions,p1_gold," +
			"p2_id,p2_champ,p2_team,p2_kills,p2_deaths,p2_minions,p2_gold," +
			"p3_id,p3_champ,p3_team,p3_kills,p3_deaths,p3_minions,p3_gold," +
			"p4_id,p4_champ,p4_team,p4_kills,p4_deaths,p4_minions,p4_gold," +
			"p5_id,p5_champ,p5_team,p5_kills,p5_deaths,p5_minions,p5_gold," +
			"p6_id,p6_champ,p6_team,p6_kills,p6_deaths,p6_minions,p6_gold," +
			"p7_id,p7_champ,p7_team,p7_kills,p7_deaths,p7_minions,p7_gold," +
			"p8_id,p8_champ,p8_team,p8_kills,p8_deaths,p8_minions,p8_gold," +
			"p9_id,p9_champ,p9_team,p9_kills,p9_deaths,p9_minions,p9_gold," +
			"p10_id,p10_champ,p10_team,p10_kills,p10_deaths,p10_minions,p10_gold," +
			"win_team) Values (" +
			"@p1_id,@p1_champ,@p1_team,@p1_kills,@p1_deaths,@p1_minions,@p1_gold," +
			"@p2_id,@p2_champ,@p2_team,@p2_kills,@p2_deaths,@p2_minions,@p2_gold," +
			"@p3_id,@p3_champ,@p3_team,@p3_kills,@p3_deaths,@p3_minions,@p3_gold," +
			"@p4_id,@p4_champ,@p4_team,@p4_kills,@p4_deaths,@p4_minions,@p4_gold," +
			"@p5_id,@p5_champ,@p5_team,@p5_kills,@p5_deaths,@p5_minions,@p5_gold," +
			"@p6_id,@p6_champ,@p6_team,@p6_kills,@p6_deaths,@p6_minions,@p6_gold," +
			"@p7_id,@p7_champ,@p7_team,@p7_kills,@p7_deaths,@p7_minions,@p7_gold," +
			"@p8_id,@p8_champ,@p8_team,@p8_kills,@p8_deaths,@p8_minions,@p8_gold," +
			"@p9_id,@p9_champ,@p9_team,@p9_kills,@p9_deaths,@p9_minions,@p9_gold," +
			"@p10_id,@p10_champ,@p10_team,@p10_kills,@p10_deaths,@p10_minions,@p10_gold,@win_team)";
	}
}
