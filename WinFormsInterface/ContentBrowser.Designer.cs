using System.ComponentModel;
using System.Windows.Forms;

namespace WinFormsInterface
{
    partial class ContentBrowser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ContentBrowser));
            this.ContentToolStripContainer = new System.Windows.Forms.ToolStripContainer();
            this.RecordsDataGridView = new System.Windows.Forms.DataGridView();
            this.ContentToolStrip = new System.Windows.Forms.ToolStrip();
            this.RefreshToolStripLabel = new System.Windows.Forms.ToolStripLabel();
            this.RefreshToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.AddToolStripLabel = new System.Windows.Forms.ToolStripLabel();
            this.AddToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.EditToolStripLabel = new System.Windows.Forms.ToolStripLabel();
            this.EditToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.DeleteToolStripLabel = new System.Windows.Forms.ToolStripLabel();
            this.DeleteToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.BasisSplitContainer = new System.Windows.Forms.SplitContainer();
            this.HierarchyToolStripContainer = new System.Windows.Forms.ToolStripContainer();
            this.HierarchyToolStrip = new System.Windows.Forms.ToolStrip();
            this.RefreshHierarchyToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.AddHierarchyToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.EditHierarchytoolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.DeleteHierarchyToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.BottomToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.TopToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.RightToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.LeftToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.ContentPanel = new System.Windows.Forms.ToolStripContentPanel();
            this.HierarchyTreeView = new System.Windows.Forms.TreeView();
            this.ContentToolStripContainer.ContentPanel.SuspendLayout();
            this.ContentToolStripContainer.TopToolStripPanel.SuspendLayout();
            this.ContentToolStripContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RecordsDataGridView)).BeginInit();
            this.ContentToolStrip.SuspendLayout();
            this.BasisSplitContainer.Panel1.SuspendLayout();
            this.BasisSplitContainer.Panel2.SuspendLayout();
            this.BasisSplitContainer.SuspendLayout();
            this.HierarchyToolStripContainer.ContentPanel.SuspendLayout();
            this.HierarchyToolStripContainer.TopToolStripPanel.SuspendLayout();
            this.HierarchyToolStripContainer.SuspendLayout();
            this.HierarchyToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // ContentToolStripContainer
            // 
            // 
            // ContentToolStripContainer.ContentPanel
            // 
            this.ContentToolStripContainer.ContentPanel.Controls.Add(this.RecordsDataGridView);
            this.ContentToolStripContainer.ContentPanel.Size = new System.Drawing.Size(531, 521);
            this.ContentToolStripContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ContentToolStripContainer.Location = new System.Drawing.Point(0, 0);
            this.ContentToolStripContainer.Name = "ContentToolStripContainer";
            this.ContentToolStripContainer.Size = new System.Drawing.Size(531, 548);
            this.ContentToolStripContainer.TabIndex = 0;
            this.ContentToolStripContainer.Text = "ContentToolStripContainer";
            // 
            // ContentToolStripContainer.TopToolStripPanel
            // 
            this.ContentToolStripContainer.TopToolStripPanel.Controls.Add(this.ContentToolStrip);
            // 
            // RecordsDataGridView
            // 
            this.RecordsDataGridView.AllowUserToAddRows = false;
            this.RecordsDataGridView.AllowUserToDeleteRows = false;
            this.RecordsDataGridView.AllowUserToOrderColumns = true;
            this.RecordsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.RecordsDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RecordsDataGridView.Location = new System.Drawing.Point(0, 0);
            this.RecordsDataGridView.Name = "RecordsDataGridView";
            this.RecordsDataGridView.ReadOnly = true;
            this.RecordsDataGridView.RowTemplate.Height = 24;
            this.RecordsDataGridView.Size = new System.Drawing.Size(531, 521);
            this.RecordsDataGridView.TabIndex = 0;
            // 
            // ContentToolStrip
            // 
            this.ContentToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.ContentToolStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.ContentToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RefreshToolStripLabel,
            this.RefreshToolStripButton,
            this.toolStripSeparator1,
            this.AddToolStripLabel,
            this.AddToolStripButton,
            this.toolStripSeparator2,
            this.EditToolStripLabel,
            this.EditToolStripButton,
            this.toolStripSeparator3,
            this.DeleteToolStripLabel,
            this.DeleteToolStripButton});
            this.ContentToolStrip.Location = new System.Drawing.Point(3, 0);
            this.ContentToolStrip.Name = "ContentToolStrip";
            this.ContentToolStrip.Size = new System.Drawing.Size(309, 27);
            this.ContentToolStrip.TabIndex = 0;
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
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // AddToolStripLabel
            // 
            this.AddToolStripLabel.Name = "AddToolStripLabel";
            this.AddToolStripLabel.Size = new System.Drawing.Size(37, 24);
            this.AddToolStripLabel.Text = "Add";
            // 
            // AddToolStripButton
            // 
            this.AddToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.AddToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("AddToolStripButton.Image")));
            this.AddToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AddToolStripButton.Name = "AddToolStripButton";
            this.AddToolStripButton.Size = new System.Drawing.Size(24, 24);
            this.AddToolStripButton.Text = "Add";
            this.AddToolStripButton.Click += new System.EventHandler(this.AddToolStripButton_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // EditToolStripLabel
            // 
            this.EditToolStripLabel.Name = "EditToolStripLabel";
            this.EditToolStripLabel.Size = new System.Drawing.Size(35, 24);
            this.EditToolStripLabel.Text = "Edit";
            // 
            // EditToolStripButton
            // 
            this.EditToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.EditToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("EditToolStripButton.Image")));
            this.EditToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.EditToolStripButton.Name = "EditToolStripButton";
            this.EditToolStripButton.Size = new System.Drawing.Size(24, 24);
            this.EditToolStripButton.Text = "Edit";
            this.EditToolStripButton.Click += new System.EventHandler(this.EditToolStripButton_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 27);
            // 
            // DeleteToolStripLabel
            // 
            this.DeleteToolStripLabel.Name = "DeleteToolStripLabel";
            this.DeleteToolStripLabel.Size = new System.Drawing.Size(53, 24);
            this.DeleteToolStripLabel.Text = "Delete";
            // 
            // DeleteToolStripButton
            // 
            this.DeleteToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.DeleteToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("DeleteToolStripButton.Image")));
            this.DeleteToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DeleteToolStripButton.Name = "DeleteToolStripButton";
            this.DeleteToolStripButton.Size = new System.Drawing.Size(24, 24);
            this.DeleteToolStripButton.Text = "Delete";
            this.DeleteToolStripButton.Click += new System.EventHandler(this.DeleteToolStripButton_Click);
            // 
            // BasisSplitContainer
            // 
            this.BasisSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BasisSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.BasisSplitContainer.Name = "BasisSplitContainer";
            // 
            // BasisSplitContainer.Panel1
            // 
            this.BasisSplitContainer.Panel1.Controls.Add(this.HierarchyToolStripContainer);
            // 
            // BasisSplitContainer.Panel2
            // 
            this.BasisSplitContainer.Panel2.Controls.Add(this.ContentToolStripContainer);
            this.BasisSplitContainer.Size = new System.Drawing.Size(777, 548);
            this.BasisSplitContainer.SplitterDistance = 242;
            this.BasisSplitContainer.TabIndex = 1;
            // 
            // HierarchyToolStripContainer
            // 
            // 
            // HierarchyToolStripContainer.ContentPanel
            // 
            this.HierarchyToolStripContainer.ContentPanel.Controls.Add(this.HierarchyTreeView);
            this.HierarchyToolStripContainer.ContentPanel.Size = new System.Drawing.Size(242, 521);
            this.HierarchyToolStripContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HierarchyToolStripContainer.Location = new System.Drawing.Point(0, 0);
            this.HierarchyToolStripContainer.Name = "HierarchyToolStripContainer";
            this.HierarchyToolStripContainer.Size = new System.Drawing.Size(242, 548);
            this.HierarchyToolStripContainer.TabIndex = 1;
            this.HierarchyToolStripContainer.Text = "HierarchyToolStripContainer";
            // 
            // HierarchyToolStripContainer.TopToolStripPanel
            // 
            this.HierarchyToolStripContainer.TopToolStripPanel.Controls.Add(this.HierarchyToolStrip);
            // 
            // HierarchyToolStrip
            // 
            this.HierarchyToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.HierarchyToolStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.HierarchyToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RefreshHierarchyToolStripButton,
            this.toolStripSeparator4,
            this.AddHierarchyToolStripButton,
            this.toolStripSeparator5,
            this.EditHierarchytoolStripButton,
            this.toolStripSeparator6,
            this.DeleteHierarchyToolStripButton});
            this.HierarchyToolStrip.Location = new System.Drawing.Point(3, 0);
            this.HierarchyToolStrip.Name = "HierarchyToolStrip";
            this.HierarchyToolStrip.Size = new System.Drawing.Size(165, 27);
            this.HierarchyToolStrip.TabIndex = 0;
            // 
            // RefreshHierarchyToolStripButton
            // 
            this.RefreshHierarchyToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.RefreshHierarchyToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("RefreshHierarchyToolStripButton.Image")));
            this.RefreshHierarchyToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.RefreshHierarchyToolStripButton.Name = "RefreshHierarchyToolStripButton";
            this.RefreshHierarchyToolStripButton.Size = new System.Drawing.Size(24, 24);
            this.RefreshHierarchyToolStripButton.Text = "Refresh";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 27);
            // 
            // AddHierarchyToolStripButton
            // 
            this.AddHierarchyToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.AddHierarchyToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("AddHierarchyToolStripButton.Image")));
            this.AddHierarchyToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AddHierarchyToolStripButton.Name = "AddHierarchyToolStripButton";
            this.AddHierarchyToolStripButton.Size = new System.Drawing.Size(24, 24);
            this.AddHierarchyToolStripButton.Text = "Add";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 27);
            // 
            // EditHierarchytoolStripButton
            // 
            this.EditHierarchytoolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.EditHierarchytoolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("EditHierarchytoolStripButton.Image")));
            this.EditHierarchytoolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.EditHierarchytoolStripButton.Name = "EditHierarchytoolStripButton";
            this.EditHierarchytoolStripButton.Size = new System.Drawing.Size(24, 24);
            this.EditHierarchytoolStripButton.Text = "Edit";
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 27);
            // 
            // DeleteHierarchyToolStripButton
            // 
            this.DeleteHierarchyToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.DeleteHierarchyToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("DeleteHierarchyToolStripButton.Image")));
            this.DeleteHierarchyToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DeleteHierarchyToolStripButton.Name = "DeleteHierarchyToolStripButton";
            this.DeleteHierarchyToolStripButton.Size = new System.Drawing.Size(24, 24);
            this.DeleteHierarchyToolStripButton.Text = "Delete";
            // 
            // BottomToolStripPanel
            // 
            this.BottomToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.BottomToolStripPanel.Name = "BottomToolStripPanel";
            this.BottomToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.BottomToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.BottomToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // TopToolStripPanel
            // 
            this.TopToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.TopToolStripPanel.Name = "TopToolStripPanel";
            this.TopToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.TopToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.TopToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // RightToolStripPanel
            // 
            this.RightToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.RightToolStripPanel.Name = "RightToolStripPanel";
            this.RightToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.RightToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.RightToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // LeftToolStripPanel
            // 
            this.LeftToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.LeftToolStripPanel.Name = "LeftToolStripPanel";
            this.LeftToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.LeftToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.LeftToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // ContentPanel
            // 
            this.ContentPanel.Size = new System.Drawing.Size(160, 521);
            // 
            // HierarchyTreeView
            // 
            this.HierarchyTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HierarchyTreeView.Location = new System.Drawing.Point(0, 0);
            this.HierarchyTreeView.Name = "HierarchyTreeView";
            this.HierarchyTreeView.Size = new System.Drawing.Size(242, 521);
            this.HierarchyTreeView.TabIndex = 0;
            // 
            // ContentBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(777, 548);
            this.Controls.Add(this.BasisSplitContainer);
            this.Name = "ContentBrowser";
            this.Text = "ContentBrowser";
            this.ContentToolStripContainer.ContentPanel.ResumeLayout(false);
            this.ContentToolStripContainer.TopToolStripPanel.ResumeLayout(false);
            this.ContentToolStripContainer.TopToolStripPanel.PerformLayout();
            this.ContentToolStripContainer.ResumeLayout(false);
            this.ContentToolStripContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RecordsDataGridView)).EndInit();
            this.ContentToolStrip.ResumeLayout(false);
            this.ContentToolStrip.PerformLayout();
            this.BasisSplitContainer.Panel1.ResumeLayout(false);
            this.BasisSplitContainer.Panel2.ResumeLayout(false);
            this.BasisSplitContainer.ResumeLayout(false);
            this.HierarchyToolStripContainer.ContentPanel.ResumeLayout(false);
            this.HierarchyToolStripContainer.TopToolStripPanel.ResumeLayout(false);
            this.HierarchyToolStripContainer.TopToolStripPanel.PerformLayout();
            this.HierarchyToolStripContainer.ResumeLayout(false);
            this.HierarchyToolStripContainer.PerformLayout();
            this.HierarchyToolStrip.ResumeLayout(false);
            this.HierarchyToolStrip.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ToolStripContainer ContentToolStripContainer;
        private ToolStrip ContentToolStrip;
        private ToolStripLabel RefreshToolStripLabel;
        private ToolStripButton RefreshToolStripButton;
        private DataGridView RecordsDataGridView;
        private ToolStripLabel AddToolStripLabel;
        private ToolStripButton AddToolStripButton;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripLabel EditToolStripLabel;
        private ToolStripButton EditToolStripButton;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripLabel DeleteToolStripLabel;
        private ToolStripButton DeleteToolStripButton;
        private SplitContainer BasisSplitContainer;
        private ToolStripContainer HierarchyToolStripContainer;
        private ToolStrip HierarchyToolStrip;
        private ToolStripButton RefreshHierarchyToolStripButton;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripButton AddHierarchyToolStripButton;
        private ToolStripSeparator toolStripSeparator5;
        private ToolStripButton EditHierarchytoolStripButton;
        private ToolStripSeparator toolStripSeparator6;
        private ToolStripButton DeleteHierarchyToolStripButton;
        private TreeView HierarchyTreeView;
        private ToolStripPanel BottomToolStripPanel;
        private ToolStripPanel TopToolStripPanel;
        private ToolStripPanel RightToolStripPanel;
        private ToolStripPanel LeftToolStripPanel;
        private ToolStripContentPanel ContentPanel;
    }
}

