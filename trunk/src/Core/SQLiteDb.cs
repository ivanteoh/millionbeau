using System;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SQLite;
using System.Globalization;
using System.ComponentModel;

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
                            cmd.CommandText = "SELECT * FROM Customers";

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
                        DbParameter titleDb = cmd.CreateParameter();
                        titleDb.ParameterName = "@title";
                        titleDb.Value = title;
                        cmd.Parameters.Add(titleDb);

                        DbParameter nameDb = cmd.CreateParameter();
                        nameDb.ParameterName = "@name";
                        nameDb.Value = name;
                        cmd.Parameters.Add(nameDb);

                        DbParameter addressDb = cmd.CreateParameter();
                        addressDb.ParameterName = "@address";
                        addressDb.Value = address;
                        cmd.Parameters.Add(addressDb);

                        DbParameter postcodeDb = cmd.CreateParameter();
                        postcodeDb.ParameterName = "@postcode";
                        postcodeDb.Value = postcode;
                        cmd.Parameters.Add(postcodeDb);

                        DbParameter stateDb = cmd.CreateParameter();
                        stateDb.ParameterName = "@state";
                        stateDb.Value = state;
                        cmd.Parameters.Add(stateDb);

                        DbParameter phoneDb = cmd.CreateParameter();
                        phoneDb.ParameterName = "@phone";
                        phoneDb.Value = phone;
                        cmd.Parameters.Add(phoneDb);

                        DbParameter companyDb = cmd.CreateParameter();
                        companyDb.ParameterName = "@company";
                        companyDb.Value = company;
                        cmd.Parameters.Add(companyDb);

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

        public object Customer(string index)
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
                        string customerQuery = 
                            string.Format(CultureInfo.InvariantCulture, "SELECT * FROM Customers WHERE CustomerID = '{0}'", index);
                        cmd.CommandText = customerQuery;  

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
                Console.WriteLine("FAIL - Get Customer: {0}", ex.Message);
            }

            return dataSet.Tables[0];
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
                            cmd.CommandText = "SELECT * FROM Products";

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
                        DbParameter nameDb = cmd.CreateParameter();
                        nameDb.ParameterName = "@name";
                        nameDb.Value = name;
                        cmd.Parameters.Add(nameDb);

                        DbParameter descriptionDb = cmd.CreateParameter();
                        descriptionDb.ParameterName = "@description";
                        descriptionDb.Value = description;
                        cmd.Parameters.Add(descriptionDb);

                        DbParameter typeDb = cmd.CreateParameter();
                        typeDb.ParameterName = "@type";
                        typeDb.Value = type;
                        cmd.Parameters.Add(typeDb);

                        DbParameter specificationDb = cmd.CreateParameter();
                        specificationDb.ParameterName = "@specification";
                        specificationDb.Value = specification;
                        cmd.Parameters.Add(specificationDb);

                        DbParameter inStockDb = cmd.CreateParameter();
                        inStockDb.ParameterName = "@inStock";
                        inStockDb.Value = inStock;
                        cmd.Parameters.Add(inStockDb);

                        DbParameter priceDb = cmd.CreateParameter();
                        priceDb.ParameterName = "@price";
                        priceDb.Value = price;
                        cmd.Parameters.Add(priceDb);

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

        #region Orders Table
        private static void CreateOrdersTable(DbConnection cnn)
        {
            using (DbCommand cmd = cnn.CreateCommand())
            {
                cmd.CommandText =
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
                cmd.ExecuteNonQuery();
            }
        }

        public object OrdersTable
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
                            cmd.CommandText = "SELECT * FROM Orders";

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
                    Console.WriteLine("FAIL - Orders Table: {0}", ex.Message);
                }

                return dataSet.Tables[0];
            }
        }

        public void InsertOrder(
            string customerId,
            string salePerson,
            string sum,
            string discountRM,
            string total)
        {
            DateTime dataTimeNow = DateTime.Now;

            try
            {
                DataTable customerTable = Customer(customerId) as DataTable;
                if (customerTable == null && customerTable.Rows.Count != 1)
                    return;

                DataRow currentCustomer = customerTable.Rows[0];
                object[] customerInfo = currentCustomer.ItemArray;

                if (customerInfo.Length != 8)
                    return;

                string title = customerInfo[1].ToString();
                string name = customerInfo[2].ToString();
                string address = customerInfo[3].ToString();
                string postcode = customerInfo[4].ToString();
                string state = customerInfo[5].ToString();
                string phone = customerInfo[6].ToString();
                string company = customerInfo[7].ToString();
                                
                using (DbConnection cnn = fact.CreateConnection())
                {
                    cnn.ConnectionString = dbConnectionStr;
                    cnn.Open();
                    using (DbCommand cmd = cnn.CreateCommand())
                    {
                        cmd.CommandText =
                            "INSERT INTO Orders " +
                            "(Year, OrderDate, OrderTime, " + 
                            "CustomerID, TitleOfCourtesy, Name, Address, Postcode, State, Phone, CompanyName, " +
                            "SalePerson, Sum, DiscountRM, Total) " +
                            "Values (@year, @orderDate, @orderTime, " + 
                            "@customerId, @title, @name, @address, @postcode, @state, @phone, @company, " +
                            "@salePerson, @sum, @discountRM, @total)";

                        DbParameter yearDb = cmd.CreateParameter();
                        yearDb.ParameterName = "@year";
                        yearDb.Value = dataTimeNow.Year;
                        cmd.Parameters.Add(yearDb);

                        DbParameter orderDateDb = cmd.CreateParameter();
                        orderDateDb.ParameterName = "@orderDate";
                        orderDateDb.Value = dataTimeNow.ToShortDateString();
                        cmd.Parameters.Add(orderDateDb);

                        DbParameter orderTimeDb = cmd.CreateParameter();
                        orderTimeDb.ParameterName = "@orderTime";
                        orderTimeDb.Value = dataTimeNow.ToShortTimeString();
                        cmd.Parameters.Add(orderTimeDb);

                        DbParameter customerIdDb = cmd.CreateParameter();
                        customerIdDb.ParameterName = "@customerId";
                        customerIdDb.Value = customerId;
                        cmd.Parameters.Add(customerIdDb);

                        DbParameter titleDb = cmd.CreateParameter();
                        titleDb.ParameterName = "@title";
                        titleDb.Value = title;
                        cmd.Parameters.Add(titleDb);

                        DbParameter nameDb = cmd.CreateParameter();
                        nameDb.ParameterName = "@name";
                        nameDb.Value = name;
                        cmd.Parameters.Add(nameDb);

                        DbParameter addressDb = cmd.CreateParameter();
                        addressDb.ParameterName = "@address";
                        addressDb.Value = address;
                        cmd.Parameters.Add(addressDb);

                        DbParameter postcodeDb = cmd.CreateParameter();
                        postcodeDb.ParameterName = "@postcode";
                        postcodeDb.Value = postcode;
                        cmd.Parameters.Add(postcodeDb);

                        DbParameter stateDb = cmd.CreateParameter();
                        stateDb.ParameterName = "@state";
                        stateDb.Value = state;
                        cmd.Parameters.Add(stateDb);

                        DbParameter phoneDb = cmd.CreateParameter();
                        phoneDb.ParameterName = "@phone";
                        phoneDb.Value = phone;
                        cmd.Parameters.Add(phoneDb);

                        DbParameter companyDb = cmd.CreateParameter();
                        companyDb.ParameterName = "@company";
                        companyDb.Value = company;
                        cmd.Parameters.Add(companyDb);

                        DbParameter salePersonDb = cmd.CreateParameter();
                        salePersonDb.ParameterName = "@salePerson";
                        salePersonDb.Value = salePerson;
                        cmd.Parameters.Add(salePersonDb);

                        DbParameter sumDb = cmd.CreateParameter();
                        sumDb.ParameterName = "@sum";
                        sumDb.Value = sum;
                        cmd.Parameters.Add(sumDb);

                        DbParameter discountRMDb = cmd.CreateParameter();
                        discountRMDb.ParameterName = "@discountRM";
                        discountRMDb.Value = discountRM;
                        cmd.Parameters.Add(discountRMDb);

                        DbParameter totalDb = cmd.CreateParameter();
                        totalDb.ParameterName = "@total";
                        totalDb.Value = total;
                        cmd.Parameters.Add(totalDb);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (DbException ex)
            {
                Console.WriteLine("FAIL - Insert Order: {0}", ex.Message);
            }
        }

        public object[] LastOrder()
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
                        cmd.CommandText = "SELECT * FROM Orders WHERE OrderID = (select max(OrderID) from Orders)";

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
                Console.WriteLine("FAIL - Get Last Order: {0}", ex.Message);
            }

            DataTable currentTable = dataSet.Tables[0];

            if (currentTable == null && currentTable.Rows.Count != 1)
                return null;

            DataRow currentOrder = currentTable.Rows[0];
            object[] orderItems = currentOrder.ItemArray;

            if (orderItems.Length != 16)
                return null;

            return orderItems;            
        }
        #endregion Orders Table

        #region Order Details
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

        public BindingList<OrderDetail> OrderDetail(string orderId)
        {
            BindingList<OrderDetail> orderDetails = new BindingList<OrderDetail>();
            DataSet dataSet = new DataSet();
            dataSet.Locale = CultureInfo.InvariantCulture;
            OrderDetail orderDetail;

            try
            {
                using (DbConnection cnn = fact.CreateConnection())
                {
                    cnn.ConnectionString = dbConnectionStr;
                    cnn.Open();
                    using (DbCommand cmd = cnn.CreateCommand())
                    {
                        string selectQuery = string.Format(CultureInfo.InvariantCulture, "SELECT * FROM OrderDetails WHERE OrderID = '{0}'", orderId);
                        cmd.CommandText = selectQuery;

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
                Console.WriteLine("FAIL - Get Order Detail: {0}", ex.Message);
            }

            DataTable currentTable = dataSet.Tables[0];

            if (currentTable == null)
                return null;

            foreach (DataRow row in currentTable.Rows)
            {
                if (row[0].ToString() == orderId)
                {
                    orderDetail = new OrderDetail();
                    orderDetail.ProductId = Convert.ToInt64(row[1], CultureInfo.InvariantCulture);
                    orderDetail.Product = row[2].ToString();
                    orderDetail.Description = row[3].ToString();
                    orderDetail.ProductType = row[4].ToString();
                    orderDetail.InStock = Convert.ToInt64(row[5], CultureInfo.InvariantCulture);
                    orderDetail.Price = Convert.ToDecimal(row[6], CultureInfo.InvariantCulture);
                    orderDetail.Quantity = Convert.ToInt64(row[7], CultureInfo.InvariantCulture);
                    orderDetail.DiscountPercent = Convert.ToDecimal(row[8], CultureInfo.InvariantCulture);
                    orderDetail.TotalCost = Convert.ToDecimal(row[9], CultureInfo.InvariantCulture);

                    orderDetails.Add(orderDetail);
                }                
            }

            return orderDetails;
        }

        public void InsertOrderDetail(
            string orderId,
            BindingList<OrderDetail> orderDetails)
        {
            DbParameter orderIdDb;
            DbParameter productIdDb;
            DbParameter nameDb;
            DbParameter descriptionDb;
            DbParameter typeDb;
            DbParameter inStockDb;
            DbParameter priceDb;
            DbParameter quantityDb;
            DbParameter discountPercentDb;
            DbParameter totalCostDb;

            try
            {
                using (DbConnection cnn = fact.CreateConnection())
                {
                    cnn.ConnectionString = dbConnectionStr;
                    cnn.Open();
                    using (DbCommand cmd = cnn.CreateCommand())
                    {
                        foreach (OrderDetail orderDetail in orderDetails)
                        {
                            cmd.CommandText =
                            "INSERT INTO OrderDetails " +
                            "(OrderID, ProductID, Name, Description, Type, InStock, Price, Quantity, DiscountPercent, TotalCost) " +
                            "Values (@orderId, @productId, @name, @description, @type, @inStock, @price, @quantity, @discountPercent, @totalCost)";
                            orderIdDb = cmd.CreateParameter();
                            orderIdDb.ParameterName = "@orderId";
                            orderIdDb.Value = orderId;
                            cmd.Parameters.Add(orderIdDb);

                            productIdDb = cmd.CreateParameter();
                            productIdDb.ParameterName = "@productId";
                            productIdDb.Value = orderDetail.ProductId;
                            cmd.Parameters.Add(productIdDb);

                            nameDb = cmd.CreateParameter();
                            nameDb.ParameterName = "@name";
                            nameDb.Value = orderDetail.Product;
                            cmd.Parameters.Add(nameDb);

                            descriptionDb = cmd.CreateParameter();
                            descriptionDb.ParameterName = "@description";
                            descriptionDb.Value = orderDetail.Description;
                            cmd.Parameters.Add(descriptionDb);

                            typeDb = cmd.CreateParameter();
                            typeDb.ParameterName = "@type";
                            typeDb.Value = orderDetail.ProductType;
                            cmd.Parameters.Add(typeDb);

                            inStockDb = cmd.CreateParameter();
                            inStockDb.ParameterName = "@inStock";
                            inStockDb.Value = orderDetail.InStock;
                            cmd.Parameters.Add(inStockDb);

                            priceDb = cmd.CreateParameter();
                            priceDb.ParameterName = "@price";
                            priceDb.Value = orderDetail.Price;
                            cmd.Parameters.Add(priceDb);

                            quantityDb = cmd.CreateParameter();
                            quantityDb.ParameterName = "@quantity";
                            quantityDb.Value = orderDetail.Quantity;
                            cmd.Parameters.Add(quantityDb);

                            discountPercentDb = cmd.CreateParameter();
                            discountPercentDb.ParameterName = "@discountPercent";
                            discountPercentDb.Value = orderDetail.DiscountPercent;
                            cmd.Parameters.Add(discountPercentDb);

                            totalCostDb = cmd.CreateParameter();
                            totalCostDb.ParameterName = "@totalCost";
                            totalCostDb.Value = orderDetail.TotalCost;
                            cmd.Parameters.Add(totalCostDb);

                            cmd.ExecuteNonQuery(); 
                        }
                    }
                }
            }
            catch (DbException ex)
            {
                Console.WriteLine("FAIL - Insert Order Detail: {0}", ex.Message);
            }

            // Update the product in stock quantity
            try
            {
                using (DbConnection cnn = fact.CreateConnection())
                {
                    cnn.ConnectionString = dbConnectionStr;
                    cnn.Open();
                    using (DbCommand cmd = cnn.CreateCommand())
                    {
                        foreach (OrderDetail orderDetail in orderDetails)
                        {
                            string updateQuery = string.Format(
                                CultureInfo.InvariantCulture,
                                "UPDATE Products SET " +
                                "InStock = '{0}' " +
                                "WHERE ProductID = '{1}'", 
                                orderDetail.InStock, orderDetail.ProductId);
                            cmd.CommandText = updateQuery;
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
            }
            catch (DbException ex)
            {
                Console.WriteLine("FAIL - Update Product In Stock: {0}", ex.Message);
            }
        }
        #endregion Order Details

        #endregion methods
    }
}
