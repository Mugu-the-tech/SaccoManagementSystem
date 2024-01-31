using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ManagementSystem.Model
{
    public class LoanTypeModel
    {
        private int id;
        private string type_name;
        private string description;

        [DisplayName("#")]

        public int Id { get => id; set => id = value; }

        [DisplayName("Loan Type")]
        [Required (ErrorMessage ="Loan Type is Required")]
        public string Type_name { get => type_name; set => type_name = value; }

        [DisplayName("Loan Description")]
        [Required(ErrorMessage = "Loan Description is Required")]
        public string Description { get => description; set => description = value; }
    }
}
