using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonOop
{
    class Bits
    {
        public double Value { get; private set; } = 0;
       

        public static implicit operator Bits(byte b) {  return new Bits { Value = b}; }
        public static implicit operator Bits(long l) { return new Bits { Value = l }; }
        public static implicit operator Bits(int i) { return new Bits { Value = i }; }
        
    }
}
