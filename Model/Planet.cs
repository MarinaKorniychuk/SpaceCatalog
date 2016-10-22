using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceCatalog.Model
{
    public class Planet : IEquatable<Planet>, INotifyPropertyChanged
    {
        private string name;
        private double radius;
        private Mass weight;
        private double periodRotation;
        private double periodRevolving;
        private Star star;
        private double orbitRadius;

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
        public double PeriodRotation
        {
            get { return periodRotation; }
            set
            {
                periodRotation = value;
                OnPropertyChanched("PeriodRotation");
            }
        }
        public double PeriodRevolving
        {
            get { return periodRevolving; }
            set
            {
                periodRevolving = value;
                OnPropertyChanched("PeriodRevolving");
            }
        }
        public Star Star
        {
            get { return star; }
            set
            {
                star = value;
                OnPropertyChanched("Star");
            }
        }
        public double OrbitRadius
        {
            get { return orbitRadius; }
            set
            {
                orbitRadius = value;
                OnPropertyChanched("OrbitRadius");
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
        public bool Equals(Planet other)
        {
            if (Name != other.Name)
                return false;
            if (Radius != other.Radius)
                return false;
            if (!Weight.Equals(other.Weight))
                return false;
            if (PeriodRotation != other.PeriodRotation)
                return false;
            if (PeriodRevolving != other.PeriodRevolving)
                return false;
            if (!Star.Equals(other.Star))
                return false;
            if (OrbitRadius != other.OrbitRadius)
                return false;
            return true;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanched([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        public Planet(string N)
        {
            Name = N;
            PeriodRotation = 0.0;
            PeriodRevolving = 0.0;
            OrbitRadius = 1.0;

        }
    }
}
