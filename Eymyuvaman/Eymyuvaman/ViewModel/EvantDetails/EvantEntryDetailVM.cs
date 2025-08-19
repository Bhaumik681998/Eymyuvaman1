namespace Eymyuvaman.ViewModel.EvantDetails
{
    public class EvantEntryDetailVM
    {
        public int EEntryId { get; set; }
        public int EvantId { get; set; }
        public string? EvantName { get; set; }
        public int EDetailId { get; set; }
        public string? FieldTitle { get; set; }
        public string? FieldType { get; set; }
        public long KishorId { get; set; }
        public string? KishoreName { get; set; }
        public string? Value { get; set; }
        public int Completed { get; set; }
    }
}
