using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Roulette.Models;
using Roulette.Data;

namespace Roulette.Controllers
{
    [ApiController]
    [Route("api/[controler]")]
    public class RoulettesController : ControllerBase
    {
        private readonly IRoulettetRep _repository;

        public RoulettesController(IRoulettetRep repository)
        {
            _repository = repository;
        }
        
        [HttpGet]
        public ActionResult <IEnumerable<Roulette>> GetAllRoulettes()
        {

        }
        [HttpGet("{id}")]
        public ActionResult <Roulette> GetRouletteById(int id)
        {

        }
    }
}