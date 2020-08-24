using System;
using System.Collections.Generic;
using System.Linq;
using RouletteApi.Models;

namespace RouletteApi.Data
{
    public class SqlRouletteRep : IRouletteRep
    {
        private readonly RouletteContext _context;

        public SqlRouletteRep(RouletteContext context)
        {
            _context = context;      
        }

        public void CreateRoulette(Roulette roulette)
        {
            if (roulette == null)
            {
                throw new ArgumentNullException(nameof(roulette));
            }
            _context.Roulettes.Add(roulette);        
        }

        public IEnumerable<Roulette> GetAllRoulettes()
        {
            return _context.Roulettes.ToList();
        }

        public Roulette GetRouletteById(int id)
        {
            return _context.Roulettes.FirstOrDefault(p => p.Id == id);
        }

        public string GetBets(Roulette rouletteRef, Roulette rouletteNew)
        {
            string results = "";
            string oldBet = rouletteRef.Bets;
            string newBet = rouletteNew.Bets;
            Random r = new Random();
            string currentlyBet = "{" + newBet + ", UserId: "+ r.Next(1, 50) + "}"; 

            if (rouletteNew.State == "Open" && newBet != "")
            {   
                results = currentlyBet;
            }
            else if (rouletteNew.State == "Close")
            {
                if(oldBet != "")
                {
                    results = oldBet + currentlyBet;
                }                 
                results = currentlyBet + ", ";             
            }          

            return results;
        }
        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateRoulette(Roulette roulette)
        {

        }
    }
}