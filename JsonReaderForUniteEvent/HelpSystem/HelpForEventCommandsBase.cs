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
    internal class HelpForEventCommandsBase
    {

        Dictionary<int, string> helpCommand = new Dictionary<int,string>();
        public string folderPath { set; get; } = string.Empty;
        public string defaultFileName { set; get; } = "EventHelpDefault.json";
        string appendFileName = "EventHelp.json";

        public void LoadHelpForEventCommands()
        {
            try
            {
                helpCommand.Clear();

                string jsonData = File.ReadAllText( folderPath + "\\" + defaultFileName);
                HelpData? helpData = JsonConvert.DeserializeObject<HelpData>(jsonData);
                AddData(helpData);

                string[] jsonFiles = Directory.GetFiles(folderPath, "*.json");

                foreach (string jsonFile in jsonFiles)
                {
                    if(jsonFile == defaultFileName)
                    {
                        return;
                    }
                    jsonData = File.ReadAllText(jsonFile);
                    helpData = JsonConvert.DeserializeObject<HelpData>(jsonData);
                    AddData(helpData);
                }

                // JSONデータをオブジェクトにデシリアライズ

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading help data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void SaveHelpForEventCommands( int code, string helpText)
        {
            try
            {
                helpCommand[code] = helpText;
                HelpData helpData = MakeHelpData();
                string jsonData = JsonConvert.SerializeObject(helpData);
                using (StreamWriter writer = new StreamWriter(folderPath+"\\"+ appendFileName))
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

        public void AddData( HelpData? data)
        {
            if(data == null)
            {
                return;
            }
            foreach (HelpJsonElement temp in data.helpJsonElements)
            {
                helpCommand[temp.code] = temp.helpText;
            }
        }
        public string GetData(int code)
        {
            if (helpCommand.TryGetValue(code, out var helpText))
            {
                return helpText;
            }
            return "Help text not available.";
        }
        private HelpData MakeHelpData()
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
