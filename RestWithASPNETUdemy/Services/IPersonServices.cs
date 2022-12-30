using Microsoft.AspNetCore.Mvc;
using RestWithASPNETUdemy.Model;

namespace RestWithASPNETUdemy.Services 
{
    public interface IPersonServices //Deveria ser Service
    {
        Person Create(Person person);
        Person FindById(long id);
        List<Person> FindAll();
        Person Update(Person person);
        void Delete(long id);
    }
}