using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace FormManager.Domain
{
    public class MemberInfo
    {
        public int Id { get; set; }

        public Member Member { get; set; }

        [ForeignKey("Member")]
        public int MemberId { get; set; }

        public string Key { get; set; }
        public string Value { get; set; }
        public DateTime DateOfInfo { get; set; }
    }
}