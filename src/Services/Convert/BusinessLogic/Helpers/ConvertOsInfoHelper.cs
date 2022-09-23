using Core.CoreModels;
using Core.DomainModels;
using ExternalModels.MasterCard.OsInfoModel;

namespace Convert.BusinessLogic.Helpers
{
    public static class ConvertOsInfoHelper
    {
        public static Payment GetPayment(Guid fileId, OsInfoSectionStart infoSectionStart)
        {
            var payment = new Payment
            {
                DocumentId = fileId,
                DocumentType = DocumentType.NetsOsInfo,
                ReconcileStatus = ReconcileStatus.Open,
                InformationType = GetInformationType(infoSectionStart.INFOTYPE),
                Cvr = infoSectionStart.CVRNUMMERAFSENDER,
                DataProviderNumber = infoSectionStart.DATALEVERANDORNUMMER,
                DueDate = DateHelper.GetDate6N(infoSectionStart.DISPOSITIONSDATO),
                PaymentDate = DateHelper.GetDate6N(infoSectionStart.DISPOSITIONSDATO),
                TotalAmount = DecimalHelper.GetAmountWithDecimals(infoSectionStart.OsSectionEnd.FirstOrDefault()?.BELOB ?? string.Empty),
                RoutingNumber = infoSectionStart.REGISTRERINGSNUMMER,
                AccountNumber = infoSectionStart.KONTONUMMER,
                PbsNumberRecepient = infoSectionStart.PBSNUMMERMODTAGER,
                Valid = false
            };
            var infoRecords = infoSectionStart.OsRecord00Collection;
            foreach (var infoRecord00 in infoRecords)
            {
                var paymentDetail = GetPaymentDetail(infoRecord00, payment.Cvr);
                if (paymentDetail == null)
                    continue;
                payment.PaymentDetails.Add(paymentDetail);
            }
            return payment;
        }

        private static PaymentDetail? GetPaymentDetail(OsInfoRecord00 infoRecord00, string cvr)
        {
            try
            {
                var paymentDetail = new ExtendedPaymentDetail
                {
                    Amount = DecimalHelper.AdjustSign(DecimalHelper.GetAmountWithDecimals(infoRecord00.INDBETALT_BELOB), infoRecord00.FORTEGN),
                    Cpr = infoRecord00.CPR_NUMMER ?? string.Empty,
                    Cvr = cvr,
                    SequenceNumber = TextHelper.GetInt(infoRecord00.SEKVENSNUMMER),
                    LaborAgreementNumber = infoRecord00.OVERENSKOMSTNUMMER.Trim(),
                    FromDate = DateHelper.GetDate8DK(infoRecord00.PERIODE_FRA),
                    ToDate = DateHelper.GetDate8DK(infoRecord00.PERIODE_TIL),
                    CustomerNumberSender = infoRecord00.KUNDENUMMER_AFSENDER.Trim(),
                    CustumerNumberRecepient = infoRecord00.KUNDENUMMER_MODTAGER.Trim()
                };
                if (infoRecord00.OsRecord01Collection.Any())
                {
                    paymentDetail = AddRecord01Fields(infoRecord00.OsRecord01Collection.First(), paymentDetail);
                }
                // ToDo and so forth...
                return paymentDetail;
            }
            catch
            {
                return null;
            }
        }

        private static ExtendedPaymentDetail AddRecord01Fields(OsInfoRecord01 textRecord, ExtendedPaymentDetail paymentDetail)
        {
            if (TextHelper.IsNumeric(textRecord.STARTDATO_KUNDE))
            {
                // ToDo
            }
            paymentDetail.PersonName = textRecord.KUNDENAVN?.TrimEnd() ?? string.Empty;
            if (TextHelper.IsNumeric(textRecord.FRATRAEDELSESDATO))
            {
                paymentDetail.EmploymentTerminationDate = DateHelper.GetDate8DK(textRecord.FRATRAEDELSESDATO);
            }
            paymentDetail.SalaryTerms = SalaryTermsHelper.GetTerms(textRecord.AFLONNINGSFORM);
            // ToDo Etc...
            return paymentDetail;
        }

        private static InformationType GetInformationType(string infoType)
        {
            if (string.IsNullOrEmpty(infoType))
                return InformationType.Unknown;
            var success = int.TryParse(infoType, out var infoTypeInt);
            if (!success) return InformationType.Unknown;
            return infoTypeInt switch
            {
                100 => InformationType.PensionAndInsurance,
                150 => InformationType.LaborMarketPension,
                200 => InformationType.LaborUnions,
                400 => InformationType.VacationPayments,
                800 => InformationType.AtpAndMaternity,
                900 => InformationType.TaxPayments,
                _ => InformationType.Unknown
            };
        }
    }
}
