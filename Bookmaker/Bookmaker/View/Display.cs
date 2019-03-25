using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using Bookmaker.Data;
using Bookmaker.Data.Models;
using Bookmaker.Services;

namespace Bookmaker.View
{
    public class Display
    {
        private ICoachSevice coachSevice;
        private IPlayerService playerService;
        private ITeamService teamService;
        private IMatchService matchService;

        public Display()
        {
            this.coachSevice = new CoachService();
            this.playerService = new PlayerService();
            this.teamService = new TeamService();
            this.matchService = new MatchService();

            Home();
        }

        private void Home()
        {
            Console.Clear();

            ShowMenu();

            if (!GetUserInput())
            {
                return;
            }

            Console.WriteLine();
            Console.WriteLine("Press enter to continue...");
            string justAnInput = Console.ReadLine();

            Home();
        }

        private bool GetUserInput()
        {
            Console.WriteLine();
            int input = int.Parse(Console.ReadLine());

            Console.Clear();

            switch (input)
            {
                case 0:
                    return false;
                case 1:
                    AddCoach();
                    break;
                case 2:
                    DeleteCoach();
                    break;
                case 3:
                    ListAllCoaches();
                    break;
                case 4:
                    AddPlayer();
                    break;
                case 5:
                    DeletePlayer();
                    break;
                case 6:
                    ListAllPlayers();
                    break;
                case 7:
                    ListAllPlayersOnSale();
                    break;
                case 8:
                    AddTeam();
                    break;
                case 9:
                    DeleteTeam();
                    break;
                case 10:
                    AddPlayerToATeam();
                    break;
                case 11:
                    TeamSellPlayer();
                    break;
                case 12:
                    ListAllTeams();
                    break;
                case 13:
                    ListAllPlayersForATeam();
                    break;
                case 14:
                    AddMatch();
                    break;
                case 15:
                    DeleteMatch();
                    break;
                case 16:
                    PlayMatch();
                    break;
                case 17:
                    GetMatchResult();
                    break;
                case 18:
                    ListAllMatches();
                    break;
                case 19:
                    ListAllMatchesForATeam();
                    break;
                case 20:
                    AddInjuryToAPlayer();
                    break;
                default:
                    Console.WriteLine("Invalid option!");
                    break;
            }

            return true;
        }

        private void AddInjuryToAPlayer()
        {
            Console.WriteLine(Label("ADD INJURY TO A PLAYER"));

            try
            {
                Console.WriteLine("Id of the player:");
                int playerId = int.Parse(Console.ReadLine());
                Console.WriteLine("Injury:");
                string injuryName = Console.ReadLine();

                playerService.AddInjury(playerId, injuryName);

                Console.WriteLine("Injury added successfully!");
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }


        }

        private void ListAllMatchesForATeam()
        {
            Console.WriteLine(Label("LIST ALL MATCHES FOR A TEAM"));

            try
            {
                Console.WriteLine("Id of the team:");
                int id = int.Parse(Console.ReadLine());

                List<Match> matches = matchService.GetAllForATeam(id);

                if (matches.Count == 0)
                {
                    Console.WriteLine("None");
                    return;
                }

                foreach (var match in matches)
                {
                    Console.WriteLine();
                    Console.WriteLine(new string('-', 22) + "MATCH" + new string('-', 23));
                    Console.WriteLine();

                    Console.WriteLine(match);
                }
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void ListAllMatches()
        {
            Console.WriteLine(Label("LIST ALL MATCHES"));

            List<Match> matches = matchService.GetAll();

            if (matches.Count == 0)
            {
                Console.WriteLine("None");
                return;
            }

            foreach (var match in matches)
            {
                Console.WriteLine();
                Console.WriteLine(new string('-', 22) + "MATCH" + new string('-', 23));
                Console.WriteLine();

                Console.WriteLine(match);
            }
        }

        private void GetMatchResult()
        {
            Console.WriteLine(Label("GET MATCH RESULT"));

            try
            {
                Console.WriteLine("Id of the match:");
                int id = int.Parse(Console.ReadLine());

                Console.WriteLine(matchService.GetMatchResult(id));
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void PlayMatch()
        {
            Console.WriteLine(Label("PLAY MATCH"));

            try
            {
                Console.WriteLine("Id of the match:");
                int id = int.Parse(Console.ReadLine());

                matchService.PlayMatch(id);

                Console.WriteLine("Match played!");
                Console.WriteLine("Result:");
                Console.WriteLine(matchService.GetMatchResult(id));
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void DeleteMatch()
        {
            Console.WriteLine(Label("DELETE MATCH"));

            try
            {
                Console.WriteLine("Id of the match:");
                int id = int.Parse(Console.ReadLine());

                matchService.RemoveMatch(id);

                Console.WriteLine("Match deleted successfully!");
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void AddMatch()
        {
            Console.WriteLine(Label("ADD MATCH"));

            try
            {
                Match match = new Match();

                Console.WriteLine("Id of the host team:");
                int hostId = int.Parse(Console.ReadLine());
                match.HostTeam = teamService.GetTeamById(hostId);

                Console.WriteLine("Id of the guest team:");
                int guest = int.Parse(Console.ReadLine());
                match.GuestTeam = teamService.GetTeamById(guest);

                matchService.AddMatch(match);

                Console.WriteLine("Match added successfully!");
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void ListAllPlayersForATeam()
        {
            Console.WriteLine(Label("LIST ALL PLAYERS FOR A TEAM"));

            Console.WriteLine("Id of the team:");
            int id = int.Parse(Console.ReadLine());

            try
            {
                List<Player> players = teamService.GetAllPlayersForATeam(id);

                if (players.Count == 0)
                {
                    Console.WriteLine("None");
                    return;
                }

                foreach (var team in players)
                {
                    Console.WriteLine(team);
                    Console.WriteLine();
                    Console.WriteLine(new string('-', 50));
                    Console.WriteLine();
                }
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void ListAllTeams()
        {
            Console.WriteLine(Label("LIST ALL TEAMS"));

            List<Team> teams = teamService.GetAll();

            if (teams.Count == 0)
            {
                Console.WriteLine("None");
                return;
            }

            foreach (var team in teams)
            {
                Console.WriteLine(team);
                Console.WriteLine();
                Console.WriteLine(new string('-', 50));
                Console.WriteLine();
            }
        }

        private void TeamSellPlayer()
        {
            Console.WriteLine(Label("TEAM SELL PLAYER"));

            try
            {
                Console.WriteLine("Id of the team:");
                int teamId = int.Parse(Console.ReadLine());
                Console.WriteLine("Id of the player:");
                int playerId = int.Parse(Console.ReadLine());

                teamService.SellPlayer(teamId, playerId);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void AddPlayerToATeam()
        {
            Console.WriteLine(Label("ADD PLAYER TO A TEAM"));

            try
            {
                Console.WriteLine("Id of the team:");
                int teamId = int.Parse(Console.ReadLine());
                Console.WriteLine("ID of the player");
                int playerId = int.Parse(Console.ReadLine());

                teamService.AddPlayerToATeam(teamId, playerId);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void DeleteTeam()
        {
            Console.WriteLine(Label("DELETE TEAM"));

            try
            {
                Console.WriteLine("Id:");
                int id = int.Parse(Console.ReadLine());

                teamService.DeleteTeam(id);

                Console.WriteLine("Team deleted successfully");
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void AddTeam()
        {
            Console.WriteLine(Label("ADD TEAM"));

            try
            {
                Team team = new Team();
                Console.WriteLine("Name:");
                team.Name = Console.ReadLine();
                Console.WriteLine("Division:");
                team.Division = int.Parse(Console.ReadLine());
                Console.WriteLine("Budget:");
                team.Budget = decimal.Parse(Console.ReadLine());

                teamService.AddTeam(team);

                Console.WriteLine("Team added successfully");
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void ListAllPlayersOnSale()
        {
            Console.WriteLine(Label("LIST ALL PLAYERS ON SALE"));

            List<Player> playersOnSale = playerService.GetAllOnSale();

            if (playersOnSale.Count == 0)
            {
                Console.WriteLine("None");
                return;
            }
            foreach (var player in playersOnSale)
            {
                Console.WriteLine(player);

                Console.WriteLine();
                Console.WriteLine(new string('-', 50));
                Console.WriteLine();
            }
        }

        private void ListAllPlayers()
        {
            Console.WriteLine(Label("LIST ALL PLAYERS"));

            List<Player> players = playerService.GetAll();

            if (players.Count == 0)
            {
                Console.WriteLine("None");
                return;
            }

            foreach (var player in players)
            {
                Console.WriteLine(player);

                Console.WriteLine();
                Console.WriteLine(new string('-', 50));
                Console.WriteLine();
            }
        }

        private void DeletePlayer()
        {
            Console.WriteLine(Label("DELETE PLAYER"));

            try
            {
                Console.WriteLine("Player Id:");
                int id = int.Parse(Console.ReadLine());

                playerService.DeletePlayer(id);

                Console.WriteLine($"Player with Id {id} deleted successfully!");
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void AddPlayer()
        {
            Console.WriteLine(Label("ADD PLAYER"));

            try
            {
                Player player = new Player();
                Console.WriteLine("Name:");
                player.Name = Console.ReadLine();
                Console.WriteLine("Age:");
                player.Age = int.Parse(Console.ReadLine());


                playerService.AddPlayer(player);

                Console.WriteLine("Player added successfully!");
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void ListAllCoaches()
        {
            Console.WriteLine(Label("LIST ALL COACHES"));

            List<Coach> coaches = coachSevice.GetAll();

            if (coaches.Count == 0)
            {
                Console.WriteLine("None");
                return;
            }

            foreach (var coach in coaches)
            {
                Console.WriteLine(coach);

                Console.WriteLine();
                Console.WriteLine(new string('-', 50));
                Console.WriteLine();
            }
        }

        private void DeleteCoach()
        {
            Console.WriteLine(Label("DELETE COACH"));

            try
            {
                Console.WriteLine("Coach Id:");
                int id = int.Parse(Console.ReadLine());

                coachSevice.DeleteCoach(id);

                Console.WriteLine($"Coach with Id {id} deleted successfully!");
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void AddCoach()
        {
            Console.WriteLine(Label("ADD COACH"));

            try
            {
                Coach coach = new Coach();
                Console.WriteLine("Name:");
                coach.Name = Console.ReadLine();
                Console.WriteLine("Age:");
                coach.Age = int.Parse(Console.ReadLine());

                coachSevice.AddCoach(coach);

                Console.WriteLine("Coach added successfully!");
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void ShowMenu()
        {
            Console.WriteLine(Label("MENU"));
            
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("0. Exit");
            sb.AppendLine("1. Add coach");
            sb.AppendLine("2. Delete coach");
            sb.AppendLine("3. List all coaches");
            sb.AppendLine("4. Add player");
            sb.AppendLine("5. Delete player");
            sb.AppendLine("6. List all players");
            sb.AppendLine("7. List all players on sale");
            sb.AppendLine("8. Add team");
            sb.AppendLine("9. Delete team");
            sb.AppendLine("10. Add player to a team");
            sb.AppendLine("11. Team sell player");
            sb.AppendLine("12. List all teams");
            sb.AppendLine("13. List all players for a team");
            sb.AppendLine("14. Add match");
            sb.AppendLine("15. Delete match");
            sb.AppendLine("16. Play Match");
            sb.AppendLine("17. Get match result");
            sb.AppendLine("18. List all matches");
            sb.AppendLine("19. List all matches for a team");
            sb.AppendLine("20. Add injury to a player");

            Console.WriteLine(sb.ToString().Trim());
        }

        private string Label(string text)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(new string('#', Constants.LabelSize));

            int before = (Constants.LabelSize - text.Length) / 2;
            int after = Constants.LabelSize - before;
            sb.AppendLine(new string(' ', before) + text + new string(' ', after));

            sb.AppendLine(new string('#', Constants.LabelSize));

            return sb.ToString();
        }
    }
}