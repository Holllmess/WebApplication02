using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication02.Controllers;
using WebApplication02.Models;
using WebApplication02.Models.Requests;
using WebApplication02.Services;

namespace CSTests
{
    public class PetControllerTests
    // Все классы должны быть публичными  
    {
        private PetController _petController;
        private Mock<IPetRepository> _mockPetRepository;

        public PetControllerTests() 
        {
            _mockPetRepository = new Mock<IPetRepository>();
            _petController = new PetController(_mockPetRepository.Object);
        }

        [Fact]
        public void PetCreateTest()
        {
            // Метод теститования состоит из трёх условных частей:
            // #01 Подготовить данные для тестирования 

            CreatePetRequest createPetRequest = new CreatePetRequest();
            createPetRequest.Name = "Minerva";
            createPetRequest.Birthday = DateTime.Now.AddYears(-10);
            createPetRequest.ClientId = 1;

            // #02 Исполнение тестируемого метода

            ActionResult<int> operationResult =  _petController.Create(createPetRequest);

            // #03 Подготовка эталонного результата (expected), проверка результата

            int expectedOperationValue = 1;

            // Assert - базовый класс, содержащий много статических методов (например: для проверки условия)
            // Проверка на то, что мы ожидаем увидеть тип OkObjectResult
            Assert.IsType<OkObjectResult>(operationResult.Result);
            // Equal - сверяем значение того, что ожидали, с тем, что получили 
            Assert.Equal<int>(expectedOperationValue,(int)((OkObjectResult)operationResult.Result).Value);
        }


        [Fact]
        public void PetCreateBadRequestTest()
        {
            // Метод теститования состоит из трёх условных частей:
            // #01 Подготовить данные для тестирования 

            CreatePetRequest createPetRequest = new CreatePetRequest();
            createPetRequest.Name = "M";
            createPetRequest.Birthday = DateTime.Now.AddYears(-50);
            createPetRequest.ClientId = 1;

            // #02 Исполнение тестируемого метода

            ActionResult<int> operationResult = _petController.Create(createPetRequest);

            // #03 Подготовка эталонного результата (expected), проверка результата

            int expectedOperationValue = 0;

            // Assert - базовый класс, содержащий много статических методов (например: для проверки условия)
            // Проверка на то, что мы ожидаем увидеть тип OkObjectResult
            Assert.IsType<BadRequestObjectResult>(operationResult.Result);
            // Equal - сверяем значение того, что ожидали, с тем, что получили 
            Assert.Equal<int>(expectedOperationValue, (int)((BadRequestObjectResult)operationResult.Result).Value);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(22)]
        [InlineData(37)]
        // Тест, выполняющий идин и тот же код, но с разными входными параметрами
        public void DeletePetTest(int petId)
        {
            // #02 Исполнение тестируемого метода

            ActionResult<int> operationResult = _petController.Delete(petId);

            // #03 Подготовка эталонного результата (expected), проверка результата

            int expectedOperationValue = 1;

            Assert.IsType<OkObjectResult>(operationResult.Result);
            Assert.Equal<int>(expectedOperationValue, (int)((OkObjectResult)operationResult.Result).Value);

        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-47)]
        // Тест, выполняющий идин и тот же код, но с разными входными параметрами
        public void DeletePetBadRequestTest(int petId)
        {
            // #02 Исполнение тестируемого метода

            ActionResult<int> operationResult = _petController.Delete(petId);

            // #03 Подготовка эталонного результата (expected), проверка результата

            int expectedOperationValue = 0;

            Assert.IsType<BadRequestObjectResult>(operationResult.Result);
            Assert.Equal<int>(expectedOperationValue, (int)((BadRequestObjectResult)operationResult.Result).Value);

        }


        [Fact]
        public void GetAllPetTest()
        {
            // #01 Подготовить данные для тестирования 

            _mockPetRepository.Setup(repository => repository.GetAll()).Returns(new List<Pet>()
            {
                new Pet(),
                new Pet(),
                new Pet()
            });

            // #02 Исполнение тестируемого метода

            ActionResult<List<Pet>> operationResult = _petController.GetAll();

            // #03 Подготовка эталонного результата (expected), проверка результата

            Assert.IsType<OkObjectResult>(operationResult.Result);
            Assert.IsAssignableFrom<List<Pet>>(((OkObjectResult)operationResult.Result).Value);
            _mockPetRepository.Verify(repository => repository.GetAll(), Times.Once);
        }


        [Theory]
        [InlineData(1)]
        [InlineData(14)]
        [InlineData(437)]
        [InlineData(477)]
        // Тест, выполняющий идин и тот же код, но с разными входными параметрами
        public void GetByIdPetTest(int Id)
        {
            // #02 Исполнение тестируемого метода

            ActionResult<Pet> operationResult = _petController.GetById(Id);

            // #03 Подготовка эталонного результата (expected), проверка результата

            int expectedOperationValue = 1;

            Assert.IsType<OkObjectResult>(operationResult.Result);
            Assert.Equal<int>(expectedOperationValue, (int)((OkObjectResult)operationResult.Result).Value);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(677)]
        [InlineData(-77)]
        // Тест, выполняющий идин и тот же код, но с разными входными параметрами
        public void GetByIdBadRequestPetTest(int Id)
        {
            // #02 Исполнение тестируемого метода

            ActionResult<Pet> operationResult = _petController.GetById(Id);

            // #03 Подготовка эталонного результата (expected), проверка результата

            int expectedOperationValue = 0;

            Assert.IsType<BadRequestObjectResult>(operationResult.Result);
            Assert.Equal<int>(expectedOperationValue, (int)((BadRequestObjectResult)operationResult.Result).Value);
        }


        [Fact]
        public void PetUpdateTest()
        {
            // Метод теститования состоит из трёх условных частей:
            // #01 Подготовить данные для тестирования 

            UpdatePetRequest updatePetRequest = new UpdatePetRequest();
            updatePetRequest.Name = "Minerva";
            updatePetRequest.Birthday = DateTime.Now.AddYears(-10);
            updatePetRequest.ClientId = 1;
            updatePetRequest.PetId = 1;

            // #02 Исполнение тестируемого метода

            ActionResult<int> operationResult = _petController.Update(updatePetRequest);

            // #03 Подготовка эталонного результата (expected), проверка результата

            int expectedOperationValue = 1;

            // Assert - базовый класс, содержащий много статических методов (например: для проверки условия)
            // Проверка на то, что мы ожидаем увидеть тип OkObjectResult
            Assert.IsType<OkObjectResult>(operationResult.Result);
            // Equal - сверяем значение того, что ожидали, с тем, что получили 
            Assert.Equal<int>(expectedOperationValue, (int)((OkObjectResult)operationResult.Result).Value);
        }


        [Fact]
        public void PetUpdateBadRequestTest()
        {
            // Метод теститования состоит из трёх условных частей:
            // #01 Подготовить данные для тестирования 

            UpdatePetRequest updatePetRequest = new UpdatePetRequest();
            updatePetRequest.Name = "Mi";
            updatePetRequest.Birthday = DateTime.Now.AddYears(-21);
            updatePetRequest.ClientId = 0;
            updatePetRequest.PetId = -1;

            // #02 Исполнение тестируемого метода

            ActionResult<int> operationResult = _petController.Update(updatePetRequest);

            // #03 Подготовка эталонного результата (expected), проверка результата

            int expectedOperationValue = 0;

            // Assert - базовый класс, содержащий много статических методов (например: для проверки условия)
            // Проверка на то, что мы ожидаем увидеть тип OkObjectResult
            Assert.IsType<BadRequestObjectResult>(operationResult.Result);
            // Equal - сверяем значение того, что ожидали, с тем, что получили 
            Assert.Equal<int>(expectedOperationValue, (int)((BadRequestObjectResult)operationResult.Result).Value);
        }
    }
}
