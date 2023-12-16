using JsonReaderForUniteEvent.EventBaseData;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonReaderForUniteEvent.HelpSystem
{
    /// <summary>
    /// ヘルプデータの保存用シングルトン
    /// </summary>
    internal class HelpForEventCommandsSingleton
    {
        private static HelpForEventCommandsSingleton instance = new HelpForEventCommandsSingleton();
        private static readonly object lockObject = new object();

        static Dictionary<int, string> helpCommand = new Dictionary<int,string>();
        public static string folderPath { set; get; } = string.Empty;
        public static string defaultFilePath { set; get; } = "EventHelpDefault.json";
        static string appendFilePath = "EventHelp.json";

        public static void LoadHelpForEventCommands()
        {
            try
            {
                helpCommand.Clear();
                string[] jsonFiles = Directory.GetFiles(folderPath, "*.json");
                foreach (string jsonFile in jsonFiles)
                {
                    string jsonData = File.ReadAllText(jsonFile);
                    HelpData? helpData = JsonConvert.DeserializeObject<HelpData>(jsonData);
                    AddData(helpData);

                }

                // JSONデータをオブジェクトにデシリアライズ

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading help data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public static void SaveHelpForEventCommands( int code, string helpText)
        {
            try
            {
                helpCommand[code] = helpText;
                HelpData helpData = MakeHelpData();
                string jsonData = JsonConvert.SerializeObject(helpData);
                using (StreamWriter writer = new StreamWriter(folderPath+"\\"+ appendFilePath))
                {
                    writer.Write(jsonData);
                }
                MessageBox.Show("データが保存されました。", "情報", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"保存中にエラーが発生しました。\n\n{ex.Message}", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private HelpForEventCommandsSingleton() { }
        public static HelpForEventCommandsSingleton GetInstance()
        {
            if (instance == null)
            {
                instance = new HelpForEventCommandsSingleton();
            }
            return instance;
        }

        public static void AddData( HelpData? data)
        {
            if(data == null)
            {
                return;
            }
            lock (lockObject)
            {
                foreach (HelpJsonElement temp in data.helpJsonElements)
                {
                    helpCommand[temp.code] = temp.helpText;
                }
            }
        }
        public static string GetData(int code)
        {
            lock (lockObject)
            {
                if (helpCommand.TryGetValue(code, out var helpText))
                {
                    return helpText;
                }
                return "Help text not available.";
            }
        }
        private static HelpData MakeHelpData()
        {
            HelpData helpData = new HelpData();
            foreach( int helpCode in helpCommand.Keys  )
            {
                HelpJsonElement helpJsonElement = new HelpJsonElement();
                helpJsonElement.code = helpCode;
                helpJsonElement.helpText = helpCommand[helpCode];
                helpData.helpJsonElements.Add( helpJsonElement );
            }

            return helpData ;
        }
    }

}
