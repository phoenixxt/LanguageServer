using System.Collections.Generic;
using System.Linq;
using language_server.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace language_server.Services 
{
    public class WordService 
    {
        private static string CONNECTION_STRING = "WordsStoreDb";
        private static string COLLECTION_NAME = "Words";
        private readonly IMongoCollection<Word> _words;

        public WordService(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetConnectionString(CONNECTION_STRING));
            var database = client.GetDatabase(CONNECTION_STRING);
            _words = database.GetCollection<Word>(COLLECTION_NAME);
        }

        public List<Word> Get()
        {
            var a = _words.Find(word => true).ToList();
            var b = a.Count;
            return _words.Find(word => true).ToList();
        }

        public Word Get(string id)
        {
            return _words.Find(word => word.Id == id).FirstOrDefault();
        }

        public Word Create(Word word)
        {
            _words.InsertOne(word);
            return word;
        }

        public void Update(string id, Word wordToUpdate)
        {
            _words.ReplaceOne(word => word.Id == id, wordToUpdate);
        }

        public void Remove(Word wordToRemove)
        {
            _words.DeleteOne(word => word.Id == wordToRemove.Id);
        }

        public void Remove(string id)
        {
            _words.DeleteOne(word => word.Id == id);
        }
    }
}