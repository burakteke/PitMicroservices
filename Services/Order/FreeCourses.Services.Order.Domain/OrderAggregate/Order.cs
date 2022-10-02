﻿using FreeCourses.Services.Order.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeCourses.Services.Order.Domain.OrderAggregate
{
    // EF Core features
    // --Owned Types
    // --Shadow Property
    // --Backing Field
    public class Order: Entity, IAggregateRoot
    {
        private readonly List<OrderItem> _orderItems;
        public DateTime CreatedDate { get; private set; }
        public Address Address { get; private set; }
        public string BuyerId { get; private set; }
        public IReadOnlyCollection<OrderItem> OrderItems => _orderItems; //kapsülledik.

        public Order()
        {

        }

        public Order(string buyerId, Address address)
        {
            Address = address;
            BuyerId = buyerId;
            _orderItems = new List<OrderItem>();
            CreatedDate = DateTime.Now;
        }

        public void AddOrderItem(string productId, string productName, decimal price, string pictureUrl)
        {
            var existProduct = _orderItems.Any(x => x.ProductId == productId);
            if (!existProduct)
            {
                var newOrderItem = new OrderItem(productId, productName, pictureUrl, price);
                _orderItems.Add(newOrderItem);
            }
        }

        public decimal GetTotalPrice => _orderItems.Sum(x => x.Price);
    }
}
