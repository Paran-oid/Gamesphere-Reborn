using GameSphereAPI.Data.Services.PublisherServices;
using GameSphereAPI.Models.Site_Models.Game_Related;
using GameSphereAPI.Models.Viewmodels.Game___Related;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GameSphereAPI.Controllers.GameController
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class PublisherController : ControllerBase
    {
        private readonly IPublisherService _publisherService;

        public PublisherController(IPublisherService publisherService)
        {
            _publisherService = publisherService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Publisher>>> GetAll()
        {
            var publishers = await _publisherService.GetPublishers();
            return Ok(publishers);
        }

        [HttpGet("{ID}")]
        public async Task<ActionResult<Publisher>> Get(int ID)
        {
            var publisher = await _publisherService.Get(ID);
            if (publisher == null)
            {
                return NotFound("Publisher not found");
            }
            return Ok(publisher);
        }

        [HttpPost]
        public async Task<ActionResult<Publisher>> Post(CreatePublisherDTO model)
        {
            if (ModelState.IsValid)
            {
                var publisher = await _publisherService.Post(model);
                if (publisher == null)
                {
                    return BadRequest("Failed to create publisher");
                }
                return Ok(publisher);
            }
            return BadRequest("Check your inputs");
        }

        [HttpPut("{ID}")]
        public async Task<ActionResult<Publisher>> Put(int ID, UpdatePublisherDTO model)
        {
            var updatedPublisher = await _publisherService.Put(ID, model);
            if (updatedPublisher == null)
            {
                return NotFound("Publisher not found");
            }
            return Ok(updatedPublisher);
        }

        [HttpDelete("{ID}")]
        public async Task<ActionResult<string>> Delete(int ID)
        {
            var result = await _publisherService.Delete(ID);
            if (result == null)
            {
                return NotFound("Publisher not found");
            }
            return Ok(result);
        }
    }
}