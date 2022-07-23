using DataAccess.Models;
using System.Collections.Generic;

namespace DataAccess.Repository
{
    public interface IMemberRepository
    {
        bool Login(string email, string password);

        IEnumerable<Member> GetMembers();

#nullable enable
        Member GetMember(int? memberId, string? email, string? password);

        void InsertMember(Member member);   

        void UpdateMember(Member member);

        void DeleteMember(int? memberId);
    }
}
