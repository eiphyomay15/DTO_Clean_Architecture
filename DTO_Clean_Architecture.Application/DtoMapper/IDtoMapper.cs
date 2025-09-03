namespace DTO_Clean_Architecture.Application.DtoMapper
{
    public interface IDtoMapper<TDto, TDomain>
        where TDto : Dtos.IDto
        where TDomain : Core.Entities.IDomainObject
    {
        TDomain ToDomainObject(TDto dto);
        TDto ToDto(TDomain domainObject);
    }
}
