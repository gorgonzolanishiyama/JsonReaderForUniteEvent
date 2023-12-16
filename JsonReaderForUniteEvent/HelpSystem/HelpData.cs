using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonReaderForUniteEvent.HelpSystem
{
    /// <summary>
    /// ヘルプ用のデータ
    /// </summary>
    internal class HelpData
    {
        public List<HelpJsonElement> helpJsonElements { get; set; } = new List<HelpJsonElement>();      
    }
}
