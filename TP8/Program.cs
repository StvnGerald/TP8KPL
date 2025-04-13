using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP8
{
    class Program
    {
        static void Main(string[] args)
        {
            CovidConfig config = new CovidConfig();

            config.UbahSatuan();

            Console.Write($"Berapa suhu badan anda saat ini? Dalam nilai {config.SatuanSuhu}: ");
            string suhuInput = Console.ReadLine();
            if (!double.TryParse(suhuInput, out double suhu))
            {
                Console.WriteLine("Input suhu tidak valid.");
                return;
            }

            Console.Write("Berapa hari yang lalu (perkiraan) anda terakhir memiliki gejala demam? ");
            string hariInput = Console.ReadLine();
            if (!int.TryParse(hariInput, out int hari))
            {
                Console.WriteLine("Input hari tidak valid.");
                return;
            }

            bool suhuNormal = false;

            if (config.SatuanSuhu.ToLower() == "celcius")
            {
                suhuNormal = suhu >= 36.5 && suhu <= 37.5;
            }
            else if (config.SatuanSuhu.ToLower() == "fahrenheit")
            {
                suhuNormal = suhu >= 97.7 && suhu <= 99.5;
            }

            bool demamLama = hari < config.BatasHariDeman;

            if (suhuNormal && demamLama)
            {
                Console.WriteLine(config.PesanDiterima);
            }
            else
            {
                Console.WriteLine(config.PesanDitolak);
            }
        }
    }
}
