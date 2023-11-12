using System;
using System.Collections.Generic;

namespace WarOfRightsWeb.Models
{
    public enum CompanyRank
    {
        Reserve,
        Private,
        Corporal,
        Sergeant,
        FirstSergeant,
        Lieutenant,
        FirstLieutenant,
        Captain

    }

    public record CompanyMembers
    {
        public List<CompanyMember> Members { get; set; }
    }

    public record CompanyMember
    {
        // Updated from Discord

        public ulong Id { get; init; }

        public string DisplayName { get; init; }

        public string Nickname { get; init; }

        public bool IsBot { get; init; }

        public string Username { get; init; }

        public DateTimeOffset CreatedAt { get; init; }

        public DateTimeOffset JoinedAt { get; init; }

        public string Status { get; init; }

        public List<CompanyRole> Roles { get; init; }


        // Updated automatically

        public DateTimeOffset LastActiveAt { get; init; }

        public CompanyRank Rank { get; init; }
    }
}
