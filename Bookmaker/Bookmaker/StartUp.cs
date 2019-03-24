using System;
using Bookmaker.Data;
using Bookmaker.Data.Models;
using Bookmaker.Services;
using Bookmaker.View;

namespace Bookmaker
{
    class StartUp
    {
        static void Main(string[] args)
        {
            BookmakerContext context = new BookmakerContext();

            Display display = new Display(new CoachService(context), new InjuryService(context),
                new PlayerService(context), new TeamService(context));
        }
    }
}
