using AutoMapper;
using DesafioTecnicoArtycs.Api.Model;
using DesafioTecnicoArtycs.Domain.Dto.Reponse;
using DesafioTecnicoArtycs.Domain.Dto.Request;
using DesafioTecnicoArtycs.Domain.Entities;
using DesafioTecnicoArtycs.Domain.Interfaces.Services;
using DesafioTecnicoArtycs.Infra.Migrations;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Diagnostics.CodeAnalysis;
using System.Net;

namespace DesafioTecnicoArtycs.Api.Controllers
{
    
    //[Authorize]
    [Route("api/curso")]
    [ApiController]
    public class CursoController : Controller
    {

        private readonly ICursoService _cursoService;
        private readonly IValidator<CursoRequest> _cursoValidator;
        public readonly IMapper _mapper;
        public CursoController(IMapper mapper, ICursoService cursoService, IValidator<CursoRequest> cursoValidator)
        {
            _cursoService = cursoService;
            _cursoValidator = cursoValidator;
            _mapper = mapper;
        }
         
        [HttpGet]
        [SwaggerOperation(Summary = "Listar os cursos", Description = "Retorna uma lista de todos os cursos disponíveis na base de dados.")]
        [SwaggerResponse((int)HttpStatusCode.OK, "Retornar lista de cursos")]
        [SwaggerResponse((int)HttpStatusCode.BadRequest , Constantes.BadRequestMessage)]
        [SwaggerResponse((int)HttpStatusCode.Unauthorized, Constantes.UnauthorizedMessage)]
        public async Task<ActionResult<IList<CursoResponse>>> BuscarCursos()
        {
            var listaCursos = await _cursoService.listaCursos();

            var cursos = _mapper.Map<List<CursoResponse>>(listaCursos);
            
            return Ok(cursos);
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Salvar os dados do Curso")]
        [SwaggerResponse((int)HttpStatusCode.OK)]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Constantes.BadRequestMessage)]
        [SwaggerResponse((int)HttpStatusCode.Unauthorized, Constantes.UnauthorizedMessage)]
        public async Task<ActionResult<bool>> AdicionarCurso(CursoRequest curso)
        {
            var validationResult = _cursoValidator.Validate(curso);

            var cursoEntitie = _mapper.Map<Curso>(curso);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            await _cursoService.Adicionar(cursoEntitie);
            return Ok(true);
        }

        [HttpPut]
        [SwaggerOperation(Summary = "Salvar os dados do Curso")]
        [SwaggerResponse((int)HttpStatusCode.OK)]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Constantes.BadRequestMessage)]
        [SwaggerResponse((int)HttpStatusCode.Unauthorized, Constantes.UnauthorizedMessage)]
        public async Task<ActionResult<bool>> AtualizarCurso(int Id, CursoRequest curso)
        {
            var validationResult = _cursoValidator.Validate(curso);

            var cursoEntitie = _mapper.Map<Curso>(curso);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            cursoEntitie.Id = Id;
            await _cursoService.Atualizar(cursoEntitie);
            return Ok(true);
        }


        [HttpGet("BuscarCursoAlura")]
        [SwaggerOperation(Summary = "Buscar os resultados da pesquisa no site da alura.")]
        [SwaggerResponse((int)HttpStatusCode.OK)]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Constantes.BadRequestMessage)]
        [SwaggerResponse((int)HttpStatusCode.Unauthorized, Constantes.UnauthorizedMessage)]
        public async Task<ActionResult<bool>> AdicionarCurso(string nomeCurso)
        {
            await _cursoService.BuscarDadosAlura();
            return Ok(true);
        }
    }
}