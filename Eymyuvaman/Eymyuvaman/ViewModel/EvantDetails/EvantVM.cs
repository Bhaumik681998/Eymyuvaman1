using System.ComponentModel.DataAnnotations.Schema;

namespace Eymyuvaman.ViewModel.EvantDetails
{
    public class EvantVM
    {
        public int EvantId { get; set; }
        public string? EvantName { get; set; }
        public int Active { get; set; }
    }
}
