

CREATE TABLE tblCategoria
(
Id INT PRIMARY KEY IDENTITY,
Descricao VARCHAR(100));

CREATE TABLE tblPermissao
(
Id INT PRIMARY KEY IDENTITY,
Descricao VARCHAR(30));

CREATE TABLE tblFormaPagamento
(
Id INT PRIMARY KEY IDENTITY,
Descricao VARCHAR(20));

CREATE TABLE tblSexo
(
Id INT PRIMARY KEY IDENTITY,
Descricao VARCHAR(9))

CREATE TABLE tblEstado
(
Id INT PRIMARY KEY IDENTITY,
Estado VARCHAR(2));

-- Cria��o Tabelas Com FK

CREATE TABLE tblCidade
(
Id INT PRIMARY KEY IDENTITY,
Cidade VARCHAR(80),
EstadoId int FOREIGN KEY (EstadoID) REFERENCES tblEstado);

CREATE TABLE tblEndereco
(
Id INT PRIMARY KEY IDENTITY,
Endereco VARCHAR(80),
Numero INT,
Complemento VARCHAR(80),
CEP VARCHAR(20),
Bairro VARCHAR(60),
CidadeId INT FOREIGN KEY (CidadeId) REFERENCES tblCidade);

CREATE TABLE tblProduto
(
Id INT PRIMARY KEY IDENTITY,
Codigo INT,
Nome VARCHAR(80),
Preco MONEY,
CategoriaId INT FOREIGN KEY (CategoriaID) REFERENCES tblCategoria);


CREATE TABLE tblFuncionario
(
Id INT PRIMARY KEY IDENTITY,
Nome VARCHAR(60),
Email VARCHAR(80),
Telefone VARCHAR(11),
CPF VARCHAR(11),
Usuario VARCHAR(80),
Senha VARCHAR(80),
Ativo BIT,
SexoId INT FOREIGN KEY (SexoId) REFERENCES tblSexo,
EnderecoId INT FOREIGN KEY (EnderecoId) REFERENCES tblEndereco,
PermissaoId INT FOREIGN KEY (PermissaoId) REFERENCES tblPermissao);

CREATE TABLE tblCliente(
Id INT PRIMARY KEY IDENTITY,
Nome VARCHAR(60),
CPF VARCHAR(11),
Telefone VARCHAR(11),
Email VARCHAR(80),
SexoId INT FOREIGN KEY (SexoId) REFERENCES tblSexo,
EnderecoId INT FOREIGN KEY (EnderecoId) REFERENCES tblEndereco,
FuncionarioId INT FOREIGN KEY (FuncionarioId) REFERENCES tblFuncionario);

CREATE TABLE tblStatusVenda(
	Id int PRIMARY key IDENTITY,
	Descricao VARCHAR(30),
)

CREATE TABLE tblVenda
(
Id INT PRIMARY KEY IDENTITY,
Preco MONEY,
ClienteId INT FOREIGN KEY (ClienteId) REFERENCES tblCliente,
FuncionarioId INT FOREIGN KEY (FuncionarioId) REFERENCES tblFuncionario,
FormaPagamentoId INT FOREIGN KEY (FormaPagamentoId) REFERENCES tblFormaPagamento,
StatusVendaId INT FOREIGN KEY (StatusVendaId) REFERENCES tblStatusVenda);




CREATE TABLE tblNotaFiscal
(
Id INT PRIMARY KEY IDENTITY,
Numero INT,
CPF VARCHAR(11),
VendaId INT FOREIGN KEY (VendaId) REFERENCES tblVenda)


CREATE TABLE tblItens
(
Id INT PRIMARY KEY IDENTITY,
Preco MONEY,
Quantidade INT,
VendaId INT FOREIGN KEY (VendaId) REFERENCES tblVenda,
ProdutoId INT FOREIGN KEY (ProdutoId) REFERENCES tblProduto);

