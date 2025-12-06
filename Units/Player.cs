using GamePrototype.Items.EconomicItems;
using GamePrototype.Items.EquipItems;
using GamePrototype.Utils;
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
            for (int i = 0; i < items.Count; i++)
            {if (items[i] is Armour armour)
                {
                    armour.LoseDurability();
                }         
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
                if (items[i] is Weapon weapon)
                { for (int j = 0; j < items.Count; j++)
                    {
                        if (items[j] is Grindstone grindstone) 
                        { 
                            weapon.Repair(grindstone);
                            Inventory.TryRemove(items[j]);
                        }
                    }
                    
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


        public void ReplaceEquipment()
        {
            
            Console.WriteLine($"Do you want to equip your hidden weapon? \nyes/no");
            if (Console.ReadLine() == "yes")
            {
                EquipItem replaced = _equipment[EquipSlot.Weapon];
                _equipment[EquipSlot.Weapon] = _equipment[EquipSlot.freeSlot];
                _equipment[EquipSlot.freeSlot] = replaced;

                Console.WriteLine("Sucsses");
                //I hope
            }
            else Console.WriteLine(); 
        }

        public void EquipHidden( EquipItem replaced)
        {
            if (_equipment[EquipSlot.Weapon] == null)
            {
                _equipment[EquipSlot.Weapon] = _equipment[EquipSlot.freeSlot];
                _equipment.Remove(EquipSlot.freeSlot);
                Console.WriteLine($"{Name} equip hidden weapon!");
            }
        }
    }
}
