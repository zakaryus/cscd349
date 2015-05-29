using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cscd349FinalProject
{
    public class HitPoint
    {
        public int Value { get; set; }

        public HitPoint(int v)
        {
            Value = v;
        }

        public static HitPoint operator +(HitPoint a, HitPoint b)
        {
            return new HitPoint(a.Value + b.Value);
        }

        public static HitPoint operator -(HitPoint a, HitPoint b)
        {
            return new HitPoint(a.Value - b.Value);
        }

        public static bool operator >(HitPoint a, HitPoint b)
        {
            return a.Value > b.Value;
        }

        public static bool operator <(HitPoint a, HitPoint b)
        {
            return a.Value < b.Value;
        }
    }
}
