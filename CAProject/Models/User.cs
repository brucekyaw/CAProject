using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace CAProject.Models;

    public class User 
    {
            [Key]
            public string Username{ get; set;}
            public string Password { get; set; }
            public string? SessionId { get; set; }
            public virtual List<Order> Orders { get; set; }

    }
