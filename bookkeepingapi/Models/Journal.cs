namespace bookkeeper.Models
{
    public class Journal
    {
        public int Id { get; set; } // Primary Key
        public DateTime Date { get; set; } // Transaction Date
        public string Description { get; set; } // Description of the transaction
        public string Account { get; set; } // Account involved
        public decimal Debit { get; set; } // Debit amount
        public decimal Credit { get; set; } // Credit amount

        // Relationship with CashRegister
        public List<CashRegister> CashRegisters { get; set; }
    }
}
