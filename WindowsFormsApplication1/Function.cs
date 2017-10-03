using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{

    public class Function
    {

        public double c1;
        public double c2;

        public Constraint[] constraints;
        
        public Function(double c1, double c2, Constraint[] constraints) {
            if (c1 == 0 && c2 == 0)
            {
                throw new Exception("Invalid function");
            }
            else
            {
                this.c1 = c1;
                this.c2 = c2;
                this.constraints = constraints;
            }
        }

        public override string ToString()
        {
            string c2String = c2 > 0 ? "+ " + c2 : "- " + c2 * -1;
            return $"F= {c1}x1 {c2String}x2";
        }

    }
}
