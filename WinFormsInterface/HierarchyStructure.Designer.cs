using System.ComponentModel;
using System.Windows.Forms;

namespace WinFormsInterface
{
    partial class HierarchyStructure
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(HierarchyStructure));
            this.NameGroupBox = new System.Windows.Forms.GroupBox();
            this.HierarchyTreeView = new System.Windows.Forms.TreeView();
            this.CommandsToolStripContainer = new System.Windows.Forms.ToolStripContainer();
            this.CommandsToolStrip = new System.Windows.Forms.ToolStrip();
            this.SelectToolStripLabel = new System.Windows.Forms.ToolStripLabel();
            this.SelectToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.CancelToolStripLabel = new System.Windows.Forms.ToolStripLabel();
            this.CancelToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.RefreshToolStripLabel = new System.Windows.Forms.ToolStripLabel();
            this.RefreshToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.NameGroupBox.SuspendLayout();
            this.CommandsToolStripContainer.ContentPanel.SuspendLayout();
            this.CommandsToolStripContainer.TopToolStripPanel.SuspendLayout();
            this.CommandsToolStripContainer.SuspendLayout();
            this.CommandsToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // NameGroupBox
            // 
            this.NameGroupBox.Controls.Add(this.HierarchyTreeView);
            this.NameGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NameGroupBox.Location = new System.Drawing.Point(0, 0);
            this.NameGroupBox.Name = "NameGroupBox";
            this.NameGroupBox.Size = new System.Drawing.Size(377, 521);
            this.NameGroupBox.TabIndex = 0;
            this.NameGroupBox.TabStop = false;
            this.NameGroupBox.Text = "Выберите каталог куда переместить";
            // 
            // HierarchyTreeView
            // 
            this.HierarchyTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HierarchyTreeView.Location = new System.Drawing.Point(3, 18);
            this.HierarchyTreeView.Name = "HierarchyTreeView";
            this.HierarchyTreeView.Size = new System.Drawing.Size(371, 500);
            this.HierarchyTreeView.TabIndex = 0;
            // 
            // CommandsToolStripContainer
            // 
            this.CommandsToolStripContainer.BottomToolStripPanelVisible = false;
            // 
            // CommandsToolStripContainer.ContentPanel
            // 
            this.CommandsToolStripContainer.ContentPanel.Controls.Add(this.NameGroupBox);
            this.CommandsToolStripContainer.ContentPanel.Size = new System.Drawing.Size(377, 521);
            this.CommandsToolStripContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CommandsToolStripContainer.LeftToolStripPanelVisible = false;
            this.CommandsToolStripContainer.Location = new System.Drawing.Point(0, 0);
            this.CommandsToolStripContainer.Name = "CommandsToolStripContainer";
            this.CommandsToolStripContainer.RightToolStripPanelVisible = false;
            this.CommandsToolStripContainer.Size = new System.Drawing.Size(377, 548);
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
            this.SelectToolStripLabel,
            this.SelectToolStripButton,
            this.toolStripSeparator2,
            this.CancelToolStripLabel,
            this.CancelToolStripButton,
            this.toolStripSeparator1,
            this.RefreshToolStripLabel,
            this.RefreshToolStripButton});
            this.CommandsToolStrip.Location = new System.Drawing.Point(3, 0);
            this.CommandsToolStrip.Name = "CommandsToolStrip";
            this.CommandsToolStrip.Size = new System.Drawing.Size(256, 27);
            this.CommandsToolStrip.TabIndex = 0;
            // 
            // SelectToolStripLabel
            // 
            this.SelectToolStripLabel.Name = "SelectToolStripLabel";
            this.SelectToolStripLabel.Size = new System.Drawing.Size(49, 24);
            this.SelectToolStripLabel.Text = "Select";
            // 
            // SelectToolStripButton
            // 
            this.SelectToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.SelectToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("SelectToolStripButton.Image")));
            this.SelectToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SelectToolStripButton.Name = "SelectToolStripButton";
            this.SelectToolStripButton.Size = new System.Drawing.Size(24, 24);
            this.SelectToolStripButton.Text = "Select";
            this.SelectToolStripButton.Click += new System.EventHandler(this.SelectToolStripButton_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 27);
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
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // RefreshToolStripLabel
            // 
            this.RefreshToolStripLabel.Name = "RefreshToolStripLabel";
            this.RefreshToolStripLabel.Size = new System.Drawing.Size(58, 24);
            this.RefreshToolStripLabel.Text = "Refresh";
            // 
            // RefreshToolStripButton
            // 
            this.RefreshToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.RefreshToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("RefreshToolStripButton.Image")));
            this.RefreshToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.RefreshToolStripButton.Name = "RefreshToolStripButton";
            this.RefreshToolStripButton.Size = new System.Drawing.Size(24, 24);
            this.RefreshToolStripButton.Text = "Refresh";
            this.RefreshToolStripButton.Click += new System.EventHandler(this.RefreshToolStripButton_Click);
            // 
            // HierarchyStructure
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(377, 548);
            this.Controls.Add(this.CommandsToolStripContainer);
            this.Name = "HierarchyStructure";
            this.Text = "Выбор каталога";
            this.Load += new System.EventHandler(this.HierarchyView_Load);
            this.NameGroupBox.ResumeLayout(false);
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
        private GroupBox NameGroupBox;
        private ToolStripContainer CommandsToolStripContainer;
        private ToolStrip CommandsToolStrip;
        private ToolStripLabel SelectToolStripLabel;
        private ToolStripButton SelectToolStripButton;
        private ToolStripLabel CancelToolStripLabel;
        private ToolStripButton CancelToolStripButton;
        private TreeView HierarchyTreeView;
        private ToolStripLabel RefreshToolStripLabel;
        private ToolStripButton RefreshToolStripButton;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripSeparator toolStripSeparator1;
    }
}