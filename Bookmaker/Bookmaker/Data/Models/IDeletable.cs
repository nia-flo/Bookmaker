namespace Bookmaker.Data.Models
{
    /*
        The IDeletable interface
        Contains property IsDeleted and method Delete
    */
    /// <summary>
    /// The <c>IDeletable</c> interface.
    /// Contains property IsDeleted and method Delete.
    /// </summary>
    public interface IDeletable
    {
        bool IsDeleted { get; set; }

        // Deletes the entry
        /// <summary>
        /// Deletes the entry.
        /// </summary>
        /// <returns>
        /// Nothing
        /// </returns>
        /// <remarks>
        /// <para>The property IsDeleted is just made true</para>
        /// </remarks>
        void Delete();
    }
}