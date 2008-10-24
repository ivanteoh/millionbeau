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
            this.nameRegexTextBox.Location = new System.Drawing.Point(120, 68);
            this.nameRegexTextBox.MaxLength = 100;
            this.nameRegexTextBox.Name = "nameRegexTextBox";
            this.nameRegexTextBox.Size = new System.Drawing.Size(100, 20);
            this.nameRegexTextBox.TabIndex = 10;
            // 
            // idLabel
            // 
            this.idLabel.AutoSize = true;
            this.idLabel.Location = new System.Drawing.Point(12, 13);
            this.idLabel.Name = "idLabel";
            this.idLabel.Size = new System.Drawing.Size(18, 13);
            this.idLabel.TabIndex = 0;
            this.idLabel.Text = "ID";
            // 
            // idTextLabel
            // 
            this.idTextLabel.AutoSize = true;
            this.idTextLabel.Location = new System.Drawing.Point(117, 13);
            this.idTextLabel.Name = "idTextLabel";
            this.idTextLabel.Size = new System.Drawing.Size(16, 13);
            this.idTextLabel.TabIndex = 8;
            this.idTextLabel.Text = "-1";
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Location = new System.Drawing.Point(12, 42);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(83, 13);
            this.titleLabel.TabIndex = 1;
            this.titleLabel.Text = "Title of Courtesy";
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(12, 71);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(35, 13);
            this.nameLabel.TabIndex = 2;
            this.nameLabel.Text = "Name";
            // 
            // addressLabel
            // 
            this.addressLabel.AutoSize = true;
            this.addressLabel.Location = new System.Drawing.Point(12, 100);
            this.addressLabel.Name = "addressLabel";
            this.addressLabel.Size = new System.Drawing.Size(45, 13);
            this.addressLabel.TabIndex = 3;
            this.addressLabel.Text = "Address";
            // 
            // postcodeLabel
            // 
            this.postcodeLabel.AutoSize = true;
            this.postcodeLabel.Location = new System.Drawing.Point(12, 129);
            this.postcodeLabel.Name = "postcodeLabel";
            this.postcodeLabel.Size = new System.Drawing.Size(52, 13);
            this.postcodeLabel.TabIndex = 4;
            this.postcodeLabel.Text = "Postcode";
            // 
            // stateLabel
            // 
            this.stateLabel.AutoSize = true;
            this.stateLabel.Location = new System.Drawing.Point(12, 158);
            this.stateLabel.Name = "stateLabel";
            this.stateLabel.Size = new System.Drawing.Size(32, 13);
            this.stateLabel.TabIndex = 5;
            this.stateLabel.Text = "State";
            // 
            // phoneLabel
            // 
            this.phoneLabel.AutoSize = true;
            this.phoneLabel.Location = new System.Drawing.Point(12, 187);
            this.phoneLabel.Name = "phoneLabel";
            this.phoneLabel.Size = new System.Drawing.Size(38, 13);
            this.phoneLabel.TabIndex = 6;
            this.phoneLabel.Text = "Phone";
            // 
            // companyLabel
            // 
            this.companyLabel.AutoSize = true;
            this.companyLabel.Location = new System.Drawing.Point(12, 216);
            this.companyLabel.Name = "companyLabel";
            this.companyLabel.Size = new System.Drawing.Size(82, 13);
            this.companyLabel.TabIndex = 7;
            this.companyLabel.Text = "Company Name";
            // 
            // titleComboBox
            // 
            this.titleComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.titleComboBox.FormattingEnabled = true;
            this.titleComboBox.Items.AddRange(new object[] {
            "Mr.",
            "Mrs.",
            "Mdm.",
            "Ms.",
            "Miss",
            "Dr."});
            this.titleComboBox.Location = new System.Drawing.Point(120, 39);
            this.titleComboBox.Name = "titleComboBox";
            this.titleComboBox.Size = new System.Drawing.Size(121, 21);
            this.titleComboBox.TabIndex = 9;
            // 
            // addressRegexTextBox
            // 
            this.addressRegexTextBox.CustomPattern = "^()$";
            this.addressRegexTextBox.Location = new System.Drawing.Point(120, 97);
            this.addressRegexTextBox.MaxLength = 100;
            this.addressRegexTextBox.Name = "addressRegexTextBox";
            this.addressRegexTextBox.Size = new System.Drawing.Size(100, 20);
            this.addressRegexTextBox.TabIndex = 11;
            // 
            // postcodeRegexTextBox
            // 
            this.postcodeRegexTextBox.CustomPattern = "^()$";
            this.postcodeRegexTextBox.Location = new System.Drawing.Point(120, 126);
            this.postcodeRegexTextBox.MaxLength = 100;
            this.postcodeRegexTextBox.Name = "postcodeRegexTextBox";
            this.postcodeRegexTextBox.Size = new System.Drawing.Size(100, 20);
            this.postcodeRegexTextBox.TabIndex = 12;
            // 
            // stateRegexTextBox
            // 
            this.stateRegexTextBox.CustomPattern = "^()$";
            this.stateRegexTextBox.Location = new System.Drawing.Point(120, 155);
            this.stateRegexTextBox.MaxLength = 100;
            this.stateRegexTextBox.Name = "stateRegexTextBox";
            this.stateRegexTextBox.Size = new System.Drawing.Size(100, 20);
            this.stateRegexTextBox.TabIndex = 13;
            // 
            // phoneRegexTextBox
            // 
            this.phoneRegexTextBox.CustomPattern = "^()$";
            this.phoneRegexTextBox.Location = new System.Drawing.Point(120, 184);
            this.phoneRegexTextBox.MaxLength = 100;
            this.phoneRegexTextBox.Name = "phoneRegexTextBox";
            this.phoneRegexTextBox.Size = new System.Drawing.Size(100, 20);
            this.phoneRegexTextBox.TabIndex = 14;
            // 
            // companyRegexTextBox
            // 
            this.companyRegexTextBox.CustomPattern = "^()$";
            this.companyRegexTextBox.Location = new System.Drawing.Point(120, 213);
            this.companyRegexTextBox.MaxLength = 100;
            this.companyRegexTextBox.Name = "companyRegexTextBox";
            this.companyRegexTextBox.Size = new System.Drawing.Size(100, 20);
            this.companyRegexTextBox.TabIndex = 15;
            // 
            // okButton
            // 
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Location = new System.Drawing.Point(120, 272);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 16;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(205, 272);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 17;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // CustomerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 307);
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
            this.Name = "CustomerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
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