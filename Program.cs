List<Product> products = new List<Product>() // list
{
    // instances
    new Product()
    {
        Name = "Football",
        Price = 14.99M,
        Sold = true,
        StockDate = new DateTime(2024, 6, 24),
        ManufactureYear = 2023,
        Condition = 4.2
    },
    new Product()
    {
        Name = "Hockey Stick",
        Price = 12.99M,
        Sold = false,
        StockDate = new DateTime(2024, 5, 20),
        ManufactureYear = 2022,
        Condition = 4.6
    },
    new Product()
    {
        Name = "Basketball",
        Price = 13.99M,
        Sold = true,
        StockDate = new DateTime(2024, 6, 14),
        ManufactureYear = 2024,
        Condition = 4.8
    },
    new Product()
    {
        Name = "Baseball",
        Price = 8.99M,
        Sold = false,
        StockDate = new DateTime(2024, 5, 24),
        ManufactureYear = 2023,
        Condition = 4.4
    },
    new Product()
    {
        Name = "Baseball glove",
        Price = 13.99M,
        Sold = false,
        StockDate = new DateTime(2024, 7, 2),
        ManufactureYear = 2022,
        Condition = 4.5
    },
    new Product()
    {
        Name = "Soccer ball",
        Price = 10.99M,
        Sold = false,
        StockDate = new DateTime(2024, 6, 20),
        ManufactureYear = 2023,
        Condition = 4.1
    }
};

string greeting = @"Welcome to Thrown For a Loop!
Your one-stop shop for used sporting equipment.";
Console.WriteLine(greeting);

string choice = null;
while (choice != "0")
{
    Console.WriteLine(@"Choose an option:
                        0. Exit
                        1. View All Products
                        2. View Product Details
                        3. View Latest Products");
    choice = Console.ReadLine();
    if (choice == "0")
    {
        Console.WriteLine("Goodbye!");
    }
    else if (choice == "1")
    {
        ListProducts();
    }
    else if (choice == "2")
    {
        ViewProductDetails();
    }
    else if (choice == "3")
    {
        ViewLatestProducts();
    }
}

void ViewProductDetails() // method
{
    ListProducts();
    Product chosenProduct = null;
    while (chosenProduct == null)
    {
        Console.WriteLine("Please enter a product number: ");
        try
        {
            int response = int.Parse(Console.ReadLine().Trim());
            chosenProduct = products[response - 1];
        }
        catch (FormatException)
        {
            Console.WriteLine("Please type only integers!");
        }
        catch (ArgumentOutOfRangeException)
        {
            Console.WriteLine("Please choose an existing item only!");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            Console.WriteLine("Do Better!");
        }
    }
    DateTime now = DateTime.Now;
    TimeSpan timeInStock = now - chosenProduct.StockDate;
    Console.WriteLine(@$"You chose: 
    {chosenProduct.Name}, which costs {chosenProduct.Price} dollars.
    It is {now.Year - chosenProduct.ManufactureYear} years old. 
    It's condition is {chosenProduct.Condition} out of 5. 
    It {(chosenProduct.Sold ? "is not available." : $"has been in stock for {timeInStock.Days} days.")}");
}

void ListProducts() // method
{
    decimal totalValue = 0.0M;
    foreach (Product product in products)
    {
        if (!product.Sold)
        {
            totalValue += product.Price;
        }
    }
    Console.WriteLine($"Total inventory value: ${totalValue}");
    Console.WriteLine("Products:");
    for (int i = 0; i < products.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {products[i].Name}");
    }
}

void ViewLatestProducts() // method
{
    // create a new empty list to store the latest products
    List<Product> latestProducts = new List<Product>();
    // calculate a DateTime 90 days in the past
    DateTime threeMonthsAgo = DateTime.Now - TimeSpan.FromDays(90);
    // loop through the products
    foreach (Product product in products)
    {
        // add a product to latestProducts if it fits the criteria
        if (product.StockDate > threeMonthsAgo && !product.Sold)
        {
            latestProducts.Add(product);
        }
    }
    // print out the latest products to the console 
    for (int i = 0; i < latestProducts.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {latestProducts[i].Name}");
    }
}