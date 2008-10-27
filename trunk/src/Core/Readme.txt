"CREATE TABLE Customers (" +
"CustomerID INTEGER PRIMARY KEY AUTOINCREMENT, " +
"TitleOfCourtesy VARCHAR(10) NULL, " +
"Name VARCHAR(100) NOT NULL, " +
"Address VARCHAR(100) NULL, " +
"Postcode VARCHAR(10) NULL, " +
"State VARCHAR(100) NULL, " +
"Phone VARCHAR(100) NULL, " +
"CompanyName VARCHAR(100) NULL)";

"CREATE TABLE Products (" +
"ProductID INTEGER PRIMARY KEY AUTOINCREMENT, " +
"Name VARCHAR(100) NOT NULL, " +
"Description VARCHAR(100) NULL, " +
"Type VARCHAR(100) NULL, " +
"Specification VARCHAR(100) NULL, " +
"InStock INTEGER DEFAULT 0 NOT NULL, " +
"Price NUMERIC DEFAULT 0 NOT NULL)";

"CREATE TABLE Orders (" +
"OrderID INTEGER PRIMARY KEY AUTOINCREMENT, " +
"Year VARCHAR(4) NOT NULL, " +
"OrderDate VARCHAR(100) NOT NULL, " +
"OrderTime VARCHAR(100) NOT NULL, " +
"CustomerID INTEGER NOT NULL, " +
"TitleOfCourtesy VARCHAR(10) NOT NULL, " +
"Name VARCHAR(100) NOT NULL, " +
"Address VARCHAR(100) NULL, " +
"Postcode VARCHAR(10) NULL, " +
"State VARCHAR(100) NULL, " +
"Phone VARCHAR(100) NULL, " +
"CompanyName VARCHAR(100) NULL, " +
"SalePerson VARCHAR(100) NULL, " +
"Sum NUMERIC DEFAULT 0 NOT NULL, " +
"DiscountRM NUMERIC DEFAULT 0 NOT NULL, " +
"Total NUMERIC DEFAULT 0 NOT NULL)";

"CREATE TABLE OrderDetails (" +
"OrderID INTEGER NOT NULL, " +
"ProductID INTEGER NOT NULL, " +
"Name VARCHAR(100) NOT NULL, " +
"Description VARCHAR(100) NULL, " +
"Type VARCHAR(100) NULL, " +
"InStock INTEGER DEFAULT 0 NOT NULL, " +
"Price NUMERIC DEFAULT 0 NOT NULL, " +
"Quantity INTEGER DEFAULT 0 NOT NULL, " +
"DiscountPercent NUMERIC DEFAULT 0 NOT NULL, " +
"TotalCost NUMERIC DEFAULT 0 NOT NULL)";

Take note that Specification of the product is not include in the order details, that is what you want.

Mr. Mrs. Mdm. Ms. Miss Dr.

"OrderDate DATE NOT NULL, " +
"OrderTime TIME NOT NULL, " +
