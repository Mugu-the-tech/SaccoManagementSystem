using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
namespace ManagementSystem.Model
{
    public class MembersModel
    {
        private int members_id;
        private string members_name;
        private int contact;
        private string gender;
        private string position;
        private string next_of_kin;
        private string status;

        [DisplayName ("Member ID")]
        [Required (ErrorMessage ="Members ID is Required")]
        public int Id { get =>members_id; set => members_id = value; }

        [DisplayName("Member Name")]
        [Required(ErrorMessage = "Members Name is Required")]
        public string Member_Name { get => members_name; set => members_name = value; }

        [DisplayName("Member Contact Detail")]
        [Required(ErrorMessage = "Members Contact is Required")]
        public int Contact { get => contact; set => contact = value; }

        [DisplayName("Member Gender")]
        [Required(ErrorMessage = "Members Gender is Required")]
        public string Gender { get => gender; set => gender = value; }

        [DisplayName("Member Position")]
        [Required(ErrorMessage = "Members Position is Required")]
        public string Position { get => position; set => position = value; }

        [DisplayName("Member Next of Kin")]
        [Required(ErrorMessage = "Members Next of Kin is Required")]
        public string Next_of_kin { get => next_of_kin; set => next_of_kin = value; }

        [DisplayName("Member Status")]
        [Required(ErrorMessage = "Members Status is Required")]
        public string Status { get => status; set => status = value; }
    }
}
