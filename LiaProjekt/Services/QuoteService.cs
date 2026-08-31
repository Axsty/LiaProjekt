using LiaProjekt.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace LiaProjekt.Services
{
    public class QuoteService
    {
        private readonly MyDbContext context;

        public QuoteService(MyDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Quote>> getAllQuotes()
        {
            return await context.Quotes.ToListAsync();
        }

        public async Task<Quote> getQuoteById(int id)
        {
            var quote = await context.Quotes.FindAsync(id);

            if (quote == null)
                throw new KeyNotFoundException($"Citatet med id {id} hittades inte.");

            return quote;
        }

        public async Task<Quote> addQuote(Quote quote)
        {
            await context.Quotes.AddAsync(quote);
            await context.SaveChangesAsync();

            return quote;
        }

        public async Task<Quote> deleteQuote(int id)
        {
            var quote = await context.Quotes.FindAsync(id);

            if (quote == null)
                throw new KeyNotFoundException($"Citatet med id {id} hittades inte.");

            context.Quotes.Remove(quote);
            await context.SaveChangesAsync();

            return quote;
        }

        public async Task<Quote> updateQuote(int id, Quote updatedQuote)
        {
            var quote = await context.Quotes.FindAsync(id);

            if (quote == null)
                throw new KeyNotFoundException($"Citatet med id {id} hittades inte.");

            quote.quote = updatedQuote.quote;

            await context.SaveChangesAsync();

            return quote;
        }
    }
}
