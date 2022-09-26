// See https://aka.ms/new-console-template for more information
class Congress : Event
{
    public string Speaker { get; set; }
    public double Price { get; set; }

    public Congress(string title, DateTime date, int maxCapacity, string speaker, double price) : base(title, date, maxCapacity)
    {
        Speaker = speaker;
        Price = price;
    }

    public string FormattedPrice()
    {
        return Math.Round(Price, 2).ToString("0.00");
    }
    public override string ToString()
    {
        return base.ToString() + $" - {Speaker} - {FormattedPrice()}";
    }

}
