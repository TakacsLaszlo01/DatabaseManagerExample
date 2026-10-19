using MySql.Data.MySqlClient;

namespace DatabaseLib;
public class Performer
{
    private int _id;
    private string _name;
    public Performer(int id, string name, bool isBand)
    {
        ID = id;
        Name = name;
        IsBand = isBand;
    }
    public int ID
    {
        get { return _id; }
        set { _id = value; }
    }
    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }
    public bool IsBand { get; set; }
}
public class PerformerManager : TableManager
{
    public PerformerManager() : base() {}
    public List<Performer> ListAll()
    {
        List<Performer> result = new();
        try
        {
            Connection.Open();
            MySqlCommand command = Connection.CreateCommand();
            command.CommandText = "SELECT id, nev, zenekar FROM eloadok";
            
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                result.Add(new Performer(
                        reader.GetInt32(0),
                        reader.GetString(1),
                        reader.GetInt16(2) != 0
                    ));
            }
        }
        finally { Connection.Close(); }
        return result;
    }
    public bool Insert(int id, string name, bool isBand)
    {
        bool result = false;
        try
        {
            Connection.Open();
            MySqlCommand command = Connection.CreateCommand();
            command.CommandText = "INSERT INTO eloadok (id, nev, eloado) VALUES (@id, @name, @is_band)";

            command.Parameters.AddWithValue("@id", id);
            command.Parameters.AddWithValue("@name", name);
            command.Parameters.AddWithValue("@is_band", isBand);

            result = command.ExecuteNonQuery() > 0;
        }
        finally { Connection.Close(); }
        return result;
    }
    public bool Insert(Performer performer)
    {
        return Insert(performer.ID, performer.Name, performer.IsBand);
    }
    public bool Delete(int id)
    {
        bool result = false;
        try
        {
            Connection.Open();
            MySqlCommand command = Connection.CreateCommand();
            command.CommandText = "DELETE FROM eloadok WHERE id = @id";

            command.Parameters.AddWithValue("@id", id);
            result = command.ExecuteNonQuery() > 0;
        }
        finally { Connection.Close(); }
        return result;
    }
    public bool Update(int id, string name, bool isBand)
    {
        bool result = false;
        try
        {
            Connection.Open();
            MySqlCommand command = Connection.CreateCommand();
            command.CommandText = "UPDATE eloadok SET nev = @name, zenekar = @is_band WHERE id = @id";

            command.Parameters.AddWithValue("@id", id);
            command.Parameters.AddWithValue("@name", name));
            command.Parameters.AddWithValue("@is_band", isBand);

            result = command.ExecuteNonQuery() > 0;
        }
        finally { Connection.Close(); }
        return result;
    }
    public Performer Select(int id)
    {
        try
        {
            Connection.Open();
            MySqlCommand command = Connection.CreateCommand();
            command.CommandText = "SELECT id, nev, zenekar FROM eloadok WHERE id = @id";

            command.Parameters.AddWithValue("@id", id);
            MySqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                string name = reader.GetString(1);
                bool isBand = reader.GetInt16(2) != 0;
                return new Performer(id, name, isBand);
            }
        }
        finally { Connection.Close(); }
        return null;
    }
}