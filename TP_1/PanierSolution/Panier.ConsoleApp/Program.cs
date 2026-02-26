

using Panier.Core;

var cart = new ShoppingCart();

Console.WriteLine("Panier de courses (TDD demo)");
Console.WriteLine("Commandes: add | total | discount | count | exit");

while (true)
{
    Console.Write("> ");
    var input = Console.ReadLine();

    if (input is null)
        continue;

    var cmd = input.Trim().ToLowerInvariant();

    if (cmd == "exit")
        break;

    if (cmd == "add")
    {
        Console.Write("Name: ");
        var name = Console.ReadLine() ?? "";

        Console.Write("Price: ");
        var priceText = Console.ReadLine() ?? "0";

        Console.Write("Quantity: ");
        var quantityText = Console.ReadLine() ?? "0";

        if (!decimal.TryParse(priceText, out var price) || !int.TryParse(quantityText, out var quantity))
        {
            Console.WriteLine("Invalid numeric input.");
            continue;
        }

        try
        {
            cart.AddItem(name, price, quantity);
            Console.WriteLine("Item added.");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        continue;
    }

    if (cmd == "total")
    {
        Console.WriteLine($"Total: {cart.GetTotal():0.00}");
        continue;
    }

    if (cmd == "count")
    {
        Console.WriteLine($"Item count: {cart.GetItemCount()}");
        continue;
    }

    if (cmd == "discount")
    {
        Console.Write("Discount percentage (0-100): ");
        var pctText = Console.ReadLine() ?? "0";

        if (!decimal.TryParse(pctText, out var pct))
        {
            Console.WriteLine("Invalid numeric input.");
            continue;
        }

        try
        {
            cart.ApplyDiscount(pct);
            Console.WriteLine("Discount applied.");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        continue;
    }

    Console.WriteLine("Unknown command.");
}