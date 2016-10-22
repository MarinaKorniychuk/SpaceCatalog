using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceCatalog.Model
{
    public class CollectionConstellation : CollectionGeneral<Constellation>
    {
        public CollectionConstellation()
        {
            Constellation Cygnus = new Constellation();

            this.Add(Cygnus);
            this[0].Name = "Cygnus";

            Star Sadr = new Star("Sard");
            Star Deneb = new Star("Deneb");

            Planet P1 = new Planet("Planet1");
            Planet P2 = new Planet("Planet2");
            Planet P3 = new Planet("Planet3");

            this[0].Stars.Add(Sadr);
            this[0].Stars.Add(Deneb);


            this[0].Stars[0].Planets.Add(P1);
            this[0].Stars[0].Planets.Add(P2);
            this[0].Stars[1].Planets.Add(P3);

            this[0].Stars[0].Planets.Add(P1);
            this[0].Stars[0].Planets.Add(P2);
            this[0].Stars[1].Planets.Add(P3);

            Constellation Perseus = new Constellation();

            this.Add(Perseus);
            this[1].Name = "Perseus";

            Star Mirfak = new Star("Mirfak");
            Star Algenib = new Star("Algenib");
            Star Algol = new Star("Algol");

            this[1].Stars.Add(Mirfak);
            this[1].Stars.Add(Algenib);
            this[1].Stars.Add(Algol);
            this[1].Stars.Add(Mirfak);
            this[1].Stars.Add(Algenib);
            this[1].Stars.Add(Algol);

            Planet P4 = new Planet("Planet1");
            Planet P5 = new Planet("Planet2");
            Planet P6 = new Planet("Planet3");

            this[1].Stars[0].Planets.Add(P4);
            this[1].Stars[1].Planets.Add(P5);
            this[1].Stars[1].Planets.Add(P6);

            this[1].Stars[0].Planets.Add(P4);
            this[1].Stars[1].Planets.Add(P5);
            this[1].Stars[1].Planets.Add(P6);

        }
    }
}
