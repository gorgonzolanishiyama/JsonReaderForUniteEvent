using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JsonReaderForUniteEvent.EventCommandSystem;

namespace JsonReaderForUniteEvent.Data
{
    /// <summary>
    /// FacoriteEventの保存データ
    /// </summary>
    class FavoriteEventsCommand
    {
        public List<FavoriteEventCommandElement> eventCommands = new List<FavoriteEventCommandElement>();

        /// <summary>
        /// イベント+説明を追加
        /// </summary>
        /// <param name="desctiption"></param>
        /// <param name="eventCommand"></param>
        public void Add(string desctiption, EventCommandData eventCommand)
        {
            eventCommands.Add( new FavoriteEventCommandElement(desctiption, eventCommand));
        }
        /// <summary>
        /// イベントと説明のセットを追加
        /// </summary>
        /// <param name="eventCommandElement"></param>
        public void Add(FavoriteEventCommandElement eventCommandElement)
        {
            eventCommands.Add(eventCommandElement);
        }
        /// <summary>
        /// このクラスをマージ
        /// </summary>
        /// <param name="eventCommandElements"></param>
        public void Add(FavoriteEventsCommand eventCommandElements)
        {
            foreach (FavoriteEventCommandElement eventCommandElement in eventCommandElements.eventCommands)
            { Add(eventCommandElement); }
        }
        /// <summary>
        /// 説明を出力
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string GetDesctiption(int key) 
        {
            if (eventCommands.Count < key)
            {
                return eventCommands[key].desctiption;
            }
            return "Help text not available.";
        }
        /// <summary>
        /// 説明文リストを出力
        /// </summary>
        /// <returns></returns>
        public List<string> GetDesctiptions()
        {
            return eventCommands.Select(x => x.desctiption).ToList();
        }
        /// <summary>
        /// イベントコマンドを出力
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public EventCommandData? GetEventCommand(int key)
        {
            if (eventCommands.Count > key)
            {
                return eventCommands[key].eventCommand;
            }
            return null;
        }
        /// <summary>
        /// 説明をクリア
        /// </summary>
        public void Clear()
        {
            eventCommands.Clear();
        }

        /// <summary>
        /// クラス内クラス
        /// 説明文とイベントコマンド
        /// </summary>
        public class FavoriteEventCommandElement
        {
            public string desctiption = string.Empty;
            public EventCommandData eventCommand = new EventCommandData();

            public FavoriteEventCommandElement(string desctiption, EventCommandData eventCommand )
            {
                this.desctiption = desctiption;
                this.eventCommand = eventCommand;
            }
        }
    }
}
