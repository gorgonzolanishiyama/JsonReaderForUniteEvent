using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace JsonReaderForUniteEvent.EventCommandSystem
{
    /// <summary>
    /// イベントこのコマンド
    /// </summary>
    public class EventCommandData
    {
        public int code { get; set; }
        public int indent { get; set; }
        public BindingList<string> parameters { get; set; } = new BindingList<string>();
        public BindingList<object> route { get; set; } = new BindingList<object>();

        public void DeepCopy(EventCommandData? eventCommand)
        {
            if (eventCommand == null) return;
            code = eventCommand.code;
            indent = eventCommand.indent;
            parameters.Clear();
            route.Clear();

            foreach (string temp in eventCommand.parameters)
            {
                parameters.Add(temp);
            }
            foreach (string temp in eventCommand.route)
            {
                route.Add(temp);
            }
        }
    }
}
