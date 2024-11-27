using DemoLibrary.DataAccess;
using DemoLibrary.Models;
using DemoLibrary.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLibrary.Handlers
{
    //IRequestHandler defines a handler. GetPersonListQuery is the query it is going to
    //handle while List<PersonModel> is the output which is optional. We then implement
    //this interface so that the Handle() method is added.
    public class GetPersonListhandler : IRequestHandler<GetPersonListQuery, List<PersonModel>>
    {
        private readonly IDataAccess _data;

        public GetPersonListhandler(IDataAccess data)
        {
            _data = data;
        }

        //Implementing the IRequestHandler will add the Handle method with the appropriate
        //request parameter as well as a CancellationToken parameter. The cancelation token
        //needs to be passed to any asynchronous method called within the method in order to
        //honor the cancelation. 
        public Task<List<PersonModel>> Handle(GetPersonListQuery request, CancellationToken cancellationToken)
        {
            //Task.FromResult is typically used to wrap a synchronous result in a Task so that
            //it can be returned from an asynchronous method.

            //it is not truly asynchronous. Since _data.GetPeople() executes synchronously,
            //the operation blocks the calling thread until the data is retrieved. However,
            //the method signature requires returning a Task<List<PersonModel>>,
            //and Task.FromResult satisfies that requirement without introducing unnecessary
            //overhead.
            return Task.FromResult(_data.GetPeople());
        }
    }
}
