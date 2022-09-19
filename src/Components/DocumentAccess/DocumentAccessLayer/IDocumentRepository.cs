using ExternalModels.MasterCard.OsInfoModel;

namespace DocumentAccess.DocumentAccessLayer
{
    public interface IDocumentRepository
    {
        Task SaveModel(FlatOsInfoModel model);

        OsInfoStart? GetOsInfo(Guid id);

        bool OsInfoExists(Guid id);
    }
}
