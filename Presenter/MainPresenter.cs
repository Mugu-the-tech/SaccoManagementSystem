using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManagementSystem.Model;
using ManagementSystem.View;
using ManagementSystem.Repositories;
using System.Windows.Forms;
namespace ManagementSystem.Presenter
{
   public class MainPresenter: Main
    {
        private IMainView mainView;
        private readonly string connectionString;
        //private Main main;

        public MainPresenter(IMainView mainView, string connectionString)
        {
            this.mainView = mainView;
            this.connectionString = connectionString;
            this.mainView.ShowBorrowerView += ShowBorrowersView;
            this.mainView.ShowLoanPlanView += ShowLoansPlanView;
            this.mainView.ShowLoanTypeView += ShowLoanTypesView;
            this.mainView.ShowMembersView += ShowMemberView;
            this.mainView.ShowSavingsView += ShowSavingView;
            this.mainView.ShowLoansView += ShowLoanView;
            
        }

        private void ShowLoanView(object sender, EventArgs e)
        {
            if (mainView != null && mainView is Main mainPanel)
            {
                ILoanView loanView = Loans.GetInstance(mainPanel);
                if(loanView != null)
                {
                    ILoanRepository repository = new LoanRepository(connectionString);
                    new LoanPresenter (loanView, repository);
                    mainPanel.OpenChildForm(loanView as Form);
                }
            }
        }

        private void ShowSavingView(object sender, EventArgs e)
        {
            if (mainView != null && mainView is Main mainPanel)
            {
                ISavingsView view = Savings.GetInstance(mainPanel);
                if (view != null)
                {
                    ISavingsRepository repisotory = new SavingsRepository(connectionString);
                    new SavingsPresenter(view, repisotory);
                    mainPanel.OpenChildForm(view as Form);
                }
            }
        }

        private void ShowMemberView(object sender, EventArgs e)
        {
            if (mainView != null && mainView is Main mainPanel)
            {
                IMemberView view = Members.GetInstance(mainPanel);
                if (view != null)
                {
                    IMemberRepository repisotory = new MembersRepository(connectionString);
                    new MemberPresenter(view, repisotory);
                    mainPanel.OpenChildForm(view as Form);
                }
            }
        }

        private void ShowLoanTypesView(object sender, EventArgs e)
        {
            if (mainView != null && mainView is Main mainPanel)
            {
                ITypeView view = LoanType.GetInstance(mainPanel);
                if (view != null)
                {
                    ITypeRepository repisotory = new LoanTypeRepository(connectionString);
                    new LoanTypePresenter(view, repisotory);
                    mainPanel.OpenChildForm(view as Form);
                }
            }
        }

        private void ShowLoansPlanView(object sender, EventArgs e)
        {
            if (mainView != null && mainView is Main mainPanel)
            {
                IplanView view = LoanPlan.GetInstance(mainPanel);
                if (view != null)
                {
                    IPlanRepository repisotory = new LoanPlanRepisotory(connectionString);
                    new LoanPlanPresenter(view, repisotory);
                    mainPanel.OpenChildForm(view as Form);
                }
            }
        }

        private void ShowBorrowersView(object sender, EventArgs e)
        {
            if (mainView != null && mainView is Main mainPanel)
            {
                IBorrowerView view = Borrowers.GetInstance(mainPanel);
                if (view != null)
                {
                    IBorrowerRepisotory repisotory = new BorrowerRepository(connectionString);
                    new BorrowersPresenter(view, repisotory);
                    mainPanel.OpenChildForm(view as Form);
                }
            }
        }
    }
}
