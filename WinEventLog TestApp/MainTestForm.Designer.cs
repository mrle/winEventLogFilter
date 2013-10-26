using System.Collections.Generic;
using System.Diagnostics;

namespace WinEventLog_Browser
{
    partial class MainTestForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainTestForm));
            this.pnlSearchConditions = new System.Windows.Forms.Panel();
            this.grpSearchConditions = new System.Windows.Forms.GroupBox();
            this.lblRepeatNo = new System.Windows.Forms.Label();
            this.numRepeatNo = new System.Windows.Forms.NumericUpDown();
            this.lblEventMessage = new System.Windows.Forms.Label();
            this.cmbEventLog = new System.Windows.Forms.ComboBox();
            this.lblEventLog = new System.Windows.Forms.Label();
            this.cmbEvenType = new System.Windows.Forms.ComboBox();
            this.lblEventType = new System.Windows.Forms.Label();
            this.pnlActions = new System.Windows.Forms.Panel();
            this.btnCreate = new System.Windows.Forms.Button();
            this.tipToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.txtEventId = new System.Windows.Forms.TextBox();
            this.rtxEventMessage = new System.Windows.Forms.RichTextBox();
            this.lblEventId = new System.Windows.Forms.Label();
            this.pnlSearchConditions.SuspendLayout();
            this.grpSearchConditions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numRepeatNo)).BeginInit();
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
            this.grpSearchConditions.Controls.Add(this.lblEventId);
            this.grpSearchConditions.Controls.Add(this.rtxEventMessage);
            this.grpSearchConditions.Controls.Add(this.txtEventId);
            this.grpSearchConditions.Controls.Add(this.lblRepeatNo);
            this.grpSearchConditions.Controls.Add(this.numRepeatNo);
            this.grpSearchConditions.Controls.Add(this.lblEventMessage);
            this.grpSearchConditions.Controls.Add(this.cmbEventLog);
            this.grpSearchConditions.Controls.Add(this.lblEventLog);
            this.grpSearchConditions.Controls.Add(this.cmbEvenType);
            this.grpSearchConditions.Controls.Add(this.lblEventType);
            this.grpSearchConditions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpSearchConditions.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpSearchConditions.Location = new System.Drawing.Point(2, 2);
            this.grpSearchConditions.Name = "grpSearchConditions";
            this.grpSearchConditions.Size = new System.Drawing.Size(776, 217);
            this.grpSearchConditions.TabIndex = 10;
            this.grpSearchConditions.TabStop = false;
            this.grpSearchConditions.Text = "New Windows Event Data:";
            // 
            // lblRepeatNo
            // 
            this.lblRepeatNo.AutoSize = true;
            this.lblRepeatNo.Location = new System.Drawing.Point(19, 27);
            this.lblRepeatNo.Name = "lblRepeatNo";
            this.lblRepeatNo.Size = new System.Drawing.Size(207, 16);
            this.lblRepeatNo.TabIndex = 25;
            this.lblRepeatNo.Text = "Number of events to be created";
            // 
            // numRepeatNo
            // 
            this.numRepeatNo.Location = new System.Drawing.Point(249, 22);
            this.numRepeatNo.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numRepeatNo.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numRepeatNo.Name = "numRepeatNo";
            this.numRepeatNo.Size = new System.Drawing.Size(120, 23);
            this.numRepeatNo.TabIndex = 24;
            this.numRepeatNo.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblEventMessage
            // 
            this.lblEventMessage.AutoSize = true;
            this.lblEventMessage.Location = new System.Drawing.Point(19, 137);
            this.lblEventMessage.Name = "lblEventMessage";
            this.lblEventMessage.Size = new System.Drawing.Size(105, 16);
            this.lblEventMessage.TabIndex = 22;
            this.lblEventMessage.Text = "Event message";
            // 
            // cmbEventLog
            // 
            this.cmbEventLog.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEventLog.FormattingEnabled = true;
            this.cmbEventLog.Location = new System.Drawing.Point(132, 78);
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
            this.lblEventLog.Location = new System.Drawing.Point(16, 79);
            this.lblEventLog.Margin = new System.Windows.Forms.Padding(2);
            this.lblEventLog.Name = "lblEventLog";
            this.lblEventLog.Padding = new System.Windows.Forms.Padding(3);
            this.lblEventLog.Size = new System.Drawing.Size(73, 22);
            this.lblEventLog.TabIndex = 20;
            this.lblEventLog.Text = "Event log";
            this.tipToolTip.SetToolTip(this.lblEventLog, "Select local machine event logs in which \r\nthe event entries are to be searched f" +
        "or.");
            // 
            // cmbEvenType
            // 
            this.cmbEvenType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEvenType.FormattingEnabled = true;
            this.cmbEvenType.Location = new System.Drawing.Point(132, 51);
            this.cmbEvenType.Name = "cmbEvenType";
            this.cmbEvenType.Size = new System.Drawing.Size(237, 24);
            this.cmbEvenType.TabIndex = 2;
            this.tipToolTip.SetToolTip(this.cmbEvenType, "Select the type of the events which you want to filter.");
            // 
            // lblEventType
            // 
            this.lblEventType.AutoSize = true;
            this.lblEventType.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEventType.Location = new System.Drawing.Point(16, 53);
            this.lblEventType.Margin = new System.Windows.Forms.Padding(2);
            this.lblEventType.Name = "lblEventType";
            this.lblEventType.Padding = new System.Windows.Forms.Padding(3);
            this.lblEventType.Size = new System.Drawing.Size(81, 22);
            this.lblEventType.TabIndex = 18;
            this.lblEventType.Text = "Event type";
            this.tipToolTip.SetToolTip(this.lblEventType, "Select the type of the events which you want to filter.");
            // 
            // pnlActions
            // 
            this.pnlActions.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlActions.Controls.Add(this.btnCreate);
            this.pnlActions.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlActions.Location = new System.Drawing.Point(0, 232);
            this.pnlActions.Name = "pnlActions";
            this.pnlActions.Size = new System.Drawing.Size(784, 50);
            this.pnlActions.TabIndex = 1;
            // 
            // btnCreate
            // 
            this.btnCreate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCreate.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreate.Location = new System.Drawing.Point(592, 5);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(178, 38);
            this.btnCreate.TabIndex = 9;
            this.btnCreate.Text = "Create Event";
            this.tipToolTip.SetToolTip(this.btnCreate, "Start filtering the Windows event entries by the search conditions. \r\nShortcut: E" +
        "nter.");
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // tipToolTip
            // 
            this.tipToolTip.AutoPopDelay = 10000;
            this.tipToolTip.InitialDelay = 500;
            this.tipToolTip.ReshowDelay = 100;
            // 
            // txtEventId
            // 
            this.txtEventId.Location = new System.Drawing.Point(132, 108);
            this.txtEventId.Name = "txtEventId";
            this.txtEventId.Size = new System.Drawing.Size(237, 23);
            this.txtEventId.TabIndex = 26;
            this.txtEventId.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEventId_KeyPress);
            // 
            // rtxEventMessage
            // 
            this.rtxEventMessage.Location = new System.Drawing.Point(132, 137);
            this.rtxEventMessage.Name = "rtxEventMessage";
            this.rtxEventMessage.Size = new System.Drawing.Size(636, 74);
            this.rtxEventMessage.TabIndex = 27;
            this.rtxEventMessage.Text = "";
            // 
            // lblEventId
            // 
            this.lblEventId.AutoSize = true;
            this.lblEventId.Location = new System.Drawing.Point(19, 108);
            this.lblEventId.Name = "lblEventId";
            this.lblEventId.Size = new System.Drawing.Size(61, 16);
            this.lblEventId.TabIndex = 28;
            this.lblEventId.Text = "Event ID";
            // 
            // MainTestForm
            // 
            this.AcceptButton = this.btnCreate;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 282);
            this.Controls.Add(this.pnlActions);
            this.Controls.Add(this.pnlSearchConditions);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(800, 320);
            this.Name = "MainTestForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WinEventLog Filter";
            this.pnlSearchConditions.ResumeLayout(false);
            this.grpSearchConditions.ResumeLayout(false);
            this.grpSearchConditions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numRepeatNo)).EndInit();
            this.pnlActions.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlSearchConditions;
        private System.Windows.Forms.Panel pnlActions;
        private System.Windows.Forms.GroupBox grpSearchConditions;
        private System.Windows.Forms.ComboBox cmbEventLog;
        private System.Windows.Forms.Label lblEventLog;
        private System.Windows.Forms.ComboBox cmbEvenType;
        private System.Windows.Forms.Label lblEventType;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.ToolTip tipToolTip;
        private System.Windows.Forms.Label lblEventMessage;
        private System.Windows.Forms.Label lblRepeatNo;
        private System.Windows.Forms.NumericUpDown numRepeatNo;
        private System.Windows.Forms.Label lblEventId;
        private System.Windows.Forms.RichTextBox rtxEventMessage;
        private System.Windows.Forms.TextBox txtEventId;
        //private System.Windows.Forms.ComboBox cmbLocalNetworkAdrs;
    }
}

