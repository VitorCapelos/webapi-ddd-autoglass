# webapi-ddd-autoglass


Para criar a tabale dentro do banco:


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
