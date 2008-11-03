namespace MillionBeauty
{
    partial class ProductForm
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
            this.nameLabel = new System.Windows.Forms.Label();
            this.descriptionLabel = new System.Windows.Forms.Label();
            this.typeLabel = new System.Windows.Forms.Label();
            this.specificationLabel = new System.Windows.Forms.Label();
            this.inStockLabel = new System.Windows.Forms.Label();
            this.priceLabel = new System.Windows.Forms.Label();
            this.descriptionRegexTextBox = new CustomControl.RegexTextBox();
            this.typeRegexTextBox = new CustomControl.RegexTextBox();
            this.specificationRegexTextBox = new CustomControl.RegexTextBox();
            this.inStockRegexTextBox = new CustomControl.RegexTextBox();
            this.priceRegexTextBox = new CustomControl.RegexTextBox();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // nameRegexTextBox
            // 
            this.nameRegexTextBox.CustomPattern = "^()$";
            this.nameRegexTextBox.Location = new System.Drawing.Point(117, 39);
            this.nameRegexTextBox.MaxLength = 100;
            this.nameRegexTextBox.Name = "nameRegexTextBox";
            this.nameRegexTextBox.Size = new System.Drawing.Size(100, 20);
            this.nameRegexTextBox.TabIndex = 8;
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
            this.idTextLabel.TabIndex = 7;
            this.idTextLabel.Text = "-1";
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(12, 42);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(35, 13);
            this.nameLabel.TabIndex = 1;
            this.nameLabel.Text = "Name";
            // 
            // descriptionLabel
            // 
            this.descriptionLabel.AutoSize = true;
            this.descriptionLabel.Location = new System.Drawing.Point(12, 71);
            this.descriptionLabel.Name = "descriptionLabel";
            this.descriptionLabel.Size = new System.Drawing.Size(60, 13);
            this.descriptionLabel.TabIndex = 2;
            this.descriptionLabel.Text = "Description";
            // 
            // typeLabel
            // 
            this.typeLabel.AutoSize = true;
            this.typeLabel.Location = new System.Drawing.Point(12, 100);
            this.typeLabel.Name = "typeLabel";
            this.typeLabel.Size = new System.Drawing.Size(31, 13);
            this.typeLabel.TabIndex = 3;
            this.typeLabel.Text = "Type";
            // 
            // specificationLabel
            // 
            this.specificationLabel.AutoSize = true;
            this.specificationLabel.Location = new System.Drawing.Point(12, 129);
            this.specificationLabel.Name = "specificationLabel";
            this.specificationLabel.Size = new System.Drawing.Size(68, 13);
            this.specificationLabel.TabIndex = 4;
            this.specificationLabel.Text = "Specification";
            // 
            // inStockLabel
            // 
            this.inStockLabel.AutoSize = true;
            this.inStockLabel.Location = new System.Drawing.Point(12, 158);
            this.inStockLabel.Name = "inStockLabel";
            this.inStockLabel.Size = new System.Drawing.Size(47, 13);
            this.inStockLabel.TabIndex = 5;
            this.inStockLabel.Text = "In Stock";
            // 
            // priceLabel
            // 
            this.priceLabel.AutoSize = true;
            this.priceLabel.Location = new System.Drawing.Point(12, 187);
            this.priceLabel.Name = "priceLabel";
            this.priceLabel.Size = new System.Drawing.Size(57, 13);
            this.priceLabel.TabIndex = 6;
            this.priceLabel.Text = "Price (RM)";
            // 
            // descriptionRegexTextBox
            // 
            this.descriptionRegexTextBox.CustomPattern = "^()$";
            this.descriptionRegexTextBox.Location = new System.Drawing.Point(117, 68);
            this.descriptionRegexTextBox.MaxLength = 100;
            this.descriptionRegexTextBox.Name = "descriptionRegexTextBox";
            this.descriptionRegexTextBox.Size = new System.Drawing.Size(345, 20);
            this.descriptionRegexTextBox.TabIndex = 9;
            // 
            // typeRegexTextBox
            // 
            this.typeRegexTextBox.CustomPattern = "^()$";
            this.typeRegexTextBox.Location = new System.Drawing.Point(117, 97);
            this.typeRegexTextBox.MaxLength = 100;
            this.typeRegexTextBox.Name = "typeRegexTextBox";
            this.typeRegexTextBox.Size = new System.Drawing.Size(100, 20);
            this.typeRegexTextBox.TabIndex = 10;
            // 
            // specificationRegexTextBox
            // 
            this.specificationRegexTextBox.CustomPattern = "^()$";
            this.specificationRegexTextBox.Location = new System.Drawing.Point(117, 126);
            this.specificationRegexTextBox.MaxLength = 100;
            this.specificationRegexTextBox.Name = "specificationRegexTextBox";
            this.specificationRegexTextBox.Size = new System.Drawing.Size(345, 20);
            this.specificationRegexTextBox.TabIndex = 11;
            // 
            // inStockRegexTextBox
            // 
            this.inStockRegexTextBox.CustomPattern = "^()$";
            this.inStockRegexTextBox.Location = new System.Drawing.Point(117, 155);
            this.inStockRegexTextBox.MaxLength = 100;
            this.inStockRegexTextBox.Name = "inStockRegexTextBox";
            this.inStockRegexTextBox.Size = new System.Drawing.Size(100, 20);
            this.inStockRegexTextBox.TabIndex = 12;
            // 
            // priceRegexTextBox
            // 
            this.priceRegexTextBox.CustomPattern = "^()$";
            this.priceRegexTextBox.Location = new System.Drawing.Point(117, 184);
            this.priceRegexTextBox.MaxLength = 100;
            this.priceRegexTextBox.Name = "priceRegexTextBox";
            this.priceRegexTextBox.Size = new System.Drawing.Size(100, 20);
            this.priceRegexTextBox.TabIndex = 13;
            // 
            // okButton
            // 
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Location = new System.Drawing.Point(306, 240);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 14;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(387, 240);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 15;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // ProductForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(474, 275);
            this.Controls.Add(this.idLabel);
            this.Controls.Add(this.idTextLabel);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.nameRegexTextBox);
            this.Controls.Add(this.descriptionLabel);
            this.Controls.Add(this.descriptionRegexTextBox);
            this.Controls.Add(this.typeLabel);
            this.Controls.Add(this.typeRegexTextBox);
            this.Controls.Add(this.specificationLabel);
            this.Controls.Add(this.specificationRegexTextBox);
            this.Controls.Add(this.inStockLabel);
            this.Controls.Add(this.inStockRegexTextBox);
            this.Controls.Add(this.priceLabel);
            this.Controls.Add(this.priceRegexTextBox);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.cancelButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProductForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CustomControl.RegexTextBox nameRegexTextBox;
        private System.Windows.Forms.Label idLabel;
        private System.Windows.Forms.Label idTextLabel;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label descriptionLabel;
        private System.Windows.Forms.Label typeLabel;
        private System.Windows.Forms.Label specificationLabel;
        private System.Windows.Forms.Label inStockLabel;
        private System.Windows.Forms.Label priceLabel;
        private CustomControl.RegexTextBox descriptionRegexTextBox;
        private CustomControl.RegexTextBox typeRegexTextBox;
        private CustomControl.RegexTextBox specificationRegexTextBox;
        private CustomControl.RegexTextBox inStockRegexTextBox;
        private CustomControl.RegexTextBox priceRegexTextBox;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
    }
}