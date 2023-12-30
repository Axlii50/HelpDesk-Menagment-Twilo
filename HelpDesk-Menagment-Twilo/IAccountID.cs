using HelpDesk_Menagment_Twilo.Models.DataBase;
using System.ComponentModel.DataAnnotations;

namespace HelpDesk_Menagment_Twilo
{
    public interface IAccountID
    {
        [Required]
        public string AccountID { get; set; }

        [Required]
        public PermissionsTypes Permissions { get; set; }
    }
}
