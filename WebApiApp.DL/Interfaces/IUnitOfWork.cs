using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiApp.DL.Models;

namespace WebApiApp.DL.Interfaces
{
    public interface IUnitOfWork: IDisposable
    {
        IRepository<Person> Persons { get; }

        void Save();
    }
}
