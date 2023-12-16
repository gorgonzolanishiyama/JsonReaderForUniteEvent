namespace JsonReaderForUniteEvent.EventCommandSystem
{
    partial class EventCommandForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Label_Code = new Label();
            Label_Indent = new Label();
            ParameterDataGrid = new DataGridView();
            RouteDataGrid = new DataGridView();
            helpText = new RichTextBox();
            ButtonOK = new Button();
            ButtonCancel = new Button();
            ButtonHelpFileUpdate = new Button();
            Label＿Parameter = new Label();
            Label_Route = new Label();
            ButtonParameterInsert = new Button();
            ButtonParameterDelete = new Button();
            ButtonRouteInsert = new Button();
            ButtonRouteDelete = new Button();
            ButtonRegisterFavoritList = new Button();
            numericUpDownCode = new NumericUpDown();
            numericUpDownIndent = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)ParameterDataGrid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)RouteDataGrid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownCode).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownIndent).BeginInit();
            SuspendLayout();
            // 
            // Label_Code
            // 
            Label_Code.AutoSize = true;
            Label_Code.Location = new Point(12, 9);
            Label_Code.Name = "Label_Code";
            Label_Code.Size = new Size(34, 15);
            Label_Code.TabIndex = 0;
            Label_Code.Text = "Code";
            // 
            // Label_Indent
            // 
            Label_Indent.AutoSize = true;
            Label_Indent.Location = new Point(12, 42);
            Label_Indent.Name = "Label_Indent";
            Label_Indent.Size = new Size(41, 15);
            Label_Indent.TabIndex = 1;
            Label_Indent.Text = "Indent";
            // 
            // ParameterDataGrid
            // 
            ParameterDataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            ParameterDataGrid.Location = new Point(78, 97);
            ParameterDataGrid.Name = "ParameterDataGrid";
            ParameterDataGrid.Size = new Size(572, 113);
            ParameterDataGrid.TabIndex = 4;
            // 
            // RouteDataGrid
            // 
            RouteDataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            RouteDataGrid.Location = new Point(74, 236);
            RouteDataGrid.Name = "RouteDataGrid";
            RouteDataGrid.Size = new Size(576, 117);
            RouteDataGrid.TabIndex = 5;
            // 
            // helpText
            // 
            helpText.Location = new Point(31, 364);
            helpText.Name = "helpText";
            helpText.Size = new Size(619, 61);
            helpText.TabIndex = 7;
            helpText.Text = "";
            // 
            // ButtonOK
            // 
            ButtonOK.Location = new Point(713, 8);
            ButtonOK.Name = "ButtonOK";
            ButtonOK.Size = new Size(75, 23);
            ButtonOK.TabIndex = 8;
            ButtonOK.Text = "OK";
            ButtonOK.UseVisualStyleBackColor = true;
            ButtonOK.Click += ButtonOK_Click;
            // 
            // ButtonCancel
            // 
            ButtonCancel.Location = new Point(713, 42);
            ButtonCancel.Name = "ButtonCancel";
            ButtonCancel.Size = new Size(75, 23);
            ButtonCancel.TabIndex = 9;
            ButtonCancel.Text = "Cancel";
            ButtonCancel.UseVisualStyleBackColor = true;
            ButtonCancel.Click += ButtonCancel_Click;
            // 
            // ButtonHelpFileUpdate
            // 
            ButtonHelpFileUpdate.Location = new Point(668, 402);
            ButtonHelpFileUpdate.Name = "ButtonHelpFileUpdate";
            ButtonHelpFileUpdate.Size = new Size(130, 23);
            ButtonHelpFileUpdate.TabIndex = 10;
            ButtonHelpFileUpdate.Text = "ヘルプファイルに反映";
            ButtonHelpFileUpdate.UseVisualStyleBackColor = true;
            ButtonHelpFileUpdate.Click += ButtonHelpFileUpdate_Click;
            // 
            // Label＿Parameter
            // 
            Label＿Parameter.AutoSize = true;
            Label＿Parameter.Location = new Point(12, 84);
            Label＿Parameter.Name = "Label＿Parameter";
            Label＿Parameter.Size = new Size(60, 15);
            Label＿Parameter.TabIndex = 11;
            Label＿Parameter.Text = "Parameter";
            // 
            // Label_Route
            // 
            Label_Route.AutoSize = true;
            Label_Route.Location = new Point(15, 236);
            Label_Route.Name = "Label_Route";
            Label_Route.Size = new Size(38, 15);
            Label_Route.TabIndex = 12;
            Label_Route.Text = "Route";
            // 
            // ButtonParameterInsert
            // 
            ButtonParameterInsert.Location = new Point(658, 97);
            ButtonParameterInsert.Name = "ButtonParameterInsert";
            ButtonParameterInsert.Size = new Size(75, 23);
            ButtonParameterInsert.TabIndex = 13;
            ButtonParameterInsert.Text = "挿入";
            ButtonParameterInsert.UseVisualStyleBackColor = true;
            ButtonParameterInsert.Click += ButtonParameterInsert_Click;
            // 
            // ButtonParameterDelete
            // 
            ButtonParameterDelete.Location = new Point(658, 126);
            ButtonParameterDelete.Name = "ButtonParameterDelete";
            ButtonParameterDelete.Size = new Size(75, 23);
            ButtonParameterDelete.TabIndex = 14;
            ButtonParameterDelete.Text = "削除";
            ButtonParameterDelete.UseVisualStyleBackColor = true;
            ButtonParameterDelete.Click += ButtonParameterDelete_Click;
            // 
            // ButtonRouteInsert
            // 
            ButtonRouteInsert.Location = new Point(658, 228);
            ButtonRouteInsert.Name = "ButtonRouteInsert";
            ButtonRouteInsert.Size = new Size(75, 23);
            ButtonRouteInsert.TabIndex = 15;
            ButtonRouteInsert.Text = "挿入";
            ButtonRouteInsert.UseVisualStyleBackColor = true;
            ButtonRouteInsert.Click += ButtonRouteInsert_Click;
            // 
            // ButtonRouteDelete
            // 
            ButtonRouteDelete.Location = new Point(656, 257);
            ButtonRouteDelete.Name = "ButtonRouteDelete";
            ButtonRouteDelete.Size = new Size(75, 23);
            ButtonRouteDelete.TabIndex = 16;
            ButtonRouteDelete.Text = "削除";
            ButtonRouteDelete.UseVisualStyleBackColor = true;
            ButtonRouteDelete.Click += ButtonRouteDelete_Click;
            // 
            // ButtonRegisterFavoritList
            // 
            ButtonRegisterFavoritList.Location = new Point(668, 71);
            ButtonRegisterFavoritList.Name = "ButtonRegisterFavoritList";
            ButtonRegisterFavoritList.Size = new Size(120, 23);
            ButtonRegisterFavoritList.TabIndex = 17;
            ButtonRegisterFavoritList.Text = "お気に入りに追加";
            ButtonRegisterFavoritList.UseVisualStyleBackColor = true;
            ButtonRegisterFavoritList.Click += ButtonRegisterFavoritList_Click;
            // 
            // numericUpDownCode
            // 
            numericUpDownCode.Location = new Point(78, 9);
            numericUpDownCode.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numericUpDownCode.Name = "numericUpDownCode";
            numericUpDownCode.Size = new Size(92, 23);
            numericUpDownCode.TabIndex = 18;
            // 
            // numericUpDownIndent
            // 
            numericUpDownIndent.Location = new Point(78, 44);
            numericUpDownIndent.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numericUpDownIndent.Name = "numericUpDownIndent";
            numericUpDownIndent.Size = new Size(92, 23);
            numericUpDownIndent.TabIndex = 19;
            // 
            // EventCommandForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(numericUpDownIndent);
            Controls.Add(numericUpDownCode);
            Controls.Add(ButtonRegisterFavoritList);
            Controls.Add(ButtonRouteDelete);
            Controls.Add(ButtonRouteInsert);
            Controls.Add(ButtonParameterDelete);
            Controls.Add(ButtonParameterInsert);
            Controls.Add(Label_Route);
            Controls.Add(Label＿Parameter);
            Controls.Add(ButtonHelpFileUpdate);
            Controls.Add(ButtonCancel);
            Controls.Add(ButtonOK);
            Controls.Add(helpText);
            Controls.Add(RouteDataGrid);
            Controls.Add(ParameterDataGrid);
            Controls.Add(Label_Indent);
            Controls.Add(Label_Code);
            Name = "EventCommandForm";
            Text = "EventCommandForm";
            Load += EventCommandForm_Load;
            ((System.ComponentModel.ISupportInitialize)ParameterDataGrid).EndInit();
            ((System.ComponentModel.ISupportInitialize)RouteDataGrid).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownCode).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownIndent).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label Label_Code;
        private Label Label_Indent;
        private DataGridView ParameterDataGrid;
        private DataGridView RouteDataGrid;
        private RichTextBox helpText;
        private Button ButtonOK;
        private Button ButtonCancel;
        private Button ButtonHelpFileUpdate;
        private Label Label＿Parameter;
        private Label Label_Route;
        private Button ButtonParameterInsert;
        private Button ButtonParameterDelete;
        private Button ButtonRouteInsert;
        private Button ButtonRouteDelete;
        private Button ButtonRegisterFavoritList;
        private NumericUpDown numericUpDownCode;
        private NumericUpDown numericUpDownIndent;
    }
}