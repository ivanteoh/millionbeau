namespace MillionBeauty
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.newOrderButton = new System.Windows.Forms.Button();
            this.ordersButton = new System.Windows.Forms.Button();
            this.customersButton = new System.Windows.Forms.Button();
            this.productsButton = new System.Windows.Forms.Button();
            this.optionsButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.customersTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.customersLabel = new System.Windows.Forms.Label();
            this.productsTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.productsLabel = new System.Windows.Forms.Label();
            this.optionsTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.optionsLabel = new System.Windows.Forms.Label();
            this.newOrderTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.newOrderLabel = new System.Windows.Forms.Label();
            this.orderTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.ordersLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel.SuspendLayout();
            this.customersTableLayoutPanel.SuspendLayout();
            this.productsTableLayoutPanel.SuspendLayout();
            this.optionsTableLayoutPanel.SuspendLayout();
            this.newOrderTableLayoutPanel.SuspendLayout();
            this.orderTableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // newOrderButton
            // 
            this.newOrderButton.Image = global::MillionBeauty.Properties.Resources.AddOrder;
            resources.ApplyResources(this.newOrderButton, "newOrderButton");
            this.newOrderButton.Name = "newOrderButton";
            this.newOrderButton.UseVisualStyleBackColor = true;
            // 
            // ordersButton
            // 
            this.ordersButton.Image = global::MillionBeauty.Properties.Resources.Orders;
            resources.ApplyResources(this.ordersButton, "ordersButton");
            this.ordersButton.Name = "ordersButton";
            this.ordersButton.UseVisualStyleBackColor = true;
            // 
            // customersButton
            // 
            this.customersButton.Image = global::MillionBeauty.Properties.Resources.Customers;
            resources.ApplyResources(this.customersButton, "customersButton");
            this.customersButton.Name = "customersButton";
            this.customersButton.UseVisualStyleBackColor = true;
            // 
            // productsButton
            // 
            this.productsButton.Image = global::MillionBeauty.Properties.Resources.Products;
            resources.ApplyResources(this.productsButton, "productsButton");
            this.productsButton.Name = "productsButton";
            this.productsButton.UseVisualStyleBackColor = true;
            // 
            // optionsButton
            // 
            this.optionsButton.Image = global::MillionBeauty.Properties.Resources.Tools;
            resources.ApplyResources(this.optionsButton, "optionsButton");
            this.optionsButton.Name = "optionsButton";
            this.optionsButton.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel
            // 
            resources.ApplyResources(this.tableLayoutPanel, "tableLayoutPanel");
            this.tableLayoutPanel.Controls.Add(this.customersTableLayoutPanel, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.productsTableLayoutPanel, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.optionsTableLayoutPanel, 0, 2);
            this.tableLayoutPanel.Controls.Add(this.newOrderTableLayoutPanel, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.orderTableLayoutPanel, 1, 1);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            // 
            // customersTableLayoutPanel
            // 
            resources.ApplyResources(this.customersTableLayoutPanel, "customersTableLayoutPanel");
            this.customersTableLayoutPanel.Controls.Add(this.customersButton, 0, 0);
            this.customersTableLayoutPanel.Controls.Add(this.customersLabel, 1, 0);
            this.customersTableLayoutPanel.MinimumSize = new System.Drawing.Size(0, 128);
            this.customersTableLayoutPanel.Name = "customersTableLayoutPanel";
            // 
            // customersLabel
            // 
            resources.ApplyResources(this.customersLabel, "customersLabel");
            this.customersLabel.Name = "customersLabel";
            // 
            // productsTableLayoutPanel
            // 
            resources.ApplyResources(this.productsTableLayoutPanel, "productsTableLayoutPanel");
            this.productsTableLayoutPanel.Controls.Add(this.productsButton, 0, 0);
            this.productsTableLayoutPanel.Controls.Add(this.productsLabel, 1, 0);
            this.productsTableLayoutPanel.Name = "productsTableLayoutPanel";
            // 
            // productsLabel
            // 
            resources.ApplyResources(this.productsLabel, "productsLabel");
            this.productsLabel.Name = "productsLabel";
            // 
            // optionsTableLayoutPanel
            // 
            resources.ApplyResources(this.optionsTableLayoutPanel, "optionsTableLayoutPanel");
            this.optionsTableLayoutPanel.Controls.Add(this.optionsButton, 0, 0);
            this.optionsTableLayoutPanel.Controls.Add(this.optionsLabel, 1, 0);
            this.optionsTableLayoutPanel.Name = "optionsTableLayoutPanel";
            // 
            // optionsLabel
            // 
            resources.ApplyResources(this.optionsLabel, "optionsLabel");
            this.optionsLabel.Name = "optionsLabel";
            // 
            // newOrderTableLayoutPanel
            // 
            resources.ApplyResources(this.newOrderTableLayoutPanel, "newOrderTableLayoutPanel");
            this.newOrderTableLayoutPanel.Controls.Add(this.newOrderButton, 0, 0);
            this.newOrderTableLayoutPanel.Controls.Add(this.newOrderLabel, 1, 0);
            this.newOrderTableLayoutPanel.Name = "newOrderTableLayoutPanel";
            // 
            // newOrderLabel
            // 
            resources.ApplyResources(this.newOrderLabel, "newOrderLabel");
            this.newOrderLabel.Name = "newOrderLabel";
            // 
            // orderTableLayoutPanel
            // 
            resources.ApplyResources(this.orderTableLayoutPanel, "orderTableLayoutPanel");
            this.orderTableLayoutPanel.Controls.Add(this.ordersButton, 0, 0);
            this.orderTableLayoutPanel.Controls.Add(this.ordersLabel, 1, 0);
            this.orderTableLayoutPanel.Name = "orderTableLayoutPanel";
            // 
            // ordersLabel
            // 
            resources.ApplyResources(this.ordersLabel, "ordersLabel");
            this.ordersLabel.Name = "ordersLabel";
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel);
            this.KeyPreview = true;
            this.Name = "MainForm";
            this.tableLayoutPanel.ResumeLayout(false);
            this.customersTableLayoutPanel.ResumeLayout(false);
            this.customersTableLayoutPanel.PerformLayout();
            this.productsTableLayoutPanel.ResumeLayout(false);
            this.productsTableLayoutPanel.PerformLayout();
            this.optionsTableLayoutPanel.ResumeLayout(false);
            this.optionsTableLayoutPanel.PerformLayout();
            this.newOrderTableLayoutPanel.ResumeLayout(false);
            this.newOrderTableLayoutPanel.PerformLayout();
            this.orderTableLayoutPanel.ResumeLayout(false);
            this.orderTableLayoutPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button newOrderButton;
        private System.Windows.Forms.Button ordersButton;
        private System.Windows.Forms.Button customersButton;
        private System.Windows.Forms.Button productsButton;
        private System.Windows.Forms.Button optionsButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.TableLayoutPanel customersTableLayoutPanel;
        private System.Windows.Forms.Label customersLabel;
        private System.Windows.Forms.TableLayoutPanel newOrderTableLayoutPanel;
        private System.Windows.Forms.Label newOrderLabel;
        private System.Windows.Forms.TableLayoutPanel orderTableLayoutPanel;
        private System.Windows.Forms.Label ordersLabel;
        private System.Windows.Forms.TableLayoutPanel productsTableLayoutPanel;
        private System.Windows.Forms.Label productsLabel;
        private System.Windows.Forms.TableLayoutPanel optionsTableLayoutPanel;
        private System.Windows.Forms.Label optionsLabel;
    }
}

