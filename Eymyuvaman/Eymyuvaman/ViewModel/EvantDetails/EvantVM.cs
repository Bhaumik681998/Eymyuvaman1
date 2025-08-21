using System.ComponentModel.DataAnnotations.Schema;

namespace Eymyuvaman.ViewModel.EventDetails
{
    public class EventVM
    {
        public int EventId { get; set; }
        public string? EventName { get; set; }
        public int Active { get; set; }
    }
}
