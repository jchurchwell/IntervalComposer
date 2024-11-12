<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        components = New ComponentModel.Container()
        Timer1 = New Timer(components)
        ProgressBarOverall = New ProgressBar()
        ButtonStart = New Button()
        ProgressBarSetTime = New ProgressBar()
        LabelTimeRemaining = New Label()
        GroupBoxRecipe = New GroupBox()
        DataGridView1 = New DataGridView()
        ColumnName = New DataGridViewTextBoxColumn()
        ColumnDuration = New DataGridViewTextBoxColumn()
        MenuStrip1 = New MenuStrip()
        FileToolStripMenuItem = New ToolStripMenuItem()
        LoadRecipeToolStripMenuItem = New ToolStripMenuItem()
        ToolStripMenuItem1 = New ToolStripSeparator()
        ExitToolStripMenuItem = New ToolStripMenuItem()
        OpenFileDialog1 = New OpenFileDialog()
        LabelName = New Label()
        GroupBoxRecipe.SuspendLayout()
        CType(DataGridView1, ComponentModel.ISupportInitialize).BeginInit()
        MenuStrip1.SuspendLayout()
        SuspendLayout()
        ' 
        ' Timer1
        ' 
        ' 
        ' ProgressBarOverall
        ' 
        ProgressBarOverall.Dock = DockStyle.Top
        ProgressBarOverall.Location = New Point(0, 38)
        ProgressBarOverall.Name = "ProgressBarOverall"
        ProgressBarOverall.Size = New Size(459, 27)
        ProgressBarOverall.Style = ProgressBarStyle.Continuous
        ProgressBarOverall.TabIndex = 0
        ' 
        ' ButtonStart
        ' 
        ButtonStart.Font = New Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        ButtonStart.Location = New Point(12, 98)
        ButtonStart.Name = "ButtonStart"
        ButtonStart.Size = New Size(199, 64)
        ButtonStart.TabIndex = 1
        ButtonStart.Text = "Start"
        ButtonStart.UseVisualStyleBackColor = True
        ' 
        ' ProgressBarSetTime
        ' 
        ProgressBarSetTime.Dock = DockStyle.Top
        ProgressBarSetTime.Location = New Point(0, 65)
        ProgressBarSetTime.Name = "ProgressBarSetTime"
        ProgressBarSetTime.Size = New Size(459, 32)
        ProgressBarSetTime.Style = ProgressBarStyle.Continuous
        ProgressBarSetTime.TabIndex = 2
        ' 
        ' LabelTimeRemaining
        ' 
        LabelTimeRemaining.BorderStyle = BorderStyle.FixedSingle
        LabelTimeRemaining.Font = New Font("Courier New", 72F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        LabelTimeRemaining.Location = New Point(12, 165)
        LabelTimeRemaining.Name = "LabelTimeRemaining"
        LabelTimeRemaining.Size = New Size(435, 102)
        LabelTimeRemaining.TabIndex = 3
        LabelTimeRemaining.TextAlign = ContentAlignment.MiddleRight
        ' 
        ' GroupBoxRecipe
        ' 
        GroupBoxRecipe.Controls.Add(DataGridView1)
        GroupBoxRecipe.Dock = DockStyle.Bottom
        GroupBoxRecipe.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        GroupBoxRecipe.Location = New Point(0, 278)
        GroupBoxRecipe.Name = "GroupBoxRecipe"
        GroupBoxRecipe.Size = New Size(459, 245)
        GroupBoxRecipe.TabIndex = 4
        GroupBoxRecipe.TabStop = False
        GroupBoxRecipe.Text = "Recipe"
        ' 
        ' DataGridView1
        ' 
        DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridView1.Columns.AddRange(New DataGridViewColumn() {ColumnName, ColumnDuration})
        DataGridView1.Dock = DockStyle.Fill
        DataGridView1.Location = New Point(3, 25)
        DataGridView1.MultiSelect = False
        DataGridView1.Name = "DataGridView1"
        DataGridView1.RowHeadersVisible = False
        DataGridView1.RowHeadersWidth = 200
        DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        DataGridView1.Size = New Size(453, 217)
        DataGridView1.TabIndex = 0
        ' 
        ' ColumnName
        ' 
        ColumnName.AutoSizeMode = DataGridViewAutoSizeColumnMode.None
        ColumnName.HeaderText = "Name"
        ColumnName.Name = "ColumnName"
        ColumnName.SortMode = DataGridViewColumnSortMode.NotSortable
        ColumnName.Width = 300
        ' 
        ' ColumnDuration
        ' 
        ColumnDuration.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        ColumnDuration.HeaderText = "Duration"
        ColumnDuration.MinimumWidth = 105
        ColumnDuration.Name = "ColumnDuration"
        ColumnDuration.SortMode = DataGridViewColumnSortMode.NotSortable
        ColumnDuration.Width = 105
        ' 
        ' MenuStrip1
        ' 
        MenuStrip1.Font = New Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        MenuStrip1.Items.AddRange(New ToolStripItem() {FileToolStripMenuItem})
        MenuStrip1.Location = New Point(0, 0)
        MenuStrip1.Name = "MenuStrip1"
        MenuStrip1.Size = New Size(459, 38)
        MenuStrip1.TabIndex = 5
        MenuStrip1.Text = "MenuStrip1"
        ' 
        ' FileToolStripMenuItem
        ' 
        FileToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {LoadRecipeToolStripMenuItem, ToolStripMenuItem1, ExitToolStripMenuItem})
        FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        FileToolStripMenuItem.Size = New Size(56, 34)
        FileToolStripMenuItem.Text = "File"
        ' 
        ' LoadRecipeToolStripMenuItem
        ' 
        LoadRecipeToolStripMenuItem.Name = "LoadRecipeToolStripMenuItem"
        LoadRecipeToolStripMenuItem.Size = New Size(198, 34)
        LoadRecipeToolStripMenuItem.Text = "&Load Recipe"
        ' 
        ' ToolStripMenuItem1
        ' 
        ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        ToolStripMenuItem1.Size = New Size(195, 6)
        ' 
        ' ExitToolStripMenuItem
        ' 
        ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        ExitToolStripMenuItem.Size = New Size(198, 34)
        ExitToolStripMenuItem.Text = "E&xit"
        ' 
        ' OpenFileDialog1
        ' 
        OpenFileDialog1.FileName = "OpenFileDialog1"
        ' 
        ' LabelName
        ' 
        LabelName.BorderStyle = BorderStyle.FixedSingle
        LabelName.Font = New Font("Segoe UI", 21.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        LabelName.Location = New Point(12, 106)
        LabelName.Name = "LabelName"
        LabelName.Size = New Size(435, 41)
        LabelName.TabIndex = 6
        LabelName.TextAlign = ContentAlignment.MiddleCenter
        LabelName.Visible = False
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(459, 523)
        Controls.Add(LabelName)
        Controls.Add(GroupBoxRecipe)
        Controls.Add(LabelTimeRemaining)
        Controls.Add(ProgressBarSetTime)
        Controls.Add(ButtonStart)
        Controls.Add(ProgressBarOverall)
        Controls.Add(MenuStrip1)
        MainMenuStrip = MenuStrip1
        MaximizeBox = False
        Name = "Form1"
        Text = "Interval Composer"
        GroupBoxRecipe.ResumeLayout(False)
        CType(DataGridView1, ComponentModel.ISupportInitialize).EndInit()
        MenuStrip1.ResumeLayout(False)
        MenuStrip1.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Timer1 As Timer
    Friend WithEvents ProgressBarOverall As ProgressBar
    Friend WithEvents ButtonStart As Button
    Friend WithEvents ProgressBarSetTime As ProgressBar
    Friend WithEvents LabelTimeRemaining As Label
    Friend WithEvents GroupBoxRecipe As GroupBox
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents ColumnName As DataGridViewTextBoxColumn
    Friend WithEvents ColumnDuration As DataGridViewTextBoxColumn
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents FileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents LoadRecipeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As ToolStripSeparator
    Friend WithEvents ExitToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents LabelName As Label

End Class
