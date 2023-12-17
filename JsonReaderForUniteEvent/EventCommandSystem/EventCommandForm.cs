using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using JsonReaderForUniteEvent.FavoriteSystem;
using JsonReaderForUniteEvent.HelpSystem;

namespace JsonReaderForUniteEvent.EventCommandSystem
{
    /// <summary>
    /// イベントの各コマンドごとのフォーム
    /// イベントデータ
    /// 　イベントファイル名
    /// 　イベントページ
    /// ☆イベントコマンド[]←イマココ！
    /// 　
    /// </summary>
    public partial class EventCommandForm : Form
    {
        /// <summary>
        /// イベントの入出力クラス
        /// </summary>
        EventCommandData Base;

        /// <summary>
        /// 現状操作しているコマンドデータ
        /// </summary>
        EventCommandData eventCommandTemp { get; } = new EventCommandData();

        public EventCommandForm(EventCommandData eventCommand)
        {
            InitializeComponent();
            Base = eventCommand;
            eventCommandTemp.DeepCopy(eventCommand);


            //コードとインデント
            numericUpDownCode.Value = eventCommandTemp.code;
            numericUpDownIndent.Value = eventCommandTemp.indent;

            // ParameterDataGridの設定
            DataGridViewTextBoxColumn columnParamter = new DataGridViewTextBoxColumn();
            columnParamter.HeaderText = "String"; // 列のヘッダーテキスト
            columnParamter.DataPropertyName = "String"; // データソースのプロパティ名（不要なので空文字列）
            columnParamter.Name = "String";
            columnParamter.Width = 500;

            // 列を追加
            ParameterDataGrid.Columns.Add(columnParamter);

            // RouteDataGridの設定
            DataGridViewTextBoxColumn columnRoute = new DataGridViewTextBoxColumn();
            columnRoute.HeaderText = "String"; // 列のヘッダーテキスト
            columnRoute.DataPropertyName = "String"; // データソースのプロパティ名（不要なので空文字列）
            columnRoute.Name = "String";
            columnRoute.Width = 500;
            // 列を追加
            RouteDataGrid.Columns.Add(columnRoute);

            //Helpの設定
            helpText.Text = HelpForEventCommandsSingleton.GetInstance().GetData(eventCommand.code);

            //画面更新
            RefreshGrid();
            
        }

        private void EventCommandForm_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 何もせずに閉じる
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 変更を承認して閉じる
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonOK_Click(object sender, EventArgs e)
        {
            MakeTempData();
            Base.DeepCopy(eventCommandTemp);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        /// <summary>
        /// 画面を更新する
        /// </summary>
        private void RefreshGrid()
        {
            //挿入削除的に変化も？
            ParameterDataGrid.Rows.Clear();
            for (int i = 0; i < eventCommandTemp.parameters.Count; i++)
            {
                DataGridViewRow rowParamter = new DataGridViewRow();
                ParameterDataGrid.Rows.Add(rowParamter);

                if (eventCommandTemp.parameters[i] != null)
                {
                    ParameterDataGrid.Rows[i].Cells["String"].Value = eventCommandTemp.parameters[i];
                }
                else
                {
                    ParameterDataGrid.Rows[i].Cells["String"].Value = string.Empty;
                }
            }

            RouteDataGrid.Rows.Clear();
            for (int i = 0; i < eventCommandTemp.route.Count; i++)
            {
                DataGridViewRow rowParamter = new DataGridViewRow();
                RouteDataGrid.Rows.Add(rowParamter);

                if (eventCommandTemp.route[i] != null)
                {
                    RouteDataGrid.Rows[i].Cells["String"].Value = eventCommandTemp.route[i];
                }
                else
                {
                    RouteDataGrid.Rows[i].Cells["String"].Value = string.Empty;
                }
            }
        }

        /// <summary>
        /// パタメータDataGridに行挿入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonParameterInsert_Click(object sender, EventArgs e)
        {
            if (eventCommandTemp.parameters.Count == 0)
            {
                eventCommandTemp.parameters.Add("");

            }
            else if (ParameterDataGrid.SelectedRows.Count > 0)
            {
                eventCommandTemp.parameters.Insert(
                    ParameterDataGrid.SelectedRows[0].Index,
                    string.Empty
                    );
            }
            RefreshGrid();
        }

        /// <summary>
        /// パラメータDataGridから行削除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonParameterDelete_Click(object sender, EventArgs e)
        {
            if (ParameterDataGrid.SelectedRows.Count > 0 && ParameterDataGrid.SelectedRows[0] != null)
            {
                int selectedIndex = ParameterDataGrid.SelectedRows[0].Index;
                if (selectedIndex >= 0 && selectedIndex < eventCommandTemp.parameters.Count)
                {
                    eventCommandTemp.parameters.RemoveAt(selectedIndex);
                    RefreshGrid();
                }
            }
        }

        /// <summary>
        /// RouteDataGridに行挿入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonRouteInsert_Click(object sender, EventArgs e)
        {
            if (eventCommandTemp.route.Count == 0)
            {
                eventCommandTemp.route.Add("");
            }
            else if (RouteDataGrid.SelectedRows.Count > 0)
            {
                eventCommandTemp.route.Insert(
                    RouteDataGrid.SelectedRows[0].Index,
                    string.Empty
                    );
            }
            RefreshGrid();
        }

        /// <summary>
        /// RouteDataGridから行削除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonRouteDelete_Click(object sender, EventArgs e)
        {
            if (RouteDataGrid.SelectedRows.Count > 0 && RouteDataGrid.SelectedRows[0] != null)
            {
                int selectedIndex = RouteDataGrid.SelectedRows[0].Index;
                if (selectedIndex >= 0 && selectedIndex < eventCommandTemp.route.Count)
                {
                    eventCommandTemp.route.RemoveAt(selectedIndex);
                    RefreshGrid();
                }
            }
        }

        /// <summary>
        /// Helpファイルを更新する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonHelpFileUpdate_Click(object sender, EventArgs e)
        {
            HelpForEventCommandsSingleton.GetInstance().SaveHelpForEventCommands(eventCommandTemp.code, helpText.Text);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonRegisterFavoritList_Click(object sender, EventArgs e)
        {
            MakeTempData();
            RegisterFavoriteEvent registerFavoritList = new RegisterFavoriteEvent();
            registerFavoritList.SetData(eventCommandTemp);
            registerFavoritList.ShowDialog();
        }

        /// <summary>
        /// eventCommandTempを現在の表示に合わせて更新する。
        /// </summary>
        private void MakeTempData()
        {
            eventCommandTemp.code = decimal.ToInt32(numericUpDownCode.Value);
            eventCommandTemp.indent = decimal.ToInt32(numericUpDownIndent.Value);
            eventCommandTemp.parameters.Clear();
            eventCommandTemp.route.Clear();

            for (int i = 0; i < ParameterDataGrid.Rows.Count - 1; i++)
            {
                object cellValue = ParameterDataGrid.Rows[i].Cells["String"].Value;
                string? stringVaue = cellValue != null ? cellValue.ToString() : string.Empty;
                eventCommandTemp.parameters.Add(stringVaue!=null ?stringVaue:"null");
            }
            for (int i = 0; i < RouteDataGrid.Rows.Count - 1; i++)
            {
                object cellValue = RouteDataGrid.Rows[i].Cells["String"].Value;
                string? stringVaue = cellValue != null ? cellValue.ToString() : string.Empty;
                eventCommandTemp.route.Add(stringVaue != null ? stringVaue : "null");
            }
        }
    }
}
