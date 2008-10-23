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
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.customersToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.productsToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolsToolStripDropDownButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.databaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.connectionStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.newOrderButton = new System.Windows.Forms.Button();
            this.toolStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            this.toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.customersToolStripButton,
            this.productsToolStripButton,
            this.toolsToolStripDropDownButton});
            resources.ApplyResources(this.toolStrip, "toolStrip");
            this.toolStrip.Name = "toolStrip";
            // 
            // customersToolStripButton
            // 
            this.customersToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.customersToolStripButton.Image = global::MillionBeauty.Properties.Resources.Customers;
            resources.ApplyResources(this.customersToolStripButton, "customersToolStripButton");
            this.customersToolStripButton.Name = "customersToolStripButton";
            // 
            // productsToolStripButton
            // 
            this.productsToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.productsToolStripButton.Image = global::MillionBeauty.Properties.Resources.Products;
            resources.ApplyResources(this.productsToolStripButton, "productsToolStripButton");
            this.productsToolStripButton.Name = "productsToolStripButton";
            // 
            // toolsToolStripDropDownButton
            // 
            this.toolsToolStripDropDownButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolsToolStripDropDownButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.databaseToolStripMenuItem});
            this.toolsToolStripDropDownButton.Image = global::MillionBeauty.Properties.Resources.Tools;
            resources.ApplyResources(this.toolsToolStripDropDownButton, "toolsToolStripDropDownButton");
            this.toolsToolStripDropDownButton.Name = "toolsToolStripDropDownButton";
            // 
            // databaseToolStripMenuItem
            // 
            this.databaseToolStripMenuItem.Name = "databaseToolStripMenuItem";
            resources.ApplyResources(this.databaseToolStripMenuItem, "databaseToolStripMenuItem");
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectionStatusLabel});
            resources.ApplyResources(this.statusStrip, "statusStrip");
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.SizingGrip = false;
            // 
            // connectionStatusLabel
            // 
            this.connectionStatusLabel.Name = "connectionStatusLabel";
            resources.ApplyResources(this.connectionStatusLabel, "connectionStatusLabel");
            // 
            // newOrderButton
            // 
            resources.ApplyResources(this.newOrderButton, "newOrderButton");
            this.newOrderButton.Name = "newOrderButton";
            this.newOrderButton.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.newOrderButton);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.statusStrip);
            this.KeyPreview = true;
            this.Name = "MainForm";
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton customersToolStripButton;
        private System.Windows.Forms.ToolStripButton productsToolStripButton;
        private System.Windows.Forms.ToolStripDropDownButton toolsToolStripDropDownButton;
        private System.Windows.Forms.ToolStripMenuItem databaseToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel connectionStatusLabel;
        private System.Windows.Forms.Button newOrderButton;
    }
}

