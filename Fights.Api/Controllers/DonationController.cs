using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Fights.Data.Entities;
using Fights.Core.Repositories.Donations;

namespace Fights.Api.Controllers
{
    [Route("api/donations")]
    public class DonationController : BaseController
    {
        private readonly IDonationRepository donationRepository;
        private readonly IMapper mapper;

        public DonationController(
            IDonationRepository donationRepository,
            IMapper mapper
        )
        {
            this.donationRepository = donationRepository;
            this.mapper = mapper;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Donation>> GetAll([FromQuery] string search)
        {
            var donation = this.donationRepository.GetAll(search);
            return Ok(donation);
        }
        [HttpGet("{id}")]
        public ActionResult<Donation> GetOne(long id)
        {
            var entity = this.donationRepository.GetOne(id);
            var donation = this.mapper.Map<Donation>(entity);
            return Ok(donation);
        }
        [HttpPost]
        public ActionResult<Donation> Create(Donation c)
        {
            var donation = this.mapper.Map<Donation>(c);
            donation = this.donationRepository.Create(donation);
            return this.mapper.Map<Donation>(donation);
        }
        [HttpPut("{id}")]
        public ActionResult<Donation> Put(long id, Donation c)
        {
            var donation = this.donationRepository.Update(id, c);
            return Ok(donation);
        }
        [HttpDelete("{id}")]
        public ActionResult<Donation> Delete(long id)
        {
            this.donationRepository.Delete(id);
            return Ok();
        }
    }
}