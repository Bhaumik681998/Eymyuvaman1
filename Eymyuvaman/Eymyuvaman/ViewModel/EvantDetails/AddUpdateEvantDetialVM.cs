using System.ComponentModel.DataAnnotations;

namespace Eymyuvaman.ViewModel.EventDetails
{
    public class AddUpdateEventDetialVM
    {
        public int EDetailId { get; set; }
        [Required]
        public int EventId { get; set; }
        [Required]
        public string? FieldTitle { get; set; }
        [Required]
        public string? FiledType { get; set; }
        [Required]
        public int SequenceNo { get; set; }
        public string? DefaultValue { get; set; }
    }
}
