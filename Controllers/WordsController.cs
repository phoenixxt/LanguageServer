using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using language_server.Models;
using language_server.Services;
using Microsoft.AspNetCore.Mvc;

namespace language_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WordsController : ControllerBase
    {
        private readonly WordService _wordService;

        public WordsController(WordService wordService) {
            _wordService = wordService;
        }

        [HttpGet]
        public ActionResult<List<Word>> Get()
        {
            return _wordService.Get();
        }

        [HttpGet("{id:length(24)}", Name = "GetWord")]
        public ActionResult<Word> Get(string id)
        {
            var word = _wordService.Get(id);
            if (word == null) 
            {
                return NotFound();
            }
            return word;
        }

        [HttpPost]
        public ActionResult<Word> Create(Word word)
        {
            _wordService.Create(word);

            return CreatedAtRoute("GetWord", new Word { Id = word.Id }, word);
        }

        [HttpPut("{id:length(24)}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id:length(24)}")]
        public void Delete(int id)
        {
        }
    }
}
