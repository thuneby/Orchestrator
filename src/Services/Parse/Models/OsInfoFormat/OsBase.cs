using Core.CoreModels;
using FileHelpers;

// ReSharper disable InconsistentNaming

namespace Parse.Models.OsInfoFormat
{
    [FixedLengthRecord]//(FixedMode.AllowMoreChars)]
    public class OsBase : TextModelBase
    {
        [FieldFixedLength(2)] public string SYSTEMKODE;
        [FieldFixedLength(1)] public string RECORDTYPE;
    }
}
