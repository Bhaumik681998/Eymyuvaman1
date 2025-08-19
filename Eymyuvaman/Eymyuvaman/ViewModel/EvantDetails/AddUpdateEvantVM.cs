using System.ComponentModel.DataAnnotations;

namespace Eymyuvaman.ViewModel.EvantDetails
{
    public class AddUpdateEvantVM
    {
        public int EvantId { get; set; }
        [Required]
        public string? EvantName { get; set; }
        [Required]
        public int Active { get; set; }
    }
}
