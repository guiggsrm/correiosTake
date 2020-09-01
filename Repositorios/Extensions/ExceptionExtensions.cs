using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Extensions
{
    public static class ExceptionExtensions
    {
        public static Exception HandleDbUpdateException(this DbUpdateException dbu)
        {

            if (dbu.InnerException != null && dbu.InnerException is SqlException)
                return ((SqlException)dbu.InnerException).HandleSqlException();

            var builder = new StringBuilder("A DbUpdateException was caught while saving changes. ");

            try
            {
                foreach (var result in dbu.Entries)
                {
                    builder.AppendFormat("Type: {0} was part of the problem. ", result.Entity.GetType().Name);
                }
            }
            catch (Exception e)
            {
                builder.Append("Error parsing DbUpdateException: " + e.ToString());
            }

            string message = builder.ToString();
            return new Exception(message, dbu);
        }

        public static Exception HandleSqlException(this SqlException sql)
        {
            var builder = new StringBuilder();
            switch (sql.Number)
            {
                case 2601:
                    builder.Append("Registro duplicado");
                    break;
                default:
                    foreach (SqlError erro in sql.Errors)
                        builder.Append(erro.Message);
                    break;
            }

            string message = builder.ToString();
            return new Exception(message, sql);
        }
    }
}
