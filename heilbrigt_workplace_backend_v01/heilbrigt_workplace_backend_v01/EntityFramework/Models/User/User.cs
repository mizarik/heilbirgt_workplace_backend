using System.ComponentModel.DataAnnotations;

namespace heilbrigt_workplace_backend_v01.EntityFramework.Models.User
{
    public class User
    {
        public int UserId { get; set; } = 0;

        [StringLength(50)]
        public string FirstName { get; set; } = string.Empty;

        [StringLength(50)]
        public string LastName { get; set; } = string.Empty;

        [StringLength(125)]
        public string Mail { get; set; } = string.Empty;

        public DateTime SignUpDate { get; set; } = DateTime.Now;

        public bool IsActiveated { get; set; } = false;

        [StringLength(350)]
        public string PasswordHash { get; set; } = string.Empty;

        [StringLength(500)]
        public string SessionId { get; set; } = string.Empty;
    }
}
