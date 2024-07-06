INSERT INTO tblCategoria (Descricao) VALUES ('Bolo');
INSERT INTO tblCategoria (Descricao) VALUES ('Torta');
INSERT INTO tblCategoria (Descricao) VALUES ('Sobremesa');
INSERT INTO tblCategoria (Descricao) VALUES ('Doces');
INSERT INTO tblCategoria (Descricao) VALUES ('Outros');




INSERT INTO tblPermissao (Descricao) VALUES ('Administrador');
INSERT INTO tblPermissao (Descricao) VALUES ('Fiscalização');
INSERT INTO tblPermissao (Descricao) VALUES ('Membro');



INSERT INTO tblFormaPagamento (Descricao)
VALUES 
    ('Dinheiro'),
    ('Crédito'),
    ('Débito'),
	('Pix');



INSERT INTO tblSexo (Descricao) VALUES ('Masculino');
INSERT INTO tblSexo (Descricao) VALUES ('Feminino');




INSERT INTO tblEndereco (Endereco, Numero, Complemento, CEP, Bairro, CidadeId)
VALUES 
    ('Rua Amador Bueno', 25, ' ', '08515-035', 'Vila Velha', 1),
    ('Rua do Grito', 1015, 'Ap 15', '07308-001', 'Vila Nova', 1),
    ('Rua Nova Era', 705, ' ', '04235-015', 'Beira Mar', 1),
	('Rua Barra Funda', 1500, 'Ap 35', '035481-000', 'São Domingos', 1),
	('Avenida Salgado Filho', 310, ' ', '06010-050', 'Parada', 3),
	('Travessa Rais De Estrela', 86, 'Ap 08', '08351-045', 'Florida', 2);
	



INSERT INTO tblProduto (Codigo, Nome, Preco, CategoriaId)
VALUES
(2024010201, 'Bolo de Chocolate com Cobertura', 45.80, 1),
(2024010202, 'Bolo de Ninho & nutella', 12.00, 1),
(2024010203, 'Bolo de Laranja', 12.00, 1),
(2024010204, 'Bolo de Milho', 12.00, 1),
(2024010205, 'Bolo com Recheio de Morango', 37.99, 1),
(2024010206, 'Torta de Limão', 20.00, 2),
(2024010207, 'Bolo de Paçoca', 15.00, 1),
(2024010208, 'Brigadeiro', 3.50, 4),
(2024010209, 'Brigadeiro de Colher', 5.00, 4),
(2024010210, 'Brigadeiro de Pistache', 3.50, 4),
(2024010211, 'Brigadeiro de Café', 3.50, 1),
(2024010212, 'Bolo Trufado', 45.00, 1),
(2024010213, 'Brigadeiro de Paçoca', 3.50, 4),
(2024010214, 'Pavê de Chocolate', 25.00, 3),
(2024010215, 'Pudim de Leite Condensado', 15.00, 3),
(2024010216, 'Bolo de Iogurte', 15.00, 1),
(2024010217, 'Mousse de Maracujá', 15.00, 3),
(2024010218, 'Mousse de Limão', 15.00, 1),
(2024010219, 'Brigadeirão', 20.00, 4),
(2024010220, 'Torta Holandesa', 45.00, 2),
(10, 'Pé de Moleque', 05.00, 4),
(11, 'Maria Mole', 45.00, 4),
(12, 'Pudim de Leite', 8.97, 5);






INSERT INTO tblFuncionario (Nome, Email, Telefone, CPF, Usuario, Senha, Ativo, SexoId,EnderecoId, PermissaoId)

VALUES
    ('Livia Rosa Camargo', 'livia@pedaco.com', '11945261215', '10298532077', 'livia.1515', ' ', 1,1, 1, 1),
    ('Silvana Silmara Silva', 'silvanass@pedaco.com', '11938455091', '27235546000', 'silvana.3578', ' ', 1, 1 , 3, 1),
    ('Carlos Alberto Pacheco', 'carlosap@pedaco.com', '11951610755', '43726303014','pacheco.8799', '', 1, 2, 2, 2),
    ('Rafael', 'rafael@pedaco.com', '11951610755', '11111111111','rafael.amoremcaldas','4c29f94d61f96dde64a65202a6de6700',1, 2, 2, 1),
    ('Livia', 'livia@pedaco.com', '11951610755', '22222222222','livia.amoremcaldas', '4c29f94d61f96dde64a65202a6de6700', 1,2, 2, 3),
    ('Fernando', 'fernado@pedaco.com', '11951610755', '33333333333','fernando.amoremcaldas', '4c29f94d61f96dde64a65202a6de6700',1, 2, 2, 2);


	
	




INSERT INTO tblCliente (Nome, CPF, Telefone, Email, SexoId, EnderecoId, FuncionarioId)
VALUES
    ('Pedro Henrique Carvalho', '10156103079', '13992953299', 'pedro.henrique@gmail.com', 2, 1, 1),
    ('Luana Silva', '76433128009', '11987800617', 'luanasila@yahoo.com.br', 1, 3, 1),
    ('Clara Maria Mendoça', '24164350008', '11938973314', 'claramaria.mendoca@hotmail.com', 1, 3, 1),
    ('AVULSO', '00000000000', NULL, NULL, 1, 3, 1);

	





INSERT INTO tblVenda (ClienteId, FuncionarioId, FormaPagamentoId)
VALUES 
(1, 1, 2),
(2, 2, 3),	
(3, 3, 1);



INSERT INTO tblNotaFiscal (Numero, CPF, VendaId)
VALUES 
(353528,'11111111111', 1),
(353529,'11111111111', 2),
(353538,'11111111111', 3);




INSERT INTO tblItens (Quantidade, Preco, VendaId, ProdutoId)
VALUES
    (1, 45.80, 1, 1),
    (1, 12.00, 2, 2),
    (1, 12.00, 3, 3);
    