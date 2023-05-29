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

        public CursoController(ICursoService cursoService, IValidator<CursoRequest> cursoValidator)
        {
            _cursoService = cursoService;
            _cursoValidator = cursoValidator;
        }
        /// <summary>
        /// Retorna os dados de um curso
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Retorna os dados de um curso", Description = "Retorna os dados do curso pelo Id.")]
        [SwaggerResponse((int)HttpStatusCode.OK, "Retorna os dados de um curso")]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Constantes.BadRequestMessage)]
        [SwaggerResponse((int)HttpStatusCode.Unauthorized, Constantes.UnauthorizedMessage)]
        [SwaggerResponse((int)HttpStatusCode.NotFound, "Curso não econtrado")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Constantes.ErroInesperadoMessage)]      
        public async Task<ActionResult<CursoResponse>> ObterCurso(int id)
        {

            if (id<=0)
            {
                return BadRequest("Precisa fornecer um id");
            }
            var curso = await _cursoService.ObterCurso(id);
            if (curso == null)
            {
                return NotFound("Curso não econtrado");
            }

            return Ok(curso);
        }
        /// <summary>
        /// Remove os dados de um curso
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Remove os dados de um curso", Description = "Remove os dados do curso pelo Id.")]
        [SwaggerResponse((int)HttpStatusCode.OK, "Remove os dados de um curso")]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Constantes.BadRequestMessage)]
        [SwaggerResponse((int)HttpStatusCode.Unauthorized, Constantes.UnauthorizedMessage)]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Constantes.ErroInesperadoMessage)]
        public async Task<ActionResult> RemoverCursoPeloId(int id)
        {

            if (id <= 0)
            {
                return BadRequest("Precisa fornecer um id");
            }
            var cursoId = await _cursoService.RemoverCurso(id);
            if (cursoId==0)
            {
                return NotFound("Curso não econtrado");
            }

            return Ok();
        }
        /// <summary>
        /// Listar os cursos
        /// </summary>
        /// <returns></returns>
        [HttpGet("Todos")]
        [SwaggerOperation(Summary = "Listar os cursos", Description = "Retorna uma lista de todos os cursos disponíveis na base de dados.")]
        [SwaggerResponse((int)HttpStatusCode.OK, "Retornar lista de cursos")]
        [SwaggerResponse((int)HttpStatusCode.BadRequest , Constantes.BadRequestMessage)]
        [SwaggerResponse((int)HttpStatusCode.Unauthorized, Constantes.UnauthorizedMessage)]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Constantes.ErroInesperadoMessage)]
        public async Task<ActionResult<IList<CursoResponse>>> BuscarCursos()
        {
            var listaCursos = await _cursoService.listaCursos();
            
            return Ok(listaCursos);
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
        public async Task<IActionResult> AdicionarCurso([FromBody] CursoRequest cursoRequest)
        {
            var validationResult = _cursoValidator.Validate(cursoRequest);


            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
       
            await _cursoService.Adicionar(cursoRequest);
            return Ok();
        }
        /// <summary>
        /// Salvar os dados do Curso
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cursoRequest"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Salvar os dados do Curso", Description = "Atualiza os dados de um curso na base de dados")]
        [SwaggerResponse((int)HttpStatusCode.OK, Constantes.SuccessMessage)]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Constantes.BadRequestMessage)]
        [SwaggerResponse((int)HttpStatusCode.Unauthorized, Constantes.UnauthorizedMessage)]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Constantes.ErroInesperadoMessage)]
        public async Task<IActionResult> AtualizarCurso(int id, [FromBody] CursoRequest cursoRequest)
        {
            if (id <= 0)
            {
                return BadRequest("Precisa fornecer um id");
            }
            var validationResult = _cursoValidator.Validate(cursoRequest);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            await _cursoService.Atualizar(id, cursoRequest);
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
        [SwaggerResponse((int)HttpStatusCode.NotFound, "Sem resultados para exibir")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Constantes.ErroInesperadoMessage)]
        public async Task<IActionResult> BuscarDadosPesquisa(string busca)
        {
            if (string.IsNullOrEmpty(busca))
            {
                return BadRequest("Parametro da busca precisa estar preenchido");
            }
            var resposta = await _cursoService.BuscarDadosAlura(busca);

            if(resposta== 0)
                return NotFound("Sem resultados para exibir");

            return Ok();
        }
    }
   

}