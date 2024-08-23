using Microsoft.AspNetCore.Mvc;
using ZooManagement.Models.Request;
using ZooManagement.Models.Response;
using ZooManagement.Repositories;

namespace ZooManagement.Controllers
{
    [ApiController]
    [Route("/animaltypes")]

     public class AnimalTypesController: ControllerBase
    {
        private readonly IAnimalTypesRepo _animalTypes;

        public AnimalTypesController(IAnimalTypesRepo animalTypes)
        {
            _animalTypes = animalTypes;
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] CreateAnimalTypeRequest newAnimalType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var animalType = _animalTypes.Create(newAnimalType);
            var url = Url.Action("GetById", new { id = animalType.Id });
            var animalTypeResponse = new AnimalTypeResponse(animalType);
            return Created(url, animalTypeResponse);
        }
    }
}