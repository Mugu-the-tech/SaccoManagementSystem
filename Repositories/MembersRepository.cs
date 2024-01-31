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
    public class MembersRepository : BaseRepository, IMemberRepository
    {

        public MembersRepository(string connection) 
        {
            this.connectionString = connection;
        }
        public void Add(MembersModel member)
        {
            using (var connection = new SQLiteConnection(connectionString))
                using (var command = connection.CreateCommand())
            {
                connection.Open();
                command.CommandText ="INSERT INTO members (members_id, members_name,contact,gender,position,next_of_kin,status) VALUES (@members_id,@members_name,@contact,@gender,@position,@next_of_kin,@status)";
                command.Parameters.AddWithValue("@members_id",member.Id);
                command.Parameters.AddWithValue("@members_name", member.Member_Name);
                command.Parameters.AddWithValue("@contact", member.Contact);
                command.Parameters.AddWithValue("@gender", member.Gender);
                command.Parameters.AddWithValue("@position", member.Position);
                command.Parameters.AddWithValue("@next_of_kin", member.Next_of_kin);
                command.Parameters.AddWithValue("@status", member.Status);
                command.ExecuteNonQuery();

            }
        }

        public void Delete(int id)
        {
            using (var connection = new SQLiteConnection(connectionString))
            using (var cmd = connection.CreateCommand())
            {
                connection.Open();
                cmd.CommandText = "delete from members where members_id=@members_id";
                cmd.Parameters.Add("@members_id", DbType.Int32).Value = id;

                cmd.ExecuteNonQuery();
            }
        }

        public void Edit(MembersModel member)
        {
            using (var connection = new SQLiteConnection(connectionString))
            using (var command = connection.CreateCommand())
            {
                connection.Open();
                command.CommandText = "UPDATE members SET members_name=@members_name,contact=@contact,gender=@gender,position=@position,next_of_kin=@next_of_kin,status=@status WHERE members_id=@members_id";
           
                command.Parameters.AddWithValue("@members_name", member.Member_Name);
                command.Parameters.AddWithValue("@contact", member.Contact);
                command.Parameters.AddWithValue("@gender", member.Gender);
                command.Parameters.AddWithValue("@position", member.Position);
                command.Parameters.AddWithValue("@next_of_kin", member.Next_of_kin);
                command.Parameters.AddWithValue("@status", member.Status);
                command.Parameters.AddWithValue("@members_id", member.Id);
                command.ExecuteNonQuery();


            }
        }

        public IEnumerable<MembersModel> GetAll()
        {
            var MemberList = new List<MembersModel>();

            using (var connection = new SQLiteConnection(connectionString))
                using (var command = connection.CreateCommand())
            {
                connection.Open();
                command.CommandText = "SELECT * FROM members order by members_id ASC";

                using(var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                       var member = new MembersModel();
                        member.Id = reader.GetInt32(reader.GetOrdinal("members_id"));
                        member.Member_Name = reader.GetString(reader.GetOrdinal("members_name"));
                        member.Contact = reader.GetInt32(reader.GetOrdinal("contact"));
                        member.Gender = reader.GetString(reader.GetOrdinal("gender"));
                        member.Position = reader.GetString(reader.GetOrdinal("position"));
                        member.Next_of_kin = reader.GetString(reader.GetOrdinal("next_of_kin"));
                        member.Status = reader.GetString(reader.GetOrdinal("status"));
                       
                        MemberList.Add(member);
  
                    }
                }
            }
            return MemberList;
        }

        public IEnumerable<MembersModel> GetByValue(string value)
        {
            var MemberList = new List<MembersModel>();
            int MemberID = int.TryParse(value, out _) ? Convert.ToInt32(value) : 0;
            string Member_Name = value;

            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM members " +
                                          "WHERE members_id=@members_id OR members_name LIKE @members_name || '%' COLLATE NOCASE " +
                                          "ORDER BY members_id ASC";

                    command.Parameters.AddWithValue("@members_id", MemberID);
                    command.Parameters.AddWithValue("@members_name", Member_Name);

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var member = new MembersModel
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("members_id")),
                                Member_Name = reader.GetString(reader.GetOrdinal("members_name")),
                                Contact = reader.GetInt32(reader.GetOrdinal("contact")),
                                Gender = reader.GetString(reader.GetOrdinal("gender")),
                                Position = reader.GetString(reader.GetOrdinal("position")),
                                Next_of_kin = reader.GetString(reader.GetOrdinal("next_of_kin")),
                                Status = reader.GetString(reader.GetOrdinal("status"))
                            };

                            MemberList.Add(member);
                        }
                    }
                }
            }

            return MemberList;
        }


    }
}
