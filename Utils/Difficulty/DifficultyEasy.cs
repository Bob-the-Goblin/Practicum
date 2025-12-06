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
    public sealed class DifficultyEasy : Difficulty
    {
        public DifficultyEasy()
        {
            
        }

        public override void SetDifficulty(string name, out Unit player, out DungeonRoom dungeon)
        {
            base.SetDifficulty(name, out player, out dungeon);
        }

    }
}
