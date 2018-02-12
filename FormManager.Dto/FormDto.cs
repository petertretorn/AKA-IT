using System;

namespace FormManager.Dto
{
    public class FormDto
    {
        public int Id { get; set; }
        public string ProcessedBy { get; set; }
        public string Member { get; set; }
        public bool IsProcessed { get; set; }
        public string DateSubmitted { get; set; }
        public string DateProcessed { get; set; }
    }
}
