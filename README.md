<style>
.scrollbar {
    max-height: 300px; /* Define a altura máxima para o bloco de código */
    overflow-y: scroll; /* Adiciona a barra de rolagem vertical */
}
</style>

# Documentação do Projeto


**Content**

<!-- TOC depthFrom:1 depthTo:6 withLinks:1 updateOnSave:1 orderedList:0 -->

- [Configuração do Ambiente de Desenvolvimento](#configuracao-ambiente-desenvolvimento)
- [GitHub](#github)
- [Documentação da API com Swagger](#documentacao-da-api-com-swagger)
- [Configuração do Swagger](#configuracao-swagger)
- [Testes unitários](#testes-unitarios)
<!-- /TOC -->


## Introdução

Este documento fornece uma visão geral do Projeto DesafioTecnicoArtycs, que é um aplicativo desenvolvido em C# utilizando os princípios do Domain-Driven Design (DDD). O projeto utiliza o GitFlow como modelo de fluxo de trabalho de controle de versão, FluentValidation para validação de dados, AutoMapper para mapeamento de objetos, EntityFramework como ORM (Object-Relational Mapping), .NET Core 6 como plataforma de desenvolvimento, Web API para construir uma API RESTful, XUnit para testes unitários seguindo o padrão Triple A (Arrange, Act, Assert), Documentação Swagger para documentar a API e Selenium WebDriver para testes de interface. Também utilizamos o MOQ para criar objetos simulados (mocks) durante os testes unitários, garantindo a correta isolação de dependências e facilitando a definição de comportamentos específicos dos objetos simulados.

### Tecnologias utlizadas no desenvolvimento
#### .NET Core 6
O .NET Core 6 é uma plataforma de desenvolvimento multiplataforma, de código aberto, para a criação de aplicativos modernos. Ele oferece uma ampla gama de recursos e melhorias em relação às versões anteriores do .NET Core. No DesafioTecnicoArtycs, o .NET Core 6 é a base para o desenvolvimento da aplicação.

#### Web API
A Web API é uma abordagem para construir APIs RESTful usando o protocolo HTTP. Ela permite a exposição dos recursos da aplicação de forma padronizada e de fácil consumo por parte dos clientes. No DesafioTecnicoArtycs, a Web API é utilizada para criar endpoints que permitem a comunicação com o aplicativo.

#### FluentValidation
O FluentValidation é uma biblioteca de validação de dados para aplicações .NET. Ele oferece uma maneira simples e fluente de definir regras de validação para as entidades do domínio. No DesafioTecnicoArtycs, o FluentValidation é utilizado para garantir a integridade dos dados e a consistência das regras de negócio.

#### AutoMapper
O AutoMapper é uma biblioteca que simplifica o mapeamento de objetos em aplicações .NET. Ele permite a configuração de regras de mapeamento entre classes de domínio e classes de DTO (Data Transfer Objects). No DesafioTecnicoArtycs, o AutoMapper é utilizado para facilitar a conversão de objetos entre as camadas do aplicativo.

#### Entity Framework
O Entity Framework é um framework ORM (Object-Relational Mapping) que permite o mapeamento de objetos para bancos de dados relacionais. Ele simplifica a interação com o banco de dados e oferece recursos avançados, como migrações de banco de dados e consultas LINQ. No DesafioTecnicoArtycs, o Entity Framework é utilizado para acessar e manipular os dados no banco de dados.

### Arquitetura do Projeto
#### Domain-Driven Design (DDD)
O DesafioTecnicoArtycs foi desenvolvido seguindo os princípios do Domain-Driven Design (DDD). O DDD é uma abordagem de design de software que enfoca a modelagem do domínio da aplicação. Ele promove a separação clara entre a lógica de negócios e a implementação técnica, permitindo uma melhor compreensão e manutenção do sistema.


## Versionamento e Repositório

#### GitHub

GitHub é uma plataforma web baseada em Git, amplamente utilizada para hospedar e gerenciar repositórios de código-fonte. Ele oferece recursos como controle de versão, colaboração em equipe, rastreamento de problemas e integração contínua. O GitHub é popular entre desenvolvedores e projetos de código aberto, fornecendo um ambiente centralizado para compartilhar, revisar e colaborar em projetos de software.
#### GitFlow
O GitFlow é um modelo de fluxo de trabalho de controle de versão baseado no Git. Ele fornece uma estrutura clara para o gerenciamento de branches e releases do projeto. O DesafioTecnicoArtycs segue o GitFlow para garantir um desenvolvimento organizado e controlado.

#### Swagger
O Swagger é uma ferramenta de documentação de API que facilita a criação, o teste e a documentação de APIs RESTful. Ele fornece uma interface interativa para explorar e testar os endpoints da API. No DesafioTecnicoArtycs, o Swagger é utilizado para documentar os endpoints da Web API e fornecer uma documentação clara e fácil de usar para os desenvolvedores e consumidores da API.


### Testes
#### MOQ
O MOQ é uma biblioteca de mocking para .NET que permite a criação de objetos simulados para facilitar a realização de testes unitários. Ele é amplamente utilizado no desenvolvimento de aplicações C# para isolar as dependências e garantir que o código seja testado de forma isolada.

#### XUnit
O XUnit é um framework de teste unitário para aplicações .NET. Ele fornece uma maneira simples e eficiente de escrever testes automatizados para verificar o comportamento do código. No DesafioTecnicoArtycs, o XUnit é utilizado para escrever testes unitários que garantem a qualidade e o funcionamento correto do sistema.

### Outras tecnologias utlizadas no projeto

#### Selenium WebDriver
O Selenium WebDriver é uma ferramenta de automação de testes que permite a interação com aplicativos web. Ele simula a interação de um usuário real com o aplicativo, permitindo a execução de testes de interface automatizados. No DesafioTecnicoArtycs, o Selenium WebDriver é utilizado para realizar testes de interface que garantem a correta interação do aplicativo com o usuário.




<a name="github"></a>
## Configuração do Ambiente de Desenvolvimento
Antes de iniciar o desenvolvimento, é necessário configurar o ambiente de desenvolvimento. Siga as etapas abaixo para configurar o ambiente:

Instale o .NET Core 6: [Link para download](https://dotnet.microsoft.com/download/dotnet/6.0)
Instale o Git: [Link para download](https://git-scm.com/downloads)

Configure o GitFlow no repositório Git do projeto: Link para documentação do GitFlow
Configure a conexão com o banco de dados no arquivo `appsettings.json`.
Instale o Selenium WebDriver: Link para download

<a name="documentacao-da-api-com-swagger"></a>
## GitHub
Este documento descreve a estrutura e o fluxo de trabalho do projeto no [Github](https://github.com/joaomarcelo81/DesafioTecnicoArtycs), seguindo o padrão `GitFlow`. O `GitFlow` é um modelo de ramificação de código-fonte que oferece uma abordagem estruturada para controle de versão e colaboração em equipe. Este modelo promove uma separação clara entre o desenvolvimento de novas funcionalidades, correções de bugs e versões estáveis do software.

### Fluxo de Trabalho com o GitFlow


O fluxo de trabalho do `GitFlow` consiste em algumas etapas básicas que são executadas durante o desenvolvimento e lançamento do software. Aqui está um resumo das etapas principais:

**Desenvolvimento de Funcionalidades:** Crie um novo branch a partir do develop para desenvolver uma nova funcionalidade. Faça commits regulares e, quando a funcionalidade estiver concluída, crie um pull request para mesclar as alterações de volta para o develop. Após a revisão do código, faça a mesclagem.

**Correção de Bugs:** Caso seja necessário corrigir um bug, crie um novo branch a partir do develop ou do master, dependendo da gravidade do bug. Desenvolva a correção no branch criado e siga o mesmo processo de pull request e mesclagem descrito acima.

**Preparação para o Lançamento:** Quando estiver pronto para lançar uma nova versão estável do software, crie um branch release a partir do develop. Neste branch, faça os ajustes finais, como atualização da documentação, versionamento e preparação de pacotes. Teste a versão no branch release e, quando estiver pronto, faça a mesclagem no master e no develop.

**Hotfixes:** Caso surja um bug crítico na versão de produção, crie um branch hotfix a partir do master. Desenvolva a correção no branch criado e siga o mesmo processo de pull request e mesclagem descrito acima. Após a mesclagem, faça a atualização da versão no master e no develop.


O repositório do projeto no Github deve seguir a seguinte estrutura básica:

1. Master Branch: O branch master é o ramo principal do repositório e contém o código-fonte da versão mais recente e estável do software. Cada commit no master deve corresponder a uma versão lançada do software.

2. Develop Branch: O branch develop é o ramo de desenvolvimento principal. Ele contém as últimas alterações em desenvolvimento e serve como ponto de integração para as funcionalidades e correções de bugs em andamento.

3. Feature Branches: Para cada nova funcionalidade ou tarefa, deve-se criar um novo branch a partir do develop. O nome do branch deve seguir o padrão feature/<nome-da-funcionalidade> ou feature/<numero-da-tarefa>.

4. Hotfix Branches: Caso seja necessário corrigir bugs críticos na versão de produção, deve-se criar um novo branch a partir do master com o nome no padrão hotfix/<nome-do-bug>.

5. Release Branches: Antes de lançar uma nova versão estável do software, deve-se criar um novo branch a partir do develop para preparar a versão. O nome do branch deve seguir o padrão release/<numero-da-versao>.


#### Fluxo de uma Feature
!["Swagger"](assets/gitflow.png "")

#### Fluxo de um HotFix
!["Swagger"](assets/gitflow_hotfix.png "")




<a name="documentacao-da-api-com-swagger"></a>

## Documentação da API com Swagger
O projeto utiliza o Swagger para documentar a API. O Swagger gera automaticamente uma documentação interativa da API com base nos atributos de rota e modelo dos controladores. 

Acesse a documentação da API no endpoint `/swagger` após iniciar a aplicação.

!["Swagger"](assets/swagger_1.jpg "")

<a name="configuracao-swagger"></a>

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


## Testes unitários

Os testes unitários são uma parte fundamental do *DesafioTecnicoArtycs*. Eles permitem verificar se cada componente individual do sistema está funcionando corretamente. Utilizamos o framework XUnit para escrever e executar os testes, garantindo a qualidade e a integridade do código.

#### XUnit

O XUnit é um framework de teste unitário para aplicações `.NET`. Ele fornece uma maneira simples e eficiente de escrever testes automatizados para verificar o comportamento do código. No *DesafioTecnicoArtycs*, o `XUnit` é utilizado para escrever testes unitários que garantem a qualidade e o funcionamento correto do sistema.

No *DesafioTecnicoArtycs*, além do framework `XUnit`, utilizamos o `MOQ` para criar objetos simulados (mocks) e implementamos o padrão Triple A (Arrange, Act, Assert) nos testes unitários. O `MOQ` nos permite isolar as dependências e definir comportamentos específicos para os objetos simulados. O padrão Triple A nos ajuda a organizar os testes em etapas claras de configuração, execução e verificação. Essas práticas contribuem para a criação de testes unitários robustos e confiáveis no projeto.

#### MOQ

O `MOQ`é uma biblioteca de mocking para `.NET` que permite a criação de objetos simulados para facilitar a realização de testes unitários. Ele é amplamente utilizado no desenvolvimento de aplicações C# para isolar as dependências e garantir que o código seja testado de forma isolada.


###### Funcionalidades e Vantagens do MOQ

1. **Criação de Objetos Simulados:** Com o `MOQ`, é possível criar objetos simulados (mocks) que se comportam como as classes reais. Isso permite que você defina o comportamento esperado desses objetos durante os testes.

2. **Definição de Comportamentos:** O `MOQ` permite que você defina comportamentos específicos para os objetos simulados. Você pode configurar retornos de métodos, lançamento de exceções e outros comportamentos personalizados para simular diferentes cenários durante os testes.

3. **Verificação de Chamadas:** O `MOQ` também oferece recursos para verificar se determinados métodos foram chamados durante a execução do código testado. Isso é útil para garantir que o código esteja interagindo corretamente com as dependências.

4. **Fácil Integração com Estruturas de Teste:** O `MOQ` se integra perfeitamente com estruturas de teste como o `XUnit`, facilitando a criação e execução de testes unitários.