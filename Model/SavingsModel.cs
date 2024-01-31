using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ManagementSystem.Model
{
    public class SavingsModel
    {
        private int id;
        private int members_id;
        private string members_name;
        private float monthly_savings;
        private float total_savings;
        private float current_savings;

        public override string ToString()
        {
            return Members_name;
        }

        public int Id { get => id; set => id = value; }
        [DisplayName ("Member ID")]
        [Required (ErrorMessage ="Required")]
        public int Members_id { get => members_id; set => members_id = value; }
        [DisplayName("Member Name")]
        [Required (ErrorMessage ="Member's Name is Required")]
        public string Members_name { get => members_name; set => members_name = value; }

        [DisplayName ("Monthly Savings")]
        [Required(ErrorMessage ="Monthly Savings Required")]
        public float Monthly_savings { get => monthly_savings; set => monthly_savings = value; }

        [DisplayName("Current Savings")]
        public float Current_savings { get => current_savings; set => current_savings = value; }

        [DisplayName ("Total Savings")]
        public float Total_savings { get => total_savings; set => total_savings = value; }
       
    }
}
