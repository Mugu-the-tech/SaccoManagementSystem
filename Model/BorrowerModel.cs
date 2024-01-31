using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem.Model
{
    public class BorrowerModel
    {
        private int id;
        private string firstname;
        private string middlename;
        private string lastname;
        private string contact;
        private string address;
        private string email;
        private string taxid;
        private string dateCreated;


        [DisplayName("Borrower ID")]
        [Required(ErrorMessage = "ID is Required")]
        public int Id { get => id; set => id = value; }

        [DisplayName("Borrower First Name")]
        [Required(ErrorMessage = "First Name is Required")]

        public string Firstname { get => firstname; set => firstname = value; }
        [DisplayName("Borrower Middle Name")]
        [Required(ErrorMessage = "Middle Name is Required")]

        public string Middlename { get => middlename; set => middlename = value; }

        [DisplayName("Borrower Last  Name")]
        [Required(ErrorMessage = "Last Name is Required")]
        public string Lastname { get => lastname; set => lastname = value; }

        [DisplayName("Borrower contacts")]
        [Required(ErrorMessage = "Contact  is Required")]
        public string Contact { get => contact; set => contact = value; }

        [DisplayName("Borrower Address")]
        [Required(ErrorMessage = "Address is Required")]
        public string Address { get => address; set => address = value; }

        [DisplayName("Borrower Email")]
        [Required(ErrorMessage = "Email is Required")]
        public string Email { get => email; set => email = value; }

        [DisplayName("Borrower Country ID")]
        [Required(ErrorMessage = "Country ID is Required")]
        public string Taxid { get => taxid; set => taxid = value; }

        [DisplayName("Date Created")]
    
        public string DateCreated { get => dateCreated; set => dateCreated = value; }
    }
}
