using ProductAssignment;
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Hello, World!");


AddManyProducts();
AddNewProduct();
UpdateProduct();
RemoveProduct();

void AddManyProducts()

{
    var Products = new List<Product>();
    Products.Add(new Product { Name = "Pears", Price = 10.5, Description = "Soap for beauty" });
    Products.Add(new Product { Name = "Sunshilk", Price = 20, Description = "This is shampoo for hair" });
    Products.Add(new Product { Name = "Colgate", Price = 12, Description = "for teeth clening" });
    using var context = new ProductDbContext();
    foreach (var s in Products)

    {
        context.Products.Add(s);
    }
    context.SaveChanges();

}

void AddNewProduct()
{
    var Products = new Product()
     { Name = "spactacles", Price = 50, Description = "Lens cart" };
    using var context = new ProductDbContext();
    context.Products.Add(Products);
    context.SaveChanges();


}

void QueryProducts()
{
    using var context = new ProductDbContext();
    var prod = context.Products.ToList();
    foreach (var p in prod)

    {
        Console.WriteLine(p.Name + " " + p.Price + " " + p.Description);
    }

}
void UpdateProduct()
{
    using var context = new ProductDbContext();
    var prod = context.Products.FirstOrDefault(p => p.Name == "pears");

    Console.WriteLine(prod.Name);

    prod.Price = 100;

    context.SaveChanges();



}
 void RemoveProduct()
{
    using var context = new ProductDbContext();
    var prod = context.Products.Where(p=>p.Name == "pears").ToList();

    foreach (var p in prod)
    {
        Console.WriteLine(p.Name);

        context.Products.Remove(p);
    }
    context.SaveChanges();



}