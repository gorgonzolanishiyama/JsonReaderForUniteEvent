using JsonReaderForUniteEvent.Data;
using JsonReaderForUniteEvent.EventCommandSystem;
using JsonReaderForUniteEvent.HelpSystem;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static JsonReaderForUniteEvent.Data.FavoriteEventsCommand;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace JsonReaderForUniteEvent.FavoriteSystem
{
    /// <summary>
    /// お気に入りイベントのデータベース
    /// </summary>
    internal class FavoriteEventCommandBaseSigleton
    {
        private static FavoriteEventDataBase instance = new FavoriteEventDataBase();
        private static readonly object lockObject = new object();

        public static FavoriteEventDataBase GetInstance()
        {
            if (instance == null)
            {
                instance = new FavoriteEventDataBase();
            }
            return instance;
        }
    }
}
