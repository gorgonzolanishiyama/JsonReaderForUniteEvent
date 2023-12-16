namespace JsonReaderForUniteEvent
{
    partial class UniteJsonEditer
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            EventCommandDataGrid = new DataGridView();
            Edit = new DataGridViewButtonColumn();
            TextBoxID = new TextBox();
            Label_FileName = new Label();
            TextBoxFileName = new TextBox();
            Label_ID = new Label();
            Label_Page = new Label();
            Label_Type = new Label();
            ButtonSave = new Button();
            Button_Load = new Button();
            ButtonInsertEventCommand = new Button();
            ButtonDeleteEventCommand = new Button();
            ButtonInsertByChoiceFavoriteList = new Button();
            ButtonCopy = new Button();
            ButtonPaste = new Button();
            numericUpDownPage = new NumericUpDown();
            numericUpDownType = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)EventCommandDataGrid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownPage).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownType).BeginInit();
            SuspendLayout();
            // 
            // EventCommandDataGrid
            // 
            EventCommandDataGrid.AllowDrop = true;
            EventCommandDataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            EventCommandDataGrid.Columns.AddRange(new DataGridViewColumn[] { Edit });
            EventCommandDataGrid.Location = new Point(30, 127);
            EventCommandDataGrid.Name = "EventCommandDataGrid";
            EventCommandDataGrid.Size = new Size(733, 246);
            EventCommandDataGrid.TabIndex = 1;
            EventCommandDataGrid.CellContentClick += EventCommandDataGrid_CellContentClick;
            EventCommandDataGrid.CellValidating += EventCommandDataGrid_CellValidating;
            EventCommandDataGrid.EditingControlShowing += EventCommandDataGrid_EditingControlShowing;
            EventCommandDataGrid.DragDrop += EventCommandDataGrid_DragDrop;
            EventCommandDataGrid.DragOver += EventCommandDataGrid_DragOver;
            EventCommandDataGrid.MouseDown += EventCommandDataGrid_MouseDown;
            EventCommandDataGrid.MouseMove += EventCommandDataGrid_MouseMove;
            // 
            // Edit
            // 
            Edit.Frozen = true;
            Edit.HeaderText = "EditButton";
            Edit.Name = "Edit";
            Edit.ReadOnly = true;
            Edit.Text = "Edit!";
            // 
            // TextBoxID
            // 
            TextBoxID.Location = new Point(103, 37);
            TextBoxID.Name = "TextBoxID";
            TextBoxID.Size = new Size(74, 23);
            TextBoxID.TabIndex = 2;
            // 
            // Label_FileName
            // 
            Label_FileName.AutoSize = true;
            Label_FileName.Location = new Point(30, 9);
            Label_FileName.Name = "Label_FileName";
            Label_FileName.Size = new Size(56, 15);
            Label_FileName.TabIndex = 0;
            Label_FileName.Text = "FileName";
            // 
            // TextBoxFileName
            // 
            TextBoxFileName.Location = new Point(103, 6);
            TextBoxFileName.Name = "TextBoxFileName";
            TextBoxFileName.Size = new Size(74, 23);
            TextBoxFileName.TabIndex = 5;
            // 
            // Label_ID
            // 
            Label_ID.AutoSize = true;
            Label_ID.Location = new Point(30, 40);
            Label_ID.Name = "Label_ID";
            Label_ID.Size = new Size(18, 15);
            Label_ID.TabIndex = 6;
            Label_ID.Text = "ID";
            // 
            // Label_Page
            // 
            Label_Page.AutoSize = true;
            Label_Page.Location = new Point(30, 69);
            Label_Page.Name = "Label_Page";
            Label_Page.Size = new Size(33, 15);
            Label_Page.TabIndex = 7;
            Label_Page.Text = "Page";
            // 
            // Label_Type
            // 
            Label_Type.AutoSize = true;
            Label_Type.Location = new Point(32, 98);
            Label_Type.Name = "Label_Type";
            Label_Type.Size = new Size(31, 15);
            Label_Type.TabIndex = 8;
            Label_Type.Text = "Type";
            // 
            // ButtonSave
            // 
            ButtonSave.Location = new Point(688, 9);
            ButtonSave.Name = "ButtonSave";
            ButtonSave.Size = new Size(75, 23);
            ButtonSave.TabIndex = 9;
            ButtonSave.Text = "Save";
            ButtonSave.UseVisualStyleBackColor = true;
            ButtonSave.Click += ButtonSave_Click;
            // 
            // Button_Load
            // 
            Button_Load.Location = new Point(688, 36);
            Button_Load.Name = "Button_Load";
            Button_Load.Size = new Size(75, 23);
            Button_Load.TabIndex = 10;
            Button_Load.Text = "Load";
            Button_Load.UseVisualStyleBackColor = true;
            Button_Load.Click += ButtonLoad_Click;
            // 
            // ButtonInsertEventCommand
            // 
            ButtonInsertEventCommand.Location = new Point(32, 379);
            ButtonInsertEventCommand.Name = "ButtonInsertEventCommand";
            ButtonInsertEventCommand.Size = new Size(75, 23);
            ButtonInsertEventCommand.TabIndex = 12;
            ButtonInsertEventCommand.Text = "挿入";
            ButtonInsertEventCommand.UseVisualStyleBackColor = true;
            ButtonInsertEventCommand.Click += ButtonInsertEventCommand_Click;
            // 
            // ButtonDeleteEventCommand
            // 
            ButtonDeleteEventCommand.Location = new Point(127, 379);
            ButtonDeleteEventCommand.Name = "ButtonDeleteEventCommand";
            ButtonDeleteEventCommand.Size = new Size(75, 23);
            ButtonDeleteEventCommand.TabIndex = 13;
            ButtonDeleteEventCommand.Text = "削除";
            ButtonDeleteEventCommand.UseVisualStyleBackColor = true;
            ButtonDeleteEventCommand.Click += ButtonDeleteEventCommand_Click;
            // 
            // ButtonInsertByChoiceFavoriteList
            // 
            ButtonInsertByChoiceFavoriteList.Location = new Point(646, 379);
            ButtonInsertByChoiceFavoriteList.Name = "ButtonInsertByChoiceFavoriteList";
            ButtonInsertByChoiceFavoriteList.Size = new Size(117, 23);
            ButtonInsertByChoiceFavoriteList.TabIndex = 14;
            ButtonInsertByChoiceFavoriteList.Text = "お気に入りから挿入";
            ButtonInsertByChoiceFavoriteList.UseVisualStyleBackColor = true;
            ButtonInsertByChoiceFavoriteList.Click += ButtonInsertByChoiceFavoriteList_Click;
            // 
            // ButtonCopy
            // 
            ButtonCopy.Location = new Point(242, 381);
            ButtonCopy.Name = "ButtonCopy";
            ButtonCopy.Size = new Size(101, 21);
            ButtonCopy.TabIndex = 15;
            ButtonCopy.Text = "選択行をコピー";
            ButtonCopy.UseVisualStyleBackColor = true;
            ButtonCopy.Click += ButtonCopy_Click;
            // 
            // ButtonPaste
            // 
            ButtonPaste.Location = new Point(349, 381);
            ButtonPaste.Name = "ButtonPaste";
            ButtonPaste.Size = new Size(101, 21);
            ButtonPaste.TabIndex = 16;
            ButtonPaste.Text = "コピー行を張り付け";
            ButtonPaste.UseVisualStyleBackColor = true;
            ButtonPaste.Click += ButtonPaste_Click;
            // 
            // numericUpDownPage
            // 
            numericUpDownPage.Location = new Point(103, 66);
            numericUpDownPage.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numericUpDownPage.Name = "numericUpDownPage";
            numericUpDownPage.Size = new Size(82, 23);
            numericUpDownPage.TabIndex = 17;
            // 
            // numericUpDownType
            // 
            numericUpDownType.Location = new Point(103, 96);
            numericUpDownType.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numericUpDownType.Name = "numericUpDownType";
            numericUpDownType.Size = new Size(82, 23);
            numericUpDownType.TabIndex = 18;
            // 
            // UniteJsonEditer
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(numericUpDownType);
            Controls.Add(numericUpDownPage);
            Controls.Add(ButtonPaste);
            Controls.Add(ButtonCopy);
            Controls.Add(ButtonInsertByChoiceFavoriteList);
            Controls.Add(ButtonDeleteEventCommand);
            Controls.Add(ButtonInsertEventCommand);
            Controls.Add(Button_Load);
            Controls.Add(ButtonSave);
            Controls.Add(Label_Type);
            Controls.Add(Label_Page);
            Controls.Add(Label_ID);
            Controls.Add(TextBoxFileName);
            Controls.Add(TextBoxID);
            Controls.Add(EventCommandDataGrid);
            Controls.Add(Label_FileName);
            Name = "UniteJsonEditer";
            Text = "UniteJsonEditer";
            Load += UniteJsonEditer_Load;
            ((System.ComponentModel.ISupportInitialize)EventCommandDataGrid).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownPage).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownType).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DataGridView EventCommandDataGrid;
        private TextBox TextBoxID;
        private Label Label_FileName;
        private TextBox TextBoxFileName;
        private Label Label_ID;
        private Label Label_Page;
        private Label Label_Type;
        private Button ButtonSave;
        private Button Button_Load;
        private DataGridViewButtonColumn Edit;
        private Button ButtonInsertEventCommand;
        private Button ButtonDeleteEventCommand;
        private Button ButtonInsertByChoiceFavoriteList;
        private Button ButtonCopy;
        private Button ButtonPaste;
        private NumericUpDown numericUpDownPage;
        private NumericUpDown numericUpDownType;
    }
}
