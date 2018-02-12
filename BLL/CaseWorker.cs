using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace FormManager.Domain
{
    public class CaseWorker
    {
        public int Id { get; set; }

        public ICollection<Form> Forms { get; set; }

        public string Name { get; set; }
        public string Location { get; set; }
    }
}