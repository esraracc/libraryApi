using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserActionsOnTheBookRepository.Dtos
{
    public class CreatedUserBookDto
    {
        public string UserId { get; set; }
        public int BookId { get; set; }
        public BookStatus StatusOfTheBook { get; set; }
        public DateTime ReserveDate { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}
