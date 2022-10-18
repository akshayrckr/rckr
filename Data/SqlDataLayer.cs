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
                cmd.Parameters.Add("@Position", SqlDbType.VarChar).Value = ((Support)staffToCreate).Position;
            if (staffToCreate is Admin)
                cmd.Parameters.Add("@Privelage", SqlDbType.VarChar).Value = ((Admin)staffToCreate).Privelage;
            if (staffToCreate is Teaching)
                cmd.Parameters.Add("@Experience", SqlDbType.VarChar).Value = ((Teaching)staffToCreate).Experience;


            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();

        }

        public void Delete(int staffIdToDelete)
        {
            throw new NotImplementedException();
        }

        public Staff Read(int staffIdToRead)
        {
            throw new NotImplementedException();
        }

        public List<Staff> ReadAll()
        {
            throw new NotImplementedException();
        }

        public List<Staff> ReadByType(string staffTypeToRead)
        {
            throw new NotImplementedException();
        }

        public void Update(Staff staffToUpdate)
        {
            throw new NotImplementedException();
        }

        private class connetionString
        {
        }
    }
}
