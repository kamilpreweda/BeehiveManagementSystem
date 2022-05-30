using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeehiveManagementSystem
{
    public static class HoneyVault
    {
        public const float NECTAR_CONVERSION_RATIO = .19f;
        public const float LOW_LEVEL_WARNING = 10f;

        private static float honey = 25f;
        private static float nectar = 100f;

        public static string StatusReport
        {  get
            {
                string status = $"JEdnostki miodu: {honey:0.0}\n" +
                                $"Jednostki nektaru: {nectar:0.0}";
                string warnings = "";
                if (honey < LOW_LEVEL_WARNING) warnings += "\nNISKI POZIOM MIODU! DODAJ PRODUCENTKĘ MIODU!";
                if (nectar < LOW_LEVEL_WARNING) warnings += "\nNISKI POZIOM NEKTARU! DODAJ ZBIERACZKĘ NEKTARU!";
                return status + warnings;
            }
        }

        public static void ConvertNectarToHoney(float amount)
        {
            float NectarToConvert = amount;
            if (NectarToConvert > nectar) NectarToConvert = nectar;
            nectar -= NectarToConvert;
            honey = (NectarToConvert * NECTAR_CONVERSION_RATIO);
        }

        public static bool ConsumeHoney(float amount)
        {
            if (amount <= honey)
            {
                honey -= amount;
                return true;
            } 
            return false;
        }

        public static void CollectNectar(float amount)
        {
            if (amount > 0f) nectar += amount;
        }
    }
}
