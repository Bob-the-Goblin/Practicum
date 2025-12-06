using GamePrototype.Items.EconomicItems;
using GamePrototype.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamePrototype.Items.EquipItems
{
    public sealed class HiddenWeapon : EquipItem
    {
        public override EquipSlot Slot => EquipSlot.freeSlot;

        public uint Damage { get; }
        public HiddenWeapon(uint damage, uint durability, string name) : base(durability, name) => Damage = damage;

        public void Repair(Grindstone grindstone)
        {
            Durability += grindstone.ArmourRestore;
        }

    }
}
