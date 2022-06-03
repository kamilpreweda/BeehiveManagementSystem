using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace BeehiveManagementSystem
{
    public class Queen : Bee, INotifyPropertyChanged
    {
        public const float EGGS_PER_SHIFT = 0.45f;
        public const float HONEY_PER_UNASSIGNED_WORKER = 0.5f;

        private IWorker[] workers = new IWorker[0];
        private float unassignedWorkers = 3;
        private float eggs = 0;

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public string StatusReport { get; private set; }
        public Queen() : base("Królowa")
        {
            AssignBee("Opiekunka jaj");
            AssignBee("Zbieraczka nektaru");
            AssignBee("Producentka miodu");
        }
        protected override void DoJob()
        {
            eggs += EGGS_PER_SHIFT;
            foreach (Bee worker in workers)
            {
                worker.WorkTheNextShift();

            }
            HoneyVault.ConsumeHoney(HONEY_PER_UNASSIGNED_WORKER * unassignedWorkers);
            UpdateStatusReport();
        }

        public override float CostPerShift => 2.15f;

        /// <summary>
        ///     Zwiększanie tablicy workers o jedno miejsce i dodanie referencji typu Bee
        /// </summary>
        /// <param name="worker">Robotnica dodawana do tablicy workers</param>
        private void AddWorker(IWorker worker)
        {
            if (unassignedWorkers >= 1)
            {
                unassignedWorkers--;
                Array.Resize(ref workers, workers.Length + 1);
                workers[workers.Length - 1] = worker;
            }
        }

        public void AssignBee(string job)
        {
            switch (job)
            {
                case "Opiekunka jaj":
                    AddWorker(new EggCare(this));
                    break;
                case "Zbieraczka nektaru":
                    AddWorker(new NectarCollector());
                    break;
                case "Producentka miodu":
                    AddWorker(new HoneyManufacturer());
                    break;
                default:
                    break;
            }
            UpdateStatusReport();

        }

        public void CareForEggs(float eggsToConvert)
        {
            if (eggs >= eggsToConvert)
            {
                eggs -= eggsToConvert;
                unassignedWorkers += eggsToConvert;
            }
        }
        private void UpdateStatusReport()
        {
            StatusReport = $"Raport o stanie skarbca: \n" +
                            $"{HoneyVault.StatusReport}\n" +
                            $"Liczba jaj: {eggs:0.0}\n" +
                            $"Nieprzydzielone robotnice: {unassignedWorkers:0.0}\n" +
                            $"{WorkerStatus("Zbieraczka nektaru")}\n" +
                            $"{WorkerStatus("Producentka miodu")}\n" +
                            $"{WorkerStatus("Opiekunka jaj")}\n" +
                            $"ROBOTNICE W SUMIE: {workers.Length}";
            OnPropertyChanged("StatusReport");

        }

        private string WorkerStatus(string job)
        {
            int count = 0;
            foreach(IWorker worker in workers)
                if (worker.Job == job) count++;
            return $"{job}: {count}";




        }
    }
}