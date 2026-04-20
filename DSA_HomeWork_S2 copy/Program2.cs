using System;
class bai2
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
    static long giaithuavonglap(int n)
    {
        long ketqua = 1;
        for (int i = 1; i <= n; i++)
        {
            ketqua *= i;
        }
        return ketqua;
    }
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine("nhap n de tinh tong: ");
        int n = int.Parse(Console.ReadLine());
        Console.WriteLine($"tong S({n}) = {tinhtong(n)}");
        Console.WriteLine($"giai thua cua {n} la: {giaithuavonglap(n)}");
    }
}