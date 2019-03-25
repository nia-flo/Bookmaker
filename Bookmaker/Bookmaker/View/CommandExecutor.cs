using System.Runtime.CompilerServices;
using Bookmaker.Services;

namespace Bookmaker.View
{
    public static class CommandExecutor
    {
        private static ICoachSevice coachSevice;
        private static IInjuryService injuryService;
        private static IPlayerService playerService;
        private static ITeamService teamService;
        private static IMatchService matchService;

        static CommandExecutor()
        {
            coachSevice = new CoachService();
            injuryService = new InjuryService();
            playerService = new PlayerService();
            teamService = new TeamService();
            matchService = new MatchService();
        }


    }
}