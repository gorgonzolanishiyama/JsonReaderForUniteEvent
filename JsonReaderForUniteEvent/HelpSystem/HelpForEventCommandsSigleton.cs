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
        private static HelpForEventCommandsBase instance ;
        private static readonly object lockObject = new object();

        private HelpForEventCommandsSingleton() { }
        public static HelpForEventCommandsBase GetInstance()
        {
            // インスタンスがまだ作成されていない場合、ロック内で作成する
            if (instance == null)
            {
                lock (lockObject)
                {
                    // ロック内で再度チェックして二重作成を防ぐ
                    if (instance == null)
                    {
                        instance = new HelpForEventCommandsBase();
                    }
                }
            }
            return instance;
        }
    }

}
