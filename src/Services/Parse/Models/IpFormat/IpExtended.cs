﻿using Core.CoreModels;
using FileHelpers;

namespace Parse.Models.IpFormat
{
    [FixedLengthRecord]
    public class IpExtended : TextModelBase
    {
        [FieldFixedLength(3)]
        public string Pensionsselskabskode;
        [FieldFixedLength(2)]
        public string Indberetningstype;
        [FieldFixedLength(5)]
        public string AfsendersKundenr;
        [FieldFixedLength(8)]
        public string DatoForDannelse;
        [FieldFixedLength(8)]
        public string Cvr;
        [FieldFixedLength(10)]
        public string Cpr;
        [FieldFixedLength(34)]
        public string Navn;
        [FieldFixedLength(8)]
        public string PeriodeStart;
        [FieldFixedLength(8)]
        public string PeriodeSlut;
        [FieldFixedLength(8)]
        public string Pensionsbidrag;
        [FieldFixedLength(1)]
        public string Fortegn;
        [FieldFixedLength(3)]
        public string Bidragskode;
        [FieldFixedLength(4)]
        public string SamletBidragsProcent;
        [FieldFixedLength(8)]
        public string DatoForBidragsProcent;
        [FieldFixedLength(5)]
        public string OverenskomstKode;
        [FieldFixedLength(8)]
        public string DatoForAfvigelse;
        [FieldFixedLength(2)]
        public string AfvigelsesKode;
        [FieldFixedLength(12)]
        public string PensionsgivendeLoen;
    }
}
