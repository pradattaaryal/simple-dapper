using Library.Service;
using MediatR;

namespace Library.CQRS.CommandHandler.AuthorCommandHandler
{
    public class AuthorCommandHandler : IRequestHandler<CreateAuthorCommand, bool>,IRequestHandler<UpdateAuthorCommand, bool>
    {
        private readonly  IAuthorService _authorService;
        public AuthorCommandHandler(IAuthorService authorService) {
            _authorService= authorService;
        }

        public async Task<bool> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
        {
            return await _authorService.AddAuthorAsync(request.author);
        }
       public async Task<bool> Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
        {
            return await _authorService.AddAuthorAsync(request.author);
        }
      
        // baki handler haru pani banau
        //nai query handler haru AuthorQueryHandler bhitra banau hai
    }
}
