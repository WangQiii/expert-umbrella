using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiDemo.Models;

namespace WebApiDemo.Controllers
{
    public class BookController : ApiController
    {
        List<Book> bookList = new List<Book>()
        {
            new Book(){Id="1",Name="哈姆雷特"},
            new Book(){ Id="2",Name="西游记"}
        };

        [Route("api/book")]
        [HttpGet]
        public IEnumerable<Book> Get()
        {
            return bookList;
        }

        [Route("api/book/{id}")]
        [HttpGet]
        public Book Get(string id)
        {
            return bookList.First(f => f.Id == id);
        }

        [Route("api/book")]
        [HttpPost]
        public void Post([FromBody]Book book)
        {
            bookList.Add(book);
        }

        [Route("api/book/{id}")]
        [HttpPut]
        public void Put(string id, [FromBody]string name)
        {
            var book = bookList.First(f => f.Id == id);
            book.Name = name;
        }

        [Route("api/book/{id}")]
        [HttpDelete]
        public void Delete(string id)
        {
            bookList.Remove(bookList.First(f => f.Id == id));
        }
    }
}