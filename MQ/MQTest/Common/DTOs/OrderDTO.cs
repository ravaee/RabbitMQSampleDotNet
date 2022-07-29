using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTOs
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }

    public class CustomerDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }

    public class ProjectDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }
}
