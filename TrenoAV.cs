using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneTreni
{
    internal class TrenoAV : Treno
    {
        public bool ServizioRistorante { get; set; }

        public TrenoAV(string numeroTreno, int numeroVagoni, int maxspeed, bool servizioristorante)
           : base(numeroTreno, numeroVagoni, maxspeed)
        {
            ServizioRistorante = servizioristorante;
        }

        public override void Avvia(DateTime dt)
        {
            StringBuilder sb = new StringBuilder();
            string servizio = ServizioRistorante ? "con servizio a bordo" : "senza servizio a bordo";

            Console.WriteLine($"il treno {NumeroTreno} partirà alle {dt.TimeOfDay} e sarà  {servizio}");
        }
    }
}
