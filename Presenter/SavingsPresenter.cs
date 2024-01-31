using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ManagementSystem.Model;
using ManagementSystem.Repositories;
using ManagementSystem.View;

namespace ManagementSystem.Presenter
{
    public class SavingsPresenter
    {
        private ISavingsView savingsView;
        private ISavingsRepository savingsRepository;
        private BindingSource SavingsBindingSource;
        private IEnumerable<SavingsModel> SavingsList;
        private BindingSource MemberListSource;
        private SavingsModel savings;


        public SavingsPresenter(ISavingsView savingsView, ISavingsRepository savingsRepository)
        {
            this.savingsView = savingsView;
            this.savingsRepository = savingsRepository;
            SavingsBindingSource = new BindingSource();
            MemberListSource = new BindingSource();
            this.savings = new SavingsModel();

            //events

            savingsView.AddSavings += AddSaving;
            savingsView.EditSavings += EditSaving;
            savingsView.CancelSavings += CancelSave;
            savingsView.DeleteSavings += DeleteSaving;
            savingsView.CalculateSavings += CalculateSaving;
            savingsView.SaveSavings += SaveSaving;

            //set binding source
            savingsView.SetSavingsListBindingSource(SavingsBindingSource);
            savingsView.SetDropDownBindingSource(MemberListSource);

            //load the data

            LoadMemberListView();

            LoadSavingsListView();
        }

        private void SaveSaving(object sender, EventArgs e)
        {
            var Savings = new SavingsModel();

            try
            {
                Savings.Members_id = Convert.ToInt32(savingsView.MemberID);
                Savings.Members_name = savingsView.MemberName;
                string currentSavingsString = savingsView.CurrentSavings;

                //monthly
                float monthlySavings;
                if (float.TryParse(savingsView.MonthlySavings, out monthlySavings))
                {
                    Savings.Monthly_savings = monthlySavings;
                }

                float currentSavings;
                if (float.TryParse(savingsView.CurrentSavings, out currentSavings))
                {
                    Savings.Current_savings = currentSavings;
                }
                //monthly

                float totalSavings;
                if (float.TryParse(savingsView.TotalSavings, out totalSavings))
                {
                    Savings.Total_savings = totalSavings;
                }


                try
                {
                    new Common.ModelDataValidation().Validate(Savings);
                    if (savingsView.IsEdit)
                    {
                        savingsRepository.Edit(Savings);
                        savingsView.Message = "Member edited successfully";
                    }///edit model
                    else//Add Model
                    {
                        savingsRepository.Add(Savings);
                        savingsView.Message = "Member Savings Added Successfully";
                    }
                    savingsView.IsSuccessful = true;
                    LoadSavingsListView();
                    CleanViewFields();
                }
                catch (Exception ex)
                {
                    savingsView.IsSuccessful = false;
                    savingsView.Message = ex.Message;
                }

            }
            catch (Exception)
            {

                MessageBox.Show("Cannot Save Member Savings: Internal Error");
            }
        }

        private void CalculateSaving(object sender, EventArgs e)
        {
            try
            {
                var currentSavings = float.Parse(savingsView.CurrentSavings);
                var monthlySavings = float.Parse(savingsView.MonthlySavings);

                // Calculate total savings
                var totalSavings = currentSavings + monthlySavings;

                // Update the Total_savings property in the SavingsModel
                savings.Total_savings = totalSavings;

                // Optionally, update the view with the calculated total savings
                savingsView.TotalSavings = totalSavings.ToString("F2"); // Assuming a string representation is used in the view

                // Check if the calculated total savings is greater than the original current savings
                if (totalSavings > currentSavings)
                {
                    // If yes, update the Current_savings to be the same as Total_savings
                    savings.Current_savings = totalSavings;
                    savingsView.CurrentSavings = totalSavings.ToString("F2"); // Update the view as well
                }

                // Inform the user or update UI as needed
                savingsView.Message = "Total savings calculated successfully";
                savingsView.IsSuccessful = true;
            }
            catch (Exception ex)
            {
                // Handle parsing or calculation errors
                savingsView.IsSuccessful = false;
                savingsView.Message = "Error calculating total savings: " + ex.Message;
            }
        }



        private void DeleteSaving(object sender, EventArgs e)
        {
            try
            {
                var saving = (SavingsModel)SavingsBindingSource.Current;
                savingsRepository.Delete(saving.Id);
                savingsView.Message = "Deleted Successful";
                LoadSavingsListView();
            }
            catch (Exception)
            {

                savingsView.IsSuccessful = false;
                savingsView.Message = "Cannot Delete member Savings";
            }

        }

        private void CancelSave(object sender, EventArgs e)
        {
           CleanViewFields();
        }

        private void EditSaving(object sender, EventArgs e)
        {
           var saving = (SavingsModel) SavingsBindingSource.Current;

            savingsView.id = saving.Id.ToString();
            savingsView.MemberName = saving.Members_name;
            savingsView.MemberID = saving.Members_id.ToString();
            savingsView.MonthlySavings= saving.Monthly_savings.ToString();
            savingsView.TotalSavings=saving.Total_savings.ToString();
            savingsView.CurrentSavings = saving.Current_savings.ToString();
            
            savingsView.IsEdit= true;
            try
            {

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void AddSaving(object sender, EventArgs e)
        {
            savingsView.IsEdit = false;
        }

        private void CleanViewFields()
        {
            savingsView.MemberID = "0";
            savingsView.MemberName = "0";
            savingsView.MonthlySavings = "0";
            savingsView.CurrentSavings = "0";
            savingsView.TotalSavings = "0";
            savingsView.MemberID = "0";
        }

        private void LoadMemberListView()
        {
        
            SavingsList = savingsRepository.GetMembers();
            MemberListSource.DataSource = SavingsList;
        }

        private void LoadSavingsListView()
        {
            SavingsList = savingsRepository.GetAll();
            SavingsBindingSource.DataSource = SavingsList;
        }
    }
}
