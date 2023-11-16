using MediatR;
 
namespace Library.Application.Commands.AuthorCommands.CreateCommand
{
    public class CreateAuthorCommand : IRequest<Unit>
    {
        public CreateAuthorDTO createAuthorDTO {  get; set; }
    }
}
