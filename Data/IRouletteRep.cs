using System.Collections.Generic;
using Roulette.Models;

namespace Roulette.Data
{
    public interface IRouletteRep
    {
        IEnumerable<Roulette> GetAllRoulettes();
        Roulette GetRouletteById(int id);
    } 
}