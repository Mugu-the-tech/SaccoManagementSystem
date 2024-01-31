using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManagementSystem.Model;
using ManagementSystem.Repositories;
using ManagementSystem.View;
using System.Windows.Forms;
using System.Security.AccessControl;

namespace ManagementSystem.Presenter
{


    public class LoanTypePresenter
    {

        private ITypeView View;
        private ITypeRepository TypeRepository;
        private BindingSource TypeBindingSource;
        private IEnumerable<LoanTypeModel> LoanTypeList;

        public LoanTypePresenter(ITypeView view, ITypeRepository typeRepository)
        {
            TypeBindingSource = new BindingSource();
            View = view;
            TypeRepository = typeRepository;

            //events
            view.Addevent += AddEvent;
            view.EditEvent += EditType;
            view.CancelEvent += CancelType;
            view.DeleteEvent += DeleteType;
            view.SaveEvent += SaveType;


            view.SetLoanTypeBindingSource(TypeBindingSource);
            //Load theview
            LoadLoanList();

        }

        private void SaveType(object sender, EventArgs e)
        {
            try
            {
                var saveType = new LoanTypeModel();

                ///saveType.Id = Convert.ToInt32(View.Id);
                saveType.Type_name = View.Type_Name;
                saveType.Description = View.Type_Description;

                try
                {
                    new Common.ModelDataValidation().Validate(saveType);
                    if (View.IsEdit)
                    {
                        TypeRepository.Edit(saveType);
                        View.Message = "Plan edited successfully";
                    }///edit model
                    else//Add Model
                    {
                        TypeRepository.Add(saveType);
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

                 MessageBox.Show("Error Cannnot Save type");
                
            }
        }

        private void DeleteType(object sender, EventArgs e)
        {
            try
            {
                var type = (LoanTypeModel)TypeBindingSource.Current;
                TypeRepository.Delete(type.Id);
                View.Message = "Successfully deleted Type";
                LoadLoanList();

            }
            catch (Exception)
            {

                View.IsSuccessful = false; View.Message = "error Occured, Could Not Delete Plan";
            }
        }

        private void CancelType(object sender, EventArgs e)
        {
           CleanViewFields();
        }

        private void EditType(object sender, EventArgs e)
        {
            var type = (LoanTypeModel)TypeBindingSource.Current;
            View.Id = type.Id.ToString();
            View.Type_Description= type.Description;
            View.Type_Name = type.Type_name;
            View.IsEdit = true;

        }

        private void AddEvent(object sender, EventArgs e)
        {
            View.IsEdit = false;
        }

        private void CleanViewFields()
        {
            View.Id = "0";
            View.Type_Description = "";
            View.Type_Name = "";
        }

        private void LoadLoanList()
        {
            LoanTypeList = TypeRepository.GetAll();
            TypeBindingSource.DataSource = LoanTypeList;
        }
    }
}
