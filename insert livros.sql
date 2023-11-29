use livraria

INSERT INTO Livro (Nome, Autor, Ano, Capa, Genero)
VALUES
('Dom Quixote', 'Miguel de Cervantes', 1612, 'https://upload.wikimedia.org/wikipedia/commons/0/08/Miguel_de_Cervantes_%281605%29_El_ingenioso_hidalgo_Don_Quixote_de_la_Mancha.png', 'Aventura'),
('O Senhor dos Anéis', 'J. R. R. Tolkien', 1954, 'https://upload.wikimedia.org/wikipedia/en/e/e9/First_Single_Volume_Edition_of_The_Lord_of_the_Rings.gif', 'Fantasia'),
('O Pequeno Príncipe', 'Antoine de Saint-Exupéry', 1943, 'https://upload.wikimedia.org/wikipedia/pt/4/47/O-pequeno-pr%C3%ADncipe.jpg', 'Juvenil'),
('Harry Potter e a Pedra Filosofal', 'J. K. Rowling', 1997, 'https://upload.wikimedia.org/wikipedia/pt/c/c1/Capa_HP1.jpg', 'Fantasia'),
('O Hobbit', 'J. R. R. Tolkien', 1937, 'https://upload.wikimedia.org/wikipedia/pt/7/72/The_Hobbit_Cover.JPG', 'Fantasia'),
('O Código Da Vinci', 'Dan Brown', 2003, 'https://upload.wikimedia.org/wikipedia/pt/6/6b/DaVinciCode.jpg', 'Suspense'),
('1984', 'George Orwell', 1949, 'https://encrypted-tbn3.gstatic.com/images?q=tbn:ANd9GcTTB_feEK0ju8YuCTrgnhTCef0X7Eq6n0sfRuKCDEOHyvpxGdWI', 'Ficção Científica');

INSERT INTO Cliente 
VALUES
('Gilberto Luis Guedes da Silva', 'Itatiaia', '(11) 1111-1111', 'gilberto.luis@aedb.br'),
('João Marcos Valente', 'Barra Mansa', '(22) 2222-2222', 'joao.marcos@aedb.br'),
('João Evangelista Beijo Neto', 'Itatiaia', '(33) 3333-3333', 'joao.evangelista@aedb.br')