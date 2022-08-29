using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Logging;
using Persistance.Models;

namespace PersistanceTest.Common
{
    public class TestBase
    {
        protected OrchestratorContext Context;
        protected ILoggerFactory LoggerFactory;

        public TestBase()
        {
            Context = TestBase.InitializeContext();
            LoggerFactory = TestBase.InitializeLoggerFactory();
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
