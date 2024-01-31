using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;
using ManagementSystem.Model;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Net;

namespace ManagementSystem.Repositories
{
    public class BorrowerRepository : BaseRepository, IBorrowerRepisotory
    {
        //Constructor

        public BorrowerRepository(string connectionString) 
        { 
            this.connectionString = connectionString;
        }
        //Methods
        public void Add(BorrowerModel borrowerModel)
        {
            using (var connection = new SQLiteConnection(connectionString))
            using (var cmd = connection.CreateCommand())
            {
                connection.Open();
                cmd.CommandText = @"INSERT INTO borrowers (firstname, middlename, lastname, contact, address, email, tax_id, date_created) 
                                    VALUES (@firstname, @middlename, @lastname, @contact, @address, @email, @tax_id, @date_created)
                                    ";
               /// cmd.Parameters.AddWithValue("@id", borrowerModel.Id);
                cmd.Parameters.AddWithValue("@firstname", borrowerModel.Firstname);
                cmd.Parameters.AddWithValue("@middlename", borrowerModel.Middlename);
                cmd.Parameters.AddWithValue("@lastname", borrowerModel.Lastname);
                cmd.Parameters.AddWithValue("@contact", borrowerModel.Contact);
                cmd.Parameters.AddWithValue("@address", borrowerModel.Address);
                cmd.Parameters.AddWithValue("@email", borrowerModel.Email);
                cmd.Parameters.AddWithValue("@tax_id", borrowerModel.Taxid);
                cmd.Parameters.AddWithValue("@date_created", borrowerModel.DateCreated);
               

                cmd.ExecuteNonQuery();

              

              
            }
        }

        public void Delete(int id)
        {
            using (var connection = new SQLiteConnection(connectionString))
            using (var cmd = connection.CreateCommand())
            {
                connection.Open();
                cmd.CommandText = "delete from borrowers where id=@id";
                cmd.Parameters.Add("@id", DbType.Int16).Value = id;
              
                cmd.ExecuteNonQuery();
            }
        }

        public void Edit(BorrowerModel borrowerModel)
        {
            try
            {
                using (var connection = new SQLiteConnection(connectionString))
                using (var cmd = connection.CreateCommand())
                {
                    connection.Open();
                    cmd.CommandText = "UPDATE borrowers SET firstname=@firstname, middlename=@middlename, lastname=@lastname, contact=@contact, address=@address, email=@email, date_created=@date_created WHERE tax_id=@tax_id";
                    cmd.Parameters.AddWithValue("@firstname", borrowerModel.Firstname);
                    cmd.Parameters.AddWithValue("@middlename", borrowerModel.Middlename);
                    cmd.Parameters.AddWithValue("@lastname", borrowerModel.Lastname);
                    cmd.Parameters.AddWithValue("@contact", borrowerModel.Contact);
                    cmd.Parameters.AddWithValue("@address", borrowerModel.Address);
                    cmd.Parameters.AddWithValue("@email", borrowerModel.Email);
                    cmd.Parameters.AddWithValue("@tax_id", borrowerModel.Taxid);
                    cmd.Parameters.AddWithValue("@date_created", borrowerModel.DateCreated);
                    ///cmd.Parameters.AddWithValue("@id", borrowerModel.Id);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                
            }
        }

        public IEnumerable<BorrowerModel> GetAll()
        {
            var borrowerList = new List<BorrowerModel>();
            using (var connection = new SQLiteConnection(connectionString))
                using (var cmd = connection.CreateCommand())
            {
                connection.Open();
                cmd.CommandText = "Select * from borrowers order by id ASC";
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var borrowerModel = new BorrowerModel();


                        borrowerModel.Id = reader.GetInt32(reader.GetOrdinal("id"));
                        borrowerModel.Firstname = reader.GetString(reader.GetOrdinal("firstname"));
                        borrowerModel.Middlename = reader.GetString(reader.GetOrdinal("middlename"));
                        borrowerModel.Lastname = reader.GetString(reader.GetOrdinal("lastname"));

                        // Check if Contact is nullable in the database
                        if (!reader.IsDBNull(reader.GetOrdinal("contact")))
                        {
                            borrowerModel.Contact = reader.GetString(reader.GetOrdinal("contact"));
                        }

                        borrowerModel.Address = reader.GetString(reader.GetOrdinal("address"));
                        borrowerModel.Email = reader.GetString(reader.GetOrdinal("email"));
                        borrowerModel.Taxid = reader.GetString(reader.GetOrdinal("tax_id"));
                        borrowerModel.DateCreated = reader.GetString(reader.GetOrdinal("date_created"));

                        borrowerList.Add(borrowerModel);
                    }
                }
            }

            return borrowerList;
        }

        public IEnumerable<BorrowerModel> GetByValue(string value)
        {
            var borrowerList = new List<BorrowerModel>();
            int taxId = int.TryParse(value, out _) ? Convert.ToInt32(value) : 0;
            string firstName = value;

            using (var connection = new SQLiteConnection(connectionString))
            using (var cmd = connection.CreateCommand())
            {
                connection.Open();
                cmd.CommandText = "SELECT * FROM borrowers " +
                                  "WHERE tax_id=@tax_id OR firstname LIKE @firstname || '%' " +
                                  "ORDER BY id ASC";

                // Assuming taxId and firstName are variables holding your parameter values
                cmd.Parameters.AddWithValue("@tax_id", taxId);
                cmd.Parameters.AddWithValue("@firstname", firstName);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var borrowerModel = new BorrowerModel
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("id")),
                            Firstname = reader.GetString(reader.GetOrdinal("firstname")),
                            Middlename = reader.GetString(reader.GetOrdinal("middlename")),
                            Lastname = reader.GetString(reader.GetOrdinal("lastname")),
                            Contact = reader.GetString(reader.GetOrdinal("contact")),
                            Address = reader.GetString(reader.GetOrdinal("address")),
                            Email = reader.GetString(reader.GetOrdinal("email")),
                            Taxid = reader.GetString(reader.GetOrdinal("tax_id")),
                            DateCreated = reader.GetString(reader.GetOrdinal("date_created"))
                        };

                        borrowerList.Add(borrowerModel);
                    }
                }
            }

            return borrowerList;
        }

    }
}
