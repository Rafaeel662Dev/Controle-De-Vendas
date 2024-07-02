use AmorEmCaldasHomolagacao

GO
--Criação Tabelas SEM FK

CREATE TABLE tblCategoria(
Id INT PRIMARY KEY IDENTITY,
Descricao VARCHAR(100));

CREATE TABLE tblPermissao(
Id INT PRIMARY KEY IDENTITY,
Descricao VARCHAR(30));

CREATE TABLE tblFormaPagamento(
Id INT PRIMARY KEY IDENTITY,
Descricao VARCHAR(20));

CREATE TABLE tblSexo(
Id INT PRIMARY KEY IDENTITY,
Descricao VARCHAR(9))

CREATE TABLE tblEstado(
Id INT PRIMARY KEY IDENTITY,
Estado VARCHAR(2));

-- Criação Tabelas Com FK

create table tblCidade (
Id	int identity primary key,
Cidade	varchar(100),
EstadoId	int foreign key (EstadoId) references tblEstado
);

CREATE TABLE tblEndereco(
Id INT PRIMARY KEY IDENTITY,
Endereco VARCHAR(80),
Numero INT,
Complemento VARCHAR(80),
CEP VARCHAR(20),
Bairro VARCHAR(60),
CidadeId INT FOREIGN KEY (CidadeId) REFERENCES tblCidade);

CREATE TABLE tblProduto(
Id INT PRIMARY KEY IDENTITY,
Codigo INT,
Nome VARCHAR(80),
Preco MONEY,
CategoriaId INT FOREIGN KEY (CategoriaID) REFERENCES tblCategoria);


CREATE TABLE tblFuncionario(
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

CREATE TABLE tblVenda(
Id INT PRIMARY KEY IDENTITY,
DataHora DateTime,
ClienteId INT FOREIGN KEY (ClienteId) REFERENCES tblCliente,
FuncionarioId INT FOREIGN KEY (FuncionarioId) REFERENCES tblFuncionario,
FormaPagamentoId INT FOREIGN KEY (FormaPagamentoId) REFERENCES tblFormaPagamento);

CREATE TABLE tblNotaFiscal(
Id INT PRIMARY KEY IDENTITY,
Numero INT,
VendaId INT FOREIGN KEY (VendaId) REFERENCES tblVenda)


CREATE TABLE tblItem(
Id INT PRIMARY KEY IDENTITY,
Quantidade INT,
Preco MONEY,
VendaId INT FOREIGN KEY (VendaId) REFERENCES tblVenda,
ProdutoId INT FOREIGN KEY (ProdutoId) REFERENCES tblProduto);




