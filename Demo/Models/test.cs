namespace Demo.Models
{
    public class test
    {
        public static int add(int x, int y)//
        {
            return x + y;
        }
    }
    public class test2
    {
        public int add2(int a,int b,int c)
        {
            return c + test.add(a,b);//call name
        }
    }
}
