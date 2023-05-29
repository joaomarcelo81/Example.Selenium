using AutoMapper;
using DesafioTecnicoArtycs.Application;
using DesafioTecnicoArtycs.Domain.Dto.Reponse;
using DesafioTecnicoArtycs.Domain.Dto.Request;
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
        private readonly Mock<IRepository<Curso>> _cursoRepositoryMock;
        private readonly Mock<ILogger<CursoService>> _loggerMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly CursoService _cursoService;

        public CursoServiceTests()
        {
            _cursoRepositoryMock = new Mock<IRepository<Curso>>();
            _loggerMock = new Mock<ILogger<CursoService>>();
            _mapperMock = new Mock<IMapper>();

     
            

            _cursoService = new CursoService(
                _mapperMock.Object,
                _loggerMock.Object,
                new Settings(),
                _cursoRepositoryMock.Object
            );
        }

        [Fact]
        [Trait("_cursoService", "Adicionar")]
        public async Task DeveSerPossivelAdicionarCursoNoRepositorio()
        {
            // Arrange
            var cursoRequest = new CursoRequest();
            var curso = new Curso { Id = 1 };
            _mapperMock.Setup(m => m.Map<Curso>(It.IsAny<CursoRequest>())).Returns(curso);
            _cursoRepositoryMock.Setup(r => r.Add(It.IsAny<Curso>())).ReturnsAsync(curso);

            // Act
            var result = await _cursoService.Adicionar(cursoRequest);

            // Assert
            Assert.Equal(curso.Id, result);
            _cursoRepositoryMock.Verify(r => r.Add(curso), Times.Once);
        }

        [Fact]
        [Trait("CursoService", "Atualizar")]

        public async Task DeveSerPossivelAtualizarCursoNoRepositorio()
        {
            // Arrange
            var id = 1;
            var cursoRequest = new CursoRequest();
            var curso = new Curso { Id = id };
            _mapperMock.Setup(m => m.Map<Curso>(It.IsAny<CursoRequest>())).Returns(curso);
            _cursoRepositoryMock.Setup(r => r.Update(It.IsAny<Curso>())).ReturnsAsync(curso);

            // Act
            var result = await _cursoService.Atualizar(id, cursoRequest);

            // Assert
            Assert.Equal(id, result);
            _cursoRepositoryMock.Verify(r => r.Update(curso), Times.Once);
        }



        [Fact]
        [Trait("CursoService", "listaCursos")]
        public async Task DeveSerPossivelRetornarListaDeCursosDoRepositorio()
        {
            // Arrange
            var cursos = new List<Curso> { new Curso() };
            _cursoRepositoryMock.Setup(r => r.GetAll()).ReturnsAsync(cursos);
            _mapperMock.Setup(m => m.Map<CursoResponse>(It.IsAny<Curso>())).Returns(new CursoResponse());

            // Act
            var result = await _cursoService.listaCursos();

            // Assert
            Assert.NotEmpty(result);
            Assert.Equal(cursos.Count, result.Count);
            _cursoRepositoryMock.Verify(r => r.GetAll(), Times.Once);
            _mapperMock.Verify(m => m.Map<CursoResponse>(It.IsAny<Curso>()), Times.Exactly(cursos.Count));
        }


        [Fact]
        [Trait("CursoService", "ObterCurso")]
        public async Task DeveSerPossivelObterCurso()
        {
            // Arrange
            var id = 1;
            var curso = new Curso();
            var cursoResponse = new CursoResponse();
            _cursoRepositoryMock.Setup(r => r.Get(id)).ReturnsAsync(curso);
            _mapperMock.Setup(m => m.Map<CursoResponse>(curso)).Returns(cursoResponse);

            // Act
            var result = await _cursoService.ObterCurso(id);

            // Assert
            Assert.Equal(cursoResponse, result);
            _cursoRepositoryMock.Verify(r => r.Get(id), Times.Once);
            _mapperMock.Verify(m => m.Map<CursoResponse>(curso), Times.Once);
        }

        [Fact]
        [Trait("CursoService", "ObterCurso")]
        public async Task DeveRetornarExceptionQuandoObterCurso()
        {
            // Arrange
            var id = 1;
            var exception = new Exception("Lancou erro");
            _cursoRepositoryMock.Setup(r => r.Get(id)).ThrowsAsync(exception);
       
            // Act & Assert
            await Assert.ThrowsAsync<Exception>(async () => await _cursoService.ObterCurso(id));

            _cursoRepositoryMock.Verify(r => r.Get(id), Times.Once);
        }
    }

}