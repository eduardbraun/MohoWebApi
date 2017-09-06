using System;
using System.Collections.Generic;

namespace ApiMoho.Models
{
    public partial class AspNetUsers
    {
        public AspNetUsers()
        {
            AspNetUserClaims = new HashSet<AspNetUserClaims>();
            AspNetUserLogins = new HashSet<AspNetUserLogins>();
            AspNetUserRoles = new HashSet<AspNetUserRoles>();
            AspNetUserTokens = new HashSet<AspNetUserTokens>();
            UserListings = new HashSet<UserListings>();
            UserReviewReviewOwnerRef = new HashSet<UserReview>();
            UserReviewUserRef = new HashSet<UserReview>();
        }

        public string Id { get; set; }
        public int AccessFailedCount { get; set; }
        public string ConcurrencyStamp { get; set; }
        public string Contract { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public DateTime JobTitle { get; set; }
        public DateTime JoinDate { get; set; }
        public bool LockoutEnabled { get; set; }
        public DateTimeOffset? LockoutEnd { get; set; }
        public string NormalizedEmail { get; set; }
        public string NormalizedUserName { get; set; }
        public string PasswordHash { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public string SecurityStamp { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public byte[] AvatarImage { get; set; }
        public string Age { get; set; }
        public bool? IsPremium { get; set; }
        public string Location { get; set; }
        public string Sex { get; set; }
        public int UpVote { get; set; }

        public ICollection<AspNetUserClaims> AspNetUserClaims { get; set; }
        public ICollection<AspNetUserLogins> AspNetUserLogins { get; set; }
        public ICollection<AspNetUserRoles> AspNetUserRoles { get; set; }
        public ICollection<AspNetUserTokens> AspNetUserTokens { get; set; }
        public ICollection<UserListings> UserListings { get; set; }
        public ICollection<UserReview> UserReviewReviewOwnerRef { get; set; }
        public ICollection<UserReview> UserReviewUserRef { get; set; }
    }
}
