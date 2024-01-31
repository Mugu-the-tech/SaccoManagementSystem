using ManagementSystem.Model;
using ManagementSystem.View;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ManagementSystem.Repositories
{
    public class SavingsRepository:BaseRepository,ISavingsRepository
    {
        public SavingsRepository(string connection) 
        {
            this.connectionString = connection;
        }

        public void Add(SavingsModel savings)
        {
            using (var connection = new SQLiteConnection(connectionString))
                using (var command = connection.CreateCommand())
            {
                connection.Open();
                command.CommandText = @"INSERT INTO Savings (members_id,members_name,monthly_savings,total_savings,current_savings)
                                        VALUES (@members_id,@members_name,@monthly_savings,@total_savings,@current_savings)";
                command.Parameters.AddWithValue("@members_id", savings.Members_id);
                command.Parameters.AddWithValue("@members_name", savings.Members_name);
                command.Parameters.AddWithValue("@monthly_savings", savings.Monthly_savings);
                command.Parameters.AddWithValue("@total_savings", savings.Total_savings);
                command.Parameters.AddWithValue("@current_savings", savings.Current_savings);

                command.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            using (var connection = new SQLiteConnection(connectionString))
            using (var cmd = connection.CreateCommand())
            {
                connection.Open();
                cmd.CommandText = "delete from savings where members_id=@members_id";
                cmd.Parameters.Add("@members_id", DbType.Int32).Value = id;

                cmd.ExecuteNonQuery();
            }
        }

        public void Edit(SavingsModel savings)
        {
            using (var connection = new SQLiteConnection(connectionString))
                using (var command = connection.CreateCommand())
            {
                connection.Open();

                command.CommandText = @"UPDATE Savings SET members_name=@members_name,monthly_savings=@monthly_savings,current_savings=@current_savings,total_savings=@total_savings WHERE members_id=@members_id";
              
                command.Parameters.AddWithValue("@members_name", savings.Members_name);
                command.Parameters.AddWithValue("@monthly_savings", savings.Monthly_savings);
                command.Parameters.AddWithValue("@total_savings", savings.Total_savings);
                command.Parameters.AddWithValue("@current_savings", savings.Current_savings);
                command.Parameters.AddWithValue("@members_id", savings.Members_id);
                command.ExecuteNonQuery();
            }
        }

        public IEnumerable<SavingsModel> GetAll()
        {
            var SavingList = new List<SavingsModel>();

            using (var connection = new SQLiteConnection (connectionString))
                using (var command = connection.CreateCommand ())
            {
                connection.Open ();
                command.CommandText = @"SELECT * FROM Savings ORDER by id ASC";

                using (var reader = command.ExecuteReader ())
                {
                    while (reader.Read ()) { 
                    var Savings = new SavingsModel ();
                    Savings.Id = reader.GetInt32(reader.GetOrdinal("id"));
                    Savings.Members_id = reader.GetInt32(reader.GetOrdinal("members_id"));
                    Savings.Members_name = reader.GetString(reader.GetOrdinal("members_name"));
                    Savings.Monthly_savings = reader.GetFloat(reader.GetOrdinal("monthly_savings"));
                    Savings.Current_savings = reader.GetFloat(reader.GetOrdinal("current_savings"));
                    Savings.Total_savings = reader.GetFloat(reader.GetOrdinal("total_savings"));
                        SavingList.Add(Savings);
                    };
                 
                }
            }
            return SavingList;
        }

        public IEnumerable<SavingsModel> GetByValue(string value)
        {
            var savings = new List<SavingsModel>();
            string member_name = value;

            using ( var connection = new SQLiteConnection (connectionString)) using ( var command = connection.CreateCommand())
            {
                connection.Open ();
                command.CommandText = "SELECT * FROM Savings " +
                                          "WHERE members_name LIKE @members_name || '%' COLLATE NOCASE " +
                                          "ORDER BY id ASC";
                command.Parameters.AddWithValue (member_name, value);

               using ( var reader = command.ExecuteReader ())
                {
                    while (reader.Read ())
                    {
                        var Savings = new SavingsModel();
                        Savings.Id = reader.GetInt32(reader.GetOrdinal("id"));
                        Savings.Members_name = reader.GetString(reader.GetOrdinal("members_name"));
                        Savings.Monthly_savings = reader.GetFloat(reader.GetOrdinal("monthly_savings"));
                        Savings.Current_savings = reader.GetFloat(reader.GetOrdinal("current_savings"));
                        Savings.Total_savings = reader.GetFloat(reader.GetOrdinal("total_savings"));
                        savings.Add(Savings);
                    }
                }
            }
            return savings;
        }

        public IEnumerable<SavingsModel> GetMembers()
        {
            var MemberList = new List<SavingsModel>();

            using (var connection = new SQLiteConnection(connectionString))
            using (var command = connection.CreateCommand())
            {
                connection.Open();
                command.CommandText = @"SELECT members_id,members_name FROM members order by members_id ASC";

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var member = new SavingsModel();
                        member.Members_id = reader.GetInt32(reader.GetOrdinal("members_id"));
                        member.Members_name = reader.GetString(reader.GetOrdinal("members_name"));
                        MemberList.Add(member);

                    }
                }
            }
            return MemberList;
        }
    }
}
