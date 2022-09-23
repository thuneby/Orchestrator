using Core.CoreModels;
using DataAccess.DataAccess;
using Microsoft.Extensions.Logging;

namespace PersistanceTest.TestStorage
{
    public class TestStorageRepository : GuidRepositoryBase<InputFile>
    {
        public TestStorageRepository(TestStorageContext context, ILogger<TestStorageRepository> logger) : base(context, logger)
        {
        }

    }
}
