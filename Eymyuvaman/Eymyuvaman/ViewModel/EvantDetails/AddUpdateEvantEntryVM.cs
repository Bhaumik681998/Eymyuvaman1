using System.ComponentModel.DataAnnotations;

namespace Eymyuvaman.ViewModel.EventDetails
{
    public class AddUpdateEventEntryVM
    {
        public int EEntryId { get; set; }
        [Required]
        public int EventId { get; set; }
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
