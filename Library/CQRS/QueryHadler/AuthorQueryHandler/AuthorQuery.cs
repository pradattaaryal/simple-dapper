using Library.Model;
using MediatR;

namespace Library.CQRS.QueryHadler.AuthorQueryHandler
{
    public class GetAuthorQuery : IRequest<IEnumerable<Author>>
    {
       
    }
    public class GetByIdAuthorQuery : IRequest<Author>
    {
        public int Id { get; set; } 
    }
}
