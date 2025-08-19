using System.ComponentModel.DataAnnotations;

namespace Eymyuvaman.ViewModel.EvantDetails
{
    public class AddUpdateEvantEntryVM
    {
        public int EEntryId { get; set; }
        [Required]
        public int EvantId { get; set; }
        [Required]
        public int EDetailId { get; set; }
        [Required]
        public long KishorId { get; set; }
        [Required]
        public string? Value { get; set; }
        [Required]
        public int Completed { get; set; }
    }
}
