using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeehiveManagementSystem
{
    public class HoneyManufacturer : Bee
    {
        public HoneyManufacturer() : base("Producentka miodu")
        {

        }
        protected override void DoJob()
        {
            base.DoJob();
        }

        public override float CostPerShift => 1.7f;
    }
}
