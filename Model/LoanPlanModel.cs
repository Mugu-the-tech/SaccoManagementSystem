using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ManagementSystem.Model
{
    public class LoanPlanModel
    {
        //Declare Fields
        private int id;
        private int months;
        private string interest_percentage;
        private int penalty_rate;
        //Properties

        [DisplayName("#")]
        public int Id { get => id; set => id = value; }
        [DisplayName("Years/Months")]
        [Required (ErrorMessage ="Loan Months Needed")]
        public int Months { get => months; set => months = value; }

        [DisplayName("Interest %")]
        [Required(ErrorMessage = "Interest is Required")]
        public string Interest_percentage { get => interest_percentage; set => interest_percentage = value; }

        [DisplayName("Overdue Penalty %")]
        [Required(ErrorMessage = "Penalty Rate is Needed")]
        public int Penalty_rate { get => penalty_rate; set => penalty_rate = value; }
    }
}
