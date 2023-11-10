using MediatR;


namespace Library.Application.Commands.GenreCommands.UpdateCommand
{
    public class UpdateGenreCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

    }
}
