using Core.CoreModels;
using Core.DomainModels;
using DataAccess.DataAccess;
using FluentAssertions;
using Utilities.Dates;
using Validate.BusinessLogic;

namespace ServiceTests.Validate
{
    public class PaymentValidatorTests
    {
        private static readonly Guid DocumentId = Guid.NewGuid(); 
        private readonly PaymentValidator _paymentValidator;
        private readonly Payment _payment1 = new()
        {
            DocumentId = DocumentId,
            DocumentType = DocumentType.NetsOsInfo,
            TotalAmount = 14789.77M,
            PbsNumberRecepient = "12345678",
            DueDate = DateUtil.GetNextBusinessDay(DateTime.Today)
        };

        private readonly Payment _payment2 = new()
        {
            DocumentId = DocumentId,
            DocumentType = DocumentType.NetsOsInfo,
            TotalAmount = 15789.76M,
            PbsNumberRecepient = "",
            DueDate = DateUtil.GetNextBusinessDay(DateTime.Today)
        };

        private readonly Payment _payment3 = new()
        {
            DocumentId = DocumentId,
            DocumentType = DocumentType.NetsOsInfo,
            TotalAmount = 162809.12M,
            PbsNumberRecepient = "12345678",
            DueDate = DateTime.MinValue
        };


        public PaymentValidatorTests()
        {
            _paymentValidator = new PaymentValidator(new MasterDataRepository());
        }

        [Fact]
        public void ValidateEmptyList()
        {
            // Arrange
            var paymentList = new List<Payment>();

            // Act
            var result = _paymentValidator.ValidatePayments(paymentList, DocumentType.NetsOsInfo);

            // Assert
            result.Should().BeEmpty();
        }

        [Fact]
        public void ValidateValidList()
        {
            // Arrange
            var paymentList = new List<Payment>{_payment1};

            // Act
            var result = _paymentValidator.ValidatePayments(paymentList, DocumentType.NetsOsInfo).ToList();

            // Assert
            result.Should().NotBeEmpty();
            result.Count.Should().Be(1);
            result.First().Valid.Should().BeTrue();
            result.First().ValidationErrors.Should().BeEmpty();
        }

        [Fact]
        public void ValidateMixedList()
        {
            // Arrange
            var paymentList = new List<Payment> { _payment1 , _payment2, _payment3};

            // Act
            var result = _paymentValidator.ValidatePayments(paymentList, DocumentType.NetsOsInfo).ToList();

            // Assert
            result.Should().NotBeEmpty();
            result.Count.Should().Be(3);
            var valid = result.Where(x => x.Valid).ToList();
            valid.Should().NotBeEmpty();
            var invalid = result.Where(x => !x.Valid).ToList();
            invalid.Should().NotBeEmpty();
            invalid.Count.Should().Be(2);
        }
    }
}
