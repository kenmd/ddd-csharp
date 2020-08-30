namespace WindowsFormsApp1
{
    partial class MenuForm
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
            this.UserSaveFormButton = new System.Windows.Forms.Button();
            this.UserListFormButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // UserSaveFormButton
            // 
            this.UserSaveFormButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.UserSaveFormButton.Location = new System.Drawing.Point(0, 0);
            this.UserSaveFormButton.Name = "UserSaveFormButton";
            this.UserSaveFormButton.Size = new System.Drawing.Size(800, 44);
            this.UserSaveFormButton.TabIndex = 0;
            this.UserSaveFormButton.Text = "ユーザー登録";
            this.UserSaveFormButton.UseVisualStyleBackColor = true;
            this.UserSaveFormButton.Click += new System.EventHandler(this.UserSaveFormButton_Click);
            // 
            // UserListFormButton
            // 
            this.UserListFormButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.UserListFormButton.Location = new System.Drawing.Point(0, 44);
            this.UserListFormButton.Name = "UserListFormButton";
            this.UserListFormButton.Size = new System.Drawing.Size(800, 45);
            this.UserListFormButton.TabIndex = 1;
            this.UserListFormButton.Text = "ユーザーリスト";
            this.UserListFormButton.UseVisualStyleBackColor = true;
            this.UserListFormButton.Click += new System.EventHandler(this.UserListFormButton_Click);
            // 
            // MenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.UserListFormButton);
            this.Controls.Add(this.UserSaveFormButton);
            this.Name = "MenuForm";
            this.Text = "Menu";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button UserSaveFormButton;
        private System.Windows.Forms.Button UserListFormButton;
    }
}