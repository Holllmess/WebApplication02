﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using WebApplication02.Models;
using WebApplication02.Models.Requests;
using WebApplication02.Services;

namespace WebApplication02.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {

        private ICleintRepository _clientRepository;
 
        public ClientController(ICleintRepository cleintRepository) 
        {
            _clientRepository = cleintRepository;
        }

        [HttpDelete("delete")]
        [SwaggerOperation(OperationId = "ClientDelete")]
        public ActionResult<int> Delete(int id)
        {
            return Ok(_clientRepository.Delete(id));
        }

        [HttpGet("get-all")]
        [SwaggerOperation(OperationId = "ClientGetAll")]
        public ActionResult<List<Client>> GetAll()
        {
            return Ok(_clientRepository.GetAll());
        }

        [HttpGet("get-by-id")]
        [SwaggerOperation(OperationId = "ClientGetById")]
        public ActionResult<Client> GetById(int id)
        {
            return Ok(_clientRepository.GetById(id));
        }

        [HttpPost("create")]
        [SwaggerOperation(OperationId = "ClientCreate")]
        public ActionResult<int> Create([FromBody] CreateClientRequest createClientRequest)
        {
            int result = _clientRepository.Create(new Client
            {
                Document = createClientRequest.Document,
                SurName = createClientRequest.SurName,
                FirstName = createClientRequest.FirstName,
                Patronymic = createClientRequest.Patronymic,
                Birthday = createClientRequest.Birthday,
            });

            return Ok(result);
        }

        [HttpPut("update")]
        [SwaggerOperation(OperationId = "ClientUpdate")]
        public ActionResult<int> Update([FromBody] UpdateClientRequest updateClientRequest)
        {
            int result = _clientRepository.Update(new Client
            {
                ClientId = updateClientRequest.ClientId,
                Document = updateClientRequest.Document,
                SurName = updateClientRequest.SurName,
                FirstName = updateClientRequest.FirstName,
                Patronymic = updateClientRequest.Patronymic,
                Birthday = updateClientRequest.Birthday,
            });

            return Ok(result);
        }
    }
}
