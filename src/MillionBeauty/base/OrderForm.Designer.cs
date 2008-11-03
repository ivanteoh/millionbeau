namespace MillionBeauty
{
    partial class OrderForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrderForm));
            this.customerGroupBox = new System.Windows.Forms.GroupBox();
            this.customerStateTextBox = new System.Windows.Forms.TextBox();
            this.customerCompanyLabel = new System.Windows.Forms.Label();
            this.customerCompanyTextBox = new System.Windows.Forms.TextBox();
            this.customerFindButton = new System.Windows.Forms.Button();
            this.customerStateLabel = new System.Windows.Forms.Label();
            this.customerTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.customerNameLabel = new System.Windows.Forms.Label();
            this.customerPhoneLabel = new System.Windows.Forms.Label();
            this.customerPhoneTextBox = new System.Windows.Forms.TextBox();
            this.customerPostcodeTextBox = new System.Windows.Forms.TextBox();
            this.customerNameTextBox = new System.Windows.Forms.TextBox();
            this.customerPostcodeLabel = new System.Windows.Forms.Label();
            this.customerAddressLabel = new System.Windows.Forms.Label();
            this.customerAddressTextBox = new System.Windows.Forms.TextBox();
            this.customerTitleTextBox = new System.Windows.Forms.TextBox();
            this.customerTitleLabel = new System.Windows.Forms.Label();
            this.orderGroupBox = new System.Windows.Forms.GroupBox();
            this.orderTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.idTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.dateLabel = new System.Windows.Forms.Label();
            this.dateTextBox = new System.Windows.Forms.TextBox();
            this.timeLabel = new System.Windows.Forms.Label();
            this.timeTextBox = new System.Windows.Forms.TextBox();
            this.recordTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.recordLabel = new System.Windows.Forms.Label();
            this.recordTextBox = new System.Windows.Forms.TextBox();
            this.yearLabel = new System.Windows.Forms.Label();
            this.yearTextBox = new System.Windows.Forms.TextBox();
            this.itemGroupBox = new System.Windows.Forms.GroupBox();
            this.totalTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
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
            this.editButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.orderDetailsControl = new MillionBeauty.OrderDetailsControl();
            this.customerGroupBox.SuspendLayout();
            this.customerTableLayoutPanel.SuspendLayout();
            this.orderGroupBox.SuspendLayout();
            this.orderTableLayoutPanel.SuspendLayout();
            this.idTableLayoutPanel.SuspendLayout();
            this.recordTableLayoutPanel.SuspendLayout();
            this.itemGroupBox.SuspendLayout();
            this.totalTableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // customerGroupBox
            // 
            this.customerGroupBox.Controls.Add(this.customerTableLayoutPanel);
            resources.ApplyResources(this.customerGroupBox, "customerGroupBox");
            this.customerGroupBox.Name = "customerGroupBox";
            this.customerGroupBox.TabStop = false;
            // 
            // customerStateTextBox
            // 
            resources.ApplyResources(this.customerStateTextBox, "customerStateTextBox");
            this.customerStateTextBox.Name = "customerStateTextBox";
            this.customerStateTextBox.ReadOnly = true;
            // 
            // customerCompanyLabel
            // 
            resources.ApplyResources(this.customerCompanyLabel, "customerCompanyLabel");
            this.customerCompanyLabel.Name = "customerCompanyLabel";
            // 
            // customerCompanyTextBox
            // 
            this.customerTableLayoutPanel.SetColumnSpan(this.customerCompanyTextBox, 3);
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
            // customerStateLabel
            // 
            resources.ApplyResources(this.customerStateLabel, "customerStateLabel");
            this.customerStateLabel.Name = "customerStateLabel";
            // 
            // customerTableLayoutPanel
            // 
            resources.ApplyResources(this.customerTableLayoutPanel, "customerTableLayoutPanel");
            this.customerTableLayoutPanel.Controls.Add(this.customerTitleLabel, 0, 0);
            this.customerTableLayoutPanel.Controls.Add(this.customerTitleTextBox, 1, 0);
            this.customerTableLayoutPanel.Controls.Add(this.customerNameLabel, 2, 0);
            this.customerTableLayoutPanel.Controls.Add(this.customerNameTextBox, 3, 0);
            this.customerTableLayoutPanel.Controls.Add(this.customerAddressLabel, 0, 1);
            this.customerTableLayoutPanel.Controls.Add(this.customerAddressTextBox, 1, 1);
            this.customerTableLayoutPanel.Controls.Add(this.customerPostcodeLabel, 0, 2);
            this.customerTableLayoutPanel.Controls.Add(this.customerPostcodeTextBox, 1, 2);
            this.customerTableLayoutPanel.Controls.Add(this.customerStateLabel, 2, 2);
            this.customerTableLayoutPanel.Controls.Add(this.customerStateTextBox, 3, 2);
            this.customerTableLayoutPanel.Controls.Add(this.customerPhoneLabel, 0, 3);
            this.customerTableLayoutPanel.Controls.Add(this.customerPhoneTextBox, 1, 3);
            this.customerTableLayoutPanel.Controls.Add(this.customerCompanyLabel, 0, 4);
            this.customerTableLayoutPanel.Controls.Add(this.customerCompanyTextBox, 1, 4);
            this.customerTableLayoutPanel.Controls.Add(this.customerFindButton, 3, 5);
            this.customerTableLayoutPanel.Name = "customerTableLayoutPanel";
            // 
            // customerNameLabel
            // 
            resources.ApplyResources(this.customerNameLabel, "customerNameLabel");
            this.customerNameLabel.Name = "customerNameLabel";
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
            // customerPostcodeTextBox
            // 
            resources.ApplyResources(this.customerPostcodeTextBox, "customerPostcodeTextBox");
            this.customerPostcodeTextBox.Name = "customerPostcodeTextBox";
            this.customerPostcodeTextBox.ReadOnly = true;
            // 
            // customerNameTextBox
            // 
            resources.ApplyResources(this.customerNameTextBox, "customerNameTextBox");
            this.customerNameTextBox.Name = "customerNameTextBox";
            this.customerNameTextBox.ReadOnly = true;
            // 
            // customerPostcodeLabel
            // 
            resources.ApplyResources(this.customerPostcodeLabel, "customerPostcodeLabel");
            this.customerPostcodeLabel.Name = "customerPostcodeLabel";
            // 
            // customerAddressLabel
            // 
            resources.ApplyResources(this.customerAddressLabel, "customerAddressLabel");
            this.customerAddressLabel.Name = "customerAddressLabel";
            // 
            // customerAddressTextBox
            // 
            this.customerTableLayoutPanel.SetColumnSpan(this.customerAddressTextBox, 3);
            resources.ApplyResources(this.customerAddressTextBox, "customerAddressTextBox");
            this.customerAddressTextBox.Name = "customerAddressTextBox";
            this.customerAddressTextBox.ReadOnly = true;
            // 
            // customerTitleTextBox
            // 
            resources.ApplyResources(this.customerTitleTextBox, "customerTitleTextBox");
            this.customerTitleTextBox.Name = "customerTitleTextBox";
            this.customerTitleTextBox.ReadOnly = true;
            // 
            // customerTitleLabel
            // 
            resources.ApplyResources(this.customerTitleLabel, "customerTitleLabel");
            this.customerTitleLabel.Name = "customerTitleLabel";
            // 
            // orderGroupBox
            // 
            resources.ApplyResources(this.orderGroupBox, "orderGroupBox");
            this.orderGroupBox.Controls.Add(this.orderTableLayoutPanel);
            this.orderGroupBox.Name = "orderGroupBox";
            this.orderGroupBox.TabStop = false;
            // 
            // orderTableLayoutPanel
            // 
            resources.ApplyResources(this.orderTableLayoutPanel, "orderTableLayoutPanel");
            this.orderTableLayoutPanel.Controls.Add(this.idTableLayoutPanel, 0, 0);
            this.orderTableLayoutPanel.Controls.Add(this.customerGroupBox, 0, 1);
            this.orderTableLayoutPanel.Controls.Add(this.itemGroupBox, 0, 2);
            this.orderTableLayoutPanel.Controls.Add(this.totalTableLayoutPanel, 0, 3);
            this.orderTableLayoutPanel.Name = "orderTableLayoutPanel";
            // 
            // idTableLayoutPanel
            // 
            resources.ApplyResources(this.idTableLayoutPanel, "idTableLayoutPanel");
            this.idTableLayoutPanel.Controls.Add(this.recordTableLayoutPanel, 0, 0);
            this.idTableLayoutPanel.Controls.Add(this.timeTextBox, 3, 1);
            this.idTableLayoutPanel.Controls.Add(this.dateTextBox, 1, 1);
            this.idTableLayoutPanel.Controls.Add(this.timeLabel, 2, 1);
            this.idTableLayoutPanel.Controls.Add(this.dateLabel, 0, 1);
            this.idTableLayoutPanel.Name = "idTableLayoutPanel";
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
            // recordTableLayoutPanel
            // 
            resources.ApplyResources(this.recordTableLayoutPanel, "recordTableLayoutPanel");
            this.idTableLayoutPanel.SetColumnSpan(this.recordTableLayoutPanel, 3);
            this.recordTableLayoutPanel.Controls.Add(this.recordLabel, 0, 0);
            this.recordTableLayoutPanel.Controls.Add(this.recordTextBox, 1, 0);
            this.recordTableLayoutPanel.Controls.Add(this.yearLabel, 2, 0);
            this.recordTableLayoutPanel.Controls.Add(this.yearTextBox, 3, 0);
            this.recordTableLayoutPanel.Name = "recordTableLayoutPanel";
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
            // itemGroupBox
            // 
            this.itemGroupBox.Controls.Add(this.orderDetailsControl);
            resources.ApplyResources(this.itemGroupBox, "itemGroupBox");
            this.itemGroupBox.Name = "itemGroupBox";
            this.itemGroupBox.TabStop = false;
            // 
            // totalTableLayoutPanel
            // 
            resources.ApplyResources(this.totalTableLayoutPanel, "totalTableLayoutPanel");
            this.totalTableLayoutPanel.Controls.Add(this.salesPersonLabel, 0, 0);
            this.totalTableLayoutPanel.Controls.Add(this.salesPersonTextBox, 1, 0);
            this.totalTableLayoutPanel.Controls.Add(this.totalLabel, 2, 0);
            this.totalTableLayoutPanel.Controls.Add(this.totalTextBox, 3, 0);
            this.totalTableLayoutPanel.Controls.Add(this.discountLabel, 2, 1);
            this.totalTableLayoutPanel.Controls.Add(this.discountRegexTextBox, 3, 1);
            this.totalTableLayoutPanel.Controls.Add(this.grandTotalLabel, 2, 2);
            this.totalTableLayoutPanel.Controls.Add(this.grandTotalTextBox, 3, 2);
            this.totalTableLayoutPanel.Name = "totalTableLayoutPanel";
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
            // editButton
            // 
            resources.ApplyResources(this.editButton, "editButton");
            this.editButton.Name = "editButton";
            this.editButton.UseVisualStyleBackColor = true;
            // 
            // deleteButton
            // 
            resources.ApplyResources(this.deleteButton, "deleteButton");
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.UseVisualStyleBackColor = true;
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
            this.Controls.Add(this.orderGroupBox);
            this.Controls.Add(this.editButton);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.printButton);
            this.KeyPreview = true;
            this.Name = "OrderForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.customerGroupBox.ResumeLayout(false);
            this.customerTableLayoutPanel.ResumeLayout(false);
            this.customerTableLayoutPanel.PerformLayout();
            this.orderGroupBox.ResumeLayout(false);
            this.orderTableLayoutPanel.ResumeLayout(false);
            this.idTableLayoutPanel.ResumeLayout(false);
            this.idTableLayoutPanel.PerformLayout();
            this.recordTableLayoutPanel.ResumeLayout(false);
            this.recordTableLayoutPanel.PerformLayout();
            this.itemGroupBox.ResumeLayout(false);
            this.totalTableLayoutPanel.ResumeLayout(false);
            this.totalTableLayoutPanel.PerformLayout();
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
        private System.Windows.Forms.GroupBox orderGroupBox;
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
        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.TableLayoutPanel orderTableLayoutPanel;
        private System.Windows.Forms.TableLayoutPanel idTableLayoutPanel;
        private System.Windows.Forms.TableLayoutPanel totalTableLayoutPanel;
        private System.Windows.Forms.TableLayoutPanel recordTableLayoutPanel;
        private System.Windows.Forms.TableLayoutPanel customerTableLayoutPanel;
    }
}