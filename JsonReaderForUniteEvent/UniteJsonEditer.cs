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
    /// ���C���t�H�[��
    /// �J�n����
    /// 
    /// �Z�[�u/���[�h
    /// �C�x���g�R�}���h�̑}��/�폜/���C�ɓ���C�x���g�}��
    /// 
    /// </summary>

    public partial class UniteJsonEditer : Form
    {
        //�R�s�[�p�̏��X�g�b�N
        EventCommandData eventCommandForCopy = new EventCommandData();
        string fileName = string.Empty;

        public UniteJsonEditer()
        {
            InitializeComponent();
            EventCommandDataGrid.DataSource = EventDataSingleton.GetInstanciate().eventCommands;
        }

        /// <summary>
        /// �N�����ɃV���O���g����ݒ肷��B
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UniteJsonEditer_Load(object sender, EventArgs e)
        {
            string path = @"Data\EventHelp";
            HelpForEventCommandsSingleton.GetInstance().folderPath = path;
            HelpForEventCommandsSingleton.GetInstance().LoadHelpForEventCommands(); // �t�@�C�����͓K�؂ɕύX
            path = @"Data\FavoriteList";
            FavoriteEventCommandBaseSigleton.GetInstance().folderPath = path;
            FavoriteEventCommandBaseSigleton.GetInstance().LoadFavoriteEventData();
        }

        /// <summary>
        /// �Z�[�u�{�^��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonSave_Click(object sender, EventArgs e)
        {
            // SaveFileDialog ���쐬
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Json �t�@�C��|*.json";
                saveFileDialog.Title = "�t�@�C����ۑ�";
                saveFileDialog.FileName = fileName;

                // �_�C�A���O��\�����AOK �{�^���������ꂽ�ꍇ�̏���
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // �I�����ꂽ�t�@�C���Ƀf�[�^��ۑ�
                    SaveData(saveFileDialog.FileName);
                }
            }
        }
        /// <summary>
        /// ���[�h�{�^��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonLoad_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "JSON�t�@�C�� (*.json)|*.json";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // �t�@�C�����I�����ꂽ�ꍇ
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
        /// EventCommandDataGrid���̃{�^��
        /// �{�^���������ꂽ��G�f�B�b�g���t�H�[�����N������B
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EventCommandDataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int ButtonColumnIndex = 0;
            // �N���b�N���ꂽ�Z�����{�^����ł���A���N���b�N���ꂽ�{�^���̗�C���f�b�N�X���z�肵����ł��邩���m�F
            if (e.ColumnIndex == ButtonColumnIndex && e.RowIndex >= 0)
            {
                int tempIndex = e.RowIndex;
                //�ŏI�s�Ȃ画�肵�Ȃ�
                int currentRowIndex = EventCommandDataGrid.CurrentCell.RowIndex;
                int lastRowIndex = EventCommandDataGrid.RowCount - 1;
                if (currentRowIndex == lastRowIndex)
                {
                    return;
                }

                // �N���b�N���ꂽ�{�^���̏������s��
                // ���̗�ł́A�s�̃f�[�^���擾���ĕ\��
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
                // 2��ڂ�3��ڂɑ΂��Ă̂݃C�x���g�n���h����ǉ�
                if (EventCommandDataGrid.CurrentCell.ColumnIndex == 1 || EventCommandDataGrid.CurrentCell.ColumnIndex == 2)
                {
                    textBox.KeyPress += new KeyPressEventHandler(dataGridViewTextBox_KeyPress);
                }
                else
                {
                    // ����ȊO�̗�͐������Ȃ�
                    textBox.KeyPress -= new KeyPressEventHandler(dataGridViewTextBox_KeyPress);
                }
            }
        }

        private void dataGridViewTextBox_KeyPress(object? sender, KeyPressEventArgs e)
        {
            // �����ȊO�̓��͂������Ȃ�
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// EventCommandDataGrid�ɃC�x���g��}������B
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonInsertEventCommand_Click(object sender, EventArgs e)
        {
            InsertData(new EventCommandData());
        }

        /// <summary>
        ///  EventCommandDataGrid�̃C�x���g���폜����B
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
        /// �I���s�R�s�[
        /// eventCommandForCopy�ɑI���s���f�B�[�v�R�s�[
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
                MessageBox.Show("�s���I������Ă��Ȃ��̂ŃR�s�[����܂���ł����B");
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
        /// ���C�ɓ��胊�X�g����}��
        /// �t�H�[���N�����˂�
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
        /// EventDataSingleton�ƃf�[�^�𓯊�������B
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
        /// �Z�[�u���s���B
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
                MessageBox.Show("�f�[�^���ۑ�����܂����B", "���", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"�ۑ����ɃG���[���������܂����B\n\n{ex.Message}", "�G���[", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// EventData��}������B
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
        /// �h���b�O�ɂ�����ւ��@�\�̒ǉ�
        ///
        ///  hamalab.net�l���Q�l�ɂ����Ă��������܂����B
        private Rectangle dragBoxFromMouseDown;      // ���W�p
        private int rowIndexFromMouseDown;           // �ړ���Index�p
        private int rowIndexOfItemUnderMouseToDrop; // �ړ���Index�p

        private void EventCommandDataGrid_MouseMove(object sender, MouseEventArgs e)
        {
            // ���N���b�N�̏ꍇ
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

            // �w�b�_�[�ȊO
            if (rowIndexFromMouseDown > -1)
            {
                var dragSize = SystemInformation.DragSize;
                // �h���b�O���삪�J�n����Ȃ��͈͂��擾
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
            // �f�[�^�O���b�h�̃|�C���g���擾
            Point clientPoint = EventCommandDataGrid.PointToClient(new Point(e.X, e.Y));
            // �ړ���INDEX
            rowIndexOfItemUnderMouseToDrop = EventCommandDataGrid.HitTest(clientPoint.X, clientPoint.Y).RowIndex;

            // �h���b�O���h���b�v���ʁy�ړ��z�̏ꍇ�EINDEX�͈͓��̏ꍇ
            if (e.Effect == DragDropEffects.Move &&
               rowIndexOfItemUnderMouseToDrop > -1)
            {
                ///�Q�l�T�C�g�ƈقȂ�Datasource�ύX�őΉ�����B
                var temp = EventDataSingleton.GetInstanciate().eventCommands[rowIndexFromMouseDown];
                EventDataSingleton.GetInstanciate().eventCommands.RemoveAt(rowIndexFromMouseDown);
                EventDataSingleton.GetInstanciate().eventCommands.Insert(rowIndexOfItemUnderMouseToDrop, temp);
            }
        }

        private void EventCommandDataGrid_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == 1 || e.ColumnIndex == 2) // ���ڂƎO���
            {
                DataGridViewCell cell = EventCommandDataGrid[e.ColumnIndex, e.RowIndex];
                if (e.FormattedValue == null)
                {
                    return;
                }
                string proposedValue = e.FormattedValue.ToString();

                // ���l�ɕϊ��ł��邩�m�F
                if (!int.TryParse(proposedValue, out int value))
                {
                    e.Cancel = true;
                    MessageBox.Show("���l����͂��Ă��������B", "�G���[", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // �ŏ��l�ƍő�l��ݒ�
                int minValue = 0; // �ŏ��l
                int maxValue = 10000; // �ő�l

                // �͈͊O�̏ꍇ�̓L�����Z��
                if (value < minValue || value > maxValue)
                {
                    e.Cancel = true;
                    MessageBox.Show($"�l�� {minValue} ���� {maxValue} �͈̔͂œ��͂��Ă��������B", "�G���[", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
