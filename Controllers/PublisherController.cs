using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using my_books.Data.ViewModel;
using my_books.Services;

namespace my_books.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublisherController : ControllerBase
    {
        private readonly PublisherService _publisherService;

        public PublisherController(PublisherService publisherService)
        {
            _publisherService = publisherService;
        }

        [HttpPost("add-publisher")]
        public IActionResult AddPublisher([FromBody] PublisherVM pub)
        {
            _publisherService.AddPublisher(pub);
            return Ok();
        }

        [HttpGet("get-publisher-books-with-auhtors/{id}")]
        public IActionResult GetPublisherInfo(int id)
        {
            var response = _publisherService.GetPublisherData(id);
            return Ok(response);
        }
    }
}
