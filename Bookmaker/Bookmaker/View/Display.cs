using System;
using System.Collections.Generic;
using Bookmaker.Data.Models;
using Bookmaker.Services;

namespace Bookmaker.View
{
    public class Display
    {
        private ICoachSevice coachSevice;
        private IInjuryService injuryService;
        private IPlayerService playerService;
        private ITeamService teamService;
        private IMatchService matchService;

        public Display(ICoachSevice coachSevice, IInjuryService injuryService, IPlayerService playerService, ITeamService teamService, IMatchService matchService)
        {
            this.coachSevice = coachSevice;
            this.injuryService = injuryService;
            this.playerService = playerService;
            this.teamService = teamService;
            this.matchService = matchService;

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

            Console.WriteLine("Press enter to continue...");
            string justAnInput = Console.ReadLine();

            Home();
        }

        private bool GetUserInput()
        {
            Console.WriteLine();
            int input = int.Parse(Console.ReadLine());

            Console.WriteLine();

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
                default:
                    Console.WriteLine("Invalid option!");
                    break;
            }

            return true;
        }

        private void ListAllMatchesForATeam()
        {
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
            Console.WriteLine(new string('#', 50));
            Console.WriteLine(new string(' ', 23) + "MENU" + new string(' ', 23));
            Console.WriteLine(new string('#', 50));

            Console.WriteLine("0. Exit");
            Console.WriteLine("1. Add coach");
            Console.WriteLine("2. Delete coach");
            Console.WriteLine("3. List all coaches");
            Console.WriteLine("4. Add player");
            Console.WriteLine("5. Delete player");
            Console.WriteLine("6. List all players");
            Console.WriteLine("7. List all players on sale");
            Console.WriteLine("8. Add team");
            Console.WriteLine("9. Delete team");
            Console.WriteLine("10. Add player to a team");
            Console.WriteLine("11. Team sell player");
            Console.WriteLine("12. List all teams");
            Console.WriteLine("13. List all players for a team");
            Console.WriteLine("14. Add match");
            Console.WriteLine("15. Delete match");
            Console.WriteLine("16. Play Match");
            Console.WriteLine("17. Get match result");
            Console.WriteLine("18. List all matches");
            Console.WriteLine("19. List all matches for a team");
        }
    }
}