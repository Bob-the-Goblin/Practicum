using GamePrototype.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamePrototype.Items.EquipItems
{
    public sealed class Accessories : EquipItem
    {
        public override EquipSlot Slot =>  EquipSlot.Accessiories;

        public uint Defence;
        public Accessories(uint maxDurability, string name) : base(maxDurability, name)
        {
        }
    }
}
