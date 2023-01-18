using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
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
        [SwaggerOperation(OperationId = "PetDelete")]
        public ActionResult<int> Delete(int id)
        {
            //return Ok(_petRepository.Delete(id));
            if(id <= 0)
            {
                return BadRequest(0);
            }
            return Ok(1);
        } 

        [HttpGet("get-all")]
        [SwaggerOperation(OperationId = "PetGetAll")]
        public ActionResult<List<Pet>> GetAll()
        {
            return Ok(_petRepository.GetAll());
            //return Ok(1);
        }

        [HttpGet("get-by-id")]
        [SwaggerOperation(OperationId = "PetGetById")]

        public ActionResult<Pet> GetById(int id)
        {
            //return Ok(_petRepository.GetById(id));
            if(id <= 0)
            {
                return BadRequest(0);
            } if (id > 500)
            {
                return BadRequest(0);
            }
            return Ok(1);
        }

        [HttpPost("create")]
        [SwaggerOperation(OperationId = "PetCreate")]
        public ActionResult<int> Create([FromBody] CreatePetRequest createPetRequest)
        {
            /*int result = _petRepository.Create(new Pet
            {
                ClientId= createPetRequest.ClientId,
                Name = createPetRequest.Name,
                Birthday = createPetRequest.Birthday,
            });

            return Ok(result);*/

            if(createPetRequest.Birthday < DateTime.Now.AddYears(-20) || createPetRequest.Name.Length < 3) 
            {
                return BadRequest(0); // BadRequestObjectResult (код ответа - 400)
            }
            return Ok(1); // OkObjectResult (код ответа - 200)
        }

        [HttpPut("update")]
        [SwaggerOperation(OperationId = "PetUpdate")]
        public ActionResult<int> Update([FromBody] UpdatePetRequest updatePetRequest)
        {
            /*int result = _petRepository.Update(new Pet
            {
                PetId = updatePetRequest.PetId,  
                ClientId = updatePetRequest.ClientId,
                Name = updatePetRequest.Name,
                Birthday = updatePetRequest.Birthday,
            });

            return Ok(result);*/
            if (updatePetRequest.Birthday < DateTime.Now.AddYears(-20) || updatePetRequest.Name.Length < 3)
            {
                return BadRequest(0); // BadRequestObjectResult (код ответа - 400)
            } if(updatePetRequest.ClientId <= 0 || updatePetRequest.PetId <= 0)
            {
                return BadRequest(0);
            }
            return Ok(1);
        }
    }
}
