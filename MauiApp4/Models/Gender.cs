using SQLite;

public class Gender
{
    [PrimaryKey, AutoIncrement]
    public int IdGender { get; set; }

    public string GenderName { get; set; } = string.Empty;
}
