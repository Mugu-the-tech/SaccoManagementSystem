using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem.Model
{
    public class LoansModel
    {
        private int id;
        private string ref_no;
        private int loan_type_id;
        private string borrower_id;
        private string purpose;
        private string amount;
        private int plan_id;
        private string status;
        private string date_released;
        private string date_created;
        private string firstname;
        private string middlename;
        private string lastname;
        private string contact;
        private int months;
        private string interest_percentage;
        private int penalty_rate;
        private string type_name;

        public  string displayText;


        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            // Concatenate borrower details
            builder.Append(borrower_id ?? "").Append(" ")
                   .Append(firstname ?? "").Append(" ")
                   .Append(middlename ?? "").Append(" ")
                   .Append(lastname ?? "").Append(" ");

            // Check if loan_type_id has a non-default value
            if (loan_type_id != 0)
                builder.Append(loan_type_id.ToString()).Append(" ");

            // Append the type_name (assuming it could be null)
            builder.Append(type_name ?? "").Append(" ");

            // Check if plan_id has a non-default value
            if (plan_id != 0)
                builder.Append(plan_id.ToString());

            displayText = builder.ToString();
            return displayText;
        }





        [DisplayName("#")]
        public int Id { get => id; set => id = value; }
        [DisplayName ("Ref No")]
        public string Ref_no { get => ref_no; set => ref_no = value; }
        [DisplayName ("Loan ID")]
        public int Loan_type_id { get => loan_type_id; set => loan_type_id = value; }
        [DisplayName ("Borrower ID")]
        public string Borrower_id { get => borrower_id; set => borrower_id = value; }
        [DisplayName ("Purpose")]
        public string Purpose { get => purpose; set => purpose = value; }
        [DisplayName("Amount(ksh)")]
        public string Amount { get => amount; set => amount = value; }
        [DisplayName("Plan")]
        public int Plan_id { get => plan_id; set => plan_id = value; }
        [DisplayName("Status")]
        public string Status { get => status; set => status = value; }
        [DisplayName("Date Released")]
        public string Date_released { get => date_released; set => date_released = value; }
        [DisplayName("Date reated")]
        public string Date_created { get => date_created; set => date_created = value; }
        [DisplayName("First Name")]
        public string Firstname { get => firstname; set => firstname = value; }
        [DisplayName("Middle Name")]
        public string Middlename { get => middlename; set => middlename = value; }
        [DisplayName("Last Name")]
        public string Lastname { get => lastname; set => lastname = value; }
        [DisplayName("Contact")]
        public string Contact { get => contact; set => contact = value; }
        [DisplayName("months")]
        public int Months { get => months; set => months = value; }
        [DisplayName("interest")]
        public string Interest_percentage { get => interest_percentage; set => interest_percentage = value; }
        [DisplayName("Penalty")]
        public int Penalty_rate { get => penalty_rate; set => penalty_rate = value; }
        [DisplayName("Type")]
        public string Type_name { get => type_name; set => type_name = value; }
    }
}
