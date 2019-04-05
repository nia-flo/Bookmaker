using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using Bookmaker.Data;
using Bookmaker.Data.Models;
using Bookmaker.Services;
using Pastel;

namespace Bookmaker.View
{
    public class Display
    {
        private ICoachSevice coachSevice;
        private IPlayerService playerService;
        private ITeamService teamService;
        private IMatchService matchService;

        public Display(BookmakerContext context)
        {
            this.coachSevice = new CoachService(context);
            this.playerService = new PlayerService(context);
            this.teamService = new TeamService(context);
            this.matchService = new MatchService(context);

            SetUpConsole();

            Home();
        }

        private void SetUpConsole()
        {
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.ForegroundColor = ConsoleColor.White;
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
            PrintSpecial("Press any key to continue...");
            Console.ReadKey();

            Home();
        }

        private bool GetUserInput()
        {
            try
            {
                Print("");
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
                        AddCoachToATeam();
                        break;
                    case 16:
                        RemoveCoachFromATeam();
                        break;
                    case 17:
                        ListAllTeams();
                        break;
                    case 18:
                        ListAllTeamsByDivision();
                        break;
                    case 19:
                        ListAllPlayersForATeam();
                        break;
                    case 20:
                        ListAllCoachesForATeam();
                        break;
                    case 21:
                        GetTeamById();
                        break;
                    case 22:
                        AddMatch();
                        break;
                    case 23:
                        DeleteMatch();
                        break;
                    case 24:
                        PlayMatch();
                        break;
                    case 25:
                        GetMatchResult();
                        break;
                    case 26:
                        ListAllMatches();
                        break;
                    case 27:
                        ListAllMatchesForATeam();
                        break;
                    case 28:
                        GetMatchById();
                        break;
                    default:
                        PrintSpecial("Invalid option!");
                        break;
                }

                return true;
            }
            catch (Exception)
            {
                PrintSpecial("Please select a valid option!");
                return GetUserInput();
            }
        }

        private void ListAllCoachesForATeam()
        {
            PrintSpecial(Label("LIST ALL COACHES FOR A TEAM"));

            try
            {
                Print("Id of the team:");
                int id = int.Parse(Console.ReadLine());
                Print("");

                List<Coach> coaches = teamService.GetAllCoachesForATeam(id);

                if (coaches.Count == 0)
                {
                    Print("None");
                    return;
                }

                foreach (var coach in coaches)
                {
                    PrintSpecial(this.Buffer("COACH"));

                    Print(coach.ToString());
                }
            }
            catch (ArgumentException e)
            {
                Print(e.Message);
            }
            catch (Exception)
            {
                Print(SomethingWentWrong());
            }
        }

        private void RemoveCoachFromATeam()
        {
            PrintSpecial(Label("REMOVE COACH FROM A TEAM"));

            try
            {
                Print("Id of the team:");
                int teamId = int.Parse(Console.ReadLine());
                Print("");

                Print("Id of the coach:");
                int coachId = int.Parse(Console.ReadLine());
                Print("");

                teamService.RemoveCoachFromATeam(teamId, coachId);

                Print("Coach removed from the team successfully!");
            }
            catch (ArgumentException e)
            {
                Print(e.Message);
            }
            catch (Exception)
            {
                Print(SomethingWentWrong());
            }
        }

        private void AddCoachToATeam()
        {
            PrintSpecial(Label("ADD COACH TO A TEAM"));

            try
            {
                Print("Id of the team:");
                int teamId = int.Parse(Console.ReadLine());
                Print("");

                Print("Id of the coach:");
                int coachId = int.Parse(Console.ReadLine());
                Print("");

                teamService.AddCoachToATeam(teamId, coachId);

                Print("Coach added to the team successfully!");
            }
            catch (ArgumentException e)
            {
                Print(e.Message);
            }
            catch (Exception)
            {
                Print(SomethingWentWrong());
            }
        }

        private void GetMatchById()
        {
            PrintSpecial(Label("GET MATCH BY ID"));

            try
            {
                Print("Id of the match:");
                int id = int.Parse(Console.ReadLine());
                Print("");

                Match match = matchService.GetMatchById(id);

                Print(match.ToString());
            }
            catch (ArgumentException)
            {
                Print("Match not found.");
            }
            catch (Exception)
            {
                Print(SomethingWentWrong());
            }
        }

        private void GetTeamById()
        {
            PrintSpecial(Label("GET TEAM BY ID"));

            try
            {
                Print("Id of the team:");
                int id = int.Parse(Console.ReadLine());
                Print("");

                Team team = teamService.GetTeamById(id);

                Print(team.ToString());
            }
            catch (ArgumentException)
            {
                Print("Team not found.");
            }
            catch (Exception)
            {
                Print(SomethingWentWrong());
            }
        }

        private void GetPlayerById()
        {
            PrintSpecial(Label("GET PLAYER BY ID"));

            try
            {
                Print("Id of the player:");
                int id = int.Parse(Console.ReadLine());
                Print("");

                Player player = playerService.GetPlayerById(id);

                Print(player.ToString());
            }
            catch (ArgumentException)
            {
                Print("Player not found");
            }
            catch (Exception)
            {
                Print(SomethingWentWrong());
            }
        }

        private void GetCoachById()
        {
            PrintSpecial(Label("GET COACH BY ID"));

            try
            {
                Print("Id of the coach:");
                int id = int.Parse(Console.ReadLine());
                Print("");

                Coach coach = coachSevice.GetCoachById(id);

                Print(coach.ToString());
            }
            catch (ArgumentException)
            {
                Print("Coach not found.");
            }
            catch (Exception)
            {
                Print(SomethingWentWrong());
            }
        }

        private void AddInjuryToAPlayer()
        {
            PrintSpecial(Label("ADD INJURY TO A PLAYER"));

            try
            {
                Print("Id of the player:");
                int playerId = int.Parse(Console.ReadLine());
                Print("");

                Print("Injury:");
                string injuryName = Console.ReadLine();
                Print("");

                playerService.AddInjury(playerId, injuryName);

                Print("Injury added successfully!");
            }
            catch (ArgumentException e)
            {
                Print(e.Message);
            }
            catch (Exception)
            {
                Print(SomethingWentWrong());
            }
        }

        private void ListAllMatchesForATeam()
        {
            PrintSpecial(Label("LIST ALL MATCHES FOR A TEAM"));

            try
            {
                Print("Id of the team:");
                int id = int.Parse(Console.ReadLine());
                Print("");

                List<Match> matches = matchService.GetAllForATeam(id);

                if (matches.Count == 0)
                {
                    Print("None");
                    return;
                }

                foreach (var match in matches)
                {
                    PrintSpecial(this.Buffer("MATCH"));

                    Print(match.ToString());
                }
            }
            catch (ArgumentException e)
            {
                Print(e.Message);
            }
            catch (Exception)
            {
                Print(SomethingWentWrong());
            }
        }

        private void ListAllMatches()
        {
            PrintSpecial(Label("LIST ALL MATCHES"));

            try
            {
                List<Match> matches = matchService.GetAll();

                if (matches.Count == 0)
                {
                    Print("None");
                    return;
                }

                foreach (var match in matches)
                {
                    PrintSpecial(this.Buffer("MATCH"));

                    Print(match.ToString());
                }
            }
            catch (Exception)
            {
                Print(SomethingWentWrong());
            }
        }

        private void GetMatchResult()
        {
            PrintSpecial(Label("GET MATCH RESULT"));

            try
            {
                Print("Id of the match:");
                int id = int.Parse(Console.ReadLine());
                Print("");

                Print(matchService.GetMatchResult(id));
            }
            catch (ArgumentException e)
            {
                Print(e.Message);
            }
            catch (Exception)
            {
                Print(SomethingWentWrong());
            }
        }

        private void PlayMatch()
        {
            PrintSpecial(Label("PLAY MATCH"));

            try
            {
                Print("Id of the match:");
                int id = int.Parse(Console.ReadLine());
                Print("");

                matchService.PlayMatch(id);

                Print("Match played!");
                Print("");

                Print("Result:");
                Print(matchService.GetMatchResult(id));
            }
            catch (ArgumentException e)
            {
                Print(e.Message);
            }
            catch (Exception)
            {
                Print(SomethingWentWrong());
            }
        }

        private void DeleteMatch()
        {
            PrintSpecial(Label("DELETE MATCH"));

            try
            {
                Print("Id of the match:");
                int id = int.Parse(Console.ReadLine());
                Print("");

                matchService.RemoveMatch(id);

                Print("Match deleted successfully!");
            }
            catch (ArgumentException e)
            {
                Print(e.Message);
            }
            catch (Exception)
            {
                Print(SomethingWentWrong());
            }
        }

        private void AddMatch()
        {
            PrintSpecial(Label("ADD MATCH"));

            try
            {
                Print("Id of the host team:");
                int hostId = int.Parse(Console.ReadLine());
                Print("");

                Team hostTeam = teamService.GetTeamById(hostId);

                Print("Id of the guest team:");
                int guestId = int.Parse(Console.ReadLine());
                Print("");

                Team guestTeam = teamService.GetTeamById(guestId);

                Match match = new Match()
                {
                    HostId = hostId,
                    HostTeam = hostTeam,
                    GuestId = guestId,
                    GuestTeam = guestTeam
                };

                matchService.AddMatch(match);

                Print("Match added successfully!");
            }
            catch (ArgumentException e)
            {
                Print(e.Message);
            }
            catch (Exception ex)
            {
                //Print(SomethingWentWrong());
                Console.WriteLine(ex.Message);
            }
        }

        private void ListAllPlayersForATeam()
        {
            PrintSpecial(Label("LIST ALL PLAYERS FOR A TEAM"));

            try
            {
                Print("Id of the team:");
                int id = int.Parse(Console.ReadLine());
                Print("");

                List<Player> players = teamService.GetAllPlayersForATeam(id);

                if (players.Count == 0)
                {
                    Print("None");
                    return;
                }

                foreach (var team in players)
                {
                    PrintSpecial(this.Buffer("PLAYER"));

                    Print(team.ToString());
                }
            }
            catch (ArgumentException e)
            {
                Print(e.Message);
            }
            catch (Exception)
            {
                Print(SomethingWentWrong());
            }
        }

        private void ListAllTeamsByDivision()
        {
            PrintSpecial(Label("LIST ALL TEAMS FOR A DIVISION"));

            try
            {
                Print("Division:");
                int division = int.Parse(Console.ReadLine());
                Print("");

                if (!Validations.IsDivisionValid(division))
                {
                    Print($"Invalid division - it must be between 1 and {Constants.DivisionsCount}!");

                    return;
                }

                List<Team> teams = teamService.GetAllByDivision(division);

                if (teams.Count == 0)
                {
                    Print("None");
                    return;
                }

                foreach (var team in teams)
                {
                    PrintSpecial(this.Buffer("TEAM"));

                    Print(team.ToString());
                }

            }
            catch (Exception)
            {
                Print(SomethingWentWrong());
            }
        }

        private void ListAllTeams()
        {
            PrintSpecial(Label("LIST ALL TEAMS"));

            try
            {
                List<Team> teams = teamService.GetAll();

                if (teams.Count == 0)
                {
                    Print("None");
                    return;
                }

                foreach (var team in teams)
                {
                    PrintSpecial(this.Buffer("TEAM"));

                    Print(team.ToString());
                }
            }
            catch (Exception)
            {
                Print(SomethingWentWrong());
            }
        }

        private void TeamSellPlayer()
        {
            PrintSpecial(Label("TEAM SELL PLAYER"));

            try
            {
                Print("Id of the team:");
                int teamId = int.Parse(Console.ReadLine());
                Print("");

                Print("Id of the player:");
                int playerId = int.Parse(Console.ReadLine());
                Print("");

                teamService.SellPlayer(teamId, playerId);

                Print("Player sold successfully!");
            }
            catch (ArgumentException e)
            {
                Print(e.Message);
            }
            catch (Exception)
            {
                Print(SomethingWentWrong());
            }
        }

        private void AddPlayerToATeam()
        {
            PrintSpecial(Label("ADD PLAYER TO A TEAM"));

            try
            {
                Print("Id of the team:");
                int teamId = int.Parse(Console.ReadLine());
                Print("");

                Print("Id of the player");
                int playerId = int.Parse(Console.ReadLine());
                Print("");

                teamService.AddPlayerToATeam(teamId, playerId);

                Print("Player added successfully to the team!");
            }
            catch (ArgumentException e)
            {
                Print(e.Message);
            }
            catch (Exception)
            {
                Print(SomethingWentWrong());
            }
        }

        private void DeleteTeam()
        {
            PrintSpecial(Label("DELETE TEAM"));

            try
            {
                Print("Id of the team:");
                int id = int.Parse(Console.ReadLine());
                Print("");

                teamService.DeleteTeam(id);

                Print("Team deleted successfully");
            }
            catch (ArgumentException e)
            {
                Print(e.Message);
            }
            catch (Exception)
            {
                Print(SomethingWentWrong());
            }
        }

        private void AddTeam()
        {
            PrintSpecial(Label("ADD TEAM"));

            try
            {
                Team team = new Team();
                Print("Name:");
                team.Name = Console.ReadLine();
                Print("");

                Print("Division:");
                team.Division = int.Parse(Console.ReadLine());
                Print("");

                Print("Budget:");
                team.Budget = decimal.Parse(Console.ReadLine());
                Print("");

                teamService.AddTeam(team);

                Print("Team added successfully");
            }
            catch (ArgumentException e)
            {
                Print(e.Message);
            }
            catch (Exception)
            {
                Print(SomethingWentWrong());
            }
        }

        private void ListAllPlayersOnSale()
        {
            PrintSpecial(Label("LIST ALL PLAYERS ON SALE"));

            try
            {
                List<Player> playersOnSale = playerService.GetAllOnSale();

                if (playersOnSale.Count == 0)
                {
                    Print("None");
                    return;
                }

                foreach (var player in playersOnSale)
                {
                    PrintSpecial(this.Buffer("PLAYER"));

                    Print(player.ToString());
                }
            }
            catch (Exception)
            {
                Print(SomethingWentWrong());
            }
        }

        private void ListAllPlayers()
        {
            PrintSpecial(Label("LIST ALL PLAYERS"));

            try
            {
                List<Player> players = playerService.GetAll();

                if (players.Count == 0)
                {
                    Print("None");
                    return;
                }

                foreach (var player in players)
                {
                    PrintSpecial(this.Buffer("PLAYER"));

                    Print(player.ToString());
                }
            }
            catch (Exception)
            {
                Print(SomethingWentWrong());
            }
        }

        private void DeletePlayer()
        {
            PrintSpecial(Label("DELETE PLAYER"));

            try
            {
                Print("Player Id:");
                int id = int.Parse(Console.ReadLine());
                Print("");

                playerService.DeletePlayer(id);

                Print("Player deleted successfully!");
            }
            catch (ArgumentException e)
            {
                Print(e.Message);
            }
            catch (Exception)
            {
                Print(SomethingWentWrong());
            }
        }

        private void AddPlayer()
        {
            PrintSpecial(Label("ADD PLAYER"));

            try
            {
                Player player = new Player();
                Print("Name:");
                player.Name = Console.ReadLine();
                Print("");

                Print("Age:");
                player.Age = int.Parse(Console.ReadLine());
                Print("");

                playerService.AddPlayer(player);

                Print("Player added successfully!");
            }
            catch (ArgumentException e)
            {
                Print(e.Message);
            }
            catch (Exception)
            {
                Print(SomethingWentWrong());
            }
        }

        private void ListAllCoaches()
        {
            PrintSpecial(Label("LIST ALL COACHES"));

            try
            {
                List<Coach> coaches = coachSevice.GetAll();

                if (coaches.Count == 0)
                {
                    Print("None");
                    return;
                }

                foreach (var coach in coaches)
                {
                    PrintSpecial(this.Buffer("COACH"));

                    Print(coach.ToString());
                }
            }
            catch (Exception)
            {
                Print(SomethingWentWrong());
            }


        }

        private void DeleteCoach()
        {
            PrintSpecial(Label("DELETE COACH"));

            try
            {
                Print("Id of the coach:");
                int id = int.Parse(Console.ReadLine());
                Print("");

                coachSevice.DeleteCoach(id);

                Print("Coach deleted successfully!");
            }
            catch (ArgumentException e)
            {
                Print(e.Message);
            }
            catch (Exception)
            {
                Print(SomethingWentWrong());
            }
        }

        private void AddCoach()
        {
            PrintSpecial(Label("ADD COACH"));

            try
            {
                Coach coach = new Coach();
                Print("Name:");
                coach.Name = Console.ReadLine();
                Print("");

                Print("Age:");
                coach.Age = int.Parse(Console.ReadLine());
                Print("");

                coachSevice.AddCoach(coach);

                Print("Coach added successfully!");
            }
            catch (ArgumentException e)
            {
                Print(e.Message);
            }
            catch (Exception)
            {
                Print(SomethingWentWrong());
            }
        }

        private void ShowMenu()
        {
            PrintSpecial(Label("MENU"));

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
            sb.AppendLine("12. Delete team				22. Add match");
            sb.AppendLine("13. Add player to a team		23. Delete match");
            sb.AppendLine("14. Team sell player			24. Play Match");
            sb.AppendLine("15. Add coach to a team			25. Get match result");
            sb.AppendLine("16. Remove coach from a team		26. List all matches");
            sb.AppendLine("17. List all teams			27. List all matches for a team");
            sb.AppendLine("18. List all teams by division		28. Get match by Id");
            sb.AppendLine("19. List all players for a team");
            sb.AppendLine("20. List all coaches for a team");
            sb.AppendLine("21. Get team by Id");

            Print(sb.ToString().Trim());
        }

        private string Label(string text)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(new string('#', Constants.LabelSize));

            int before = (Constants.LabelSize - text.Length) / 2;
            int after = Constants.LabelSize - text.Length - before;
            sb.AppendLine(new string(' ', before) + text + new string(' ', after));

            sb.AppendLine(new string('#', Constants.LabelSize));

            return sb.ToString();
        }

        private string Buffer(string text)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine();

            int before = (Constants.LabelSize - text.Length) / 2;
            int after = Constants.LabelSize - text.Length - before;
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

        private void Print(string text)
        {
            //Console.WriteLine(text);
            Console.WriteLine(text.Pastel("#99FF99"));
        }

        private void PrintSpecial(string text)
        {
            Console.WriteLine(text.Pastel("#003300"));
        }
    }
}