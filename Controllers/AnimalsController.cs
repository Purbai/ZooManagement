using Microsoft.AspNetCore.Mvc;
using ZooManagement.Models.Request;
using ZooManagement.Models.Response;
using ZooManagement.Repositories;

namespace ZooManagement.Controllers
{
    [ApiController]
    [Route("/animals")]

    public class AnimalsController : ControllerBase
    {
        private readonly IAnimalsRepo _animals;

        public AnimalsController(IAnimalsRepo animals)
        {
            _animals = animals;
        }

        [HttpGet("{id}")]
        public ActionResult<AnimalResponse> GetById([FromRoute] int id)
        {
            var animal = _animals.GetById(id);

            return new AnimalResponse(animal);
        }

        [HttpGet("")]
        public ActionResult<AnimalListResponse> Search([FromQuery] AnimalSearchRequest searchRequest)
        {
            var animals = _animals.Search(searchRequest);
            var animalCount = _animals.Count(searchRequest);
            return AnimalListResponse.Create(searchRequest, animals, animalCount);
        }


        [HttpPost("create")]
        public IActionResult Create([FromBody] CreateAnimalRequest newAnimal)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var animal = _animals.Create(newAnimal);

            var url = Url.Action("GetById", new { id = animal.Id });
            var animalResponse = new AnimalResponse(animal);
            return Created(url, animalResponse);
        }
    }
}