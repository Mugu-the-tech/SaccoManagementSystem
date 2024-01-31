using ManagementSystem.Model;
using ManagementSystem.Repositories;
using ManagementSystem.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagementSystem.Presenter
{
   public class LoanPresenter
    {
        private ILoanView loanView;
        private ILoanRepository repository;
        private BindingSource loansBindingSource;
        private BindingSource TypeBindingSource;
        private BindingSource planBindingsource;
        private BindingSource BorrowerBindingSource;
        private IEnumerable<LoansModel> LoanLists;

        public LoanPresenter(ILoanView loanView, ILoanRepository repository)
        {
            this.loanView = loanView;
            this.repository = repository;
            loansBindingSource = new BindingSource();
            TypeBindingSource = new BindingSource();
            planBindingsource = new BindingSource();
            BorrowerBindingSource = new BindingSource();

            //Events

            loanView.SaveLoan += SaveLoanEvent;
            loanView.EditLoan += EditLoanEvent;
            loanView.CancelLoan += CancleLoanEvent;
            loanView.CalculateLoan += CalculateLoanEvent;
            loanView.SearchLoan += SearchLoanEvent;
            loanView.DeleteLoan += DeleteLoanEvent;
            loanView.AddLoan += AddLoanEvent;

            //set binding source

            loanView.SetBorrowersBindingSource(BorrowerBindingSource);
            loanView.SetLoanPlanBindingSource(planBindingsource);
            loanView.SetLoansBindingSource(loansBindingSource);
            loanView.SetLoanTypeBindingSource(TypeBindingSource);

            //load data
            LoadLoansView();
            LoadBorrowerView();
            LoadTypeView();
            LoadPlanView();

        }

        private void AddLoanEvent(object sender, EventArgs e)
        {
            loanView.IsEdit = false;
        }

        private void DeleteLoanEvent(object sender, EventArgs e)
        {
            try
            {
                var delete = (LoansModel)loansBindingSource.Current;
                repository.Delete(delete.Id);
                loanView.Message = "Deleted Successfully";
                LoadLoansView();

            }
            catch (Exception)
            {

               loanView.IsSuccessful = false;
                loanView.Message = "Unable to delete Loan";
            }
        }

        private void SearchLoanEvent(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void CalculateLoanEvent(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void CancleLoanEvent(object sender, EventArgs e)
        {
            CleanViewFields();
        }

        private void EditLoanEvent(object sender, EventArgs e)
        {
            var EditLoan = (LoansModel)loansBindingSource.Current;

            loanView.ref_no = EditLoan.Ref_no;
            loanView.loant_type_id = EditLoan.Loan_type_id.ToString();
            loanView.borrower_id = EditLoan.Borrower_id;
            loanView.purpose = EditLoan.Purpose;
            loanView.amount = EditLoan.Amount;
            loanView.plan_id = EditLoan.Plan_id.ToString() ;
            loanView.status = EditLoan.Status;
            loanView.date_released = EditLoan.Date_released;

            loanView.IsEdit = true;

        }

        private void SaveLoanEvent(object sender, EventArgs e)
        {
            var loansSave = new LoansModel();

            try
            {
                loansSave.Ref_no = loanView.ref_no;

                if (int.TryParse(loanView.loant_type_id, out int loanTypeId))
                    loansSave.Loan_type_id = loanTypeId;
                else
                    throw new ArgumentException("Invalid loan type ID");

                loansSave.Borrower_id = loanView.borrower_id;
                loansSave.Purpose = loanView.purpose;
                loansSave.Amount = loanView.amount;

                if (int.TryParse(loanView.plan_id, out int planId))
                    loansSave.Plan_id = planId;
                else
                    throw new ArgumentException("Invalid plan ID");

                loansSave.Status = loanView.status;
                loansSave.Date_released = loanView.date_released;
                loansSave.Date_created = loanView.date_created;

                try
                {
                    new Common.ModelDataValidation().Validate(loansSave);

                    if (loanView.IsEdit)
                    {
                        repository.Edit(loansSave);
                        loanView.Message = "Loan edited successfully";
                    }
                    else
                    {
                        repository.Add(loansSave);
                        loanView.Message = "Loan Added Successfully";
                    }
                    loanView.IsSuccessful = true;
                    LoadLoansView();
                    CleanViewFields();
                }
                catch (Exception ex)
                {
                    loanView.IsSuccessful = false;
                    loanView.Message = ex.Message;
                }
            }
            catch (Exception)
            {
                // Handle the exception appropriately
                // MessageBox.Show("Cannot Save Loan: Internal Error");
            }
        }


        private void CleanViewFields()
        {
           
        }

        private void LoadPlanView()
        {
            LoanLists = repository.GetLoanPlans();
            planBindingsource.DataSource= LoanLists;
        }

        private void LoadTypeView()
        {
            LoanLists = repository.GetLoanType();
            TypeBindingSource.DataSource = LoanLists;
        }

        private void LoadBorrowerView()
        {
           LoanLists = repository.GetBorrowers();
            BorrowerBindingSource.DataSource = LoanLists;
        }

        private void LoadLoansView()
        {
            LoanLists = repository.GetAll();
            loansBindingSource.DataSource = LoanLists;
        }
    }
}
