using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneTreni
{
    internal abstract class Treno
    {
        public string? NumeroTreno { get; set; }
        public int? NumeroVagoni { get; set; }
        public int? MaxSpeed { get; set; }

        public abstract void Avvia(DateTime dt);

        public virtual void MostraDettagli() { Console.WriteLine($"N° {NumeroTreno} N° Vagoni {NumeroVagoni} MaxSpeed {MaxSpeed}"); }

        public Treno(string? numeroTreno, int? numeroVagoni, int? maxSpeed)
        {
            NumeroTreno = numeroTreno;
            NumeroVagoni = numeroVagoni;
            MaxSpeed = maxSpeed;
        }
    }
}
