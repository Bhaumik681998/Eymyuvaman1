using System.ComponentModel.DataAnnotations;

namespace Eymyuvaman.ViewModel.EvantDetails
{
    public class AddUpdateEvantDetialVM
    {
        public int EDetailId { get; set; }
        [Required]
        public int EvantId { get; set; }
        [Required]
        public string? FieldTitle { get; set; }
        [Required]
        public string? FiledType { get; set; }
        [Required]
        public string? SequenceNo { get; set; }
        public string? DefaultValue { get; set; }
    }
}
