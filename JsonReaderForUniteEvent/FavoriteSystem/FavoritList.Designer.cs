namespace JsonReaderForUniteEvent.FavoriteSystem
{
    partial class FavoritList
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
            ListBoxFavorit = new ListBox();
            ButtonInsert = new Button();
            ButtonCancel = new Button();
            SuspendLayout();
            // 
            // ListBoxFavorit
            // 
            ListBoxFavorit.FormattingEnabled = true;
            ListBoxFavorit.ItemHeight = 15;
            ListBoxFavorit.Location = new Point(29, 12);
            ListBoxFavorit.Name = "ListBoxFavorit";
            ListBoxFavorit.Size = new Size(431, 289);
            ListBoxFavorit.TabIndex = 0;
            ListBoxFavorit.SelectedIndexChanged += ListBoxFavorit_SelectedIndexChanged;
            // 
            // ButtonInsert
            // 
            ButtonInsert.Location = new Point(282, 318);
            ButtonInsert.Name = "ButtonInsert";
            ButtonInsert.Size = new Size(75, 23);
            ButtonInsert.TabIndex = 1;
            ButtonInsert.Text = "挿入する";
            ButtonInsert.UseVisualStyleBackColor = true;
            ButtonInsert.Click += ButtonInsert_Click;
            // 
            // ButtonCancel
            // 
            ButtonCancel.Location = new Point(363, 318);
            ButtonCancel.Name = "ButtonCancel";
            ButtonCancel.Size = new Size(97, 23);
            ButtonCancel.TabIndex = 2;
            ButtonCancel.Text = "挿入せず終了";
            ButtonCancel.UseVisualStyleBackColor = true;
            ButtonCancel.Click += ButtonCancel_Click;
            // 
            // FavoritList
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(484, 353);
            Controls.Add(ButtonCancel);
            Controls.Add(ButtonInsert);
            Controls.Add(ListBoxFavorit);
            Name = "FavoritList";
            Text = "FavoritList";
            Load += FavoritList_Load;
            ResumeLayout(false);
        }

        #endregion

        private ListBox ListBoxFavorit;
        private Button ButtonInsert;
        private Button ButtonCancel;
    }
}