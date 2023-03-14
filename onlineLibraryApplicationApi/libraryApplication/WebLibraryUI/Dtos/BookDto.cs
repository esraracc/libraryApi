using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebLibraryUI.Dtos
{
    public class BookDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PageCount { get; set; }
        public int Count { get; set; }
        public string AuthorName { get; set; }
    }
}
