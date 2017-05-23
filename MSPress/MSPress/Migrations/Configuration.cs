namespace MSPress.Migrations
{
    using Controllers;
    using Microsoft.AspNet.Identity;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MSPress.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MSPress.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            // Create some sample users

            // Roles?
            // Create some users.           
            context.Users.AddOrUpdate(u => u.UserName,
                ConstructUser("computa_mike@hotmail.com", "password", "0123456789"),
                ConstructUser("Sue@Sue.com", "password", "0123456789"),
                ConstructUser("Steve@Steve.com", "password", "0123456789"),
                ConstructUser("kim@kim.com", "password", "0123456789")
                );
            context.SaveChanges();

            // Create some sample Books
            context.Books.AddOrUpdate(x => x.ID,
                new Book() { ID = 1, Title = "Exam Ref 70-743 Upgrading Your Skills to MCSA: Windows Server 2016 with Practice Test", Image = "https://www.microsoftpressstore.com/ShowCover.aspx?isbn=9781509303700" },
                new Book() { ID = 2, Title = "Exam Ref 70-743 Upgrading Your Skills to MCSA: Windows Server 2016 with Practice Test", Image = "https://www.microsoftpressstore.com/ShowCover.aspx?isbn=9781509303700" },
                new Book() { ID = 3, Title = "Exam Ref 70-740 Installation, Storage and Compute with Windows Server 2016", Image = "https://www.microsoftpressstore.com/ShowCover.aspx?isbn=9780735698826" });
            context.SaveChanges();

            

            CreateError(context, "Steve@steve.com", 1,1,"Typo error - check spelling of yore.",1);

            context.SaveChanges();
        }

        private void CreateError(ApplicationDbContext context, string reporterEmail, int errataID,int bookId, string description, int pagenumber)
        {
            var reporter = context.Users.SingleOrDefault(x => x.Email == reporterEmail);
            var victimBook = context.Books.SingleOrDefault(x => x.ID == bookId);
            context.SaveChanges();
            context.Errata.AddOrUpdate(x=>x.ID,
                new Erratum() {ID =errataID,  Status = Status.Pending, Book = victimBook, Reporter = reporter, DescriptionOfError = description, PageNumber = pagenumber });
            context.SaveChanges();
        }



 

        /// <summary>
        /// Constructs a user.
        /// </summary>
        /// <param name="UserName">Name of the user.</param>
        /// <param name="Password">The password.</param>
        /// <param name="PhoneNumber">The phone number.</param>
        /// <returns></returns>
        private ApplicationUser ConstructUser(string UserName, string Password, string PhoneNumber)
        {
            var passwordHash = new PasswordHasher();
            string password = passwordHash.HashPassword(Password);
            return new ApplicationUser
            {
                SecurityStamp = Guid.NewGuid().ToString(),
                Email = UserName,
                UserName = UserName,
                PasswordHash = password,
                PhoneNumber = PhoneNumber

            };
        }


    }
}
