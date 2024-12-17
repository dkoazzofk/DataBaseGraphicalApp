namespace test.VIew.Class
{
    partial class ConsoleWindow
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
            this.dataGridViewDocument = new System.Windows.Forms.DataGridView();
            this.seeDocument = new System.Windows.Forms.Button();
            this.saveDocument = new System.Windows.Forms.Button();
            this.textBoxDocument = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDocument)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewDocument
            // 
            this.dataGridViewDocument.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridViewDocument.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDocument.Location = new System.Drawing.Point(12, 12);
            this.dataGridViewDocument.Name = "dataGridViewDocument";
            this.dataGridViewDocument.RowHeadersWidth = 51;
            this.dataGridViewDocument.RowTemplate.Height = 24;
            this.dataGridViewDocument.Size = new System.Drawing.Size(1000, 442);
            this.dataGridViewDocument.TabIndex = 0;
            // 
            // seeDocument
            // 
            this.seeDocument.Cursor = System.Windows.Forms.Cursors.Hand;
            this.seeDocument.Location = new System.Drawing.Point(913, 460);
            this.seeDocument.Name = "seeDocument";
            this.seeDocument.Size = new System.Drawing.Size(100, 45);
            this.seeDocument.TabIndex = 1;
            this.seeDocument.Text = "Просмотр";
            this.seeDocument.UseVisualStyleBackColor = true;
            // 
            // saveDocument
            // 
            this.saveDocument.Cursor = System.Windows.Forms.Cursors.Hand;
            this.saveDocument.Location = new System.Drawing.Point(807, 460);
            this.saveDocument.Name = "saveDocument";
            this.saveDocument.Size = new System.Drawing.Size(100, 45);
            this.saveDocument.TabIndex = 2;
            this.saveDocument.Text = "Сохранить";
            this.saveDocument.UseVisualStyleBackColor = true;
            // 
            // textBoxDocument
            // 
            this.textBoxDocument.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxDocument.Location = new System.Drawing.Point(12, 460);
            this.textBoxDocument.Multiline = true;
            this.textBoxDocument.Name = "textBoxDocument";
            this.textBoxDocument.Size = new System.Drawing.Size(790, 45);
            this.textBoxDocument.TabIndex = 3;
            // 
            // ConsoleWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 518);
            this.Controls.Add(this.textBoxDocument);
            this.Controls.Add(this.saveDocument);
            this.Controls.Add(this.seeDocument);
            this.Controls.Add(this.dataGridViewDocument);
            this.Name = "ConsoleWindow";
            this.Text = "ConsoleWindow";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDocument)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewDocument;
        private System.Windows.Forms.Button seeDocument;
        private System.Windows.Forms.Button saveDocument;
        private System.Windows.Forms.TextBox textBoxDocument;
    }
}