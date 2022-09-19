using Core.Models;
using DocumentAccess.DocumentAccessLayer;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Parse.Controllers;
using PersistanceTest.Common;

namespace ServiceTests.Parse
{
    public class ParseControllerTests: TestBase
    {
        private const string ParseFolder = "Parse"; 
        private DocumentRepository _documentRepository;
        private ParseController _controller;

        private new void Initialize()
        {
            base.Initialize();
            _documentRepository = new DocumentRepository(DocumentContext, TestLoggerFactory.CreateLogger<DocumentRepository>());
            _controller = new ParseController(_documentRepository, new TestStorageHelper(TestStorageContext, TestLoggerFactory), TestLoggerFactory);
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
            var osInfoRecord = _documentRepository.GetOsInfo(result);

            // Assert
            result.Should().NotBe(Guid.Empty);
            osInfoRecord.Should().NotBeNull();

        }

        private async Task<Guid> UploadDocument()
        {
            const string fileName = "Eksempel på OsInfo.txt";
            var fileStream = await TestUtil.GetFileStream(fileName, ParseFolder);
            var storageHelper = new TestStorageHelper(TestStorageContext, TestLoggerFactory);
            var id = await storageHelper.UploadFile(fileStream, fileName, DocumentType.NetsOsInfo);
            return id;
        }
    }
}
