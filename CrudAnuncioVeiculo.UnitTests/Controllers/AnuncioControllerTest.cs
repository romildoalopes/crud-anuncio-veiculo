using CrudAnuncioVeiculo.Api.Controllers;
using CrudAnuncioVeiculo.Domain.Commands;
using CrudAnuncioVeiculo.Domain.Services.Anuncio;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Net;
using Xunit;

namespace CrudAnuncioVeiculo.UnitTests.Controllers
{
    public class AnuncioControllerTest
    {
        private readonly Mock<IMediator> _mockedMediator;
        private readonly Mock<IAnuncioService> _mockedService;
        private readonly AnuncioController _controller;

        public AnuncioControllerTest()
        {
            _mockedMediator = new();
            _mockedService = new();
            _controller = new AnuncioController();
        }

        #region Criar
        [Fact]
        public async Task Verifica_AnuncioController_Criar_ReturnOk()
        {
            // Arrange
            _mockedMediator.Setup(x => x.Send(It.IsAny<CriarAnuncioCommand>(), It.IsAny<CancellationToken>()));

            // Act
            var result = (OkObjectResult)await _controller.Criar(It.IsAny<CriarAnuncioCommand>(),_mockedMediator.Object);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(HttpStatusCode.OK, (HttpStatusCode)result.StatusCode);
        }
        #endregion

        #region Atualizar
        [Fact]
        public async Task Verifica_AnuncioController_Atualizar_ReturnOk()
        {
            // Arrange
            _mockedMediator.Setup(x => x.Send(It.IsAny<AlterarAnuncioCommand>(), It.IsAny<CancellationToken>()));

            // Act
            var result = (OkObjectResult)await _controller.Alterar(It.IsAny<AlterarAnuncioCommand>(), _mockedMediator.Object);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(HttpStatusCode.OK, (HttpStatusCode)result.StatusCode);
        }
        #endregion Atualizar

        #region Deletar
        [Fact]
        public async Task Verifica_AnuncioController_Deletar_ReturnOk()
        {
            // Arrange
            _mockedService.Setup(x => x.Deletar(It.IsAny<int>()));

            // Act
            var result = (OkObjectResult)await _controller.Deletar(It.IsAny<int>(), _mockedService.Object);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(HttpStatusCode.OK, (HttpStatusCode)result.StatusCode);
        }
        #endregion Deletar

        #region Obter
        [Fact]
        public async Task Verifica_AnuncioController_Obter_ReturnOk()
        {
            // Arrange
            _mockedService.Setup(x => x.Obter());

            // Act
            var result = (OkObjectResult)await _controller.Deletar(It.IsAny<int>(), _mockedService.Object);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(HttpStatusCode.OK, (HttpStatusCode)result.StatusCode);
        }
        #endregion Obter

    }
}
