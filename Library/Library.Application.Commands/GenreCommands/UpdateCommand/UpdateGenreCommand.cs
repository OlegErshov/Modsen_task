using MediatR;


namespace Library.Application.Commands.GenreCommands.UpdateCommand
{
    public class UpdateGenreCommand : IRequest<Unit>
    {
        public UpdateGenreDTO updateGenreDTO { get; set; }
    }
}
