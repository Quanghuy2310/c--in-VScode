using System.Collections.Generic;
using System.Linq;

public class Product {
    public string ID {get;set;} // ma san pham
    public string Name {get;set;}
    public double Price {get;set;}


}

public class ProductService {
    List<Product> products = new List<Product>();

    public ProductService(){
        products.AddRange(new Product[]{
            new Product() { ID = "product01", Name = "Product 01", Price = 1000},
            new Product() { ID = "product02", Name = "Product 02", Price = 2000},
            new Product() { ID = "product03", Name = "Product 03", Price = 3000},
            new Product() { ID = "product04", Name = "Product 04", Price = 4000},

        });
    }

    public Product FindProduct(string productid){
        var qr = from p in products where p.ID == productid select p;
        return qr.FirstOrDefault();
 
    }
}