# Web API em DDD - Autoglass - Vitor Capelos

Primeiro crie um Database e defina o nome dele. Dentro do AppSettings altere o nome do Database para o novo que acabou de criar, insira seu nome de usuário e senha de login no SQL.

Para criar a tabale dentro do banco utilize:

'''
CREATE TABLE Produtos (
	Id INT IDENTITY(1, 1) NOT NULL,
	Nome Varchar(200) NOT NULL,
	Descricao VARCHAR(400) NOT NULL,
	DataFrabricacao DATETIME,
	DataValidade DATETIME,
	DataCadastro DATETIME,
	CodigoFornecedor VARCHAR(100),
	DescricaoFornecedor VARCHAR(400),
	CnpjFornecedor VARCHAR(14),
	Ativo BIT
)
'''
