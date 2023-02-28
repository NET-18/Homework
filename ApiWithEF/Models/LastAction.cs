using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiWithEF.Models
{
    public class LastAction
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string LastActionActivity { get; set; }
    }
}

