using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Fights.Data.Entities;
using Fights.Core.Repositories.Cities;

namespace Fights.Api.Controllers
{
    [Route("api/cities")]
    public class CityController : BaseController
    {
        private readonly ICityRepository cityRepository;
        private readonly IMapper mapper;

        public CityController(
            ICityRepository cityRepository,
            IMapper mapper
        )
        {
            this.cityRepository = cityRepository;
            this.mapper = mapper;
        }
        [HttpGet]
        public ActionResult<IEnumerable<City>> GetAll([FromQuery] string search)
        {
            var city = this.cityRepository.GetAll(search);
            return Ok(city);
        }
        [HttpGet("{id}")]
        public ActionResult<City> GetOne(long id)
        {
            var entity = this.cityRepository.GetOne(id);
            var city = this.mapper.Map<City>(entity);
            return Ok(city);
        }
        [HttpPost]
        public ActionResult<City> Create(City c)
        {
            var city = this.mapper.Map<City>(c);
            city = this.cityRepository.Create(city);
            return this.mapper.Map<City>(city);
        }
        [HttpPut("{id}")]
        public ActionResult<City> Put(long id, City c)
        {
            var city = this.cityRepository.Update(id, c);
            return Ok(city);
        }
        [HttpDelete("{id}")]
        public ActionResult<City> Delete(long id)
        {
            this.cityRepository.Delete(id);
            return Ok();
        }
    }
}