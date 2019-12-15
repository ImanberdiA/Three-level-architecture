using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiApp.BL.DataTO;
using WebApiApp.BL.Interfaces;
using WebApiApp.BL.Settings;
using WebApiApp.DL.Interfaces;
using WebApiApp.DL.Models;

namespace WebApiApp.BL.Services
{
    public class PersonService : IOrderService
    {
        IUnitOfWork Database { get; set; }

        public PersonService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public void Create(PersonDTO item)
        {
            Database.Persons.Create(new Person {
                IIN = item.IIN,
                FirstName = item.FirstName,
                LastName = item.LastName,
                BirthDate = item.BirthDate
            });
        }

        public void Delete(int id)
        {
            Database.Persons.Delete(id);
        }

        public void Dispose()
        {
            Database.Dispose();
        }

        public PersonDTO Get(int? id)
        {
            if (id == null)
            {
                throw new ValidException("Укажите id", "");
            }

            Person person = Database.Persons.Get(id.Value);

            if(person == null)
            {
                throw new ValidException("Пользователь с таким id не найден", "");
            }

            return new PersonDTO {
                IIN = person.IIN,
                FirstName = person.FirstName,
                LastName = person.LastName,
                BirthDate = person.BirthDate };
        }

        public IEnumerable<PersonDTO> GetAll()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Person, PersonDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Person>, List<PersonDTO>>(Database.Persons.GetAll());
        }

        public void Update(PersonDTO item)
        {
            Person person = Database.Persons.Find(p => p.IIN == item.IIN).FirstOrDefault();

            person.IIN = item.IIN;
            person.FirstName = item.FirstName;
            person.LastName = item.LastName;
            person.BirthDate = item.BirthDate;

            Database.Persons.Update(person);
        }
    }
}
