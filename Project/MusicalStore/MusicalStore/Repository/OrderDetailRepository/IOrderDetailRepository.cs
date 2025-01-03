﻿using MusicalStore.Models;

namespace MusicalStore.Repository.OrderDetailRepository
{
    public interface IOrderDetailRepository
    {
        public Task<IEnumerable<OrderDetail>> CreateOrderDetail(List<OrderDetail> orderDetail);
        public IEnumerable<OrderDetail> GetAllOrderDetail(string customerId);
    }
}
