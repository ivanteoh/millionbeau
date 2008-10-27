namespace MillionBeauty
{
    partial class NewOrderForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewOrderForm));
            this.customerGroupBox = new System.Windows.Forms.GroupBox();
            this.customerTitleLabel = new System.Windows.Forms.Label();
            this.customerTitleTextBox = new System.Windows.Forms.TextBox();
            this.customerNameLabel = new System.Windows.Forms.Label();
            this.customerNameTextBox = new System.Windows.Forms.TextBox();
            this.customerAddressLabel = new System.Windows.Forms.Label();
            this.customerAddressTextBox = new System.Windows.Forms.TextBox();
            this.customerPostcodeLabel = new System.Windows.Forms.Label();
            this.customerPostcodeTextBox = new System.Windows.Forms.TextBox();
            this.customerStateLabel = new System.Windows.Forms.Label();
            this.customerStateTextBox = new System.Windows.Forms.TextBox();
            this.customerPhoneLabel = new System.Windows.Forms.Label();
            this.customerPhoneTextBox = new System.Windows.Forms.TextBox();
            this.customerCompanyLabel = new System.Windows.Forms.Label();
            this.customerCompanyTextBox = new System.Windows.Forms.TextBox();
            this.customerFindButton = new System.Windows.Forms.Button();
            this.newOrderGroupBox = new System.Windows.Forms.GroupBox();
            this.recordLabel = new System.Windows.Forms.Label();
            this.recordTextBox = new System.Windows.Forms.TextBox();
            this.yearLabel = new System.Windows.Forms.Label();
            this.yearTextBox = new System.Windows.Forms.TextBox();
            this.dateLabel = new System.Windows.Forms.Label();
            this.dateTextBox = new System.Windows.Forms.TextBox();
            this.timeLabel = new System.Windows.Forms.Label();
            this.timeTextBox = new System.Windows.Forms.TextBox();
            this.itemGroupBox = new System.Windows.Forms.GroupBox();
            this.salesPersonLabel = new System.Windows.Forms.Label();
            this.salesPersonTextBox = new System.Windows.Forms.TextBox();
            this.totalLabel = new System.Windows.Forms.Label();
            this.totalTextBox = new System.Windows.Forms.TextBox();
            this.discountLabel = new System.Windows.Forms.Label();
            this.discountRegexTextBox = new CustomControl.RegexTextBox();
            this.grandTotalLabel = new System.Windows.Forms.Label();
            this.grandTotalTextBox = new System.Windows.Forms.TextBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.printButton = new System.Windows.Forms.Button();
            this.orderDetailsControl = new MillionBeauty.OrderDetailsControl();
            this.customerGroupBox.SuspendLayout();
            this.newOrderGroupBox.SuspendLayout();
            this.itemGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // customerGroupBox
            // 
            this.customerGroupBox.Controls.Add(this.customerTitleLabel);
            this.customerGroupBox.Controls.Add(this.customerTitleTextBox);
            this.customerGroupBox.Controls.Add(this.customerNameLabel);
            this.customerGroupBox.Controls.Add(this.customerNameTextBox);
            this.customerGroupBox.Controls.Add(this.customerAddressLabel);
            this.customerGroupBox.Controls.Add(this.customerAddressTextBox);
            this.customerGroupBox.Controls.Add(this.customerPostcodeLabel);
            this.customerGroupBox.Controls.Add(this.customerPostcodeTextBox);
            this.customerGroupBox.Controls.Add(this.customerStateLabel);
            this.customerGroupBox.Controls.Add(this.customerStateTextBox);
            this.customerGroupBox.Controls.Add(this.customerPhoneLabel);
            this.customerGroupBox.Controls.Add(this.customerPhoneTextBox);
            this.customerGroupBox.Controls.Add(this.customerCompanyLabel);
            this.customerGroupBox.Controls.Add(this.customerCompanyTextBox);
            this.customerGroupBox.Controls.Add(this.customerFindButton);
            resources.ApplyResources(this.customerGroupBox, "customerGroupBox");
            this.customerGroupBox.Name = "customerGroupBox";
            this.customerGroupBox.TabStop = false;
            // 
            // customerTitleLabel
            // 
            resources.ApplyResources(this.customerTitleLabel, "customerTitleLabel");
            this.customerTitleLabel.Name = "customerTitleLabel";
            // 
            // customerTitleTextBox
            // 
            resources.ApplyResources(this.customerTitleTextBox, "customerTitleTextBox");
            this.customerTitleTextBox.Name = "customerTitleTextBox";
            this.customerTitleTextBox.ReadOnly = true;
            // 
            // customerNameLabel
            // 
            resources.ApplyResources(this.customerNameLabel, "customerNameLabel");
            this.customerNameLabel.Name = "customerNameLabel";
            // 
            // customerNameTextBox
            // 
            resources.ApplyResources(this.customerNameTextBox, "customerNameTextBox");
            this.customerNameTextBox.Name = "customerNameTextBox";
            this.customerNameTextBox.ReadOnly = true;
            // 
            // customerAddressLabel
            // 
            resources.ApplyResources(this.customerAddressLabel, "customerAddressLabel");
            this.customerAddressLabel.Name = "customerAddressLabel";
            // 
            // customerAddressTextBox
            // 
            resources.ApplyResources(this.customerAddressTextBox, "customerAddressTextBox");
            this.customerAddressTextBox.Name = "customerAddressTextBox";
            this.customerAddressTextBox.ReadOnly = true;
            // 
            // customerPostcodeLabel
            // 
            resources.ApplyResources(this.customerPostcodeLabel, "customerPostcodeLabel");
            this.customerPostcodeLabel.Name = "customerPostcodeLabel";
            // 
            // customerPostcodeTextBox
            // 
            resources.ApplyResources(this.customerPostcodeTextBox, "customerPostcodeTextBox");
            this.customerPostcodeTextBox.Name = "customerPostcodeTextBox";
            this.customerPostcodeTextBox.ReadOnly = true;
            // 
            // customerStateLabel
            // 
            resources.ApplyResources(this.customerStateLabel, "customerStateLabel");
            this.customerStateLabel.Name = "customerStateLabel";
            // 
            // customerStateTextBox
            // 
            resources.ApplyResources(this.customerStateTextBox, "customerStateTextBox");
            this.customerStateTextBox.Name = "customerStateTextBox";
            this.customerStateTextBox.ReadOnly = true;
            // 
            // customerPhoneLabel
            // 
            resources.ApplyResources(this.customerPhoneLabel, "customerPhoneLabel");
            this.customerPhoneLabel.Name = "customerPhoneLabel";
            // 
            // customerPhoneTextBox
            // 
            resources.ApplyResources(this.customerPhoneTextBox, "customerPhoneTextBox");
            this.customerPhoneTextBox.Name = "customerPhoneTextBox";
            this.customerPhoneTextBox.ReadOnly = true;
            // 
            // customerCompanyLabel
            // 
            resources.ApplyResources(this.customerCompanyLabel, "customerCompanyLabel");
            this.customerCompanyLabel.Name = "customerCompanyLabel";
            // 
            // customerCompanyTextBox
            // 
            resources.ApplyResources(this.customerCompanyTextBox, "customerCompanyTextBox");
            this.customerCompanyTextBox.Name = "customerCompanyTextBox";
            this.customerCompanyTextBox.ReadOnly = true;
            // 
            // customerFindButton
            // 
            resources.ApplyResources(this.customerFindButton, "customerFindButton");
            this.customerFindButton.Name = "customerFindButton";
            this.customerFindButton.UseVisualStyleBackColor = true;
            // 
            // newOrderGroupBox
            // 
            this.newOrderGroupBox.Controls.Add(this.recordLabel);
            this.newOrderGroupBox.Controls.Add(this.recordTextBox);
            this.newOrderGroupBox.Controls.Add(this.yearLabel);
            this.newOrderGroupBox.Controls.Add(this.yearTextBox);
            this.newOrderGroupBox.Controls.Add(this.dateLabel);
            this.newOrderGroupBox.Controls.Add(this.dateTextBox);
            this.newOrderGroupBox.Controls.Add(this.timeLabel);
            this.newOrderGroupBox.Controls.Add(this.timeTextBox);
            this.newOrderGroupBox.Controls.Add(this.customerGroupBox);
            this.newOrderGroupBox.Controls.Add(this.itemGroupBox);
            this.newOrderGroupBox.Controls.Add(this.salesPersonLabel);
            this.newOrderGroupBox.Controls.Add(this.salesPersonTextBox);
            this.newOrderGroupBox.Controls.Add(this.totalLabel);
            this.newOrderGroupBox.Controls.Add(this.totalTextBox);
            this.newOrderGroupBox.Controls.Add(this.discountLabel);
            this.newOrderGroupBox.Controls.Add(this.discountRegexTextBox);
            this.newOrderGroupBox.Controls.Add(this.grandTotalLabel);
            this.newOrderGroupBox.Controls.Add(this.grandTotalTextBox);
            resources.ApplyResources(this.newOrderGroupBox, "newOrderGroupBox");
            this.newOrderGroupBox.Name = "newOrderGroupBox";
            this.newOrderGroupBox.TabStop = false;
            // 
            // recordLabel
            // 
            resources.ApplyResources(this.recordLabel, "recordLabel");
            this.recordLabel.Name = "recordLabel";
            // 
            // recordTextBox
            // 
            resources.ApplyResources(this.recordTextBox, "recordTextBox");
            this.recordTextBox.Name = "recordTextBox";
            this.recordTextBox.ReadOnly = true;
            // 
            // yearLabel
            // 
            resources.ApplyResources(this.yearLabel, "yearLabel");
            this.yearLabel.Name = "yearLabel";
            // 
            // yearTextBox
            // 
            resources.ApplyResources(this.yearTextBox, "yearTextBox");
            this.yearTextBox.Name = "yearTextBox";
            this.yearTextBox.ReadOnly = true;
            // 
            // dateLabel
            // 
            resources.ApplyResources(this.dateLabel, "dateLabel");
            this.dateLabel.Name = "dateLabel";
            // 
            // dateTextBox
            // 
            resources.ApplyResources(this.dateTextBox, "dateTextBox");
            this.dateTextBox.Name = "dateTextBox";
            this.dateTextBox.ReadOnly = true;
            // 
            // timeLabel
            // 
            resources.ApplyResources(this.timeLabel, "timeLabel");
            this.timeLabel.Name = "timeLabel";
            // 
            // timeTextBox
            // 
            resources.ApplyResources(this.timeTextBox, "timeTextBox");
            this.timeTextBox.Name = "timeTextBox";
            this.timeTextBox.ReadOnly = true;
            // 
            // itemGroupBox
            // 
            this.itemGroupBox.Controls.Add(this.orderDetailsControl);
            resources.ApplyResources(this.itemGroupBox, "itemGroupBox");
            this.itemGroupBox.Name = "itemGroupBox";
            this.itemGroupBox.TabStop = false;
            // 
            // salesPersonLabel
            // 
            resources.ApplyResources(this.salesPersonLabel, "salesPersonLabel");
            this.salesPersonLabel.Name = "salesPersonLabel";
            // 
            // salesPersonTextBox
            // 
            resources.ApplyResources(this.salesPersonTextBox, "salesPersonTextBox");
            this.salesPersonTextBox.Name = "salesPersonTextBox";
            // 
            // totalLabel
            // 
            resources.ApplyResources(this.totalLabel, "totalLabel");
            this.totalLabel.Name = "totalLabel";
            // 
            // totalTextBox
            // 
            resources.ApplyResources(this.totalTextBox, "totalTextBox");
            this.totalTextBox.Name = "totalTextBox";
            this.totalTextBox.ReadOnly = true;
            // 
            // discountLabel
            // 
            resources.ApplyResources(this.discountLabel, "discountLabel");
            this.discountLabel.Name = "discountLabel";
            // 
            // discountRegexTextBox
            // 
            this.discountRegexTextBox.CustomPattern = "^()$";
            resources.ApplyResources(this.discountRegexTextBox, "discountRegexTextBox");
            this.discountRegexTextBox.Name = "discountRegexTextBox";
            // 
            // grandTotalLabel
            // 
            resources.ApplyResources(this.grandTotalLabel, "grandTotalLabel");
            this.grandTotalLabel.Name = "grandTotalLabel";
            // 
            // grandTotalTextBox
            // 
            resources.ApplyResources(this.grandTotalTextBox, "grandTotalTextBox");
            this.grandTotalTextBox.Name = "grandTotalTextBox";
            this.grandTotalTextBox.ReadOnly = true;
            // 
            // saveButton
            // 
            resources.ApplyResources(this.saveButton, "saveButton");
            this.saveButton.Name = "saveButton";
            this.saveButton.UseVisualStyleBackColor = true;
            // 
            // printButton
            // 
            resources.ApplyResources(this.printButton, "printButton");
            this.printButton.Name = "printButton";
            this.printButton.UseVisualStyleBackColor = true;
            // 
            // orderDetailsControl
            // 
            this.orderDetailsControl.AddButtonName = "Add";
            this.orderDetailsControl.DataSetSource = null;
            resources.ApplyResources(this.orderDetailsControl, "orderDetailsControl");
            this.orderDetailsControl.Name = "orderDetailsControl";
            // 
            // OrderForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.newOrderGroupBox);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.printButton);
            this.KeyPreview = true;
            this.Name = "OrderForm";
            this.customerGroupBox.ResumeLayout(false);
            this.customerGroupBox.PerformLayout();
            this.newOrderGroupBox.ResumeLayout(false);
            this.newOrderGroupBox.PerformLayout();
            this.itemGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox customerGroupBox;
        private System.Windows.Forms.Button customerFindButton;
        private System.Windows.Forms.Label customerPostcodeLabel;
        private System.Windows.Forms.Label customerAddressLabel;
        private System.Windows.Forms.Label customerNameLabel;
        private System.Windows.Forms.Label customerTitleLabel;
        private System.Windows.Forms.Label customerStateLabel;
        private System.Windows.Forms.Label customerPhoneLabel;
        private System.Windows.Forms.Label customerCompanyLabel;
        private System.Windows.Forms.TextBox customerCompanyTextBox;
        private System.Windows.Forms.TextBox customerPhoneTextBox;
        private System.Windows.Forms.TextBox customerStateTextBox;
        private System.Windows.Forms.TextBox customerPostcodeTextBox;
        private System.Windows.Forms.TextBox customerAddressTextBox;
        private System.Windows.Forms.TextBox customerNameTextBox;
        private System.Windows.Forms.TextBox customerTitleTextBox;
        private System.Windows.Forms.GroupBox newOrderGroupBox;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button printButton;
        private System.Windows.Forms.Label yearLabel;
        private System.Windows.Forms.TextBox yearTextBox;
        private System.Windows.Forms.TextBox recordTextBox;
        private System.Windows.Forms.Label recordLabel;
        private System.Windows.Forms.GroupBox itemGroupBox;
        private System.Windows.Forms.Label timeLabel;
        private System.Windows.Forms.TextBox timeTextBox;
        private System.Windows.Forms.TextBox dateTextBox;
        private System.Windows.Forms.Label dateLabel;
        private System.Windows.Forms.Label salesPersonLabel;
        private System.Windows.Forms.TextBox grandTotalTextBox;
        private System.Windows.Forms.TextBox totalTextBox;
        private System.Windows.Forms.Label grandTotalLabel;
        private System.Windows.Forms.Label discountLabel;
        private System.Windows.Forms.Label totalLabel;
        private System.Windows.Forms.TextBox salesPersonTextBox;
        private CustomControl.RegexTextBox discountRegexTextBox;
        private OrderDetailsControl orderDetailsControl;
    }
}