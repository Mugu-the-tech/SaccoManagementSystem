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
    public class LoanPlanPresenter  
    {
        //fields

        private IplanView View;
        private IPlanRepository PlanRepository;
        private BindingSource loanPlanBindingSource;
        private IEnumerable<LoanPlanModel> LoanPlanList;

        public LoanPlanPresenter(IplanView view, IPlanRepository planRepository)
        {
            View = view;
            PlanRepository = planRepository;
            loanPlanBindingSource = new BindingSource();


            //Subscribe Event Handler

            
            view.AddEvent += AddNewPlan;
            view.EditEvent += EditPlan;
            view.DeleteEvent += DeletePlan;
            view.CancelEvent += CancelPlan;
            view.SaveEvent += SavePlan;

            //Set LoanPlan Bind Source
            view.SetPlanListBindingSource(loanPlanBindingSource);
            //load LoanPlan view
            LoadLoanList();
            //Show
            view.Show();
        }

        private void SavePlan(object sender, EventArgs e)
        {
            try
            {
                var saveplan = new LoanPlanModel();

                saveplan.Months = Convert.ToInt32(View.Months);
                saveplan.Interest_percentage = View.Interest;
                saveplan.Penalty_rate = Convert.ToInt32(View.Rates);

                try
                {
                    new Common.ModelDataValidation().Validate(saveplan);
                    if (View.IsEdit)
                    {
                        PlanRepository.Edit(saveplan);
                        View.Message = "Plan edited successfully";
                    }///edit model
                    else//Add Model
                    {
                        PlanRepository.Add(saveplan);
                        View.Message = "Plan Added Successfully";
                    }
                    View.IsSuccessful = true;
                    LoadLoanList();
                    CleanViewFields();
                }
                catch (Exception ex)
                {
                    View.IsSuccessful = false;
                    View.Message = ex.Message;
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Error Cannnot Save Plan");
            }
           
        }

        private void CleanViewFields()
        {
            View.Id = "0";
            View.Months = "0";
            View.Interest = "";
            View.Rates = "0";
           
        }

        private void CancelPlan(object sender, EventArgs e)
        {
            CleanViewFields();
        }

        private void DeletePlan(object sender, EventArgs e)
        {
            try
            {
                var plan = (LoanPlanModel)loanPlanBindingSource.Current;
                PlanRepository.Delete(plan.Id);
                View.Message = "Deleted Successfully";
                LoadLoanList();
            }
            catch (Exception ex)
            {

                View.IsSuccessful = false; View.Message = "error Occured, Could Not Delete Plan";
            }
        }

        private void EditPlan(object sender, EventArgs e)
        {
            var plan = (LoanPlanModel)loanPlanBindingSource.Current;
            View.Id = plan.Id.ToString();
            View.Months = plan.Months.ToString();
            View.Interest =plan.Interest_percentage;
            View.Rates = plan.Penalty_rate.ToString();
            View.IsEdit = true;
        }

        private void AddNewPlan(object sender, EventArgs e)
        {
            View.IsEdit = false;
        }

        private void LoadLoanList()
        {
            LoanPlanList = PlanRepository.GetAll();
            loanPlanBindingSource.DataSource = LoanPlanList;
        }
    }
}
