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
    public abstract class Difficulty
    {
        private Unit player;
        private DungeonRoom dungeon;
        public string GetDifficultyString() 
        {
            return $"Let set difficulty for your adventure\n" +
                $"Type {DifficultyLevel.easy} = {(int)DifficultyLevel.easy}" +
                $"or {DifficultyLevel.hard} = {(int)DifficultyLevel.hard}";
        }

        public virtual void SetDifficulty(string name, out Unit player, out DungeonRoom dungeon)
        {
            player = UnitFactoryEasy.CreatePlayer(name);
            dungeon = DungeonBuilderEasy.BuildDungeon();


        }           
    }
}
