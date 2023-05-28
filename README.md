<style>
.scrollbar {
    max-height: 300px; /* Define a altura máxima para o bloco de código */
    overflow-y: scroll; /* Adiciona a barra de rolagem vertical */
}
</style>

# Documentação do Projeto

## Introdução

Este documento fornece uma visão geral do DesafioTecnicoArtycs, que é um aplicativo desenvolvido em C# utilizando os princípios do `Domain-Driven Design (DDD)`. O projeto utiliza o `GitFlow` como modelo de fluxo de trabalho de controle de versão, FluentValidation para validação de dados, AutoMapper para mapeamento de objetos, `EntityFramework` como ORM (Object-Relational Mapping), `.NET Core 6` como plataforma de desenvolvimento, Web API para construir uma API RESTful, `XUnit` para testes unitários, Documentação `Swagger` para documentar a API e `Selenium WebDriver` para testes de interface.

## Configuração do Ambiente de Desenvolvimento
Antes de iniciar o desenvolvimento, é necessário configurar o ambiente de desenvolvimento. Siga as etapas abaixo para configurar o ambiente:

Instale o .NET Core 6: [Link para download](https://dotnet.microsoft.com/download/dotnet/6.0)
Instale o Git: [Link para download](https://git-scm.com/downloads)
Configure o GitFlow no repositório Git do projeto: Link para documentação do GitFlow
Configure a conexão com o banco de dados no arquivo appsettings.json.

## Documentação da API com Swagger
O projeto utiliza o Swagger para documentar a API. O Swagger gera automaticamente uma documentação interativa da API com base nos atributos de rota e modelo dos controladores. 

Acesse a documentação da API no endpoint `/swagger` após iniciar a aplicação.

!["Swagger"](assets/swagger_1.jpg "")


### Configuração do Swagger
```csharp

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new()
    {
        Title = "Curso Api",
        Version = "v1",
        Contact = new OpenApiContact()
        {
            Name = "João",
            Email = "Joaomarcelo@teste.com"

        },
        Description = "Web Api para exemplo de sistema"
    });
    c.EnableAnnotations();
    c.AddSecurityDefinition("apikey", new OpenApiSecurityScheme
    {
        Name = "apikey",
        In = ParameterLocation.Header,
        Scheme = "apikey",
        Type = SecuritySchemeType.ApiKey,
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "apikey" }
            },
            new List<string>()
        }
    });
});
```


## Estrutura do Projeto
A estrutura do projeto segue o padrão de arquitetura DDD para separação de responsabilidades e modularização do código-fonte. A estrutura do projeto é a seguinte:

- DesafioTecnicoArtycs.Api
  - Models
  - Interfaces
  - Services
- DesafioTecnicoArtycs.Infrastructure
  - Data
  - Repositories
- DesafioTecnicoArtycs.Application
  - DTOs
  - Interfaces
  - Services
- DesafioTecnicoArtycs.CrossCutting.IoC
  - Controllers
  - ViewModels



### DesafioTecnicoArtycs.Api

O projeto DesafioTecnicoArtycs.Core contém os modelos de domínio, interfaces de serviços e interfaces de repositórios.

#### Estrutura do Projeto

<pre>
├── appsettings.Development.json
├── appsettings.json
├── DesafioTecnicoArtycs.Api.csproj
├── DesafioTecnicoArtycs.Api.csproj.user
├── DesafioTecnicoArtycsDB.db
├── Program.cs
└── Controllers
    └── CursoController.cs
└── Model
    ├── Constantes.cs
    └── Settings.cs

</pre>


### DesafioTecnicoArtycs.Infrastructure
O projeto DesafioTecnicoArtycs.Infrastructure contém a implementação dos repositórios e a configuração do EntityFramework para acesso aos dados.

### DesafioTecnicoArtycs.Application
O projeto DesafioTecnicoArtycs.Application contém os serviços de aplicação e os DTOs (Data Transfer Objects) para transferência de dados entre a camada de aplicação e a camada de apresentação.

### DesafioTecnicoArtycs.CrossCutting.IoC
O projeto DesafioTecnicoArtycs.Web contém os controladores da API e as ViewModels para representação dos dados nas camadas de apresentação.

## Fluxo de Trabalho com o GitFlow

O projeto utiliza o GitFlow como modelo de fluxo de trabalho para controle de versão. O GitFlow define dois branches principais: master e develop, além de branches de suporte para o desenvolvimento de novas funcionalidades e correções de bugs. O fluxo de trabalho básico é o seguinte:

Crie um novo branch a partir do branch develop para o desenvolvimento de uma nova funcionalidade ou correção de bug.
Implemente a funcionalidade ou correção de bug no branch criado.
Faça o commit e o push das alterações para o branch remoto correspondente.
Ao concluir o desenvolvimento, crie um pull request para mesclar as alterações no branch develop.
Realize a revisão do código e, se aprovado, faça a mesclagem das alterações no branch develop.
Periodicamente, faça o merge do branch develop para o branch master para criar uma nova versão estável do software.


## Validação de Dados com FluentValidation
O projeto utiliza a biblioteca FluentValidation para a validação de dados. As regras de validação são definidas em classes separadas e associadas aos modelos de domínio. A validação é executada antes da persistência dos dados. Exemplo de uso:


```csharp
    public class CursoValidator : AbstractValidator<CursoRequest>
    {
        public CursoValidator()
        {         
            RuleFor(curso => curso.Titulo).NotEmpty().WithMessage("Titulo é obrigatorio.");
            RuleFor(curso => curso.Professor).NotEmpty().WithMessage("Professor é obrigatorio.");
            RuleFor(curso => curso.CargaHoraria).NotEmpty().WithMessage("CargaHoraria é obrigatorio.");
            RuleFor(curso => curso.Descricao).NotEmpty().WithMessage("Descricao é obrigatorio.");
        }
    }
```

## Desenvolvimento de Web API com .NET Core

O projeto utiliza o `.NET Core 6` para desenvolvimento de uma Web API. Os controladores da API são criados no projeto DesafioTecnicoArtycs.WebApi e seguem as convenções RESTful. Exemplo de uso:

### Código Web API
```csharp{.scrollbar}
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
```


#### Autenticação de API com API Key e Basic Authentication

A autenticação é um aspecto crucial ao construir uma API Web. Duas formas comuns de autenticação são a autenticação por chave de API (API Key) e a autenticação básica (Basic Authentication). Este documento explica como implementar essas formas de autenticação em uma API Web desenvolvida em `C#` com `.NET Core 6.`

#### API Key
A autenticação por API Key é uma forma simples de autenticar solicitações de API usando uma chave exclusiva. Cada solicitação à API deve incluir essa chave para ser considerada autenticada. 


## Mapeamento de Objetos com AutoMapper
O projeto utiliza o AutoMapper para realizar o mapeamento entre objetos. A configuração do mapeamento é feita no momento da inicialização da aplicação. Exemplo de uso:
```csharp
```



## Persistência de Dados com EntityFramework
O projeto utiliza o EntityFramework como ORM para a persistência de dados. A configuração da conexão com o banco de dados é feita no arquivo `appsettings.json`. Exemplo de uso:
```csharp
```