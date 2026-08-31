using LiaProjekt.Models;
using LiaProjekt.Services;
using Microsoft.AspNetCore.Mvc;

namespace LiaProjekt.Controllers
{

    [Route("api/quotes")]
    [ApiController]
    public class QuoteController : ControllerBase
    {
        private readonly QuoteService quoteService;

        public QuoteController(QuoteService quoteService)
        {
            this.quoteService = quoteService;
        }

        [HttpGet]
        public async Task<IActionResult> getAllQuotes()
        {
            var quotes = await quoteService.getAllQuotes();
            return Ok(quotes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> getQuoteById(int id)
        {
            try { 

                var quote = await quoteService.getQuoteById(id);
                return Ok(quote);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> addQuote(Quote quote)
        {
            var addedQuote = await quoteService.addQuote(quote);
            return CreatedAtAction(nameof(getQuoteById), new { id = addedQuote.Id }, addedQuote);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> updateQuote(int id, Quote updatedQuote)
        {
           try
            {
                var quote = await quoteService.updateQuote(id, updatedQuote);
                return Ok(quote);
            }
            catch(KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> deleteQuote(int id)
        {
            try
            {
                var quote = await quoteService.deleteQuote(id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }
    }
}
