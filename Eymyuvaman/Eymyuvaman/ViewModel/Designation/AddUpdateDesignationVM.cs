using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eymyuvaman.ViewModel.Designation
{
    public class AddUpdateDesignationVM
    {
        public int DesigID { get; set; }
        [Required]
        public string? Designation { get; set; }
        public int Indexof { get; set; }
    }
}
