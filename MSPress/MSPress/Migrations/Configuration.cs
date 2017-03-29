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

            context.Users.AddOrUpdate(u => u.UserName,
                ConstructUser("computa_mike@hotmail.com", "password", "0123456789"),
                ConstructUser("Sue@Sue.com", "password", "0123456789"),
                ConstructUser("Steve@Steve.com", "password", "0123456789"),
                ConstructUser("kim@kim.com", "password", "0123456789")
                );

            var Steve = context.Users.Where(x => x.Email == "Steve@Steve.com").First();

            // Create some sample Data

            //context.Database.ExecuteSqlCommand("TRUNCATE TABLE Books");
            //context.Database.ExecuteSqlCommand("DBCC CHECKIDENT ('[Books]', RESEED, 0);");

            var nb = context.Books.Create();
            nb.ID = 1;
            nb.Title = "Exam Ref 70-743 Upgrading Your Skills to MCSA: Windows Server 2016 with Practice Test";
            nb.Image = "https://www.microsoftpressstore.com/ShowCover.aspx?isbn=9781509303700";
            nb.BookErrata = new System.Collections.Generic.List<Erratum>()
            {
                NewMethod(context, Steve, nb,12,"There is a typo in the third paragraph."),
                NewMethod(context, Steve, nb,15,"The question options presented here do not match the answers in the answer section."),
                NewMethod(context, Steve, nb,122,"This code example does not compile."),
                NewMethod(context, Steve, nb,127,"This assertion is incorrect - the cast the author suggests can't be done can be done.")
            };
           
            
            context.Books.AddOrUpdate(x => x.ID,
                nb,
                new Book() { ID = 2, Title = "Exam Ref 70-743 Upgrading Your Skills to MCSA: Windows Server 2016 with Practice Test", Image = "https://www.microsoftpressstore.com/ShowCover.aspx?isbn=9781509303700" },
                new Book() { ID = 3, Title = "Exam Ref 70-740 Installation, Storage and Compute with Windows Server 2016", Image = "https://www.microsoftpressstore.com/ShowCover.aspx?isbn=9780735698826" });
                      


        }

        private   Erratum  NewMethod(ApplicationDbContext context, ApplicationUser Steve, Book nb, int PageNumber,string Description)
        {
            var nb_errors = context.Errata.Create();
            nb_errors.ID = 1;
            nb_errors.Book = nb;
            nb_errors.PageNumber = PageNumber;
            nb_errors.DescriptionOfError = Description;
            nb_errors.Status = Status.Pending;
            nb_errors.Reporter = Steve;
            return nb_errors;
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
