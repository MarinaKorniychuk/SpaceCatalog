using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceCatalog.Model
{
    public struct Mass : IEquatable<Mass>
    {
        public double Value { get; set; }
        public int Power { get; set; }
        public bool Equals(Mass other)
        {
            if (Value != other.Value)
                return false;
            if (Power != other.Power)
                return false;
            return true;
        }
    }

    public class Star : IEquatable<Star>, INotifyPropertyChanged
    {
        private readonly CollectionPlanet planets;
        private string name;
        private double radius;
        private Mass weight;
        private double luminosity;
        private string type;

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanched("Name");
            }
        }
        public double Radius
        {
            get { return radius; }
            set
            {
                radius = value;
                OnPropertyChanched("Radius");
            }
        }
        public Mass Weight
        {
            get { return weight; }
            set
            {
                weight = value;
                OnPropertyChanched("Weight");
            }
        }
        public double Luminosity
        {
            get { return luminosity; }
            set
            {
                luminosity = value;
                OnPropertyChanched("Luminosity");
            }
        }
        public string Type
        {
            get { return type; }
            set
            {
                type = value;
                OnPropertyChanched("Type");
            }
        }

        public CollectionPlanet Planets
        {
            get { return planets; }
        }

        public bool Equals(Star other)
        {
            if (Name != other.Name)
                return false;
            if (Radius != other.Radius)
                return false;
            if (!Weight.Equals(other.Weight))
                return false;
            if (Luminosity != other.Luminosity)
                return false;
            if (Type != other.Type)
                return false;
            return true;
        }

        /*public override bool Equals(object obj)
        {
            // todo: see msdn
            throw new NotImplementedException();
        }*/

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanched([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
        public Star(string N)
        {
            planets = new CollectionPlanet();
            Name = N;
            Radius = 0.0;
            Luminosity = 1.0;
            Type = "Type";
            foreach (Planet pl in planets)
            {
                pl.Star = this;
            }

        }
    }
}
