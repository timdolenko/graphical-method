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
            this.c1 = c1;
            this.c2 = c2;
            this.constraints = constraints;
        }

    }
}
