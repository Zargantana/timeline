using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TimeFabric
{
    public class mESUREITOR
    {
        public DateTime a, b;
        

        public void StartMesure()
        {
            a = DateTime.Now;
        }

        public void StopMeuser()
        {
            b = DateTime.Now;
            long elapsedTicks = b.Ticks - a.Ticks;
            TimeSpan elapsedSpan = new TimeSpan(elapsedTicks);
            Console.WriteLine("   {0:N0} nanoseconds", elapsedTicks * 100);
            Console.WriteLine("   {0:N0} ticks", elapsedTicks);
        }
    }

    public static class GODmESUREITOR
    {
        public static DateTime a, b;
        private static DateTime lastUse = DateTime.Now;
        private static int count = 0;
        private static int last_count = 0;

        public static void StartMesure()
        {
            a = DateTime.Now;
            if (lastUse.Second != a.Second)
            {
                last_count = count;
                count = 1;
            }
            else
            { 
                count++; 
            }
            lastUse = a;
        }

        public static void StopMesure()
        {
            b = DateTime.Now;
            long elapsedTicks = b.Ticks - a.Ticks;
            TimeSpan elapsedSpan = new TimeSpan(elapsedTicks);
            //Console.WriteLine("   {0:N0} nanoseconds", elapsedTicks * 100);
            //Console.WriteLine("   {0:N0} ticks", elapsedTicks);
        }
    }
}
