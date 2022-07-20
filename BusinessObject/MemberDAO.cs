using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessObject
{
    public class MemberDAO
    {
        private static MemberDAO instance = null;
        private static readonly object instanceLock = new();
        public static MemberDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new MemberDAO();
                    }

                    return instance;
                }
            }
        }

        public IEnumerable<Member> GetMembers()
        {
            try
            {
                using FStore2Context context = new();

                return context.Members.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Member GetMember(int memberId)
        {
            try
            {
                using FStore2Context context = new();

                var member = context.Members.Find(memberId);

                if (member == null)
                {
                    throw new Exception("Not found.");
                }

                return member;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void AddMember(Member member)
        {
            try
            {
                using FStore2Context context = new();

                if (context.Members.Any(m => m.MemberId == member.MemberId))
                {
                    throw new Exception("Already exists.");
                }

                context.Members.Add(member);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void UpdateMember(Member member)
        {
            try
            {
                using FStore2Context context = new();

                if (context.Members.Any(m => m.MemberId == member.MemberId))
                {
                    throw new Exception("Not exists.");
                }

                context.Members.Update(member);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void DeleteMember(int memberId)
        {
            try
            {
                using FStore2Context context = new();

                var member = GetMember(memberId);

                if (context.Members.Any(m => m.MemberId == member.MemberId))
                {
                    throw new Exception("Not exists.");
                }

                context.Members.Remove(member);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
