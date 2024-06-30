namespace WindowsPet
{
    partial class HomeForm
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
            pictureBox = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
            SuspendLayout();
            // 
            // pictureBox
            // 
            pictureBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pictureBox.Location = new Point(0, 0);
            pictureBox.Margin = new Padding(7, 8, 7, 8);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new Size(1943, 1230);
            pictureBox.TabIndex = 0;
            pictureBox.TabStop = false;
            pictureBox.MouseDown += HomeMouseDown;
            pictureBox.MouseMove += HomeMouseMove;
            pictureBox.MouseUp += HomeMouseUp;
            // 
            // HomeForm
            // 
            AutoScaleDimensions = new SizeF(17F, 41F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1943, 1230);
            Controls.Add(pictureBox);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(7, 8, 7, 8);
            Name = "HomeForm";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.Manual;
            Text = "HomeForm";
            TopMost = true;
            TransparencyKey = SystemColors.Control;
            ((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox;
    }
}