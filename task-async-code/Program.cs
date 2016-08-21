using System;
using System.Threading.Tasks;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                Task t = Task.Run(() => { throw new Exception("Exception 1"); });
                Task t2 = Task.Run(()=> {throw new Exception("Exception 2");});
                t.Wait();
            }
            catch (Exception exception)
            {
                Console.WriteLine("Exception Message: " + exception.Message);
                Console.WriteLine("Exception Type: " + exception.GetType().FullName);
                Console.WriteLine("Exception Inner Message: " + exception.InnerException.Message);
            }
        }
    }
}
