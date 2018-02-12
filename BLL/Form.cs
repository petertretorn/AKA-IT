
using System;

namespace FormManager.Domain
{
    public class Form
    {
        public int Id { get; set; }
        public CaseWorker CaseWorker { get; set; }
        public Member Member { get; set; }
        public bool IsProcessed { get; set; }
        public DateTime DateSubmitted { get; set; }
        public DateTime DateProcessed { get; set; }
    }
}