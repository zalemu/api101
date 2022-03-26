using api101.Models;
using api101.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api101.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CourseController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<CourseController> _logger;
        private readonly CourseService courseService;
        private readonly IConfiguration configuration;

        public CourseController(ILogger<CourseController> logger, CourseService courseService, IConfiguration configuration)
        {
            _logger = logger;
            this.courseService = courseService;
            this.configuration = configuration;

        }

        [HttpGet]
        public IEnumerable<Course> GetCourses()
        {
            return courseService.GetCourses(configuration.GetConnectionString("conStr"));
        }
        //public IEnumerable<WeatherForecast> Get()
        //{
        //    var rng = new Random();
        //    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //    {
        //        Date = DateTime.Now.AddDays(index),
        //        TemperatureC = rng.Next(-20, 55),
        //        Summary = Summaries[rng.Next(Summaries.Length)]
        //    })
        //    .ToArray();
        //}
    }
}
