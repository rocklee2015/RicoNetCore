using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace S06.AutoMapperV9.V2_2.S05_ListArray
{
    public class Source
    {
        public int Value { get; set; }
    }

    public class Destination
    {
        public int Value { get; set; }
    }
    public class ParentSource
    {
        public int Value1 { get; set; }
    }

    public class ChildSource : ParentSource
    {
        public int Value2 { get; set; }
    }

    public class ParentDestination
    {
        public int Value1 { get; set; }
    }

    public class ChildDestination : ParentDestination
    {
        public int Value2 { get; set; }
    }
    [TestClass]
    public class ListArray_Test
    {
        [TestMethod]
        public void ListArray()
        {
            var configuration = new MapperConfiguration(cfg => cfg.CreateMap<Source, Destination>());

            var sources = new[]
            {
                new Source { Value = 5 },
                new Source { Value = 6 },
                new Source { Value = 7 }
            };
            IMapper mapper = new Mapper(configuration);

            IEnumerable<Destination> ienumerableDest = mapper.Map<Source[], IEnumerable<Destination>>(sources);
            ICollection<Destination> icollectionDest = mapper.Map<Source[], ICollection<Destination>>(sources);
            IList<Destination> ilistDest = mapper.Map<Source[], IList<Destination>>(sources);
            List<Destination> listDest = mapper.Map<Source[], List<Destination>>(sources);
            Destination[] arrayDest = mapper.Map<Source[], Destination[]>(sources);

            ienumerableDest.Count().ShouldBe(3);
            icollectionDest.Count().ShouldBe(3);
            ilistDest.Count().ShouldBe(3);
            listDest.Count().ShouldBe(3);
            arrayDest.Count().ShouldBe(3);
        }

        [TestMethod]
        public void Polymorphic_element_types_in_collections()
        {
            var configuration = new MapperConfiguration(c =>
            {
                c.CreateMap<ParentSource, ParentDestination>()
                     .Include<ChildSource, ChildDestination>();
                c.CreateMap<ChildSource, ChildDestination>();
            });

            var sources = new[]
                {
        new ParentSource(),
        new ChildSource(),
        new ParentSource()
    };
            IMapper mapper = new Mapper(configuration);
            var destinations = mapper.Map<ParentSource[], ParentDestination[]>(sources);

            destinations[0].ShouldBeAssignableTo<ParentDestination>();
            destinations[1].ShouldBeAssignableTo<ChildDestination>();
            destinations[2].ShouldBeAssignableTo<ParentDestination>();
        }
    }
}
