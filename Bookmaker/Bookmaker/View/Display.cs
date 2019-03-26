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

            SetUpConsole();

            Home();
        }

        private void SetUpConsole()
        {
            //TODO: Console.BackgroundColor = ConsoleColor.DarkGreen;
            //TODO: Console.ForegroundColor = ConsoleColor.Green;
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
                    GetCoachById();
                    break;
                case 5:
                    AddPlayer();
                    break;
                case 6:
                    DeletePlayer();
                    break;
                case 7:
                    ListAllPlayers();
                    break;
                case 8:
                    ListAllPlayersOnSale();
                    break;
                case 9:
                    GetPlayerById();
                    break;
                case 10:
                    AddInjuryToAPlayer();
                    break;
                case 11:
                    AddTeam();
                    break;
                case 12:
                    DeleteTeam();
                    break;
                case 13:
                    AddPlayerToATeam();
                    break;
                case 14:
                    TeamSellPlayer();
                    break;
                case 15:
                    ListAllTeams();
                    break;
                case 16:
                    ListAllTeamsByDivision();
                    break;
                case 17:
                    ListAllPlayersForATeam();
                    break;
                case 18:
                    GetTeamById();
                    break;
                case 19:
                    AddMatch();
                    break;
                case 20:
                    DeleteMatch();
                    break;
                case 21:
                    PlayMatch();
                    break;
                case 22:
                    GetMatchResult();
                    break;
                case 23:
                    ListAllMatches();
                    break;
                case 24:
                    ListAllMatchesForATeam();
                    break;
                case 25:
                    GetMatchById();
                    break;
                default:
                    Console.WriteLine("Invalid option!");
                    break;
            }

            return true;
        }

        private void GetMatchById()
        {
            Console.WriteLine(Label("GET MATCH BY ID"));

            try
            {
                Console.WriteLine("Id of the match:");
                int id = int.Parse(Console.ReadLine());
                Console.WriteLine();

                Match match = matchService.GetMatchById(id);

                Console.WriteLine(match);
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Match not found.");
            }
            //catch (Exception)
            //{
            //    Console.WriteLine(SomethingWentWrong());
            //}
        }

        private void GetTeamById()
        {
            Console.WriteLine(Label("GET TEAM BY ID"));

            try
            {
                Console.WriteLine("Id of the team:");
                int id = int.Parse(Console.ReadLine());
                Console.WriteLine();

                Team team = teamService.GetTeamById(id);

                Console.WriteLine(team);
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Team not found.");
            }
            //catch (Exception)
            //{
            //    Console.WriteLine(SomethingWentWrong());
            //}
        }

        private void GetPlayerById()
        {
            Console.WriteLine(Label("GET PLAYER BY ID"));

            try
            {
                Console.WriteLine("Id of the player:");
                int id = int.Parse(Console.ReadLine());
                Console.WriteLine();

                Player player = playerService.GetPlayerById(id);

                Console.WriteLine(player);
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Player not found");
            }
            //catch (Exception)
            //{
            //    Console.WriteLine(SomethingWentWrong());
            //}
        }

        private void GetCoachById()
        {
            Console.WriteLine(Label("GET COACH BY ID"));

            try
            {
                Console.WriteLine("Id of the coach:");
                int id = int.Parse(Console.ReadLine());
                Console.WriteLine();

                Coach coach = coachSevice.GetCoachById(id);

                Console.WriteLine(coach);
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Coach not found.");
            }
            //catch (Exception)
            //{
            //    Console.WriteLine(SomethingWentWrong());
            //}
        }

        private void AddInjuryToAPlayer()
        {
            Console.WriteLine(Label("ADD INJURY TO A PLAYER"));

            try
            {
                Console.WriteLine("Id of the player:");
                int playerId = int.Parse(Console.ReadLine());
                Console.WriteLine();

                Console.WriteLine("Injury:");
                string injuryName = Console.ReadLine();
                Console.WriteLine();

                playerService.AddInjury(playerId, injuryName);

                Console.WriteLine("Injury added successfully!");
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            //catch (Exception)
            //{
            //    Console.WriteLine(SomethingWentWrong());
            //}
        }

        private void ListAllMatchesForATeam()
        {
            Console.WriteLine(Label("LIST ALL MATCHES FOR A TEAM"));

            try
            {
                Console.WriteLine("Id of the team:");
                int id = int.Parse(Console.ReadLine());
                Console.WriteLine();

                List<Match> matches = matchService.GetAllForATeam(id);

                if (matches.Count == 0)
                {
                    Console.WriteLine("None");
                    return;
                }

                foreach (var match in matches)
                {
                    Console.WriteLine(this.Buffer("MATCH"));

                    Console.WriteLine(match);
                }
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            //catch (Exception)
            //{
            //    Console.WriteLine(SomethingWentWrong());
            //}
        }

        private void ListAllMatches()
        {
            Console.WriteLine(Label("LIST ALL MATCHES"));

            //try
            //{
                List<Match> matches = matchService.GetAll();

                if (matches.Count == 0)
                {
                    Console.WriteLine("None");
                    return;
                }

                foreach (var match in matches)
                {
                    Console.WriteLine(this.Buffer("MATCH"));

                    Console.WriteLine(match);
                }
            //}
            //catch (Exception)
            //{
            //    Console.WriteLine(SomethingWentWrong());
            //}
        }

        private void GetMatchResult()
        {
            Console.WriteLine(Label("GET MATCH RESULT"));

            try
            {
                Console.WriteLine("Id of the match:");
                int id = int.Parse(Console.ReadLine());
                Console.WriteLine();

                Console.WriteLine(matchService.GetMatchResult(id));
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            //catch (Exception)
            //{
            //    Console.WriteLine(SomethingWentWrong());
            //}
        }

        private void PlayMatch()
        {
            Console.WriteLine(Label("PLAY MATCH"));

            try
            {
                Console.WriteLine("Id of the match:");
                int id = int.Parse(Console.ReadLine());
                Console.WriteLine();

                matchService.PlayMatch(id);

                Console.WriteLine("Match played!");
                Console.WriteLine();

                Console.WriteLine("Result:");
                Console.WriteLine(matchService.GetMatchResult(id));
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            //catch (Exception)
            //{
            //    Console.WriteLine(SomethingWentWrong());
            //}
        }

        private void DeleteMatch()
        {
            Console.WriteLine(Label("DELETE MATCH"));

            try
            {
                Console.WriteLine("Id of the match:");
                int id = int.Parse(Console.ReadLine());
                Console.WriteLine();

                matchService.RemoveMatch(id);

                Console.WriteLine("Match deleted successfully!");
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            //catch (Exception)
            //{
            //    Console.WriteLine(SomethingWentWrong());
            //}
        }

        private void AddMatch()
        {
            Console.WriteLine(Label("ADD MATCH"));

            try
            {
                Match match = new Match();

                Console.WriteLine("Id of the host team:");
                int hostId = int.Parse(Console.ReadLine());
                Console.WriteLine();
                match.HostId = hostId;
                //match.HostTeam = teamService.GetTeamById(hostId);

                Console.WriteLine("Id of the guest team:");
                int guestId = int.Parse(Console.ReadLine());
                Console.WriteLine();
                match.GuestId = guestId;
               // match.GuestTeam = teamService.GetTeamById(guestId);

                matchService.AddMatch(match);

                Console.WriteLine("Match added successfully!");
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            //catch (Exception)
            //{
            //    Console.WriteLine(SomethingWentWrong());
            //}
        }

        private void ListAllPlayersForATeam()
        {
            Console.WriteLine(Label("LIST ALL PLAYERS FOR A TEAM"));

            try
            {
                Console.WriteLine("Id of the team:");
                int id = int.Parse(Console.ReadLine());
                Console.WriteLine();

                List<Player> players = teamService.GetAllPlayersForATeam(id);

                if (players.Count == 0)
                {
                    Console.WriteLine("None");
                    return;
                }

                foreach (var team in players)
                {
                    Console.WriteLine(this.Buffer("TEAM"));

                    Console.WriteLine(team);
                }
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            //catch (Exception)
            //{
            //    Console.WriteLine(SomethingWentWrong());
            //}
        }

        private void ListAllTeamsByDivision()
        {
            Console.WriteLine(Label("LIST ALL TEAMS FOR A DIVISION"));

            //try
            //{
                Console.WriteLine("Division:");
                int division = int.Parse(Console.ReadLine());
                Console.WriteLine();

                if (!Validations.IsDivisionValid(division))
                {
                    Console.WriteLine($"Invalid division - it must be between 1 and {Constants.DivisionsCount}!");

                    return;
                }

                List<Team> teams = teamService.GetAllByDivision(division);

                if (teams.Count == 0)
                {
                    Console.WriteLine("None");
                    return;
                }

                foreach (var team in teams)
                {
                    Console.WriteLine(this.Buffer("TEAM"));

                    Console.WriteLine(team);
                }

            //}
            //catch (Exception)
            //{
            //    Console.WriteLine(SomethingWentWrong());
            //}
        }

        private void ListAllTeams()
        {
            Console.WriteLine(Label("LIST ALL TEAMS"));

            //try
            //{
                List<Team> teams = teamService.GetAll();

                if (teams.Count == 0)
                {
                    Console.WriteLine("None");
                    return;
                }

                foreach (var team in teams)
                {
                    Console.WriteLine(this.Buffer("TEAM"));

                    Console.WriteLine(team);
                }
            //}
            //catch (Exception)
            //{
            //    Console.WriteLine(SomethingWentWrong());
            //}
        }

        private void TeamSellPlayer()
        {
            Console.WriteLine(Label("TEAM SELL PLAYER"));

            try
            {
                Console.WriteLine("Id of the team:");
                int teamId = int.Parse(Console.ReadLine());
                Console.WriteLine();

                Console.WriteLine("Id of the player:");
                int playerId = int.Parse(Console.ReadLine());
                Console.WriteLine();

                teamService.SellPlayer(teamId, playerId);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            //catch (Exception)
            //{
            //    Console.WriteLine(SomethingWentWrong());
            //}
        }

        private void AddPlayerToATeam()
        {
            Console.WriteLine(Label("ADD PLAYER TO A TEAM"));

            try
            {
                Console.WriteLine("Id of the team:");
                int teamId = int.Parse(Console.ReadLine());
                Console.WriteLine();

                Console.WriteLine("Id of the player");
                int playerId = int.Parse(Console.ReadLine());
                Console.WriteLine();

                teamService.AddPlayerToATeam(teamId, playerId);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            //catch (Exception)
            //{
            //    Console.WriteLine(SomethingWentWrong());
            //}
        }

        private void DeleteTeam()
        {
            Console.WriteLine(Label("DELETE TEAM"));

            try
            {
                Console.WriteLine("Id of the team:");
                int id = int.Parse(Console.ReadLine());
                Console.WriteLine();

                teamService.DeleteTeam(id);

                Console.WriteLine("Team deleted successfully");
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            //catch (Exception)
            //{
            //    Console.WriteLine(SomethingWentWrong());
            //}
        }

        private void AddTeam()
        {
            Console.WriteLine(Label("ADD TEAM"));

            try
            {
                Team team = new Team();
                Console.WriteLine("Name:");
                team.Name = Console.ReadLine();
                Console.WriteLine();

                Console.WriteLine("Division:");
                team.Division = int.Parse(Console.ReadLine());
                Console.WriteLine();

                Console.WriteLine("Budget:");
                team.Budget = decimal.Parse(Console.ReadLine());
                Console.WriteLine();

                teamService.AddTeam(team);

                Console.WriteLine("Team added successfully");
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            //catch (Exception)
            //{
            //    Console.WriteLine(SomethingWentWrong());
            //}
        }

        private void ListAllPlayersOnSale()
        {
            Console.WriteLine(Label("LIST ALL PLAYERS ON SALE"));

            //try
            //{
                List<Player> playersOnSale = playerService.GetAllOnSale();

                if (playersOnSale.Count == 0)
                {
                    Console.WriteLine("None");
                    return;
                }

                foreach (var player in playersOnSale)
                {
                    Console.WriteLine(this.Buffer("PLAYER"));

                    Console.WriteLine(player);
                }
            //}
            //catch (Exception)
            //{
            //    Console.WriteLine(SomethingWentWrong());
            //}
        }

        private void ListAllPlayers()
        {
            Console.WriteLine(Label("LIST ALL PLAYERS"));

            //try
            //{
                List<Player> players = playerService.GetAll();

                if (players.Count == 0)
                {
                    Console.WriteLine("None");
                    return;
                }

                foreach (var player in players)
                {
                    Console.WriteLine(this.Buffer("PLAYER"));

                    Console.WriteLine(player);
                }
            //}
            //catch (Exception)
            //{
            //    Console.WriteLine(SomethingWentWrong());
            //}
        }

        private void DeletePlayer()
        {
            Console.WriteLine(Label("DELETE PLAYER"));

            try
            {
                Console.WriteLine("Player Id:");
                int id = int.Parse(Console.ReadLine());
                Console.WriteLine();

                playerService.DeletePlayer(id);

                Console.WriteLine("Player deleted successfully!");
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            //catch (Exception)
            //{
            //    Console.WriteLine(SomethingWentWrong());
            //}
        }

        private void AddPlayer()
        {
            Console.WriteLine(Label("ADD PLAYER"));

            try
            {
                Player player = new Player();
                Console.WriteLine("Name:");
                player.Name = Console.ReadLine();
                Console.WriteLine();

                Console.WriteLine("Age:");
                player.Age = int.Parse(Console.ReadLine());
                Console.WriteLine();

                playerService.AddPlayer(player);

                Console.WriteLine("Player added successfully!");
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            //catch (Exception)
            //{
            //    Console.WriteLine(SomethingWentWrong());
            //}
        }

        private void ListAllCoaches()
        {
            Console.WriteLine(Label("LIST ALL COACHES"));

            //try
            //{
                List<Coach> coaches = coachSevice.GetAll();

                if (coaches.Count == 0)
                {
                    Console.WriteLine("None");
                    return;
                }

                foreach (var coach in coaches)
                {
                    Console.WriteLine(this.Buffer("COACH"));

                    Console.WriteLine(coach);
                }
            //}
            //catch (Exception)
            //{
            //    Console.WriteLine(SomethingWentWrong());
            //}


        }

        private void DeleteCoach()
        {
            Console.WriteLine(Label("DELETE COACH"));

            try
            {
                Console.WriteLine("Id of the coach:");
                int id = int.Parse(Console.ReadLine());
                Console.WriteLine();

                coachSevice.DeleteCoach(id);

                Console.WriteLine("Coach deleted successfully!");
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            //catch (Exception)
            //{
            //    Console.WriteLine(SomethingWentWrong());
            //}
        }

        private void AddCoach()
        {
            Console.WriteLine(Label("ADD COACH"));

            try
            {
                Coach coach = new Coach();
                Console.WriteLine("Name:");
                coach.Name = Console.ReadLine();
                Console.WriteLine();

                Console.WriteLine("Age:");
                coach.Age = int.Parse(Console.ReadLine());
                Console.WriteLine();

                coachSevice.AddCoach(coach);

                Console.WriteLine("Coach added successfully!");
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            //catch (Exception)
            //{
            //    Console.WriteLine(SomethingWentWrong());
            //}
        }

        private void ShowMenu()
        {
            Console.WriteLine(Label("MENU"));

            StringBuilder sb = new StringBuilder();

            sb.AppendLine("0. Exit");
            sb.AppendLine("					Player options:");
            sb.AppendLine("Coach options:				");
            sb.AppendLine("					5. Add player");
            sb.AppendLine("1. Add coach				6. Delete player");
            sb.AppendLine("2. Delete coach				7. List all players");
            sb.AppendLine("3. List all coaches			8. List all players on sale");
            sb.AppendLine("4. Get coach by Id			9. Get player by Id");
            sb.AppendLine("					10. Add injury to a player");
            sb.AppendLine("Team options:		");
            sb.AppendLine("					Match options:");
            sb.AppendLine("11. Add team				");
            sb.AppendLine("12. Delete team				19. Add match");
            sb.AppendLine("13. Add player to a team		20. Delete match");
            sb.AppendLine("14. Team sell player			21. Play Match");
            sb.AppendLine("15. List all teams			22. Get match result");
            sb.AppendLine("16. List all teams by division		23. List all matches");
            sb.AppendLine("17. List all players for a team		24. List all matches for a team");
            sb.AppendLine("18. Get team by Id			25. Get match by Id");

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

        private string Buffer(string text)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine();

            int before = (Constants.LabelSize - text.Length) / 2;
            int after = Constants.LabelSize - before;
            sb.AppendLine(new string('-', before) + text + new string('-', after));

            sb.AppendLine();

            return sb.ToString();
        }

        private string SomethingWentWrong()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("  ----								  ----  ");
            sb.AppendLine(@"_/O.O\\_	Something went wrong, please try again later	_//O.O\_");
            sb.AppendLine("--------							--------");

            return sb.ToString().TrimEnd();
        }
    }
}