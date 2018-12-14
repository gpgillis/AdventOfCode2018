namespace AdventOfCode2018.Day10Visualizer
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
            this._pauseButton = new System.Windows.Forms.Button();
            this._runButton = new System.Windows.Forms.Button();
            this._graphicsPanel = new System.Windows.Forms.Panel();
            this._delayTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this._doGraphicTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this._normalizerTextBox = new System.Windows.Forms.TextBox();
            this._reloadButton = new System.Windows.Forms.Button();
            this._elapsedSecondsLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // _pauseButton
            // 
            this._pauseButton.Location = new System.Drawing.Point(537, 622);
            this._pauseButton.Name = "_pauseButton";
            this._pauseButton.Size = new System.Drawing.Size(75, 23);
            this._pauseButton.TabIndex = 0;
            this._pauseButton.Text = "Pause";
            this._pauseButton.UseVisualStyleBackColor = true;
            this._pauseButton.Click += new System.EventHandler(this._pauseButton_Click);
            // 
            // _runButton
            // 
            this._runButton.Location = new System.Drawing.Point(456, 622);
            this._runButton.Name = "_runButton";
            this._runButton.Size = new System.Drawing.Size(75, 23);
            this._runButton.TabIndex = 1;
            this._runButton.Text = "Run";
            this._runButton.UseVisualStyleBackColor = true;
            this._runButton.Click += new System.EventHandler(this._runButton_Click);
            // 
            // _graphicsPanel
            // 
            this._graphicsPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._graphicsPanel.Location = new System.Drawing.Point(12, 16);
            this._graphicsPanel.Name = "_graphicsPanel";
            this._graphicsPanel.Size = new System.Drawing.Size(600, 600);
            this._graphicsPanel.TabIndex = 2;
            // 
            // _delayTextBox
            // 
            this._delayTextBox.Location = new System.Drawing.Point(256, 624);
            this._delayTextBox.Name = "_delayTextBox";
            this._delayTextBox.Size = new System.Drawing.Size(35, 20);
            this._delayTextBox.TabIndex = 3;
            this._delayTextBox.TextChanged += new System.EventHandler(this._delayTextBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(214, 627);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Delay:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(102, 628);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "DoGraphic:";
            // 
            // _doGraphicTextBox
            // 
            this._doGraphicTextBox.Location = new System.Drawing.Point(167, 625);
            this._doGraphicTextBox.Name = "_doGraphicTextBox";
            this._doGraphicTextBox.Size = new System.Drawing.Size(40, 20);
            this._doGraphicTextBox.TabIndex = 5;
            this._doGraphicTextBox.TextChanged += new System.EventHandler(this._doGraphicTextBox_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 628);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Norm:";
            // 
            // _normalizerTextBox
            // 
            this._normalizerTextBox.Location = new System.Drawing.Point(47, 625);
            this._normalizerTextBox.Name = "_normalizerTextBox";
            this._normalizerTextBox.Size = new System.Drawing.Size(47, 20);
            this._normalizerTextBox.TabIndex = 7;
            this._normalizerTextBox.TextChanged += new System.EventHandler(this._normalizerTextBox_TextChanged);
            // 
            // _reloadButton
            // 
            this._reloadButton.Location = new System.Drawing.Point(375, 622);
            this._reloadButton.Name = "_reloadButton";
            this._reloadButton.Size = new System.Drawing.Size(75, 23);
            this._reloadButton.TabIndex = 9;
            this._reloadButton.Text = "ReLoad";
            this._reloadButton.UseVisualStyleBackColor = true;
            this._reloadButton.Click += new System.EventHandler(this._reloadButton_Click);
            // 
            // _elapsedSecondsLabel
            // 
            this._elapsedSecondsLabel.AutoSize = true;
            this._elapsedSecondsLabel.Location = new System.Drawing.Point(316, 627);
            this._elapsedSecondsLabel.Name = "_elapsedSecondsLabel";
            this._elapsedSecondsLabel.Size = new System.Drawing.Size(45, 13);
            this._elapsedSecondsLabel.TabIndex = 10;
            this._elapsedSecondsLabel.Text = "Elapsed";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(627, 650);
            this.Controls.Add(this._elapsedSecondsLabel);
            this.Controls.Add(this._reloadButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this._normalizerTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this._doGraphicTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._delayTextBox);
            this.Controls.Add(this._runButton);
            this.Controls.Add(this._pauseButton);
            this.Controls.Add(this._graphicsPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MainForm";
            this.Text = "AOC - Day 10 Visualizer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button _pauseButton;
        private System.Windows.Forms.Button _runButton;
        private System.Windows.Forms.Panel _graphicsPanel;
        private System.Windows.Forms.TextBox _delayTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox _doGraphicTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox _normalizerTextBox;
        private System.Windows.Forms.Button _reloadButton;
        private System.Windows.Forms.Label _elapsedSecondsLabel;
    }
}

