using Bookmaker.Data;
using Bookmaker.Data.Models;

namespace Bookmaker.Services
{
    public class ResultService
    {
        private BookmakerContext context;

        public ResultService(BookmakerContext context)
        {
            this.context = context;
        }

        public void AddResult(Result result)
        {
            context.Results.Add(result);

            context.SaveChanges();
        }
    }
}