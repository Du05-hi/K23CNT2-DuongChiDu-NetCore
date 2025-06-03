namespace dcdLab07.Models
{
    public class DcdEmployee
    {
        public int DcdId { get; set; }
        public string DcdName { get; set; }
        public DateTime DcdBirthDay { get; set; }
        public string DcdEmail { get; set; }
        public string DcdPhone { get; set; }
 
        public decimal DcdSalary { get; set; }
        public bool DcdStatus { get; set; }
    }
}
