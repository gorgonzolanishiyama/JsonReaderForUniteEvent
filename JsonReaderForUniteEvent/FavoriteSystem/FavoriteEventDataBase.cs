using JsonReaderForUniteEvent.Data;
using JsonReaderForUniteEvent.EventCommandSystem;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonReaderForUniteEvent.FavoriteSystem
{
    internal class FavoriteEventDataBase
    {
 
        FavoriteEventsCommand favoriteEvents = new FavoriteEventsCommand();
        /// <summary>
        /// 保存設定(保存パス)
        /// </summary>
        public string folderPath { set; get; } = string.Empty;
        /// <summary>
        /// 保存設定(保存ファイル名)
        /// </summary>
        string appendFilePath = "FavoritEvent.json";

        /// <summary>
        /// データをロードする。
        /// </summary>
        public void LoadFavoriteEventData()
        {
            try
            {
                favoriteEvents.Clear();
                string[] jsonFiles = Directory.GetFiles(folderPath, "*.json");
                foreach (string jsonFile in jsonFiles)
                {
                    string jsonData = File.ReadAllText(jsonFile);
                    FavoriteEventsCommand? favoriteEventsData = JsonConvert.DeserializeObject<FavoriteEventsCommand>(jsonData);
                    AddData(favoriteEventsData);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading help data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// データを追加してセーブする。
        /// </summary>
        /// <param name="description"></param>
        /// <param name="eventCommand"></param>
        public void SaveHelpForEventCommands(string description, EventCommandData eventCommand)
        {
            try
            {
                favoriteEvents.Add(description, eventCommand);
                string jsonData = JsonConvert.SerializeObject(favoriteEvents);
                using (StreamWriter writer = new StreamWriter(folderPath + "\\" + appendFilePath))
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

        /// <summary>
        /// データ追加
        /// </summary>
        /// <param name="data"></param>
        private void AddData(FavoriteEventsCommand? data)
        {
            if(data != null)
            {
                favoriteEvents.Add(data);
            }
        }
        /// <summary>
        /// データ追加
        /// </summary>
        private void AddData(string desctiption, EventCommandData eventCommand)
        {
            favoriteEvents.Add(desctiption, eventCommand);
        }
        /// <summary>
        /// 説明一覧取得
        /// </summary>
        /// <returns></returns>
        public List<string> GetDescriptions()
        {
            return favoriteEvents.GetDesctiptions();
        }
        /// <summary>
        /// 説明一覧のうち一つ取得
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string GetDescription(int key)
        {
            return favoriteEvents.GetDesctiption(key);
        }
        /// <summary>
        /// イベントのデータを取得
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public EventCommandData? GetEventCommand(int key)
        {
            return favoriteEvents.GetEventCommand(key);
        }
    }
}
