using System.Net.Sockets;
using System.Reflection.Metadata;

namespace GestioneTreni
{
    internal class Program
    {
        private static object? _lock = new object ();

        static void Main(string[] args)
        {
            List<Treno> treni = new List<Treno>();
            //UseThread(treni);
            UseTask(treni);

            foreach (var treno in treni)
            {
                treno.Avvia(DateTime.Now);
                treno.MostraDettagli();
                Console.WriteLine();
            }
        }

        public static void UseTask(List<Treno> treni)
        {
            Task t1 = new Task( () => LoadTreniRegionali(treni) );
            t1.Start();

            Task t2 = new Task(() => LoadTreniAV(treni));
            t2.Start();

            Task t3 = new Task(() => LoadTreniMerci(treni));
            t3.Start();

            t1.Wait();
            t2.Wait();
            t3.Wait();
        }

        public static void UseThread(List<Treno> treni)
        {
            Thread t1 = new Thread(LoadTreniRegionali);
            t1.Start(treni);

            Thread t2 = new Thread(LoadTreniAV);
            t2.Start(treni);

            Thread t3 = new Thread(LoadTreniMerci);
            t3.Start(treni);

            t1.Join();
            t2.Join();
            t3.Join();
        }



        private static void LoadTreniAV(object? obj)
        {
            var lst = (List<Treno>)obj;

                for (int i = 1; i <= 4; i++)
                {
                    var treno = new TrenoAV($"AV{i:000}", 8 + i, 300 + i * 10, i % 2 == 0);

                    lock (_lock)
                    {
                        lst.Add(treno);
                    }
                    Console.WriteLine($"[Thread Alta Velocità] Aggiunto treno {treno.NumeroTreno}");
                    
                    Thread.Sleep(250);
                }
        }

        private static void LoadTreniRegionali(object? obj)
        {
            var lst = (List<Treno>)obj;
            
                for (int i = 1; i <= 4; i++)
                {
                    var treno = new TrenoRegionale($"R{i:000}", 5 + i, 150, 10 + i);

                lock (_lock)
                {
                    lst.Add(treno);
                }
                Console.WriteLine($"[Thread Regionale] Aggiunto treno {treno.NumeroTreno}");

                Thread.Sleep(200);
                
            }
        }

        private static void LoadTreniMerci(object? obj)
        {
            var lst = (List<Treno>)obj;
           
                for (int i = 1; i <= 4; i++)
                {
                    var treno = new TrenoMerci($"M{i:000}", 20 + i, 120, 1500 + i * 200);

                 lock (_lock)
                 {
                      lst.Add(treno);
                 }
            Console.WriteLine($"[Thread Merci] Aggiunto treno {treno.NumeroTreno}");
                    
                    Thread.Sleep(300);
                }

        }
    }
}
