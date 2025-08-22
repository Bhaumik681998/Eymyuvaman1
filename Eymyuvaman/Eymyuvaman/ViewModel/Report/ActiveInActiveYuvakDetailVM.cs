namespace Eymyuvaman.ViewModel.Report
{
    public class ActiveInActiveYuvakDetailVM
    {
        public List<ActiveYuvakDetailVM> ActiveyuvakList { get; set; } = new List<ActiveYuvakDetailVM>();
        public List<InActiveYuvakDetailVM> InActiveyuvakList { get; set; } = new List<InActiveYuvakDetailVM>();
    }

    public class ActiveYuvakDetailVM
    {
        public int KishoreId { get; set; }
        public string? KishoreName { get; set; }
        public string? FatherName { get; set; }
        public string? SureName { get; set; }
        public string? MobileNo { get; set; }
    }
    public class InActiveYuvakDetailVM
    {
        public int KishoreId { get; set; }
        public string? KishoreName { get; set; }
        public string? FatherName { get; set; }
        public string? SureName { get; set; }
        public string? MobileNo { get; set; }
    }
}
