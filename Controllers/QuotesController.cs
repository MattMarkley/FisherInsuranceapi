using System;
using FisherInsuranceApi.Models;
using FisherInsuranceApi.Data;
using Microsoft.AspNetCore.Mvc;



[Route("api/quotes")]

    public class QuotesController : Controller 
    {

        private IMemoryStore db;

        public QuotesController(IMemoryStore repo)
        {
            db = repo;
        }


        // Post api/auto/quotes

        [HttpPost]
   
        public IActionResult Post([FromBody] Quote quote)
        {
            return Ok(db.CreateQuote(quote));
        }
        // GET 
        [HttpGet]
        public IActionResult GetQuotes()
        {
            return Ok(db.RetrieveAllQuotes);
        }
        // GET api/auto/quotes/5

       [HttpGet("{id}")]
       
       public IActionResult Get(int id)
       {
           return Ok(db.RetrieveQuote(id));
       }

       // PUT api/auto/quotes/id

       [HttpPut("{id}")]

       public IActionResult Put([FromBody] Quote quote)
       {
           return Ok(db.UpdateQuote(quote));
       }


       // DELETE api/auto/quotes/id

       [HttpDelete("{id}")]

       public IActionResult Delete(int id)
       {
           db.DeleteQuote(id);

           return Ok();
       }





    }