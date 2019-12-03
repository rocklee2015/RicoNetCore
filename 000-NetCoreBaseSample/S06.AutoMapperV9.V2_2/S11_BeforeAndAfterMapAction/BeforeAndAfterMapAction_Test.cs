using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Text;

namespace S06.AutoMapperV9.V2_2.S11_BeforeAndAfterMapAction
{
    public class Source
    {
        public int Value { get; set; }
    }

    public class Destination
    {
        public int Value { get; set; }

        public string Name { get; set; }
    }
    [TestClass]
    public class BeforeAndAfterMapAction_Test
    {
        [TestMethod]
        public void BeforeAndAfterMapAction()
        {
            var configuration = new MapperConfiguration(cfg => {
                cfg.CreateMap<Source, Destination>()
                  .BeforeMap((src, dest) => src.Value = src.Value + 10)
                  .AfterMap((src, dest) => dest.Name = "John");
            });
            var mapper = configuration.CreateMapper();

            var source = new Source { Value = 5};
            var dest = mapper.Map<Source, Destination>(source);

            dest.Name.ShouldBe("John");
            dest.Value.ShouldBe(15);
        }
    }
}
