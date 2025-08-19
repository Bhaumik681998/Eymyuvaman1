namespace Eymyuvaman.ViewModel.EvantDetails
{
    public class EventEntryLogDetailVM
    {
        public int Id { get; set; }
        public int EvantId { get; set; }
        public int EDetailId { get; set; }
        public long KishorId { get; set; }
        public string? Value { get; set; }
        public int Completed { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string? EntryType { get; set; }
    }
}
