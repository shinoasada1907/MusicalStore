using System.ComponentModel.DataAnnotations.Schema;

namespace MusicalStore.Models
{
    public class Payment
    {
       
            public string PaymentMethodId { get; set; } = null!;

            [Column(TypeName = "nvarchar(200)")]
            public string? MethodType { get; set; }

            public string? PhoneNumber { get; set; }

            public string? RecipientName { get; set; }

            public string? BankName { get; set; }

            public string? AccountNumber { get; set; }

            public virtual ICollection<OrderModel> Orders { get; set; } = new List<OrderModel>();
        
    }
}
