using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Books.Dtos
{
    public class BookGetByIdDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PageCount { get; set; }
        public int Count { get; set; }
        public string AuthorName { get; set; }
    }
}
