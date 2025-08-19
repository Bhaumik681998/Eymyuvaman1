using System.ComponentModel.DataAnnotations;

namespace Eymyuvaman.Model.Evant
{
    public class EvantDetial
    {
        [Key]
        public int EDetailId { get; set; }
        public int EvantId { get; set; }
        public string? FieldTitle { get; set; }
        public string? FiledType { get; set; }
        public string? SequenceNo { get; set; }
        public string? DefaultValue { get; set; }
    }
}
