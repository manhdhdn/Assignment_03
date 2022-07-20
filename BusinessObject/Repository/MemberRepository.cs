using BusinessObject;
using DataAccess.Models;
using System.Collections.Generic;

namespace DataAccess.Repository
{
    public class MemberRepository : IMemberRepository
    {
        public IEnumerable<Member> GetMembers() => MemberDAO.Instance.GetMembers();

        public Member GetMember(int memberId) => MemberDAO.Instance.GetMember(memberId);

        public void InsertMember(Member member) => MemberDAO.Instance.AddMember(member);

        public void UpdateMember(Member member) => MemberDAO.Instance.UpdateMember(member);

        public void DeleteMember(int memberId) => MemberDAO.Instance.DeleteMember(memberId);
    }
}
