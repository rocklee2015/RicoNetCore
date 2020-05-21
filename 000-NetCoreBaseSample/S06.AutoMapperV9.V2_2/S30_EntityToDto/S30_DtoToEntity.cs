using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Text;

namespace S06.AutoMapperV9.V2_2.S30_EntityToDto
{

    public class Student
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public string Favorite { get; set; }

        public string Sport { get; set; }
    }

    public class StudentDto
    {
        public string Favorite { get; set; }

        public int Age { get; set; }
    }

    [TestClass]
    public class S30_DtoToEntity
    {
        [TestMethod]
        public void Test()
        {
            var configuration = new MapperConfiguration(cfg =>
   cfg.CreateMap<StudentDto, Student>());

            var student = new Student()
            {
                Id = 1,
                Age = 18,
                Favorite = "电影，苹果,音乐",
                Sport = "羽毛球，乒乓球"
            };
            var stuDto = new StudentDto()
            {
                Age = 20,
                Favorite = "香蕉，编程"
            };
            IMapper mapper = new Mapper(configuration);
            student = mapper.Map<Student>(stuDto);

            student.Id.ShouldBe(1);

        }

        [TestMethod]
        public void AddMonth()
        {
            var date = new DateTime(2019, 4, 6);

            var date2 = date.AddMonths(1);

            Console.WriteLine(date2.ToString("yyyy-MM-dd"));

            Console.WriteLine(date2.Subtract(date).Days);
        }
    }
}
