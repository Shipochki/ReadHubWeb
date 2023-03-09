using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadHub.Core.Services.Author.Models
{
    public class AuthorServiceModel
    {
        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;
    }
}
