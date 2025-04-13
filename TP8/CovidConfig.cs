using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;

namespace TP8
{
    public class CovidConfig
    {
        private const string ConfigFileName = "covid_config.json";

        public string SatuanSuhu { get; set; }
        public int BatasHariDeman { get; set; }
        public string PesanDitolak { get; set; }
        public string PesanDiterima { get; set; }

        private const string DefaultSatuanSuhu = "celcius";
        private const int DefaultBatasHariDeman = 14;
        private const string DefaultPesanDitolak = "Anda tidak diperbolehkan masuk ke dalam gedung ini";
        private const string DefaultPesanDiterima = "Anda dipersilahkan untuk masuk ke dalam gedung ini";

        public CovidConfig()
        {
            LoadConfig();
        }

        private void LoadConfig()
        {
            if (File.Exists(ConfigFileName))
            {
                string jsonString = File.ReadAllText(ConfigFileName);

                var config = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(jsonString);

                SatuanSuhu = config.ContainsKey("SatuanSuhu") ? config["SatuanSuhu"].GetString() : DefaultSatuanSuhu;
                BatasHariDeman = config.ContainsKey("BatasHariDeman") ? config["BatasHariDeman"].GetInt32() : DefaultBatasHariDeman;
                PesanDitolak = config.ContainsKey("PesanDitolak") ? config["PesanDitolak"].GetString() : DefaultPesanDitolak;
                PesanDiterima = config.ContainsKey("PesanDiterima") ? config["PesanDiterima"].GetString() : DefaultPesanDiterima;
            }
            else
            {
                SatuanSuhu = DefaultSatuanSuhu;
                BatasHariDeman = DefaultBatasHariDeman;
                PesanDitolak = DefaultPesanDitolak;
                PesanDiterima = DefaultPesanDiterima;

                SaveConfig();
            }
        }


        private void SaveConfig()
        {
            var jsonString = JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(ConfigFileName, jsonString);
        }

        public void UbahSatuan()
        {
            if (SatuanSuhu.ToLower() == "celcius")
            {
                SatuanSuhu = "fahrenheit";
            }
            else
            {
                SatuanSuhu = "celcius";
            }
            SaveConfig();
        }
    }
}
