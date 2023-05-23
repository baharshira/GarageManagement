using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class ValueOutOfRangeException : Exception
    {
        private readonly float r_MaxValue;
        private readonly float r_MinValue;
        public float MaxValue
        {
            get { return r_MaxValue; }
        }

        public float MinValue
        {
            get { return r_MinValue; }
        }

        public ValueOutOfRangeException(string msg, float r_MaxValue, float r_MinValue)
            : base(string.Format("Value is out of range: {0}-{1}", r_MinValue, r_MaxValue))
        {

        }
    }
}
