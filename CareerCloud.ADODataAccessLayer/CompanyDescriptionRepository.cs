using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq.Expressions;
using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;

namespace CareerCloud.ADODataAccessLayer
{
    public class CompanyDescriptionRepository : IDataRepository<CompanyDescriptionPoco>
    {
        public void Add(params CompanyDescriptionPoco[] items)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
            SqlCommand cmd = new SqlCommand();
            int rowsEffected = 0;
            foreach (CompanyDescriptionPoco poco in items)
            {
                cmd.CommandText = @"INSERT INTO Company_Descriptions (Id, Company, Language, Company_Name, Company_Description) 
                                    VALUES (@Id, @Company, @Language, @Company_Name, @Company_Description)";
                cmd.Parameters.AddWithValue("@Id", poco.Id);
                cmd.Parameters.AddWithValue("@Company", poco.Company);
                cmd.Parameters.AddWithValue("@Language", poco.LanguageId);
                cmd.Parameters.AddWithValue("@Company_Name", poco.CompanyName);
                cmd.Parameters.AddWithValue("@Company_Description", poco.CompanyDescription);

                conn.Open();
                rowsEffected = cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<CompanyDescriptionPoco> GetAll(params Expression<Func<CompanyDescriptionPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public IList<CompanyDescriptionPoco> GetList(Expression<Func<CompanyDescriptionPoco, bool>> where, params Expression<Func<CompanyDescriptionPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public CompanyDescriptionPoco GetSingle(Expression<Func<CompanyDescriptionPoco, bool>> where, params Expression<Func<CompanyDescriptionPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public void Remove(params CompanyDescriptionPoco[] items)
        {
            throw new NotImplementedException();
        }

        public void Update(params CompanyDescriptionPoco[] items)
        {
            throw new NotImplementedException();
        }
    }
}
