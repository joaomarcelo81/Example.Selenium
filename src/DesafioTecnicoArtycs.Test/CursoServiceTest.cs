using DesafioTecnicoArtycs.Application;
using DesafioTecnicoArtycs.Domain.Entities;
using DesafioTecnicoArtycs.Domain.Interfaces.Repositories;
using Microsoft.Extensions.Logging;
using Moq;
using OpenQA.Selenium;

namespace DesafioTecnicoArtycs.Test
{
    public class CursoServiceTests
    {
        private Mock<IRepository<Curso>> _cursoRepositoryMock;
        private Mock<ILogger<CursoService>> _loggerMock;
        private CursoService _cursoService;

        public CursoServiceTests()
        {
            _cursoRepositoryMock = new Mock<IRepository<Curso>>();
            _loggerMock = new Mock<ILogger<CursoService>>();
            _cursoService = new CursoService(_loggerMock.Object, _cursoRepositoryMock.Object);
        }

        [Fact]
        public async Task Adicionar_DeveAdicionarCursoNoRepositorio()
        {
            // Arrange
            var curso = new Curso();
            _cursoRepositoryMock.Setup(x => x.Add(curso)).ReturnsAsync(curso);

            // Act
            var result = await _cursoService.Adicionar(curso);

            // Assert
            _cursoRepositoryMock.Verify(x => x.Add(curso), Times.Once);
            Assert.Equal(curso, result);
        }

        [Fact]
        public async Task Atualizar_DeveAtualizarCursoNoRepositorio()
        {
            // Arrange
            var curso = new Curso();
            _cursoRepositoryMock.Setup(x => x.Update(curso)).ReturnsAsync(curso);

            // Act
            var result = await _cursoService.Atualizar(curso);

            // Assert
            _cursoRepositoryMock.Verify(x => x.Update(curso), Times.Once);
            Assert.Equal(curso, result);
        }

        [Fact]
        public async Task listaCursos_DeveRetornarListaDeCursosDoRepositorio()
        {
            // Arrange
            var cursos = new List<Curso> { new Curso(), new Curso() };
            _cursoRepositoryMock.Setup(x => x.GetAll()).ReturnsAsync(cursos);

            // Act
            var result = await _cursoService.listaCursos();

            // Assert
            _cursoRepositoryMock.Verify(x => x.GetAll(), Times.Once);
            Assert.Equal(cursos, result);
        }

        // Outros métodos de teste...

        //// Exemplo de teste para o método BuscarDadosAlura
        //[Fact]
        //public async Task BuscarDadosAlura_DeveBuscarDadosNaLista()
        //{
        //    // Arrange
        //    var driverMock = new Mock<IWebDriver>();
        //    var elementoMock = new Mock<IWebElement>();
        //    var listaElementosMock = new List<IWebElement> { elementoMock.Object };

        //    driverMock.Setup(x => x.FindElements(By.ClassName("busca-resultado-container")))
        //        .Returns(listaElementosMock);
        //    elementoMock.Setup(x => x.Text).Returns("Exemplo de item buscado");
        //    elementoMock.Setup(x => x.FindElement(By.XPath(It.IsAny<string>())))
        //        .Returns(elementoMock.Object);
        //    elementoMock.Setup(x => x.Click());
        //    _cursoRepositoryMock.Setup(x => x.Add(It.IsAny<Curso>())).ReturnsAsync(new Curso());
        //    _loggerMock.Setup(x => x.LogInformation(It.IsAny<EventId>(), It.IsAny<string>(), It.IsAny<object[]>()));
        //    // Configurar o comportamento esperado para os métodos do driverMock de acordo com a lógica do método BuscarDadosAlura

        //    // Act
        //    await _cursoService.BuscarDadosAlura();

        //    // Assert
        //    // Verifique o comportamento esperado, como as chamadas de método no _cursoRepositoryMock e _loggerMock
        //    // Verifique se os métodos do driverMock foram chamados corretamente
        //}
    }

}