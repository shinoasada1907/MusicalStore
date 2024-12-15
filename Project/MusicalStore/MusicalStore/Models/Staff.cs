namespace MusicalStore.Models
{
    public class Staff
    {
        public string StaffId { get; set; } = string.Empty; // same to CCCD
        public string StaffName { get; set; } = string.Empty;
        public DateTime Birthday { get; set; } = DateTime.MinValue;
        public string Sex { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string PositionId { get; set; } = string.Empty;
        public string CCCD { get; set; } = string.Empty;
        public PositionModel Potition { get; set; } = new PositionModel();
    }
}
