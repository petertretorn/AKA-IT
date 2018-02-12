
using System;

namespace FormManager.Domain
{
    public class UnemployedForm : Form
    {
        public DateTime DateUnemployed { get; set; }
        public Employer PreviousEmployer { get; set; }
    }
}
