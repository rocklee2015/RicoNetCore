using AutoMapper;
using AutoMapper.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace S06.AutoMapperSample.V2_2.S04_Configuration_Validation
{
    public class Source
    {
        public int SomeValue { get; set; }
    }

    public class Destination
    {
        public int SomeValuefff { get; set; }
    }

    public class Source2
    {
        public int SomeValue { get; set; }
    }

    public class Destination2
    {
        public int SomeValuefff { get; set; }
    }

    [TestClass]
    public class ConfigruationValidation_Test
    {
        [TestMethod]
        public void configuration_validation()
        {
            var configuration = new MapperConfiguration(cfg => cfg.CreateMap<Source, Destination>());

            configuration.AssertConfigurationIsValid();
        }

        [TestMethod]
        public void overriding_configuration_errors()
        {
            var configuration = new MapperConfiguration(cfg => cfg.CreateMap<Source, Destination>()
                                   .ForMember(dest => dest.SomeValuefff, opt => opt.Ignore()));

            configuration.AssertConfigurationIsValid();
        }

        [TestMethod]
        public void selecting_members_to_validate()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Source, Destination>(MemberList.Source);
                cfg.CreateMap<Source2, Destination2>(MemberList.None);//跳过映射验证
            });

            configuration.AssertConfigurationIsValid();
        }
    }
}
