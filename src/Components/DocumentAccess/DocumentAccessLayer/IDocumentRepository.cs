using ExternalModels.MasterCard.Bs601Model;
using ExternalModels.MasterCard.OsInfoModel;

namespace DocumentAccess.DocumentAccessLayer
{
    public interface IDocumentRepository
    {
        Task SaveModel(FlatOsInfoModel model);
        Task SaveModel(FlatNetsBs601Model model);

        OsInfoStart? GetOsInfo(Guid id);

        Task<bool> OsInfoExists(Guid id);
    }
}
