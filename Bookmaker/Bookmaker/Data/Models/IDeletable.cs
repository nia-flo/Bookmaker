namespace Bookmaker.Data.Models
{
    public interface IDeletable
    {
        bool IsDeleted { get; set; }

        void Delete();
    }
}