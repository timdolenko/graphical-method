using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public class Constraint
    {

        public double a1;
        public double a2;
        public double b;
        public bool isGreater;

        public Constraint(double a1, double a2, double b, bool isGreater) {
            if (a1 == 0 && a2 == 0)
            {
                throw new Exception("Invalid Constraint");
            } else
            {
                this.a1 = a1;
                this.a2 = a2;
                this.b = b;
                this.isGreater = isGreater;
            }
        }

        public override string ToString()
        {
            string typeString = isGreater ? ">=" : "<=";
            string a2String = a2 >= 0 ? "+ " + a2 : a2.ToString();
            string desc = $"{a1}x1 {a2String}x2 {typeString} {b}";
            return desc;
        }

    }
}
