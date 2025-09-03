using DTO_Clean_Architecture.Core.Entities;

namespace DTO_Clean_Architecture.Infrastructure.DbMapper
{
    public interface IDbMapper<TDomainObject,TDbObject>
        where TDomainObject : IDomainObject
        where TDbObject : class
    {
        TDbObject ToDbObject(TDomainObject domainObject);
        TDomainObject ToDomainObject(TDbObject dbObject);
    }
}
