using DemoLibrary.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLibrary.Commands
{
    public record InsertPersonCommand(string FirstName, string LastName) : IRequest<PersonModel>;

    //public class InsertPersonCommandClass : IRequest<PersonModel>
    //{
    //    public string _firstName { get; set; }
    //    public string _lastName { get; set; }
    //    public InsertPersonCommandClass(string firstName, string lastName)
    //    {
    //        _firstName = firstName;
    //        _lastName = lastName;
    //    }
    //}
}
