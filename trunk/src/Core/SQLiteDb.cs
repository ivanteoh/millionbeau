using System;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SQLite;
using System.Globalization;

namespace MillionBeauty
{
    public sealed class SQLiteDB
    {
        #region Construction  / Destruction
        /// <summary>
        /// Constructors of creating table for sqlite3 database.
        /// </summary>
        /// <remarks>
        /// Protected constructor is sufficient to avoid other instantiation
        /// This must be present otherwise the compiler provides
        /// a default public constructor
        /// </remarks>
        private SQLiteDB()
        {
            fact = DbProviderFactories.GetFactory("System.Data.SQLite");
        }
        #endregion Construction  / Destruction

        #region fields        
        // Static members are lazily initialized.
        // .NET guarantees thread safety for static initialization
        private static readonly SQLiteDB instance = new SQLiteDB();

        string dbConnectionStr = "";
        DbProviderFactory fact;
        #endregion fields

        #region methods
        /// Return an instance of <see cref="SQLiteDb"/>
        public static SQLiteDB Instance
        {
            get
            {
                return instance;
            }
        }        

        public string ConnectionString 
        {
            get
            {
                return dbConnectionStr;
            }
            set
            {
                dbConnectionStr = value;
            }
        }

        /// <type>Method</type>
        /// <summary>
        /// Creates the connection.
        /// </summary>
        /// <param name="file">The file.</param>
        public bool CreateConnection()
        {
            bool isSuccess = true;

            try
            {
                using (DbConnection cnn = fact.CreateConnection())
                {
                    cnn.ConnectionString = dbConnectionStr;
                    cnn.Open();
                }
            }
            catch (DbException ex)
            {
                Console.WriteLine(ex.Message);
                isSuccess = false;
            }
            return isSuccess;
        }

        /// <summary>
        /// Main function to call all creating table functions.
        /// </summary>
        /// <param name="fact">Sqlite database provider factory.</param>
        /// <param name="cnn">Sqlite connection object that associate with the command.</param>
        public void CreateDatabase()
        {
            try
            {
                using (DbConnection cnn = fact.CreateConnection())
                {
                    cnn.ConnectionString = dbConnectionStr;
                    cnn.Open();
                    CreateCustomersTable(cnn);
                    CreateProductsTable(cnn);
                    CreateOrdersTable(cnn);
                    CreateOrderDetailsTable(cnn);
                }
            }
            catch (DbException ex)
            {
                Console.WriteLine("FAIL - Create Table for String: {0}", ex.Message);
            }
        }
        
        private static void CreateOrdersTable(DbConnection cnn)
        {
            using (DbCommand cmd = cnn.CreateCommand())
            {
                cmd.CommandText =
                    "CREATE TABLE Orders (" +
                    "OrderID INTEGER PRIMARY KEY AUTOINCREMENT, " +
                    "CustomerID INTEGER NOT NULL, " +
                    "TitleOfCourtesy VARCHAR(10) NOT NULL, " +
                    "Name VARCHAR(100) NOT NULL, " +
                    "Address VARCHAR(100) NULL, " +
                    "Postcode VARCHAR(10) NULL, " +
                    "State VARCHAR(100) NULL, " +
                    "Phone VARCHAR(100) NULL, " +
                    "CompanyName VARCHAR(100) NULL, " +
                    "Year VARCHAR(4) NOT NULL, " +
                    "OrderDate DATE NOT NULL, " +
                    "OrderTime TIME NOT NULL, " +
                    "SalePerson VARCHAR(100) NULL, " +
                    "Sum NUMERIC DEFAULT 0 NOT NULL, " +
                    "DiscountRM NUMERIC DEFAULT 0 NOT NULL, " +
                    "Total NUMERIC DEFAULT 0 NOT NULL)";
                cmd.ExecuteNonQuery();
            }
        }

        private static void CreateOrderDetailsTable(DbConnection cnn)
        {
            using (DbCommand cmd = cnn.CreateCommand())
            {
                cmd.CommandText =
                    "CREATE TABLE OrderDetails (" +
                    "OrderID INTEGER NOT NULL, " +
                    "ProductID INTEGER NOT NULL, " +
                    "Name VARCHAR(100) NOT NULL, " +
                    "Description VARCHAR(100) NULL, " +
                    "Type VARCHAR(100) NULL, " +
                    "InStock INTEGER DEFAULT 1 NOT NULL, " +
                    "Price NUMERIC DEFAULT 0 NOT NULL, " +
                    "Quantity INTEGER DEFAULT 1 NOT NULL, " +
                    "DiscountPercent NUMERIC DEFAULT 0 NOT NULL, " +
                    "TotalCost NUMERIC DEFAULT 0 NOT NULL)";
                cmd.ExecuteNonQuery();
            }
        }

        #region Customers Table
        /// <summary>
        /// Create table for ID and string data.
        /// </summary>
        /// <param name="cnn">Sqlite connection object that associate with the command.</param>
        private static void CreateCustomersTable(DbConnection cnn)
        {
            using (DbCommand cmd = cnn.CreateCommand())
            {
                cmd.CommandText =
                    "CREATE TABLE Customers (" +
                    "CustomerID INTEGER PRIMARY KEY AUTOINCREMENT, " +
                    "TitleOfCourtesy VARCHAR(10) NOT NULL, " +
                    "Name VARCHAR(100) NOT NULL, " +
                    "Address VARCHAR(100) NULL, " +
                    "Postcode VARCHAR(10) NULL, " +
                    "State VARCHAR(100) NULL, " +
                    "Phone VARCHAR(100) NULL, " +
                    "CompanyName VARCHAR(100) NULL)";
                cmd.ExecuteNonQuery();
            }
        }

        public object CustomersTable 
        {
            get
            {
                DataSet dataSet = new DataSet();
                dataSet.Locale = CultureInfo.InvariantCulture;

                try
                {
                    using (DbConnection cnn = fact.CreateConnection())
                    {
                        cnn.ConnectionString = dbConnectionStr;
                        cnn.Open();
                        using (DbCommand cmd = cnn.CreateCommand())
                        {
                            cmd.CommandText = "SELECT * from Customers";

                            using (DbDataAdapter dataAdapter = fact.CreateDataAdapter())
                            {
                                dataAdapter.SelectCommand = cmd;
                                dataAdapter.FillSchema(dataSet, SchemaType.Mapped);
                                dataAdapter.Fill(dataSet);
                            }
                        }
                    }
                }
                catch (DbException ex)
                {
                    Console.WriteLine("FAIL - Customers Table: {0}", ex.Message);
                }

                return dataSet.Tables[0];
            }
        }

        public void InsertCustomer(
            string title, 
            string name,
            string address,
            string postcode,
            string state,
            string phone,
            string company)
        {
            try
            {
                using (DbConnection cnn = fact.CreateConnection())
                {
                    cnn.ConnectionString = dbConnectionStr;
                    cnn.Open();
                    using (DbCommand cmd = cnn.CreateCommand())
                    {
                        cmd.CommandText =
                            "INSERT INTO Customers " +
                            "(TitleOfCourtesy, Name, Address, Postcode, State, Phone, CompanyName) " +
                            "Values (@title, @name, @address, @postcode, @state, @phone, @company)";
                        DbParameter titleDB = cmd.CreateParameter();
                        titleDB.ParameterName = "@title";
                        titleDB.Value = title;
                        cmd.Parameters.Add(titleDB);

                        DbParameter nameDB = cmd.CreateParameter();
                        nameDB.ParameterName = "@name";
                        nameDB.Value = name;
                        cmd.Parameters.Add(nameDB);

                        DbParameter addressDB = cmd.CreateParameter();
                        addressDB.ParameterName = "@address";
                        addressDB.Value = address;
                        cmd.Parameters.Add(addressDB);

                        DbParameter postcodeDB = cmd.CreateParameter();
                        postcodeDB.ParameterName = "@postcode";
                        postcodeDB.Value = postcode;
                        cmd.Parameters.Add(postcodeDB);

                        DbParameter stateDB = cmd.CreateParameter();
                        stateDB.ParameterName = "@state";
                        stateDB.Value = state;
                        cmd.Parameters.Add(stateDB);

                        DbParameter phoneDB = cmd.CreateParameter();
                        phoneDB.ParameterName = "@phone";
                        phoneDB.Value = phone;
                        cmd.Parameters.Add(phoneDB);

                        DbParameter companyDB = cmd.CreateParameter();
                        companyDB.ParameterName = "@company";
                        companyDB.Value = company;
                        cmd.Parameters.Add(companyDB);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (DbException ex)
            {
                Console.WriteLine("FAIL - Insert Customer: {0}", ex.Message);
            }
        }

        public void UpdateCustomer(
            string id,
            string title,
            string name,
            string address,
            string postcode,
            string state,
            string phone,
            string company)
        {
            try
            {
                using (DbConnection cnn = fact.CreateConnection())
                {
                    cnn.ConnectionString = dbConnectionStr;
                    cnn.Open();
                    using (DbCommand cmd = cnn.CreateCommand())
                    {
                        string updateQuery = 
                            string.Format(CultureInfo.InvariantCulture,
                            "UPDATE Customers SET " +
                            "TitleOfCourtesy = '{0}', Name = '{1}', " +
                            "Address = '{2}', Postcode = '{3}', " +
                            "State = '{4}', Phone = '{5}', " +
                            "CompanyName = '{6}' " +
                            "WHERE CustomerID = '{7}'",
                            title, name, address, postcode,
                            state, phone, company, id);
                        cmd.CommandText = updateQuery;  
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (DbException ex)
            {
                Console.WriteLine("FAIL - Update Customer: {0}", ex.Message);
            }
        }

        public void DeleteCustomer(string index)
        {
            try
            {
                using (DbConnection cnn = fact.CreateConnection())
                {
                    cnn.ConnectionString = dbConnectionStr;
                    cnn.Open();
                    using (DbCommand cmd = cnn.CreateCommand())
                    {
                        string deleteQuery = string.Format(CultureInfo.InvariantCulture,
                            "DELETE FROM Customers WHERE CustomerID = '{0}'", index);
                        cmd.CommandText = deleteQuery;
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (DbException ex)
            {
                Console.WriteLine("FAIL - Delete Customer: {0}", ex.Message);
            }
        }
        #endregion Customers Table

        #region Products Table
        private static void CreateProductsTable(DbConnection cnn)
        {
            using (DbCommand cmd = cnn.CreateCommand())
            {
                cmd.CommandText =
                    "CREATE TABLE Products (" +
                    "ProductID INTEGER PRIMARY KEY AUTOINCREMENT, " +
                    "Name VARCHAR(100) NOT NULL, " +
                    "Description VARCHAR(100) NULL, " +
                    "Type VARCHAR(100) NULL, " +
                    "Specification VARCHAR(100) NULL, " +
                    "InStock INTEGER DEFAULT 0 NOT NULL, " +
                    "Price NUMERIC DEFAULT 0 NOT NULL)";
                cmd.ExecuteNonQuery();
            }
        }

        public object ProductsTable
        {
            get
            {
                DataSet dataSet = new DataSet();
                dataSet.Locale = CultureInfo.InvariantCulture;

                try
                {
                    using (DbConnection cnn = fact.CreateConnection())
                    {
                        cnn.ConnectionString = dbConnectionStr;
                        cnn.Open();
                        using (DbCommand cmd = cnn.CreateCommand())
                        {
                            cmd.CommandText = "SELECT * from Products";

                            using (DbDataAdapter dataAdapter = fact.CreateDataAdapter())
                            {
                                dataAdapter.SelectCommand = cmd;
                                dataAdapter.FillSchema(dataSet, SchemaType.Mapped);
                                dataAdapter.Fill(dataSet);
                            }
                        }
                    }
                }
                catch (DbException ex)
                {
                    Console.WriteLine("FAIL - Products Table: {0}", ex.Message);
                }

                return dataSet.Tables[0];
            }
        }

        public void InsertProduct(
            string name,
            string description,
            string type,
            string specification,
            string inStock,
            string price)
        {
            try
            {
                using (DbConnection cnn = fact.CreateConnection())
                {
                    cnn.ConnectionString = dbConnectionStr;
                    cnn.Open();
                    using (DbCommand cmd = cnn.CreateCommand())
                    {
                        cmd.CommandText =
                            "INSERT INTO Products " +
                            "(Name, Description, Type, Specification, InStock, Price) " +
                            "Values (@name, @description, @type, @specification, @inStock, @price)";
                        DbParameter nameDB = cmd.CreateParameter();
                        nameDB.ParameterName = "@name";
                        nameDB.Value = name;
                        cmd.Parameters.Add(nameDB);

                        DbParameter descriptionDB = cmd.CreateParameter();
                        descriptionDB.ParameterName = "@description";
                        descriptionDB.Value = description;
                        cmd.Parameters.Add(descriptionDB);

                        DbParameter typeDB = cmd.CreateParameter();
                        typeDB.ParameterName = "@type";
                        typeDB.Value = type;
                        cmd.Parameters.Add(typeDB);

                        DbParameter specificationDB = cmd.CreateParameter();
                        specificationDB.ParameterName = "@specification";
                        specificationDB.Value = specification;
                        cmd.Parameters.Add(specificationDB);

                        DbParameter inStockDB = cmd.CreateParameter();
                        inStockDB.ParameterName = "@inStock";
                        inStockDB.Value = inStock;
                        cmd.Parameters.Add(inStockDB);

                        DbParameter priceDB = cmd.CreateParameter();
                        priceDB.ParameterName = "@price";
                        priceDB.Value = price;
                        cmd.Parameters.Add(priceDB);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (DbException ex)
            {
                Console.WriteLine("FAIL - Insert Product: {0}", ex.Message);
            }
        }

        public void UpdateProduct(
            string id,
            string name,
            string description,
            string type,
            string specification,
            string inStock,
            string price)
        {
            try
            {
                using (DbConnection cnn = fact.CreateConnection())
                {
                    cnn.ConnectionString = dbConnectionStr;
                    cnn.Open();
                    using (DbCommand cmd = cnn.CreateCommand())
                    {
                        string updateQuery =
                            string.Format(CultureInfo.InvariantCulture,
                            "UPDATE Products SET " +
                            "Name = '{0}', Description = '{1}', " +
                            "Type = '{2}', Specification = '{3}', " +
                            "InStock = '{4}', Price = '{5}' " +
                            "WHERE ProductID = '{6}'",
                            name, description, type, specification,
                            inStock, price, id);
                        cmd.CommandText = updateQuery;
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (DbException ex)
            {
                Console.WriteLine("FAIL - Update Product: {0}", ex.Message);
            }
        }

        public void DeleteProduct(string index)
        {
            try
            {
                using (DbConnection cnn = fact.CreateConnection())
                {
                    cnn.ConnectionString = dbConnectionStr;
                    cnn.Open();
                    using (DbCommand cmd = cnn.CreateCommand())
                    {
                        string deleteQuery = string.Format(CultureInfo.InvariantCulture,
                            "DELETE FROM Products WHERE ProductID = '{0}'", index);
                        cmd.CommandText = deleteQuery;
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (DbException ex)
            {
                Console.WriteLine("FAIL - Delete Product: {0}", ex.Message);
            }
        }
        #endregion Products Table

        #endregion methods
    }
}
