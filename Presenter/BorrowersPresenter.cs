using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ManagementSystem.Model;
using ManagementSystem.View;
namespace ManagementSystem.Presenter
{
    public class BorrowersPresenter
    {

        //Fields

        private IBorrowerView View;
        private IBorrowerRepisotory repisotory;
        private BindingSource borrowersBindingSource;
        private IEnumerable<BorrowerModel> borrowerList;
        //Constructor
        public BorrowersPresenter(IBorrowerView view, IBorrowerRepisotory repisotory)
        {
            borrowersBindingSource = new BindingSource();
            View = view;
            this.repisotory = repisotory;

            //Subscribe Event Handler

            view.SearchEvent += SearchBorrower;
            view.AddEvent += AddNewBorrower;
            view.EditEvent += EditBorrower;
            view.DeleteEvent += DeleteBorrower;
            view.CancelEvent += CancelBorrower;
            view.SaveEvent += SaveBorrower;

            //Set Borrowers Bind Source
            view.SetBorrowerListBindingSource(borrowersBindingSource);
            //load borrower view
            LoadBorrowerList();
            //Show
            view.Show();
        }

        private void LoadBorrowerList()
        {
            borrowerList = repisotory.GetAll();
            borrowersBindingSource.DataSource = borrowerList;
        }

        private void SearchBorrower(object sender, EventArgs e)
        {
            bool emptyValue = string.IsNullOrWhiteSpace(this.View.SearchValue);
            if (emptyValue == false)
                borrowerList = repisotory.GetByValue(this.View.SearchValue);
            else borrowerList = repisotory.GetAll();
            borrowersBindingSource.DataSource = borrowerList;
        }

        private void SaveBorrower(object sender, EventArgs e)
        {
            var savemodel = new BorrowerModel();
            //savemodel.Id = Convert.ToInt32(View.Id);
            savemodel.Firstname = View.Firstname;
            savemodel.Middlename = View.Middlename;
            savemodel.Lastname = View.Lastname;
            savemodel.Contact = View.Contact;
            savemodel.Address = View.Address;
            savemodel.Email = View.Email;
            savemodel.Taxid = View.Tax_id;
            savemodel.DateCreated = View.Date_created;

           

            try
            {
                new Common.ModelDataValidation().Validate(savemodel);
                if (View.IsEdit)
                {
                    repisotory.Edit(savemodel);
                    View.Message = "Borrower edited successfully";
                }///edit model
                else//Add Model
                {
                   repisotory.Add(savemodel);
                    View.Message = "Borrower Added Successfully";
                }
                View.IsSuccessful = true;
                LoadBorrowerList();
                CleanViewFields();
            }
            catch(Exception ex)
            {
                View.IsSuccessful = false;
                View.Message = ex.Message;
            }
          

        }

        private void CleanViewFields()
        {
            View.Id = "0";
            View.Firstname = "";
            View.Middlename = "";
            View.Lastname = "";
            View.Contact = "";
            View.Address = "";
            View.Email = "";
            View.Tax_id = "";
            View.Date_created = "";
           
        }

        private void CancelBorrower(object sender, EventArgs e)
        {
            CleanViewFields (); 
        }

        private void DeleteBorrower(object sender, EventArgs e)
        {
            try
            {
                var borrower = (BorrowerModel)borrowersBindingSource.Current;
                repisotory.Delete(borrower.Id);
                View.Message = "Deleted Successfully";
                LoadBorrowerList();
            }
            catch (Exception ex)
            {

                View.IsSuccessful= false; View.Message = "error Occured, Could Not Delete Borrower";
            }
        }

        private void EditBorrower(object sender, EventArgs e)
        {
            var borrower = (BorrowerModel)borrowersBindingSource.Current;
            View.Id= borrower.Id.ToString();
            View.Firstname = borrower.Firstname;
            View.Middlename = borrower.Middlename;
            View.Lastname = borrower.Lastname;
            View.Contact = borrower.Contact;
            View.Address = borrower.Address;
            View.Email = borrower.Email;
            View.Tax_id = borrower.Taxid;
            View.Date_created = borrower.DateCreated;
            View.IsEdit = true;

        }

        private void AddNewBorrower(object sender, EventArgs e)
        {
            View.IsEdit = false;
        }


    }
}
