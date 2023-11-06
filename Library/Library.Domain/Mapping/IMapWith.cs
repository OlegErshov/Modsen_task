using AutoMapper;

namespace Library.Domain.Mapping
{
    public interface IMapWith<T>
    {
        void Mapping(Profile profile) => profile.CreateMap(typeof(T),GetType());
    }
}
