using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bookmaker.Data.Models
{
    public class Coach : Person
    {
        public int? TeamId { get; set; }
        public virtual Team Team { get; set; }
    }
}