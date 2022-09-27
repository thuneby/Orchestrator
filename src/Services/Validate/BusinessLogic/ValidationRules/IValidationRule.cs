using Core.DomainModels;
using DataAccess.DataAccess;

namespace Validate.BusinessLogic.ValidationRules
{
    public interface IValidationRule<T>
    {
        ValidationError? Validate(T entity, MasterDataRepository repository);
    }
}
