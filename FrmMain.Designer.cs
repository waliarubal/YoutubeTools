namespace YoutubeTools;

partial class FrmMain
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
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
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        dgvWindows = new DataGridView();
        colHandle = new DataGridViewTextBoxColumn();
        colTitle = new DataGridViewTextBoxColumn();
        colState = new DataGridViewTextBoxColumn();
        label1 = new Label();
        txtVideoKey = new TextBox();
        label2 = new Label();
        updnInstances = new NumericUpDown();
        btnRun = new Button();
        label3 = new Label();
        updnReplay = new NumericUpDown();
        btnStop = new Button();
        ((System.ComponentModel.ISupportInitialize)dgvWindows).BeginInit();
        ((System.ComponentModel.ISupportInitialize)updnInstances).BeginInit();
        ((System.ComponentModel.ISupportInitialize)updnReplay).BeginInit();
        SuspendLayout();
        // 
        // dgvWindows
        // 
        dgvWindows.AllowUserToAddRows = false;
        dgvWindows.AllowUserToDeleteRows = false;
        dgvWindows.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        dgvWindows.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvWindows.Columns.AddRange(new DataGridViewColumn[] { colHandle, colTitle, colState });
        dgvWindows.Location = new Point(12, 70);
        dgvWindows.Name = "dgvWindows";
        dgvWindows.ReadOnly = true;
        dgvWindows.RowTemplate.Height = 25;
        dgvWindows.Size = new Size(600, 359);
        dgvWindows.TabIndex = 0;
        // 
        // colHandle
        // 
        colHandle.HeaderText = "Handle";
        colHandle.Name = "colHandle";
        colHandle.ReadOnly = true;
        // 
        // colTitle
        // 
        colTitle.HeaderText = "Title";
        colTitle.Name = "colTitle";
        colTitle.ReadOnly = true;
        // 
        // colState
        // 
        colState.HeaderText = "State";
        colState.Name = "colState";
        colState.ReadOnly = true;
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Location = new Point(12, 15);
        label1.Name = "label1";
        label1.Size = new Size(62, 15);
        label1.TabIndex = 1;
        label1.Text = "Video Key:";
        // 
        // txtVideoKey
        // 
        txtVideoKey.Location = new Point(80, 12);
        txtVideoKey.Name = "txtVideoKey";
        txtVideoKey.Size = new Size(160, 23);
        txtVideoKey.TabIndex = 2;
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.Location = new Point(487, 15);
        label2.Name = "label2";
        label2.Size = new Size(59, 15);
        label2.TabIndex = 3;
        label2.Text = "Instances:";
        // 
        // updnInstances
        // 
        updnInstances.Location = new Point(552, 13);
        updnInstances.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
        updnInstances.Name = "updnInstances";
        updnInstances.Size = new Size(60, 23);
        updnInstances.TabIndex = 4;
        updnInstances.Value = new decimal(new int[] { 10, 0, 0, 0 });
        // 
        // btnRun
        // 
        btnRun.Location = new Point(456, 41);
        btnRun.Name = "btnRun";
        btnRun.Size = new Size(75, 23);
        btnRun.TabIndex = 5;
        btnRun.Text = "Start";
        btnRun.UseVisualStyleBackColor = true;
        btnRun.Click += btnRun_Click;
        // 
        // label3
        // 
        label3.AutoSize = true;
        label3.Location = new Point(271, 15);
        label3.Name = "label3";
        label3.Size = new Size(135, 15);
        label3.TabIndex = 6;
        label3.Text = "Replay Check (minutes):";
        // 
        // updnReplay
        // 
        updnReplay.Location = new Point(412, 12);
        updnReplay.Maximum = new decimal(new int[] { 30, 0, 0, 0 });
        updnReplay.Name = "updnReplay";
        updnReplay.Size = new Size(60, 23);
        updnReplay.TabIndex = 7;
        updnReplay.Value = new decimal(new int[] { 2, 0, 0, 0 });
        // 
        // btnStop
        // 
        btnStop.Enabled = false;
        btnStop.Location = new Point(537, 41);
        btnStop.Name = "btnStop";
        btnStop.Size = new Size(75, 23);
        btnStop.TabIndex = 8;
        btnStop.Text = "Stop";
        btnStop.UseVisualStyleBackColor = true;
        btnStop.Click += btnStop_Click;
        // 
        // FrmMain
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(624, 441);
        Controls.Add(btnStop);
        Controls.Add(updnReplay);
        Controls.Add(label3);
        Controls.Add(btnRun);
        Controls.Add(updnInstances);
        Controls.Add(label2);
        Controls.Add(txtVideoKey);
        Controls.Add(label1);
        Controls.Add(dgvWindows);
        Name = "FrmMain";
        Text = "YouTube Tools";
        FormClosing += FrmMain_FormClosing;
        Load += FrmMain_Load;
        ((System.ComponentModel.ISupportInitialize)dgvWindows).EndInit();
        ((System.ComponentModel.ISupportInitialize)updnInstances).EndInit();
        ((System.ComponentModel.ISupportInitialize)updnReplay).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private DataGridView dgvWindows;
    private DataGridViewTextBoxColumn colHandle;
    private DataGridViewTextBoxColumn colTitle;
    private DataGridViewTextBoxColumn colState;
    private Label label1;
    private TextBox txtVideoKey;
    private Label label2;
    private NumericUpDown updnInstances;
    private Button btnRun;
    private Label label3;
    private NumericUpDown updnReplay;
    private Button btnStop;
}
