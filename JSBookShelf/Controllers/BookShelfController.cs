using JSBookShelf.Context;
using JSBookShelf.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JSBookShelf.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookShelfController : ControllerBase
    {
        private readonly BookShelftDBContext _context;

        public BookShelfController(BookShelftDBContext context)
        {
            this._context = context;
        }
        // GET: api/<BookShelfController>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(_context.Book.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }

        // GET api/<BookShelfController>/5
        [HttpGet("{id}", Name = "GetBook")]
        public ActionResult Get(int id)
        {
            try
            {
                return Ok(_context.Book.FirstOrDefault(b => b.Id == id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }

        // POST api/<BookShelfController>
        [HttpPost]
        public ActionResult Post([FromBody] Book book)
        {
            try
            {
                this._context.Book.Add(book);
                this._context.SaveChanges();
                return CreatedAtRoute("GetBook", new { id = book.Id }, book);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }

        // PUT api/<BookShelfController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Book book)
        {
            try
            {
                if (book.Id == id)
                {
                    this._context.Entry(book).State = EntityState.Modified;
                    this._context.SaveChanges();
                    return CreatedAtRoute("GetBook", new { id = book.Id }, book);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }

        // DELETE api/<BookShelfController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var book = this._context.Book.FirstOrDefault(b => b.Id == id);

                if (book != null)
                {
                    this._context.Book.Remove(book);
                    this._context.SaveChanges();
                    return Ok(id);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }
    }
}
