using System;
using System.Linq; //required
using System.Collections.Generic;
using System.Text.Unicode;
using System.Globalization;

namespace Linq
// linq (Language Integrated Querry ) : Ngôn ngữ truy vấn tich hợp
// khác giống SQL
// Nguồn dữ liệu IEnumerable, IEnumerable<T> (Array, List, Stack, Queue ...)
//XML, SQL
{
    public class Brand
    {
        public string? Name { set; get; }
        public int ID { set; get; }
    }
    public class Product
    {
        public int ID { set; get; }
        public string Name { set; get; }         // tên
        public double Price { set; get; }        // giá
        public string[] Colors { set; get; }     // các màu sắc
        public int Brand { set; get; }           // ID Nhãn hiệu, hãng
        public Product(int id, string name, double price, string[] colors, int brand)
        {
            ID = id; Name = name; Price = price; Colors = colors; Brand = brand;
        }
        // Lấy chuỗi thông tin sản phẳm gồm ID, Name, Price
        override public string ToString()
           => $"{ID,3} {Name,12} {Price,5} {Brand,2} {string.Join(",", Colors)}";

    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            // Product p = new Product(1, "Abc", 1000, new string[] { "Xanh", "Do" }, 2);
            // System.Console.WriteLine(p);
            var brands = new List<Brand>() {
            new Brand{ID = 1, Name = "Công ty A"},
            new Brand{ID = 2, Name = "Công ty B"},
            new Brand{ID = 4, Name = "Công ty C"},
            };

            var products = new List<Product>()
            {
                new Product(1, "Bàn trà",    400, new string[] {"Xám", "Xanh"},         2),
                new Product(2, "Tranh treo", 400, new string[] {"Vàng", "Xanh"},        1),
                new Product(3, "Đèn trùm",   500, new string[] {"Trắng"},               3),
                new Product(4, "Bàn học",    200, new string[] {"Trắng", "Xanh"},       1),
                new Product(5, "Túi da",     300, new string[] {"Đỏ", "Đen", "Vàng"},   2),
                new Product(6, "Giường ngủ", 500, new string[] {"Trắng"},               2),
                new Product(7, "Tủ áo",      600, new string[] {"Trắng"},               3),
            };

            // show items price 400
            // var query = from p in products 
            //             where p.Price == 400 
            //             select p;
            // foreach(var product in query){
            //     System.Console.WriteLine(product);
            // }


            //select
            // var resultSelect = products.Select(
            //     (p) => {
            //         // return p.Name + " giá : " + p.Price;
            //         return new {
            //             Ten = p.Name,
            //             Gia = p.Price
            //         };
            //     }
            // );
            // foreach(var item in resultSelect){
            //     System.Console.WriteLine(item);
            // }

            // where
            // var resultWhere = products.Where(
            //     (p) => {
            //         // return p.Name.Contains("tr");
            //         // return p.Brand == 2;
            //         return p.Price >= 200 && p.Price <= 300;
            //     }
            // );

            // foreach(var item in resultWhere){
            //     System.Console.WriteLine(item);
            // }

            // selectMany
            // var resultSelectMany = products.SelectMany(
            //     (p) => {
            //         return p.Colors;
            //     }
            // );

            // foreach(var item in resultSelectMany){
            //     System.Console.WriteLine(item);
            // }

            // Min, Max, Sum, Average
            // int[] numbers = {1,2,3,4,5,6,7};
            // System.Console.WriteLine(numbers.Min());
            // System.Console.WriteLine(numbers.Sum());
            // System.Console.WriteLine(numbers.Max());
            // System.Console.WriteLine(numbers.Average());
            // System.Console.WriteLine(numbers.Where(n => n % 2 == 0).Sum());
            // System.Console.WriteLine(products.Min(p=>p.Price));

            // Join 
            // var resultJoin = products.Join(brands, p => p.Brand, b => b.ID,
            //      (p,b) => {
            //         return new {
            //             Name = p.Name,
            //             Brand = b.Name
            //         };
            //      });

            // foreach(var item in resultJoin){
            //     System.Console.WriteLine(item);
            // }

            // GroupJoin
            // var resultGroupJoin = brands.GroupJoin(products, b => b.ID, p => p.Brand, 
            //     (brand, products)=> {
            //         return new {
            //             Brand = brand.Name,
            //             Products = products
            //         };
            //     });
            // foreach( var items in resultGroupJoin ){
            //     System.Console.WriteLine(items.Brand);
            //     foreach(var group in items.Products){
            //         System.Console.WriteLine(group);
            //     }
            // }

            // Take
            // products.Take(4).ToList().ForEach( p => System.Console.WriteLine(p));

            // Skip
            // products.Skip(2).ToList().ForEach( p => System.Console.WriteLine(p));

            // OrderBy ( tang ) / OrderByDescending ( giam )
            // products.OrderBy(p => p.Price).ToList().ForEach(p => System.Console.WriteLine(p));
            // products.OrderByDescending(p => p.Price).ToList().ForEach(p => System.Console.WriteLine(p));

            // Reverse  
            // int[] numbers = {1,23,4,5,6,7,8,9,};
            // numbers.Reverse().ToList().ForEach(n => System.Console.WriteLine(n));

            // GroupBy
            // var resultGroupBy = products.GroupBy(p => p.Price );
            // foreach (var group in resultGroupBy){
            //     System.Console.WriteLine(group.Key);
            //     foreach(var p in group){
            //         System.Console.WriteLine(p);
            //     }
            // }
            // var resultGroupBy = products.GroupBy(p => p.Brand );
            // foreach (var group in resultGroupBy){
            //     System.Console.WriteLine(group.Key);
            //     foreach(var p in group){
            //         System.Console.WriteLine(p);
            //     }
            // }

            // Distinct
            // products.SelectMany(p => p.Colors).Distinct().ToList()
            // .ForEach(color => System.Console.WriteLine(color));

            // Single / SingleOrDefault check cac phan tu thoa man dieu kien, > 2 phan tu se => loi
            // var resultSingle = products.SingleOrDefault(p=>p.Price == 200);
            // if(resultSingle!=null)System.Console.WriteLine(resultSingle);

            // Any check cac phan tu, neu exsit => true, >< false
            // var resultAny = products.Any(p => p.Price == 600);
            // System.Console.WriteLine(resultAny);

            // All
            // var resultAll = products.All(p => p.Price >= 600);
            // System.Console.WriteLine(resultAll);

            //Count
            // var resultCount = products.Count(p => p.Price <= 200);
            // System.Console.WriteLine(resultCount);

            // xác định nguồn : from tenphantu in IEnumerables ... where, orderby
            // lay du lieu select, groupby ...

            // var result = from product in products
            //             from color in product.Colors
            //                 where product.Price <= 400 && color == "Xanh" 
            //                 orderby product.Price
            //                 select new {
            //                     Name = product.Name,
            //                     Price = product.Price,
            //                     Colors = product.Colors
            //                 };
            // result.ToList().ForEach(result => {
            //     System.Console.WriteLine($"{result.Name} - {result.Price} {string.Join(',', result.Colors)}");
                
            // });

            // nhom san pham theo gia
            // var resultGroup = from p in products
            //                     group p by p.Price;
            // resultGroup.ToList().ForEach(group =>{
            //     System.Console.WriteLine(group.Key);
            //     group.ToList().ForEach(p=>System.Console.WriteLine(p)); 
            // });

            // var result = from p in products
            //                 group p by p.Price into gr
            //                 orderby gr.Key
            //                 let sl = "So luong trong gr la " + gr.Count() 
            //                 select new {
            //                     Price = gr.Key,
            //                     Item = gr.ToList(),
            //                     Quantity = sl
            //                 };
            // result.ToList().ForEach(i => {
            //     System.Console.WriteLine(i.Price);
            //     System.Console.WriteLine(i.Quantity);
            //     i.Item.ForEach(p=>System.Console.WriteLine(p));
            // });

            // join
            // var resultJoin = from product in products
            //                 join brand in brands on product.Brand equals brand.ID into t
            //                 from b in t.DefaultIfEmpty()
            //                 select new {
            //                   Name = product.Name,
            //                   Price = product.Price,
            //                   Brand = (b != null) ? b.Name : "khong co thuoong hieu"  
            //                 };
            // resultJoin.ToList().ForEach(o => {
            //     System.Console.WriteLine($"{o.Name,10} {o.Brand,15} {o.Price,5}");
            // });


        }
    }
}