using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data.SqlClient;



namespace WcfServiceAPI
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {

        public static SqlCommand SqlCmd(string sql)
        {
            string connString = @"Server=DESKTOP-7H6L3KN;Database=Demo;Trusted_Connection = True;";   //Windows Authentication.
            //string connString = @"Server=INSTANCE_NAME;Database=DATABASE_NAME;User ID=USERNAME;Password=PASSWORD";   //SQL Server Authentication.

            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(sql, conn);

            conn.Open();
            return cmd;
        }


        public string GetData(string value)
        {
            return $"You entered: {value}";
        }

        public string PayBill(string PayId)
        {
            return "Transaction having PayId " + PayId + " was successful";
        }

        public MessageResponse InsertData(WCF_Enter enter)
        {

            MessageResponse msg = new MessageResponse();

            try
            {
                string sql = "INSERT INTO WCF_Enter (Name, Age, Country, Gender) VALUES ('" + enter.Name + "','" + enter.Age + "','" + enter.Country + "','" + enter.Gender + "')";
                SqlCommand insCmd = SqlCmd(sql);

                insCmd.ExecuteNonQuery();  //For Insert Query.
                insCmd.Connection.Close();

                msg.Message = "Data Entry Successful.";
                msg.Status_Code = 200;

                return msg;
            }
            catch (Exception ex)
            {
                msg.Message = ex.Message;
                msg.Status_Code=500;

                return msg;
            }
        }


        public List<WCF_Enter> GetAllData()
        {
            try
            {
                List<WCF_Enter> output = new List<WCF_Enter>();

                string sql = "SELECT * FROM WCF_Enter";
                SqlCommand insCmd = SqlCmd(sql);
                SqlDataReader reader = insCmd.ExecuteReader();

                while (reader.Read())
                {
                    WCF_Enter outData = new WCF_Enter();  //Initializing Obj to assigning data to datamembers.

                    outData.Name = reader["Name"].ToString();
                    outData.Age = Convert.ToInt32(reader["Age"]);
                    outData.Gender = reader["Gender"].ToString();
                    outData.Country = reader["Country"].ToString();

                    output.Add(outData);
                }

                return output;
            }
            catch (Exception ex) 
            {
                //MessageResponse msg = new MessageResponse();
                //msg.Message = ex.Message;
                //msg.Status_Code = 500;

                return null;
            }

        }



        public List<WCF_Enter> GetSpecificData(string id)
        {
            try
            {
                List<WCF_Enter> output = new List<WCF_Enter>();

                string sql = "SELECT * FROM WCF_Enter WHERE Id='" + id + "'";
                SqlCommand insCmd = SqlCmd(sql);
                SqlDataReader reader = insCmd.ExecuteReader();

                while (reader.Read())
                {
                    WCF_Enter outData = new WCF_Enter();  //Initializing Obj to assigning data to datamembers.

                    outData.Name = reader["Name"].ToString();
                    outData.Age = Convert.ToInt32(reader["Age"]);
                    outData.Gender = reader["Gender"].ToString();
                    outData.Country = reader["Country"].ToString();

                    output.Add(outData);
                }

                return output;
            }
            catch (Exception ex)
            {
                return null;
            }

        }



        public MessageResponse deleteData(DeleteRequest Id)
        {

            MessageResponse msg = new MessageResponse();

            try
            {
                string sql = "DELETE FROM WCF_Enter WHERE Id='" + Id.Id + "'";
                SqlCommand insCmd = SqlCmd(sql);

                insCmd.ExecuteNonQuery();  //For Insert Query.
                insCmd.Connection.Close();

                msg.Message = "Data Deleted Successfully.";
                msg.Status_Code = 200;

                return msg;
            }
            catch (Exception ex)
            {
                msg.Message = ex.Message;
                msg.Status_Code = 500;

                return msg;
            }
        }


    }
}
