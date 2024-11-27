using DemoLibrary.Models;
using MediatR;

namespace DemoLibrary.Queries
{
    // We use records because they are immutable, meaning they cannot be changed.
    //the record implements IRequest<List<PersonModel>>. This marks this as a request
    //while the List<PersonModel> is the out/response.
    public record GetPersonListQuery() : IRequest<List<PersonModel>>;
}
