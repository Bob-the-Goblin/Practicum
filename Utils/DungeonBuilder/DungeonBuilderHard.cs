using GamePrototype.Dungeon;
using GamePrototype.Items.EconomicItems;
using GamePrototype.Items.EquipItems;
using GamePrototype.Utils.UnitFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamePrototype.Utils.DungeonBuilder
{
    public class DungeonBuilderHard : DungeonBuilder
    {
        public DungeonBuilderHard() { }

        public static DungeonRoom BuildDungeonHard()
        {
            var enter = new DungeonRoom("Enter");
            var monsterRoom = new DungeonRoom("Monster", UnitFactoryDemo.CreateGoblinEnemy());
            var lootRoom = new DungeonRoom("Loot", new Weapon (15, 20, "Axe"));
            var emptyRoom = new DungeonRoom("Empty");
            var emptyRoom2 = new DungeonRoom("Empty");
            var bossRoom = new DungeonRoom("Boss", UnitFactoryDemo.CreateBossEnemy());
            var lootStoneRoom = new DungeonRoom("Loot", new Grindstone("Stone"));
            var lootRoomGold = new DungeonRoom("Loot", new Gold());
            var finalRoom = new DungeonRoom("Final", new Grindstone("Stone1"));

            enter.TrySetDirection(Direction.Left, lootRoom);
            enter.TrySetDirection(Direction.Right, monsterRoom);

            lootRoom.TrySetDirection(Direction.Forward, emptyRoom);
            monsterRoom.TrySetDirection(Direction.Forward, emptyRoom2);
            monsterRoom.TrySetDirection(Direction.Left, emptyRoom);

            emptyRoom.TrySetDirection(Direction.Forward, lootStoneRoom);
            emptyRoom.TrySetDirection(Direction.Right, bossRoom);

            lootStoneRoom.TrySetDirection(Direction.Forward, lootRoomGold);

            lootRoomGold.TrySetDirection(Direction.Forward, finalRoom);
            lootRoomGold.TrySetDirection(Direction.Right, bossRoom);

            emptyRoom2.TrySetDirection(Direction.Forward, bossRoom);

            bossRoom.TrySetDirection(Direction.Forward, finalRoom);

            return enter;
        }
    }
}
