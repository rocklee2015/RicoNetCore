using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Text;

namespace S06.AutoMapperV9.V2_2.S09_ValueTransformers
{
    public class Source
    {
        public string Value { get; set; }
    }

    public class Destination
    {
        public string Value { get; set; }
    }

    [TestClass]
    public class ValueTransformers_Test
    {
        [TestMethod]
        public void ValueTransformer()
        {
            var configuration = new MapperConfiguration(cfg => cfg.ValueTransformers.Add<string>(val => val + "!!!")); ;

            var source = new Source { Value = "Hello" };

            IMapper mapper = new Mapper(configuration);
            var dest = mapper.Map<Destination>(source);

            dest.Value.ShouldBe("Hello!!!");
        }
    }
}
