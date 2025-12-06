using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GamePrototype.Units;
using GamePrototype.Dungeon;
using System.Security.Cryptography.X509Certificates;


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

        public virtual void SetDifficulty(string name, out Unit unit, out DungeonRoom dungeon) 
        {
            unit = UnitFactoryDemo.CreatePlayer(name);
            dungeon = DungeonBuilder.BuildDungeon();
        }

        
           
    }
}
