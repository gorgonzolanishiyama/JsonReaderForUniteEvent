using JsonReaderForUniteEvent.EventCommandSystem;
using JsonReaderForUniteEvent.HelpSystem;
using Newtonsoft.Json;
using System.Diagnostics.Tracing;
using System.Windows.Forms;
using JsonReaderForUniteEvent.FavoriteSystem;
using JsonReaderForUniteEvent;
using JsonReaderForUniteEvent.EventBaseData;
using System.Data;

namespace JsonReaderForUniteEvent
{
    /// <summary>
    /// メインフォーム
    /// 開始処理
    /// 
    /// セーブ/ロード
    /// イベントコマンドの挿入/削除/お気に入りイベント挿入
    /// 
    /// </summary>

    public partial class UniteJsonEditer : Form
    {
        //コピー用の情報ストック
        EventCommandData eventCommandForCopy = new EventCommandData();
        string fileName = string.Empty;

        public UniteJsonEditer()
        {
            InitializeComponent();
            EventCommandDataGrid.DataSource = EventDataSingleton.GetInstanciate().eventCommands;
        }

        /// <summary>
        /// 起動時にシングルトンを設定する。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UniteJsonEditer_Load(object sender, EventArgs e)
        {
            string path = @"Data\EventHelp";
            HelpForEventCommandsSingleton.GetInstance().folderPath = path;
            HelpForEventCommandsSingleton.GetInstance().LoadHelpForEventCommands(); // ファイル名は適切に変更
            path = @"Data\FavoriteList";
            FavoriteEventCommandBaseSigleton.GetInstance().folderPath = path;
            FavoriteEventCommandBaseSigleton.GetInstance().LoadFavoriteEventData();
        }

        /// <summary>
        /// セーブボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonSave_Click(object sender, EventArgs e)
        {
            // SaveFileDialog を作成
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Json ファイル|*.json";
                saveFileDialog.Title = "ファイルを保存";
                saveFileDialog.FileName = fileName;

                // ダイアログを表示し、OK ボタンが押された場合の処理
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // 選択されたファイルにデータを保存
                    SaveData(saveFileDialog.FileName);
                }
            }
        }
        /// <summary>
        /// ロードボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonLoad_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "JSONファイル (*.json)|*.json";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // ファイルが選択された場合
                        string fileContent = File.ReadAllText(openFileDialog.FileName);
                        EventData? loadEventData = JsonConvert.DeserializeObject<EventData>(fileContent);
                        if (loadEventData != null)
                        {
                            EventDataSingleton.SetInstance(loadEventData);
                            TextBoxFileName.Text = Path.GetFileName(openFileDialog.FileName);
                            UpdateData();
                            fileName = Path.GetFileNameWithoutExtension(openFileDialog.FileName);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error loading file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
        }
        /// <summary>
        /// EventCommandDataGrid内のボタン
        /// ボタンが押されたらエディットをフォームを起動する。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EventCommandDataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int ButtonColumnIndex = 0;
            // クリックされたセルがボタン列であり、かつクリックされたボタンの列インデックスが想定した列であるかを確認
            if (e.ColumnIndex == ButtonColumnIndex && e.RowIndex >= 0)
            {
                int tempIndex = e.RowIndex;
                //最終行なら判定しない
                int currentRowIndex = EventCommandDataGrid.CurrentCell.RowIndex;
                int lastRowIndex = EventCommandDataGrid.RowCount - 1;
                if (currentRowIndex == lastRowIndex)
                {
                    return;
                }

                // クリックされたボタンの処理を行う
                // この例では、行のデータを取得して表示
                //DataGridViewRow selectedRow = EventCommandDataGrid.Rows[e.RowIndex];
                EventCommandForm eventCommandForm = new EventCommandForm(EventDataSingleton.GetInstanciate().eventCommands[tempIndex]);
                if (eventCommandForm.ShowDialog() == DialogResult.OK)
                {
                    //UpdateData();
                }
            }
        }
        private void EventCommandDataGrid_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox? textBox = e.Control as TextBox;
            if (textBox != null)
            {
                // 2列目と3列目に対してのみイベントハンドラを追加
                if (EventCommandDataGrid.CurrentCell.ColumnIndex == 1 || EventCommandDataGrid.CurrentCell.ColumnIndex == 2)
                {
                    textBox.KeyPress += new KeyPressEventHandler(dataGridViewTextBox_KeyPress);
                }
                else
                {
                    // それ以外の列は制限しない
                    textBox.KeyPress -= new KeyPressEventHandler(dataGridViewTextBox_KeyPress);
                }
            }
        }

        private void dataGridViewTextBox_KeyPress(object? sender, KeyPressEventArgs e)
        {
            // 数字以外の入力を許可しない
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// EventCommandDataGridにイベントを挿入する。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonInsertEventCommand_Click(object sender, EventArgs e)
        {
            InsertData(new EventCommandData());
        }

        /// <summary>
        ///  EventCommandDataGridのイベントを削除する。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonDeleteEventCommand_Click(object sender, EventArgs e)
        {
            if (EventCommandDataGrid.SelectedRows.Count > 0)
            {
                if (EventCommandDataGrid.SelectedRows[0].Index < EventDataSingleton.GetInstanciate().eventCommands.Count)
                {
                    EventDataSingleton.GetInstanciate().eventCommands.RemoveAt(
                        EventCommandDataGrid.SelectedRows[0].Index);
                }

            }
        }
        /// <summary>
        /// 選択行コピー
        /// eventCommandForCopyに選択行をディープコピー
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonCopy_Click(object sender, EventArgs e)
        {
            if (EventCommandDataGrid.SelectedRows.Count > 0)
            {
                eventCommandForCopy.DeepCopy(EventDataSingleton.GetInstanciate().eventCommands[EventCommandDataGrid.SelectedRows[0].Index]);
            }
            else
            {
                MessageBox.Show("行が選択されていないのでコピーされませんでした。");
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonPaste_Click(object sender, EventArgs e)
        {
            InsertData(eventCommandForCopy);
        }


        /// <summary>
        /// お気に入りリストから挿入
        /// フォーム起動兼ねる
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonInsertByChoiceFavoriteList_Click(object sender, EventArgs e)
        {
            using (FavoritList favoritListForm = new FavoritList())
            {
                if (favoritListForm.ShowDialog() == DialogResult.OK)
                {
                    int selectedItem = favoritListForm.selectedNumber;
                    EventCommandData eventCommand = new EventCommandData();
                    eventCommand.DeepCopy(FavoriteEventCommandBaseSigleton.GetInstance().GetEventCommand(selectedItem));
                    if (eventCommand == null)
                    {
                        return;
                    }
                    if (EventCommandDataGrid.SelectedRows.Count > 0)
                    {
                        EventDataSingleton.GetInstanciate().eventCommands.Insert(EventCommandDataGrid.SelectedRows[0].Index, eventCommand);
                    }
                    else
                    {
                        EventDataSingleton.GetInstanciate().eventCommands.Add(eventCommand);
                    }
                }
            }
        }
        /// <summary>
        /// EventDataSingletonとデータを同期させる。
        /// </summary>
        private void UpdateData()
        {

            TextBoxID.Text = EventDataSingleton.GetInstanciate().id;
            numericUpDownPage.Value = EventDataSingleton.GetInstanciate().page;
            numericUpDownType.Value = EventDataSingleton.GetInstanciate().type;
            EventCommandDataGrid.DataSource = null;
            EventCommandDataGrid.DataSource = EventDataSingleton.GetInstanciate().eventCommands;


        }

        /// <summary>
        /// セーブを行う。
        /// </summary>
        /// <param name="filePath"> </param>
        private void SaveData(string filePath)
        {
            try
            {
                EventDataSingleton.GetInstanciate().id = TextBoxID.Text;
                EventDataSingleton.GetInstanciate().page = decimal.ToInt32(numericUpDownPage.Value);
                EventDataSingleton.GetInstanciate().type = decimal.ToInt32(numericUpDownType.Value);

                string jsonData = JsonConvert.SerializeObject(EventDataSingleton.GetInstanciate());
                File.WriteAllText(filePath, jsonData);
                MessageBox.Show("データが保存されました。", "情報", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"保存中にエラーが発生しました。\n\n{ex.Message}", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// EventDataを挿入する。
        /// </summary>
        /// <param name="eventCommand"></param>
        private void InsertData(EventCommandData eventCommand)
        {
            if (EventCommandDataGrid.SelectedRows.Count > 0)
            {
                EventDataSingleton.GetInstanciate().eventCommands.Insert(
                    EventCommandDataGrid.SelectedRows[0].Index,
                    eventCommand
                    );
            }
            if (EventCommandDataGrid.SelectedRows.Count == 0)
            {
                EventDataSingleton.GetInstanciate().eventCommands.Add(eventCommand);
            }
            EventCommandDataGrid.DataSource = null;
            EventCommandDataGrid.DataSource = EventDataSingleton.GetInstanciate().eventCommands;
            EventCommandDataGrid.Invalidate();
        }

        ///
        /// ドラッグによる入れ替え機能の追加
        ///
        ///  hamalab.net様を参考にさせていただきました。
        private Rectangle dragBoxFromMouseDown;      // 座標用
        private int rowIndexFromMouseDown;           // 移動元Index用
        private int rowIndexOfItemUnderMouseToDrop; // 移動先Index用

        private void EventCommandDataGrid_MouseMove(object sender, MouseEventArgs e)
        {
            // 左クリックの場合
            if (e.Button == MouseButtons.Left)
            {
                if (dragBoxFromMouseDown != Rectangle.Empty && !(dragBoxFromMouseDown.Contains(e.X, e.Y)))
                {
                    DragDropEffects dropEffect = EventCommandDataGrid.DoDragDrop(EventCommandDataGrid.Rows[rowIndexFromMouseDown], DragDropEffects.Move);
                }
            }
        }

        private void EventCommandDataGrid_MouseDown(object sender, MouseEventArgs e)
        {
            rowIndexFromMouseDown = EventCommandDataGrid.HitTest(e.X, e.Y).RowIndex;

            // ヘッダー以外
            if (rowIndexFromMouseDown > -1)
            {
                var dragSize = SystemInformation.DragSize;
                // ドラッグ操作が開始されない範囲を取得
                dragBoxFromMouseDown = new Rectangle(new Point(e.X - dragSize.Width / 2, e.Y - dragSize.Height / 2), dragSize);
            }
            else
            {
                dragBoxFromMouseDown = Rectangle.Empty;
            }
        }

        private void EventCommandDataGrid_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void EventCommandDataGrid_DragDrop(object sender, DragEventArgs e)
        {
            // データグリッドのポイントを取得
            Point clientPoint = EventCommandDataGrid.PointToClient(new Point(e.X, e.Y));
            // 移動先INDEX
            rowIndexOfItemUnderMouseToDrop = EventCommandDataGrid.HitTest(clientPoint.X, clientPoint.Y).RowIndex;

            // ドラッグ＆ドロップ効果【移動】の場合・INDEX範囲内の場合
            if (e.Effect == DragDropEffects.Move &&
               rowIndexOfItemUnderMouseToDrop > -1)
            {
                ///参考サイトと異なりDatasource変更で対応する。
                var temp = EventDataSingleton.GetInstanciate().eventCommands[rowIndexFromMouseDown];
                EventDataSingleton.GetInstanciate().eventCommands.RemoveAt(rowIndexFromMouseDown);
                EventDataSingleton.GetInstanciate().eventCommands.Insert(rowIndexOfItemUnderMouseToDrop, temp);
            }
        }

        private void EventCommandDataGrid_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == 1 || e.ColumnIndex == 2) // 二列目と三列目
            {
                DataGridViewCell cell = EventCommandDataGrid[e.ColumnIndex, e.RowIndex];
                if (e.FormattedValue == null)
                {
                    return;
                }
                string proposedValue = e.FormattedValue.ToString();

                // 数値に変換できるか確認
                if (!int.TryParse(proposedValue, out int value))
                {
                    e.Cancel = true;
                    MessageBox.Show("数値を入力してください。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // 最小値と最大値を設定
                int minValue = 0; // 最小値
                int maxValue = 10000; // 最大値

                // 範囲外の場合はキャンセル
                if (value < minValue || value > maxValue)
                {
                    e.Cancel = true;
                    MessageBox.Show($"値は {minValue} から {maxValue} の範囲で入力してください。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
