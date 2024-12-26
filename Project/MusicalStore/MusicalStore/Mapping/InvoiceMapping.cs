using MusicalStore.Models.Service;
using MusicalStore.Models;

namespace MusicalStore.Mapping
{
    public static class InvoiceMapping
    {
        public static InvoiceModel ToInvoiceModel(this OrderModel order, List<OrderDetail> orderDetails)
        {
            return new InvoiceModel
            {
                OrderId = order.OrderId,
                CustomerName = order.UserName,
                InvoiceDate = order.OrderDate,
                Items = orderDetails
                    .Where(detail => detail.OrderId == order.OrderId)
                    .Select(detail => new InvoiceItem
                    {
                        ProductName = detail.Product?.ProductName ?? "Unknown Product",
                        Quantity = detail.Quantity,
                        UnitPrice = (decimal)detail.UnitPrice
                    }).ToList()
            };
        }
    }
}
