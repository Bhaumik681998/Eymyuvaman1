using System.ComponentModel.DataAnnotations;

namespace Eymyuvaman.ViewModel.EventDetails
{
    public class AddUpdateEventEntryLogVM
    {
        public int Id { get; set; }
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
        [Required]
        public DateTime UpdatedDate { get; set; }
        [Required]
        public string? EntryType { get; set; }
    }
}
