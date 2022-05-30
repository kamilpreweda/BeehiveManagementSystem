using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeehiveManagementSystem
{
    public class EggCare : Bee
    {
        public EggCare() : base("Opiekunka jaj")
        {

        }

        protected override void DoJob()
        {
            base.DoJob();
        }

        public override float CostPerShift => 1.35f;
    }
}
