using DataAccess.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
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

        public static bool Login(string email, string password)
        {
            {
                IConfiguration configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();

                string AdEmail = configuration["Admin:Email"];
                string AdPassword = configuration["Admin:Password"];

                if (email == AdEmail && password == AdPassword)
                {
                    return true;
                }

                return false;
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

#nullable enable
        public Member GetMember(int? memberId, string? email, string? password)
        {
            try
            {
                using FStore2Context context = new();

                Member member = null!;

                if (memberId != null)
                {
                    member = context.Members.Find(memberId);
                }

                if (email != null && password != null)
                {
                    member = context.Members.FirstOrDefault(m => m.Email == email && m.Password == password)!;
                }

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

                var member = GetMember(memberId,null,null);

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
