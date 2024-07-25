using Domin;
using Infrastructure.DataBeasContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Web.DTOs
{
    public static class SeedingData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new LibraryContext(
                serviceProvider.GetRequiredService<DbContextOptions<LibraryContext>>()))
            {
                context.Database.EnsureDeleted();
                context.Database.Migrate();

                context.Categories.AddRange(
                    new Category() { Name = "Fiction" },
                    new Category() { Name = "Non-Fiction" }
                    );
                context.SaveChanges();

                context.SubCategories.AddRange(
                    new SubCategory() { Name = "Science Fiction", CategoryId = 1 },
                    new SubCategory() { Name = "Historical Fiction", CategoryId = 1 },
                    new SubCategory() { Name = "Biography", CategoryId = 2 },
                    new SubCategory() { Name = "Self-Help", CategoryId = 2 }
                    );
                context.SaveChanges();

                context.Authors.AddRange(
                    new Author() { Name = "Auther one" , DateOfBirth ="1999"},
                    new Author() { Name = "Auther two" , DateOfBirth ="1974"},
                    new Author() { Name = "Auther three", DateOfBirth ="2000" }
                    );
                context.SaveChanges();

                context.Books.AddRange(

                    new Book() { Title = "Book1", PublicationYear = "2000", SubCategoryId = 1, AuthorId = 1 },
                    new Book() { Title = "Book2", PublicationYear = "2001", SubCategoryId = 2, AuthorId = 2 },
                    new Book() { Title = "Book3", PublicationYear = "2002", SubCategoryId = 3, AuthorId = 3 },
                    new Book() { Title = "Book4", PublicationYear = "2003", SubCategoryId = 3, AuthorId = 3 },
                    new Book() { Title = "Book5", PublicationYear = "2004", SubCategoryId = 3, AuthorId = 3 },
                    new Book() { Title = "Book6", PublicationYear = "2005", SubCategoryId = 3, AuthorId = 3 },
                    new Book() { Title = "Book7", PublicationYear = "2006", SubCategoryId = 2, AuthorId = 3 },
                    new Book() { Title = "Book8", PublicationYear = "2007", SubCategoryId = 2, AuthorId = 3 },
                    new Book() { Title = "Book9", PublicationYear = "2008", SubCategoryId = 2, AuthorId = 3 },
                    new Book() { Title = "Book10", PublicationYear = "2009", SubCategoryId = 3, AuthorId = 3 },
                    new Book() { Title = "Book11", PublicationYear = "2010", SubCategoryId = 3, AuthorId = 3 },
                    new Book() { Title = "Book12", PublicationYear = "2011", SubCategoryId = 3, AuthorId = 1 },
                    new Book() { Title = "Book13", PublicationYear = "2012", SubCategoryId = 3, AuthorId = 1 },
                    new Book() { Title = "Book14", PublicationYear = "2013", SubCategoryId = 1, AuthorId = 1 },
                    new Book() { Title = "Book15", PublicationYear = "2014", SubCategoryId = 1, AuthorId = 1 },
                    new Book() { Title = "Book16", PublicationYear = "2015", SubCategoryId = 1, AuthorId = 3 },
                    new Book() { Title = "Book17", PublicationYear = "2016", SubCategoryId = 1, AuthorId = 3 },
                    new Book() { Title = "Book18", PublicationYear = "2017", SubCategoryId = 1, AuthorId = 3 },
                    new Book() { Title = "Book19", PublicationYear = "2018", SubCategoryId = 1, AuthorId = 2 },
                    new Book() { Title = "Book20", PublicationYear = "2019", SubCategoryId = 3, AuthorId = 2 },
                    new Book() { Title = "Book21", PublicationYear = "2020", SubCategoryId = 3, AuthorId = 2 },
                    new Book() { Title = "Book22", PublicationYear = "2021", SubCategoryId = 3, AuthorId = 2 },
                    new Book() { Title = "Book23", PublicationYear = "2022", SubCategoryId = 3, AuthorId = 2 },
                    new Book() { Title = "Book24", PublicationYear = "2023", SubCategoryId = 3, AuthorId = 3 },
                    new Book() { Title = "Book25", PublicationYear = "2024", SubCategoryId = 3, AuthorId = 3 },
                    new Book() { Title = "Book26", PublicationYear = "2025", SubCategoryId = 3, AuthorId = 3 }
                    );
                context.SaveChanges();
            }
        }
    }
}