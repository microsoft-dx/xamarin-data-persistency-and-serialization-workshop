namespace DataAccessLayer.Entities
{
    public class User
    {
        public uint UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsMale { get; set; }

        public string UserName { get; set; }
        public string AuthentiCationToken { get; set; }
    }
}
