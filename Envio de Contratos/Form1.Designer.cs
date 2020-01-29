namespace Envio_de_Contratos
{
   partial class Form1
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
         System.Windows.Forms.Label fechaInicioRelacionLabel;
         System.Windows.Forms.Label fechaFinLabel;
         System.Windows.Forms.Label nombreEmpleadoLabel;
         System.Windows.Forms.Label numeroDeEmpleadoLabel;
         System.Windows.Forms.Label planillaLabel;
         System.Windows.Forms.Label puestoLabel;
         System.Windows.Forms.Label empresaLabel;
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
         this.panel1 = new System.Windows.Forms.Panel();
         this.txtNombreEmpleado = new UserWindowsControlLibrary.TextBoxSD();
         this.cboPuesto = new UserWindowsControlLibrary.ComboBoxSD();
         this.cboPlanillas = new UserWindowsControlLibrary.ComboBoxSD();
         this.CboEmpresas = new UserWindowsControlLibrary.ComboBoxSD();
         this.txtNumeroDeEmpleado = new UserWindowsControlLibrary.TextBoxSD();
         this.txtFechaFinalIngreso = new UserWindowsControlLibrary.MaskedTextBoxSD();
         this.txtFechaInicialIngreso = new UserWindowsControlLibrary.MaskedTextBoxSD();
         this.btnBuscar = new System.Windows.Forms.Button();
         this.grdDatos = new System.Windows.Forms.DataGridView();
         this.DPIFirmantePatronoColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.razonSocialPatronoColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.nombreFirmantePatronoColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.calidadFirmanteLegalPatronoColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.SalarioColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.jornadaColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.actividadEconomicaColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.formaPagoColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.plazoColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.fechaInicioRelacionColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.fechaFinColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.horasTiempoParcialColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.tarifaTiempoParcialColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.jornadaTiempoParcialColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.nombreEmpleadoColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.dpiEmpleadoColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.edadEmpleadoColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.sexoEmpleadoColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.NumeroDeEmpleadoColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.PlanillaColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.PuestoColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.EmpresaColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.mnuOpciones = new System.Windows.Forms.ContextMenuStrip(this.components);
         this.MnuEnviarContrato = new System.Windows.Forms.ToolStripMenuItem();
         this.toolStrip1 = new System.Windows.Forms.ToolStrip();
         this.lblRegistros = new System.Windows.Forms.ToolStripLabel();
         this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
         this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
         this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
         this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
         fechaInicioRelacionLabel = new System.Windows.Forms.Label();
         fechaFinLabel = new System.Windows.Forms.Label();
         nombreEmpleadoLabel = new System.Windows.Forms.Label();
         numeroDeEmpleadoLabel = new System.Windows.Forms.Label();
         planillaLabel = new System.Windows.Forms.Label();
         puestoLabel = new System.Windows.Forms.Label();
         empresaLabel = new System.Windows.Forms.Label();
         this.panel1.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.grdDatos)).BeginInit();
         this.mnuOpciones.SuspendLayout();
         this.toolStrip1.SuspendLayout();
         this.SuspendLayout();
         // 
         // fechaInicioRelacionLabel
         // 
         fechaInicioRelacionLabel.AutoSize = true;
         fechaInicioRelacionLabel.Location = new System.Drawing.Point(784, 5);
         fechaInicioRelacionLabel.Name = "fechaInicioRelacionLabel";
         fechaInicioRelacionLabel.Size = new System.Drawing.Size(153, 18);
         fechaInicioRelacionLabel.TabIndex = 8;
         fechaInicioRelacionLabel.Text = "Fecha Inicio Relacion:";
         // 
         // fechaFinLabel
         // 
         fechaFinLabel.AutoSize = true;
         fechaFinLabel.Location = new System.Drawing.Point(943, 5);
         fechaFinLabel.Name = "fechaFinLabel";
         fechaFinLabel.Size = new System.Drawing.Size(150, 18);
         fechaFinLabel.TabIndex = 10;
         fechaFinLabel.Text = "Fecha Final Relacion:";
         // 
         // nombreEmpleadoLabel
         // 
         nombreEmpleadoLabel.AutoSize = true;
         nombreEmpleadoLabel.Location = new System.Drawing.Point(7, 55);
         nombreEmpleadoLabel.Name = "nombreEmpleadoLabel";
         nombreEmpleadoLabel.Size = new System.Drawing.Size(137, 18);
         nombreEmpleadoLabel.TabIndex = 12;
         nombreEmpleadoLabel.Text = "Nombre Empleado:";
         // 
         // numeroDeEmpleadoLabel
         // 
         numeroDeEmpleadoLabel.AutoSize = true;
         numeroDeEmpleadoLabel.Location = new System.Drawing.Point(678, 5);
         numeroDeEmpleadoLabel.Name = "numeroDeEmpleadoLabel";
         numeroDeEmpleadoLabel.Size = new System.Drawing.Size(107, 18);
         numeroDeEmpleadoLabel.TabIndex = 21;
         numeroDeEmpleadoLabel.Text = "No. Empleado:";
         // 
         // planillaLabel
         // 
         planillaLabel.AutoSize = true;
         planillaLabel.Location = new System.Drawing.Point(263, 5);
         planillaLabel.Name = "planillaLabel";
         planillaLabel.Size = new System.Drawing.Size(58, 18);
         planillaLabel.TabIndex = 23;
         planillaLabel.Text = "Planilla:";
         // 
         // puestoLabel
         // 
         puestoLabel.AutoSize = true;
         puestoLabel.Location = new System.Drawing.Point(475, 5);
         puestoLabel.Name = "puestoLabel";
         puestoLabel.Size = new System.Drawing.Size(59, 18);
         puestoLabel.TabIndex = 25;
         puestoLabel.Text = "Puesto:";
         // 
         // empresaLabel
         // 
         empresaLabel.AutoSize = true;
         empresaLabel.Location = new System.Drawing.Point(7, 5);
         empresaLabel.Name = "empresaLabel";
         empresaLabel.Size = new System.Drawing.Size(72, 18);
         empresaLabel.TabIndex = 27;
         empresaLabel.Text = "Empresa:";
         // 
         // panel1
         // 
         this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this.panel1.Controls.Add(this.txtNombreEmpleado);
         this.panel1.Controls.Add(this.cboPuesto);
         this.panel1.Controls.Add(this.cboPlanillas);
         this.panel1.Controls.Add(this.CboEmpresas);
         this.panel1.Controls.Add(this.txtNumeroDeEmpleado);
         this.panel1.Controls.Add(this.txtFechaFinalIngreso);
         this.panel1.Controls.Add(this.txtFechaInicialIngreso);
         this.panel1.Controls.Add(empresaLabel);
         this.panel1.Controls.Add(puestoLabel);
         this.panel1.Controls.Add(planillaLabel);
         this.panel1.Controls.Add(numeroDeEmpleadoLabel);
         this.panel1.Controls.Add(this.btnBuscar);
         this.panel1.Controls.Add(fechaInicioRelacionLabel);
         this.panel1.Controls.Add(fechaFinLabel);
         this.panel1.Controls.Add(nombreEmpleadoLabel);
         this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.panel1.Location = new System.Drawing.Point(4, 12);
         this.panel1.Name = "panel1";
         this.panel1.Size = new System.Drawing.Size(1410, 112);
         this.panel1.TabIndex = 0;
         // 
         // txtNombreEmpleado
         // 
         this.txtNombreEmpleado.BackColor = System.Drawing.Color.LightGray;
         this.txtNombreEmpleado.FormatInput = UserWindowsControlLibrary.TextBoxSD.InputFormat.InputString;
         this.txtNombreEmpleado.Location = new System.Drawing.Point(7, 76);
         this.txtNombreEmpleado.Name = "txtNombreEmpleado";
         this.txtNombreEmpleado.NumberDecimal = 0;
         this.txtNombreEmpleado.Size = new System.Drawing.Size(250, 24);
         this.txtNombreEmpleado.TabEnter = true;
         this.txtNombreEmpleado.TabIndex = 6;
         this.txtNombreEmpleado.TypeField = UserWindowsControlLibrary.TextBoxSD.TiposDeCampo.Opcional;
         this.txtNombreEmpleado.ValidField = false;
         // 
         // cboPuesto
         // 
         this.cboPuesto.AddAll = true;
         this.cboPuesto.AlternativeQuery = null;
         this.cboPuesto.BackColor = System.Drawing.Color.LightGray;
         this.cboPuesto.ColumnDisplay = "NombrePuesto";
         this.cboPuesto.ColumnValue = "Puesto";
         this.cboPuesto.ConcatenarID = true;
         this.cboPuesto.Conditions = null;
         this.cboPuesto.DataBase = "DbRecursosHumanos";
         this.cboPuesto.DisplayMember = "Descripcion";
         this.cboPuesto.FormattingEnabled = true;
         this.cboPuesto.Location = new System.Drawing.Point(475, 26);
         this.cboPuesto.Name = "cboPuesto";
         this.cboPuesto.NumberOfZeros = 0;
         this.cboPuesto.Objects = UserWindowsControlLibrary.ComboBoxSD.TypeObjects.Table;
         this.cboPuesto.OrderBy = null;
         this.cboPuesto.Server = UserWindowsControlLibrary.ComboBoxSD.Servers.SQLSDFCA5;
         this.cboPuesto.ShowFindDialog = true;
         this.cboPuesto.Size = new System.Drawing.Size(197, 26);
         this.cboPuesto.TabEnter = true;
         this.cboPuesto.TabIndex = 2;
         this.cboPuesto.Table = "VWPuestosCorporacion";
         this.cboPuesto.TipoDeOrden = UserWindowsControlLibrary.ComboBoxSD.TiposDeOrden.Desc;
         this.cboPuesto.TypeField = UserWindowsControlLibrary.ComboBoxSD.TiposDeCampo.Opcional;
         this.cboPuesto.User = null;
         this.cboPuesto.ValidField = false;
         this.cboPuesto.ValueMember = "Codigo";
         // 
         // cboPlanillas
         // 
         this.cboPlanillas.AddAll = true;
         this.cboPlanillas.AlternativeQuery = null;
         this.cboPlanillas.BackColor = System.Drawing.Color.LightGray;
         this.cboPlanillas.ColumnDisplay = "Nombre";
         this.cboPlanillas.ColumnValue = "Planilla";
         this.cboPlanillas.ConcatenarID = true;
         this.cboPlanillas.Conditions = null;
         this.cboPlanillas.DataBase = "DbRecursosHumanos";
         this.cboPlanillas.DisplayMember = "Descripcion";
         this.cboPlanillas.FormattingEnabled = true;
         this.cboPlanillas.Location = new System.Drawing.Point(263, 26);
         this.cboPlanillas.Name = "cboPlanillas";
         this.cboPlanillas.NumberOfZeros = 0;
         this.cboPlanillas.Objects = UserWindowsControlLibrary.ComboBoxSD.TypeObjects.Table;
         this.cboPlanillas.OrderBy = null;
         this.cboPlanillas.Server = UserWindowsControlLibrary.ComboBoxSD.Servers.SQLSDFCA5;
         this.cboPlanillas.ShowFindDialog = true;
         this.cboPlanillas.Size = new System.Drawing.Size(206, 26);
         this.cboPlanillas.TabEnter = true;
         this.cboPlanillas.TabIndex = 1;
         this.cboPlanillas.Table = "VwPlanillas";
         this.cboPlanillas.TipoDeOrden = UserWindowsControlLibrary.ComboBoxSD.TiposDeOrden.Desc;
         this.cboPlanillas.TypeField = UserWindowsControlLibrary.ComboBoxSD.TiposDeCampo.Opcional;
         this.cboPlanillas.User = null;
         this.cboPlanillas.ValidField = false;
         this.cboPlanillas.ValueMember = "Codigo";
         // 
         // CboEmpresas
         // 
         this.CboEmpresas.AddAll = true;
         this.CboEmpresas.AlternativeQuery = null;
         this.CboEmpresas.BackColor = System.Drawing.Color.LightGray;
         this.CboEmpresas.ColumnDisplay = "Nombre";
         this.CboEmpresas.ColumnValue = "Empresa";
         this.CboEmpresas.ConcatenarID = true;
         this.CboEmpresas.Conditions = null;
         this.CboEmpresas.DataBase = "DbRecursosHumanos";
         this.CboEmpresas.DisplayMember = "Descripcion";
         this.CboEmpresas.FormattingEnabled = true;
         this.CboEmpresas.Location = new System.Drawing.Point(7, 26);
         this.CboEmpresas.Name = "CboEmpresas";
         this.CboEmpresas.NumberOfZeros = 0;
         this.CboEmpresas.Objects = UserWindowsControlLibrary.ComboBoxSD.TypeObjects.Table;
         this.CboEmpresas.OrderBy = null;
         this.CboEmpresas.Server = UserWindowsControlLibrary.ComboBoxSD.Servers.SQLSDFCA5;
         this.CboEmpresas.ShowFindDialog = true;
         this.CboEmpresas.Size = new System.Drawing.Size(250, 26);
         this.CboEmpresas.TabEnter = true;
         this.CboEmpresas.TabIndex = 0;
         this.CboEmpresas.Table = "VwEmpresas";
         this.CboEmpresas.TipoDeOrden = UserWindowsControlLibrary.ComboBoxSD.TiposDeOrden.Desc;
         this.CboEmpresas.TypeField = UserWindowsControlLibrary.ComboBoxSD.TiposDeCampo.Opcional;
         this.CboEmpresas.User = null;
         this.CboEmpresas.ValidField = false;
         this.CboEmpresas.ValueMember = "Codigo";
         // 
         // txtNumeroDeEmpleado
         // 
         this.txtNumeroDeEmpleado.BackColor = System.Drawing.Color.LightGray;
         this.txtNumeroDeEmpleado.FormatInput = UserWindowsControlLibrary.TextBoxSD.InputFormat.InputNumber;
         this.txtNumeroDeEmpleado.Location = new System.Drawing.Point(678, 26);
         this.txtNumeroDeEmpleado.Name = "txtNumeroDeEmpleado";
         this.txtNumeroDeEmpleado.NumberDecimal = 0;
         this.txtNumeroDeEmpleado.Size = new System.Drawing.Size(100, 24);
         this.txtNumeroDeEmpleado.TabEnter = true;
         this.txtNumeroDeEmpleado.TabIndex = 3;
         this.txtNumeroDeEmpleado.TypeField = UserWindowsControlLibrary.TextBoxSD.TiposDeCampo.Opcional;
         this.txtNumeroDeEmpleado.ValidField = false;
         // 
         // txtFechaFinalIngreso
         // 
         this.txtFechaFinalIngreso.BackColor = System.Drawing.Color.LightGray;
         this.txtFechaFinalIngreso.Location = new System.Drawing.Point(943, 26);
         this.txtFechaFinalIngreso.Mask = "00/00/0000";
         this.txtFechaFinalIngreso.Name = "txtFechaFinalIngreso";
         this.txtFechaFinalIngreso.Size = new System.Drawing.Size(150, 24);
         this.txtFechaFinalIngreso.TabEnter = true;
         this.txtFechaFinalIngreso.TabIndex = 5;
         this.txtFechaFinalIngreso.TypeField = UserWindowsControlLibrary.MaskedTextBoxSD.TiposDeCampo.Opcional;
         this.txtFechaFinalIngreso.ValidatingType = typeof(System.DateTime);
         // 
         // txtFechaInicialIngreso
         // 
         this.txtFechaInicialIngreso.BackColor = System.Drawing.Color.LightGray;
         this.txtFechaInicialIngreso.Location = new System.Drawing.Point(784, 26);
         this.txtFechaInicialIngreso.Mask = "00/00/0000";
         this.txtFechaInicialIngreso.Name = "txtFechaInicialIngreso";
         this.txtFechaInicialIngreso.Size = new System.Drawing.Size(153, 24);
         this.txtFechaInicialIngreso.TabEnter = true;
         this.txtFechaInicialIngreso.TabIndex = 4;
         this.txtFechaInicialIngreso.TypeField = UserWindowsControlLibrary.MaskedTextBoxSD.TiposDeCampo.Opcional;
         this.txtFechaInicialIngreso.ValidatingType = typeof(System.DateTime);
         // 
         // btnBuscar
         // 
         this.btnBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.btnBuscar.Image = global::Envio_de_Contratos.Properties.Resources.Metro_Search_Black_48;
         this.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
         this.btnBuscar.Location = new System.Drawing.Point(263, 58);
         this.btnBuscar.Name = "btnBuscar";
         this.btnBuscar.Size = new System.Drawing.Size(131, 44);
         this.btnBuscar.TabIndex = 7;
         this.btnBuscar.Text = "Buscar";
         this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
         this.btnBuscar.UseVisualStyleBackColor = true;
         this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
         // 
         // grdDatos
         // 
         this.grdDatos.AllowUserToAddRows = false;
         this.grdDatos.AllowUserToDeleteRows = false;
         this.grdDatos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.grdDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
         this.grdDatos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DPIFirmantePatronoColumn,
            this.razonSocialPatronoColumn,
            this.nombreFirmantePatronoColumn,
            this.calidadFirmanteLegalPatronoColumn,
            this.SalarioColumn,
            this.jornadaColumn,
            this.actividadEconomicaColumn,
            this.formaPagoColumn,
            this.plazoColumn,
            this.fechaInicioRelacionColumn,
            this.fechaFinColumn,
            this.horasTiempoParcialColumn,
            this.tarifaTiempoParcialColumn1,
            this.jornadaTiempoParcialColumn,
            this.nombreEmpleadoColumn,
            this.dpiEmpleadoColumn,
            this.edadEmpleadoColumn,
            this.sexoEmpleadoColumn,
            this.NumeroDeEmpleadoColumn,
            this.PlanillaColumn,
            this.PuestoColumn,
            this.EmpresaColumn});
         this.grdDatos.ContextMenuStrip = this.mnuOpciones;
         this.grdDatos.Location = new System.Drawing.Point(4, 130);
         this.grdDatos.Name = "grdDatos";
         this.grdDatos.ReadOnly = true;
         this.grdDatos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
         this.grdDatos.Size = new System.Drawing.Size(1410, 616);
         this.grdDatos.TabIndex = 1;
         // 
         // DPIFirmantePatronoColumn
         // 
         this.DPIFirmantePatronoColumn.DataPropertyName = "DPIFirmantePatrono";
         this.DPIFirmantePatronoColumn.HeaderText = "DPI Firmante Patrono";
         this.DPIFirmantePatronoColumn.Name = "DPIFirmantePatronoColumn";
         this.DPIFirmantePatronoColumn.ReadOnly = true;
         // 
         // razonSocialPatronoColumn
         // 
         this.razonSocialPatronoColumn.DataPropertyName = "razonSocialPatrono";
         this.razonSocialPatronoColumn.HeaderText = "Razon Social Patrono";
         this.razonSocialPatronoColumn.Name = "razonSocialPatronoColumn";
         this.razonSocialPatronoColumn.ReadOnly = true;
         // 
         // nombreFirmantePatronoColumn
         // 
         this.nombreFirmantePatronoColumn.DataPropertyName = "nombreFirmantePatrono";
         this.nombreFirmantePatronoColumn.HeaderText = "Nombre Firmante Patrono";
         this.nombreFirmantePatronoColumn.Name = "nombreFirmantePatronoColumn";
         this.nombreFirmantePatronoColumn.ReadOnly = true;
         // 
         // calidadFirmanteLegalPatronoColumn
         // 
         this.calidadFirmanteLegalPatronoColumn.DataPropertyName = "calidadFirmanteLegalPatrono";
         this.calidadFirmanteLegalPatronoColumn.HeaderText = "Calidad Firmante Legal Patrono";
         this.calidadFirmanteLegalPatronoColumn.Name = "calidadFirmanteLegalPatronoColumn";
         this.calidadFirmanteLegalPatronoColumn.ReadOnly = true;
         // 
         // SalarioColumn
         // 
         this.SalarioColumn.DataPropertyName = "Salario";
         this.SalarioColumn.HeaderText = "Salario";
         this.SalarioColumn.Name = "SalarioColumn";
         this.SalarioColumn.ReadOnly = true;
         // 
         // jornadaColumn
         // 
         this.jornadaColumn.DataPropertyName = "jornada";
         this.jornadaColumn.HeaderText = "Jornada";
         this.jornadaColumn.Name = "jornadaColumn";
         this.jornadaColumn.ReadOnly = true;
         // 
         // actividadEconomicaColumn
         // 
         this.actividadEconomicaColumn.DataPropertyName = "actividadEconomica";
         this.actividadEconomicaColumn.HeaderText = "Actividad Economica";
         this.actividadEconomicaColumn.Name = "actividadEconomicaColumn";
         this.actividadEconomicaColumn.ReadOnly = true;
         // 
         // formaPagoColumn
         // 
         this.formaPagoColumn.DataPropertyName = "formaPago";
         this.formaPagoColumn.HeaderText = "Forma de Pago";
         this.formaPagoColumn.Name = "formaPagoColumn";
         this.formaPagoColumn.ReadOnly = true;
         // 
         // plazoColumn
         // 
         this.plazoColumn.DataPropertyName = "plazo";
         this.plazoColumn.HeaderText = "Plazo";
         this.plazoColumn.Name = "plazoColumn";
         this.plazoColumn.ReadOnly = true;
         // 
         // fechaInicioRelacionColumn
         // 
         this.fechaInicioRelacionColumn.DataPropertyName = "fechaInicioRelacion";
         this.fechaInicioRelacionColumn.HeaderText = "Fecha Inicio Relacion";
         this.fechaInicioRelacionColumn.Name = "fechaInicioRelacionColumn";
         this.fechaInicioRelacionColumn.ReadOnly = true;
         // 
         // fechaFinColumn
         // 
         this.fechaFinColumn.DataPropertyName = "fechaFin";
         this.fechaFinColumn.HeaderText = "Fecha Final Relacion";
         this.fechaFinColumn.Name = "fechaFinColumn";
         this.fechaFinColumn.ReadOnly = true;
         // 
         // horasTiempoParcialColumn
         // 
         this.horasTiempoParcialColumn.DataPropertyName = "horasTiempoParcial";
         this.horasTiempoParcialColumn.HeaderText = "Horas Tiempo Parcial";
         this.horasTiempoParcialColumn.Name = "horasTiempoParcialColumn";
         this.horasTiempoParcialColumn.ReadOnly = true;
         // 
         // tarifaTiempoParcialColumn1
         // 
         this.tarifaTiempoParcialColumn1.DataPropertyName = "tarifaTiempoParcial";
         this.tarifaTiempoParcialColumn1.HeaderText = "Tarifa Tiempo Parcial";
         this.tarifaTiempoParcialColumn1.Name = "tarifaTiempoParcialColumn1";
         this.tarifaTiempoParcialColumn1.ReadOnly = true;
         // 
         // jornadaTiempoParcialColumn
         // 
         this.jornadaTiempoParcialColumn.DataPropertyName = "jornadaTiempoParcial";
         this.jornadaTiempoParcialColumn.HeaderText = "Jornada Tiempo Parcial";
         this.jornadaTiempoParcialColumn.Name = "jornadaTiempoParcialColumn";
         this.jornadaTiempoParcialColumn.ReadOnly = true;
         // 
         // nombreEmpleadoColumn
         // 
         this.nombreEmpleadoColumn.DataPropertyName = "nombreEmpleado";
         this.nombreEmpleadoColumn.HeaderText = "Nombre Empleado";
         this.nombreEmpleadoColumn.Name = "nombreEmpleadoColumn";
         this.nombreEmpleadoColumn.ReadOnly = true;
         // 
         // dpiEmpleadoColumn
         // 
         this.dpiEmpleadoColumn.DataPropertyName = "dpiEmpleado";
         this.dpiEmpleadoColumn.HeaderText = "DPI Empleado";
         this.dpiEmpleadoColumn.Name = "dpiEmpleadoColumn";
         this.dpiEmpleadoColumn.ReadOnly = true;
         // 
         // edadEmpleadoColumn
         // 
         this.edadEmpleadoColumn.DataPropertyName = "edadEmpleado";
         this.edadEmpleadoColumn.HeaderText = "Edad Empleado";
         this.edadEmpleadoColumn.Name = "edadEmpleadoColumn";
         this.edadEmpleadoColumn.ReadOnly = true;
         // 
         // sexoEmpleadoColumn
         // 
         this.sexoEmpleadoColumn.DataPropertyName = "sexoEmpleado";
         this.sexoEmpleadoColumn.HeaderText = "Genero Empleado";
         this.sexoEmpleadoColumn.Name = "sexoEmpleadoColumn";
         this.sexoEmpleadoColumn.ReadOnly = true;
         // 
         // NumeroDeEmpleadoColumn
         // 
         this.NumeroDeEmpleadoColumn.DataPropertyName = "NumeroDeEmpleado";
         this.NumeroDeEmpleadoColumn.HeaderText = "Numero De Empleado";
         this.NumeroDeEmpleadoColumn.Name = "NumeroDeEmpleadoColumn";
         this.NumeroDeEmpleadoColumn.ReadOnly = true;
         // 
         // PlanillaColumn
         // 
         this.PlanillaColumn.DataPropertyName = "Planilla";
         this.PlanillaColumn.HeaderText = "Planilla";
         this.PlanillaColumn.Name = "PlanillaColumn";
         this.PlanillaColumn.ReadOnly = true;
         // 
         // PuestoColumn
         // 
         this.PuestoColumn.DataPropertyName = "Puesto";
         this.PuestoColumn.HeaderText = "Puesto";
         this.PuestoColumn.Name = "PuestoColumn";
         this.PuestoColumn.ReadOnly = true;
         // 
         // EmpresaColumn
         // 
         this.EmpresaColumn.DataPropertyName = "Empresa";
         this.EmpresaColumn.HeaderText = "Empresa";
         this.EmpresaColumn.Name = "EmpresaColumn";
         this.EmpresaColumn.ReadOnly = true;
         // 
         // mnuOpciones
         // 
         this.mnuOpciones.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnuEnviarContrato});
         this.mnuOpciones.Name = "mnuOpciones";
         this.mnuOpciones.Size = new System.Drawing.Size(157, 26);
         // 
         // MnuEnviarContrato
         // 
         this.MnuEnviarContrato.Name = "MnuEnviarContrato";
         this.MnuEnviarContrato.Size = new System.Drawing.Size(156, 22);
         this.MnuEnviarContrato.Text = "Enviar Contrato";
         this.MnuEnviarContrato.Click += new System.EventHandler(this.MnuEnviarContrato_Click);
         // 
         // toolStrip1
         // 
         this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
         this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
         this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblRegistros,
            this.toolStripLabel1,
            this.toolStripSeparator1,
            this.toolStripLabel3,
            this.toolStripLabel2});
         this.toolStrip1.Location = new System.Drawing.Point(0, 748);
         this.toolStrip1.Name = "toolStrip1";
         this.toolStrip1.Size = new System.Drawing.Size(1417, 25);
         this.toolStrip1.TabIndex = 3;
         this.toolStrip1.Text = "toolStrip1";
         // 
         // lblRegistros
         // 
         this.lblRegistros.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
         this.lblRegistros.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
         this.lblRegistros.Name = "lblRegistros";
         this.lblRegistros.Size = new System.Drawing.Size(19, 22);
         this.lblRegistros.Text = "0";
         this.lblRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
         // 
         // toolStripLabel1
         // 
         this.toolStripLabel1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
         this.toolStripLabel1.Name = "toolStripLabel1";
         this.toolStripLabel1.Size = new System.Drawing.Size(58, 22);
         this.toolStripLabel1.Text = "Registros:";
         // 
         // toolStripSeparator1
         // 
         this.toolStripSeparator1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
         this.toolStripSeparator1.Name = "toolStripSeparator1";
         this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
         // 
         // toolStripLabel3
         // 
         this.toolStripLabel3.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
         this.toolStripLabel3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
         this.toolStripLabel3.Name = "toolStripLabel3";
         this.toolStripLabel3.Size = new System.Drawing.Size(76, 22);
         this.toolStripLabel3.Text = "1.0.0.001";
         // 
         // toolStripLabel2
         // 
         this.toolStripLabel2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
         this.toolStripLabel2.Name = "toolStripLabel2";
         this.toolStripLabel2.Size = new System.Drawing.Size(48, 22);
         this.toolStripLabel2.Text = "Version:";
         // 
         // Form1
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(1417, 773);
         this.Controls.Add(this.toolStrip1);
         this.Controls.Add(this.grdDatos);
         this.Controls.Add(this.panel1);
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.Name = "Form1";
         this.Text = "San Diego S.A. || Envio de Contratos";
         this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
         this.Load += new System.EventHandler(this.Form1_Load);
         this.panel1.ResumeLayout(false);
         this.panel1.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.grdDatos)).EndInit();
         this.mnuOpciones.ResumeLayout(false);
         this.toolStrip1.ResumeLayout(false);
         this.toolStrip1.PerformLayout();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Panel panel1;
      private System.Windows.Forms.Button btnBuscar;
      private UserWindowsControlLibrary.TextBoxSD txtNombreEmpleado;
      private UserWindowsControlLibrary.ComboBoxSD cboPuesto;
      private UserWindowsControlLibrary.ComboBoxSD cboPlanillas;
      private UserWindowsControlLibrary.ComboBoxSD CboEmpresas;
      private UserWindowsControlLibrary.TextBoxSD txtNumeroDeEmpleado;
      private UserWindowsControlLibrary.MaskedTextBoxSD txtFechaFinalIngreso;
      private UserWindowsControlLibrary.MaskedTextBoxSD txtFechaInicialIngreso;
      private System.Windows.Forms.DataGridView grdDatos;
      private System.Windows.Forms.DataGridViewTextBoxColumn DPIFirmantePatronoColumn;
      private System.Windows.Forms.DataGridViewTextBoxColumn razonSocialPatronoColumn;
      private System.Windows.Forms.DataGridViewTextBoxColumn nombreFirmantePatronoColumn;
      private System.Windows.Forms.DataGridViewTextBoxColumn calidadFirmanteLegalPatronoColumn;
      private System.Windows.Forms.DataGridViewTextBoxColumn SalarioColumn;
      private System.Windows.Forms.DataGridViewTextBoxColumn jornadaColumn;
      private System.Windows.Forms.DataGridViewTextBoxColumn actividadEconomicaColumn;
      private System.Windows.Forms.DataGridViewTextBoxColumn formaPagoColumn;
      private System.Windows.Forms.DataGridViewTextBoxColumn plazoColumn;
      private System.Windows.Forms.DataGridViewTextBoxColumn fechaInicioRelacionColumn;
      private System.Windows.Forms.DataGridViewTextBoxColumn fechaFinColumn;
      private System.Windows.Forms.DataGridViewTextBoxColumn horasTiempoParcialColumn;
      private System.Windows.Forms.DataGridViewTextBoxColumn tarifaTiempoParcialColumn1;
      private System.Windows.Forms.DataGridViewTextBoxColumn jornadaTiempoParcialColumn;
      private System.Windows.Forms.DataGridViewTextBoxColumn nombreEmpleadoColumn;
      private System.Windows.Forms.DataGridViewTextBoxColumn dpiEmpleadoColumn;
      private System.Windows.Forms.DataGridViewTextBoxColumn edadEmpleadoColumn;
      private System.Windows.Forms.DataGridViewTextBoxColumn sexoEmpleadoColumn;
      private System.Windows.Forms.DataGridViewTextBoxColumn NumeroDeEmpleadoColumn;
      private System.Windows.Forms.DataGridViewTextBoxColumn PlanillaColumn;
      private System.Windows.Forms.DataGridViewTextBoxColumn PuestoColumn;
      private System.Windows.Forms.DataGridViewTextBoxColumn EmpresaColumn;
      private System.Windows.Forms.ContextMenuStrip mnuOpciones;
      private System.Windows.Forms.ToolStripMenuItem MnuEnviarContrato;
      private System.Windows.Forms.ToolStrip toolStrip1;
      private System.Windows.Forms.ToolStripLabel lblRegistros;
      private System.Windows.Forms.ToolStripLabel toolStripLabel1;
      private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
      private System.Windows.Forms.ToolStripLabel toolStripLabel3;
      private System.Windows.Forms.ToolStripLabel toolStripLabel2;
   }
}

