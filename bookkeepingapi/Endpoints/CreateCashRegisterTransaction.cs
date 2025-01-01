using bookkeeper.Data;
using bookkeeper.Models;
using FastEndpoints;

namespace bookkeeper.Endpoints
{
    public class CreateCashRegisterTransaction : Endpoint<CashRegisterRequest, CashRegisterResponse>
    {
        private readonly AppDbContext _dbContext;

        public CreateCashRegisterTransaction(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public override void Configure()
        {
            Verbs(Http.POST);
            Routes("/cashregister");
            AllowAnonymous();
        }

        public override async Task HandleAsync(CashRegisterRequest req, CancellationToken ct)
        {
            // Create a Journal entry
            var journal = new Journal
            {
                Date = req.Date,
                Description = req.Description,
                Account = "Cash Account",
                Debit = req.TransactionType == "Sale" ? req.Amount : 0,
                Credit = req.TransactionType == "Refund" ? req.Amount : 0
            };

            // Create a CashRegister entry
            var cashRegister = new CashRegister
            {
                TransactionType = req.TransactionType,
                Amount = req.Amount,
                Date = req.Date,
                Journal = journal // Link the Journal
            };

            _dbContext.CashRegisters.Add(cashRegister);
            await _dbContext.SaveChangesAsync(ct);

            await SendAsync(new CashRegisterResponse
            {
                Message = "Cash Register entry created successfully."
            });
        }
    }

    public class CashRegisterRequest
    {
        public string TransactionType { get; set; } // Sale or Refund
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; } // Description for the Journal
    }

    public class CashRegisterResponse
    {
        public string Message { get; set; }
    }
}
