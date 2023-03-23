namespace SendEmailTest.Models
{
    public class EmailData
    {
        public const string Title = "Заявка на запрос";
        public string Sender { get; set; }
        public string Recipient { get; set; }
        public string Text { get; set; }
        public string CompanyName { get; set; }
    }
}
