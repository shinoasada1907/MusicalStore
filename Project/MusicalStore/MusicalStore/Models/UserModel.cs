namespace MusicalStore.Models
{
    public class UserModel
    {
        public string UID { get; set; } = string.Empty;
        public string UName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string SDT { get; set; } = string.Empty;
        public string Sex { get; set; } = string.Empty;
        public DateTime Birthday { get; set; } = DateTime.MinValue;
        public string Address { get; set; } = string.Empty;
    }
}
