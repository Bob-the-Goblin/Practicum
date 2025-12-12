using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GamePrototype.Units;
using GamePrototype.Dungeon;
using GamePrototype.Utils.Difficulty;
using GamePrototype.Utils.UnitFactory;
using GamePrototype.Utils.DungeonBuilder;

namespace GamePrototype.Utils.Difficulty
{
    public sealed class DifficultyEasy : Difficulty
    {
        public DifficultyEasy()
        {
            
        }

        public override void SetDifficulty(string name, out Unit player, out DungeonRoom dungeon)
        {
            player = UnitFactoryEasy.CreatePlayer(name);
            dungeon = DungeonBuilderEasy.BuildDungeon();
        }

    }
}
