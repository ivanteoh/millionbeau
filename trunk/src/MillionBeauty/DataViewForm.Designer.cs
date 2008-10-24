namespace MillionBeauty
{
    partial class DataViewForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DataViewForm));
            this.dataGridViewControl = new MillionBeauty.DataGridViewControl();
            this.SuspendLayout();
            // 
            // dataGridViewControl
            // 
            this.dataGridViewControl.DataSetSource = null;
            resources.ApplyResources(this.dataGridViewControl, "dataGridViewControl");
            this.dataGridViewControl.Name = "dataGridViewControl";
            this.dataGridViewControl.OkButtonName = "Add";
            // 
            // DataViewForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridViewControl);
            this.KeyPreview = true;
            this.Name = "DataViewForm";
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridViewControl dataGridViewControl;
    }
}