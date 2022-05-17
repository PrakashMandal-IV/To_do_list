namespace To_do_list.Data.Model
{
    public class User
    {
        public int Id { get; set; } 
        public string UserName { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public DateOnly CreatedAt { get; set; }       
    }
}
