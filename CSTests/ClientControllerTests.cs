using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication02.Controllers;
using WebApplication02.Models;
using WebApplication02.Services;

namespace CSTests
{
    public class ClientControllerTests
    // Все классы должны быть публичными  
    {
        private ClientController _clientController;
        private Mock<ICleintRepository> _mockClientRepository;

        public ClientControllerTests()
        {
            _mockClientRepository = new Mock<ICleintRepository>();
            _clientController = new ClientController(_mockClientRepository.Object);
        }

        [Fact]
        public void GetAllClientTest()
        {
            // #01 Подготовить данные для тестирования 

            _mockClientRepository.Setup(repository => repository.GetAll()).Returns(new List<Client>()
            {
                new Client(),
                new Client(),
                new Client()
            });

            // #02 Исполнение тестируемого метода

            ActionResult<List<Client>> operationResult = _clientController.GetAll(); 
            Assert.IsType<OkObjectResult>(operationResult.Result);
            // Проверка на инициализацию и возвращение коллекции <List<Client>>
            Assert.IsAssignableFrom<List<Client>>(((OkObjectResult)operationResult.Result).Value);

            // Проверка: обращались ли вообще к репозиторию (там может быть пустышка возвращающая
            // устраивающие нас значения) (Times.Once - обратиться должны были один раз)
            _mockClientRepository.Verify(repository => repository.GetAll(), Times.Once);
        }


    }
}
