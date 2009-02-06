"CREATE TABLE Customers (" +
"CustomerId INTEGER PRIMARY KEY AUTOINCREMENT, " +
"TitleOfCourtesy VARCHAR(10) NULL, " +
"Name VARCHAR(100) NOT NULL, " +
"Address VARCHAR(100) NULL, " +
"Postcode VARCHAR(10) NULL, " +
"State VARCHAR(100) NULL, " +
"Phone VARCHAR(100) NULL, " +
"CompanyName VARCHAR(100) NULL)";

"CREATE TABLE Products (" +
"ProductId INTEGER PRIMARY KEY AUTOINCREMENT, " +
"Name VARCHAR(100) NOT NULL, " +
"Description VARCHAR(100) NULL, " +
"Type VARCHAR(100) NULL, " +
"Specification VARCHAR(100) NULL, " +
"InStock INTEGER DEFAULT 0 NOT NULL, " +
"Price NUMERIC DEFAULT 0 NOT NULL)";

"CREATE TABLE Orders (" +
"OrderId INTEGER PRIMARY KEY AUTOINCREMENT, " +
"Year VARCHAR(4) NOT NULL, " +
"OrderDate VARCHAR(100) NOT NULL, " +
"OrderTime VARCHAR(100) NOT NULL, " +
"CustomerId INTEGER NOT NULL, " +
"TitleOfCourtesy VARCHAR(10) NOT NULL, " +
"Name VARCHAR(100) NOT NULL, " +
"Address VARCHAR(100) NULL, " +
"Postcode VARCHAR(10) NULL, " +
"State VARCHAR(100) NULL, " +
"Phone VARCHAR(100) NULL, " +
"CompanyName VARCHAR(100) NULL, " +
"SalePerson VARCHAR(100) NULL, " +
"Total NUMERIC DEFAULT 0 NOT NULL, " +
"Rebate NUMERIC DEFAULT 0 NOT NULL, " +
"GrandTotal NUMERIC DEFAULT 0 NOT NULL)";

"CREATE TABLE OrderDetails (" +
"OrderDetailId INTEGER PRIMARY KEY AUTOINCREMENT, " +
"OrderId INTEGER NOT NULL, " +
"ProductId INTEGER NOT NULL, " +
"Name VARCHAR(100) NOT NULL, " +
"Description VARCHAR(100) NULL, " +
"Type VARCHAR(100) NULL, " +
"InStock INTEGER DEFAULT 0 NOT NULL, " +
"Price NUMERIC DEFAULT 0 NOT NULL, " +
"Quantity INTEGER DEFAULT 0 NOT NULL, " +
"Cost NUMERIC DEFAULT 0 NOT NULL, " +
"Discount NUMERIC DEFAULT 0 NOT NULL, " +
"TotalCost NUMERIC DEFAULT 0 NOT NULL)";

"CREATE TABLE Versions (" +
"VersionId INTEGER PRIMARY KEY AUTOINCREMENT, " +
"Version REAL NOT NULL)";

"CREATE TABLE StrongKeys (" +
"StrongKeyId INTEGER PRIMARY KEY AUTOINCREMENT, " +
"Name VARCHAR(100) NOT NULL, " +
"StrongKey VARCHAR(100) NOT NULL)";

Take note that Specification of the product is not include in the order details, that is what you want.

Mr. Mrs. Mdm. Ms. Miss Dr.

"OrderDate DATE NOT NULL, " +
"OrderTime TIME NOT NULL, " +

Requirement
- Visual Studio 2008 Express
- TortoiseSVN 
- System.Data.SQLite (http://sqlite.phxsoftware.com/)