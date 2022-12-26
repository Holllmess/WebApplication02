using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication02.Models;
using WebApplication02.Models.Requests;
using WebApplication02.Services;
using WebApplication02.Services.Implementation;

namespace WebApplication02.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetController : ControllerBase
    {
        private IPetRepository _petRepository;

        public PetController(IPetRepository petRepository)
        {
            _petRepository = petRepository;
        }

        [HttpDelete("delete")]
        public ActionResult<int> Delete(int id)
        {
            return Ok(_petRepository.Delete(id));
        }

        [HttpGet("get-all")]
        public ActionResult<List<Pet>> GetAll()
        {
            return Ok(_petRepository.GetAll());
        }

        [HttpGet("get-by-id")]
        public ActionResult<Pet> GetById(int id)
        {
            return Ok(_petRepository.GetById(id));
        }

        [HttpPost("create")]
        public ActionResult<int> Create([FromBody] CreatePetRequest createPetRequest)
        {
            int result = _petRepository.Create(new Pet
            {
                ClientId= createPetRequest.ClientId,
                Name = createPetRequest.Name,
                Birthday = createPetRequest.Birthday,
            });

            return Ok(result);
        }

        [HttpPut("update")]
        public ActionResult<int> Update([FromBody] UpdatePetRequest updatePetRequest)
        {
            int result = _petRepository.Update(new Pet
            {
                PetId = updatePetRequest.PetId,  
                ClientId = updatePetRequest.ClientId,
                Name = updatePetRequest.Name,
                Birthday = updatePetRequest.Birthday,
            });

            return Ok(result);
        }
    }
}
