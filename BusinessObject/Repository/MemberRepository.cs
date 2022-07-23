using BusinessObject;
using DataAccess.Models;
using System.Collections.Generic;

namespace DataAccess.Repository
{
    public class MemberRepository : IMemberRepository
    {
        public bool Login(string email, string password) => MemberDAO.Login(email, password);

        public IEnumerable<Member> GetMembers() => MemberDAO.Instance.GetMembers();

#nullable enable
        public Member GetMember(int? memberId, string? email, string? password) => MemberDAO.Instance.GetMember(memberId, email, password);

        public void InsertMember(Member member) => MemberDAO.Instance.AddMember(member);

        public void UpdateMember(Member member) => MemberDAO.Instance.UpdateMember(member);

        public void DeleteMember(int? memberId) => MemberDAO.Instance.DeleteMember(memberId);
    }
}
