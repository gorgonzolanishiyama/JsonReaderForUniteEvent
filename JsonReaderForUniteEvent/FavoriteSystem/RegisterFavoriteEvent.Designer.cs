namespace JsonReaderForUniteEvent.FavoriteSystem
{
    partial class RegisterFavoriteEvent
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
            label1 = new Label();
            TextDescription = new TextBox();
            ButtonRegister = new Button();
            ButtonCancel = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(213, 15);
            label1.TabIndex = 0;
            label1.Text = "このイベント状態をお気に入りに登録します。";
            // 
            // TextDescription
            // 
            TextDescription.Location = new Point(12, 27);
            TextDescription.Name = "TextDescription";
            TextDescription.Size = new Size(343, 23);
            TextDescription.TabIndex = 1;
            TextDescription.Text = "概要";
            // 
            // ButtonRegister
            // 
            ButtonRegister.Location = new Point(150, 56);
            ButtonRegister.Name = "ButtonRegister";
            ButtonRegister.Size = new Size(75, 23);
            ButtonRegister.TabIndex = 2;
            ButtonRegister.Text = "登録する";
            ButtonRegister.UseVisualStyleBackColor = true;
            ButtonRegister.Click += ButtonRegister_Click;
            // 
            // ButtonCancel
            // 
            ButtonCancel.Location = new Point(250, 56);
            ButtonCancel.Name = "ButtonCancel";
            ButtonCancel.Size = new Size(105, 23);
            ButtonCancel.TabIndex = 3;
            ButtonCancel.Text = "登録しないで戻る";
            ButtonCancel.UseVisualStyleBackColor = true;
            ButtonCancel.Click += ButtonCancel_Click;
            // 
            // RegisterFavoriteEvent
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(367, 83);
            Controls.Add(ButtonCancel);
            Controls.Add(ButtonRegister);
            Controls.Add(TextDescription);
            Controls.Add(label1);
            Name = "RegisterFavoriteEvent";
            Text = "RegisterFavoriteEvent";
            Load += RegisterFavoriteEvent_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox TextDescription;
        private Button ButtonRegister;
        private Button ButtonCancel;
    }
}