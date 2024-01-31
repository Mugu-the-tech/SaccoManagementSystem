using ManagementSystem.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem.Repositories
{
    public class LoanPlanRepisotory : BaseRepository, IPlanRepository
    {
        public LoanPlanRepisotory( String connectString) 
        {
            this.connectionString = connectString;
        }

        public void Add(LoanPlanModel planModel)
        {
            using (var connection = new SQLiteConnection(connectionString))
            using (var cmd = connection.CreateCommand())
            {
                connection.Open();
                cmd.CommandText = @"INSERT INTO loan_plan (months, interest_percentage, penalty_rate) 
                                    VALUES (@months, @interest_percentage, @penalty_rate)
                                    ";
                /// cmd.Parameters.AddWithValue("@id", borrowerModel.Id);
                cmd.Parameters.AddWithValue("@months", planModel.Months);
                cmd.Parameters.AddWithValue("@interest_percentage", planModel.Interest_percentage);
                cmd.Parameters.AddWithValue("@penalty_rate", planModel.Penalty_rate);


                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(int id2)
        {
            using (var connection = new SQLiteConnection(connectionString))
            using (var cmd = connection.CreateCommand())
            {
                connection.Open();
                cmd.CommandText = "delete from loan_plan where id=@id";
                cmd.Parameters.Add("@id", DbType.Int32).Value = id2;

                cmd.ExecuteNonQuery();
            }
        }

        public void Edit(LoanPlanModel planModel)
        {
            using (var connection = new SQLiteConnection(connectionString))
            using (var cmd = connection.CreateCommand())
            {
                connection.Open();
                cmd.CommandText = @"UPDATE loan_plan 
                                    SET months=@months, interest_percentage=@interest_percentage, penalty_rate=@penalty_rate WHERE id=@id
                                    ";
                /// cmd.Parameters.AddWithValue("@id", borrowerModel.Id);
                cmd.Parameters.AddWithValue("@months", planModel.Months);
                cmd.Parameters.AddWithValue("@interest_percentage", planModel.Interest_percentage);
                cmd.Parameters.AddWithValue("@penalty_rate", planModel.Penalty_rate);
                cmd.Parameters.AddWithValue("@id",planModel.Id);


                cmd.ExecuteNonQuery();
            }
        }

        public IEnumerable<LoanPlanModel> GetAll()
        {
            var loanPlanList = new List<LoanPlanModel>();
            using (var connection = new SQLiteConnection(connectionString))
            using (var cmd = connection.CreateCommand())
            {
                connection.Open();
                cmd.CommandText = "Select * from loan_plan order by id desc";
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var LoanModel = new LoanPlanModel();


                        LoanModel.Id = reader.GetInt32(reader.GetOrdinal("id"));
                        LoanModel.Months = reader.GetInt32(reader.GetOrdinal("months"));
                        LoanModel.Interest_percentage = reader.GetString(reader.GetOrdinal("interest_percentage"));
                        // Check if Contact is nullable in the database
                        if (!reader.IsDBNull(reader.GetOrdinal("penalty_rate")))
                        {
                            LoanModel.Penalty_rate = reader.GetInt32(reader.GetOrdinal("penalty_rate"));
                        }
                        loanPlanList.Add(LoanModel);
                    }
                }
            }

            return loanPlanList;
        }
    }
}
