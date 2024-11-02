using System.ComponentModel.DataAnnotations;

namespace heilbrigt_workplace_backend_v01.EntityFramework.Models.User
{
    public class User
    {
        public int UserId { get; set; } = 0;

        [StringLength(50)]
        public string userFirstName { get; set; } = string.Empty;

        [StringLength(50)]
        public string userLastName { get; set; } = string.Empty;

        [StringLength(125)]
        public string userMail { get; set; } = string.Empty;

        [StringLength(17)]
        public string userInternalId { get; set; } = string.Empty; 

        public DateTime userAddDate { get; set; } = DateTime.Now;

        public bool userIsActiveated { get; set; } = false;

        [StringLength(350)]
        public string userPasswordHash { get; set; } = string.Empty;

        [StringLength(500)]
        public string userSessionId { get; set; } = string.Empty;
    }
}
