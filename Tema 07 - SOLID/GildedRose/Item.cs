namespace GildedRoseKata
{
    public class Item
    {
        public string Name { get; set; }
        public int SellIn { get; set; }
        public int Quality { get; set; }
        public Item() { }

        public Item(string name, int sellIn, int quality)
        {
            Name = name;
            SellIn = sellIn;
            Quality = quality;
        }

        public void ChangeDay()
        {
            if (SellIn > 0)
            {
                SellIn--;
            }

        }

        public virtual void updateQuality()
        {
            if (Quality > 0)
            {
                Quality -= 1;
            }

        }
    }

    public class AgeBrie : Item
    {
        public AgeBrie(string name, int sellIn, int quality) : base(name, sellIn, quality)
        {
        }

        public override void updateQuality()
        {
            if (Quality >= 50)
            {
                return;
            }

            Quality += 1;
        }
    }

    public class BackStage : Item
    {
        public BackStage(string name, int sellIn, int quality) : base(name, sellIn, quality)
        {
        }

        public override void updateQuality()
        {
            if(SellIn == 0)
            {
                Quality = 0;
                return;
            }
            if (SellIn < 11)
            {
                if (Quality < 50)
                {
                    Quality = Quality + 2;
                }
            } else if (SellIn < 6)
            {
                if (Quality < 50)
                {
                    Quality = Quality + 3;
                }
            }

        }
    }


    public class Sulfuras : Item
    {
        public Sulfuras(string name, int sellIn, int quality) : base(name, sellIn, quality)
        {
        }

        public override void updateQuality()
        {
        }

        public new void ChangeDay()
        {
        }
    }

    public class Conjured : Item
    {
        public Conjured(string name, int sellIn, int quality) : base(name, sellIn, quality)
        {
            
        }
        public override void updateQuality()
        {
            if (Quality > 0)
            {
                Quality -= 2;
            }
        }

    }
}
