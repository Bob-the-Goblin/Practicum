using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GamePrototype.Units;
using GamePrototype.Dungeon;
using GamePrototype.Utils.UnitFactory;
using GamePrototype.Utils.DungeonBuilder;

namespace GamePrototype.Utils.Difficulty
{
   public  sealed class DifficultyHard : Difficulty
    {
        public DifficultyHard() 
        { 
        
        }

        public override void SetDifficulty(string name, out Unit unit, out DungeonRoom dungeon)
        {
            unit = UnitFactoryHard.CreatePlayer(name);
            dungeon = DungeonBuilderHard.BuildDungeonHard();
        }   
    }
}
