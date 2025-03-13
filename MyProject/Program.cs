using System;
using System.Linq; // for using min,max,sum in for loop in arrays


namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            // But WriteLine is Diff than Write it doesnot print things in new line.
            
            // Console.WriteLine("Hello, World!");
            // Console.WriteLine("This is new Line");
            // Console.WriteLine("its a functionality of the writeline");
            

            // Console.Write("Line 1 ");
            // Console.Write("Line 2");

            /* Console.WriteLine("Calling the Function : ");

             Basic.ProcessData(); */

            // DataTypes
            string name="ashish";
            bool isLogin= true;
            double data=1.234;
            char c='A';
            int num=61;

            // we can also use const in our DataTypes;

            const string name2="ashish";
            name="Chauhan";
            // name2="Chauhan2";  cant do it
            // Console.WriteLine(name);
            // Console.WriteLine($" My name is {name} ");


            // const string fiName="Ashish";
            // const string lName="Chauhan";
            // const string fName=fiName+lName;

            // Console.WriteLine($" My name is {fName}!");


            // TypeCasting

            int val=34;
            double val2=val;
            // Console.WriteLine(val2);

            // string nameVale=val.ToString();  
            // Console.WriteLine(nameVale);


            // Console.WriteLine("Enter Username : ");
            // string Username=Console.ReadLine(); // this method will only returns a string.

            // Console.Write("Enter Password : ");
            // int Password= Convert.ToInt32(Console.ReadLine());

            // Operators are same as like in C++


            // Math Functions

            //   int maxi=Math.Max(10,16);
            //   Console.WriteLine(maxi);
            //   maxi=Math.Min(10,16);
            //   Console.WriteLine(maxi);

            //    Console.WriteLine($" Value of root is : {Math.Sqrt(64)}");

               //Others are :  Math.Round and Math.Abs




            string myString = "Hello";
            // Console.WriteLine(myString.IndexOf("e"));  // Outputs "1"

            switch(myString){
                case "hello1":
                     Console.WriteLine("Milgya 1");
                     break;
                case "hello2":
                     Console.WriteLine("Milgya 2");
                     break;
                case "hello3":
                     Console.WriteLine("Milgya 3");
                     break;
                case "Hello":
                     Console.WriteLine("Milgya 4");
                     break;
                default:
                     Console.WriteLine("Milgya 5");
                     break;
            }
            
            // Arrays
            char[] arr={'A','B','Z','D','E'};
            Array.Sort(arr);
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i]);
            }
   
            // 2D matrix

            int [,] matrix={{1,2,3},{3,4,5},{5,6,7}};
             foreach (int i in matrix)
             {
                Console.WriteLine(i);
             }
             solve();
             solve2("Vanshika");
             solve2("Ashish");
             Console.WriteLine(solve3(3,4));

             // Method Overloading is also possible

              int MyMethod(int x)
              float MyMethod(float x)
              double MyMethod(double x, double y)

           
        }

// Create function inside the Program class but outside the main function and call it from the main function

        // Functions/ methods
           static void solve(){
             Console.WriteLine("Hi from the Function");
           }

           static void solve2(string name){
             Console.WriteLine($"Hi {name} from the Function");
            //  Console.WriteLine($"Hi from the Function" + name);
           }
           static int solve3(int a,int b){
            return a+b;
           }


           
    }
}