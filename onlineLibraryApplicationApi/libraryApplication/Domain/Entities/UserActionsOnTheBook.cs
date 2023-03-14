using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class UserActionsOnTheBook : Entity
    {
        public UserActionsOnTheBook()
        {
        }

        public UserActionsOnTheBook(int id, string userId, int bookId, BookStatus statusOfTheBook, DateTime reserveDate, DateTime? deliveryDate, DateTime returnDate) : this()
        {
            Id = id;
            UserId = userId;
            BookId = bookId;
            StatusOfTheBook = statusOfTheBook;
            ReserveDate = reserveDate;
            DeliveryDate = deliveryDate;
            ReturnDate = returnDate;
        }

        public string UserId { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
        public BookStatus StatusOfTheBook { get; set; }
        public DateTime ReserveDate { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public DateTime ReturnDate { get; set; }
    }
    public enum BookStatus
    {
        Reservation,//kitap rezerve edilmiş
        Return,//kitap iade edilmiş
    }
}
