# Configuracao:

Deverá ter instalado em sua máquina o .net core

Criar um banco de dados e configurar ele no app settings com o nome DefaultConnection como o exemplo abaixo

 "ConnectionStrings": {
    "DefaultConnection": "Server=localhostouseuip;Database=seubanco;User Id=seuid;Password=suasenha;"
  },

você irá rodar o seguinte comando
dotnet ef --startup-project ..\Livraria.Web\Livraria.web.csproj --project .\Livraria.Infra.csproj migrations add LivrosInicial

e após 

 dotnet ef --startup-project ..\Livraria.Web\Livraria.web.csproj --project .\Livraria.Infra.csproj database update 

 Esses comandos irão gerar uma nova migration e atualizar seu banco de dados.

No seu gerenciador de banco de dados, criar a tabela de log

CREATE TABLE [dbo].[Logs](
	[Id] [int] NOT NULL,
	[Message] [nvarchar](max) NULL,
	[MessageTemplate] [nvarchar](max) NULL,
	[Level] [nvarchar](128) NULL,
	[TimeStamp] [datetime] NULL,
	[Exception] [nvarchar](max) NULL,
	[Properties] [nvarchar](max) NULL,
	[Action] [nvarchar](max) NULL,
 CONSTRAINT [PK_Logs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

O programa está usando o Serilog para gerar logs

No Swagger está listando todas as rotas disponiveis

Utilizei DDD mas sinto que pequei em alguns aspectos, com mais calma irei adequar o uso das services para a criar o LivroApplication que irá englobar toda a lógica  

Muito obrigado pela oportunidade
