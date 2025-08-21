namespace Eymyuvaman.ViewModel.EventDetails
{
    public class EventEntryDetailVM
    {
        public int EEntryId { get; set; }
        public int EventId { get; set; }
        public string? EventName { get; set; }
        public int EDetailId { get; set; }
        public string? FieldTitle { get; set; }
        public string? FieldType { get; set; }
        public long KishorId { get; set; }
        public string? KishoreName { get; set; }
        public string? Value { get; set; }
        public int Completed { get; set; }
    }
}
