namespace Proyecto_Entregable
{
    partial class Frm_Almacenes
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
            this.DGVAlmacen = new System.Windows.Forms.DataGridView();
            this.lblOpcion = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.txtStock = new System.Windows.Forms.TextBox();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DGVAlmacen)).BeginInit();
            this.SuspendLayout();
            // 
            // DGVAlmacen
            // 
            this.DGVAlmacen.AllowUserToOrderColumns = true;
            this.DGVAlmacen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVAlmacen.Location = new System.Drawing.Point(13, 13);
            this.DGVAlmacen.Margin = new System.Windows.Forms.Padding(4);
            this.DGVAlmacen.Name = "DGVAlmacen";
            this.DGVAlmacen.RowHeadersWidth = 51;
            this.DGVAlmacen.Size = new System.Drawing.Size(800, 367);
            this.DGVAlmacen.TabIndex = 2;
            this.DGVAlmacen.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVAlmacen_CellClick);
            // 
            // lblOpcion
            // 
            this.lblOpcion.AutoSize = true;
            this.lblOpcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOpcion.Location = new System.Drawing.Point(874, 9);
            this.lblOpcion.Name = "lblOpcion";
            this.lblOpcion.Size = new System.Drawing.Size(279, 32);
            this.lblOpcion.TabIndex = 3;
            this.lblOpcion.Text = "Visualizar Producto";
            // 
            // txtNombre
            // 
            this.txtNombre.BackColor = System.Drawing.Color.LightGray;
            this.txtNombre.Enabled = false;
            this.txtNombre.Location = new System.Drawing.Point(861, 83);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(312, 22);
            this.txtNombre.TabIndex = 4;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.BackColor = System.Drawing.Color.LightGray;
            this.txtDescripcion.Enabled = false;
            this.txtDescripcion.Location = new System.Drawing.Point(861, 145);
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(312, 64);
            this.txtDescripcion.TabIndex = 5;
            // 
            // txtPrecio
            // 
            this.txtPrecio.BackColor = System.Drawing.Color.LightGray;
            this.txtPrecio.Enabled = false;
            this.txtPrecio.Location = new System.Drawing.Point(1016, 234);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(157, 22);
            this.txtPrecio.TabIndex = 6;
            // 
            // txtStock
            // 
            this.txtStock.BackColor = System.Drawing.Color.LightGray;
            this.txtStock.Enabled = false;
            this.txtStock.Location = new System.Drawing.Point(931, 269);
            this.txtStock.Name = "txtStock";
            this.txtStock.Size = new System.Drawing.Size(242, 22);
            this.txtStock.TabIndex = 7;
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConfirmar.Enabled = false;
            this.btnConfirmar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnConfirmar.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirmar.Location = new System.Drawing.Point(907, 310);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(204, 49);
            this.btnConfirmar.TabIndex = 8;
            this.btnConfirmar.Text = "XXXXXX";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(864, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "Nombre:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(863, 122);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 20);
            this.label2.TabIndex = 10;
            this.label2.Text = "Descripcion:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(864, 234);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(136, 20);
            this.label3.TabIndex = 11;
            this.label3.Text = "Precio (Soles):";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(863, 269);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 20);
            this.label4.TabIndex = 12;
            this.label4.Text = "Stock:";
            // 
            // Frm_Almacenes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1196, 394);
            this.ControlBox = false;
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.txtStock);
            this.Controls.Add(this.txtPrecio);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.lblOpcion);
            this.Controls.Add(this.DGVAlmacen);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_Almacenes";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Almacen";
            ((System.ComponentModel.ISupportInitialize)(this.DGVAlmacen)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView DGVAlmacen;
        private System.Windows.Forms.Label lblOpcion;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.TextBox txtStock;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}