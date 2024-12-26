using MusicalStore.Models.Service;

namespace MusicalStore.Services
{
    public class InvoiceEmailService : IInvoiceEmailService
    {
        private readonly RenderViewToString _renderer;
        private readonly IEmailService _emailService;

        public InvoiceEmailService(RenderViewToString renderer, IEmailService emailService)
        {
            _renderer = renderer;
            _emailService = emailService;
        }
        public async Task SendInvoiceEmailAsync(InvoiceModel model, string customerEmail)
        {
            // Render Razor View thành HTML
            string htmlContent = await _renderer.RenderViewToStringAsync("Invoice", model);

            // Gửi email
            await _emailService.SendEmailAsync(customerEmail, "Hóa đơn mua hàng của bạn", htmlContent);

        }
    }
}
