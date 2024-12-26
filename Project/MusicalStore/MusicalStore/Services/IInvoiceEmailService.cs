using MusicalStore.Models.Service;

namespace MusicalStore.Services
{
    public interface IInvoiceEmailService
    {
        public Task SendInvoiceEmailAsync(InvoiceModel model, string customerEmail);
    }
}
