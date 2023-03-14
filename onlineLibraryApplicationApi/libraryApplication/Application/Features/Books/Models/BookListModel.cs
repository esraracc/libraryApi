using Application.Features.Books.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Books.Models
{
    public class BookListModel
    {
        public List<BookListDto> BookList { get; set; }
    }
}
