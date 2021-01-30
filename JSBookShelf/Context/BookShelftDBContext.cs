using JSBookShelf.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JSBookShelf.Context
{
    public class BookShelftDBContext : DbContext
    {
        public DbSet<Book> Book { get; set; }

        public BookShelftDBContext(DbContextOptions<BookShelftDBContext> options) : base(options)
        {

        }
    }
}
