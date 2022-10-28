using LoginAuthMicroServices.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LoginAuthMicroServices.Entity
{
    [Table("user_claim")]
    public class UserClaim : IEntity
    {
        [Column("id")]
        [Key]
        public int Id { get; set; }
        [Column("user_id")]
        public int UserId { get; set; }
        [Column("claim_id")]
        public int ClaimId { get; set; }
    }
}
