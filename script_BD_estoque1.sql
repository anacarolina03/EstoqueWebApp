USE [estoque]
GO
/****** Object:  User [admin]    Script Date: 27/02/2021 16:42:07 ******/
CREATE USER [admin] FOR LOGIN [admin] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [ana]    Script Date: 27/02/2021 16:42:07 ******/
CREATE USER [ana] FOR LOGIN [ana] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [admin]
GO
ALTER ROLE [db_owner] ADD MEMBER [ana]
GO
/****** Object:  Table [dbo].[PRODUTO]    Script Date: 27/02/2021 16:42:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PRODUTO](
	[cod_produto] [int] IDENTITY(1,1) NOT NULL,
	[txt_descricao] [nvarchar](50) NOT NULL,
	[txt_marca] [nvarchar](50) NOT NULL,
	[vlr_preco] [float] NOT NULL,
	[dt_cadastro] [datetime] NOT NULL,
	[dt_lancamento] [datetime] NOT NULL,
	[cod_tipo_produto] [int] NOT NULL,
 CONSTRAINT [PK_PRODUTO] PRIMARY KEY CLUSTERED 
(
	[cod_produto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TIPO_PRODUTO]    Script Date: 27/02/2021 16:42:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TIPO_PRODUTO](
	[cod_tipo_produto] [int] IDENTITY(1,1) NOT NULL,
	[txt_descricao] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_TIPO_PRODUTO] PRIMARY KEY CLUSTERED 
(
	[cod_tipo_produto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[USUARIO]    Script Date: 27/02/2021 16:42:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[USUARIO](
	[cod_cliente] [int] IDENTITY(1,1) NOT NULL,
	[txt_usuario] [nvarchar](50) NOT NULL,
	[senha] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_USUARIO] PRIMARY KEY CLUSTERED 
(
	[cod_cliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[PRODUTO]  WITH CHECK ADD  CONSTRAINT [fk_produto_tipo_produto] FOREIGN KEY([cod_tipo_produto])
REFERENCES [dbo].[TIPO_PRODUTO] ([cod_tipo_produto])
GO
ALTER TABLE [dbo].[PRODUTO] CHECK CONSTRAINT [fk_produto_tipo_produto]
GO
