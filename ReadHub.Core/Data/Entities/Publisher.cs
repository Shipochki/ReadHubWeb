using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadHub.Core.Data.Entities
{
    public class Publisher
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public ICollection<Book> PublishedBooks { get; set; } = new List<Book>();
    }
}
