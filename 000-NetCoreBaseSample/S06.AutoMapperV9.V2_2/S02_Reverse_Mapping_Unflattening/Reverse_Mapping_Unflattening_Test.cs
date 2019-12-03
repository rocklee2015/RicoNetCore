using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Text;

namespace S06.AutoMapperV9.V2_2.S02_Reverse_Mapping_Unflattening
{
    public class Order
    {
        public decimal Total { get; set; }
        public Customer Customer { get; set; }
    }

    public class Customer
    {
        public string Name { get; set; }
    }
    public class OrderDto
    {
        public decimal Total { get; set; }
        public string CustomerName { get; set; }
    }
    [TestClass]
    public class Reverse_Mapping_Unflattening_Test
    {
        [TestMethod]
        public void Reverse_Mapping_Unflattening()
        {
            var customer = new Customer
            {
                Name = "Bob"
            };

            var order = new Order
            {
                Customer = customer,
                Total = 15.8m
            };
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Order, OrderDto>().ReverseMap();
            });
            IMapper mapper = new Mapper(configuration);
            var orderDto = mapper.Map<Order, OrderDto>(order);

            orderDto.CustomerName = "Joe";

            mapper.Map(orderDto, order);

            order.Customer.Name.ShouldBe("Joe");
        }
        [TestMethod]
        public void customizing_reverse_mapping()
        {
            var customer = new Customer
            {
                Name = "Bob"
            };

            var order = new Order
            {
                Customer = customer,
                Total = 15.8m
            };
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Order, OrderDto>()
                 .ForMember(d => d.CustomerName, opt => opt.MapFrom(src => src.Customer.Name))
                .ReverseMap();
            });
            IMapper mapper = new Mapper(configuration);
            var orderDto = mapper.Map<Order, OrderDto>(order);

            orderDto.CustomerName = "Joe";

            mapper.Map(orderDto, order);

            order.Customer.Name.ShouldBe("Joe");

        }
    }
}
