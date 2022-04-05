using Xunit;
using System.Collections.Generic;
using GildedRoseKata;

namespace GildedRoseTests
{
    public class GildedRoseTest
    {
        [Theory]
        [InlineData("Aged Brie", 15, 3)]
        public void GivenAgedBrieTypeWhenUpdateQualityThenIncrementQuality(string name, int sellIn, int quality)
        {
            var item = new Item(name, sellIn, quality);
            IList<Item> Items = new List<Item>();
            Items.Add(item);

            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();

            Assert.Equal(4, app.getItem(0).Quality);
        }

        [Theory]
        [InlineData("Conjured, idk", 15, 3)]
        public void GivenConjuredTypeWhenUpdateQualityThenDecrementQualityTwiceAsFast(string name, int sellIn, int quality)
        {
            var item = new Item(name, sellIn, quality);
            IList<Item> Items = new List<Item>();
            Items.Add(item);

            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();

            Assert.Equal(1, app.getItem(0).Quality);
        }

        [Theory]
        [InlineData("Sulfuras, Hand of Ragnaros", 15, 3)]
        public void GivenSulfurasTypeWhenUpdateQualityThenQualityUnchanged(string name, int sellIn, int quality)
        {
            var item = new Item(name, sellIn, quality);
            IList<Item> Items = new List<Item>();
            Items.Add(item);

            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();

            Assert.Equal(3, app.getItem(0).Quality);
        }
    }
}
