namespace MusicalStore.Models
{
    public class Staff
    {
        public string StaffId { get; set; } = string.Empty;
        public string StaffName { get; set; } = string.Empty;
        public DateTime Birthday { get; set; } = DateTime.MinValue;
        public string Position { get; set; } = string.Empty;
    }
}
