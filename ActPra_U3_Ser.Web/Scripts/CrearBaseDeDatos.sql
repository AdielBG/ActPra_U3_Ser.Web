IF DB_ID('ApiBibliotecaDb') IS NULL
BEGIN
    CREATE DATABASE ApiBibliotecaDb;
END
GO

USE ApiBibliotecaDb;
GO

IF OBJECT_ID('Libros', 'U') IS NOT NULL
    DROP TABLE Libros;
GO

CREATE TABLE Libros
(
    Id               INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    Titulo           NVARCHAR(200)     NOT NULL,
    Autor            NVARCHAR(100)     NOT NULL,
    AnioPublicacion  INT               NOT NULL,
    Genero           NVARCHAR(50)      NOT NULL,
    NumeroPaginas    INT               NOT NULL,
    Precio           DECIMAL(18,2)     NOT NULL,
    Disponible       BIT               NOT NULL
);
GO

INSERT INTO Libros (Titulo, Autor, AnioPublicacion, Genero, NumeroPaginas, Precio, Disponible)
VALUES
('Cien años de soledad',              'Gabriel García Márquez', 1967, 'Novela',   432, 850.00, 1),
('El amor en los tiempos del cólera', 'Gabriel García Márquez', 1985, 'Romance',  368, 720.00, 1),
('La casa de los espíritus',          'Isabel Allende',         1982, 'Novela',   433, 780.00, 1),
('La ciudad y los perros',            'Mario Vargas Llosa',     1963, 'Novela',   349, 650.00, 0),
('Don Quijote de la Mancha',          'Miguel de Cervantes',    1605, 'Clásico',  863, 950.00, 1);
GO

SELECT * FROM Libros;
GO