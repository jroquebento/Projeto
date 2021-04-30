--CREATE DATABASE Projeto;

SELECT * FROM CIDADE WHERE CODCIDADE=5

USE Projeto;

--Tabelas

--Tabela Categoria
CREATE TABLE Categoria(
	CodCategoria INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	Nome VARCHAR(150) NOT NULL
);
---------------------------------------------------
--Tabela Cidade
CREATE TABLE Cidade(
	CodCidade INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	Nome VARCHAR(50) NOT NULL,
	Uf CHAR(2)
);
---------------------------------------------------
--Tabela Fornecedor
CREATE TABLE Fornecedor(
	CodFornecedor INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	Cidade_CodCidade INT NOT NULL,
	Nome VARCHAR(50) NOT NULL,
	Endereco VARCHAR(50) NOT NULL,
	Num INT NOT NULL,
	Bairro VARCHAR (50) NOT NULL,
	Cep CHAR(9) NOT NULL,
	Contato VARCHAR(50) NOT NULL,
	Cnpj CHAR(18) NOT NULL,
	Insc VARCHAR(20) NOT NULL,
	Tel CHAR(14) NOT NULL
);

---------------------------------------------------
--Tabela Entrada
CREATE TABLE Entrada(
	CodEntrada INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	Transportadora_CodTransportadora INT NOT NULL,
	DataPed DATE NOT NULL,
	DataEntr DATE NOT NULL,
	Total DECIMAL(5,2),
	Frete DECIMAL(5,2),
	NumNf INT NOT NULL,
	Imposto DECIMAL(5,2)
);
---------------------------------------------------
--Tabela Transportadora
CREATE TABLE Transportadora(
	CodTransportadora INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	Cidade_CodCidade INT NOT NULL,
	Nome VARCHAR(50) NOT NULL,
	Endereco VARCHAR(50) NOT NULL,
	Num INT NOT NULL,
	Bairro VARCHAR(50) NOT NULL,
	Cep CHAR(9) NOT NULL,
	Cnpj CHAR(18) NOT NULL,
	Insc VARCHAR(20) NOT NULL,
	Contato VARCHAR(50) NOT NULL,
	Tel CHAR(14) NOT NULL
);
---------------------------------------------------
--Tabela Loja
CREATE TABLE Loja(
	CodLoja INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	Cidade_CodCidade INT NOT NULL,
	Nome VARCHAR(50) NOT NULL,
	Endereco VARCHAR(100) NOT NULL,
	Num INT NOT NULL,
	Bairro VARCHAR(50) NOT NULL,
	Tel CHAR(14),
	Insc VARCHAR(20) NOT NULL,
	Cnpj CHAR(18)
);
---------------------------------------------------
--Tabela Produto
CREATE TABLE Produto(
	CodProduto INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	Categoria_CodCategoria INT NOT NULL,
	Fornecedor_CodFornecedor INT NOT NULL,
	Descricao VARCHAR(250) NOT NULL,
	Peso DECIMAL(5,2) NOT NULL,
	Controlado BIT NOT NULL,
	QtdeMin INT NOT NULL,
);
---------------------------------------------------
--Tabela ItemEntrada
CREATE TABLE ItemEntrada(
	CodItemEntrada INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	Produto_CodProduto INT NOT NULL,
	Entrada_CodEntrada INT NOT NULL,
	Lote VARCHAR(10) NOT NULL,
	Qtde INT NOT NULL,
	Valor DECIMAL(5,2)
);
---------------------------------------------------
--Tabela ItemSaida
CREATE TABLE ItemSaida(
	CodItemSaida INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	Saida_CodSaida INT NOT NULL,
	Produto_CodProduto INT NOT NULL,
	Lote VARCHAR(10) NOT NULL,
	Qtde INT NOT NULL,
	Valor DECIMAL(5,2)
);

---------------------------------------------------
--Tabela Saida
CREATE TABLE Saida(
	CodSaida INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	Loja_CodLoja INT NOT NULL,
	Transportadora_CodTransportadora INT NOT NULL,
	Total DECIMAL(5,2),
	Frete DECIMAL(5,2),
	Imposto DECIMAL (5,2)
	
);
--FOREIGN KEYS

--FK Cidade
ALTER TABLE Fornecedor ADD CONSTRAINT FK_Fornecedor_CodCidade FOREIGN KEY(Cidade_CodCidade)
REFERENCES Cidade (CodCidade);

--FK Transportadora
ALTER TABLE Entrada ADD CONSTRAINT FK_Entrada_CodTransportadora 
FOREIGN KEY (Transportadora_CodTransportadora) 
REFERENCES Transportadora (CodTransportadora);

--FK Cidade
ALTER TABLE Transportadora
ADD CONSTRAINT FK_Transportadora_CodCidade FOREIGN KEY (Cidade_CodCidade)
REFERENCES Cidade (CodCidade);

--FK Cidade
ALTER TABLE Loja ADD CONSTRAINT FK_Loja_CodCidade FOREIGN KEY (Cidade_CodCidade)
REFERENCES Cidade (CodCidade);

--FK Categoria
ALTER TABLE Produto  
ADD  CONSTRAINT FK_Produto_CodCategoria FOREIGN KEY(Categoria_CodCategoria)
REFERENCES Categoria (CodCategoria);
--FK Fornecedor
ALTER TABLE Produto  
ADD  CONSTRAINT FK_Produto_CodFornecedor FOREIGN KEY(Fornecedor_CodFornecedor)
REFERENCES Fornecedor (CodFornecedor);

--FK Produto
ALTER TABLE ItemEntrada 
ADD CONSTRAINT FK_ItemEntrada_CodProduto FOREIGN KEY (Produto_CodProduto)
REFERENCES Produto (CodProduto);
--FK Entrada
ALTER TABLE ItemEntrada
ADD CONSTRAINT FK_ItemEntrada_CodEntrada FOREIGN KEY (Entrada_CodEntrada)
REFERENCES Entrada (CodEntrada);

--FK Saida
ALTER TABLE ItemSaida ADD CONSTRAINT FK_ItemSaida_CodSaida FOREIGN KEY (Saida_CodSaida)
REFERENCES Saida (CodSaida);
--FK Produto
ALTER TABLE ItemSaida ADD CONSTRAINT FK_ItemSaida_CodProduto FOREIGN KEY (Produto_CodProduto)
REFERENCES Produto (CodProduto);

--FK Loja
ALTER TABLE Saida ADD CONSTRAINT FK_Saida_CodLoja FOREIGN KEY (Loja_CodLoja)
REFERENCES Loja (CodLoja);

--FK Transportadora 
ALTER TABLE Saida ADD CONSTRAINT FK_Saida_CodTransportadora
FOREIGN KEY (Transportadora_CodTransportadora) 
REFERENCES Transportadora (CodTransportadora);

USE Projeto;

SELECT * FROM Produto; 

SELECT * FROM Categoria WHERE NOME LIKE 'P%'

--INSERT INTO ITEMSAIDA VALUES (1, 1, '520b',2, 300);




