using MediatR;
 
namespace Library.Application.Commands.AuthorCommands.CreateCommand
{
    public class CreateAuthorCommand : IRequest<Unit>
    {
        public string FirstName { get;  set; }
        public string Surname { get;  set; }
    }
}
