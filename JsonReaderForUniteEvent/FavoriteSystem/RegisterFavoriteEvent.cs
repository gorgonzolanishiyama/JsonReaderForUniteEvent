using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using JsonReaderForUniteEvent.EventCommandSystem;

namespace JsonReaderForUniteEvent.FavoriteSystem
{
    /// <summary>
    /// お気に入り登録用フォーム
    /// </summary>
    public partial class RegisterFavoriteEvent : Form
    {
        /// <summary>
        /// お気に入り入力用のイベント
        /// </summary>
        EventCommandData eventCommand = new EventCommandData();
        public RegisterFavoriteEvent()
        {
            InitializeComponent();
        }

        private void RegisterFavoriteEvent_Load(object sender, EventArgs e)
        {
            this.AcceptButton = ButtonRegister;
        }
        /// <summary>
        /// お気に入り保存
        /// </summary>
        /// <param name="eventCommand"></param>
        public void SetData(EventCommandData eventCommand)
        {
            this.eventCommand = eventCommand;
        }
        /// <summary>
        /// 現在のイベントをお気に入りに保存する。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonRegister_Click(object sender, EventArgs e)
        {
            ///無効な内容であれば反応しない。
            if (TextDescription.Text == string.Empty || TextDescription.Text == "概要")
            {
                return;
            }
            FavoriteEventCommandBaseSigleton.GetInstance().SaveHelpForEventCommands(TextDescription.Text, eventCommand);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
