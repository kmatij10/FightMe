using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Fights.Data.Entities;
using Fights.Core.Repositories.Swipes;

namespace Fights.Api.Controllers
{
    [Route("api/swipes")]
    public class SwipeController : BaseController
    {
        private readonly ISwipeRepository swipeRepository;
        private readonly IMapper mapper;

        public SwipeController(
            ISwipeRepository swipeRepository,
            IMapper mapper
        )
        {
            this.swipeRepository = swipeRepository;
            this.mapper = mapper;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Swipe>> GetAll([FromQuery] string search)
        {
            var swipe = this.swipeRepository.GetAll(search);
            return Ok(swipe);
        }
        [HttpGet("{id}")]
        public ActionResult<Swipe> GetOne(long id)
        {
            var entity = this.swipeRepository.GetOne(id);
            var swipe = this.mapper.Map<Swipe>(entity);
            return Ok(swipe);
        }
        [HttpPost]
        public ActionResult<Swipe> Create(Swipe c)
        {
            var swipe = this.mapper.Map<Swipe>(c);
            swipe = this.swipeRepository.Create(swipe);
            return this.mapper.Map<Swipe>(swipe);
        }
        [HttpPut("{id}")]
        public ActionResult<Swipe> Put(long id, Swipe c)
        {
            var swipe = this.swipeRepository.Update(id, c);
            return Ok(swipe);
        }
        [HttpDelete("{id}")]
        public ActionResult<Swipe> Delete(long id)
        {
            this.swipeRepository.Delete(id);
            return Ok();
        }
    }
}