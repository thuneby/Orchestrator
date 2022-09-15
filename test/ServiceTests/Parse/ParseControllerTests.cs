using Core.Models;
using FluentAssertions;
using Parse.Controllers;
using PersistanceTest.Common;

namespace ServiceTests.Parse
{
    public class ParseControllerTests: TestBase
    {
        private const string parseFolder = "Parse";
        private ParseController _controller;

        private new void Initialize()
        {
            base.Initialize();
            _controller = new ParseController(DocumentContext, new TestStorageHelper(TestStorageContext, TestLoggerFactory), TestLoggerFactory);
        }

        [Fact]
        public async void ParseOsInfo()
        {
            Initialize();
            // Arrange
            var id = await UploadDocument();
            var tenantId = 0;

            // Act
            var result = await _controller.ParseFromGuid(id, DocumentType.NetsOsInfo, tenantId);
            var infoRecord = DocumentContext.OsInfoStart.FirstOrDefault();

            // Assert
            result.Should().NotBe(Guid.Empty);
            infoRecord.Should().NotBeNull();

        }

        private async Task<Guid> UploadDocument()
        {
            var fileName = "Eksempel på OsInfo.txt";
            var fileStream = await TestUtil.GetFileStream(fileName, parseFolder);
            var storageHelper = new TestStorageHelper(TestStorageContext, TestLoggerFactory);
            var id = await storageHelper.UploadFile(fileStream, fileName, DocumentType.NetsOsInfo);
            return id;
        }
    }
}
