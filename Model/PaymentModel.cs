using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
namespace ManagementSystem.Model
{
    public class PaymentModel
    {
        //Fields
        private int id;
        private int loan_id;
        private string payee;
        private string amount;
        private string penalty_amount;
        private int overdue;
        private string date_created;
        //properties
        public int Id { get => id; set => id = value; }

        [DisplayName("Loan ID")]
        public int Loan_id { get => loan_id; set => loan_id = value; }

        [DisplayName("Payee Name")]
        [Required(ErrorMessage = " Payers Name is Required ")]
        public string Payee { get => payee; set => payee = value; }

        [DisplayName("Loan Amount")]
        [Required(ErrorMessage = " Payers  is Required ")]
        public string Amount { get => amount; set => amount = value; }

        [DisplayName("Loan Penalty")]
        public string Penalty_amount { get => penalty_amount; set => penalty_amount = value; }

        [DisplayName("Loan Overdue")]
        public int Overdue { get => overdue; set => overdue = value; }

        [DisplayName("Date Created")]
        public string Date_created { get => date_created; set => date_created = value; }
    }
}
