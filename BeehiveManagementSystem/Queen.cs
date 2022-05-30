using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeehiveManagementSystem
{
    public class Queen : Bee
    {
        public Queen() : base("Królowa")
        {
        }
        protected override void DoJob()
        {
            base.DoJob();
        }

        public override float CostPerShift => 2.15f;
    }
}
