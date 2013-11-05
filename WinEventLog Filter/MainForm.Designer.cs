using System.Collections.Generic;
using System.Diagnostics;

namespace WinEventLog_Filter
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.pnlSearchConditions = new System.Windows.Forms.Panel();
            this.grpSearchConditions = new System.Windows.Forms.GroupBox();
            this.btnReloadCurrentDate = new System.Windows.Forms.Button();
            this.chkSaveSearchConditions = new System.Windows.Forms.CheckBox();
            this.txtSearchTerm = new System.Windows.Forms.TextBox();
            this.lblEventSearchTerm = new System.Windows.Forms.Label();
            this.chkMachExact = new System.Windows.Forms.CheckBox();
            this.txtEventSource = new System.Windows.Forms.TextBox();
            this.lblEventSource = new System.Windows.Forms.Label();
            this.chkMissingLinksFiltering = new System.Windows.Forms.CheckBox();
            this.cmbEventLog = new System.Windows.Forms.ComboBox();
            this.lblEventLog = new System.Windows.Forms.Label();
            this.dateEnd = new System.Windows.Forms.DateTimePicker();
            this.dateStart = new System.Windows.Forms.DateTimePicker();
            this.cmbEvenType = new System.Windows.Forms.ComboBox();
            this.txtEventId = new System.Windows.Forms.TextBox();
            this.lblEventType = new System.Windows.Forms.Label();
            this.lblEndDate = new System.Windows.Forms.Label();
            this.lblStartDate = new System.Windows.Forms.Label();
            this.lblEventId = new System.Windows.Forms.Label();
            this.pnlActions = new System.Windows.Forms.Panel();
            this.btnCopySummary = new System.Windows.Forms.Button();
            this.btnCopy = new System.Windows.Forms.Button();
            this.btnSaveToFile = new System.Windows.Forms.Button();
            this.btnFilter = new System.Windows.Forms.Button();
            this.txtResults = new System.Windows.Forms.TextBox();
            this.tipToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.pnlSearchConditions.SuspendLayout();
            this.grpSearchConditions.SuspendLayout();
            this.pnlActions.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlSearchConditions
            // 
            this.pnlSearchConditions.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlSearchConditions.Controls.Add(this.grpSearchConditions);
            this.pnlSearchConditions.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSearchConditions.Location = new System.Drawing.Point(0, 0);
            this.pnlSearchConditions.Margin = new System.Windows.Forms.Padding(0);
            this.pnlSearchConditions.Name = "pnlSearchConditions";
            this.pnlSearchConditions.Padding = new System.Windows.Forms.Padding(2);
            this.pnlSearchConditions.Size = new System.Drawing.Size(784, 225);
            this.pnlSearchConditions.TabIndex = 0;
            // 
            // grpSearchConditions
            // 
            this.grpSearchConditions.Controls.Add(this.btnReloadCurrentDate);
            this.grpSearchConditions.Controls.Add(this.chkSaveSearchConditions);
            this.grpSearchConditions.Controls.Add(this.txtSearchTerm);
            this.grpSearchConditions.Controls.Add(this.lblEventSearchTerm);
            this.grpSearchConditions.Controls.Add(this.chkMachExact);
            this.grpSearchConditions.Controls.Add(this.txtEventSource);
            this.grpSearchConditions.Controls.Add(this.lblEventSource);
            this.grpSearchConditions.Controls.Add(this.chkMissingLinksFiltering);
            this.grpSearchConditions.Controls.Add(this.cmbEventLog);
            this.grpSearchConditions.Controls.Add(this.lblEventLog);
            this.grpSearchConditions.Controls.Add(this.dateEnd);
            this.grpSearchConditions.Controls.Add(this.dateStart);
            this.grpSearchConditions.Controls.Add(this.cmbEvenType);
            this.grpSearchConditions.Controls.Add(this.txtEventId);
            this.grpSearchConditions.Controls.Add(this.lblEventType);
            this.grpSearchConditions.Controls.Add(this.lblEndDate);
            this.grpSearchConditions.Controls.Add(this.lblStartDate);
            this.grpSearchConditions.Controls.Add(this.lblEventId);
            this.grpSearchConditions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpSearchConditions.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpSearchConditions.Location = new System.Drawing.Point(2, 2);
            this.grpSearchConditions.Name = "grpSearchConditions";
            this.grpSearchConditions.Size = new System.Drawing.Size(776, 217);
            this.grpSearchConditions.TabIndex = 10;
            this.grpSearchConditions.TabStop = false;
            this.grpSearchConditions.Text = "Search Conditions:";
            // 
            // btnReloadCurrentDate
            // 
            this.btnReloadCurrentDate.Image = global::WinEventLog_Filter.Properties.Resources.reload;
            this.btnReloadCurrentDate.Location = new System.Drawing.Point(713, 152);
            this.btnReloadCurrentDate.Name = "btnReloadCurrentDate";
            this.btnReloadCurrentDate.Size = new System.Drawing.Size(25, 25);
            this.btnReloadCurrentDate.TabIndex = 8;
            this.btnReloadCurrentDate.UseVisualStyleBackColor = true;
            this.btnReloadCurrentDate.Click += new System.EventHandler(this.btnReloadCurrentDate_Click);
            this.tipToolTip.SetToolTip(this.btnReloadCurrentDate, "Reloads current date and time.\r\nShortcut: Ctrl+R.");
            // 
            // chkSaveSearchConditions
            // 
            this.chkSaveSearchConditions.AutoSize = true;
            this.chkSaveSearchConditions.Location = new System.Drawing.Point(557, 22);
            this.chkSaveSearchConditions.Name = "chkSaveSearchConditions";
            this.chkSaveSearchConditions.Size = new System.Drawing.Size(211, 20);
            this.chkSaveSearchConditions.TabIndex = 15;
            this.chkSaveSearchConditions.Text = "Remember search conditions";
            this.tipToolTip.SetToolTip(this.chkSaveSearchConditions, "Check this one if you want search conditions \r\nto be saved until next application s" +
        "tart.");
            this.chkSaveSearchConditions.UseVisualStyleBackColor = true;
            // 
            // txtSearchTerm
            // 
            this.txtSearchTerm.Location = new System.Drawing.Point(151, 24);
            this.txtSearchTerm.Name = "txtSearchTerm";
            this.txtSearchTerm.Size = new System.Drawing.Size(237, 23);
            this.txtSearchTerm.TabIndex = 0;
            this.tipToolTip.SetToolTip(this.txtSearchTerm, "Enter the search terms to be compared \r\nagainst the event entries message content" +
        ". \r\nDelimiters are , or ;.");
            // 
            // lblEventSearchTerm
            // 
            this.lblEventSearchTerm.AutoSize = true;
            this.lblEventSearchTerm.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEventSearchTerm.Location = new System.Drawing.Point(16, 24);
            this.lblEventSearchTerm.Margin = new System.Windows.Forms.Padding(2);
            this.lblEventSearchTerm.Name = "lblEventSearchTerm";
            this.lblEventSearchTerm.Padding = new System.Windows.Forms.Padding(3);
            this.lblEventSearchTerm.Size = new System.Drawing.Size(129, 22);
            this.lblEventSearchTerm.TabIndex = 23;
            this.lblEventSearchTerm.Text = "Search for term(s)";
            this.tipToolTip.SetToolTip(this.lblEventSearchTerm, "Enter the search terms to be compared \r\nagainst the event entries message content" +
        ". \r\nDelimiters are , or ;.");
            // 
            // chkMachExact
            // 
            this.chkMachExact.AutoSize = true;
            this.chkMachExact.Location = new System.Drawing.Point(396, 127);
            this.chkMachExact.Name = "chkMachExact";
            this.chkMachExact.Padding = new System.Windows.Forms.Padding(3);
            this.chkMachExact.Size = new System.Drawing.Size(180, 26);
            this.chkMachExact.TabIndex = 5;
            this.chkMachExact.Text = "Match the exact phrase";
            this.tipToolTip.SetToolTip(this.chkMachExact, "If checked, the event source field value must match\r\nthe exact value of the event" +
        " entries source attribute.");
            this.chkMachExact.UseVisualStyleBackColor = true;
            // 
            // txtEventSource
            // 
            this.txtEventSource.Location = new System.Drawing.Point(151, 128);
            this.txtEventSource.Name = "txtEventSource";
            this.txtEventSource.Size = new System.Drawing.Size(237, 23);
            this.txtEventSource.TabIndex = 4;
            this.tipToolTip.SetToolTip(this.txtEventSource, "Enter the event source name to be compared \r\nagainst the event entries source atr" +
        "ibute.");
            // 
            // lblEventSource
            // 
            this.lblEventSource.AutoSize = true;
            this.lblEventSource.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEventSource.Location = new System.Drawing.Point(16, 128);
            this.lblEventSource.Margin = new System.Windows.Forms.Padding(2);
            this.lblEventSource.Name = "lblEventSource";
            this.lblEventSource.Padding = new System.Windows.Forms.Padding(3);
            this.lblEventSource.Size = new System.Drawing.Size(97, 22);
            this.lblEventSource.TabIndex = 21;
            this.lblEventSource.Text = "Event source";
            this.tipToolTip.SetToolTip(this.lblEventSource, "Enter the event source name to be compared \r\nagainst the event entries source atr" +
        "ibute.");
            // 
            // chkMissingLinksFiltering
            // 
            this.chkMissingLinksFiltering.AutoSize = true;
            this.chkMissingLinksFiltering.Checked = true;
            this.chkMissingLinksFiltering.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkMissingLinksFiltering.Location = new System.Drawing.Point(151, 183);
            this.chkMissingLinksFiltering.Name = "chkMissingLinksFiltering";
            this.chkMissingLinksFiltering.Padding = new System.Windows.Forms.Padding(3);
            this.chkMissingLinksFiltering.Size = new System.Drawing.Size(224, 26);
            this.chkMissingLinksFiltering.TabIndex = 9;
            this.chkMissingLinksFiltering.Text = "Use the \"missing links\" filtering";
            this.tipToolTip.SetToolTip(this.chkMissingLinksFiltering, "Only usable with 11111 events, missing link errors. Allows extracting of \r\nthe mi" +
        "ssing links summary results. Also, enables Copy Summary button.");
            this.chkMissingLinksFiltering.UseVisualStyleBackColor = true;
            this.chkMissingLinksFiltering.CheckedChanged += new System.EventHandler(this.chkMissingLinksFiltering_CheckedChanged);
            // 
            // cmbEventLog
            // 
            this.cmbEventLog.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEventLog.FormattingEnabled = true;
            this.cmbEventLog.Location = new System.Drawing.Point(151, 101);
            this.cmbEventLog.Name = "cmbEventLog";
            this.cmbEventLog.Size = new System.Drawing.Size(237, 24);
            this.cmbEventLog.TabIndex = 3;
            this.tipToolTip.SetToolTip(this.cmbEventLog, "Select local machine event logs in which \r\nthe event entries are to be searched f" +
        "or.");
            // 
            // lblEventLog
            // 
            this.lblEventLog.AutoSize = true;
            this.lblEventLog.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEventLog.Location = new System.Drawing.Point(16, 102);
            this.lblEventLog.Margin = new System.Windows.Forms.Padding(2);
            this.lblEventLog.Name = "lblEventLog";
            this.lblEventLog.Padding = new System.Windows.Forms.Padding(3);
            this.lblEventLog.Size = new System.Drawing.Size(73, 22);
            this.lblEventLog.TabIndex = 20;
            this.lblEventLog.Text = "Event log";
            this.tipToolTip.SetToolTip(this.lblEventLog, "Select local machine event logs in which \r\nthe event entries are to be searched f" +
        "or.");
            // 
            // dateEnd
            // 
            this.dateEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateEnd.Location = new System.Drawing.Point(469, 154);
            this.dateEnd.Name = "dateEnd";
            this.dateEnd.Size = new System.Drawing.Size(237, 23);
            this.dateEnd.TabIndex = 7;
            this.tipToolTip.SetToolTip(this.dateEnd, "Select the date at which the search \r\nfor the event entries will stop.");
            // 
            // dateStart
            // 
            this.dateStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateStart.Location = new System.Drawing.Point(151, 154);
            this.dateStart.Name = "dateStart";
            this.dateStart.Size = new System.Drawing.Size(237, 23);
            this.dateStart.TabIndex = 6;
            this.tipToolTip.SetToolTip(this.dateStart, "Select the date from which the search \r\nfor the event entries will begin.");
            // 
            // cmbEvenType
            // 
            this.cmbEvenType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEvenType.FormattingEnabled = true;
            this.cmbEvenType.Location = new System.Drawing.Point(151, 74);
            this.cmbEvenType.Name = "cmbEvenType";
            this.cmbEvenType.Size = new System.Drawing.Size(237, 24);
            this.cmbEvenType.TabIndex = 2;
            this.tipToolTip.SetToolTip(this.cmbEvenType, "Select the type of the events which you want to filter.");
            // 
            // txtEventId
            // 
            this.txtEventId.Location = new System.Drawing.Point(151, 49);
            this.txtEventId.Name = "txtEventId";
            this.txtEventId.Size = new System.Drawing.Size(237, 23);
            this.txtEventId.TabIndex = 1;
            this.tipToolTip.SetToolTip(this.txtEventId, "Enter the event ID to be compared agains the event entries Event ID attribute. \r\n" +
        "Only numeric attributes are allowed.");
            this.txtEventId.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEventId_KeyPress);
            // 
            // lblEventType
            // 
            this.lblEventType.AutoSize = true;
            this.lblEventType.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEventType.Location = new System.Drawing.Point(16, 76);
            this.lblEventType.Margin = new System.Windows.Forms.Padding(2);
            this.lblEventType.Name = "lblEventType";
            this.lblEventType.Padding = new System.Windows.Forms.Padding(3);
            this.lblEventType.Size = new System.Drawing.Size(81, 22);
            this.lblEventType.TabIndex = 18;
            this.lblEventType.Text = "Event type";
            this.tipToolTip.SetToolTip(this.lblEventType, "Select the type of the events which you want to filter.");
            // 
            // lblEndDate
            // 
            this.lblEndDate.AutoSize = true;
            this.lblEndDate.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEndDate.Location = new System.Drawing.Point(393, 154);
            this.lblEndDate.Margin = new System.Windows.Forms.Padding(2);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Padding = new System.Windows.Forms.Padding(3);
            this.lblEndDate.Size = new System.Drawing.Size(71, 22);
            this.lblEndDate.TabIndex = 15;
            this.lblEndDate.Text = "End date";
            this.tipToolTip.SetToolTip(this.lblEndDate, "Select the date at which the search \r\nfor the event entries will stop.");
            // 
            // lblStartDate
            // 
            this.lblStartDate.AutoSize = true;
            this.lblStartDate.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStartDate.Location = new System.Drawing.Point(16, 154);
            this.lblStartDate.Margin = new System.Windows.Forms.Padding(2);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Padding = new System.Windows.Forms.Padding(3);
            this.lblStartDate.Size = new System.Drawing.Size(76, 22);
            this.lblStartDate.TabIndex = 13;
            this.lblStartDate.Text = "Start date";
            this.tipToolTip.SetToolTip(this.lblStartDate, "Select the date from which the search \r\nfor the event entries will begin.");
            // 
            // lblEventId
            // 
            this.lblEventId.AutoSize = true;
            this.lblEventId.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEventId.Location = new System.Drawing.Point(16, 50);
            this.lblEventId.Margin = new System.Windows.Forms.Padding(2);
            this.lblEventId.Name = "lblEventId";
            this.lblEventId.Padding = new System.Windows.Forms.Padding(3);
            this.lblEventId.Size = new System.Drawing.Size(67, 22);
            this.lblEventId.TabIndex = 11;
            this.lblEventId.Text = "Event ID";
            this.tipToolTip.SetToolTip(this.lblEventId, "Enter the event ID to be compared agains the event entries Event ID attribute. \r\n" +
        "Only numeric attributes are allowed.");
            // 
            // pnlActions
            // 
            this.pnlActions.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlActions.Controls.Add(this.btnCopySummary);
            this.pnlActions.Controls.Add(this.btnCopy);
            this.pnlActions.Controls.Add(this.btnSaveToFile);
            this.pnlActions.Controls.Add(this.btnFilter);
            this.pnlActions.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlActions.Location = new System.Drawing.Point(0, 512);
            this.pnlActions.Name = "pnlActions";
            this.pnlActions.Size = new System.Drawing.Size(784, 50);
            this.pnlActions.TabIndex = 1;
            // 
            // btnCopySummary
            // 
            this.btnCopySummary.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCopySummary.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCopySummary.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnCopySummary.Location = new System.Drawing.Point(373, 5);
            this.btnCopySummary.Name = "btnCopySummary";
            this.btnCopySummary.Size = new System.Drawing.Size(145, 38);
            this.btnCopySummary.TabIndex = 11;
            this.btnCopySummary.Text = "Copy su&mmary";
            this.tipToolTip.SetToolTip(this.btnCopySummary, "Copy the missing links summary results into clipboard. \r\nShortcut: Ctrl+M.");
            this.btnCopySummary.UseVisualStyleBackColor = true;
            this.btnCopySummary.Click += new System.EventHandler(this.btnCopySummary_Click);
            // 
            // btnCopy
            // 
            this.btnCopy.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCopy.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCopy.Location = new System.Drawing.Point(524, 5);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(113, 38);
            this.btnCopy.TabIndex = 12;
            this.btnCopy.Text = "&Copy";
            this.tipToolTip.SetToolTip(this.btnCopy, "Copy the results into clipboard. \r\nShortcut: Ctrl+C.");
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // btnSaveToFile
            // 
            this.btnSaveToFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveToFile.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveToFile.Location = new System.Drawing.Point(643, 5);
            this.btnSaveToFile.Name = "btnSaveToFile";
            this.btnSaveToFile.Size = new System.Drawing.Size(134, 38);
            this.btnSaveToFile.TabIndex = 13;
            this.btnSaveToFile.Text = "&Save to file ..";
            this.tipToolTip.SetToolTip(this.btnSaveToFile, "Open Save File Dialog, saves the results into text file. \r\nShortcut: Ctrl+S.");
            this.btnSaveToFile.UseVisualStyleBackColor = true;
            this.btnSaveToFile.Click += new System.EventHandler(this.btnSaveToFile_Click);
            // 
            // btnFilter
            // 
            this.btnFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btnFilter.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFilter.Location = new System.Drawing.Point(3, 5);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(113, 38);
            this.btnFilter.TabIndex = 10;
            this.btnFilter.Text = "Filter";
            this.tipToolTip.SetToolTip(this.btnFilter, "Start filtering the Windows event entries by the search conditions. \r\nShortcut: E" +
        "nter.");
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // txtResults
            // 
            this.txtResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtResults.Location = new System.Drawing.Point(0, 225);
            this.txtResults.Multiline = true;
            this.txtResults.Name = "txtResults";
            this.txtResults.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtResults.Size = new System.Drawing.Size(784, 287);
            this.txtResults.TabIndex = 14;
            this.tipToolTip.SetToolTip(this.txtResults, "Displays the filtered event entries.");
            this.txtResults.WordWrap = false;
            this.txtResults.MouseHover += new System.EventHandler(this.txtResults_MouseHover);
            // 
            // tipToolTip
            // 
            this.tipToolTip.AutoPopDelay = 10000;
            this.tipToolTip.InitialDelay = 500;
            this.tipToolTip.ReshowDelay = 100;
            // 
            // MainForm
            // 
            this.AcceptButton = this.btnFilter;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.txtResults);
            this.Controls.Add(this.pnlActions);
            this.Controls.Add(this.pnlSearchConditions);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WinEventLog Filter";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.pnlSearchConditions.ResumeLayout(false);
            this.grpSearchConditions.ResumeLayout(false);
            this.grpSearchConditions.PerformLayout();
            this.pnlActions.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        #region Attributes
        /// <summary>
        /// Dictionary which holds all unique Windows events which fulfill the search conditions.
        /// </summary>
        private static Dictionary<int, EventLogEntry> uniqueEventsResults;
        /// <summary>
        /// List which holds missing links tcm-s in if Missing links filtering is turned on.
        /// </summary>
        private List<string> missingLinksTcmResults;
        /// <summary>
        /// Object which contains current search conditions.
        /// </summary>
        private SearchConditions searchConditions;
        #endregion

        private System.Windows.Forms.Panel pnlSearchConditions;
        private System.Windows.Forms.Panel pnlActions;
        private System.Windows.Forms.TextBox txtResults;
        private System.Windows.Forms.GroupBox grpSearchConditions;
        private System.Windows.Forms.CheckBox chkMissingLinksFiltering;
        private System.Windows.Forms.ComboBox cmbEventLog;
        private System.Windows.Forms.Label lblEventLog;
        private System.Windows.Forms.DateTimePicker dateEnd;
        private System.Windows.Forms.DateTimePicker dateStart;
        private System.Windows.Forms.ComboBox cmbEvenType;
        private System.Windows.Forms.TextBox txtEventId;
        private System.Windows.Forms.Label lblEventType;
        private System.Windows.Forms.Label lblEndDate;
        private System.Windows.Forms.Label lblStartDate;
        private System.Windows.Forms.Label lblEventId;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.Button btnSaveToFile;
        private System.Windows.Forms.TextBox txtEventSource;
        private System.Windows.Forms.Label lblEventSource;
        private System.Windows.Forms.CheckBox chkMachExact;
        private System.Windows.Forms.Button btnCopySummary;
        private System.Windows.Forms.TextBox txtSearchTerm;
        private System.Windows.Forms.Label lblEventSearchTerm;
        private System.Windows.Forms.ToolTip tipToolTip;
        private System.Windows.Forms.CheckBox chkSaveSearchConditions;
        private System.Windows.Forms.Button btnReloadCurrentDate;
        //private System.Windows.Forms.ComboBox cmbLocalNetworkAdrs;
    }
}

