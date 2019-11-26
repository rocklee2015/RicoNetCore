using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;

namespace S06.AutoMapperV9.V2_2.S01_Flattening
{
    public class Customer
    {
        public string Name { get; set; }
    }
    public class Order
    {
        private readonly IList<OrderLineItem> _orderLineItems = new List<OrderLineItem>();

        public Customer Customer { get; set; }

        public OrderLineItem[] GetOrderLineItems()
        {
            return _orderLineItems.ToArray();
        }

        public void AddOrderLineItem(Product product, int quantity)
        {
            _orderLineItems.Add(new OrderLineItem(product, quantity));
        }

        public decimal GetTotal()
        {
            return _orderLineItems.Sum(li => li.GetTotal());
        }
    }
    public class OrderDto
    {
        public string CustomerName { get; set; }
        public decimal Total { get; set; }
    }
    public class OrderLineItem
    {
        public OrderLineItem(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }

        public Product Product { get; private set; }
        public int Quantity { get; private set; }

        public decimal GetTotal()
        {
            return Quantity * Product.Price;
        }
    }
    public class Product
    {
        public decimal Price { get; set; }
        public string Name { get; set; }
    }
    [TestClass]
    public  class Flattening_Test
    {
        [TestMethod]
        public  void Falttening()
        {
            Console.WriteLine("-------S01_0_Falttening-------------");
            // Complex model
            var customer = new Customer
            {
                Name = "George Costanza"
            };
            var order = new Order
            {
                Customer = customer
            };
            var bosco = new Product
            {
                Name = "Bosco",
                Price = 4.99m
            };
            order.AddOrderLineItem(bosco, 15);

            // Configure AutoMapper

            var configuration = new MapperConfiguration(cfg => cfg.CreateMap<Order, OrderDto>());

            // Perform mapping
            IMapper mapper = new Mapper(configuration);
            OrderDto dto = mapper.Map<Order, OrderDto>(order);

            dto.CustomerName.ShouldBe("George Costanza");
            dto.Total.ShouldBe(74.85m);
        }
    }
}
