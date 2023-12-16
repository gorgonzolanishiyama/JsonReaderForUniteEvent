using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JsonReaderForUniteEvent.FavoriteSystem
{
    /// <summary>
    /// お気に入りを説明文からイベントを選択するフォーム
    /// </summary>
    public partial class FavoritList : Form
    {
        /// <summary>
        /// 選択行出力変数
        /// </summary>
        public int selectedNumber { get; set; } = 0;

        public FavoritList()
        {
            InitializeComponent();
            this.AcceptButton = ButtonInsert;
        }

        private void FavoritList_Load(object sender, EventArgs e)
        {
            ListBoxFavorit.DataSource = FavoriteEventCommandBaseSigleton.GetInstance().GetDescriptions();
        }

        private void ListBoxFavorit_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedNumber = ListBoxFavorit.SelectedIndex;
        }

        private void ButtonInsert_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
