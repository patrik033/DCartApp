namespace DCartWeb.Models.ViewModels
{
    public record AveragePrice
    {
        public int Month { get; set; }
        public decimal Price { get; set; }
    }
}
