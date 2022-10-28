using LoginAuthMicroServices.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LoginAuthMicroServices.Entity
{
    [Table("user")]
    public class User : IEntity
    {
        [Column("id")]
        [Key]
        public int Id { get; set; }
        [Column("user_name")]
        public string UserName { get; set; }
        [Column("password_salt")]
        public byte[] PasswordSalt { get; set; }
        [Column("password_hash")]
        public byte[] PasswordHash { get; set; }
    }
}
