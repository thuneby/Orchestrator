using Core.Models;
using FileHelpers;
// ReSharper disable InconsistentNaming

namespace ExternalModels.MasterCard.OsInfoFormat
{
    [FixedLengthRecord]//(FixedMode.AllowMoreChars)]
    public class OsBase : TextModelBase
    {
        [FieldFixedLength(2)] public string SYSTEMKODE;
        [FieldFixedLength(1)] public string RECORDTYPE;
    }
}
