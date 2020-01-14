using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using twitterapi.Models;

namespace twitterapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TweetController : ControllerBase
    {
        private readonly TweetContext _context;

        public TweetController(TweetContext context)
        {
            _context = context;
        }

        // GET: api/Tweet
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TweetItem>>> GetTweetItems()
        {
            return await _context.TweetItems.ToListAsync();
        }

        // GET: api/Tweet/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TweetItem>> GetTweetItem(long id)
        {
            var tweetItem = await _context.TweetItems.FindAsync(id);

            if (tweetItem == null)
            {
                return NotFound();
            }

            return tweetItem;
        }

        // PUT: api/Tweet/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTweetItem(long id, TweetItem tweetItem)
        {
            if (id != tweetItem.id)
            {
                return BadRequest();
            }

            _context.Entry(tweetItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TweetItemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Tweet
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<TweetItem>> PostTweetItem(TweetItem tweetItem)
        {
            
            tweetItem.userPostDate = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
            _context.TweetItems.Add(tweetItem);

            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTweetItem), new { id = tweetItem.id }, tweetItem);
        }

        // DELETE: api/Tweet/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TweetItem>> DeleteTweetItem(long id)
        {
            var tweetItem = await _context.TweetItems.FindAsync(id);
            if (tweetItem == null)
            {
                return NotFound();
            }

            _context.TweetItems.Remove(tweetItem);
            await _context.SaveChangesAsync();

            return tweetItem;
        }

        private bool TweetItemExists(long id)
        {
            return _context.TweetItems.Any(e => e.id == id);
        }
    }
}
