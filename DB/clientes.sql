CREATE TABLE [dbo].[Table]
(
	[Id_Cliente] INT NOT NULL , 
    [Nome] VARCHAR(100) NOT NULL, 
    [Telefone] VARCHAR(50) NULL, 
    [Cpf] VARCHAR(50) NOT NULL, 
    CONSTRAINT [PK_Table] PRIMARY KEY ([Id_Cliente])
)
