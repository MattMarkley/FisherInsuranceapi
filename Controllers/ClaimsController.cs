using System;
using FisherInsuranceApi.Models;
using FisherInsuranceApi.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Design;
using Npgsql.EntityFrameworkCore.PostgreSQL;



[Route("api/claims/claim")]

  public class ClaimsController : Controller 
  {
    private readonly FisherContext db;
    public ClaimsController(FisherContext context)
    {
        db = context;
    }

    [HttpGet]
       public IActionResult GetClaims()
       {
        return Ok(db.Claims);

       }


    // Post api/claims/claim

        [HttpPost]
   
        public IActionResult Post([FromBody]Claim claim)
        {
            var newClaim = db.Claims.Add(claim);
            db.SaveChanges();
            return CreatedAtRoute("GetClaim", new { id = claim.Id }, claim);
        }

    // GET api/claims/claim/5

       [HttpGet("{id}", Name = "GetClaim")]
       
       public IActionResult Get(int id)
       {
           return Ok(db.Claims.Find(id));
       }

    // PUT api/claims/claim/id

       [HttpPut("{id}")]

       public IActionResult Put(int id, [FromBody] Claim claim)
       {
           var newClaim = db.Claims.Find(id);
           if (newClaim == null)
           {
               return NotFound();
           }
           newClaim = claim;
           db.SaveChanges();
           return Ok(newClaim);
       }


    // DELETE api/claims/claim/id

       [HttpDelete("{id}")]

       public IActionResult Delete(int id)
       {
          var claimToDelete = db.Claims.Find(id);
          if (claimToDelete == null)
          {
              return NotFound();
          }
          db.Claims.Remove(claimToDelete);
          db.SaveChangesAsync();
          return NoContent();
       }


  }