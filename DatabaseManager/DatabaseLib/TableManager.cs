using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace DatabaseLib;
public abstract class TableManager
{
    private MySqlConnection connection;
    public TableManager()
    {
        string connString = $"Data Source=127.0.0.1; Initial Catalog=slagerek; Port=3306; User ID=root; Password=; SslMode=none";
        connection = new MySqlConnection(connString);
    }
    protected MySqlConnection Connection { get { return connection; } }
}
