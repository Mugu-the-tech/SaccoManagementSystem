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
    public class LoanTypeRepository : BaseRepository, ITypeRepository
    {

        public LoanTypeRepository(String ConnectionString) 
        {
            this.connectionString = ConnectionString;
        }
        public void Add(LoanTypeModel loanTypeModel)
        {
            using (var connection = new SQLiteConnection(connectionString))
                using (var cmd = connection.CreateCommand())
            {
                connection.Open();
                cmd.CommandText = @"INSERT INTO loan_types (type_name,description) 
                                            VALUES(@type_name,@description)";
                cmd.Parameters.AddWithValue("@type_name", loanTypeModel.Type_name);
                cmd.Parameters.AddWithValue("@description", loanTypeModel.Description);

                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            using(var connection = new SQLiteConnection(connectionString))
            using (var cmd = connection.CreateCommand())
            {
                connection.Open();
                cmd.CommandText = "delete from loan_types where id=@id";
                cmd.Parameters.Add("@id", DbType.Int32).Value = id;

                cmd.ExecuteNonQuery();
            }
        }

        public void Edit(LoanTypeModel loanTypeModel)
        {
            try
            {
                using (var connection = new SQLiteConnection(connectionString))
                    using (var cmd = connection.CreateCommand())
                {
                    connection.Open();
                    cmd.CommandText = "UPDATE loan_types SET type_name=@type_name, type_description=@description WHERE id=@id";
                    cmd.Parameters.AddWithValue("@type_name",loanTypeModel.Type_name);
                    cmd.Parameters.AddWithValue("@description", loanTypeModel.Description);
                    cmd.Parameters.AddWithValue("@id", loanTypeModel.Id);
                }
            }
            catch (Exception)
            {

             
            }
        }

        public IEnumerable<LoanTypeModel> GetAll()
        {
            var LoanTypeList = new List<LoanTypeModel>();
            using (var connection = new SQLiteConnection(connectionString))
            using (var cmd = connection.CreateCommand())
            {
                connection.Open();
                cmd.CommandText = "Select * from loan_types order by id ASC";
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var LoanModel = new LoanTypeModel();


                        LoanModel.Id = reader.GetInt32(reader.GetOrdinal("id"));
                        LoanModel.Type_name = reader.GetString(reader.GetOrdinal("type_name"));
                        LoanModel.Description = reader.GetString(reader.GetOrdinal("description"));
                       
                        LoanTypeList.Add(LoanModel);
                    }
                }
            }

            return LoanTypeList;
        }
    }
}
