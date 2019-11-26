using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Text;

namespace S06.AutoMapperV9.V2_2.S03_Projection
{
    public class CalendarEvent
    {
        public DateTime Date { get; set; }
        public string Title { get; set; }
    }
    public class CalendarEventForm
    {
        public DateTime EventDate { get; set; }
        public int EventHour { get; set; }
        public int EventMinute { get; set; }
        public string Title { get; set; }
    }
    [TestClass]
    public class Projection_Test
    {
        [TestMethod]
        public void Projection()
        {
            //模型
            var calendarEvent = new CalendarEvent
            {
                Date = new DateTime(2008, 12, 15, 20, 30, 0),
                Title = "Company Holiday Party"
            };

            //配置AutoMapper
            var configuration = new MapperConfiguration(cfg =>
              cfg.CreateMap<CalendarEvent, CalendarEventForm>()
                .ForMember(dest => dest.EventDate, opt => opt.MapFrom(src => src.Date.Date))
                .ForMember(dest => dest.EventHour, opt => opt.MapFrom(src => src.Date.Hour))
                .ForMember(dest => dest.EventMinute, opt => opt.MapFrom(src => src.Date.Minute)));

            //执行映射
            IMapper mapper = new Mapper(configuration);
            CalendarEventForm form = mapper.Map<CalendarEvent, CalendarEventForm>(calendarEvent);

            form.EventDate.ShouldBe(new DateTime(2008, 12, 15));
            form.EventHour.ShouldBe(20);
            form.EventMinute.ShouldBe(30);
            form.Title.ShouldBe("Company Holiday Party");
        }
    }
}
