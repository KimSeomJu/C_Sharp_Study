using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// C# 1~4 의 정렬 및 필터에 대한 예제 코드
namespace CSharp_1
{
    // System.Collections 를 사용
    public class Product
    {
        // getter 프로퍼티를 만들기 위해 번거럽고 복잡한 많은 코드들을 작성해야 한다.
        string name;
        public string Name { get { return name; } }     // 만약 private setter를 제공하고 싶다면, setter 또한 정의 해주어야 한다.
        decimal price;
        public decimal Price { get { return price; } }
        public Product(string name, decimal price)
        {
            this.name = name;
            this.price = price;
        }
        public static ArrayList GetSampleProducts()
        {
            // ArrayList에 어떤 값이 추가되는지 알 수 없다.
            ArrayList list = new ArrayList();
            list.Add(new Product("상품 2", 1000));
            list.Add(new Product("상품 3", 2000));
            list.Add(new Product("상품 1", 3000));
            list.Add(new Product("상품 4", 4000));

            return list;
        }
        public override string ToString()
        {
            return string.Format("{0} : {1}", name, price);
        }
    }

    class ProductNameComparer : IComparer
    {
        public int Compare(object x, object y)
        {
            // 컴파일러에게 객체를 인식시키기 위해 타입 변환(캐스팅) 시도
            
            Product first = (Product)x;
            Product second = (Product)y;
            return first.Name.CompareTo(second.Name);
        }
    }
}

namespace CSharp_2
{
    // System.Collections.Generic을 사용
    public class Product
    {
        string name;
        public string Name
        {
            get { return name; }
            private set { name = value; }           // C#1에서 private setter가 추가되었다.
        }
        decimal? price;                             // C#2 부터 nullable 타입으로 지정이 가능하다.
        public decimal? Price
        {
            get { return price; }
            private set { price = value; }
        }
        public Product(string name, decimal price)
        {
            this.name = name;
            this.price = price;
        }
        public static List<Product> GetSampleProducts()
        {
            // Generic이 도입되면서 List<T>가 추가되었다.
            // 덕분에 반드시 지정한 타입명으로 할당될 수 있다는 것을 알 수 있다.
            List<Product> list = new List<Product>();
            list.Add(new Product("상품 2", 1000));
            list.Add(new Product("상품 3", 2000));
            list.Add(new Product("상품 1", 3000));
            list.Add(new Product("상품 4", 4000));

            return list;
        }
        public override string ToString()
        {
            return string.Format("{0} : {1}", name, price);
        }
    }

    // 타입을 지정하여 명확해졌으며, 변환할 필요가 사라졌다.
    class ProductNameComparer : IComparer<Product>
    {
        public int Compare(Product x, Product y)
        {
            return x.Name.CompareTo(y.Name);
        }
    }
}

namespace CSharp_3
{
    // System.Collections.Generic을 사용
    public class Product
    {
        string name;
        public string Name
        {
            get { return name; }
            private set { name = value; }           // C#1에서 private setter가 추가되었다.
        }
        decimal? price;
        public decimal? Price
        {
            get { return price; }
            private set { price = value; }
        }
        public Product(string name, decimal? price)
        {
            this.name = name;
            this.price = price;
        }
        public static List<Product> GetSampleProducts()
        {
            // Generic이 도입되면서 List<T>가 추가되었다.
            // 덕분에 반드시 지정한 타입명으로 할당될 수 있다는 것을 알 수 있다.
            List<Product> list = new List<Product>();
            list.Add(new Product("상품 2", 1000));
            list.Add(new Product("상품 3", 2000));
            list.Add(new Product("상품 1", 3000));
            list.Add(new Product("상품 4", 4000));

            return list;
        }
        public override string ToString()
        {
            return string.Format("{0} : {1}", name, price);
        }
    }

    // 타입을 지정하여 명확해졌으며, 변환할 필요가 사라졌다.
    class ProductNameComparer : IComparer<Product>
    {
        public int Compare(Product x, Product y)
        {
            return x.Name.CompareTo(y.Name);
        }
    }
}

namespace CSharp_4
{
    // System.Collections.Generic을 사용
    public class Product
    {
        string name;
        public string Name
        {
            get { return name; }
            private set { name = value; }           // C#1에서 private setter가 추가되었다.
        }
        decimal? price;
        public decimal? Price
        {
            get { return price; }
            private set { price = value; }
        }
        // C# 4 부터 옵션 파라미터 기능을 이용해 추가적으로 생성자 오버로딩을 만들 필요가 없다.
        // 기본 매개변수 라고 부르기도 한다.
        public Product(string name, decimal? price = null)
        {
            this.name = name;
            this.price = price;
        }
        public static List<Product> GetSampleProducts()
        {
            // Generic이 도입되면서 List<T>가 추가되었다.
            // 덕분에 반드시 지정한 타입명으로 할당될 수 있다는 것을 알 수 있다.
            List<Product> list = new List<Product>();
            list.Add(new Product("상품 2", 1000));
            list.Add(new Product("상품 3", 2000));
            list.Add(new Product("상품 1", 3000));
            list.Add(new Product("상품 4", 4000));

            return list;
        }
        public override string ToString()
        {
            return string.Format("{0} : {1}", name, price);
        }
    }

    // 타입을 지정하여 명확해졌으며, 변환할 필요가 사라졌다.
    class ProductNameComparer : IComparer<Product>
    {
        public int Compare(Product x, Product y)
        {
            return x.Name.CompareTo(y.Name);
        }
    }
}

namespace Chapter_1_2
{
    class Program
    {
        static void Main(string[] args)
        {
            ActCSharp1();
            ActCSharp2();
            ActCSharp3();
            ActCSharp4();
        }

        static void ActCSharp1()
        {
            Console.WriteLine("=============== CSharp 1 ===============");
            ArrayList products = CSharp_1.Product.GetSampleProducts();
            products.Sort(new CSharp_1.ProductNameComparer());

            // 리스트 안의 각각의 요소들은 Product 타입으로 변환된다.
            foreach (CSharp_1.Product product in products)
            {
                Console.WriteLine(product);
            }
            Console.WriteLine();

            // 반복문들 돌며 간단하게 if문으로 조건에 맞는 데이터를 출력하고 있다.
            foreach(CSharp_1.Product product in products)
            {
                if (product.Price > 3000)
                    Console.WriteLine(product);
            }
            Console.WriteLine("========================================");
        }

        static void ActCSharp2()
        {
            Console.WriteLine("=============== CSharp 2 ===============");
            List<CSharp_2.Product> products = CSharp_2.Product.GetSampleProducts();
            products.Sort(new CSharp_2.ProductNameComparer());
            // C#2 에서는 델리게이트를 통해 별도의 인터페이스 구현없이 바로 사용이 가능하다.
            products.Sort(delegate (CSharp_2.Product x, CSharp_2.Product y)
            { return x.Name.CompareTo(y.Name); }
            );
            // 리스트 안의 각각의 요소들은 Product 타입으로 변환된다.
            foreach (CSharp_2.Product product in products)
            {
                Console.WriteLine(product);
            }
            Console.WriteLine();

            // 델리게이트 함수인 test와 출력 함수인 print를 다른 메서드에 넘겨 사용하고 있다.
            Predicate<CSharp_2.Product> test = delegate (CSharp_2.Product p) { return p.Price > 3000; };
            List<CSharp_2.Product> matches = products.FindAll(test);
            Action<CSharp_2.Product> print = Console.WriteLine;
            matches.ForEach(print);

            // 위 조건식을 한 문장으로 작성이 가능하다.
            products.FindAll(delegate (CSharp_2.Product p) { return p.Price > 3000; })
                .ForEach(delegate (CSharp_2.Product p) { Console.WriteLine(p); });

            Console.WriteLine("========================================");
        }

        static void ActCSharp3()
        {
            Console.WriteLine("=============== CSharp 3 ===============");
            List<CSharp_3.Product> products = CSharp_3.Product.GetSampleProducts();
            // 람다 식을 통해 delegate 키워드 없이 무명 함수를 구현하였다.
            //products.Sort((x, y) => x.Name.CompareTo(y.Name));

            // 확장메서드를 통해 List의 OrderBy 사용
            foreach (CSharp_3.Product product in products.OrderBy(p => p.Name))
            {
                Console.WriteLine(product);
            }

            foreach(CSharp_3.Product product in products.Where(p => p.Price > 3000))
            {
                Console.WriteLine(product);
            }

            // nullable 타입을 통해 구조체 타입 변수에 null 삽입이 가능하다.
            products.Add(new CSharp_3.Product("상품 6", null));
            foreach(CSharp_3.Product product in products.Where(p => p.Price == null))
            {
                Console.WriteLine("미출시 상품 : " + product.Name);
            }

            Console.WriteLine("========================================");
        }

        static void ActCSharp4()
        {
            Console.WriteLine("=============== CSharp 4 ===============");
            List<CSharp_4.Product> products = CSharp_4.Product.GetSampleProducts();

            // nullable 타입인 price에 옵션 파라미터를 설정하여 가독성이 증가하였다.
            products.Add(new CSharp_4.Product("상품 6"));
            foreach (CSharp_4.Product product in products.Where(p => p.Price == null))
            {
                Console.WriteLine("미출시 상품 : " + product.Name);
            }

            Console.WriteLine("========================================");
        }
    }
}
