using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography;
using System.Text;
using Task20.Entities.Base;

namespace Task20.Entities
{
    public class UserEntity : BaseEntity
    {
        [Column("Login"), Required, MaxLength(60)]
        public string Login { get; set; } = default!;


        [Column("Password_hash"), Required, MaxLength(100)]
        public string PasswordHash { get; set; } = default!;


        [Column("Password_salt"), Required, MaxLength(100)]
        public string PasswordSalt { get; set; } = default!;

        public UserRole Role { get; set; }

        public static string CreatePasswordSalt() => Guid.NewGuid().ToString("N");

        public static string CreatePasswordHash(string password, string salt)
        {
            var sha256 = SHA256.Create();
            var saltedPassword = $"{password}:{salt}";
            var buffer = Encoding.UTF8.GetBytes(saltedPassword);
            var hash = sha256.ComputeHash(buffer);
            var encodedHash = Convert.ToBase64String(hash);
            return encodedHash;
        }
    }
}
