using GamePrototype.Items.EconomicItems;
using GamePrototype.Items.EquipItems;
using GamePrototype.Units;


namespace GamePrototype.Utils
{
    public class UnitFactoryDemo
    {
        public static Unit CreatePlayer(string name)
        {
            var player = new Player(name, 30, 30, 6);
            player.AddItemToInventory(new Weapon(10, 15, "Sword"));
            player.AddItemToInventory(new Armour(10, 15, "Armour"));
            player.AddItemToInventory(new HealthPotion("Potion"));
            return player;
        }

        public static Unit CreateGoblinEnemy() => new Goblin(GameConstants.Goblin, 18, 18, 2);

        public static Unit CreatePlayerHard (string name)
        {
            var player = new Player(name, 30, 30, 5);
            player.AddItemToInventory(new Weapon(5, 10, "SmallSword"));
            player.AddItemToInventory(new Armour(10, 10, "Armour"));
            player.AddItemToInventory(new HiddenWeapon(15, 12, "Hammer"));
            player.ReplaceEquipment();
            return player;
        }

        public static Unit CreateBossEnemy() => new Goblin("HobGoblin", 24, 24, 5);
    }
}
