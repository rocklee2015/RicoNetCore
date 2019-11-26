using AutoMapper;
using AutoMapper.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Text;

namespace S06.AutoMapperSample.V2_2.S01_1_IncludeMembers
{
    class Source
    {
        public string Name { get; set; }
        public InnerSource InnerSource { get; set; }
        public OtherInnerSource OtherInnerSource { get; set; }
    }
    class InnerSource
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
    class OtherInnerSource
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
    }
    class Destination
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
    }
    [TestClass]
    public class IncludeMembers_Test
    {
        [TestMethod]
        public void IncludeMembers()
        {
            var cfg = new MapperConfigurationExpression();
            cfg.CreateMap<Source, Destination>().IncludeMembers(s => s.InnerSource, s => s.OtherInnerSource);
            cfg.CreateMap<InnerSource, Destination>(MemberList.None);
            cfg.CreateMap<OtherInnerSource, Destination>(MemberList.None);

            var source = new Source
            {
                Name = "name",
                InnerSource = new InnerSource { Description = "description" },
                OtherInnerSource = new OtherInnerSource { Title = "title" }
            };
            var mapperConfig = new MapperConfiguration(cfg);
            IMapper mapper = new Mapper(mapperConfig);
            var destination = mapper.Map<Destination>(source);

            destination.Name.ShouldBe("name");
            destination.Description.ShouldBe("description");
            destination.Title.ShouldBe("title");
        }
    }

}
