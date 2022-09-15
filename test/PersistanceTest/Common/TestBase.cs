using DataAccess.Models;
using DocumentAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Logging;
using PersistanceTest.TestStorage;

namespace PersistanceTest.Common
{
    public class TestBase
    {
        protected OrchestratorContext OrchestratorContext;
        protected TestStorageContext TestStorageContext;
        protected DocumentContext DocumentContext;
        protected ILoggerFactory TestLoggerFactory;


        protected void Initialize()
        {
            OrchestratorContext = InitializeOrchestratorContext();
            DocumentContext = InitializeDocumentContext();
            TestStorageContext = InitializeTestStorageContext();
            TestLoggerFactory = InitializeLoggerFactory();
        }

        public static OrchestratorContext InitializeOrchestratorContext()
        {
            var options = new DbContextOptionsBuilder<OrchestratorContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .ConfigureWarnings(b => b.Ignore(InMemoryEventId.TransactionIgnoredWarning))
                .Options;
            var context = new OrchestratorContext(options);
            return context;
        }

        public static DocumentContext InitializeDocumentContext()
        {
            var options = new DbContextOptionsBuilder<DocumentContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .ConfigureWarnings(b => b.Ignore(InMemoryEventId.TransactionIgnoredWarning))
                .Options;
            var context = new DocumentContext(options);
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
