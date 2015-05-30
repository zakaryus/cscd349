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

        public static bool operator ==(HitPoint a, HitPoint b)
        {
            if (a as Object == null && b as Object == null)
                return true;
            if (a as Object == null || b as Object == null)
                return false;
            return a.Value == b.Value;
        }

        public static bool operator !=(HitPoint a, HitPoint b)
        {
            if (a as Object == null && b as Object == null)
                return false;
            if (a as Object == null || b as Object == null)
                return false;
            return a.Value != b.Value;
        }

        public static HitPoint operator +(HitPoint a, HitPoint b)
        {
            if(a as Object == null || b as Object == null)
                throw new NullReferenceException();
            return new HitPoint(a.Value + b.Value);
        }

        public static HitPoint operator -(HitPoint a, HitPoint b)
        {
            if(a as Object == null || b as Object == null)
                throw new NullReferenceException();
            return new HitPoint(a.Value - b.Value);
        }

        public static bool operator >(HitPoint a, HitPoint b)
        {
            if(a as Object == null || b as Object == null)
                throw new NullReferenceException();
            return a.Value > b.Value;
        }

        public static bool operator <(HitPoint a, HitPoint b)
        {
            if(a as Object == null || b as Object == null)
                throw new NullReferenceException();
            return a.Value < b.Value;
        }

        public static bool operator >=(HitPoint a, HitPoint b)
        {
            if(a as Object == null || b as Object == null)
                throw new NullReferenceException();
            return a.Value >= b.Value;
        }

        public static bool operator <=(HitPoint a, HitPoint b)
        {
            if(a as Object == null || b as Object == null)
                throw new NullReferenceException();
            return a.Value <= b.Value;
        }
    }
}
