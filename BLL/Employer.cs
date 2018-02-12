using System.ComponentModel.DataAnnotations.Schema;

namespace FormManager.Domain
{
    public class Employer
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        public string Address { get; set; }
        public string CVR { get; set; }
    }
}