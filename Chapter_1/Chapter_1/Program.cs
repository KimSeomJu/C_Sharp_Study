using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp1
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
            list.Add(new Product("상품 1", 1000));
            list.Add(new Product("상품 2", 2000));
            list.Add(new Product("상품 3", 3000));
            list.Add(new Product("상품 4", 4000));

            return list;
        }
        public override string ToString()
        {
            return string.Format("{0} : {1}", name, price);
        }
    }
}

namespace CSharp2
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
        decimal price;
        public decimal Price
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
            list.Add(new Product("상품 1", 1000));
            list.Add(new Product("상품 2", 2000));
            list.Add(new Product("상품 3", 3000));
            list.Add(new Product("상품 4", 4000));

            return list;
        }
        public override string ToString()
        {
            return string.Format("{0} : {1}", name, price);
        }
    }
}

namespace CSharp3
{
    public class Product
    {
        // name, price 변수를 따로 선언하지 않고도 사용할 수 있게 되었다.
        // getter를 통해 어디서든 접근이 가능하였고 일관성있게 수정되어 코드가 깔끔해졌다.
        public string Name { get; private set; }
        public decimal Price { get; private set; }

        public Product(string name, decimal price)
        {
            Name = name;
            Price = price;
        }
        // Name, Price를 직접 접근하여 초기화를 진행하기 때문에 Product(string name, decimal price) 생성자를 지우거나 기본 생성자를 추가해주어야 한다.
        public Product() { }
        public static List<Product> GetSampleProducts()
        {
            return new List<Product>
            {
                // 기본 생성자를 사용하고 있다.
                new Product{Name = "상품 1", Price = 1000 },
                new Product{Name = "상품 2", Price = 2000 },
                new Product{Name = "상품 3", Price = 3000 },
                new Product{Name = "상품 4", Price = 4000 }

            };
        }
        public override string ToString()
        {
            return string.Format("{0} : {1}", Name, Price);
        }
    }
}

namespace CSharp4
{
    public class Product
    {
        // readlony를 통해 런타임에 변수값이 초기화가 되고 가독성이 증가하였다.
        readonly string name;
        public string Name { get { return name; } }
        readonly decimal price;
        public decimal Price { get { return price; } }
        public Product(string name, decimal price)
        {
            this.name = name;
            this.price = price;
        }

        public static List<Product> GetSampleProducts()
        {
            return new List<Product>
            {
                new Product(name : "상품 1", price : 1000 ),
                new Product(name : "상품 2", price : 2000 ),
                new Product(name : "상품 3", price : 3000 ),
                new Product(name : "상품 4", price : 4000 )

            };
        }
        public override string ToString()
        {
            return string.Format("{0} : {1}", name, price);
        }
    }
}

namespace Chapter_1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<CSharp4.Product> list = CSharp4.Product.GetSampleProducts();

            Console.WriteLine("======== Sample List ========");
            for (int i = 0; i < list.Count; i++)
                Console.WriteLine(list[i].ToString());
            Console.WriteLine("=============================");

            CSharp4.Product product = new CSharp4.Product("상품 5", 5000);
            Console.WriteLine("<New Product>");
            Console.WriteLine(product.ToString());

        }
    }
}
