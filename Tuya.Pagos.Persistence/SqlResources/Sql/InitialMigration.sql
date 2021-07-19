CREATE DATABASE PAGOS
GO
USE PAGOS
GO
IF NOT EXISTS (SELECT NAME FROM SYS.tables WHERE NAME = 'Customer')
BEGIN
CREATE TABLE Customer (
    IdClient int IDENTITY(1,1) NOT NULL PRIMARY KEY,
    Name varchar(50),
    LastName varchar(50),
    Phone varchar(15),
    Email varchar(80),
	Address varchar(100)
);
END
GO
IF NOT EXISTS (SELECT NAME FROM SYS.tables WHERE NAME = 'Product')
BEGIN
CREATE TABLE Product(
	IdProduct int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	Name varchar(150),
	Price int,
	Reference varchar(100)
)
END
GO
IF NOT EXISTS (SELECT NAME FROM SYS.tables WHERE NAME = 'Invoice')
BEGIN
CREATE TABLE Invoice(
	IdInvoice int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	IdCliente int NOT NULL  FOREIGN KEY REFERENCES Customer(IdClient)
)
END
GO
IF NOT EXISTS (SELECT NAME FROM SYS.tables WHERE NAME = 'InvoiceProduct')
BEGIN
CREATE TABLE InvoiceProduct(
	IdInvoiceProduct int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	IdInvoice int NOT NULL FOREIGN KEY REFERENCES Invoice(IdInvoice),
	IdProduct int NOT NULL FOREIGN KEY REFERENCES Product(IdProduct)
)
END
GO 
IF NOT EXISTS (SELECT NAME FROM SYS.tables WHERE NAME = 'Stock')
BEGIN
CREATE TABLE Stock(
	idStock int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	IdProduct int NOT NULL  FOREIGN KEY REFERENCES Product(IdProduct),
	State varchar(3),
	IdInvoice int FOREIGN KEY REFERENCES Invoice(IdInvoice)
)
END
GO
IF NOT EXISTS (SELECT NAME FROM SYS.tables WHERE NAME = 'Sending')
BEGIN
CREATE TABLE Sending(
	IdSending int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	IdInvoice int NOT NULL  FOREIGN KEY REFERENCES Invoice(IdInvoice),
	State varchar(3)
)
END
GO
INSERT INTO Customer (Name, LastName, Address,Email,Phone) VALUES
('TEST', 'TEST', 'CR 11A #16-56', 'test@test.com', '3211234567')
GO
INSERT INTO Product (NAME, Price, Reference) VALUES 
('Camisa', 20, '2DFASDF'),
('Pantalon', 30, 'bxb45345'),
('Correa', 15, '2DFASDF'),
('Tenis', 90, 'uiou567'),
('Botas', 120, '34534hgf'),
('Chaqueta', 100, '78876'),
('Falda', 50, '345hfh')
GO
INSERT INTO Stock (IdProduct, State) VALUES
(1,'1'),
(1,'1'),
(1,'1'),
(1,'1'),
(1,'1'),
(2,'1'),
(2,'1'),
(2,'1'),
(2,'1'),
(2,'1'),
(3,'1'),
(3,'1'),
(3,'1'),
(3,'1'),
(3,'1'),
(4,'1'),
(4,'1'),
(4,'1'),
(4,'1'),
(4,'1'),
(5,'1'),
(6,'1'),
(7,'1'),
(7,'1'),
(7,'1'),
(7,'1'),
(7,'1'),
(7,'1'),
(7,'1')
