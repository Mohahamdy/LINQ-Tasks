using assist;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection.Metadata;
namespace Tasks
{
    //public class CustCompare : IEqualityComparer<assist.Customer>
    //{
    //    public bool Equals(Customer? x, Customer? y)
    //    {
    //        return x.CompanyName[0] == y.CompanyName[0];
    //    }

    //    public int GetHashCode([DisallowNull] Customer obj)
    //    {
    //        return int.Parse(obj.CustomerID);
    //    }
    //}

    //public class ProdCompare : IEqualityComparer<assist.Product>
    //{
    //    public bool Equals(Product? x, Product? y)
    //    {
    //        return x.ProductName[0] == y.ProductName[0];
    //    }

    //    public int GetHashCode([DisallowNull] Product obj)
    //    {
    //        return (int)obj.ProductID;
    //    }
    //}

    public class StringCompare : IEqualityComparer<string>
    {
        public bool Equals(string? x, string? y)
        {
            var xCharCount = x.Trim().ToCharArray().GroupBy(c => c).ToDictionary(grp => grp.Key, grp => grp.Count());
            var yCharCount = y.Trim().ToCharArray().GroupBy(c => c).ToDictionary(grp => grp.Key, grp => grp.Count());

            return xCharCount.Count == yCharCount.Count && !xCharCount.Except(yCharCount).Any();
        }

        public int GetHashCode([DisallowNull] string obj)
        {
            return obj.Trim().OrderBy(c => c).ToString().GetHashCode();
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            ///*-- Section one*/

            ////query 1
            //var q1 = assist.ListGenerators.ProductList.Where(p => p.UnitsInStock == 0);

            //foreach (var item in q1)
            //{
            //    Console.WriteLine(item.ProductName);
            //}
            //Console.WriteLine("=====================================");

            ////query 2
            //var q2 = assist.ListGenerators.ProductList.Where(p => p.UnitsInStock > 0 && p.UnitPrice > 3);

            //foreach (var item in q2)
            //{
            //    Console.WriteLine($"{item.ProductName} - {item.UnitPrice}");
            //}
            //Console.WriteLine("=====================================");

            ////query 3
            //string[] Arr = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

            //var q3 = Arr.Where((n, i) => n.Length < i);

            //foreach (var item in q3)
            //{
            //    Console.WriteLine(item);
            //}
            //Console.WriteLine("=====================================");

            ///*--section two--*/

            ////query 1
            //var q4 = assist.ListGenerators.ProductList.Where(p => p.UnitsInStock == 0).Take(1);

            //foreach (var item in q4)
            //{
            //    Console.WriteLine(item.ProductName);
            //}
            //Console.WriteLine("=====================================");

            ////query 2 
            //var q5 = assist.ListGenerators.ProductList.Where(p => p.UnitsInStock > 1000).FirstOrDefault();

            //Console.WriteLine(q5);
            //Console.WriteLine("=====================================");

            ////query 3
            //int[] nums = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            //var q6 = nums.Where(n => n > 5).Skip(1).Take(1);
            //foreach (var item in q6)
            //{
            //    Console.WriteLine(item);
            //}
            //Console.WriteLine("=====================================");

            ///*--section three--*/

            ////query 1
            //var q7 = assist.ListGenerators.ProductList.Select(p => p.Category).Distinct();

            //foreach (var item in q7)
            //{
            //    Console.WriteLine(item);
            //}
            //Console.WriteLine("=====================================");

            ////query 2
            //var q8 = assist.ListGenerators.CustomerList.Select(c => c.CompanyName[0]).Union(assist.ListGenerators.ProductList.Select(p => p.ProductName[0]));

            //foreach (var item in q8)
            //{
            //    Console.WriteLine(item);
            //}

            ////query 3
            //var q9 = assist.ListGenerators.CustomerList.SelectMany(customer => assist.ListGenerators.ProductList, (customer, product) => new { customer.CompanyName, product.ProductName })
            //                      .Where(pair => pair.CompanyName[0] == pair.ProductName[0])
            //                      .Select(pair => pair.CompanyName[0]);


            //foreach (var letter in q9.Distinct())
            //{
            //    Console.WriteLine(letter);
            //}

            ////query 4
            //var q10 = assist.ListGenerators.ProductList.Select(product => product.ProductName[0])
            //                                   .Except(assist.ListGenerators.CustomerList.Select(customer => customer.CompanyName[0]));

            //foreach (var letter in q10)
            //{
            //    Console.WriteLine(letter);
            //}

            ////query 5
            //var q11 = assist.ListGenerators.CustomerList.Select(Customer => Customer.CompanyName.Substring(Math.Max(0, Customer.CompanyName.Length - 3)))
            //                               .Concat(assist.ListGenerators.ProductList.Select(Product => Product.ProductName.Substring(Math.Max(0, Product.ProductName.Length - 3))));

            //Console.WriteLine("Last three characters in each name of customers and products:");
            //foreach (var characters in q11)
            //{
            //    Console.WriteLine(characters);
            //}
            //Console.WriteLine("=====================================");


            ///*--section three*/

            ////query 1 
            //int[] Arrnum = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            //var q15 = Arrnum.Where(n => n % 2 == 1).Count();
            //Console.WriteLine(q15);
            //Console.WriteLine("=====================================");

            ////query 2
            //var q16 = assist.ListGenerators.CustomerList.Select(c => new { name = c.CustomerID, orders = c.Orders.Count() });

            //foreach (var item in q16)
            //{
            //    Console.WriteLine(item);
            //}
            //Console.WriteLine("=====================================");

            ////query 3
            //var q17 = assist.ListGenerators.ProductList.GroupBy(p => p.Category, (category,product ) => new {category , products = product.Count() });

            //foreach(var item in q17)
            //{
            //    Console.WriteLine(item);
            //}
            //Console.WriteLine("=====================================");

            ////query 4
            //int[] arr = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            //var q18 = arr.Sum();
            //Console.WriteLine(q18);
            //Console.WriteLine("=====================================");

            ////query 5
            //string fileContents = File.ReadAllText("D:\\Technical Materials\\LINQ\\Tasks\\Day02\\Tasks\\dictionary_english.txt");
            //var q19 = fileContents.Split('\n').Sum(s=>s.Length);
            //Console.WriteLine(q19);
            //Console.WriteLine("=====================================");

            ////query 6
            //var q20 = assist.ListGenerators.ProductList.Where(p => p.UnitsInStock >0).GroupBy(p=>p.Category, (category,product) => new {category,unitOfStock =product.Sum(p=>p.UnitsInStock)});
            //foreach (var item in q20)
            //{
            //    Console.WriteLine(item);
            //}
            //Console.WriteLine("=====================================");

            ////query 7
            //string fileContents = File.ReadAllText("D:\\Technical Materials\\LINQ\\Tasks\\Day02\\Tasks\\dictionary_english.txt");
            //var q21 = fileContents.Split('\n').Aggregate((x,y)  =>
            //{
            //    if (x.Length < y.Length)
            //        return x;
            //    else 
            //        return y;
            //});

            //Console.WriteLine(q21.Length);
            //Console.WriteLine("=====================================");

            ////query 8
            //var q22 = assist.ListGenerators.ProductList.GroupBy(p => p.Category, (c, p) => new { c, CheapestPrice = p.Min(p => p.UnitPrice) });

            //foreach (var item in q22)
            //{
            //    Console.WriteLine(item);
            //}
            //Console.WriteLine("=====================================");

            ////query 9
            //var q23 = from p in assist.ListGenerators.ProductList
            //          group p by p.Category into category
            //          let cheapestProduct = category.OrderBy(p => p.UnitPrice).FirstOrDefault()
            //          select new { category = category.Key, cheapestProduct.ProductName };

            //foreach (var item in q23)
            //{
            //    Console.WriteLine(item);
            //}
            //Console.WriteLine("=====================================");

            ////query 10
            //string fileContents = File.ReadAllText("D:\\Technical Materials\\LINQ\\Tasks\\Day02\\Tasks\\dictionary_english.txt");
            //var q24 = fileContents.Split('\n').Aggregate((x, y) =>
            //{
            //    if (x.Length > y.Length)
            //        return x;
            //    else
            //        return y;
            //});

            //Console.WriteLine($"length={q24.Length}|word: {q24}");
            //Console.WriteLine("=====================================");

            ////query 11
            //var q25 = assist.ListGenerators.ProductList.GroupBy(p => p.Category, (category, p) => new { category, mostExpisve = p.Max(p => p.UnitPrice) });
            //foreach (var item in q25)
            //{
            //    Console.WriteLine(item);
            //}
            //Console.WriteLine("=====================================");

            ////query 12 
            //var q26 = assist.ListGenerators.ProductList.GroupBy(p => p.Category, (category, p) => new { category, mostExpenProducr = p.OrderByDescending(p => p.UnitPrice).FirstOrDefault().ProductName });
            //foreach (var item in q26)
            //{
            //    Console.WriteLine(item);
            //}
            //Console.WriteLine("=====================================");

            ////query 13
            //string fileContents = File.ReadAllText("D:\\Technical Materials\\LINQ\\Tasks\\Day02\\Tasks\\dictionary_english.txt");
            //Console.WriteLine(fileContents.Split("\n").Average(s=>s.Length));

            ////query 14
            //var q25 = assist.ListGenerators.ProductList.GroupBy(p => p.Category, (category, p) => new { category, avgPrice = p.Average(p => p.UnitPrice) });
            //foreach (var item in q25)
            //{
            //    Console.WriteLine(item);
            //}

            ///*--section four--*/

            ////query 1
            //var q26 = assist.ListGenerators.ProductList.OrderBy(p => p.ProductName);
            //foreach (var item in q26)
            //{
            //    Console.WriteLine(item.ProductName);
            //}

            ////query 2
            //string[] Arr = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };
            //var q27 = Arr.OrderBy(s => s.ToLower());
            //foreach (var item in q27)
            //{
            //    Console.WriteLine(item);
            //}
            //Console.WriteLine("-----------------------");

            ////query 3 
            //var q28 = assist.ListGenerators.ProductList.OrderByDescending(p => p.UnitsInStock);

            //foreach (var item in q28)
            //{
            //    Console.WriteLine($"{ item.ProductName}-{item.UnitsInStock}");
            //}

            ////query 4 
            //string[] Arr = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            //var q29 = Arr.OrderBy(x => x.Length).ThenBy(x=>x);
            //foreach (var item in q29)
            //{
            //    Console.WriteLine(item);
            //}

            ////query 5
            //string[] words = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };
            //var q30 = words.OrderBy(w=>w.Length).ThenBy(w=>w.ToLower());

            //foreach (var item in q30)
            //{
            //    Console.WriteLine(item);
            //}

            ////query 6
            //var q31 = assist.ListGenerators.ProductList.OrderBy(p=>p.Category).ThenByDescending(p=>p.UnitPrice);
            //foreach (var item in q31)
            //{
            //    Console.WriteLine(item.Category+" "+item.UnitPrice);
            //}

            ////query 7
            //string[] Arr = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };
            //var q32 = Arr.OrderBy(x => x.Length).ThenBy(x => x);

            ////query 8
            //string[] Arr = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

            //var q33 = Arr.Where(w => w[1] == 'i').Reverse();

            //foreach (var item in q33)
            //{
            //    Console.WriteLine(item);
            //}

            ///*--section five--*/

            ////query 1
            //var q34 = assist.ListGenerators.CustomerList.Where(c => c.City == "London").Select(c => c.Orders.Take(3));

            //foreach (var item in q34)
            //{
            //    foreach (var order in item)
            //    {
            //        Console.WriteLine(order);
            //    }
            //    Console.WriteLine("-----------------------------------------");
            //}

            ////query 2
            //var q35 = assist.ListGenerators.CustomerList.Where(c => c.City == "London").Select(c => c.Orders.Skip(2));
            //foreach (var item in q35)
            //{
            //    foreach (var order in item)
            //    {
            //        Console.WriteLine(order);
            //    }
            //    Console.WriteLine("-----------------------------------------");
            //}

            ////quey 3
            //int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            //var q36 = numbers.TakeWhile((n, index) => n > index);
            //foreach (var item in q36)
            //{
            //    Console.WriteLine(item);
            //}

            ////query 4 
            //int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            //var q37 = numbers.SkipWhile(n => n % 3 != 0);
            //foreach (var item in q37)
            //{
            //    Console.WriteLine(item);
            //}

            //query 5
            //int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            //var q38 = numbers.SkipWhile((n,index)=> n  > index);
            //foreach (var item in q38)
            //{
            //    Console.WriteLine(item);
            //}

            ///*--section six--*/

            ////query 1
            //var q39 = assist.ListGenerators.ProductList.Select(p => p.ProductName);

            //foreach (var item in q39)
            //{
            //    Console.WriteLine(item);
            //}

            ///query 2
            //string[] words = { "aPPLE", "BlUeBeRrY", "cHeRry" };

            //var q40 = words.Select(w => new { upperWord = w.ToUpper(), lowerWord = w.ToLower() });
            //foreach (var item in q40)
            //{
            //    Console.WriteLine(item);
            //}

            ////query 3
            //var q41 = assist.ListGenerators.ProductList.Select(p => new { id = p.ProductID, name = p.ProductName, Price = p.UnitPrice });
            //foreach (var item in q41)
            //{
            //    Console.WriteLine(item);
            //}

            ////query 4
            //int[] Arr = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            //var q42 = Arr.Select((x,index) => x +":"+ (x == index));

            //foreach (var item in q42)
            //{
            //    Console.WriteLine(item);
            //}

            ////query 5
            //int[] numbersA = { 0, 2, 4, 5, 6, 8, 9 };
            //int[] numbersB = { 1, 3, 5, 7, 8 };

            //var q43 = numbersA.SelectMany(n => numbersB,(nA,nB)=> new {nA,nB }).Where(pair => pair.nA < pair.nB).Select(pair => pair.nA+" less than "+pair.nB);
            //foreach (var item in q43)
            //{
            //    Console.WriteLine(item);
            //}

            ////query 6
            //var q44 = assist.ListGenerators.CustomerList.SelectMany(c => c.Orders).Where(o => o.Total < 500);

            //foreach (var item in q44)
            //{
            //    Console.WriteLine(item);
            //}

            ////query 7
            //DateTime d = new DateTime(1998);
            //var q45 = assist.ListGenerators.CustomerList.SelectMany(c => c.Orders).Where(o => o.OrderDate.Year >= d.Year);
            ////.Where(o=> o.OrderDate >= )
            //foreach (var item in q45)
            //{
            //    Console.WriteLine(item);
            //}


            ///*-- section seven--*/

            ////query 1
            //string fileContents = File.ReadAllText("D:\\Technical Materials\\LINQ\\Tasks\\Day02\\Tasks\\dictionary_english.txt");

            //var q46 = fileContents.Split('\n').Any(w=> w.Contains("ei"));

            //Console.WriteLine(q46);

            ////query 2
            //var q47 = assist.ListGenerators.ProductList.GroupBy(p => p.Category).Where(c => c.Any(p=>p.UnitsInStock > 0));

            //foreach (var item in q47)
            //{
            //    foreach (var product in item)
            //    {
            //        Console.WriteLine(product.ProductName+" | "+product.UnitsInStock +" | "+product.Category);
            //    }
            //}

            ////query 3
            //var q48 = assist.ListGenerators.ProductList.GroupBy(p => p.Category).Where(c => c.All(p => p.UnitsInStock > 0));

            //foreach (var item in q48)
            //{
            //    foreach (var product in item)
            //    {
            //        Console.WriteLine(product.ProductName+" | "+product.UnitsInStock +" | "+product.Category);
            //    }
            //}


            ///*-- section eight --*/

            ////query 1
            //int[] arr = {0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 };

            //var q49 = arr.GroupBy(n => n % 5);

            //foreach (var item in q49)
            //{
            //    Console.WriteLine("Items: ");
            //    foreach (var num in item)
            //    {
            //        Console.WriteLine(num);
            //    }
            //}

            ////query 2
            //string[] fileContents = File.ReadAllText("D:\\Technical Materials\\LINQ\\Tasks\\Day02\\Tasks\\dictionary_english.txt").Split("\n");

            //var q50 = fileContents.GroupBy(w => w[0]);
            //foreach (var item in q50)
            //{
            //    Console.WriteLine(item.Key);
            //}

            ////query 3
            //string[] Arr = { "from   ", " salt", " earn ", "  last   ", " near ", " form  " };

            //var q51 = Arr.GroupBy(w => w, new StringCompare());

            //foreach (var item in q51)
            //{
            //    Console.WriteLine("...");
            //    foreach (var word in item)
            //    {
            //        Console.WriteLine(word.Trim());
            //    }
            //}
        }
    }
}
