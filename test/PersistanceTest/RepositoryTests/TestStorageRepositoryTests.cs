using Core.CoreModels;
using PersistanceTest.Common;

namespace PersistanceTest.RepositoryTests
{
    public class TestStorageRepositoryTests: TestBase 
    {

        private new void Initialize()
        {
            base.Initialize();

        }

        [Fact]
        public async void ReadFile()
        {
            // Arrange
            Initialize();
            var fileName = "Eksempel på OsInfo.txt";
            var fileStream = await TestUtil.GetFileStream(fileName, "Parse");
            var storageHelper = new TestStorageHelper(TestStorageContext, TestLoggerFactory);
            await storageHelper.UploadFile(fileStream, fileName, DocumentType.NetsOsInfo);

            // Act
            var fileList = await storageHelper.GetFileList();

            // Assert
            Assert.NotEmpty(fileList);

            // CleanUp
        }
    }
}
