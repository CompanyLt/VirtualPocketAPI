namespace VirtualPocket.Model.Market
{
    public class ProductSetForm
    {
        // Jei ID generuojamas rankiniu būdu (jei DB yra IDENTITY, šio lauko galite nenaudoti)
       

        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public decimal Price { get; set; }

        public int Category { get; set; }

        public int Assign { get; set; }

        public string Status { get; set; } = string.Empty;
    }
}
