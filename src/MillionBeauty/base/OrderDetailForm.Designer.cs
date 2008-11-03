namespace MillionBeauty
{
    partial class OrderDetailForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrderDetailForm));
            this.nameLabel = new System.Windows.Forms.Label();
            this.descriptionLabel = new System.Windows.Forms.Label();
            this.typeLabel = new System.Windows.Forms.Label();
            this.inStockLabel = new System.Windows.Forms.Label();
            this.priceLabel = new System.Windows.Forms.Label();
            this.quantityLabel = new System.Windows.Forms.Label();
            this.discountLabel = new System.Windows.Forms.Label();
            this.totalCostLabel = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.descriptionTextBox = new System.Windows.Forms.TextBox();
            this.typeTextBox = new System.Windows.Forms.TextBox();
            this.inStockTextBox = new System.Windows.Forms.TextBox();
            this.priceTextBox = new System.Windows.Forms.TextBox();
            this.totalCostTextBox = new System.Windows.Forms.TextBox();
            this.productGroupBox = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.idTextBox = new System.Windows.Forms.TextBox();
            this.productFindButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.quantityRegexTextBox = new CustomControl.RegexTextBox();
            this.discountRegexTextBox = new CustomControl.RegexTextBox();
            this.costLabel = new System.Windows.Forms.Label();
            this.costTextBox = new System.Windows.Forms.TextBox();
            this.productGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // nameLabel
            // 
            resources.ApplyResources(this.nameLabel, "nameLabel");
            this.nameLabel.Name = "nameLabel";
            // 
            // descriptionLabel
            // 
            resources.ApplyResources(this.descriptionLabel, "descriptionLabel");
            this.descriptionLabel.Name = "descriptionLabel";
            // 
            // typeLabel
            // 
            resources.ApplyResources(this.typeLabel, "typeLabel");
            this.typeLabel.Name = "typeLabel";
            // 
            // inStockLabel
            // 
            resources.ApplyResources(this.inStockLabel, "inStockLabel");
            this.inStockLabel.Name = "inStockLabel";
            // 
            // priceLabel
            // 
            resources.ApplyResources(this.priceLabel, "priceLabel");
            this.priceLabel.Name = "priceLabel";
            // 
            // quantityLabel
            // 
            resources.ApplyResources(this.quantityLabel, "quantityLabel");
            this.quantityLabel.Name = "quantityLabel";
            // 
            // discountLabel
            // 
            resources.ApplyResources(this.discountLabel, "discountLabel");
            this.discountLabel.Name = "discountLabel";
            // 
            // totalCostLabel
            // 
            resources.ApplyResources(this.totalCostLabel, "totalCostLabel");
            this.totalCostLabel.Name = "totalCostLabel";
            // 
            // nameTextBox
            // 
            resources.ApplyResources(this.nameTextBox, "nameTextBox");
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.ReadOnly = true;
            // 
            // descriptionTextBox
            // 
            resources.ApplyResources(this.descriptionTextBox, "descriptionTextBox");
            this.descriptionTextBox.Name = "descriptionTextBox";
            this.descriptionTextBox.ReadOnly = true;
            // 
            // typeTextBox
            // 
            resources.ApplyResources(this.typeTextBox, "typeTextBox");
            this.typeTextBox.Name = "typeTextBox";
            this.typeTextBox.ReadOnly = true;
            // 
            // inStockTextBox
            // 
            resources.ApplyResources(this.inStockTextBox, "inStockTextBox");
            this.inStockTextBox.Name = "inStockTextBox";
            this.inStockTextBox.ReadOnly = true;
            // 
            // priceTextBox
            // 
            resources.ApplyResources(this.priceTextBox, "priceTextBox");
            this.priceTextBox.Name = "priceTextBox";
            this.priceTextBox.ReadOnly = true;
            // 
            // totalCostTextBox
            // 
            resources.ApplyResources(this.totalCostTextBox, "totalCostTextBox");
            this.totalCostTextBox.Name = "totalCostTextBox";
            this.totalCostTextBox.ReadOnly = true;
            // 
            // productGroupBox
            // 
            this.productGroupBox.Controls.Add(this.label1);
            this.productGroupBox.Controls.Add(this.idTextBox);
            this.productGroupBox.Controls.Add(this.nameLabel);
            this.productGroupBox.Controls.Add(this.nameTextBox);
            this.productGroupBox.Controls.Add(this.descriptionLabel);
            this.productGroupBox.Controls.Add(this.descriptionTextBox);
            this.productGroupBox.Controls.Add(this.typeLabel);
            this.productGroupBox.Controls.Add(this.typeTextBox);
            this.productGroupBox.Controls.Add(this.inStockLabel);
            this.productGroupBox.Controls.Add(this.inStockTextBox);
            this.productGroupBox.Controls.Add(this.priceLabel);
            this.productGroupBox.Controls.Add(this.priceTextBox);
            this.productGroupBox.Controls.Add(this.productFindButton);
            resources.ApplyResources(this.productGroupBox, "productGroupBox");
            this.productGroupBox.Name = "productGroupBox";
            this.productGroupBox.TabStop = false;
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // idTextBox
            // 
            resources.ApplyResources(this.idTextBox, "idTextBox");
            this.idTextBox.Name = "idTextBox";
            this.idTextBox.ReadOnly = true;
            // 
            // productFindButton
            // 
            resources.ApplyResources(this.productFindButton, "productFindButton");
            this.productFindButton.Name = "productFindButton";
            this.productFindButton.UseVisualStyleBackColor = true;
            // 
            // addButton
            // 
            resources.ApplyResources(this.addButton, "addButton");
            this.addButton.Name = "addButton";
            this.addButton.UseVisualStyleBackColor = true;
            // 
            // quantityRegexTextBox
            // 
            this.quantityRegexTextBox.CustomPattern = "^()$";
            resources.ApplyResources(this.quantityRegexTextBox, "quantityRegexTextBox");
            this.quantityRegexTextBox.Name = "quantityRegexTextBox";
            // 
            // discountRegexTextBox
            // 
            this.discountRegexTextBox.CustomPattern = "^()$";
            resources.ApplyResources(this.discountRegexTextBox, "discountRegexTextBox");
            this.discountRegexTextBox.Name = "discountRegexTextBox";
            // 
            // costLabel
            // 
            resources.ApplyResources(this.costLabel, "costLabel");
            this.costLabel.Name = "costLabel";
            // 
            // costTextBox
            // 
            resources.ApplyResources(this.costTextBox, "costTextBox");
            this.costTextBox.Name = "costTextBox";
            this.costTextBox.ReadOnly = true;
            // 
            // OrderDetailForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.productGroupBox);
            this.Controls.Add(this.quantityLabel);
            this.Controls.Add(this.quantityRegexTextBox);
            this.Controls.Add(this.costLabel);
            this.Controls.Add(this.costTextBox);
            this.Controls.Add(this.discountLabel);
            this.Controls.Add(this.discountRegexTextBox);
            this.Controls.Add(this.totalCostLabel);
            this.Controls.Add(this.totalCostTextBox);
            this.Controls.Add(this.addButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OrderDetailForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.productGroupBox.ResumeLayout(false);
            this.productGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label descriptionLabel;
        private System.Windows.Forms.Label typeLabel;
        private System.Windows.Forms.Label inStockLabel;
        private System.Windows.Forms.Label priceLabel;
        private System.Windows.Forms.Label quantityLabel;
        private System.Windows.Forms.Label discountLabel;
        private System.Windows.Forms.Label totalCostLabel;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.TextBox descriptionTextBox;
        private System.Windows.Forms.TextBox typeTextBox;
        private System.Windows.Forms.TextBox inStockTextBox;
        private System.Windows.Forms.TextBox priceTextBox;
        private System.Windows.Forms.TextBox totalCostTextBox;
        private System.Windows.Forms.GroupBox productGroupBox;
        private System.Windows.Forms.Button productFindButton;
        private System.Windows.Forms.Button addButton;
        private CustomControl.RegexTextBox quantityRegexTextBox;
        private CustomControl.RegexTextBox discountRegexTextBox;
        private System.Windows.Forms.TextBox idTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label costLabel;
        private System.Windows.Forms.TextBox costTextBox;
    }
}