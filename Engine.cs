using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public abstract class Engine
    {
        public float CurrentCapacity { get; set; }
        private readonly float r_MaxCapacity;
        public float MaxCapacity
        {
            get { return r_MaxCapacity; }
        }

        public Engine(float maxCapacity)
        {
            r_MaxCapacity = maxCapacity;
        }
    }
}
