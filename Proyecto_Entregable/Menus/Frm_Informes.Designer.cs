namespace Proyecto_Entregable
{
    partial class Frm_Informes
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.v_ProductosRegistradosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tECHSOLUBDDataSet = new Proyecto_Entregable.TECHSOLUBDDataSet();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.btnGenerar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbTipoReporte = new System.Windows.Forms.ComboBox();
            this.vProductosRegistradosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.v_ProductosRegistradosTableAdapter = new Proyecto_Entregable.TECHSOLUBDDataSetTableAdapters.v_ProductosRegistradosTableAdapter();
            this.tECHSOLUBDDataSet1 = new Proyecto_Entregable.TECHSOLUBDDataSet1();
            this.vVentasConDetallesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.v_VentasConDetallesTableAdapter = new Proyecto_Entregable.TECHSOLUBDDataSet1TableAdapters.v_VentasConDetallesTableAdapter();
            this.v_VentasConDetallesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.v_ProductosRegistradosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tECHSOLUBDDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vProductosRegistradosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tECHSOLUBDDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vVentasConDetallesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.v_VentasConDetallesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // v_ProductosRegistradosBindingSource
            // 
            this.v_ProductosRegistradosBindingSource.DataMember = "v_ProductosRegistrados";
            this.v_ProductosRegistradosBindingSource.DataSource = this.tECHSOLUBDDataSet;
            // 
            // tECHSOLUBDDataSet
            // 
            this.tECHSOLUBDDataSet.DataSetName = "TECHSOLUBDDataSet";
            this.tECHSOLUBDDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            reportDataSource2.Name = "ProductoDataSet1";
            reportDataSource2.Value = this.v_ProductosRegistradosBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Proyecto_Entregable.Menus.Reportes.ReporteAlmacen.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(24, 51);
            this.reportViewer1.Margin = new System.Windows.Forms.Padding(4);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(936, 420);
            this.reportViewer1.TabIndex = 0;
            // 
            // btnGenerar
            // 
            this.btnGenerar.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnGenerar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGenerar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGenerar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerar.Location = new System.Drawing.Point(601, 15);
            this.btnGenerar.Margin = new System.Windows.Forms.Padding(4);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(172, 28);
            this.btnGenerar.TabIndex = 2;
            this.btnGenerar.Text = "Generar reporte";
            this.btnGenerar.UseVisualStyleBackColor = false;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(31, 16);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(225, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "Elegir tipo de reporte: ";
            // 
            // cmbTipoReporte
            // 
            this.cmbTipoReporte.FormattingEnabled = true;
            this.cmbTipoReporte.Location = new System.Drawing.Point(264, 16);
            this.cmbTipoReporte.Margin = new System.Windows.Forms.Padding(4);
            this.cmbTipoReporte.Name = "cmbTipoReporte";
            this.cmbTipoReporte.Size = new System.Drawing.Size(264, 24);
            this.cmbTipoReporte.TabIndex = 4;
            // 
            // vProductosRegistradosBindingSource
            // 
            this.vProductosRegistradosBindingSource.DataMember = "v_ProductosRegistrados";
            this.vProductosRegistradosBindingSource.DataSource = this.tECHSOLUBDDataSet;
            // 
            // v_ProductosRegistradosTableAdapter
            // 
            this.v_ProductosRegistradosTableAdapter.ClearBeforeFill = true;
            // 
            // tECHSOLUBDDataSet1
            // 
            this.tECHSOLUBDDataSet1.DataSetName = "TECHSOLUBDDataSet1";
            this.tECHSOLUBDDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // vVentasConDetallesBindingSource
            // 
            this.vVentasConDetallesBindingSource.DataMember = "v_VentasConDetalles";
            this.vVentasConDetallesBindingSource.DataSource = this.tECHSOLUBDDataSet1;
            // 
            // v_VentasConDetallesTableAdapter
            // 
            this.v_VentasConDetallesTableAdapter.ClearBeforeFill = true;
            // 
            // v_VentasConDetallesBindingSource
            // 
            this.v_VentasConDetallesBindingSource.DataMember = "v_VentasConDetalles";
            this.v_VentasConDetallesBindingSource.DataSource = this.tECHSOLUBDDataSet1;
            // 
            // Frm_Informes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(973, 495);
            this.ControlBox = false;
            this.Controls.Add(this.cmbTipoReporte);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnGenerar);
            this.Controls.Add(this.reportViewer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_Informes";
            this.ShowIcon = false;
            this.Text = "Informes e Impresiones";
            this.Load += new System.EventHandler(this.Frm_Informes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.v_ProductosRegistradosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tECHSOLUBDDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vProductosRegistradosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tECHSOLUBDDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vVentasConDetallesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.v_VentasConDetallesBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.Button btnGenerar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbTipoReporte;
        private TECHSOLUBDDataSet tECHSOLUBDDataSet;
        private System.Windows.Forms.BindingSource vProductosRegistradosBindingSource;
        private TECHSOLUBDDataSetTableAdapters.v_ProductosRegistradosTableAdapter v_ProductosRegistradosTableAdapter;
        private System.Windows.Forms.BindingSource v_ProductosRegistradosBindingSource;
        private TECHSOLUBDDataSet1 tECHSOLUBDDataSet1;
        private System.Windows.Forms.BindingSource vVentasConDetallesBindingSource;
        private TECHSOLUBDDataSet1TableAdapters.v_VentasConDetallesTableAdapter v_VentasConDetallesTableAdapter;
        private System.Windows.Forms.BindingSource v_VentasConDetallesBindingSource;
    }
}