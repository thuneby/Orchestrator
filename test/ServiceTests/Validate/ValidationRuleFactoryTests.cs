using Core.CoreModels;
using FluentAssertions;
using Validate.BusinessLogic;

namespace ServiceTests.Validate
{
    public class ValidationRuleFactoryTests
    {
        [Fact]
        public void GetPaymentRules()
        {
            // Act
            var rules = ValidationRuleFactory.GetPaymentRules(DocumentType.NetsOsInfo).ToList();

            // Assert
            rules.Count.Should().BeGreaterOrEqualTo(2);
        }
    }
}
