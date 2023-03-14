using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserActionsOnTheBookRepository.Dtos
{
    public class UpdatedBookStatusDto
    {
        public BookStatus StatusOfTheBook { get; set; }
        public DateTime DeliveryDate { get; set; }
    }
}
