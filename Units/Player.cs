using GamePrototype.Items.EconomicItems;
using GamePrototype.Items.EquipItems;
using GamePrototype.Utils;
using System;
using System.Security.Cryptography;
using System.Text;

namespace GamePrototype.Units
{
    public sealed class Player : Unit
    {
        private readonly Dictionary<EquipSlot, EquipItem> _equipment = new();

        public Player(string name, uint health, uint maxHealth, uint baseDamage) : base(name, health, maxHealth, baseDamage)
        {           
        }

        public override uint GetUnitDamage()
        {
            if (_equipment.TryGetValue(EquipSlot.Weapon, out var item) && item is Weapon weapon) 
            {
                return BaseDamage + weapon.Damage;
            }
            return BaseDamage;
        }

        protected override void DamageReceiveHandler()
        {

            var items = Inventory.Items;
            foreach (var item in items)
            {
                if (item is Armour armour)
                { armour.ReduceDurability(1); }
            }
        }

        public override void HandleCombatComplete()
        {
            var items = Inventory.Items;
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i] is EconomicItem economicItem)
                {
                    UseEconomicItem(economicItem);
                    Inventory.TryRemove(items[i]);
                }
             }
        }

        public override void AddItemToInventory(Item item)
        {
            if (item is EquipItem equipItem && _equipment.TryAdd(equipItem.Slot, equipItem)) 
            {
                // Item was equipped
                return;
            }
            base.AddItemToInventory(item);
            
        }

        private void UseEconomicItem(EconomicItem economicItem)
        {
            if (economicItem is HealthPotion healthPotion) 
            {
                Health += healthPotion.HealthRestore;
            }
            if (economicItem is Grindstone grindstone)
            {
                _equipment[EquipSlot.Armour].Repair(grindstone.ArmourRestore);
            /////    
            }
        }

        protected override uint CalculateAppliedDamage(uint damage)
        {
            if (_equipment.TryGetValue(EquipSlot.Armour, out var item) && item is Armour armour) 
            {
                damage -= (uint)(damage * (armour.Defence / 100f));
            }
            return damage;
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.AppendLine(Name);
            builder.AppendLine($"Health {Health}/{MaxHealth}");
            builder.AppendLine("Loot:");
            var items = Inventory.Items;
            for (int i = 0; i < items.Count; i++) 
            {
                builder.AppendLine($"[{items[i].Name}] : {items[i].Amount}");
            }
            return builder.ToString();
        }

        public override void ReplaceEquipment(EquipItem equipItem)
        {
            Console.WriteLine("You have new equipment! Want to equip it?\nyes/no");
            if (Console.ReadLine() == "yes")
            {
                if (equipItem.Slot == null)
                {
                    _equipment.TryAdd(equipItem.Slot, equipItem);
                }
                else
                {
                    if (equipItem is Weapon weapon)
                    {
                        _equipment[EquipSlot.freeSlot2] = _equipment[EquipSlot.Weapon];
                        _equipment[EquipSlot.Weapon] = equipItem;
                    }

                    if (equipItem is Armour armour)
                    {
                        _equipment[EquipSlot.freeSlot2] = _equipment[EquipSlot.Armour];
                        _equipment [EquipSlot.Armour] = equipItem;
                    }

                }
            }
        }


    }
}
