using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Text;

namespace S06.AutoMapperV9.V2_2.S10_NullSubstitution
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
    public class NullSubstitution_Test
    {
        [TestMethod]
        public void NullSubstitution()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Source, Destination>()
    .ForMember(destination => destination.Value, opt => opt.NullSubstitute("Other Value")));

            var source = new Source { Value = null };
            var mapper = config.CreateMapper();
            var dest = mapper.Map<Source, Destination>(source);

            dest.Value.ShouldBe("Other Value");

            source.Value = "Not null";

            dest = mapper.Map<Source, Destination>(source);

            dest.Value.ShouldBe("Not null");
        }
    }
}
