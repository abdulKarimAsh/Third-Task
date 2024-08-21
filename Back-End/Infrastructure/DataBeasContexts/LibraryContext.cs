using Domin;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Infrastructure.DataBeasContexts
{
    public class LibraryContext : DbContext
    {
        public LibraryContext()
        {
        }

        public LibraryContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        /*        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
                {
                    *//*            optionsBuilder.UseSqlServer("Data Source=ABDUL-KARIM\\SQLEXPRESS;Initial Catalog=LibraryDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
                    */
        /*optionsBuilder.UseSqlServer("workstation id=libraryabood.mssql.somee.com;packet size=4096;user id=abood;pwd=123abood;data source=libraryabood.mssql.somee.com;persist security info=False;initial catalog=libraryabood;TrustServerCertificate=True");*//*
        optionsBuilder.UseSqlServer("Data Source = SQL8020.site4now.net; Initial Catalog = db_aac4dc_librarya1; User Id = db_aac4dc_librarya1_admin; Password = abood123");
    }
}*/
    }
}
