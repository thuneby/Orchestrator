using DataAccess.DataAccess;
using Microsoft.Extensions.Logging;

namespace PersistanceTest.TestStorage
{
    public class TestStorageRepository : GuidRepositoryBase<InputFile>
    {
        public TestStorageRepository(TestStorageContext context, ILoggerFactory loggerFactory) : base(context, loggerFactory)
        {
        }

    }
}
