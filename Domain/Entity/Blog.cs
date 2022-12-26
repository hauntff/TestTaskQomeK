using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class Blog
    {
        public int Id { get; set; }
        public string Header { get; set; }
        public string Body { get; set; }
        public string Author { get; set; }
    }
}
