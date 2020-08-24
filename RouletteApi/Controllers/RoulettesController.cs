using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using RouletteApi.Data;
using RouletteApi.DTOs;
using RouletteApi.Models;

namespace RouletteApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoulettesController : ControllerBase
    {
        private readonly IRouletteRep _repository;
        private readonly IMapper _mapper;

        public RoulettesController(IRouletteRep repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        
        [HttpGet]
        public ActionResult <IEnumerable<RouletteReadDTO>> GetAllRoulettes()
        {
            var roulettes = _repository.GetAllRoulettes();
            return Ok(_mapper.Map<IEnumerable<RouletteReadDTO>>(roulettes));
        }
        [HttpGet("{id}")]
        public ActionResult <Roulette> GetRouletteById(int id)
        {
            var rouletteItem = _repository.GetRouletteById(id);
            if(rouletteItem != null)
            {
                return Ok(rouletteItem);
            }
            return NotFound();
        }
        [HttpPost]
        public ActionResult <RouletteCreateDTO> CreateRoulette()
        {        
            var newRoulette = new Roulette();
            newRoulette.State = "Open";
            newRoulette.Bets = "";
            _repository.CreateRoulette(newRoulette);
            _repository.SaveChanges();
            var rouletteCreateDTO = _mapper.Map<RouletteCreateDTO>(newRoulette);
            return Ok(rouletteCreateDTO);
        }
        [HttpPatch("{id}")]
        public ActionResult PartialUpdateCommand(int id, JsonPatchDocument<RouletteUpdateDTO> patchDocument)
        {        
            var rouletteFromRepo = _repository.GetRouletteById(id);
            if(rouletteFromRepo == null)
            {
                
                return NotFound();
            } 

            var rouletteToPatch = _mapper.Map<RouletteUpdateDTO>(rouletteFromRepo);
            patchDocument.ApplyTo(rouletteToPatch, ModelState);
            if(!TryValidateModel(rouletteToPatch))
            {

                return ValidationProblem(ModelState);
            }  

            _mapper.Map(rouletteToPatch, rouletteFromRepo);      
            _repository.UpdateRoulette(rouletteFromRepo);
            _repository.SaveChanges();

            rouletteFromRepo.Bets = _repository.GetBets(rouletteFromRepo, _mapper.Map<Roulette>(rouletteToPatch));
            return Ok(_repository.GetRouletteById(id));
        }

    }
}