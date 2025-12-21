using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    internal class ConfigManager
    {
        public static AppConfig? Current { get; private set; }

        public static void Load()
        {
            if (!System.IO.File.Exists("appconfig.json"))
            {
                Current = new AppConfig(); 
                return;
            }
            var json = System.IO.File.ReadAllText("appconfig.json");
            Current = System.Text.Json.JsonSerializer.Deserialize<AppConfig>(json) ?? new AppConfig();
        }

        public static void Save()
        {
            var json = System.Text.Json.JsonSerializer.Serialize(Current, new System.Text.Json.JsonSerializerOptions { WriteIndented = true });
            System.IO.File.WriteAllText("appconfig.json", json);
        }
    }
}
