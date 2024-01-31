using ManagementSystem.Model;
using ManagementSystem.View;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem.Repositories
{
    public class LoanRepository : BaseRepository, ILoanRepository
    {
        public LoanRepository(string connection)
        {
            this.connectionString = connection;
        }
        public void Add(LoansModel loans)
        {
            using (var connection = new SQLiteConnection(connectionString))
                using(var command = connection.CreateCommand())
            {
                connection.Open();
                command.CommandText = @"INSERT INTO loan_list (ref_no,loan_type_id,borrower_id,purpose,amount,plan_id,date_created)
                                        VALUES (@ref_no,@loan_type_id,@borrower_id,@purpose,@amount,@plan_id,@date_created)";
                try
                {
                    command.Parameters.AddWithValue("@ref_no", loans.Ref_no);
                    command.Parameters.AddWithValue("@loan_type_id",loans.Loan_type_id);
                    command.Parameters.AddWithValue("@borrower_id", loans.Borrower_id);
                    command.Parameters.AddWithValue("@purpose", loans.Purpose);
                    command.Parameters.AddWithValue("@amount", loans.Amount);
                    command.Parameters.AddWithValue("@plan_id", loans.Plan_id);
                    //command.Parameters.AddWithValue("@status", loans.Status);
                    //command.Parameters.AddWithValue("@date_released", loans.Date_released);
                    command.Parameters.AddWithValue("@date_created", loans.Date_created);

                    command.ExecuteNonQuery();
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Edit(LoansModel loans)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<LoansModel> GetAll()
        {
            var LoanList = new List<LoansModel>();
            using (var connection = new SQLiteConnection(connectionString))
            using (var command = connection.CreateCommand())
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                command.CommandText = @"SELECT loan_list.id,loan_list.ref_no,loan_list.amount,loan_list.status,loan_list.date_created, loan_list.borrower_id, borrowers.firstname, borrowers.middlename, borrowers.lastname,
                                borrowers.contact, loan_list.plan_id, loan_plan.months, loan_plan.interest_percentage, loan_plan.penalty_rate,
                                loan_list.loan_type_id, loan_types.type_name FROM loan_list
                                JOIN borrowers ON loan_list.borrower_id = borrowers.tax_id
                                JOIN loan_plan ON loan_list.plan_id = loan_plan.id
                                JOIN loan_types ON loan_list.loan_type_id = loan_types.id";

                try
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var loan = new LoansModel
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("id")),
                                Ref_no = reader.GetString(reader.GetOrdinal("ref_no")),
                                Date_created = reader.GetString(reader.GetOrdinal("date_created")),
                                Borrower_id = reader.GetString(reader.GetOrdinal("borrower_id")),
                                Amount = reader.GetString(reader.GetOrdinal("amount")),
                                Status = reader.GetString(reader.GetOrdinal("status")),
                                Firstname = reader.GetString(reader.GetOrdinal("firstname")),
                                Lastname = reader.GetString(reader.GetOrdinal("lastname")),
                                Middlename = reader.GetString(reader.GetOrdinal("middlename")),
                                Contact = reader.GetString(reader.GetOrdinal("contact")),
                                Type_name = reader.GetString(reader.GetOrdinal("type_name")),
                                Months = reader.GetInt32(reader.GetOrdinal("months")),
                                Interest_percentage = reader.GetString(reader.GetOrdinal("interest_percentage")),
                                Penalty_rate = reader.GetInt32(reader.GetOrdinal("penalty_rate"))
                            };

                            LoanList.Add(loan);
                        }
                    }

                    return LoanList;
                }
                catch (Exception ex)
                {
                    // Handle or log the exception
                    Console.WriteLine("Error: " + ex.Message);
                    return null; // or throw an exception
                }
            }
        }


        public IEnumerable<LoansModel> GetBorrowers()
        {
            var borrowerList = new List<LoansModel>();
            using ( var connection = new SQLiteConnection(connectionString))
                using (var command  = connection.CreateCommand())
            {
                connection.Open();
                command.CommandText = @"SELECT tax_id,firstname,middlename,lastname FROM borrowers";

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var borrower = new LoansModel();

                        borrower.Borrower_id = reader.GetString(reader.GetOrdinal("tax_id"));
                        borrower.Firstname = reader.GetString(reader.GetOrdinal("firstname"));
                        borrower.Middlename = reader.GetString(reader.GetOrdinal("middlename"));
                        borrower.Lastname = reader.GetString(reader.GetOrdinal("lastname"));

                        borrowerList.Add(borrower);
                    }
                }

            }
            return borrowerList;
        }

        public IEnumerable<LoansModel> GetByValue(string value)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<LoansModel> GetLoanPlans()
        {
            var planList = new List<LoansModel>();
            using( var connection = new SQLiteConnection(connectionString))
                using ( var command = connection.CreateCommand())
            {
                connection.Open();
                command.CommandText = @"SELECT id,months,interest_percentage,penalty_rate FROM loan_plan ORDER BY  id ASC";

               using( var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var plan = new LoansModel();

                        plan.Plan_id = reader.GetInt32(reader.GetOrdinal("id"));
                        plan.Months = reader.GetInt32(reader.GetOrdinal("months"));
                        plan.Interest_percentage = reader.GetString(reader.GetOrdinal("interest_percentage"));
                        plan.Penalty_rate = reader.GetInt32(reader.GetOrdinal("penalty_rate"));
                        planList.Add(plan);
                    }
                }
            } return planList;
        }

        public IEnumerable<LoansModel> GetLoanType()
        {
           var typeList = new List<LoansModel>();
            using (var connection = new SQLiteConnection(connectionString))
                using ( var command = connection.CreateCommand())
            {
                connection.Open();
                command.CommandText = @"SELECT id,type_name FROM loan_types ORDER BY id ASC";

                using (var  reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var type = new LoansModel();
                        type.Loan_type_id = reader.GetInt32(reader.GetOrdinal("id"));
                        type.Type_name = reader.GetString(reader.GetOrdinal("type_name"));

                        typeList.Add(type);
                    }
                }
            } return typeList;
        }
    }
}
