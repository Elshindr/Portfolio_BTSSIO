CREATE TABLE pos_account_book
(
	id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	codeBoutique VARCHAR(3) NOT NULL,
	date DATE NOT NULL,
	piece VARCHAR(50) ,
	numCompte VARCHAR(25),
	libelle VARCHAR(50),
	debit FLOAT NOT NULL,
	credit FLOAT NOT NULL
)
INSERT INTO pos_account_book (date, piece, numCompte, libelle, credit, debit) VALUES (STR_TO_DATE("01/12/2021", "%m/%d/%Y", 0801056169,53100000,'Vte comptoir 01/12/2021',50.0, 0.00 ); 
DELETE FROM pos_account_book


SELECT * FROM pos_account_book 
WHERE codeBoutique = ? AND date = ?

SELECT  * FROM [A$]
WHERE codeBoutique = ? AND date = ?


CREATE TABLE pos_accountbook_importX3
(
	id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	codeBoutique VARCHAR(3) NOT NULL FOREIGN KEY REFERENCES pos_account_book(codeBoutique),
	date DATE NOT NULL FOREIGN KEY REFERENCES pos_account_book(date),
	typeLigne VARCHAR(1),
	totalOperation INT,
	numCompte VARCHAR(25)
	numOperation VARCHAR(25),
	libelle VARCHAR(50),
	sensOp INT,
	sumCredit FLOAT,
	sumDebit FLOAT,
	montant FLOAT,
)

