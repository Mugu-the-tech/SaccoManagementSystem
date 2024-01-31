using ManagementSystem.Model;
using ManagementSystem.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagementSystem.Presenter
{
   public class MemberPresenter
    {
        //fields

        private IMemberView memberView;
        private IMemberRepository memberRepository;
        private BindingSource MembersBindingSource;
        private IEnumerable<MembersModel> membersList;

        public MemberPresenter(IMemberView memberView, IMemberRepository memberRepository)
        {
            MembersBindingSource = new BindingSource();
            this.memberView = memberView;
            this.memberRepository = memberRepository;

            //Subscribe Event Handler

            memberView.SearchEvent += SearchMember;
            memberView.AddEvent += AddMember;
            memberView.EditEvent += EditMember;
            memberView.DeleteEvent += DeleteMember;
            memberView.CancelEvent += CancelMember;
            memberView.SaveEvent += SaveMember;

            //set Binding Source
            memberView.SetMemberBindingSource(MembersBindingSource);
            //load the view of datagrid

            LoadMemberListView();

            memberView.Show();

        }

        private void SaveMember(object sender, EventArgs e)
        {
            var SaveMember = new MembersModel();
            try
            {
                SaveMember.Id = Convert.ToInt32(memberView.Member_ID);
                SaveMember.Member_Name = memberView.Member_Name;
                SaveMember.Contact = Convert.ToInt32(memberView.Contact);
                SaveMember.Gender = memberView.Member_Gender;
                SaveMember.Position = memberView.Position;
                SaveMember.Next_of_kin = memberView.Next_of_Kin;
                SaveMember.Status = memberView.Member_Status;


                try
                {
                    new Common.ModelDataValidation().Validate(SaveMember);
                    if (memberView.IsEdit)
                    {
                        memberRepository.Edit(SaveMember);
                        memberView.Message = "Member edited successfully";
                    }///edit model
                    else//Add Model
                    {
                        memberRepository.Add(SaveMember);
                        memberView.Message = "Member Added Successfully";
                    }
                    memberView.IsSuccessful = true;
                    LoadMemberListView();
                    CleanViewFields();
                }
                catch (Exception ex)
                {
                    memberView.IsSuccessful = false;
                    memberView.Message = ex.Message;
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Cannot Save Member: Internal Error");
            }
           

        }

        private void CleanViewFields()
        {
            memberView.Member_ID = "0";
            memberView.Contact = "0";
            memberView.Member_Name = "";
            memberView.Member_Gender = "";
            memberView.Member_Status = "";
            memberView.Next_of_Kin = "";
            memberView.Position = "";
        }

        private void CancelMember(object sender, EventArgs e)
        {
            CleanViewFields();
        }

        private void DeleteMember(object sender, EventArgs e)
        {
            try
            {
                var member = (MembersModel)MembersBindingSource.Current;
                memberRepository.Delete(member.Id);
                memberView.Message = "Deleted Successfully";
                LoadMemberListView();
            }
            catch (Exception ex)
            {

                memberView.IsSuccessful = false; memberView.Message = "error Occured, Could Not Delete Member";
            }
        }

        private void EditMember(object sender, EventArgs e)
        {
            var member = (MembersModel)MembersBindingSource.Current;

            memberView.Member_ID = member.Id.ToString();
            memberView.Member_Name = member.Member_Name;
            memberView.Contact = member.Contact.ToString();
            memberView.Member_Gender = member.Gender;
            memberView.Position = member.Position;
            memberView.Next_of_Kin = member.Next_of_kin;
            memberView.Member_Status = member.Status;

            memberView.IsEdit = true;
        }

        private void AddMember(object sender, EventArgs e)
        {
            memberView.IsEdit = false;
        }

        private void SearchMember(object sender, EventArgs e)
        {
            bool emptyValue = string.IsNullOrWhiteSpace(this.memberView.SearchValue);
            if (emptyValue == false)
                membersList = memberRepository.GetByValue(this.memberView.SearchValue);
            else membersList =memberRepository.GetAll();
            MembersBindingSource.DataSource = membersList;
        }

        private void LoadMemberListView()
        {
            membersList = memberRepository.GetAll();
            MembersBindingSource.DataSource = membersList;

        }

        
    }
}
