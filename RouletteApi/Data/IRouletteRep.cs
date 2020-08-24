using System.Collections.Generic;
using RouletteApi.Models;

namespace RouletteApi.Data
{
    public interface IRouletteRep
    {
        bool SaveChanges();
        IEnumerable<Roulette> GetAllRoulettes();
        Roulette GetRouletteById(int id);
        void CreateRoulette(Roulette roulette);   
        void UpdateRoulette(Roulette roulette);
        string GetBets(Roulette rouletteRef, Roulette rouletteNew);

    } 
}