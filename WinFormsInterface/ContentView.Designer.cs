using System.ComponentModel;
using System.Windows.Forms;

namespace WinFormsInterface
{
    partial class ContentView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ContentView));
            this.BasisSplitContainer = new System.Windows.Forms.SplitContainer();
            this.NameGroupBox = new System.Windows.Forms.GroupBox();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.ContentGroupBox = new System.Windows.Forms.GroupBox();
            this.ContentTextBox = new System.Windows.Forms.TextBox();
            this.CommandsToolStripContainer = new System.Windows.Forms.ToolStripContainer();
            this.CommandsToolStrip = new System.Windows.Forms.ToolStrip();
            this.ApplyToolStripLabel = new System.Windows.Forms.ToolStripLabel();
            this.ApplyToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.CancelToolStripLabel = new System.Windows.Forms.ToolStripLabel();
            this.CancelToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.BasisSplitContainer.Panel1.SuspendLayout();
            this.BasisSplitContainer.Panel2.SuspendLayout();
            this.BasisSplitContainer.SuspendLayout();
            this.NameGroupBox.SuspendLayout();
            this.ContentGroupBox.SuspendLayout();
            this.CommandsToolStripContainer.ContentPanel.SuspendLayout();
            this.CommandsToolStripContainer.TopToolStripPanel.SuspendLayout();
            this.CommandsToolStripContainer.SuspendLayout();
            this.CommandsToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // BasisSplitContainer
            // 
            this.BasisSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BasisSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.BasisSplitContainer.Name = "BasisSplitContainer";
            this.BasisSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // BasisSplitContainer.Panel1
            // 
            this.BasisSplitContainer.Panel1.Controls.Add(this.NameGroupBox);
            // 
            // BasisSplitContainer.Panel2
            // 
            this.BasisSplitContainer.Panel2.Controls.Add(this.ContentGroupBox);
            this.BasisSplitContainer.Size = new System.Drawing.Size(479, 196);
            this.BasisSplitContainer.SplitterDistance = 94;
            this.BasisSplitContainer.TabIndex = 0;
            // 
            // NameGroupBox
            // 
            this.NameGroupBox.Controls.Add(this.NameTextBox);
            this.NameGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NameGroupBox.Location = new System.Drawing.Point(0, 0);
            this.NameGroupBox.Name = "NameGroupBox";
            this.NameGroupBox.Size = new System.Drawing.Size(479, 94);
            this.NameGroupBox.TabIndex = 0;
            this.NameGroupBox.TabStop = false;
            this.NameGroupBox.Text = "Наименование";
            // 
            // NameTextBox
            // 
            this.NameTextBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.NameTextBox.Location = new System.Drawing.Point(3, 18);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(473, 22);
            this.NameTextBox.TabIndex = 0;
            // 
            // ContentGroupBox
            // 
            this.ContentGroupBox.Controls.Add(this.ContentTextBox);
            this.ContentGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ContentGroupBox.Location = new System.Drawing.Point(0, 0);
            this.ContentGroupBox.Name = "ContentGroupBox";
            this.ContentGroupBox.Size = new System.Drawing.Size(479, 98);
            this.ContentGroupBox.TabIndex = 1;
            this.ContentGroupBox.TabStop = false;
            this.ContentGroupBox.Text = "Значение";
            // 
            // ContentTextBox
            // 
            this.ContentTextBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.ContentTextBox.Location = new System.Drawing.Point(3, 18);
            this.ContentTextBox.Name = "ContentTextBox";
            this.ContentTextBox.Size = new System.Drawing.Size(473, 22);
            this.ContentTextBox.TabIndex = 1;
            // 
            // CommandsToolStripContainer
            // 
            this.CommandsToolStripContainer.BottomToolStripPanelVisible = false;
            // 
            // CommandsToolStripContainer.ContentPanel
            // 
            this.CommandsToolStripContainer.ContentPanel.Controls.Add(this.BasisSplitContainer);
            this.CommandsToolStripContainer.ContentPanel.Size = new System.Drawing.Size(479, 196);
            this.CommandsToolStripContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CommandsToolStripContainer.LeftToolStripPanelVisible = false;
            this.CommandsToolStripContainer.Location = new System.Drawing.Point(0, 0);
            this.CommandsToolStripContainer.Name = "CommandsToolStripContainer";
            this.CommandsToolStripContainer.RightToolStripPanelVisible = false;
            this.CommandsToolStripContainer.Size = new System.Drawing.Size(479, 223);
            this.CommandsToolStripContainer.TabIndex = 1;
            this.CommandsToolStripContainer.Text = "toolStripContainer1";
            // 
            // CommandsToolStripContainer.TopToolStripPanel
            // 
            this.CommandsToolStripContainer.TopToolStripPanel.Controls.Add(this.CommandsToolStrip);
            // 
            // CommandsToolStrip
            // 
            this.CommandsToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.CommandsToolStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.CommandsToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ApplyToolStripLabel,
            this.ApplyToolStripButton,
            this.CancelToolStripLabel,
            this.CancelToolStripButton});
            this.CommandsToolStrip.Location = new System.Drawing.Point(3, 0);
            this.CommandsToolStrip.Name = "CommandsToolStrip";
            this.CommandsToolStrip.Size = new System.Drawing.Size(161, 27);
            this.CommandsToolStrip.TabIndex = 0;
            // 
            // ApplyToolStripLabel
            // 
            this.ApplyToolStripLabel.Name = "ApplyToolStripLabel";
            this.ApplyToolStripLabel.Size = new System.Drawing.Size(48, 24);
            this.ApplyToolStripLabel.Text = "Apply";
            // 
            // ApplyToolStripButton
            // 
            this.ApplyToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ApplyToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("ApplyToolStripButton.Image")));
            this.ApplyToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ApplyToolStripButton.Name = "ApplyToolStripButton";
            this.ApplyToolStripButton.Size = new System.Drawing.Size(24, 24);
            this.ApplyToolStripButton.Text = "Apply";
            this.ApplyToolStripButton.Click += new System.EventHandler(this.ApplyToolStripButton_Click);
            // 
            // CancelToolStripLabel
            // 
            this.CancelToolStripLabel.Name = "CancelToolStripLabel";
            this.CancelToolStripLabel.Size = new System.Drawing.Size(53, 24);
            this.CancelToolStripLabel.Text = "Cancel";
            // 
            // CancelToolStripButton
            // 
            this.CancelToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.CancelToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("CancelToolStripButton.Image")));
            this.CancelToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CancelToolStripButton.Name = "CancelToolStripButton";
            this.CancelToolStripButton.Size = new System.Drawing.Size(24, 24);
            this.CancelToolStripButton.Text = "Cancel";
            this.CancelToolStripButton.Click += new System.EventHandler(this.CancelToolStripButton_Click);
            // 
            // ContentView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(479, 223);
            this.Controls.Add(this.CommandsToolStripContainer);
            this.Name = "ContentView";
            this.Text = "ContentView";
            this.Load += new System.EventHandler(this.ContentView_Load);
            this.BasisSplitContainer.Panel1.ResumeLayout(false);
            this.BasisSplitContainer.Panel2.ResumeLayout(false);
            this.BasisSplitContainer.ResumeLayout(false);
            this.NameGroupBox.ResumeLayout(false);
            this.NameGroupBox.PerformLayout();
            this.ContentGroupBox.ResumeLayout(false);
            this.ContentGroupBox.PerformLayout();
            this.CommandsToolStripContainer.ContentPanel.ResumeLayout(false);
            this.CommandsToolStripContainer.TopToolStripPanel.ResumeLayout(false);
            this.CommandsToolStripContainer.TopToolStripPanel.PerformLayout();
            this.CommandsToolStripContainer.ResumeLayout(false);
            this.CommandsToolStripContainer.PerformLayout();
            this.CommandsToolStrip.ResumeLayout(false);
            this.CommandsToolStrip.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private SplitContainer BasisSplitContainer;
        private GroupBox NameGroupBox;
        private TextBox NameTextBox;
        private GroupBox ContentGroupBox;
        private TextBox ContentTextBox;
        private ToolStripContainer CommandsToolStripContainer;
        private ToolStrip CommandsToolStrip;
        private ToolStripLabel ApplyToolStripLabel;
        private ToolStripButton ApplyToolStripButton;
        private ToolStripLabel CancelToolStripLabel;
        private ToolStripButton CancelToolStripButton;
    }
}