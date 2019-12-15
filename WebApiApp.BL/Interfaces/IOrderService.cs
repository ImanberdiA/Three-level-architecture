using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiApp.BL.DataTO;

namespace WebApiApp.BL.Interfaces
{
    public interface IOrderService
    {        
        IEnumerable<PersonDTO> GetAll();        

        void Create(PersonDTO item);

        void Update(PersonDTO item);

        void Delete(int id);

        PersonDTO Get(int? id);

        void Dispose();
    }
}
