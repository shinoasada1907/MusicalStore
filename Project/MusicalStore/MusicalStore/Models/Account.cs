namespace MusicalStore.Models
{
    public class Account
    {
        public string AccountId { get; set; } = string.Empty;
        public string AccountName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string? Email { get; set; } = string.Empty;
        public string? CustomerId { get; set; } = string.Empty;
        public string? EmployeeId { get; set; } = string.Empty;
        public string? PermissionId { get; set; } = string.Empty;
    }
}
