using System;
using System.Data;
using MySql.Data.MySqlClient;


namespace IdealeWareWebApiCore.Data
{
    public class BaseConnection 
    {
        protected IDbConnection Connection { get; set; }
        public BaseConnection()
        {
            Connection = new MySqlConnection("server=localhost; database=idealewaredb; user id=root; password=root;");
        }

    }
}
