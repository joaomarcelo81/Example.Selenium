using AutoMapper;
using DesafioTecnicoArtycs.Api.Model;
using DesafioTecnicoArtycs.Domain.Dto.Reponse;
using DesafioTecnicoArtycs.Domain.Dto.Request;
using DesafioTecnicoArtycs.Domain.Entities;
using DesafioTecnicoArtycs.Domain.Interfaces.Services;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace DesafioTecnicoArtycs.Api.Controllers
{
    /// <summary>
    /// Controller
    /// </summary>
    [Authorize]
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
        /// <summary>
        /// Listar os cursos
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [SwaggerOperation(Summary = "Listar os cursos", Description = "Retorna uma lista de todos os cursos disponíveis na base de dados.")]
        [SwaggerResponse((int)HttpStatusCode.OK, "Retornar lista de cursos")]
        [SwaggerResponse((int)HttpStatusCode.BadRequest , Constantes.BadRequestMessage)]
        [SwaggerResponse((int)HttpStatusCode.Unauthorized, Constantes.UnauthorizedMessage)]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Constantes.ErroInesperadoMessage)]
        public async Task<ActionResult<IList<CursoResponse>>> BuscarCursos()
        {
            var listaCursos = await _cursoService.listaCursos();

            var cursos = _mapper.Map<List<CursoResponse>>(listaCursos);
            
            return Ok(cursos);
        }
        /// <summary>
        /// Salvar os dados do Curso
        /// </summary>
        /// <param name="cursoRequest">Curso</param>
        /// <returns></returns>
        [HttpPost]
        [SwaggerOperation(Summary = "Salvar os dados do Curso", Description = "Salva os dados na base de dados")]
        [SwaggerResponse((int)HttpStatusCode.OK, Constantes.SuccessMessage)]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Constantes.BadRequestMessage)]
        [SwaggerResponse((int)HttpStatusCode.Unauthorized, Constantes.UnauthorizedMessage)]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Constantes.ErroInesperadoMessage)]
        public async Task<IActionResult> AdicionarCurso(CursoRequest cursoRequest)
        {
            var validationResult = _cursoValidator.Validate(cursoRequest);


            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            var cursoEntitie = _mapper.Map<Curso>(cursoRequest);
            await _cursoService.Adicionar(cursoEntitie);
            return Ok();
        }
        /// <summary>
        /// Salvar os dados do Curso
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="cursoRequest"></param>
        /// <returns></returns>
        [HttpPut]
        [SwaggerOperation(Summary = "Salvar os dados do Curso", Description = "Atualiza os dados de um curso na base de dados")]
        [SwaggerResponse((int)HttpStatusCode.OK, Constantes.SuccessMessage)]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Constantes.BadRequestMessage)]
        [SwaggerResponse((int)HttpStatusCode.Unauthorized, Constantes.UnauthorizedMessage)]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Constantes.ErroInesperadoMessage)]
        public async Task<IActionResult> AtualizarCurso(int Id, CursoRequest cursoRequest)
        {
            var validationResult = _cursoValidator.Validate(cursoRequest);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            var cursoEntitie = _mapper.Map<Curso>(cursoRequest);
            cursoEntitie.Id = Id;
            await _cursoService.Atualizar(cursoEntitie);
            return Ok();
        }

        /// <summary>
        /// Buscar os resultados da pesquisa no site da alura.
        /// </summary>
        /// <param name="busca"></param>
        /// <returns></returns>
        [HttpGet("BuscarCursoAlura")]
        [SwaggerOperation(Summary = "Buscar os resultados da pesquisa no site da alura.", Description = "Esse metodo irá executar uma busca no site da Alura buscando todas as informações que retornarem na busca")]
        [SwaggerResponse((int)HttpStatusCode.OK, Constantes.SuccessMessage)]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Constantes.BadRequestMessage)]
        [SwaggerResponse((int)HttpStatusCode.Unauthorized, Constantes.UnauthorizedMessage)]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Constantes.ErroInesperadoMessage)]
        public async Task<IActionResult> BuscarDadosPesquisa(string busca)
        {
            if (string.IsNullOrEmpty(busca))
            {
                return BadRequest("Parametro da busca precisa estar preenchido");
            }
            await _cursoService.BuscarDadosAlura(busca);
            return Ok();
        }
    }
   

}