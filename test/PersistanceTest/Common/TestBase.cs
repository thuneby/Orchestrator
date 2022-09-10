using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Logging;
using PersistanceTest.TestStorage;

namespace PersistanceTest.Common
{
    public class TestBase
    {
        protected OrchestratorContext Context;
        protected TestStorageContext TestStorageContext; 
        protected ILoggerFactory TestLoggerFactory;


        protected void Initialize()
        {
            Context = TestBase.InitializeContext();
            TestStorageContext = InitializeTestStorageContext();
            TestLoggerFactory = TestBase.InitializeLoggerFactory();
        }

        public static OrchestratorContext InitializeContext()
        {
            var options = new DbContextOptionsBuilder<OrchestratorContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .ConfigureWarnings(b => b.Ignore(InMemoryEventId.TransactionIgnoredWarning))
                .Options;
            var context = new OrchestratorContext(options);
            return context;
        }

        public static TestStorageContext InitializeTestStorageContext()
        {
            var options = new DbContextOptionsBuilder<TestStorageContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning))
                .Options;

            var context = new TestStorageContext(options);
            return context;
        }

        public static ILoggerFactory InitializeLoggerFactory()
        {
            var loggerFactory = new LoggerFactory();
            return loggerFactory;
        }

        public static void TestCleanup()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    }
}
