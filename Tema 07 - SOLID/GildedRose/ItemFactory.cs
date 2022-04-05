using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRoseKata
{
    public class ItemFactory
    {
        public enum ItemType
        {
            AgedBrie, Backstage, Sulfuras, Unknown, Conjured
        }

        public static Item createItem(ItemType itemType, string name, int sellIn, int quality)
        {
            switch (itemType)
            {
                case ItemType.AgedBrie: return new AgeBrie(name, sellIn, quality);
                case ItemType.Backstage: return new BackStage(name, sellIn, quality);
                case ItemType.Sulfuras: return new Sulfuras(name, sellIn, quality);
                case ItemType.Conjured: return new Conjured(name, sellIn, quality);
                case ItemType.Unknown: return new Item(name, sellIn, quality);
            }
            throw new ArgumentException($"The item type {itemType} is not recognized.");
        }

    }
}
