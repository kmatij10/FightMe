using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Fights.Data.Entities;
using Fights.Core.Repositories.Fights;

namespace Fights.Api.Controllers
{
    [Route("api/fights")]
    public class FightController :  BaseController
    {
        private readonly IFightRepository fightRepository;
        private readonly IMapper mapper;

        public FightController(
            IFightRepository fightRepository,
            IMapper mapper
        )
        {
            this.fightRepository = fightRepository;
            this.mapper = mapper;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Fight>> GetAll([FromQuery] string search)
        {
            var fight = this.fightRepository.GetAll(search);
            return Ok(fight);
        }
        [HttpGet("{id}")]
        public ActionResult<Fight> GetOne(long id)
        {
            var entity = this.fightRepository.GetOne(id);
            var fight = this.mapper.Map<Fight>(entity);
            return Ok(fight);
        }
        [HttpPost]
        public ActionResult<Fight> Create(Fight c)
        {
            var fight = this.mapper.Map<Fight>(c);
            fight = this.fightRepository.Create(fight);
            return this.mapper.Map<Fight>(fight);
        }
        [HttpPut("{id}")]
        public ActionResult<Fight> Put(long id, Fight c)
        {
            var fight = this.fightRepository.Update(id, c);
            return Ok(fight);
        }
        [HttpDelete("{id}")]
        public ActionResult<Fight> Delete(long id)
        {
            this.fightRepository.Delete(id);
            return Ok();
        }
    }
}