using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiApp.DL.Models
{
    public class PersonContext: DbContext
    {
        public PersonContext(string connString) : base(connString) { }

        static PersonContext()
        {
            Database.SetInitializer<PersonContext>(new DbInitializer());
        }

        public DbSet<Person> Persons { get; set; }
    }

    public class DbInitializer : DropCreateDatabaseAlways<PersonContext>
    {
        protected override void Seed(PersonContext db)
        {
            Person p1 = new Person { IIN = "1", FirstName = "Name_1", LastName = "LastName_1", BirthDate = "11-01-1991" };
            Person p2 = new Person { IIN = "2", FirstName = "Name_2", LastName = "LastName_2", BirthDate = "21-11-1994" };
            Person p3 = new Person { IIN = "3", FirstName = "Name_3", LastName = "LastName_3", BirthDate = "31-12-1995" };
            db.Persons.AddRange(new List<Person> { p1, p2, p3 });
            db.SaveChanges();

            base.Seed(db);
        }
    }
}
