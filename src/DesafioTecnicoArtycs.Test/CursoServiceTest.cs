using DesafioTecnicoArtycs.Application;
using DesafioTecnicoArtycs.Domain.Entities;
using DesafioTecnicoArtycs.Domain.Interfaces.Repositories;
using DesafioTecnicoArtycs.Domain.Util;
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
        private Settings _settings;
        public CursoServiceTests()
        {
            _cursoRepositoryMock = new Mock<IRepository<Curso>>();
            _loggerMock = new Mock<ILogger<CursoService>>();
            _settings = new Settings();
            _cursoService = new CursoService(_loggerMock.Object, _settings, _cursoRepositoryMock.Object);
        }

        [Fact]
        [Trait("_cursoService", "Adicionar")]
        public async Task DeveSerPossivelAdicionarCursoNoRepositorio()
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
        [Trait("_cursoService", "Atualizar")]
        public async Task DeveSerPossivelAtualizarCursoNoRepositorio()
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
        [Trait("_cursoService", "listaCursos")]
        public async Task DeveSerPossivelRetornarListaDeCursosDoRepositorio()
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
    }

}