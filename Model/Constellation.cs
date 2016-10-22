using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceCatalog.Model
{
    public class Constellation : INotifyPropertyChanged
    {
        // image
        private readonly CollectionStar stars;
        private string name;
        private string coordinates;

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanched("Name");
            }
        }
        public string Coordinates
        {
            get { return coordinates; }
            set
            {
                coordinates = value;
                OnPropertyChanched("Coordinates");
            }
        }
        public CollectionStar Stars
        {
            get { return stars; }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanched([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        public Constellation()
        {
            stars = new CollectionStar();
            Name = "NameC";
            // Coordinates
        }
    }
}
