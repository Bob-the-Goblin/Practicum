using GamePrototype.Items.EquipItems;
using GamePrototype.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamePrototype.Utils.UnitFactory
{
    internal class UnitFactoryHard
    {
        public UnitFactoryHard() { }
        public static Unit CreatePlayer(string name)
        {
            var player = new Player(name, 30, 30, 5);
            player.AddItemToInventory(new Weapon(5, 10, "SmallSword"));
            player.AddItemToInventory(new Armour(10, 10, "Armour"));
            return player;
        }

       
    }
}
