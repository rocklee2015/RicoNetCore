using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace S06.AutoMapperV9.V2_2.S14_QueryableExtensions
{
    public class OrderLine
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public Item Item { get; set; }
        public decimal Quantity { get; set; }
    }

    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class OrderLineDTO
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public string Item { get; set; }
        public decimal Quantity { get; set; }
    }
    [TestClass]
    public class S14_QueryableExtensions_Test
    {
        [TestMethod]
        public void QueryableExtensions()
        {
            var configuration = new MapperConfiguration(cfg =>
    cfg.CreateMap<OrderLine, OrderLineDTO>()
    .ForMember(dto => dto.Item, conf => conf.MapFrom(ol => ol.Item.Name)));

            //using (var context = new orderEntities())
            //{
            //    return context.OrderLines.Where(ol => ol.OrderId == orderId)
            //             .ProjectTo<OrderLineDTO>().ToList();
            //}
        }
    }
}
