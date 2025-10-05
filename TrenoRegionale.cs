using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneTreni
{
    internal class TrenoRegionale : Treno
    {
        public int NumeroFermate { get; set; }

        public override void Avvia(DateTime dt)
        {
            Console.WriteLine($"il treno {NumeroTreno} partirà alle {dt.TimeOfDay} e farà {NumeroFermate} fermate");
        }

        public TrenoRegionale(string numeroTreno, int numeroVagoni, int maxspeed, int numeroFermate)
            : base(numeroTreno, numeroVagoni, maxspeed)
        {
            NumeroFermate = numeroFermate;
        }
    }
}
