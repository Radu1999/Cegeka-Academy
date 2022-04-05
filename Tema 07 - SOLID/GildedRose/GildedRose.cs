using System.Collections.Generic;

namespace GildedRoseKata
{
    public class GildedRose
    {
        private const string AgedBrie = "Aged Brie";
        private const string Backstage = "Backstage passes to a TAFKAL80ETC concert";
        private const string Sulfuras = "Sulfuras, Hand of Ragnaros";
        private const string Conjured = "Conjured, idk";

        IList<Item> Items;
        public GildedRose(IList<Item> Items)
        {
            //aplicati Factory Pattern on init
            IList<Item> mItems = new List<Item>();
            foreach (Item item in Items)
            {
                var (name, sellIn, quality) = (item.Name, item.SellIn, item.Quality);
                ItemFactory.ItemType type = ItemFactory.ItemType.Unknown;
                switch(item.Name)
                {
                    case AgedBrie:
                        type = ItemFactory.ItemType.AgedBrie;
                        break;
                    case Backstage:
                        type = ItemFactory.ItemType.Backstage;
                        break;
                    case Sulfuras:
                        type = ItemFactory.ItemType.Sulfuras;
                        break;
                    case Conjured:
                        type = ItemFactory.ItemType.Conjured;
                        break;
                }

                mItems.Add(ItemFactory.createItem(type, name, sellIn, quality));
            }
            this.Items = mItems;
        }

        public void UpdateQuality()
        {
            foreach (var item in Items)
            {
                item.ChangeDay();
                item.updateQuality();
            }
        }

        public Item getItem(int pos)
        {
            if(pos >= Items.Count)
            {
                return null;
            }
            return Items[pos];
        }
    }
}
