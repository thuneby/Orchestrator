using Core.Models;
using System.ComponentModel.DataAnnotations;

namespace PersistanceTest.TestStorage
{
    public class InputFile : GuidModelBase
    {
        [StringLength(255)]
        [Display(Name = "Filnavn")]
        public string FileName { get; set; }

        [Display(Name = "Størrelse")]
        public long Size { get; set; }
        public DocumentType DocumentType { get; set; }
        public byte[] Content { get; set; }
    }
}
