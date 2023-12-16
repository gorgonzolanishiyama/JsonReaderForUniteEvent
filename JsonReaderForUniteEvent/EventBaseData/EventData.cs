using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JsonReaderForUniteEvent.EventCommandSystem;

namespace JsonReaderForUniteEvent.EventBaseData
{
    /// <summary>
    /// イベントjsonのデータ
    /// </summary>
    public class EventData
    {
        public BindingList<EventCommandData> eventCommands { get; set; } = new BindingList<EventCommandData>();
        public string id { get; set; } = "";
        public int page { get; set; } = 0;
        public int type { get; set; } = 0;
    }
}
