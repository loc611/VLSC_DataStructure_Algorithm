using System;
class Program
{
    //ham de quy tinh tong S(n)
    static int tinhtong(int n)
    {
        //1. truong hop co so  : khi n=1, tong chinh la 1 
        if (n ==1 )
            return 1;
            //2 buoc de quy : s(n) = n + s(n-1)
            return n+ tinhtong(n-1);
    }
   
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine("nhap n de tinh tong: ");
        int n = int.Parse(Console.ReadLine());
        Console.WriteLine($"tong S({n}) = {tinhtong(n)}");
        
    }
}
