using static System.Console;
using Packt.Shared;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

/*

static void AggregateProducts()

{

    using (var db = new Northwind())

    {

        WriteLine("{0,-25} {1,10}",

        arg0: "Product count:",

        arg1: db.Products.Count());

        WriteLine("{0,-25} {1,10:$#,##0.00}",

        arg0: "Highest product price:",

        arg1: db.Products.Max(p => p.UnitPrice));

        WriteLine("{0,-25} {1,10:N0}",

        arg0: "Sum of units in stock:",

        arg1: db.Products.Sum(p => p.UnitsInStock));

        WriteLine("{0,-25} {1,10:N0}",

        arg0: "Sum of units on order:",

        arg1: db.Products.Sum(p => p.UnitsOnOrder));

        WriteLine("{0,-25} {1,10:$#,##0.00}",

        arg0: "Average unit price:",

        arg1: db.Products.Average(p => p.UnitPrice));

        WriteLine("{0,-25} {1,10:$#,##0.00}",

        arg0: "Value of units in stock:",

        arg1: db.Products.AsEnumerable()

        .Sum(p => p.UnitPrice * p.UnitsInStock));

    }

}

*/

static void GroupJoinCategoriesAndProducts()

{

    using (var db = new Northwind())

    {

        // group all products by their category to return 8 matches

        var queryGroup = db.Categories.AsEnumerable().GroupJoin(

        inner: db.Products,

        outerKeySelector: category => category.CategoryID,

        innerKeySelector: product => product.CategoryID,

        resultSelector: (c, matchingProducts) => new {

            c.CategoryName,

            Products = matchingProducts.OrderBy(p => p.ProductName)

        });

        foreach (var item in queryGroup)

        {

            WriteLine("{0} has {1} products.",

            arg0: item.CategoryName,

            arg1: item.Products.Count());

            foreach (var product in item.Products)

            {

                WriteLine($" {product.ProductName}");

            }

        }

    }

}


static void JoinCategoriesAndProducts()

{

    using (var db = new Northwind())

    {

        // join every product to its category to return 77 matches

        var queryJoin = db.Categories.Join(

        inner: db.Products,

        outerKeySelector: category => category.CategoryID,

        innerKeySelector: product => product.CategoryID,

        resultSelector: (c, p) =>

        new { c.CategoryName, p.ProductName, p.ProductID });

        foreach (var item in queryJoin)

        {

            WriteLine("{0}: {1} is in {2}.",

            arg0: item.ProductID,

            arg1: item.ProductName,

            arg2: item.CategoryName);

        }

    }

}


static void FilterAndSort()

{

    using (var db = new Northwind())

    {
        var loggerFactory = db.GetService<ILoggerFactory>();

        loggerFactory.AddProvider(new ConsoleLoggerProvider());
        var query = db.Products//.AsEnumerable()

        .Where(product => product.Cost < 10M)

        // IQueryable<Product>

        .OrderByDescending(product => product.Stock).Select((product) => new
        {
            product.CategoryID,
            product.ProductID,
            product.ProductName,
            product.Cost
        });

        WriteLine("Products that cost less than $10:");

        foreach (var item in query)

        {

            WriteLine("{0}: {1} costs {2:$#,##0.00}",

            item.ProductID, item.ProductName, item.Cost);

        }

        WriteLine();

    }

}




static bool AddProduct(int categoryID, string productName, decimal? price)

{

    using (var db = new Northwind())

    {

        var newProduct = new Product

        {

            CategoryID = categoryID,

            ProductName = productName,

            Cost = price

        };

        // mark product as added in change tracking

        db.Products.Add(newProduct);

        // save tracked change to database

        int affected = db.SaveChanges();

        return (affected == 1);

    }

}


static bool IncreaseProductPrice(string name, decimal amount)

{

    using (var db = new Northwind())

    {

        // get first product whose name starts with name

        Product updateProduct = db.Products.First(

        p => p.ProductName.StartsWith(name));

        updateProduct.Cost += amount;

        int affected = db.SaveChanges();

        return (affected == 1);

    }

}




static void QueryingCategories()
{
    using (var db = new Northwind())
    {
        var loggerFactory = db.GetService<ILoggerFactory>();

        loggerFactory.AddProvider(new ConsoleLoggerProvider());

        WriteLine("Categories and how many products they have:");

        // a query to get all categories and their related products

        IQueryable<Category> cats = db.Categories;//.Include(c => c.Products);

        foreach (Category c in cats)
        {
            WriteLine("--------------------------");
            WriteLine($"{c.CategoryName} has {c.Products.Count} products.");
            foreach (Product p in c.Products)
            {
                WriteLine($"{p.ProductName} cost {p.Cost} and has {p.Stock} item in stock.");
            }

        }
    }

}


static void QueryingProducts()

{

    using (var db = new Northwind())

    {

        WriteLine("Products that cost more than a price, highest at top.");

        string input;

        decimal price;

        do

        {

            Write("Enter a product price: ");

            input = ReadLine();

        } while (!decimal.TryParse(input, out price));

        IOrderedEnumerable<Product> prods = db.Products

        .AsEnumerable()

        .Where(product => product.Cost > price)

        .OrderByDescending(product => product.Cost);

        foreach (Product item in prods)

        {

            WriteLine(

            "{0}: {1} costs {2:$#,##0.00} and has {3} in stock.",

            item.ProductID, item.ProductName, item.Cost, item.Stock);

        }

    }

}



static void QueryingWithLike()

{

    using (var db = new Northwind())

    {

        var loggerFactory = db.GetService<ILoggerFactory>();

        loggerFactory.AddProvider(new ConsoleLoggerProvider());

        Write("Enter part of a product name: ");

        string input = ReadLine();

        IQueryable<Product> prods = db.Products

        .Where(p => EF.Functions.Like(p.ProductName, $"%{input}%"));

        foreach (Product item in prods)

        {

            WriteLine("{0} has {1} units in stock. Discontinued? {2}",

            item.ProductName, item.Stock, item.Discontinued);

        }

    }

}


FilterAndSort();