Imports ComponentFactory
Imports ComponentFactory.Krypton.Navigator
Imports ComponentFactory.Krypton.Toolkit

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits Krypton.Toolkit.KryptonForm

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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.mainPanel = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonNavigator1 = New ComponentFactory.Krypton.Navigator.KryptonNavigator()
        Me.KryptonPage1 = New ComponentFactory.Krypton.Navigator.KryptonPage()
        Me.gvr = New ComponentFactory.Krypton.Toolkit.KryptonDataGridView()
        Me.F1DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.F2DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.F3DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.F4DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.F5DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.F6DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.F7DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.F8DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.F9DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.F10DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.F11DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.F12DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.F13DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.F14DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.F15DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.F16DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RnDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColorDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RARBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ds = New LTFFAlloc25.ods()
        Me.KryptonPage2 = New ComponentFactory.Krypton.Navigator.KryptonPage()
        Me.gvm = New ComponentFactory.Krypton.Toolkit.KryptonDataGridView()
        Me.C1DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.C2DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.C3DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.C4DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.C5DataGridViewTextBoxColumn = New ComponentFactory.Krypton.Toolkit.KryptonDataGridViewNumericUpDownColumn()
        Me.C12DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.C13DataGridViewTextBoxColumn = New ComponentFactory.Krypton.Toolkit.KryptonDataGridViewNumericUpDownColumn()
        Me.C18DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.C19DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.C20DataGridViewTextBoxColumn = New ComponentFactory.Krypton.Toolkit.KryptonDataGridViewNumericUpDownColumn()
        Me.C21DataGridViewTextBoxColumn = New ComponentFactory.Krypton.Toolkit.KryptonDataGridViewNumericUpDownColumn()
        Me.C22DataGridViewTextBoxColumn = New ComponentFactory.Krypton.Toolkit.KryptonDataGridViewNumericUpDownColumn()
        Me.C23DataGridViewTextBoxColumn = New ComponentFactory.Krypton.Toolkit.KryptonDataGridViewNumericUpDownColumn()
        Me.MktSpecBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ExchangeRateBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.IndexMundiBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.KryptonPage5 = New ComponentFactory.Krypton.Navigator.KryptonPage()
        Me.gvo = New ComponentFactory.Krypton.Toolkit.KryptonDataGridView()
        Me.colc110 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colc24 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OptionsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.oRefreshAllButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton3 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton4 = New System.Windows.Forms.ToolStripSplitButton()
        Me.PDFToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExcelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CSVToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HTMLToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton5 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton6 = New System.Windows.Forms.ToolStripButton()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.oStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.oFolderLoc = New System.Windows.Forms.ToolStripStatusLabel()
        CType(Me.mainPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.mainPanel.SuspendLayout()
        CType(Me.KryptonNavigator1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonNavigator1.SuspendLayout()
        CType(Me.KryptonPage1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPage1.SuspendLayout()
        CType(Me.gvr, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RARBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ds, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonPage2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPage2.SuspendLayout()
        CType(Me.gvm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MktSpecBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ExchangeRateBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.IndexMundiBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonPage5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPage5.SuspendLayout()
        CType(Me.gvo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OptionsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'mainPanel
        '
        Me.mainPanel.Controls.Add(Me.KryptonNavigator1)
        Me.mainPanel.Controls.Add(Me.ToolStrip1)
        Me.mainPanel.Controls.Add(Me.StatusStrip1)
        Me.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.mainPanel.Location = New System.Drawing.Point(0, 0)
        Me.mainPanel.Name = "mainPanel"
        Me.mainPanel.Size = New System.Drawing.Size(1232, 621)
        Me.mainPanel.TabIndex = 0
        '
        'KryptonNavigator1
        '
        Me.KryptonNavigator1.Bar.ItemSizing = ComponentFactory.Krypton.Navigator.BarItemSizing.SameWidth
        Me.KryptonNavigator1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonNavigator1.Location = New System.Drawing.Point(0, 34)
        Me.KryptonNavigator1.Name = "KryptonNavigator1"
        Me.KryptonNavigator1.Pages.AddRange(New ComponentFactory.Krypton.Navigator.KryptonPage() {Me.KryptonPage1, Me.KryptonPage2, Me.KryptonPage5})
        Me.KryptonNavigator1.SelectedIndex = 2
        Me.KryptonNavigator1.Size = New System.Drawing.Size(1232, 555)
        Me.KryptonNavigator1.TabIndex = 1
        Me.KryptonNavigator1.Text = "KryptonNavigator1"
        '
        'KryptonPage1
        '
        Me.KryptonPage1.AutoHiddenSlideSize = New System.Drawing.Size(200, 200)
        Me.KryptonPage1.Controls.Add(Me.gvr)
        Me.KryptonPage1.Flags = 65534
        Me.KryptonPage1.LastVisibleSet = True
        Me.KryptonPage1.MinimumSize = New System.Drawing.Size(50, 50)
        Me.KryptonPage1.Name = "KryptonPage1"
        Me.KryptonPage1.Size = New System.Drawing.Size(1230, 519)
        Me.KryptonPage1.Text = "RAR"
        Me.KryptonPage1.ToolTipTitle = "Page ToolTip"
        Me.KryptonPage1.UniqueName = "D182CA08210C473436A2AEE2C8FAA12E"
        '
        'gvr
        '
        Me.gvr.AutoGenerateColumns = False
        Me.gvr.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.gvr.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.gvr.ColumnHeadersHeight = 30
        Me.gvr.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.F1DataGridViewTextBoxColumn, Me.F2DataGridViewTextBoxColumn, Me.F3DataGridViewTextBoxColumn, Me.F4DataGridViewTextBoxColumn, Me.F5DataGridViewTextBoxColumn, Me.F6DataGridViewTextBoxColumn, Me.F7DataGridViewTextBoxColumn, Me.F8DataGridViewTextBoxColumn, Me.F9DataGridViewTextBoxColumn, Me.F10DataGridViewTextBoxColumn, Me.F11DataGridViewTextBoxColumn, Me.F12DataGridViewTextBoxColumn, Me.F13DataGridViewTextBoxColumn, Me.F14DataGridViewTextBoxColumn, Me.F15DataGridViewTextBoxColumn, Me.F16DataGridViewTextBoxColumn, Me.RnDataGridViewTextBoxColumn, Me.ColorDataGridViewTextBoxColumn})
        Me.gvr.DataSource = Me.RARBindingSource
        Me.gvr.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gvr.Location = New System.Drawing.Point(0, 0)
        Me.gvr.Name = "gvr"
        Me.gvr.ReadOnly = True
        Me.gvr.RowHeadersWidth = 30
        Me.gvr.Size = New System.Drawing.Size(1230, 519)
        Me.gvr.TabIndex = 0
        '
        'F1DataGridViewTextBoxColumn
        '
        Me.F1DataGridViewTextBoxColumn.DataPropertyName = "F1"
        Me.F1DataGridViewTextBoxColumn.HeaderText = "F1"
        Me.F1DataGridViewTextBoxColumn.MinimumWidth = 8
        Me.F1DataGridViewTextBoxColumn.Name = "F1DataGridViewTextBoxColumn"
        Me.F1DataGridViewTextBoxColumn.ReadOnly = True
        Me.F1DataGridViewTextBoxColumn.Width = 71
        '
        'F2DataGridViewTextBoxColumn
        '
        Me.F2DataGridViewTextBoxColumn.DataPropertyName = "F2"
        Me.F2DataGridViewTextBoxColumn.HeaderText = "F2"
        Me.F2DataGridViewTextBoxColumn.MinimumWidth = 8
        Me.F2DataGridViewTextBoxColumn.Name = "F2DataGridViewTextBoxColumn"
        Me.F2DataGridViewTextBoxColumn.ReadOnly = True
        Me.F2DataGridViewTextBoxColumn.Width = 71
        '
        'F3DataGridViewTextBoxColumn
        '
        Me.F3DataGridViewTextBoxColumn.DataPropertyName = "F3"
        Me.F3DataGridViewTextBoxColumn.HeaderText = "F3"
        Me.F3DataGridViewTextBoxColumn.MinimumWidth = 8
        Me.F3DataGridViewTextBoxColumn.Name = "F3DataGridViewTextBoxColumn"
        Me.F3DataGridViewTextBoxColumn.ReadOnly = True
        Me.F3DataGridViewTextBoxColumn.Width = 71
        '
        'F4DataGridViewTextBoxColumn
        '
        Me.F4DataGridViewTextBoxColumn.DataPropertyName = "F4"
        Me.F4DataGridViewTextBoxColumn.HeaderText = "F4"
        Me.F4DataGridViewTextBoxColumn.MinimumWidth = 8
        Me.F4DataGridViewTextBoxColumn.Name = "F4DataGridViewTextBoxColumn"
        Me.F4DataGridViewTextBoxColumn.ReadOnly = True
        Me.F4DataGridViewTextBoxColumn.Width = 71
        '
        'F5DataGridViewTextBoxColumn
        '
        Me.F5DataGridViewTextBoxColumn.DataPropertyName = "F5"
        Me.F5DataGridViewTextBoxColumn.HeaderText = "F5"
        Me.F5DataGridViewTextBoxColumn.MinimumWidth = 8
        Me.F5DataGridViewTextBoxColumn.Name = "F5DataGridViewTextBoxColumn"
        Me.F5DataGridViewTextBoxColumn.ReadOnly = True
        Me.F5DataGridViewTextBoxColumn.Width = 71
        '
        'F6DataGridViewTextBoxColumn
        '
        Me.F6DataGridViewTextBoxColumn.DataPropertyName = "F6"
        Me.F6DataGridViewTextBoxColumn.HeaderText = "F6"
        Me.F6DataGridViewTextBoxColumn.MinimumWidth = 8
        Me.F6DataGridViewTextBoxColumn.Name = "F6DataGridViewTextBoxColumn"
        Me.F6DataGridViewTextBoxColumn.ReadOnly = True
        Me.F6DataGridViewTextBoxColumn.Width = 71
        '
        'F7DataGridViewTextBoxColumn
        '
        Me.F7DataGridViewTextBoxColumn.DataPropertyName = "F7"
        Me.F7DataGridViewTextBoxColumn.HeaderText = "F7"
        Me.F7DataGridViewTextBoxColumn.MinimumWidth = 8
        Me.F7DataGridViewTextBoxColumn.Name = "F7DataGridViewTextBoxColumn"
        Me.F7DataGridViewTextBoxColumn.ReadOnly = True
        Me.F7DataGridViewTextBoxColumn.Width = 71
        '
        'F8DataGridViewTextBoxColumn
        '
        Me.F8DataGridViewTextBoxColumn.DataPropertyName = "F8"
        Me.F8DataGridViewTextBoxColumn.HeaderText = "F8"
        Me.F8DataGridViewTextBoxColumn.MinimumWidth = 8
        Me.F8DataGridViewTextBoxColumn.Name = "F8DataGridViewTextBoxColumn"
        Me.F8DataGridViewTextBoxColumn.ReadOnly = True
        Me.F8DataGridViewTextBoxColumn.Width = 71
        '
        'F9DataGridViewTextBoxColumn
        '
        Me.F9DataGridViewTextBoxColumn.DataPropertyName = "F9"
        Me.F9DataGridViewTextBoxColumn.HeaderText = "F9"
        Me.F9DataGridViewTextBoxColumn.MinimumWidth = 8
        Me.F9DataGridViewTextBoxColumn.Name = "F9DataGridViewTextBoxColumn"
        Me.F9DataGridViewTextBoxColumn.ReadOnly = True
        Me.F9DataGridViewTextBoxColumn.Width = 71
        '
        'F10DataGridViewTextBoxColumn
        '
        Me.F10DataGridViewTextBoxColumn.DataPropertyName = "F10"
        Me.F10DataGridViewTextBoxColumn.HeaderText = "F10"
        Me.F10DataGridViewTextBoxColumn.MinimumWidth = 8
        Me.F10DataGridViewTextBoxColumn.Name = "F10DataGridViewTextBoxColumn"
        Me.F10DataGridViewTextBoxColumn.ReadOnly = True
        Me.F10DataGridViewTextBoxColumn.Width = 81
        '
        'F11DataGridViewTextBoxColumn
        '
        Me.F11DataGridViewTextBoxColumn.DataPropertyName = "F11"
        Me.F11DataGridViewTextBoxColumn.HeaderText = "F11"
        Me.F11DataGridViewTextBoxColumn.MinimumWidth = 8
        Me.F11DataGridViewTextBoxColumn.Name = "F11DataGridViewTextBoxColumn"
        Me.F11DataGridViewTextBoxColumn.ReadOnly = True
        Me.F11DataGridViewTextBoxColumn.Width = 81
        '
        'F12DataGridViewTextBoxColumn
        '
        Me.F12DataGridViewTextBoxColumn.DataPropertyName = "F12"
        Me.F12DataGridViewTextBoxColumn.HeaderText = "F12"
        Me.F12DataGridViewTextBoxColumn.MinimumWidth = 8
        Me.F12DataGridViewTextBoxColumn.Name = "F12DataGridViewTextBoxColumn"
        Me.F12DataGridViewTextBoxColumn.ReadOnly = True
        Me.F12DataGridViewTextBoxColumn.Width = 81
        '
        'F13DataGridViewTextBoxColumn
        '
        Me.F13DataGridViewTextBoxColumn.DataPropertyName = "F13"
        Me.F13DataGridViewTextBoxColumn.HeaderText = "F13"
        Me.F13DataGridViewTextBoxColumn.MinimumWidth = 8
        Me.F13DataGridViewTextBoxColumn.Name = "F13DataGridViewTextBoxColumn"
        Me.F13DataGridViewTextBoxColumn.ReadOnly = True
        Me.F13DataGridViewTextBoxColumn.Width = 81
        '
        'F14DataGridViewTextBoxColumn
        '
        Me.F14DataGridViewTextBoxColumn.DataPropertyName = "F14"
        Me.F14DataGridViewTextBoxColumn.HeaderText = "F14"
        Me.F14DataGridViewTextBoxColumn.MinimumWidth = 8
        Me.F14DataGridViewTextBoxColumn.Name = "F14DataGridViewTextBoxColumn"
        Me.F14DataGridViewTextBoxColumn.ReadOnly = True
        Me.F14DataGridViewTextBoxColumn.Width = 81
        '
        'F15DataGridViewTextBoxColumn
        '
        Me.F15DataGridViewTextBoxColumn.DataPropertyName = "F15"
        Me.F15DataGridViewTextBoxColumn.HeaderText = "F15"
        Me.F15DataGridViewTextBoxColumn.MinimumWidth = 8
        Me.F15DataGridViewTextBoxColumn.Name = "F15DataGridViewTextBoxColumn"
        Me.F15DataGridViewTextBoxColumn.ReadOnly = True
        Me.F15DataGridViewTextBoxColumn.Width = 81
        '
        'F16DataGridViewTextBoxColumn
        '
        Me.F16DataGridViewTextBoxColumn.DataPropertyName = "F16"
        Me.F16DataGridViewTextBoxColumn.HeaderText = "F16"
        Me.F16DataGridViewTextBoxColumn.MinimumWidth = 8
        Me.F16DataGridViewTextBoxColumn.Name = "F16DataGridViewTextBoxColumn"
        Me.F16DataGridViewTextBoxColumn.ReadOnly = True
        Me.F16DataGridViewTextBoxColumn.Width = 81
        '
        'RnDataGridViewTextBoxColumn
        '
        Me.RnDataGridViewTextBoxColumn.DataPropertyName = "rn"
        Me.RnDataGridViewTextBoxColumn.HeaderText = "rn"
        Me.RnDataGridViewTextBoxColumn.MinimumWidth = 8
        Me.RnDataGridViewTextBoxColumn.Name = "RnDataGridViewTextBoxColumn"
        Me.RnDataGridViewTextBoxColumn.ReadOnly = True
        Me.RnDataGridViewTextBoxColumn.Width = 68
        '
        'ColorDataGridViewTextBoxColumn
        '
        Me.ColorDataGridViewTextBoxColumn.DataPropertyName = "_color"
        Me.ColorDataGridViewTextBoxColumn.HeaderText = "_color"
        Me.ColorDataGridViewTextBoxColumn.MinimumWidth = 8
        Me.ColorDataGridViewTextBoxColumn.Name = "ColorDataGridViewTextBoxColumn"
        Me.ColorDataGridViewTextBoxColumn.ReadOnly = True
        Me.ColorDataGridViewTextBoxColumn.Width = 99
        '
        'RARBindingSource
        '
        Me.RARBindingSource.DataMember = "RAR"
        Me.RARBindingSource.DataSource = Me.ds
        '
        'ds
        '
        Me.ds.DataSetName = "ods"
        Me.ds.EnforceConstraints = False
        Me.ds.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'KryptonPage2
        '
        Me.KryptonPage2.AutoHiddenSlideSize = New System.Drawing.Size(200, 200)
        Me.KryptonPage2.Controls.Add(Me.gvm)
        Me.KryptonPage2.Flags = 65534
        Me.KryptonPage2.LastVisibleSet = True
        Me.KryptonPage2.MinimumSize = New System.Drawing.Size(50, 50)
        Me.KryptonPage2.Name = "KryptonPage2"
        Me.KryptonPage2.Size = New System.Drawing.Size(1230, 519)
        Me.KryptonPage2.Text = "MktSpec"
        Me.KryptonPage2.ToolTipTitle = "Page ToolTip"
        Me.KryptonPage2.UniqueName = "D73F1584A33D482AC88125F64B8625EC"
        '
        'gvm
        '
        Me.gvm.AutoGenerateColumns = False
        Me.gvm.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.gvm.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.gvm.ColumnHeadersHeight = 30
        Me.gvm.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.C1DataGridViewTextBoxColumn, Me.C2DataGridViewTextBoxColumn, Me.C3DataGridViewTextBoxColumn, Me.C4DataGridViewTextBoxColumn, Me.C5DataGridViewTextBoxColumn, Me.C12DataGridViewTextBoxColumn, Me.C13DataGridViewTextBoxColumn, Me.C18DataGridViewTextBoxColumn, Me.C19DataGridViewTextBoxColumn, Me.C20DataGridViewTextBoxColumn, Me.C21DataGridViewTextBoxColumn, Me.C22DataGridViewTextBoxColumn, Me.C23DataGridViewTextBoxColumn})
        Me.gvm.DataSource = Me.MktSpecBindingSource
        Me.gvm.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gvm.Location = New System.Drawing.Point(0, 0)
        Me.gvm.Name = "gvm"
        Me.gvm.RowHeadersWidth = 30
        Me.gvm.RowTemplate.Height = 28
        Me.gvm.Size = New System.Drawing.Size(1230, 519)
        Me.gvm.TabIndex = 0
        '
        'C1DataGridViewTextBoxColumn
        '
        Me.C1DataGridViewTextBoxColumn.DataPropertyName = "c1"
        Me.C1DataGridViewTextBoxColumn.HeaderText = "File Name"
        Me.C1DataGridViewTextBoxColumn.MinimumWidth = 8
        Me.C1DataGridViewTextBoxColumn.Name = "C1DataGridViewTextBoxColumn"
        Me.C1DataGridViewTextBoxColumn.Width = 130
        '
        'C2DataGridViewTextBoxColumn
        '
        Me.C2DataGridViewTextBoxColumn.DataPropertyName = "c2"
        Me.C2DataGridViewTextBoxColumn.HeaderText = "Commodity Name"
        Me.C2DataGridViewTextBoxColumn.MinimumWidth = 8
        Me.C2DataGridViewTextBoxColumn.Name = "C2DataGridViewTextBoxColumn"
        Me.C2DataGridViewTextBoxColumn.Width = 199
        '
        'C3DataGridViewTextBoxColumn
        '
        Me.C3DataGridViewTextBoxColumn.DataPropertyName = "c3"
        Me.C3DataGridViewTextBoxColumn.HeaderText = "Point Value $Local"
        Me.C3DataGridViewTextBoxColumn.MinimumWidth = 8
        Me.C3DataGridViewTextBoxColumn.Name = "C3DataGridViewTextBoxColumn"
        Me.C3DataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.C3DataGridViewTextBoxColumn.Width = 194
        '
        'C4DataGridViewTextBoxColumn
        '
        Me.C4DataGridViewTextBoxColumn.DataPropertyName = "c4"
        Me.C4DataGridViewTextBoxColumn.HeaderText = "Point Value $US"
        Me.C4DataGridViewTextBoxColumn.MinimumWidth = 8
        Me.C4DataGridViewTextBoxColumn.Name = "C4DataGridViewTextBoxColumn"
        Me.C4DataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.C4DataGridViewTextBoxColumn.Width = 176
        '
        'C5DataGridViewTextBoxColumn
        '
        Me.C5DataGridViewTextBoxColumn.DataPropertyName = "c5"
        Me.C5DataGridViewTextBoxColumn.DecimalPlaces = 6
        Me.C5DataGridViewTextBoxColumn.HeaderText = "Min Tick"
        Me.C5DataGridViewTextBoxColumn.MinimumWidth = 8
        Me.C5DataGridViewTextBoxColumn.Name = "C5DataGridViewTextBoxColumn"
        Me.C5DataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.C5DataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.C5DataGridViewTextBoxColumn.Width = 117
        '
        'C12DataGridViewTextBoxColumn
        '
        Me.C12DataGridViewTextBoxColumn.DataPropertyName = "c12"
        Me.C12DataGridViewTextBoxColumn.HeaderText = "FX"
        Me.C12DataGridViewTextBoxColumn.MinimumWidth = 8
        Me.C12DataGridViewTextBoxColumn.Name = "C12DataGridViewTextBoxColumn"
        Me.C12DataGridViewTextBoxColumn.Width = 72
        '
        'C13DataGridViewTextBoxColumn
        '
        Me.C13DataGridViewTextBoxColumn.DataPropertyName = "c13"
        Me.C13DataGridViewTextBoxColumn.DecimalPlaces = 4
        Me.C13DataGridViewTextBoxColumn.HeaderText = "Ex Rate"
        Me.C13DataGridViewTextBoxColumn.MinimumWidth = 8
        Me.C13DataGridViewTextBoxColumn.Name = "C13DataGridViewTextBoxColumn"
        Me.C13DataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.C13DataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.C13DataGridViewTextBoxColumn.Width = 109
        '
        'C18DataGridViewTextBoxColumn
        '
        Me.C18DataGridViewTextBoxColumn.DataPropertyName = "c18"
        Me.C18DataGridViewTextBoxColumn.HeaderText = "Trd"
        Me.C18DataGridViewTextBoxColumn.MinimumWidth = 8
        Me.C18DataGridViewTextBoxColumn.Name = "C18DataGridViewTextBoxColumn"
        Me.C18DataGridViewTextBoxColumn.Width = 76
        '
        'C19DataGridViewTextBoxColumn
        '
        Me.C19DataGridViewTextBoxColumn.DataPropertyName = "c19"
        Me.C19DataGridViewTextBoxColumn.HeaderText = "OP (B or S)"
        Me.C19DataGridViewTextBoxColumn.MinimumWidth = 8
        Me.C19DataGridViewTextBoxColumn.Name = "C19DataGridViewTextBoxColumn"
        Me.C19DataGridViewTextBoxColumn.Width = 138
        '
        'C20DataGridViewTextBoxColumn
        '
        Me.C20DataGridViewTextBoxColumn.DataPropertyName = "c20"
        Me.C20DataGridViewTextBoxColumn.HeaderText = "# of Contract"
        Me.C20DataGridViewTextBoxColumn.Maximum = New Decimal(New Integer() {-727379968, 232, 0, 0})
        Me.C20DataGridViewTextBoxColumn.MinimumWidth = 8
        Me.C20DataGridViewTextBoxColumn.Name = "C20DataGridViewTextBoxColumn"
        Me.C20DataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.C20DataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.C20DataGridViewTextBoxColumn.Width = 157
        '
        'C21DataGridViewTextBoxColumn
        '
        Me.C21DataGridViewTextBoxColumn.DataPropertyName = "c21"
        Me.C21DataGridViewTextBoxColumn.DecimalPlaces = 2
        Me.C21DataGridViewTextBoxColumn.HeaderText = "Alloc Weight (Wt)"
        Me.C21DataGridViewTextBoxColumn.MinimumWidth = 8
        Me.C21DataGridViewTextBoxColumn.Name = "C21DataGridViewTextBoxColumn"
        Me.C21DataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.C21DataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.C21DataGridViewTextBoxColumn.Width = 190
        '
        'C22DataGridViewTextBoxColumn
        '
        Me.C22DataGridViewTextBoxColumn.DataPropertyName = "c22"
        Me.C22DataGridViewTextBoxColumn.DecimalPlaces = 2
        Me.C22DataGridViewTextBoxColumn.HeaderText = "MktCMI (Buy)"
        Me.C22DataGridViewTextBoxColumn.MinimumWidth = 8
        Me.C22DataGridViewTextBoxColumn.Name = "C22DataGridViewTextBoxColumn"
        Me.C22DataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.C22DataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.C22DataGridViewTextBoxColumn.Width = 159
        '
        'C23DataGridViewTextBoxColumn
        '
        Me.C23DataGridViewTextBoxColumn.DataPropertyName = "c23"
        Me.C23DataGridViewTextBoxColumn.DecimalPlaces = 2
        Me.C23DataGridViewTextBoxColumn.HeaderText = "MktCMI (Sell)"
        Me.C23DataGridViewTextBoxColumn.Minimum = New Decimal(New Integer() {100, 0, 0, -2147483648})
        Me.C23DataGridViewTextBoxColumn.MinimumWidth = 8
        Me.C23DataGridViewTextBoxColumn.Name = "C23DataGridViewTextBoxColumn"
        Me.C23DataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.C23DataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.C23DataGridViewTextBoxColumn.Width = 157
        '
        'MktSpecBindingSource
        '
        Me.MktSpecBindingSource.DataMember = "MktSpec"
        Me.MktSpecBindingSource.DataSource = Me.ds
        '
        'ExchangeRateBindingSource
        '
        Me.ExchangeRateBindingSource.DataMember = "ExchangeRate"
        Me.ExchangeRateBindingSource.DataSource = Me.ds
        '
        'IndexMundiBindingSource
        '
        Me.IndexMundiBindingSource.DataMember = "IndexMundi"
        Me.IndexMundiBindingSource.DataSource = Me.ds
        '
        'KryptonPage5
        '
        Me.KryptonPage5.AutoHiddenSlideSize = New System.Drawing.Size(200, 200)
        Me.KryptonPage5.Controls.Add(Me.gvo)
        Me.KryptonPage5.Flags = 65534
        Me.KryptonPage5.LastVisibleSet = True
        Me.KryptonPage5.MinimumSize = New System.Drawing.Size(50, 50)
        Me.KryptonPage5.Name = "KryptonPage5"
        Me.KryptonPage5.Size = New System.Drawing.Size(1230, 519)
        Me.KryptonPage5.Text = "Options"
        Me.KryptonPage5.ToolTipTitle = "Page ToolTip"
        Me.KryptonPage5.UniqueName = "B58E8CD8ABBC4AF6EF87043174B230D5"
        '
        'gvo
        '
        Me.gvo.AllowUserToAddRows = False
        Me.gvo.AllowUserToDeleteRows = False
        Me.gvo.AutoGenerateColumns = False
        Me.gvo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.gvo.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.gvo.ColumnHeadersHeight = 28
        Me.gvo.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colc110, Me.colc24})
        Me.gvo.DataSource = Me.OptionsBindingSource
        Me.gvo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gvo.Location = New System.Drawing.Point(0, 0)
        Me.gvo.Name = "gvo"
        Me.gvo.RowHeadersVisible = False
        Me.gvo.RowHeadersWidth = 30
        Me.gvo.RowTemplate.Height = 28
        Me.gvo.Size = New System.Drawing.Size(1230, 519)
        Me.gvo.TabIndex = 0
        '
        'colc110
        '
        Me.colc110.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.colc110.DataPropertyName = "c1"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.colc110.DefaultCellStyle = DataGridViewCellStyle3
        Me.colc110.HeaderText = "ID"
        Me.colc110.MinimumWidth = 8
        Me.colc110.Name = "colc110"
        Me.colc110.Width = 70
        '
        'colc24
        '
        Me.colc24.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.colc24.DataPropertyName = "c2"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.colc24.DefaultCellStyle = DataGridViewCellStyle4
        Me.colc24.HeaderText = "Value"
        Me.colc24.MinimumWidth = 8
        Me.colc24.Name = "colc24"
        Me.colc24.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colc24.Width = 200
        '
        'OptionsBindingSource
        '
        Me.OptionsBindingSource.DataMember = "Options"
        Me.OptionsBindingSource.DataSource = Me.ds
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ToolStrip1.GripMargin = New System.Windows.Forms.Padding(0)
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(25, 25)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1, Me.ToolStripSeparator1, Me.oRefreshAllButton, Me.ToolStripSeparator2, Me.ToolStripButton3, Me.ToolStripSeparator3, Me.ToolStripButton4, Me.ToolStripSeparator4, Me.ToolStripButton5, Me.ToolStripButton6})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1232, 34)
        Me.ToolStrip1.TabIndex = 1
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ToolStripButton1.Image = Global.LTFFAlloc25.My.Resources.Resources.open_32x32
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(133, 29)
        Me.ToolStripButton1.Text = "Set Folder..."
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 34)
        '
        'oRefreshAllButton
        '
        Me.oRefreshAllButton.Image = Global.LTFFAlloc25.My.Resources.Resources.refresh_16x16
        Me.oRefreshAllButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.oRefreshAllButton.Name = "oRefreshAllButton"
        Me.oRefreshAllButton.Size = New System.Drawing.Size(99, 29)
        Me.oRefreshAllButton.Text = "Refresh"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 34)
        '
        'ToolStripButton3
        '
        Me.ToolStripButton3.Image = Global.LTFFAlloc25.My.Resources.Resources._2010BlueContextMenuSub
        Me.ToolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton3.Name = "ToolStripButton3"
        Me.ToolStripButton3.Size = New System.Drawing.Size(167, 29)
        Me.ToolStripButton3.Text = "Update MktCMI"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 34)
        '
        'ToolStripButton4
        '
        Me.ToolStripButton4.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PDFToolStripMenuItem, Me.ExcelToolStripMenuItem, Me.CSVToolStripMenuItem, Me.HTMLToolStripMenuItem})
        Me.ToolStripButton4.Image = Global.LTFFAlloc25.My.Resources.Resources.export_32x32
        Me.ToolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton4.Name = "ToolStripButton4"
        Me.ToolStripButton4.Size = New System.Drawing.Size(109, 29)
        Me.ToolStripButton4.Text = "Export"
        '
        'PDFToolStripMenuItem
        '
        Me.PDFToolStripMenuItem.Name = "PDFToolStripMenuItem"
        Me.PDFToolStripMenuItem.Size = New System.Drawing.Size(160, 34)
        Me.PDFToolStripMenuItem.Text = "PDF"
        '
        'ExcelToolStripMenuItem
        '
        Me.ExcelToolStripMenuItem.Name = "ExcelToolStripMenuItem"
        Me.ExcelToolStripMenuItem.Size = New System.Drawing.Size(160, 34)
        Me.ExcelToolStripMenuItem.Text = "Excel"
        '
        'CSVToolStripMenuItem
        '
        Me.CSVToolStripMenuItem.Name = "CSVToolStripMenuItem"
        Me.CSVToolStripMenuItem.Size = New System.Drawing.Size(160, 34)
        Me.CSVToolStripMenuItem.Text = "CSV"
        '
        'HTMLToolStripMenuItem
        '
        Me.HTMLToolStripMenuItem.Name = "HTMLToolStripMenuItem"
        Me.HTMLToolStripMenuItem.Size = New System.Drawing.Size(160, 34)
        Me.HTMLToolStripMenuItem.Text = "HTML"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 34)
        '
        'ToolStripButton5
        '
        Me.ToolStripButton5.Image = Global.LTFFAlloc25.My.Resources.Resources.add_32x32
        Me.ToolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton5.Name = "ToolStripButton5"
        Me.ToolStripButton5.Size = New System.Drawing.Size(75, 29)
        Me.ToolStripButton5.Text = "Add"
        Me.ToolStripButton5.Visible = False
        '
        'ToolStripButton6
        '
        Me.ToolStripButton6.Image = Global.LTFFAlloc25.My.Resources.Resources.remove_32x32
        Me.ToolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton6.Name = "ToolStripButton6"
        Me.ToolStripButton6.Size = New System.Drawing.Size(91, 29)
        Me.ToolStripButton6.Text = "Delete"
        Me.ToolStripButton6.Visible = False
        '
        'StatusStrip1
        '
        Me.StatusStrip1.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.oStatus, Me.oFolderLoc})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 589)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Padding = New System.Windows.Forms.Padding(0)
        Me.StatusStrip1.Size = New System.Drawing.Size(1232, 32)
        Me.StatusStrip1.SizingGrip = False
        Me.StatusStrip1.TabIndex = 3
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'oStatus
        '
        Me.oStatus.AutoSize = False
        Me.oStatus.Name = "oStatus"
        Me.oStatus.Size = New System.Drawing.Size(1052, 25)
        Me.oStatus.Spring = True
        Me.oStatus.Text = "Ready"
        Me.oStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'oFolderLoc
        '
        Me.oFolderLoc.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.oFolderLoc.AutoSize = False
        Me.oFolderLoc.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left
        Me.oFolderLoc.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedOuter
        Me.oFolderLoc.Name = "oFolderLoc"
        Me.oFolderLoc.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.oFolderLoc.Size = New System.Drawing.Size(180, 25)
        Me.oFolderLoc.Text = "C:\Data"
        Me.oFolderLoc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1232, 621)
        Me.Controls.Add(Me.mainPanel)
        Me.Name = "Form1"
        Me.Text = "LTTF Alloc v25.1"
        CType(Me.mainPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.mainPanel.ResumeLayout(False)
        Me.mainPanel.PerformLayout()
        CType(Me.KryptonNavigator1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonNavigator1.ResumeLayout(False)
        CType(Me.KryptonPage1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPage1.ResumeLayout(False)
        CType(Me.gvr, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RARBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ds, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KryptonPage2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPage2.ResumeLayout(False)
        CType(Me.gvm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MktSpecBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ExchangeRateBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.IndexMundiBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KryptonPage5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPage5.ResumeLayout(False)
        CType(Me.gvo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OptionsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents KryptonNavigator1 As ComponentFactory.Krypton.Navigator.KryptonNavigator
    Friend WithEvents KryptonPage1 As ComponentFactory.Krypton.Navigator.KryptonPage
    Friend WithEvents KryptonPage2 As ComponentFactory.Krypton.Navigator.KryptonPage
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents ToolStripButton1 As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents oRefreshAllButton As ToolStripButton
    Friend WithEvents ToolStripButton3 As ToolStripButton
    Friend WithEvents KryptonPage5 As ComponentFactory.Krypton.Navigator.KryptonPage
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents oStatus As ToolStripStatusLabel
    Friend WithEvents oFolderLoc As ToolStripStatusLabel
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents gvr As ComponentFactory.Krypton.Toolkit.KryptonDataGridView
    Friend WithEvents ds As ods
    Friend WithEvents F1DataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents F2DataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents F3DataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents F4DataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents F5DataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents F6DataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents F7DataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents F8DataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents F9DataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents F10DataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents F11DataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents F12DataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents F13DataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents F14DataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents F15DataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents F16DataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents RnDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents ColorDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents RARBindingSource As BindingSource
    Friend WithEvents gvm As ComponentFactory.Krypton.Toolkit.KryptonDataGridView
    Friend WithEvents MktSpecBindingSource As BindingSource
    Friend WithEvents ExchangeRateBindingSource As BindingSource
    Friend WithEvents IndexMundiBindingSource As BindingSource
    Friend WithEvents OptionsBindingSource As BindingSource
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents ToolStripButton4 As ToolStripSplitButton
    Friend WithEvents PDFToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ExcelToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CSVToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents HTMLToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
    Friend WithEvents ToolStripButton5 As ToolStripButton
    Friend WithEvents ToolStripButton6 As ToolStripButton
    Friend WithEvents mainPanel As Krypton.Toolkit.KryptonPanel
    Friend WithEvents C1DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents C2DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents gvo As KryptonDataGridView
    Friend WithEvents C1DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn
    Friend WithEvents C2DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents colc110 As DataGridViewTextBoxColumn
    Friend WithEvents colc24 As DataGridViewTextBoxColumn
    Friend WithEvents C1DataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents C2DataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents C3DataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents C4DataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents C5DataGridViewTextBoxColumn As KryptonDataGridViewNumericUpDownColumn
    Friend WithEvents C12DataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents C13DataGridViewTextBoxColumn As KryptonDataGridViewNumericUpDownColumn
    Friend WithEvents C18DataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents C19DataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents C20DataGridViewTextBoxColumn As KryptonDataGridViewNumericUpDownColumn
    Friend WithEvents C21DataGridViewTextBoxColumn As KryptonDataGridViewNumericUpDownColumn
    Friend WithEvents C22DataGridViewTextBoxColumn As KryptonDataGridViewNumericUpDownColumn
    Friend WithEvents C23DataGridViewTextBoxColumn As KryptonDataGridViewNumericUpDownColumn
End Class
