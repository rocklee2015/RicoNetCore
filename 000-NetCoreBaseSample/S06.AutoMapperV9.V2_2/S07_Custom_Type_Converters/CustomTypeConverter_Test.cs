using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace S06.AutoMapperV9.V2_2.S07_Custom_Type_Converters
{
    public class Source
    {
        public string Value1 { get; set; }
        public string Value2 { get; set; }
        public string Value3 { get; set; }
    }

    public class Destination
    {
        public int Value1 { get; set; }
        public DateTime Value2 { get; set; }
        public Type Value3 { get; set; }
    }
    [TestClass]
    public class CustomTypeConverter_Test
    {
        [TestMethod]
        public void CustomTypeConverter()
        {
            var configuration = new MapperConfiguration(cfg => {
                cfg.CreateMap<string, int>().ConvertUsing(s => Convert.ToInt32(s));
                cfg.CreateMap<string, DateTime>().ConvertUsing(new DateTimeTypeConverter());
                cfg.CreateMap<string, Type>().ConvertUsing<TypeTypeConverter>();
                cfg.CreateMap<Source, Destination>();
            });
            configuration.AssertConfigurationIsValid();

            var source = new Source
            {
                Value1 = "5",
                Value2 = "01/01/2000",
                Value3 = "S06.AutoMapperV9.V2_2.S07_Custom_Type_Converters.Destination"
            };
            IMapper mapper = new Mapper(configuration);
            Destination result = mapper.Map<Source, Destination>(source);
            result.Value3.ShouldBe(typeof(Destination));
        }
        public class DateTimeTypeConverter : ITypeConverter<string, DateTime>
        {
            public DateTime Convert(string source, DateTime destination, ResolutionContext context)
            {
                return System.Convert.ToDateTime(source);
            }
        }

        public class TypeTypeConverter : ITypeConverter<string, Type>
        {
            public Type Convert(string source, Type destination, ResolutionContext context)
            {
                return Assembly.GetExecutingAssembly().GetType(source);
            }
        }
    }
}
