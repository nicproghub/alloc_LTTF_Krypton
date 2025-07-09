Imports DevExpress.Pdf.Native

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MainForm
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Dim GridFormatRule1 As DevExpress.XtraGrid.GridFormatRule = New DevExpress.XtraGrid.GridFormatRule()
        Dim FormatConditionRuleValue1 As DevExpress.XtraEditors.FormatConditionRuleValue = New DevExpress.XtraEditors.FormatConditionRuleValue()
        Dim GridFormatRule2 As DevExpress.XtraGrid.GridFormatRule = New DevExpress.XtraGrid.GridFormatRule()
        Dim FormatConditionRuleValue2 As DevExpress.XtraEditors.FormatConditionRuleValue = New DevExpress.XtraEditors.FormatConditionRuleValue()
        Dim GridFormatRule3 As DevExpress.XtraGrid.GridFormatRule = New DevExpress.XtraGrid.GridFormatRule()
        Dim FormatConditionRuleValue3 As DevExpress.XtraEditors.FormatConditionRuleValue = New DevExpress.XtraEditors.FormatConditionRuleValue()
        Me.col_color = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colF15 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colF16 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.bm = New DevExpress.XtraBars.BarManager(Me.components)
        Me.Bar1 = New DevExpress.XtraBars.Bar()
        Me.oSetFolderButton = New DevExpress.XtraBars.BarButtonItem()
        Me.oRefreshAllButton = New DevExpress.XtraBars.BarButtonItem()
        Me.oMktMciUpdateButton = New DevExpress.XtraBars.BarButtonItem()
        Me.SkinBarSubItem1 = New DevExpress.XtraBars.SkinBarSubItem()
        Me.Bar3 = New DevExpress.XtraBars.Bar()
        Me.oStatus = New DevExpress.XtraBars.BarStaticItem()
        Me.oFolderLoc = New DevExpress.XtraBars.BarButtonItem()
        Me.Bar4 = New DevExpress.XtraBars.Bar()
        Me.BarStaticItem6 = New DevExpress.XtraBars.BarStaticItem()
        Me.BarSubItem1 = New DevExpress.XtraBars.BarSubItem()
        Me.oRiskExport_PDF = New DevExpress.XtraBars.BarButtonItem()
        Me.oRiskExport_Excel = New DevExpress.XtraBars.BarButtonItem()
        Me.oRiskExport_CSV = New DevExpress.XtraBars.BarButtonItem()
        Me.oRiskExport_Html = New DevExpress.XtraBars.BarButtonItem()
        Me.Bar5 = New DevExpress.XtraBars.Bar()
        Me.BarStaticItem3 = New DevExpress.XtraBars.BarStaticItem()
        Me.StandaloneBarDockControl5 = New DevExpress.XtraBars.StandaloneBarDockControl()
        Me.Bar6 = New DevExpress.XtraBars.Bar()
        Me.BarStaticItem5 = New DevExpress.XtraBars.BarStaticItem()
        Me.oExportButton = New DevExpress.XtraBars.BarSubItem()
        Me.oRarExport_PDF = New DevExpress.XtraBars.BarButtonItem()
        Me.oRarExport_Excel = New DevExpress.XtraBars.BarButtonItem()
        Me.oRarExport_Csv = New DevExpress.XtraBars.BarButtonItem()
        Me.oRarExport_Html = New DevExpress.XtraBars.BarButtonItem()
        Me.StandaloneBarDockControl2 = New DevExpress.XtraBars.StandaloneBarDockControl()
        Me.Bar7 = New DevExpress.XtraBars.Bar()
        Me.BarStaticItem1 = New DevExpress.XtraBars.BarStaticItem()
        Me.oAddButton = New DevExpress.XtraBars.BarButtonItem()
        Me.oDeleteButton = New DevExpress.XtraBars.BarButtonItem()
        Me.BarEditItem1 = New DevExpress.XtraBars.BarEditItem()
        Me.RepositoryItemSearchControl1 = New DevExpress.XtraEditors.Repository.RepositoryItemSearchControl()
        Me.gcm = New DevExpress.XtraGrid.GridControl()
        Me.bsMkt = New System.Windows.Forms.BindingSource(Me.components)
        Me.ds = New LTFFAlloc2.ods()
        Me.pr = New DevExpress.XtraEditors.Repository.PersistentRepository(Me.components)
        Me.rpYesNo = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.gvm = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colc11 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colc21 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colc31 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colc41 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colc51 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colc71 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colc91 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colc10 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colc111 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colc12 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colc13 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colc14 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colc15 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colc16 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colc17 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colc18 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colc19 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colc20 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colc211 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colc22 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colc23 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BarButtonItem1 = New DevExpress.XtraBars.BarButtonItem()
        Me.StandaloneBarDockControl3 = New DevExpress.XtraBars.StandaloneBarDockControl()
        Me.Bar8 = New DevExpress.XtraBars.Bar()
        Me.BarStaticItem4 = New DevExpress.XtraBars.BarStaticItem()
        Me.StandaloneBarDockControl4 = New DevExpress.XtraBars.StandaloneBarDockControl()
        Me.Bar9 = New DevExpress.XtraBars.Bar()
        Me.BarStaticItem2 = New DevExpress.XtraBars.BarStaticItem()
        Me.StandaloneBarDockControl6 = New DevExpress.XtraBars.StandaloneBarDockControl()
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.oCalcButton = New DevExpress.XtraBars.BarButtonItem()
        Me.ttc = New DevExpress.Utils.DefaultToolTipController(Me.components)
        Me.oNav = New DevExpress.XtraBars.Navigation.NavigationFrame()
        Me.s1 = New DevExpress.XtraBars.Navigation.NavigationPage()
        Me.gcr = New DevExpress.XtraGrid.GridControl()
        Me.bsRar = New System.Windows.Forms.BindingSource(Me.components)
        Me.gvr = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colF1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colF2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colF3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colF4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colF5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colF6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colF7 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colF8 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colF9 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colF10 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colF11 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colF12 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colF13 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.s3 = New DevExpress.XtraBars.Navigation.NavigationPage()
        Me.s5 = New DevExpress.XtraBars.Navigation.NavigationPage()
        Me.gci = New DevExpress.XtraGrid.GridControl()
        Me.bsMundi = New System.Windows.Forms.BindingSource(Me.components)
        Me.gvi = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colxArea = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colxCurrency = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colxDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colxInverse = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colxRate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.s6 = New DevExpress.XtraBars.Navigation.NavigationPage()
        Me.gco = New DevExpress.XtraGrid.GridControl()
        Me.bsOptions = New System.Windows.Forms.BindingSource(Me.components)
        Me.gvo = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colc110 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colc24 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.s4 = New DevExpress.XtraBars.Navigation.NavigationPage()
        Me.gce = New DevExpress.XtraGrid.GridControl()
        Me.bsExchange = New System.Windows.Forms.BindingSource(Me.components)
        Me.gve = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colxChange1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colxCountry1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colxCurrency1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colxDat01 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colxDat11 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colid = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.bsSector = New System.Windows.Forms.BindingSource(Me.components)
        Me.OfficeNavigationBar1 = New DevExpress.XtraBars.Navigation.OfficeNavigationBar()
        Me.dlf = New DevExpress.LookAndFeel.DefaultLookAndFeel(Me.components)
        Me.ssm = New DevExpress.XtraSplashScreen.SplashScreenManager(Me, GetType(Global.LTFFAlloc2.WaitForm1), False, False)
        Me.bwRefresh = New System.ComponentModel.BackgroundWorker()
        Me.bwCalc = New System.ComponentModel.BackgroundWorker()
        Me.bwWeb = New System.ComponentModel.BackgroundWorker()
        Me.bwMkt = New System.ComponentModel.BackgroundWorker()
        Me.sfd = New System.Windows.Forms.SaveFileDialog()
        Me.fbd = New System.Windows.Forms.FolderBrowserDialog()
        CType(Me.bm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemSearchControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gcm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bsMkt, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ds, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rpYesNo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gvm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.oNav, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.oNav.SuspendLayout()
        Me.s1.SuspendLayout()
        CType(Me.gcr, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bsRar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gvr, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.s3.SuspendLayout()
        Me.s5.SuspendLayout()
        CType(Me.gci, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bsMundi, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gvi, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.s6.SuspendLayout()
        CType(Me.gco, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bsOptions, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gvo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.s4.SuspendLayout()
        CType(Me.gce, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bsExchange, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gve, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bsSector, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OfficeNavigationBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'col_color
        '
        Me.col_color.FieldName = "_color"
        Me.col_color.MinWidth = 30
        Me.col_color.Name = "col_color"
        Me.col_color.OptionsColumn.ShowInCustomizationForm = False
        Me.col_color.OptionsColumn.ShowInExpressionEditor = False
        Me.col_color.Width = 112
        '
        'colF15
        '
        Me.colF15.Caption = "MktCMI (Buy)"
        Me.colF15.DisplayFormat.FormatString = "n2"
        Me.colF15.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colF15.FieldName = "F15"
        Me.colF15.MinWidth = 75
        Me.colF15.Name = "colF15"
        Me.colF15.OptionsColumn.FixedWidth = True
        Me.colF15.Visible = True
        Me.colF15.VisibleIndex = 13
        Me.colF15.Width = 97
        '
        'colF16
        '
        Me.colF16.Caption = "MktCMI (Sell)"
        Me.colF16.DisplayFormat.FormatString = "n2"
        Me.colF16.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colF16.FieldName = "F16"
        Me.colF16.MinWidth = 75
        Me.colF16.Name = "colF16"
        Me.colF16.OptionsColumn.FixedWidth = True
        Me.colF16.Visible = True
        Me.colF16.VisibleIndex = 14
        Me.colF16.Width = 97
        '
        'bm
        '
        Me.bm.Bars.AddRange(New DevExpress.XtraBars.Bar() {Me.Bar1, Me.Bar3, Me.Bar4, Me.Bar5, Me.Bar6, Me.Bar7, Me.Bar8, Me.Bar9})
        Me.bm.DockControls.Add(Me.barDockControlTop)
        Me.bm.DockControls.Add(Me.barDockControlBottom)
        Me.bm.DockControls.Add(Me.barDockControlLeft)
        Me.bm.DockControls.Add(Me.barDockControlRight)
        Me.bm.DockControls.Add(Me.StandaloneBarDockControl2)
        Me.bm.DockControls.Add(Me.StandaloneBarDockControl3)
        Me.bm.DockControls.Add(Me.StandaloneBarDockControl4)
        Me.bm.DockControls.Add(Me.StandaloneBarDockControl5)
        Me.bm.DockControls.Add(Me.StandaloneBarDockControl6)
        Me.bm.Form = Me
        Me.bm.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.oRefreshAllButton, Me.oCalcButton, Me.oMktMciUpdateButton, Me.oStatus, Me.oExportButton, Me.oRarExport_PDF, Me.oRarExport_Excel, Me.oRarExport_Csv, Me.oRarExport_Html, Me.BarSubItem1, Me.oRiskExport_PDF, Me.oRiskExport_Excel, Me.oRiskExport_CSV, Me.oRiskExport_Html, Me.oSetFolderButton, Me.oFolderLoc, Me.BarStaticItem1, Me.BarStaticItem2, Me.BarStaticItem3, Me.BarStaticItem4, Me.BarStaticItem5, Me.BarStaticItem6, Me.oAddButton, Me.oDeleteButton, Me.SkinBarSubItem1, Me.BarEditItem1, Me.BarButtonItem1})
        Me.bm.MaxItemId = 36
        Me.bm.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemSearchControl1})
        Me.bm.StatusBar = Me.Bar3
        '
        'Bar1
        '
        Me.Bar1.BarName = "Tools"
        Me.Bar1.DockCol = 0
        Me.Bar1.DockRow = 0
        Me.Bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
        Me.Bar1.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.oSetFolderButton, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.oRefreshAllButton, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(Me.oMktMciUpdateButton, True), New DevExpress.XtraBars.LinkPersistInfo(Me.SkinBarSubItem1)})
        Me.Bar1.OptionsBar.AllowQuickCustomization = False
        Me.Bar1.OptionsBar.DisableClose = True
        Me.Bar1.OptionsBar.DisableCustomization = True
        Me.Bar1.OptionsBar.DrawDragBorder = False
        Me.Bar1.OptionsBar.UseWholeRow = True
        Me.Bar1.Text = "Tools"
        '
        'oSetFolderButton
        '
        Me.oSetFolderButton.Caption = "Set Folder..."
        Me.oSetFolderButton.Id = 22
        Me.oSetFolderButton.ImageOptions.Image = Global.LTFFAlloc2.My.Resources.Resources.open_16x16
        Me.oSetFolderButton.ImageOptions.LargeImage = Global.LTFFAlloc2.My.Resources.Resources.open_32x32
        Me.oSetFolderButton.Name = "oSetFolderButton"
        '
        'oRefreshAllButton
        '
        Me.oRefreshAllButton.Caption = "Refresh"
        Me.oRefreshAllButton.Id = 5
        Me.oRefreshAllButton.ImageOptions.Image = Global.LTFFAlloc2.My.Resources.Resources.refresh_16x16
        Me.oRefreshAllButton.Name = "oRefreshAllButton"
        '
        'oMktMciUpdateButton
        '
        Me.oMktMciUpdateButton.Caption = "Update MktCMI"
        Me.oMktMciUpdateButton.Id = 8
        Me.oMktMciUpdateButton.Name = "oMktMciUpdateButton"
        '
        'SkinBarSubItem1
        '
        Me.SkinBarSubItem1.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right
        Me.SkinBarSubItem1.Caption = "Skins"
        Me.SkinBarSubItem1.Id = 33
        Me.SkinBarSubItem1.Name = "SkinBarSubItem1"
        '
        'Bar3
        '
        Me.Bar3.BarName = "Status bar"
        Me.Bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom
        Me.Bar3.DockCol = 0
        Me.Bar3.DockRow = 0
        Me.Bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom
        Me.Bar3.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.oStatus), New DevExpress.XtraBars.LinkPersistInfo(Me.oFolderLoc)})
        Me.Bar3.OptionsBar.AllowQuickCustomization = False
        Me.Bar3.OptionsBar.DrawDragBorder = False
        Me.Bar3.OptionsBar.UseWholeRow = True
        Me.Bar3.Text = "Status bar"
        '
        'oStatus
        '
        Me.oStatus.AutoSize = DevExpress.XtraBars.BarStaticItemSize.Spring
        Me.oStatus.Caption = "Ready"
        Me.oStatus.Id = 9
        Me.oStatus.Name = "oStatus"
        Me.oStatus.Size = New System.Drawing.Size(32, 0)
        Me.oStatus.Width = 32
        '
        'oFolderLoc
        '
        Me.oFolderLoc.Caption = "c:\"
        Me.oFolderLoc.Id = 23
        Me.oFolderLoc.Name = "oFolderLoc"
        '
        'Bar4
        '
        Me.Bar4.BarName = "Custom 5"
        Me.Bar4.DockCol = 0
        Me.Bar4.DockRow = 0
        Me.Bar4.DockStyle = DevExpress.XtraBars.BarDockStyle.Standalone
        Me.Bar4.FloatLocation = New System.Drawing.Point(118, 213)
        Me.Bar4.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.BarStaticItem6, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.BarSubItem1, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)})
        Me.Bar4.OptionsBar.AllowQuickCustomization = False
        Me.Bar4.OptionsBar.DisableClose = True
        Me.Bar4.OptionsBar.DisableCustomization = True
        Me.Bar4.OptionsBar.DrawDragBorder = False
        Me.Bar4.OptionsBar.UseWholeRow = True
        Me.Bar4.Text = "Custom 5"
        '
        'BarStaticItem6
        '
        Me.BarStaticItem6.Caption = "Risk"
        Me.BarStaticItem6.Id = 30
        Me.BarStaticItem6.ImageOptions.Image = Global.LTFFAlloc2.My.Resources.Resources.table_16x16
        Me.BarStaticItem6.Name = "BarStaticItem6"
        Me.BarStaticItem6.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph
        '
        'BarSubItem1
        '
        Me.BarSubItem1.Caption = "Export"
        Me.BarSubItem1.Id = 17
        Me.BarSubItem1.ImageOptions.Image = Global.LTFFAlloc2.My.Resources.Resources.export_16x16
        Me.BarSubItem1.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.oRiskExport_PDF), New DevExpress.XtraBars.LinkPersistInfo(Me.oRiskExport_Excel), New DevExpress.XtraBars.LinkPersistInfo(Me.oRiskExport_CSV), New DevExpress.XtraBars.LinkPersistInfo(Me.oRiskExport_Html)})
        Me.BarSubItem1.Name = "BarSubItem1"
        '
        'oRiskExport_PDF
        '
        Me.oRiskExport_PDF.Caption = "PDF"
        Me.oRiskExport_PDF.Id = 18
        Me.oRiskExport_PDF.Name = "oRiskExport_PDF"
        '
        'oRiskExport_Excel
        '
        Me.oRiskExport_Excel.Caption = "Excel"
        Me.oRiskExport_Excel.Id = 19
        Me.oRiskExport_Excel.Name = "oRiskExport_Excel"
        '
        'oRiskExport_CSV
        '
        Me.oRiskExport_CSV.Caption = "CSV"
        Me.oRiskExport_CSV.Id = 20
        Me.oRiskExport_CSV.Name = "oRiskExport_CSV"
        '
        'oRiskExport_Html
        '
        Me.oRiskExport_Html.Caption = "HTML"
        Me.oRiskExport_Html.Id = 21
        Me.oRiskExport_Html.Name = "oRiskExport_Html"
        '
        'Bar5
        '
        Me.Bar5.BarName = "Custom 6"
        Me.Bar5.DockCol = 0
        Me.Bar5.DockRow = 0
        Me.Bar5.DockStyle = DevExpress.XtraBars.BarDockStyle.Standalone
        Me.Bar5.FloatLocation = New System.Drawing.Point(46, 221)
        Me.Bar5.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.BarStaticItem3, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)})
        Me.Bar5.OptionsBar.AllowQuickCustomization = False
        Me.Bar5.OptionsBar.DisableClose = True
        Me.Bar5.OptionsBar.DisableCustomization = True
        Me.Bar5.OptionsBar.DrawDragBorder = False
        Me.Bar5.OptionsBar.UseWholeRow = True
        Me.Bar5.StandaloneBarDockControl = Me.StandaloneBarDockControl5
        Me.Bar5.Text = "Custom 6"
        '
        'BarStaticItem3
        '
        Me.BarStaticItem3.Caption = "IndexMundi"
        Me.BarStaticItem3.Id = 27
        Me.BarStaticItem3.ImageOptions.Image = Global.LTFFAlloc2.My.Resources.Resources.table_16x16
        Me.BarStaticItem3.ImageOptions.LargeImage = Global.LTFFAlloc2.My.Resources.Resources.table_32x32
        Me.BarStaticItem3.Name = "BarStaticItem3"
        Me.BarStaticItem3.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph
        '
        'StandaloneBarDockControl5
        '
        Me.StandaloneBarDockControl5.CausesValidation = False
        Me.StandaloneBarDockControl5.Dock = System.Windows.Forms.DockStyle.Top
        Me.StandaloneBarDockControl5.Location = New System.Drawing.Point(0, 0)
        Me.StandaloneBarDockControl5.Manager = Me.bm
        Me.StandaloneBarDockControl5.Margin = New System.Windows.Forms.Padding(4)
        Me.StandaloneBarDockControl5.Name = "StandaloneBarDockControl5"
        Me.StandaloneBarDockControl5.Size = New System.Drawing.Size(1157, 42)
        Me.StandaloneBarDockControl5.Text = "StandaloneBarDockControl5"
        '
        'Bar6
        '
        Me.Bar6.BarName = "Custom 7"
        Me.Bar6.DockCol = 0
        Me.Bar6.DockRow = 0
        Me.Bar6.DockStyle = DevExpress.XtraBars.BarDockStyle.Standalone
        Me.Bar6.FloatLocation = New System.Drawing.Point(47, 213)
        Me.Bar6.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.BarStaticItem5, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.oExportButton, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)})
        Me.Bar6.OptionsBar.AllowQuickCustomization = False
        Me.Bar6.OptionsBar.DisableClose = True
        Me.Bar6.OptionsBar.DisableCustomization = True
        Me.Bar6.OptionsBar.DrawDragBorder = False
        Me.Bar6.OptionsBar.UseWholeRow = True
        Me.Bar6.StandaloneBarDockControl = Me.StandaloneBarDockControl2
        Me.Bar6.Text = "Custom 7"
        '
        'BarStaticItem5
        '
        Me.BarStaticItem5.Caption = "RAR"
        Me.BarStaticItem5.Id = 29
        Me.BarStaticItem5.ImageOptions.Image = Global.LTFFAlloc2.My.Resources.Resources.table_16x16
        Me.BarStaticItem5.Name = "BarStaticItem5"
        Me.BarStaticItem5.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph
        '
        'oExportButton
        '
        Me.oExportButton.Caption = "Export"
        Me.oExportButton.Id = 12
        Me.oExportButton.ImageOptions.Image = Global.LTFFAlloc2.My.Resources.Resources.export_16x16
        Me.oExportButton.ImageOptions.LargeImage = Global.LTFFAlloc2.My.Resources.Resources.export_32x32
        Me.oExportButton.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.oRarExport_PDF), New DevExpress.XtraBars.LinkPersistInfo(Me.oRarExport_Excel), New DevExpress.XtraBars.LinkPersistInfo(Me.oRarExport_Csv), New DevExpress.XtraBars.LinkPersistInfo(Me.oRarExport_Html)})
        Me.oExportButton.Name = "oExportButton"
        '
        'oRarExport_PDF
        '
        Me.oRarExport_PDF.Caption = "PDF"
        Me.oRarExport_PDF.Id = 13
        Me.oRarExport_PDF.Name = "oRarExport_PDF"
        '
        'oRarExport_Excel
        '
        Me.oRarExport_Excel.Caption = "Excel"
        Me.oRarExport_Excel.Id = 14
        Me.oRarExport_Excel.Name = "oRarExport_Excel"
        '
        'oRarExport_Csv
        '
        Me.oRarExport_Csv.Caption = "CSV"
        Me.oRarExport_Csv.Id = 15
        Me.oRarExport_Csv.Name = "oRarExport_Csv"
        '
        'oRarExport_Html
        '
        Me.oRarExport_Html.Caption = "HTML"
        Me.oRarExport_Html.Id = 16
        Me.oRarExport_Html.Name = "oRarExport_Html"
        '
        'StandaloneBarDockControl2
        '
        Me.StandaloneBarDockControl2.CausesValidation = False
        Me.StandaloneBarDockControl2.Dock = System.Windows.Forms.DockStyle.Top
        Me.StandaloneBarDockControl2.Location = New System.Drawing.Point(0, 0)
        Me.StandaloneBarDockControl2.Manager = Me.bm
        Me.StandaloneBarDockControl2.Margin = New System.Windows.Forms.Padding(4)
        Me.StandaloneBarDockControl2.Name = "StandaloneBarDockControl2"
        Me.StandaloneBarDockControl2.Size = New System.Drawing.Size(1157, 42)
        Me.StandaloneBarDockControl2.Text = "StandaloneBarDockControl2"
        '
        'Bar7
        '
        Me.Bar7.BarName = "Custom 8"
        Me.Bar7.DockCol = 0
        Me.Bar7.DockRow = 0
        Me.Bar7.DockStyle = DevExpress.XtraBars.BarDockStyle.Standalone
        Me.Bar7.FloatLocation = New System.Drawing.Point(37, 213)
        Me.Bar7.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.BarStaticItem1, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.oAddButton, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.oDeleteButton, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.BarEditItem1, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.BarButtonItem1, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)})
        Me.Bar7.OptionsBar.AllowQuickCustomization = False
        Me.Bar7.OptionsBar.DisableClose = True
        Me.Bar7.OptionsBar.DisableCustomization = True
        Me.Bar7.OptionsBar.DrawDragBorder = False
        Me.Bar7.OptionsBar.UseWholeRow = True
        Me.Bar7.StandaloneBarDockControl = Me.StandaloneBarDockControl3
        Me.Bar7.Text = "Custom 8"
        '
        'BarStaticItem1
        '
        Me.BarStaticItem1.Caption = "MktSpec"
        Me.BarStaticItem1.Id = 24
        Me.BarStaticItem1.ImageOptions.Image = Global.LTFFAlloc2.My.Resources.Resources.table_16x16
        Me.BarStaticItem1.ImageOptions.LargeImage = CType(resources.GetObject("BarStaticItem1.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.BarStaticItem1.Name = "BarStaticItem1"
        Me.BarStaticItem1.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph
        '
        'oAddButton
        '
        Me.oAddButton.Caption = "Add"
        Me.oAddButton.Id = 31
        Me.oAddButton.ImageOptions.Image = Global.LTFFAlloc2.My.Resources.Resources.add_16x16
        Me.oAddButton.ImageOptions.LargeImage = Global.LTFFAlloc2.My.Resources.Resources.add_32x32
        Me.oAddButton.Name = "oAddButton"
        '
        'oDeleteButton
        '
        Me.oDeleteButton.Caption = "Delete"
        Me.oDeleteButton.Enabled = False
        Me.oDeleteButton.Id = 32
        Me.oDeleteButton.ImageOptions.Image = Global.LTFFAlloc2.My.Resources.Resources.remove_16x16
        Me.oDeleteButton.ImageOptions.LargeImage = Global.LTFFAlloc2.My.Resources.Resources.remove_32x32
        Me.oDeleteButton.Name = "oDeleteButton"
        '
        'BarEditItem1
        '
        Me.BarEditItem1.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right
        Me.BarEditItem1.Caption = "Find:"
        Me.BarEditItem1.Edit = Me.RepositoryItemSearchControl1
        Me.BarEditItem1.EditWidth = 150
        Me.BarEditItem1.Id = 34
        Me.BarEditItem1.Name = "BarEditItem1"
        '
        'RepositoryItemSearchControl1
        '
        Me.RepositoryItemSearchControl1.AutoHeight = False
        Me.RepositoryItemSearchControl1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Repository.ClearButton(), New DevExpress.XtraEditors.Repository.SearchButton()})
        Me.RepositoryItemSearchControl1.Client = Me.gcm
        Me.RepositoryItemSearchControl1.Name = "RepositoryItemSearchControl1"
        '
        'gcm
        '
        Me.gcm.DataSource = Me.bsMkt
        Me.gcm.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gcm.EmbeddedNavigator.Margin = New System.Windows.Forms.Padding(4)
        Me.gcm.ExternalRepository = Me.pr
        Me.gcm.Location = New System.Drawing.Point(0, 42)
        Me.gcm.MainView = Me.gvm
        Me.gcm.Margin = New System.Windows.Forms.Padding(4)
        Me.gcm.MenuManager = Me.bm
        Me.gcm.Name = "gcm"
        Me.gcm.Size = New System.Drawing.Size(1157, 373)
        Me.gcm.TabIndex = 2
        Me.gcm.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gvm})
        '
        'bsMkt
        '
        Me.bsMkt.DataMember = "MktSpec"
        Me.bsMkt.DataSource = Me.ds
        '
        'ds
        '
        Me.ds.DataSetName = "ods"
        Me.ds.EnforceConstraints = False
        Me.ds.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'pr
        '
        Me.pr.Items.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.rpYesNo})
        '
        'rpYesNo
        '
        Me.rpYesNo.Name = "rpYesNo"
        Me.rpYesNo.ValueChecked = ""
        Me.rpYesNo.ValueUnchecked = "No"
        '
        'gvm
        '
        Me.gvm.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.gvm.ColumnPanelRowHeight = 66
        Me.gvm.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colc11, Me.colc21, Me.colc31, Me.colc41, Me.colc51, Me.colc71, Me.colc91, Me.colc10, Me.colc111, Me.colc12, Me.colc13, Me.colc14, Me.colc15, Me.colc16, Me.colc17, Me.colc18, Me.colc19, Me.colc20, Me.colc211, Me.colc22, Me.colc23})
        Me.gvm.DetailHeight = 512
        Me.gvm.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus
        Me.gvm.GridControl = Me.gcm
        Me.gvm.Name = "gvm"
        Me.gvm.OptionsEditForm.PopupEditFormWidth = 1200
        Me.gvm.OptionsView.ColumnAutoWidth = False
        Me.gvm.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.[True]
        Me.gvm.OptionsView.ShowFooter = True
        Me.gvm.OptionsView.ShowGroupPanel = False
        Me.gvm.OptionsView.ShowIndicator = False
        '
        'colc11
        '
        Me.colc11.Caption = "CSI Symbol"
        Me.colc11.FieldName = "c1"
        Me.colc11.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
        Me.colc11.MinWidth = 112
        Me.colc11.Name = "colc11"
        Me.colc11.OptionsColumn.FixedWidth = True
        Me.colc11.Visible = True
        Me.colc11.VisibleIndex = 0
        '
        'colc21
        '
        Me.colc21.Caption = "Commodity Name"
        Me.colc21.FieldName = "c2"
        Me.colc21.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
        Me.colc21.MinWidth = 112
        Me.colc21.Name = "colc21"
        Me.colc21.Visible = True
        Me.colc21.VisibleIndex = 1
        Me.colc21.Width = 112
        '
        'colc31
        '
        Me.colc31.Caption = "Point Value $Local"
        Me.colc31.DisplayFormat.FormatString = "{0:n0}"
        Me.colc31.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colc31.FieldName = "c3"
        Me.colc31.MinWidth = 112
        Me.colc31.Name = "colc31"
        Me.colc31.OptionsColumn.FixedWidth = True
        Me.colc31.Visible = True
        Me.colc31.VisibleIndex = 2
        Me.colc31.Width = 112
        '
        'colc41
        '
        Me.colc41.Caption = "Point Value $US"
        Me.colc41.DisplayFormat.FormatString = "n2"
        Me.colc41.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colc41.FieldName = "c4"
        Me.colc41.MinWidth = 112
        Me.colc41.Name = "colc41"
        Me.colc41.OptionsColumn.AllowEdit = False
        Me.colc41.OptionsColumn.FixedWidth = True
        Me.colc41.Visible = True
        Me.colc41.VisibleIndex = 3
        Me.colc41.Width = 112
        '
        'colc51
        '
        Me.colc51.Caption = "Min Tick"
        Me.colc51.DisplayFormat.FormatString = "n4"
        Me.colc51.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colc51.FieldName = "c5"
        Me.colc51.MinWidth = 112
        Me.colc51.Name = "colc51"
        Me.colc51.OptionsColumn.FixedWidth = True
        Me.colc51.Visible = True
        Me.colc51.VisibleIndex = 4
        Me.colc51.Width = 112
        '
        'colc71
        '
        Me.colc71.Caption = "Sector"
        Me.colc71.FieldName = "c7"
        Me.colc71.MinWidth = 112
        Me.colc71.Name = "colc71"
        Me.colc71.OptionsColumn.FixedWidth = True
        Me.colc71.Width = 112
        '
        'colc91
        '
        Me.colc91.Caption = "Slip/RT (in ticks)"
        Me.colc91.DisplayFormat.FormatString = "n2"
        Me.colc91.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colc91.FieldName = "c9"
        Me.colc91.MinWidth = 75
        Me.colc91.Name = "colc91"
        Me.colc91.OptionsColumn.FixedWidth = True
        '
        'colc10
        '
        Me.colc10.Caption = "Comm/Rt LocalFX"
        Me.colc10.DisplayFormat.FormatString = "n2"
        Me.colc10.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colc10.FieldName = "c10"
        Me.colc10.MinWidth = 112
        Me.colc10.Name = "colc10"
        Me.colc10.OptionsColumn.FixedWidth = True
        Me.colc10.Width = 112
        '
        'colc111
        '
        Me.colc111.Caption = "Comm/RT $US"
        Me.colc111.DisplayFormat.FormatString = "n2"
        Me.colc111.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colc111.FieldName = "c11"
        Me.colc111.MinWidth = 112
        Me.colc111.Name = "colc111"
        Me.colc111.OptionsColumn.AllowEdit = False
        Me.colc111.OptionsColumn.FixedWidth = True
        Me.colc111.Width = 112
        '
        'colc12
        '
        Me.colc12.Caption = "FX"
        Me.colc12.FieldName = "c12"
        Me.colc12.MinWidth = 112
        Me.colc12.Name = "colc12"
        Me.colc12.OptionsColumn.FixedWidth = True
        Me.colc12.Visible = True
        Me.colc12.VisibleIndex = 5
        Me.colc12.Width = 112
        '
        'colc13
        '
        Me.colc13.Caption = "Exchange Rate"
        Me.colc13.DisplayFormat.FormatString = "n4"
        Me.colc13.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colc13.FieldName = "c13"
        Me.colc13.MinWidth = 90
        Me.colc13.Name = "colc13"
        Me.colc13.OptionsColumn.AllowEdit = False
        Me.colc13.OptionsColumn.FixedWidth = True
        Me.colc13.Visible = True
        Me.colc13.VisibleIndex = 6
        Me.colc13.Width = 90
        '
        'colc14
        '
        Me.colc14.Caption = "ATR"
        Me.colc14.DisplayFormat.FormatString = "n4"
        Me.colc14.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colc14.FieldName = "c14"
        Me.colc14.MinWidth = 112
        Me.colc14.Name = "colc14"
        Me.colc14.OptionsColumn.AllowEdit = False
        Me.colc14.OptionsColumn.FixedWidth = True
        Me.colc14.Visible = True
        Me.colc14.VisibleIndex = 7
        Me.colc14.Width = 112
        '
        'colc15
        '
        Me.colc15.Caption = "SlipRT / ATR[500]"
        Me.colc15.DisplayFormat.FormatString = "{0:p2}"
        Me.colc15.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colc15.FieldName = "c15"
        Me.colc15.MinWidth = 90
        Me.colc15.Name = "colc15"
        Me.colc15.OptionsColumn.FixedWidth = True
        Me.colc15.Width = 90
        '
        'colc16
        '
        Me.colc16.Caption = "CommRT / ATR[500]"
        Me.colc16.DisplayFormat.FormatString = "{0:p2}"
        Me.colc16.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colc16.FieldName = "c16"
        Me.colc16.MinWidth = 90
        Me.colc16.Name = "colc16"
        Me.colc16.OptionsColumn.FixedWidth = True
        Me.colc16.Width = 90
        '
        'colc17
        '
        Me.colc17.Caption = "Avg. Volume (250)"
        Me.colc17.DisplayFormat.FormatString = "n0"
        Me.colc17.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colc17.FieldName = "c17"
        Me.colc17.MinWidth = 112
        Me.colc17.Name = "colc17"
        Me.colc17.OptionsColumn.FixedWidth = True
        Me.colc17.Width = 112
        '
        'colc18
        '
        Me.colc18.Caption = "Trd"
        Me.colc18.FieldName = "c18"
        Me.colc18.MinWidth = 37
        Me.colc18.Name = "colc18"
        Me.colc18.OptionsColumn.FixedWidth = True
        Me.colc18.ToolTip = "Trading"
        Me.colc18.Visible = True
        Me.colc18.VisibleIndex = 8
        Me.colc18.Width = 60
        '
        'colc19
        '
        Me.colc19.Caption = "OP"
        Me.colc19.FieldName = "c19"
        Me.colc19.MinWidth = 45
        Me.colc19.Name = "colc19"
        Me.colc19.OptionsColumn.FixedWidth = True
        Me.colc19.ToolTip = "Open Position"
        Me.colc19.Visible = True
        Me.colc19.VisibleIndex = 9
        Me.colc19.Width = 60
        '
        'colc20
        '
        Me.colc20.Caption = "# of Contract"
        Me.colc20.FieldName = "c20"
        Me.colc20.MinWidth = 75
        Me.colc20.Name = "colc20"
        Me.colc20.OptionsColumn.FixedWidth = True
        Me.colc20.ToolTip = "# of Contract"
        Me.colc20.Visible = True
        Me.colc20.VisibleIndex = 10
        '
        'colc211
        '
        Me.colc211.Caption = "Alloc Weight (Wt)"
        Me.colc211.DisplayFormat.FormatString = "n2"
        Me.colc211.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colc211.FieldName = "c21"
        Me.colc211.MinWidth = 90
        Me.colc211.Name = "colc211"
        Me.colc211.OptionsColumn.FixedWidth = True
        Me.colc211.Visible = True
        Me.colc211.VisibleIndex = 11
        Me.colc211.Width = 90
        '
        'colc22
        '
        Me.colc22.Caption = "MktCMI (Buy)"
        Me.colc22.DisplayFormat.FormatString = "{0:p2}"
        Me.colc22.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colc22.FieldName = "c22"
        Me.colc22.MinWidth = 90
        Me.colc22.Name = "colc22"
        Me.colc22.OptionsColumn.FixedWidth = True
        Me.colc22.Visible = True
        Me.colc22.VisibleIndex = 12
        Me.colc22.Width = 90
        '
        'colc23
        '
        Me.colc23.Caption = "MktCMI (Sell)"
        Me.colc23.DisplayFormat.FormatString = "{0:p2}"
        Me.colc23.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colc23.FieldName = "c23"
        Me.colc23.MinWidth = 90
        Me.colc23.Name = "colc23"
        Me.colc23.OptionsColumn.FixedWidth = True
        Me.colc23.Visible = True
        Me.colc23.VisibleIndex = 13
        Me.colc23.Width = 90
        '
        'BarButtonItem1
        '
        Me.BarButtonItem1.Caption = "Update AllocWt"
        Me.BarButtonItem1.Id = 35
        Me.BarButtonItem1.ImageOptions.Image = CType(resources.GetObject("BarButtonItem1.ImageOptions.Image"), System.Drawing.Image)
        Me.BarButtonItem1.ImageOptions.LargeImage = CType(resources.GetObject("BarButtonItem1.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.BarButtonItem1.Name = "BarButtonItem1"
        '
        'StandaloneBarDockControl3
        '
        Me.StandaloneBarDockControl3.CausesValidation = False
        Me.StandaloneBarDockControl3.Dock = System.Windows.Forms.DockStyle.Top
        Me.StandaloneBarDockControl3.Location = New System.Drawing.Point(0, 0)
        Me.StandaloneBarDockControl3.Manager = Me.bm
        Me.StandaloneBarDockControl3.Margin = New System.Windows.Forms.Padding(4)
        Me.StandaloneBarDockControl3.Name = "StandaloneBarDockControl3"
        Me.StandaloneBarDockControl3.Size = New System.Drawing.Size(1157, 42)
        Me.StandaloneBarDockControl3.Text = "StandaloneBarDockControl3"
        '
        'Bar8
        '
        Me.Bar8.BarName = "Custom 9"
        Me.Bar8.DockCol = 0
        Me.Bar8.DockRow = 0
        Me.Bar8.DockStyle = DevExpress.XtraBars.BarDockStyle.Standalone
        Me.Bar8.FloatLocation = New System.Drawing.Point(41, 215)
        Me.Bar8.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.BarStaticItem4, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)})
        Me.Bar8.OptionsBar.AllowQuickCustomization = False
        Me.Bar8.OptionsBar.DisableCustomization = True
        Me.Bar8.OptionsBar.DrawDragBorder = False
        Me.Bar8.OptionsBar.DrawSizeGrip = True
        Me.Bar8.OptionsBar.UseWholeRow = True
        Me.Bar8.StandaloneBarDockControl = Me.StandaloneBarDockControl4
        Me.Bar8.Text = "Custom 9"
        '
        'BarStaticItem4
        '
        Me.BarStaticItem4.Caption = "ExchangeRate"
        Me.BarStaticItem4.Id = 28
        Me.BarStaticItem4.ImageOptions.Image = CType(resources.GetObject("BarStaticItem4.ImageOptions.Image"), System.Drawing.Image)
        Me.BarStaticItem4.ImageOptions.LargeImage = CType(resources.GetObject("BarStaticItem4.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.BarStaticItem4.Name = "BarStaticItem4"
        Me.BarStaticItem4.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph
        '
        'StandaloneBarDockControl4
        '
        Me.StandaloneBarDockControl4.CausesValidation = False
        Me.StandaloneBarDockControl4.Dock = System.Windows.Forms.DockStyle.Top
        Me.StandaloneBarDockControl4.Location = New System.Drawing.Point(0, 0)
        Me.StandaloneBarDockControl4.Manager = Me.bm
        Me.StandaloneBarDockControl4.Margin = New System.Windows.Forms.Padding(4)
        Me.StandaloneBarDockControl4.Name = "StandaloneBarDockControl4"
        Me.StandaloneBarDockControl4.Size = New System.Drawing.Size(1157, 42)
        Me.StandaloneBarDockControl4.Text = "StandaloneBarDockControl4"
        '
        'Bar9
        '
        Me.Bar9.BarName = "Custom 10"
        Me.Bar9.DockCol = 0
        Me.Bar9.DockRow = 0
        Me.Bar9.DockStyle = DevExpress.XtraBars.BarDockStyle.Standalone
        Me.Bar9.FloatLocation = New System.Drawing.Point(54, 226)
        Me.Bar9.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.BarStaticItem2, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)})
        Me.Bar9.OptionsBar.AllowQuickCustomization = False
        Me.Bar9.OptionsBar.DisableClose = True
        Me.Bar9.OptionsBar.DisableCustomization = True
        Me.Bar9.OptionsBar.DrawDragBorder = False
        Me.Bar9.OptionsBar.UseWholeRow = True
        Me.Bar9.StandaloneBarDockControl = Me.StandaloneBarDockControl6
        Me.Bar9.Text = "Custom 10"
        '
        'BarStaticItem2
        '
        Me.BarStaticItem2.Caption = "Options"
        Me.BarStaticItem2.Id = 26
        Me.BarStaticItem2.ImageOptions.Image = Global.LTFFAlloc2.My.Resources.Resources.table_16x16
        Me.BarStaticItem2.Name = "BarStaticItem2"
        Me.BarStaticItem2.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph
        '
        'StandaloneBarDockControl6
        '
        Me.StandaloneBarDockControl6.CausesValidation = False
        Me.StandaloneBarDockControl6.Dock = System.Windows.Forms.DockStyle.Top
        Me.StandaloneBarDockControl6.Location = New System.Drawing.Point(0, 0)
        Me.StandaloneBarDockControl6.Manager = Me.bm
        Me.StandaloneBarDockControl6.Margin = New System.Windows.Forms.Padding(4)
        Me.StandaloneBarDockControl6.Name = "StandaloneBarDockControl6"
        Me.StandaloneBarDockControl6.Size = New System.Drawing.Size(1157, 42)
        Me.StandaloneBarDockControl6.Text = "StandaloneBarDockControl6"
        '
        'barDockControlTop
        '
        Me.barDockControlTop.CausesValidation = False
        Me.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.barDockControlTop.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlTop.Manager = Me.bm
        Me.barDockControlTop.Margin = New System.Windows.Forms.Padding(4)
        Me.barDockControlTop.Size = New System.Drawing.Size(1157, 41)
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = False
        Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.barDockControlBottom.Location = New System.Drawing.Point(0, 511)
        Me.barDockControlBottom.Manager = Me.bm
        Me.barDockControlBottom.Margin = New System.Windows.Forms.Padding(4)
        Me.barDockControlBottom.Size = New System.Drawing.Size(1157, 34)
        '
        'barDockControlLeft
        '
        Me.barDockControlLeft.CausesValidation = False
        Me.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.barDockControlLeft.Location = New System.Drawing.Point(0, 41)
        Me.barDockControlLeft.Manager = Me.bm
        Me.barDockControlLeft.Margin = New System.Windows.Forms.Padding(4)
        Me.barDockControlLeft.Size = New System.Drawing.Size(0, 470)
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = False
        Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.barDockControlRight.Location = New System.Drawing.Point(1157, 41)
        Me.barDockControlRight.Manager = Me.bm
        Me.barDockControlRight.Margin = New System.Windows.Forms.Padding(4)
        Me.barDockControlRight.Size = New System.Drawing.Size(0, 470)
        '
        'oCalcButton
        '
        Me.oCalcButton.Caption = "Calculate"
        Me.oCalcButton.Id = 7
        Me.oCalcButton.Name = "oCalcButton"
        '
        'oNav
        '
        Me.ttc.SetAllowHtmlText(Me.oNav, DevExpress.Utils.DefaultBoolean.[Default])
        Me.oNav.AllowTransitionAnimation = DevExpress.Utils.DefaultBoolean.[False]
        Me.oNav.Controls.Add(Me.s1)
        Me.oNav.Controls.Add(Me.s3)
        Me.oNav.Controls.Add(Me.s5)
        Me.oNav.Controls.Add(Me.s6)
        Me.oNav.Controls.Add(Me.s4)
        Me.oNav.Dock = System.Windows.Forms.DockStyle.Fill
        Me.oNav.Location = New System.Drawing.Point(0, 41)
        Me.oNav.Margin = New System.Windows.Forms.Padding(4)
        Me.oNav.Name = "oNav"
        Me.oNav.Pages.AddRange(New DevExpress.XtraBars.Navigation.NavigationPageBase() {Me.s1, Me.s3, Me.s4, Me.s5, Me.s6})
        Me.oNav.SelectedPage = Me.s3
        Me.oNav.Size = New System.Drawing.Size(1157, 415)
        Me.oNav.TabIndex = 5
        Me.oNav.Text = "NavigationFrame1"
        '
        's1
        '
        Me.ttc.SetAllowHtmlText(Me.s1, DevExpress.Utils.DefaultBoolean.[Default])
        Me.s1.Caption = "RAR"
        Me.s1.Controls.Add(Me.gcr)
        Me.s1.Controls.Add(Me.StandaloneBarDockControl2)
        Me.s1.Margin = New System.Windows.Forms.Padding(4)
        Me.s1.Name = "s1"
        Me.s1.Size = New System.Drawing.Size(1157, 415)
        '
        'gcr
        '
        Me.gcr.DataSource = Me.bsRar
        Me.gcr.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gcr.EmbeddedNavigator.Margin = New System.Windows.Forms.Padding(4)
        Me.gcr.Location = New System.Drawing.Point(0, 42)
        Me.gcr.MainView = Me.gvr
        Me.gcr.Margin = New System.Windows.Forms.Padding(4)
        Me.gcr.MenuManager = Me.bm
        Me.gcr.Name = "gcr"
        Me.gcr.Size = New System.Drawing.Size(1157, 373)
        Me.gcr.TabIndex = 2
        Me.gcr.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gvr})
        '
        'bsRar
        '
        Me.bsRar.DataMember = "RAR"
        Me.bsRar.DataSource = Me.ds
        '
        'gvr
        '
        Me.gvr.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.gvr.ColumnPanelRowHeight = 66
        Me.gvr.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colF1, Me.colF2, Me.colF3, Me.colF4, Me.colF5, Me.colF6, Me.colF7, Me.colF8, Me.colF9, Me.colF10, Me.colF11, Me.colF12, Me.colF13, Me.colF15, Me.colF16, Me.col_color})
        Me.gvr.DetailHeight = 512
        Me.gvr.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus
        GridFormatRule1.ApplyToRow = True
        GridFormatRule1.Column = Me.col_color
        GridFormatRule1.Name = "Format0"
        FormatConditionRuleValue1.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(35, Byte), Integer))
        FormatConditionRuleValue1.Appearance.Options.UseBackColor = True
        FormatConditionRuleValue1.Condition = DevExpress.XtraEditors.FormatCondition.Expression
        FormatConditionRuleValue1.Expression = "[_color] = 1"
        GridFormatRule1.Rule = FormatConditionRuleValue1
        GridFormatRule2.Column = Me.colF15
        GridFormatRule2.ColumnApplyTo = Me.colF15
        GridFormatRule2.Name = "Format1"
        FormatConditionRuleValue2.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        FormatConditionRuleValue2.Appearance.Options.UseFont = True
        FormatConditionRuleValue2.Condition = DevExpress.XtraEditors.FormatCondition.Greater
        FormatConditionRuleValue2.Value1 = 1.4R
        GridFormatRule2.Rule = FormatConditionRuleValue2
        GridFormatRule3.Column = Me.colF16
        GridFormatRule3.Name = "Format2"
        FormatConditionRuleValue3.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        FormatConditionRuleValue3.Appearance.Options.UseFont = True
        FormatConditionRuleValue3.Condition = DevExpress.XtraEditors.FormatCondition.Greater
        FormatConditionRuleValue3.Value1 = 1.4R
        GridFormatRule3.Rule = FormatConditionRuleValue3
        Me.gvr.FormatRules.Add(GridFormatRule1)
        Me.gvr.FormatRules.Add(GridFormatRule2)
        Me.gvr.FormatRules.Add(GridFormatRule3)
        Me.gvr.GridControl = Me.gcr
        Me.gvr.Name = "gvr"
        Me.gvr.OptionsBehavior.Editable = False
        Me.gvr.OptionsEditForm.PopupEditFormWidth = 1200
        Me.gvr.OptionsView.ColumnAutoWidth = False
        Me.gvr.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.[True]
        Me.gvr.OptionsView.ShowFooter = True
        Me.gvr.OptionsView.ShowGroupPanel = False
        Me.gvr.OptionsView.ShowIndicator = False
        Me.gvr.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.colF11, DevExpress.Data.ColumnSortOrder.Descending), New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.colF3, DevExpress.Data.ColumnSortOrder.Descending), New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.colF4, DevExpress.Data.ColumnSortOrder.Descending)})
        '
        'colF1
        '
        Me.colF1.Caption = "File Name"
        Me.colF1.FieldName = "F1"
        Me.colF1.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
        Me.colF1.MinWidth = 30
        Me.colF1.Name = "colF1"
        Me.colF1.OptionsColumn.FixedWidth = True
        Me.colF1.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "F1", "{0:n0}")})
        Me.colF1.Visible = True
        Me.colF1.VisibleIndex = 0
        Me.colF1.Width = 150
        '
        'colF2
        '
        Me.colF2.Caption = "Mkt Name"
        Me.colF2.FieldName = "F2"
        Me.colF2.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
        Me.colF2.MinWidth = 187
        Me.colF2.Name = "colF2"
        Me.colF2.Visible = True
        Me.colF2.VisibleIndex = 1
        Me.colF2.Width = 187
        '
        'colF3
        '
        Me.colF3.Caption = "RAR 200"
        Me.colF3.DisplayFormat.FormatString = "{0:n4}"
        Me.colF3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colF3.FieldName = "F3"
        Me.colF3.MinWidth = 75
        Me.colF3.Name = "colF3"
        Me.colF3.OptionsColumn.FixedWidth = True
        Me.colF3.Visible = True
        Me.colF3.VisibleIndex = 2
        Me.colF3.Width = 142
        '
        'colF4
        '
        Me.colF4.Caption = "RAR 1350"
        Me.colF4.DisplayFormat.FormatString = "{0:n4}"
        Me.colF4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colF4.FieldName = "F4"
        Me.colF4.MinWidth = 75
        Me.colF4.Name = "colF4"
        Me.colF4.OptionsColumn.FixedWidth = True
        Me.colF4.Visible = True
        Me.colF4.VisibleIndex = 3
        Me.colF4.Width = 142
        '
        'colF5
        '
        Me.colF5.Caption = "$ ATR[x]"
        Me.colF5.DisplayFormat.FormatString = "{0:n0}"
        Me.colF5.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colF5.FieldName = "F5"
        Me.colF5.MinWidth = 75
        Me.colF5.Name = "colF5"
        Me.colF5.OptionsColumn.FixedWidth = True
        Me.colF5.Visible = True
        Me.colF5.VisibleIndex = 4
        Me.colF5.Width = 97
        '
        'colF6
        '
        Me.colF6.Caption = "Long MM Risk"
        Me.colF6.DisplayFormat.FormatString = "{0:n0}"
        Me.colF6.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colF6.FieldName = "F6"
        Me.colF6.MinWidth = 75
        Me.colF6.Name = "colF6"
        Me.colF6.OptionsColumn.FixedWidth = True
        Me.colF6.Visible = True
        Me.colF6.VisibleIndex = 5
        Me.colF6.Width = 76
        '
        'colF7
        '
        Me.colF7.Caption = "Short MM Risk"
        Me.colF7.DisplayFormat.FormatString = "{0:n0}"
        Me.colF7.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colF7.FieldName = "F7"
        Me.colF7.MinWidth = 75
        Me.colF7.Name = "colF7"
        Me.colF7.OptionsColumn.FixedWidth = True
        Me.colF7.Visible = True
        Me.colF7.VisibleIndex = 6
        Me.colF7.Width = 90
        '
        'colF8
        '
        Me.colF8.Caption = "Last Trading Day"
        Me.colF8.FieldName = "F8"
        Me.colF8.MinWidth = 75
        Me.colF8.Name = "colF8"
        Me.colF8.OptionsColumn.FixedWidth = True
        Me.colF8.Visible = True
        Me.colF8.VisibleIndex = 7
        Me.colF8.Width = 90
        '
        'colF9
        '
        Me.colF9.Caption = "Rank 200"
        Me.colF9.DisplayFormat.FormatString = "n0"
        Me.colF9.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colF9.FieldName = "F9"
        Me.colF9.MinWidth = 75
        Me.colF9.Name = "colF9"
        Me.colF9.OptionsColumn.FixedWidth = True
        Me.colF9.Visible = True
        Me.colF9.VisibleIndex = 8
        '
        'colF10
        '
        Me.colF10.Caption = "Rank 1350"
        Me.colF10.DisplayFormat.FormatString = "n0"
        Me.colF10.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colF10.FieldName = "F10"
        Me.colF10.MinWidth = 75
        Me.colF10.Name = "colF10"
        Me.colF10.OptionsColumn.FixedWidth = True
        Me.colF10.Visible = True
        Me.colF10.VisibleIndex = 9
        '
        'colF11
        '
        Me.colF11.Caption = "Rank Group"
        Me.colF11.DisplayFormat.FormatString = "n0"
        Me.colF11.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colF11.FieldName = "F11"
        Me.colF11.MinWidth = 75
        Me.colF11.Name = "colF11"
        Me.colF11.OptionsColumn.FixedWidth = True
        Me.colF11.Visible = True
        Me.colF11.VisibleIndex = 10
        Me.colF11.Width = 90
        '
        'colF12
        '
        Me.colF12.Caption = "Alloc Weight"
        Me.colF12.DisplayFormat.FormatString = "{0:p2}"
        Me.colF12.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colF12.FieldName = "F12"
        Me.colF12.MinWidth = 75
        Me.colF12.Name = "colF12"
        Me.colF12.OptionsColumn.FixedWidth = True
        Me.colF12.Visible = True
        Me.colF12.VisibleIndex = 11
        Me.colF12.Width = 90
        '
        'colF13
        '
        Me.colF13.Caption = "# Contracts"
        Me.colF13.DisplayFormat.FormatString = "n0"
        Me.colF13.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colF13.FieldName = "F13"
        Me.colF13.MinWidth = 75
        Me.colF13.Name = "colF13"
        Me.colF13.OptionsColumn.FixedWidth = True
        Me.colF13.Visible = True
        Me.colF13.VisibleIndex = 12
        Me.colF13.Width = 100
        '
        's3
        '
        Me.ttc.SetAllowHtmlText(Me.s3, DevExpress.Utils.DefaultBoolean.[Default])
        Me.s3.Caption = "MktSpec"
        Me.s3.Controls.Add(Me.gcm)
        Me.s3.Controls.Add(Me.StandaloneBarDockControl3)
        Me.s3.Margin = New System.Windows.Forms.Padding(4)
        Me.s3.Name = "s3"
        Me.s3.Size = New System.Drawing.Size(1157, 415)
        '
        's5
        '
        Me.ttc.SetAllowHtmlText(Me.s5, DevExpress.Utils.DefaultBoolean.[Default])
        Me.s5.Caption = "IndexMundi"
        Me.s5.Controls.Add(Me.gci)
        Me.s5.Controls.Add(Me.StandaloneBarDockControl5)
        Me.s5.Margin = New System.Windows.Forms.Padding(4)
        Me.s5.Name = "s5"
        Me.s5.Size = New System.Drawing.Size(1157, 415)
        '
        'gci
        '
        Me.gci.DataSource = Me.bsMundi
        Me.gci.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gci.EmbeddedNavigator.Margin = New System.Windows.Forms.Padding(4)
        Me.gci.Location = New System.Drawing.Point(0, 42)
        Me.gci.MainView = Me.gvi
        Me.gci.Margin = New System.Windows.Forms.Padding(4)
        Me.gci.MenuManager = Me.bm
        Me.gci.Name = "gci"
        Me.gci.Size = New System.Drawing.Size(1157, 373)
        Me.gci.TabIndex = 3
        Me.gci.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gvi})
        '
        'bsMundi
        '
        Me.bsMundi.DataMember = "IndexMundi"
        Me.bsMundi.DataSource = Me.ds
        '
        'gvi
        '
        Me.gvi.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.gvi.ColumnPanelRowHeight = 66
        Me.gvi.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colxArea, Me.colxCurrency, Me.colxDate, Me.colxInverse, Me.colxRate})
        Me.gvi.DetailHeight = 512
        Me.gvi.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus
        Me.gvi.GridControl = Me.gci
        Me.gvi.Name = "gvi"
        Me.gvi.OptionsBehavior.Editable = False
        Me.gvi.OptionsEditForm.PopupEditFormWidth = 1200
        Me.gvi.OptionsView.ColumnAutoWidth = False
        Me.gvi.OptionsView.ShowFooter = True
        Me.gvi.OptionsView.ShowGroupPanel = False
        Me.gvi.OptionsView.ShowIndicator = False
        '
        'colxArea
        '
        Me.colxArea.Caption = "Area"
        Me.colxArea.FieldName = "xArea"
        Me.colxArea.MinWidth = 30
        Me.colxArea.Name = "colxArea"
        Me.colxArea.Visible = True
        Me.colxArea.VisibleIndex = 1
        Me.colxArea.Width = 372
        '
        'colxCurrency
        '
        Me.colxCurrency.Caption = "Currency"
        Me.colxCurrency.FieldName = "xCurrency"
        Me.colxCurrency.MinWidth = 75
        Me.colxCurrency.Name = "colxCurrency"
        Me.colxCurrency.OptionsColumn.FixedWidth = True
        Me.colxCurrency.Visible = True
        Me.colxCurrency.VisibleIndex = 2
        Me.colxCurrency.Width = 225
        '
        'colxDate
        '
        Me.colxDate.Caption = "Date"
        Me.colxDate.FieldName = "xDate"
        Me.colxDate.MinWidth = 30
        Me.colxDate.Name = "colxDate"
        Me.colxDate.OptionsColumn.FixedWidth = True
        Me.colxDate.Visible = True
        Me.colxDate.VisibleIndex = 0
        Me.colxDate.Width = 105
        '
        'colxInverse
        '
        Me.colxInverse.Caption = "Inverse"
        Me.colxInverse.DisplayFormat.FormatString = "{0:n4}"
        Me.colxInverse.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colxInverse.FieldName = "xInverse"
        Me.colxInverse.MinWidth = 112
        Me.colxInverse.Name = "colxInverse"
        Me.colxInverse.OptionsColumn.FixedWidth = True
        Me.colxInverse.Visible = True
        Me.colxInverse.VisibleIndex = 4
        Me.colxInverse.Width = 120
        '
        'colxRate
        '
        Me.colxRate.Caption = "Rate"
        Me.colxRate.DisplayFormat.FormatString = "{0:n4}"
        Me.colxRate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colxRate.FieldName = "xRate"
        Me.colxRate.MinWidth = 112
        Me.colxRate.Name = "colxRate"
        Me.colxRate.OptionsColumn.FixedWidth = True
        Me.colxRate.Visible = True
        Me.colxRate.VisibleIndex = 3
        Me.colxRate.Width = 120
        '
        's6
        '
        Me.ttc.SetAllowHtmlText(Me.s6, DevExpress.Utils.DefaultBoolean.[Default])
        Me.s6.Caption = "Options"
        Me.s6.Controls.Add(Me.gco)
        Me.s6.Controls.Add(Me.StandaloneBarDockControl6)
        Me.s6.Margin = New System.Windows.Forms.Padding(4)
        Me.s6.Name = "s6"
        Me.s6.Size = New System.Drawing.Size(1157, 415)
        '
        'gco
        '
        Me.gco.DataSource = Me.bsOptions
        Me.gco.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gco.EmbeddedNavigator.Margin = New System.Windows.Forms.Padding(4)
        Me.gco.Location = New System.Drawing.Point(0, 42)
        Me.gco.MainView = Me.gvo
        Me.gco.Margin = New System.Windows.Forms.Padding(4)
        Me.gco.MenuManager = Me.bm
        Me.gco.Name = "gco"
        Me.gco.Size = New System.Drawing.Size(1157, 373)
        Me.gco.TabIndex = 4
        Me.gco.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gvo})
        '
        'bsOptions
        '
        Me.bsOptions.DataMember = "Options"
        Me.bsOptions.DataSource = Me.ds
        '
        'gvo
        '
        Me.gvo.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.gvo.ColumnPanelRowHeight = 66
        Me.gvo.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colc110, Me.colc24})
        Me.gvo.DetailHeight = 512
        Me.gvo.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus
        Me.gvo.GridControl = Me.gco
        Me.gvo.Name = "gvo"
        Me.gvo.OptionsEditForm.PopupEditFormWidth = 1200
        Me.gvo.OptionsView.ColumnAutoWidth = False
        Me.gvo.OptionsView.ShowFooter = True
        Me.gvo.OptionsView.ShowGroupPanel = False
        Me.gvo.OptionsView.ShowIndicator = False
        '
        'colc110
        '
        Me.colc110.Caption = "ID"
        Me.colc110.FieldName = "c1"
        Me.colc110.MinWidth = 30
        Me.colc110.Name = "colc110"
        Me.colc110.OptionsColumn.AllowEdit = False
        Me.colc110.OptionsColumn.FixedWidth = True
        Me.colc110.Visible = True
        Me.colc110.VisibleIndex = 0
        Me.colc110.Width = 225
        '
        'colc24
        '
        Me.colc24.Caption = "Value"
        Me.colc24.FieldName = "c2"
        Me.colc24.MinWidth = 30
        Me.colc24.Name = "colc24"
        Me.colc24.Visible = True
        Me.colc24.VisibleIndex = 1
        Me.colc24.Width = 120
        '
        's4
        '
        Me.ttc.SetAllowHtmlText(Me.s4, DevExpress.Utils.DefaultBoolean.[Default])
        Me.s4.Caption = "ExchangeRate"
        Me.s4.Controls.Add(Me.gce)
        Me.s4.Controls.Add(Me.StandaloneBarDockControl4)
        Me.s4.Margin = New System.Windows.Forms.Padding(4)
        Me.s4.Name = "s4"
        Me.s4.Size = New System.Drawing.Size(1157, 415)
        '
        'gce
        '
        Me.gce.DataSource = Me.bsExchange
        Me.gce.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gce.EmbeddedNavigator.Margin = New System.Windows.Forms.Padding(4)
        Me.gce.Location = New System.Drawing.Point(0, 42)
        Me.gce.MainView = Me.gve
        Me.gce.Margin = New System.Windows.Forms.Padding(4)
        Me.gce.MenuManager = Me.bm
        Me.gce.Name = "gce"
        Me.gce.Size = New System.Drawing.Size(1157, 373)
        Me.gce.TabIndex = 3
        Me.gce.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gve})
        '
        'bsExchange
        '
        Me.bsExchange.DataMember = "ExchangeRate"
        Me.bsExchange.DataSource = Me.ds
        '
        'gve
        '
        Me.gve.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.gve.ColumnPanelRowHeight = 66
        Me.gve.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colxChange1, Me.colxCountry1, Me.colxCurrency1, Me.colxDat01, Me.colxDat11, Me.colid})
        Me.gve.DetailHeight = 512
        Me.gve.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus
        Me.gve.GridControl = Me.gce
        Me.gve.Name = "gve"
        Me.gve.OptionsBehavior.Editable = False
        Me.gve.OptionsEditForm.PopupEditFormWidth = 1200
        Me.gve.OptionsView.ColumnAutoWidth = False
        Me.gve.OptionsView.ShowFooter = True
        Me.gve.OptionsView.ShowGroupPanel = False
        Me.gve.OptionsView.ShowIndicator = False
        Me.gve.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.colxCountry1, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'colxChange1
        '
        Me.colxChange1.Caption = "Changes"
        Me.colxChange1.DisplayFormat.FormatString = "{0:n2} %"
        Me.colxChange1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colxChange1.FieldName = "xChange"
        Me.colxChange1.MinWidth = 30
        Me.colxChange1.Name = "colxChange1"
        Me.colxChange1.OptionsColumn.FixedWidth = True
        Me.colxChange1.Visible = True
        Me.colxChange1.VisibleIndex = 5
        Me.colxChange1.Width = 90
        '
        'colxCountry1
        '
        Me.colxCountry1.Caption = "Country"
        Me.colxCountry1.FieldName = "xCountry"
        Me.colxCountry1.MinWidth = 30
        Me.colxCountry1.Name = "colxCountry1"
        Me.colxCountry1.Visible = True
        Me.colxCountry1.VisibleIndex = 2
        Me.colxCountry1.Width = 330
        '
        'colxCurrency1
        '
        Me.colxCurrency1.Caption = "Name"
        Me.colxCurrency1.FieldName = "xCurrency"
        Me.colxCurrency1.MinWidth = 30
        Me.colxCurrency1.Name = "colxCurrency1"
        Me.colxCurrency1.OptionsColumn.FixedWidth = True
        Me.colxCurrency1.Visible = True
        Me.colxCurrency1.VisibleIndex = 1
        Me.colxCurrency1.Width = 187
        '
        'colxDat01
        '
        Me.colxDat01.Caption = "Date"
        Me.colxDat01.DisplayFormat.FormatString = "n4"
        Me.colxDat01.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colxDat01.FieldName = "xDat0"
        Me.colxDat01.MinWidth = 30
        Me.colxDat01.Name = "colxDat01"
        Me.colxDat01.OptionsColumn.FixedWidth = True
        Me.colxDat01.Visible = True
        Me.colxDat01.VisibleIndex = 3
        Me.colxDat01.Width = 120
        '
        'colxDat11
        '
        Me.colxDat11.Caption = "Date"
        Me.colxDat11.DisplayFormat.FormatString = "n4"
        Me.colxDat11.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colxDat11.FieldName = "xDat1"
        Me.colxDat11.MinWidth = 30
        Me.colxDat11.Name = "colxDat11"
        Me.colxDat11.OptionsColumn.FixedWidth = True
        Me.colxDat11.Visible = True
        Me.colxDat11.VisibleIndex = 4
        Me.colxDat11.Width = 120
        '
        'colid
        '
        Me.colid.Caption = "Currency"
        Me.colid.FieldName = "id"
        Me.colid.MinWidth = 30
        Me.colid.Name = "colid"
        Me.colid.OptionsColumn.FixedWidth = True
        Me.colid.Visible = True
        Me.colid.VisibleIndex = 0
        '
        'bsSector
        '
        Me.bsSector.DataMember = "Sector"
        Me.bsSector.DataSource = Me.ds
        '
        'OfficeNavigationBar1
        '
        Me.OfficeNavigationBar1.AutoSizeInLayoutControl = True
        Me.OfficeNavigationBar1.CustomizationButtonVisibility = DevExpress.XtraBars.Navigation.CustomizationButtonVisibility.Hidden
        Me.OfficeNavigationBar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.OfficeNavigationBar1.Location = New System.Drawing.Point(0, 456)
        Me.OfficeNavigationBar1.Margin = New System.Windows.Forms.Padding(4)
        Me.OfficeNavigationBar1.MenuManager = Me.bm
        Me.OfficeNavigationBar1.Name = "OfficeNavigationBar1"
        Me.OfficeNavigationBar1.NavigationClient = Me.oNav
        Me.OfficeNavigationBar1.Size = New System.Drawing.Size(1157, 55)
        Me.OfficeNavigationBar1.TabIndex = 4
        Me.OfficeNavigationBar1.Text = "OfficeNavigationBar1"
        Me.OfficeNavigationBar1.ViewMode = DevExpress.XtraBars.Navigation.OfficeNavigationBarViewMode.Skinned
        '
        'dlf
        '
        Me.dlf.LookAndFeel.SkinName = "Office 2010 Blue"
        '
        'bwRefresh
        '
        '
        'bwCalc
        '
        '
        'bwWeb
        '
        '
        'bwMkt
        '
        '
        'sfd
        '
        Me.sfd.RestoreDirectory = True
        '
        'fbd
        '
        Me.fbd.RootFolder = System.Environment.SpecialFolder.MyComputer
        '
        'MainForm
        '
        Me.ttc.SetAllowHtmlText(Me, DevExpress.Utils.DefaultBoolean.[Default])
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 19.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1157, 545)
        Me.Controls.Add(Me.oNav)
        Me.Controls.Add(Me.OfficeNavigationBar1)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.IconOptions.Icon = CType(resources.GetObject("MainForm.IconOptions.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "MainForm"
        Me.Text = "LTTF Alloc v7.0"
        CType(Me.bm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemSearchControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gcm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bsMkt, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ds, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rpYesNo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gvm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.oNav, System.ComponentModel.ISupportInitialize).EndInit()
        Me.oNav.ResumeLayout(False)
        Me.s1.ResumeLayout(False)
        CType(Me.gcr, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bsRar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gvr, System.ComponentModel.ISupportInitialize).EndInit()
        Me.s3.ResumeLayout(False)
        Me.s5.ResumeLayout(False)
        CType(Me.gci, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bsMundi, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gvi, System.ComponentModel.ISupportInitialize).EndInit()
        Me.s6.ResumeLayout(False)
        CType(Me.gco, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bsOptions, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gvo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.s4.ResumeLayout(False)
        CType(Me.gce, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bsExchange, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gve, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bsSector, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OfficeNavigationBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents bm As DevExpress.XtraBars.BarManager
	Friend WithEvents Bar1 As DevExpress.XtraBars.Bar
	Friend WithEvents Bar3 As DevExpress.XtraBars.Bar
	Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
	Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
	Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
	Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
	Friend WithEvents ttc As DevExpress.Utils.DefaultToolTipController
	Friend WithEvents dlf As DevExpress.LookAndFeel.DefaultLookAndFeel
	Friend WithEvents pr As DevExpress.XtraEditors.Repository.PersistentRepository
	Friend WithEvents ds As ods
	Friend WithEvents OfficeNavigationBar1 As DevExpress.XtraBars.Navigation.OfficeNavigationBar
	Friend WithEvents ssm As DevExpress.XtraSplashScreen.SplashScreenManager
	Friend WithEvents oNav As DevExpress.XtraBars.Navigation.NavigationFrame
	Friend WithEvents s1 As DevExpress.XtraBars.Navigation.NavigationPage
    Friend WithEvents s3 As DevExpress.XtraBars.Navigation.NavigationPage
    Friend WithEvents s4 As DevExpress.XtraBars.Navigation.NavigationPage
    Friend WithEvents s5 As DevExpress.XtraBars.Navigation.NavigationPage
    Friend WithEvents Bar4 As DevExpress.XtraBars.Bar
    Friend WithEvents Bar5 As DevExpress.XtraBars.Bar
    Friend WithEvents StandaloneBarDockControl5 As DevExpress.XtraBars.StandaloneBarDockControl
    Friend WithEvents StandaloneBarDockControl2 As DevExpress.XtraBars.StandaloneBarDockControl
    Friend WithEvents StandaloneBarDockControl3 As DevExpress.XtraBars.StandaloneBarDockControl
    Friend WithEvents StandaloneBarDockControl4 As DevExpress.XtraBars.StandaloneBarDockControl
    Friend WithEvents Bar6 As DevExpress.XtraBars.Bar
    Friend WithEvents Bar7 As DevExpress.XtraBars.Bar
    Friend WithEvents Bar8 As DevExpress.XtraBars.Bar
    Friend WithEvents oRefreshAllButton As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents Bar9 As DevExpress.XtraBars.Bar
    Friend WithEvents StandaloneBarDockControl6 As DevExpress.XtraBars.StandaloneBarDockControl
    Friend WithEvents s6 As DevExpress.XtraBars.Navigation.NavigationPage
    Friend WithEvents gcm As DevExpress.XtraGrid.GridControl
    Friend WithEvents bsMkt As BindingSource
    Friend WithEvents gvm As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colc11 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colc21 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colc31 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colc41 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colc51 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colc71 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colc91 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colc10 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colc111 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colc12 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colc13 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colc14 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colc15 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colc16 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colc17 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colc18 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colc19 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colc20 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colc211 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colc22 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colc23 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents bwRefresh As System.ComponentModel.BackgroundWorker
    Friend WithEvents gcr As DevExpress.XtraGrid.GridControl
    Friend WithEvents bsRar As BindingSource
    Friend WithEvents gvr As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colF1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colF2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colF3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colF4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colF5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colF6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colF7 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colF8 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colF9 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colF10 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colF11 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colF12 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colF13 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colF15 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colF16 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gce As DevExpress.XtraGrid.GridControl
    Friend WithEvents bsExchange As BindingSource
    Friend WithEvents gve As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colxChange1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colxCountry1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colxCurrency1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colxDat01 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colxDat11 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gci As DevExpress.XtraGrid.GridControl
    Friend WithEvents bsMundi As BindingSource
    Friend WithEvents gvi As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colxArea As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colxCurrency As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colxDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colxInverse As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colxRate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gco As DevExpress.XtraGrid.GridControl
    Friend WithEvents bsOptions As BindingSource
    Friend WithEvents gvo As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colc110 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colc24 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colid As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents bsSector As BindingSource
    Friend WithEvents bwCalc As System.ComponentModel.BackgroundWorker
    Friend WithEvents oCalcButton As DevExpress.XtraBars.BarButtonItem
	Friend WithEvents oMktMciUpdateButton As DevExpress.XtraBars.BarButtonItem
	Friend WithEvents bwWeb As System.ComponentModel.BackgroundWorker
	Friend WithEvents oStatus As DevExpress.XtraBars.BarStaticItem
	Friend WithEvents bwMkt As System.ComponentModel.BackgroundWorker
	Friend WithEvents col_color As DevExpress.XtraGrid.Columns.GridColumn
	Friend WithEvents rpYesNo As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
	Friend WithEvents oExportButton As DevExpress.XtraBars.BarSubItem
	Friend WithEvents oRarExport_PDF As DevExpress.XtraBars.BarButtonItem
	Friend WithEvents oRarExport_Excel As DevExpress.XtraBars.BarButtonItem
	Friend WithEvents oRarExport_Csv As DevExpress.XtraBars.BarButtonItem
	Friend WithEvents sfd As SaveFileDialog
	Friend WithEvents oRarExport_Html As DevExpress.XtraBars.BarButtonItem
	Friend WithEvents BarSubItem1 As DevExpress.XtraBars.BarSubItem
	Friend WithEvents oRiskExport_PDF As DevExpress.XtraBars.BarButtonItem
	Friend WithEvents oRiskExport_Excel As DevExpress.XtraBars.BarButtonItem
	Friend WithEvents oRiskExport_CSV As DevExpress.XtraBars.BarButtonItem
	Friend WithEvents oRiskExport_Html As DevExpress.XtraBars.BarButtonItem
	Friend WithEvents oSetFolderButton As DevExpress.XtraBars.BarButtonItem
	Friend WithEvents oFolderLoc As DevExpress.XtraBars.BarButtonItem
	Friend WithEvents fbd As FolderBrowserDialog
	Friend WithEvents BarStaticItem1 As DevExpress.XtraBars.BarStaticItem
	Friend WithEvents BarStaticItem2 As DevExpress.XtraBars.BarStaticItem
	Friend WithEvents BarStaticItem3 As DevExpress.XtraBars.BarStaticItem
	Friend WithEvents BarStaticItem4 As DevExpress.XtraBars.BarStaticItem
	Friend WithEvents BarStaticItem6 As DevExpress.XtraBars.BarStaticItem
	Friend WithEvents BarStaticItem5 As DevExpress.XtraBars.BarStaticItem
	Friend WithEvents oAddButton As DevExpress.XtraBars.BarButtonItem
	Friend WithEvents oDeleteButton As DevExpress.XtraBars.BarButtonItem
	Friend WithEvents SkinBarSubItem1 As DevExpress.XtraBars.SkinBarSubItem
	Friend WithEvents BarEditItem1 As DevExpress.XtraBars.BarEditItem
	Friend WithEvents RepositoryItemSearchControl1 As DevExpress.XtraEditors.Repository.RepositoryItemSearchControl
    Friend WithEvents BarButtonItem1 As DevExpress.XtraBars.BarButtonItem
End Class
