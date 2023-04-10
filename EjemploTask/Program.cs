using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EjemploTask
{
    class Program
    {

        static String[] x = new string[2];

        static void Main(string[] args)
        {
            FooAsync();

            for(int i = 0; i < x.Length; i++)
            {
                Console.WriteLine($"Valor en posicisión {i} = {x[i]}");
            }

            
            Console.ReadKey();
        }


        public static void FooAsync()
        {
            List<Task> tareas = new List<Task>();
            tareas.Add(ExecuteLongRunningTask("Victor",0));
            tareas.Add(ExecuteLongRunningTask("Israel",1));
            Task.WaitAll(tareas.ToArray());

        }

        public static Task ExecuteLongRunningTask(string mensaje, int slot)
        {
            return (Task.Factory.StartNew(() =>
            {
                Thread.Sleep(5000);
                x[slot] = $"Hola {mensaje}";
            }));
        }
    }
}
