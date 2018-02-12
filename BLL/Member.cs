using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace FormManager.Domain
{
    public class Member
    {
        public int Id { get; set; }

        public ICollection<Form> Forms { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Cpr { get; set; }
        public Gender Gender { get; set; }

        public IList<MemberInfo> MemberInfo { get; set; }
    }
}