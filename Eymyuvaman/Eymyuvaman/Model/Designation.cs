using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eymyuvaman.Model
{
    public class Designation
    {
        [Key]
        public int DesigID { get; set; }
        [Column("Designation")]
        public string? DesignationName { get; set; }
        public int Indexof { get; set; }
    }
}
