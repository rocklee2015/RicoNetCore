using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Text;

namespace S06.AutoMapperV9.V2_2.S08_Custom_Value_Resolvers
{
    public class Source
    {
        public int Value1 { get; set; }
        public int Value2 { get; set; }
    }

    public class Destination
    {
        public int Total { get; set; }
    }

    [TestClass]
    public class CustomValueResolvers_Test
    {
        [TestMethod]
        public void CustomValueResolvers()
        {
            var configuration = new MapperConfiguration(cfg => cfg.CreateMap<Source, Destination>()
             .ForMember(dest => dest.Total, opt => opt.MapFrom<CustomResolver>()));

            configuration.AssertConfigurationIsValid();

            var source = new Source
            {
                Value1 = 5,
                Value2 = 7
            };
            IMapper mapper = new Mapper(configuration);
            var result = mapper.Map<Source, Destination>(source);

            result.Total.ShouldBe(12);
        }

        public class CustomResolver : IValueResolver<Source, Destination, int>
        {
            public int Resolve(Source source, Destination destination, int member, ResolutionContext context)
            {
                return source.Value1 + source.Value2;
            }
        }
    }
}
