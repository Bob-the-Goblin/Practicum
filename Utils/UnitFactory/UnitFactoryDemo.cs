using GamePrototype.Items.EconomicItems;
using GamePrototype.Items.EquipItems;
using GamePrototype.Units;


namespace GamePrototype.Utils.UnitFactory
{
    public abstract class UnitFactoryDemo
    {
        public static Unit CreateGoblinEnemy() => new Goblin(GameConstants.Goblin, 18, 18, 2);

        public static Unit CreateBossEnemy()
        { 
            Goblin boss = new Goblin("HobGoblin", 22, 22, 5);
            boss.AddItemToInventory(new HiddenWeapon(15, 20, "Hammer"));
            return boss;
        }
        
    }
}
