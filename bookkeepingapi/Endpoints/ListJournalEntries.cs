using bookkeeper.Data;
using bookkeeper.Models;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;

namespace bookkeeper.Endpoints
{
    public class ListJournalEntries : EndpointWithoutRequest<List<JournalResponse>>
    {
        private readonly AppDbContext _dbContext;

        public ListJournalEntries(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public override void Configure()
        {
            Verbs(Http.GET);
            Routes("/journals");
            AllowAnonymous();
        }

        public override async Task HandleAsync(CancellationToken ct)
        {
            var journals = await _dbContext.Journals
                .Include(j => j.CashRegisters)
                .ToListAsync(ct);

            var response = journals.Select(j => new JournalResponse
            {
                Id = j.Id,
                Date = j.Date,
                Description = j.Description,
                Account = j.Account,
                Debit = j.Debit,
                Credit = j.Credit,
                CashRegisters = j.CashRegisters.Select(cr => new CashRegisterDetail
                {
                    Id = cr.Id,
                    TransactionType = cr.TransactionType,
                    Amount = cr.Amount,
                    Date = cr.Date
                }).ToList()
            }).ToList();

            await SendAsync(response);
        }
    }

    public class JournalResponse
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string Account { get; set; }
        public decimal Debit { get; set; }
        public decimal Credit { get; set; }
        public List<CashRegisterDetail> CashRegisters { get; set; }
    }

    public class CashRegisterDetail
    {
        public int Id { get; set; }
        public string TransactionType { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
    }
}
