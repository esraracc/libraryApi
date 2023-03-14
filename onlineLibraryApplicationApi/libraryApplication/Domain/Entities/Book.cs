using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Book : Entity
    {
        public Book()
        {
        }

        public Book(int id, string name, int pageCount, int count, string authorName) : this()
        {
            Id = id;
            Name = name;
            PageCount = pageCount;
            Count = count;
            AuthorName = authorName;
        }

        public string Name { get; set; }
        public int PageCount { get; set; }
        public int Count { get; set; }
        public string AuthorName { get; set; }
        //public UserActionsOnTheBook UserActionsOnTheBook { get; set; }
    }
}
