using GamePrototype.Dungeon;
using GamePrototype.Items.EconomicItems;
using GamePrototype.Items.EquipItems;

namespace GamePrototype.Utils
{
    public static class DungeonBuilder
    {
        public static DungeonRoom BuildDungeon()
        {
            var enter = new DungeonRoom("Enter");
            var monsterRoom = new DungeonRoom("Monster", UnitFactoryDemo.CreateGoblinEnemy());
            var emptyRoom = new DungeonRoom("Empty");
            var lootRoom = new DungeonRoom("Loot1", new Gold());
            var lootStoneRoom = new DungeonRoom("Loot1", new Grindstone("Stone"));
            var finalRoom = new DungeonRoom("Final", new Grindstone("Stone1"));

            enter.TrySetDirection(Direction.Right, monsterRoom);
            enter.TrySetDirection(Direction.Left, emptyRoom);

            monsterRoom.TrySetDirection(Direction.Forward, lootRoom);
            monsterRoom.TrySetDirection(Direction.Left, emptyRoom);

            emptyRoom.TrySetDirection(Direction.Forward, lootStoneRoom);

            lootRoom.TrySetDirection(Direction.Forward, finalRoom);
            lootStoneRoom.TrySetDirection(Direction.Forward, finalRoom);

            return enter;
        }

        public static DungeonRoom BuildDungeonHard()
        {
            var enter = new DungeonRoom("Enter");
            var monsterRoom = new DungeonRoom("Monster", UnitFactoryDemo.CreateGoblinEnemy());
            var lootRoom = new DungeonRoom("Loot", new Gold());
            var emptyRoom = new DungeonRoom("Empty");
            var emptyRoom2 = new DungeonRoom("Empty");
            var bossRoom = new DungeonRoom("Boss", UnitFactoryDemo.CreateBossEnemy());
            var lootStoneRoom = new DungeonRoom("Loot", new Grindstone("Stone"));
            var lootRoomGold = new DungeonRoom("Loot", new Gold());
            var finalRoom = new DungeonRoom ("Final", new Grindstone("Stone1"));

            enter.TrySetDirection(Direction.Left, lootRoom);
            enter.TrySetDirection(Direction.Right, monsterRoom);

            lootRoom.TrySetDirection(Direction.Forward, emptyRoom);
            monsterRoom.TrySetDirection (Direction.Forward, emptyRoom2);
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
