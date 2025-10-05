using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneTreni
{
    internal class TrenoMerci : Treno
    {
        double CapacitàdiCarico { get; set; }

        public override void Avvia(DateTime dt)
        {
            Console.WriteLine($"il treno {NumeroTreno} partirà alle {dt.TimeOfDay} con un carico di {CapacitàdiCarico}");
        }



        public TrenoMerci(string numeroTreno, int numeroVagoni, int maxspeed, double capacitàdicarico)
         : base(numeroTreno, numeroVagoni, maxspeed)
        {
            CapacitàdiCarico = capacitàdicarico;
        }




    }
}
