using SpaceCatalog.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceCatalog.ViewModel
{
    public class ConstellationViewModel
    {
        public CollectionConstellation Constellations { get; set; }

        public void LoadConstellations()
        {
            CollectionConstellation constellations = new CollectionConstellation();
            Constellations = constellations;
        }

    }
}
