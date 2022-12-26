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
    public class ConsultationController : ControllerBase
    {

        private IConsultationRepository _consultationRepository;

        public ConsultationController(IConsultationRepository consultationRepository)
        { 
            _consultationRepository= consultationRepository;
        }

        [HttpDelete("delete")]
        public ActionResult<int> Delete(int id)
        {
            return Ok(_consultationRepository.Delete(id));
        }

        [HttpGet("get-all")]
        public ActionResult<List<Consultation>> GetAll()
        {
            return Ok(_consultationRepository.GetAll());
        }

        [HttpGet("get-by-id")]
        public ActionResult<Consultation> GetById(int id)
        {
            return Ok(_consultationRepository.GetById(id));
        }

        [HttpPost("create")]
        public ActionResult<int> Create([FromBody] CreateConsultationRequest createConsultationRequest)
        {
            int result = _consultationRepository.Create(new Consultation
            {
                PetId = createConsultationRequest.PetId,
                ClientId = createConsultationRequest.ClientId,
                ConsultationDate= createConsultationRequest.ConsultationDate,
                Description= createConsultationRequest.Description,
            });

            return Ok(result);
        }

        [HttpPut("update")]
        public ActionResult<int> Update([FromBody] UpdateConsultationRequest updateConsultationRequest)
        {
            int result = _consultationRepository.Update(new Consultation
            {
                ConsultationId = updateConsultationRequest.ConsultationId,
                PetId = updateConsultationRequest.PetId,
                ClientId = updateConsultationRequest.ClientId,
                ConsultationDate = updateConsultationRequest.ConsultationDate,
                Description = updateConsultationRequest.Description,
            });

            return Ok(result);
        }

    }
}
