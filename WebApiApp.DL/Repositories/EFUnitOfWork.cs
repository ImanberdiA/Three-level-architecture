using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiApp.DL.Interfaces;
using WebApiApp.DL.Models;

namespace WebApiApp.DL.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private PersonContext db;
        private PersonRepository personRepository;

        public EFUnitOfWork(string connectionString)
        {
            db = new PersonContext(connectionString);
        }
        public IRepository<Person> Persons
        {
            get
            {
                if (personRepository == null)
                    personRepository = new PersonRepository(db);
                return personRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
