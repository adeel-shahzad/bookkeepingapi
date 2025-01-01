namespace bookkeeper.Models
{
    public class CashRegister
    {
        public int Id { get; set; } // Primary Key
        public string TransactionType { get; set; } // Sale, Refund, etc.
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }

        // Foreign Key for Journal
        public int JournalId { get; set; }
        public Journal Journal { get; set; }
    }
}
