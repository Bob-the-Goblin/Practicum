using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GamePrototype.Units;
using GamePrototype.Dungeon;
using GamePrototype.Utils.Difficulty;

namespace GamePrototype.Utils.Difficulty
{
   public  sealed class DifficultyHard : Difficulty
    {
        public DifficultyHard() 
        { 
        
        }

        public override void SetDifficulty(string name, out Unit unit, out DungeonRoom dungeon)
        {
            unit = UnitFactoryDemo.CreatePlayerHard(name);
            dungeon = DungeonBuilder.BuildDungeonHard();
        }   
    }
}
