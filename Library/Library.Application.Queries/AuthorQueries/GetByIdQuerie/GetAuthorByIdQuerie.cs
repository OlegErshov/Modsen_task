using MediatR;


namespace Library.Application.Queries.AuthorQueries.GetByIdQuerie
{
    public class GetAuthorByIdQuerie : IRequest<AuthorDTO>
    {
        public Guid id { get; set; }
    }
}
