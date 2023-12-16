using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonReaderForUniteEvent.EventBaseData
{
    /// <summary>
    /// イベントデータを保存するシングルトン
    /// </summary>
    internal class EventDataSingleton
    {
        private static EventData? baseData;
        private static readonly object lockObject = new object();

        private EventDataSingleton() { }

        public static EventData GetInstanciate()
        {
            lock (lockObject)
            {
                if (baseData != null)
                {
                    return baseData;
                }
                else
                {
                    baseData = new EventData();
                    return baseData;
                }
            }
        }
        public static void SetInstance(EventData data)
        {
            baseData = data;
        }
    }
}
