using System;
using System.Data.SqlClient;

namespace AdessoWL.Application.Interfaces.DapperContext
{
    public interface IDapperContext
    {
        public SqlConnection GetConnection();
        public void Execute(Action<SqlConnection> @event);
    }
}
