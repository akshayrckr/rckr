using Library;
using System;
using System.Collections.Generic;
using System.Data;
//using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
using System.Text;

namespace Data.Impl
{
    class SqlDataLayer : IData
    {
        public string connstr;
        SqlConnection cnn;

        public SqlDataLayer()
        {
            connstr = @"Server=DESKTOP-3JR0NLN;Initial Catalog=StaffManagementDb;Integrated Security=True;TrustServerCertificate=True;";
            cnn = new SqlConnection(connstr);

        }
        public void Create(Staff staffToCreate)
        {
            SqlCommand cmd = new SqlCommand("Proc_Staff_Insert", cnn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = staffToCreate.Name;
            cmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = staffToCreate.Email;
            cmd.Parameters.Add("@Phone", SqlDbType.VarChar).Value = staffToCreate.Phone;
            cmd.Parameters.Add("@Address", SqlDbType.VarChar).Value = staffToCreate.Address;
            cmd.Parameters.Add("@Roles", SqlDbType.VarChar).Value = staffToCreate.Type;
            if (staffToCreate is Support)
            {
                cmd.Parameters.Add("@Position", SqlDbType.VarChar).Value = ((Support)staffToCreate).Position;
            }
            if (staffToCreate is Admin)
            {
                cmd.Parameters.Add("@Privelage", SqlDbType.VarChar).Value = ((Admin)staffToCreate).Privelage;
            }
            if (staffToCreate is Teaching)
            {
                cmd.Parameters.Add("@Experience", SqlDbType.VarChar).Value = ((Teaching)staffToCreate).Experience;
            }

            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();

        }

        public void Delete(int staffIdToDelete)
        {
            SqlCommand cmd = new SqlCommand("Proc_Staff_Delete", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@StaffId", SqlDbType.VarChar).Value = staffIdToDelete;
        }

        public Staff Read(int staffIdToRead)
        {
            using (SqlConnection cnn = new SqlConnection(connstr))
            {
                cnn.Open();
                SqlCommand command = new SqlCommand("Proc_Staff_ReadById", cnn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@EmpId", SqlDbType.VarChar).Value = staffIdToRead;

                using (SqlDataReader reader = command.ExecuteReader())
                {

                    do
                    {


                        while (reader.Read())
                        {
                            string Name = reader.GetValue(reader.GetOrdinal("Name")).ToString();
                            string Email = reader.GetValue(reader.GetOrdinal("Email")).ToString();
                            string Phone = reader.GetValue(reader.GetOrdinal("Phone")).ToString();
                            string Address = reader.GetValue(reader.GetOrdinal("Address")).ToString();
                            string Role = reader.GetValue(reader.GetOrdinal("Role")).ToString();

                            switch (Role)
                            {
                                case "Support":
                                    string position = reader.GetValue(reader.GetOrdinal("Position")).ToString();
                                    Staff sp = new Support(staffIdToRead, Name, Address, Email, Phone, position);
                                    return sp;


                                case "Admin":
                                    string privelage = reader["Privelage"].ToString();
                                    Staff ad = new Admin(staffIdToRead, Name, Address, Email, Phone, privelage);
                                    return ad;

                                case "Teacher":
                                    int Experience = (int)reader.GetValue(reader.GetOrdinal("Experience"));
                                    Staff tc = new Teaching(staffIdToRead, Name, Address, Email, Phone, Experience);
                                    return tc;

                                default:
                                    return null;
                            }
                        }
                    } while (reader.NextResult());

                    command.ExecuteNonQuery();
                    cnn.Close();
                    return null;
                }
            }



        }

        public List<Staff> ReadAll()
        {
            List<Staff> Staffs = new List<Staff>();
            using (SqlConnection cnn = new SqlConnection(connstr))
            {
                cnn.Open();
                SqlCommand command = new SqlCommand("Proc_Staff_ReadAll", cnn);
                command.CommandType = CommandType.StoredProcedure;
               

                using (SqlDataReader reader = command.ExecuteReader())
                {

                    do
                    {


                        while (reader.Read())
                        {
                            int StaffId = (int)reader.GetValue(reader.GetOrdinal("Staffid"));
                            string Name = reader.GetValue(reader.GetOrdinal("Name")).ToString();
                            string Email = reader.GetValue(reader.GetOrdinal("Email")).ToString();
                            string Phone = reader.GetValue(reader.GetOrdinal("Phone")).ToString();
                            string Address = reader.GetValue(reader.GetOrdinal("Address")).ToString();
                            string Role = reader.GetValue(reader.GetOrdinal("Role")).ToString();

                            switch (Role)
                            {
                                case "Support":
                                    string position = reader["Position"].ToString();
                                    Staff sp = new Support(StaffId, Name, Address, Email, Phone, position);
                                    Staffs.Add(sp);
                                    break;

                                case "Admin":
                                    string privelage = reader["Privelage"].ToString();
                                    Staff ad = new Admin(StaffId, Name, Address, Email, Phone, privelage);
                                    Staffs.Add(ad);
                                    break;
                                case "Teacher":
                                    int Experience = (int)reader.GetValue(reader.GetOrdinal("Experience"));
                                    Staff tc = new Teaching(StaffId, Name, Address, Email, Phone, Experience);
                                    Staffs.Add(tc);
                                    break;

                                default:
                                    break;
                            }
                        }
                    } while (reader.NextResult());
                   
                    
                    
                    //command.ExecuteNonQuery();
                    cnn.Close();
                    return Staffs;
                    

                }
            }
        }

        public List<Staff> ReadByType(string staffTypeToRead)
        {
            List<Staff> staffs = new List<Staff>();
            using (SqlConnection cnn = new SqlConnection(connstr))
            {
                cnn.Open();
                SqlCommand command = new SqlCommand("Proc_Staff_ReadByType", cnn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@role", SqlDbType.VarChar).Value = staffTypeToRead;

                using (SqlDataReader reader = command.ExecuteReader())
                {

                    do
                    {


                        while (reader.Read())
                        {
                            string Name = reader.GetValue(reader.GetOrdinal("Name")).ToString();
                            string Email = reader.GetValue(reader.GetOrdinal("Email")).ToString();
                            string Phone = reader.GetValue(reader.GetOrdinal("Phone")).ToString();
                            string Address = reader.GetValue(reader.GetOrdinal("Address")).ToString();
                            string Role = reader.GetValue(reader.GetOrdinal("Role")).ToString();
                            int StaffId = (int)reader.GetValue(reader.GetOrdinal("StaffId"));

                            switch (Role)
                            {
                                case "Support":
                                    string position = reader.GetValue(reader.GetOrdinal("Position")).ToString();
                                    Staff sp = new Support(StaffId, Name, Address, Email, Phone, position);
                                    staffs.Add(sp);
                                    break;


                                case "Admin":
                                    string privelage = reader["Privelage"].ToString();
                                    Staff ad = new Admin(StaffId, Name, Address, Email, Phone, privelage);
                                    staffs.Add(ad);
                                    break;

                                case "Teacher":
                                    int Experience = (int)reader.GetValue(reader.GetOrdinal("Experience"));
                                    Staff tc = new Teaching(StaffId, Name, Address, Email, Phone, Experience);
                                    staffs.Add(tc);
                                    break;

                                default:
                                    break;
                            }
                        }
                    } while (reader.NextResult());
                    return staffs;
                    //command.ExecuteNonQuery();
                    cnn.Close();
                    return null;
                }
            }
        }

        public void Update(Staff staffToUpdate)
        {
            SqlCommand cmd = new SqlCommand("Proc_Staff_Update", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = staffToUpdate.Name;
            cmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = staffToUpdate.Email;
            cmd.Parameters.Add("@Phone", SqlDbType.VarChar).Value = staffToUpdate.Phone;
            cmd.Parameters.Add("@Address", SqlDbType.VarChar).Value = staffToUpdate.Address;
            cmd.Parameters.Add("@Roles", SqlDbType.VarChar).Value = staffToUpdate.Type;
            if (staffToUpdate is Support)
            {
                cmd.Parameters.Add("@Position", SqlDbType.VarChar).Value = ((Support)staffToUpdate).Position;
            }
            if (staffToUpdate is Admin)
            {
                cmd.Parameters.Add("@Privelage", SqlDbType.VarChar).Value = ((Admin)staffToUpdate).Privelage;
            }
            if (staffToUpdate is Teaching)
            {
                cmd.Parameters.Add("@Experience", SqlDbType.VarChar).Value = ((Teaching)staffToUpdate).Experience;
            }

            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
    }
}
