using Library.Model;
using MediatR;
namespace Library.CQRS.CommandHandler.AuthorCommandHandler
{
    public class CreateAuthorCommand :IRequest<bool>
    {
        public Author author { get; set; }
    }
    public class UpdateAuthorCommand: IRequest<bool>
    {
        public Author author { get; set; }
    }
    public class DeletAuthorCommand: IRequest<bool>
    {
        public int Id { get; set; } 
    }
}
