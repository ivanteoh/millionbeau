namespace MillionBeauty
{
    partial class CustomerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomerForm));
            this.nameRegexTextBox = new CustomControl.RegexTextBox();
            this.idLabel = new System.Windows.Forms.Label();
            this.idTextLabel = new System.Windows.Forms.Label();
            this.titleLabel = new System.Windows.Forms.Label();
            this.nameLabel = new System.Windows.Forms.Label();
            this.addressLabel = new System.Windows.Forms.Label();
            this.postcodeLabel = new System.Windows.Forms.Label();
            this.stateLabel = new System.Windows.Forms.Label();
            this.phoneLabel = new System.Windows.Forms.Label();
            this.companyLabel = new System.Windows.Forms.Label();
            this.titleComboBox = new System.Windows.Forms.ComboBox();
            this.addressRegexTextBox = new CustomControl.RegexTextBox();
            this.postcodeRegexTextBox = new CustomControl.RegexTextBox();
            this.stateRegexTextBox = new CustomControl.RegexTextBox();
            this.phoneRegexTextBox = new CustomControl.RegexTextBox();
            this.companyRegexTextBox = new CustomControl.RegexTextBox();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // nameRegexTextBox
            // 
            this.nameRegexTextBox.CustomPattern = "^()$";
            resources.ApplyResources(this.nameRegexTextBox, "nameRegexTextBox");
            this.nameRegexTextBox.Name = "nameRegexTextBox";
            // 
            // idLabel
            // 
            resources.ApplyResources(this.idLabel, "idLabel");
            this.idLabel.Name = "idLabel";
            // 
            // idTextLabel
            // 
            resources.ApplyResources(this.idTextLabel, "idTextLabel");
            this.idTextLabel.Name = "idTextLabel";
            // 
            // titleLabel
            // 
            resources.ApplyResources(this.titleLabel, "titleLabel");
            this.titleLabel.Name = "titleLabel";
            // 
            // nameLabel
            // 
            resources.ApplyResources(this.nameLabel, "nameLabel");
            this.nameLabel.Name = "nameLabel";
            // 
            // addressLabel
            // 
            resources.ApplyResources(this.addressLabel, "addressLabel");
            this.addressLabel.Name = "addressLabel";
            // 
            // postcodeLabel
            // 
            resources.ApplyResources(this.postcodeLabel, "postcodeLabel");
            this.postcodeLabel.Name = "postcodeLabel";
            // 
            // stateLabel
            // 
            resources.ApplyResources(this.stateLabel, "stateLabel");
            this.stateLabel.Name = "stateLabel";
            // 
            // phoneLabel
            // 
            resources.ApplyResources(this.phoneLabel, "phoneLabel");
            this.phoneLabel.Name = "phoneLabel";
            // 
            // companyLabel
            // 
            resources.ApplyResources(this.companyLabel, "companyLabel");
            this.companyLabel.Name = "companyLabel";
            // 
            // titleComboBox
            // 
            this.titleComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.titleComboBox.FormattingEnabled = true;
            this.titleComboBox.Items.AddRange(new object[] {
            resources.GetString("titleComboBox.Items"),
            resources.GetString("titleComboBox.Items1"),
            resources.GetString("titleComboBox.Items2"),
            resources.GetString("titleComboBox.Items3"),
            resources.GetString("titleComboBox.Items4"),
            resources.GetString("titleComboBox.Items5")});
            resources.ApplyResources(this.titleComboBox, "titleComboBox");
            this.titleComboBox.Name = "titleComboBox";
            // 
            // addressRegexTextBox
            // 
            this.addressRegexTextBox.CustomPattern = "^()$";
            resources.ApplyResources(this.addressRegexTextBox, "addressRegexTextBox");
            this.addressRegexTextBox.Name = "addressRegexTextBox";
            // 
            // postcodeRegexTextBox
            // 
            this.postcodeRegexTextBox.CustomPattern = "^()$";
            resources.ApplyResources(this.postcodeRegexTextBox, "postcodeRegexTextBox");
            this.postcodeRegexTextBox.Name = "postcodeRegexTextBox";
            // 
            // stateRegexTextBox
            // 
            this.stateRegexTextBox.CustomPattern = "^()$";
            resources.ApplyResources(this.stateRegexTextBox, "stateRegexTextBox");
            this.stateRegexTextBox.Name = "stateRegexTextBox";
            // 
            // phoneRegexTextBox
            // 
            this.phoneRegexTextBox.CustomPattern = "^()$";
            resources.ApplyResources(this.phoneRegexTextBox, "phoneRegexTextBox");
            this.phoneRegexTextBox.Name = "phoneRegexTextBox";
            // 
            // companyRegexTextBox
            // 
            this.companyRegexTextBox.CustomPattern = "^()$";
            resources.ApplyResources(this.companyRegexTextBox, "companyRegexTextBox");
            this.companyRegexTextBox.Name = "companyRegexTextBox";
            // 
            // okButton
            // 
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            resources.ApplyResources(this.okButton, "okButton");
            this.okButton.Name = "okButton";
            this.okButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.cancelButton, "cancelButton");
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // CustomerForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.idLabel);
            this.Controls.Add(this.idTextLabel);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.titleComboBox);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.nameRegexTextBox);
            this.Controls.Add(this.addressLabel);
            this.Controls.Add(this.addressRegexTextBox);
            this.Controls.Add(this.postcodeLabel);
            this.Controls.Add(this.postcodeRegexTextBox);
            this.Controls.Add(this.stateLabel);
            this.Controls.Add(this.stateRegexTextBox);
            this.Controls.Add(this.phoneLabel);
            this.Controls.Add(this.phoneRegexTextBox);
            this.Controls.Add(this.companyLabel);
            this.Controls.Add(this.companyRegexTextBox);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.cancelButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CustomerForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CustomControl.RegexTextBox nameRegexTextBox;
        private System.Windows.Forms.Label idLabel;
        private System.Windows.Forms.Label idTextLabel;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label addressLabel;
        private System.Windows.Forms.Label postcodeLabel;
        private System.Windows.Forms.Label stateLabel;
        private System.Windows.Forms.Label phoneLabel;
        private System.Windows.Forms.Label companyLabel;
        private System.Windows.Forms.ComboBox titleComboBox;
        private CustomControl.RegexTextBox addressRegexTextBox;
        private CustomControl.RegexTextBox postcodeRegexTextBox;
        private CustomControl.RegexTextBox stateRegexTextBox;
        private CustomControl.RegexTextBox phoneRegexTextBox;
        private CustomControl.RegexTextBox companyRegexTextBox;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
    }
}