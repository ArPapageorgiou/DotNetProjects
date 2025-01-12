using DemoLibrary.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLibrary.Queries
{
    public record GetPersonByIdQuery(int id) : IRequest<PersonModel>;

    //if we were to use a class instead of a record this is how it would be implemented:

    //public class GetPersonByIdQueryClass : IRequest<PersonModel>
    //{
    //    public int _id { get; set; }

    //    public GetPersonByIdQueryClass(int id)
    //    {
    //        _id = id;
    //    }
    //}

}
