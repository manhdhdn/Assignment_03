using DataAccess.Models;
using System.Collections.Generic;

namespace DataAccess.Repository
{
    public interface IMemberRepository
    {
        bool Login(string email, string password);

        IEnumerable<Member> GetMembers();

        Member GetMember(int? memberId);

        void InsertMember(Member member);   

        void UpdateMember(Member member);

        void DeleteMember(int? memberId);
    }
}
