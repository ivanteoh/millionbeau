namespace MillionBeauty
{
    partial class OptionsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OptionsForm));
            this.newButton = new System.Windows.Forms.Button();
            this.loadButton = new System.Windows.Forms.Button();
            this.currentLabel = new System.Windows.Forms.Label();
            this.databaseLabel = new System.Windows.Forms.Label();
            this.optionTabControl = new System.Windows.Forms.TabControl();
            this.databaseTabPage = new System.Windows.Forms.TabPage();
            this.keyTabPage = new System.Windows.Forms.TabPage();
            this.keyLabel = new System.Windows.Forms.Label();
            this.keyTextBox = new System.Windows.Forms.TextBox();
            this.enterLabel = new System.Windows.Forms.Label();
            this.enterTextBox = new System.Windows.Forms.TextBox();
            this.reEnterLabel = new System.Windows.Forms.Label();
            this.reEnterTextBox = new System.Windows.Forms.TextBox();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.optionTabControl.SuspendLayout();
            this.databaseTabPage.SuspendLayout();
            this.keyTabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // newButton
            // 
            resources.ApplyResources(this.newButton, "newButton");
            this.newButton.Name = "newButton";
            this.newButton.UseVisualStyleBackColor = true;
            // 
            // loadButton
            // 
            resources.ApplyResources(this.loadButton, "loadButton");
            this.loadButton.Name = "loadButton";
            this.loadButton.UseVisualStyleBackColor = true;
            // 
            // currentLabel
            // 
            this.currentLabel.AllowDrop = true;
            resources.ApplyResources(this.currentLabel, "currentLabel");
            this.currentLabel.Name = "currentLabel";
            // 
            // databaseLabel
            // 
            resources.ApplyResources(this.databaseLabel, "databaseLabel");
            this.databaseLabel.Name = "databaseLabel";
            // 
            // optionTabControl
            // 
            this.optionTabControl.Controls.Add(this.databaseTabPage);
            this.optionTabControl.Controls.Add(this.keyTabPage);
            resources.ApplyResources(this.optionTabControl, "optionTabControl");
            this.optionTabControl.Name = "optionTabControl";
            this.optionTabControl.SelectedIndex = 0;
            // 
            // databaseTabPage
            // 
            this.databaseTabPage.Controls.Add(this.currentLabel);
            this.databaseTabPage.Controls.Add(this.databaseLabel);
            this.databaseTabPage.Controls.Add(this.newButton);
            this.databaseTabPage.Controls.Add(this.loadButton);
            resources.ApplyResources(this.databaseTabPage, "databaseTabPage");
            this.databaseTabPage.Name = "databaseTabPage";
            this.databaseTabPage.UseVisualStyleBackColor = true;
            // 
            // keyTabPage
            // 
            this.keyTabPage.Controls.Add(this.keyLabel);
            this.keyTabPage.Controls.Add(this.keyTextBox);
            this.keyTabPage.Controls.Add(this.enterLabel);
            this.keyTabPage.Controls.Add(this.enterTextBox);
            this.keyTabPage.Controls.Add(this.reEnterLabel);
            this.keyTabPage.Controls.Add(this.reEnterTextBox);
            this.keyTabPage.Controls.Add(this.okButton);
            this.keyTabPage.Controls.Add(this.cancelButton);
            resources.ApplyResources(this.keyTabPage, "keyTabPage");
            this.keyTabPage.Name = "keyTabPage";
            this.keyTabPage.UseVisualStyleBackColor = true;
            // 
            // keyLabel
            // 
            resources.ApplyResources(this.keyLabel, "keyLabel");
            this.keyLabel.Name = "keyLabel";
            // 
            // keyTextBox
            // 
            resources.ApplyResources(this.keyTextBox, "keyTextBox");
            this.keyTextBox.Name = "keyTextBox";
            this.keyTextBox.UseSystemPasswordChar = true;
            // 
            // enterLabel
            // 
            resources.ApplyResources(this.enterLabel, "enterLabel");
            this.enterLabel.Name = "enterLabel";
            // 
            // enterTextBox
            // 
            resources.ApplyResources(this.enterTextBox, "enterTextBox");
            this.enterTextBox.Name = "enterTextBox";
            this.enterTextBox.UseSystemPasswordChar = true;
            // 
            // reEnterLabel
            // 
            resources.ApplyResources(this.reEnterLabel, "reEnterLabel");
            this.reEnterLabel.Name = "reEnterLabel";
            // 
            // reEnterTextBox
            // 
            resources.ApplyResources(this.reEnterTextBox, "reEnterTextBox");
            this.reEnterTextBox.Name = "reEnterTextBox";
            this.reEnterTextBox.UseSystemPasswordChar = true;
            // 
            // okButton
            // 
            resources.ApplyResources(this.okButton, "okButton");
            this.okButton.Name = "okButton";
            this.okButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            resources.ApplyResources(this.cancelButton, "cancelButton");
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // OptionsForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.optionTabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OptionsForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.optionTabControl.ResumeLayout(false);
            this.databaseTabPage.ResumeLayout(false);
            this.databaseTabPage.PerformLayout();
            this.keyTabPage.ResumeLayout(false);
            this.keyTabPage.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button newButton;
        private System.Windows.Forms.Button loadButton;
        private System.Windows.Forms.Label currentLabel;
        private System.Windows.Forms.Label databaseLabel;
        private System.Windows.Forms.TabControl optionTabControl;
        private System.Windows.Forms.TabPage databaseTabPage;
        private System.Windows.Forms.TabPage keyTabPage;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.TextBox reEnterTextBox;
        private System.Windows.Forms.Label reEnterLabel;
        private System.Windows.Forms.TextBox enterTextBox;
        private System.Windows.Forms.Label enterLabel;
        private System.Windows.Forms.TextBox keyTextBox;
        private System.Windows.Forms.Label keyLabel;
        private System.Windows.Forms.Button cancelButton;
    }
}