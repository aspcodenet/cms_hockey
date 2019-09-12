using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HockeyCms
{
    class Program
    {
        static void CreatePlayer(List<Team> allaLag)
        {
            Team teamToAddTo = null;
            while(true)
            {
                Console.WriteLine("Vilket lag ska spelaren läggas till i");
                for(int i = 0; i < allaLag.Count();i++)
                {
                    Console.WriteLine($"{i+1} {allaLag[i].Name}");
                }
                int selection =Convert.ToInt32( Console.ReadLine());
                if (selection < 1 || selection > allaLag.Count())
                    continue;
                teamToAddTo = allaLag[selection - 1];
                break;
            }

            Console.WriteLine("Enter data:");
            string namn = "";
            var pos = Player.Position.None;
            int number = 0;

            do
            {
                if(namn == "")
                {
                    Console.Write("Enter name:");
                    namn = Console.ReadLine();
                }
                if (pos == Player.Position.None)
                {
                    Console.Write("Enter position (g,d,f):");
                    string input = Console.ReadLine();
                    if (input == "g") pos = Player.Position.Goalie;
                    if (input == "d") pos = Player.Position.Defence;
                    if (input == "f") pos = Player.Position.Forward;
                }
                if (number == 0)
                {
                    Console.Write("Enter jersey number:");
                    number = Convert.ToInt32(Console.ReadLine());
                }

            } while (namn == "" || pos == Player.Position.None || number == 0);
            teamToAddTo.Players.Add(new Player(namn, pos, number));
        }
        static Player FindPlayerByName(List<Player> players, string namn)
        {
            foreach (var player in players)
                if (namn.Equals(player.Name, StringComparison.OrdinalIgnoreCase))
                    return player;
            return null;
        }
        static void Main(string[] args)
        {
            var allaLag = new List<Team>();
            allaLag.Add(new Team("Sweden"));
            allaLag[0].Players.Add(
                new Player("Peter Forsberg",Player.Position.Forward, 21));
            allaLag[0].Players.Add(
                new Player("Mats Sundin", Player.Position.Forward, 13));
            allaLag[0].Players.Add(
                new Player("Erik Karlsson", Player.Position.Defence, 65));

            var swedensPlayers = allaLag[0].Players;
            Console.WriteLine("Skriv in namn på spelare som ska få score uppdaterad");
            var pname = Console.ReadLine();
            var pla = FindPlayerByName(swedensPlayers, pname);
            if(pla == null)
            {
                Console.WriteLine("hittar ingen spelare med det namnet");
            }
            else
                pla.Scores = pla.Scores + 2;



            allaLag.Add(new Team("Finland"));
            allaLag.Add(new Team("Kanada"));
            while(true)
            {
                CreatePlayer(allaLag);
                foreach(var team in allaLag)
                {
                    Console.WriteLine($"***** {team.Name} *****");
                    foreach(var player in team.Players)
                    {
                        Console.WriteLine($"#{player.JerseyNumber} {player.Name}");
                    }
                }
            }


            //var foppa = new Player("Peter Forsberg",
            //    Player.Position.Forward, 21);
            //treKronor.Players.Add(foppa);


            //treKronor.Players.Add(new Player("Mats Sundin",
            //    Player.Position.Forward, 13));

            //Console.WriteLine($"Spelare i {treKronor.Name}");
            //foreach(var player in treKronor.Players)
            //{
            //    Console.WriteLine($"#{player.JerseyNumber} {player.Name}");
            //}
        }
    }
}
