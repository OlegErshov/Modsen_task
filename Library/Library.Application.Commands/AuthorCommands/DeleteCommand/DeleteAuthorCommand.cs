using MediatR;


namespace Library.Application.Commands.AuthorCommands.DeleteCommand
{
    public class DeleteAuthorCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
