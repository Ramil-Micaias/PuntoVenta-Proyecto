namespace GU_Tercero
{
    partial class FormTaller
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
            grpRecepciónCliente = new GroupBox();
            cmbEstado = new ComboBox();
            dtpFecha = new DateTimePicker();
            cmbTecnico = new ComboBox();
            cmbEquipo = new ComboBox();
            cmbCliente = new ComboBox();
            txtRecepcion = new TextBox();
            lblEstado = new Label();
            lblFecha = new Label();
            lblRecepcion = new Label();
            lblTecnico = new Label();
            lblEquipo = new Label();
            lblCliente = new Label();
            groupBox1 = new GroupBox();
            txtDiagnosticoTecnico = new TextBox();
            txtPatronClave = new TextBox();
            txtFallaDeclarada = new TextBox();
            lblDiagnosticoTecnico = new Label();
            lblPatronClave = new Label();
            lblFallaDeclarada = new Label();
            grpPresupuestoRepuestos = new GroupBox();
            txtManoObra = new TextBox();
            lblManoObra = new Label();
            btnGuardarOrden = new Button();
            btnCancelar = new Button();
            txtToalPresupuesto = new TextBox();
            lblTotalPresupuesto = new Label();
            dgvRepuestos = new DataGridView();
            btnAgregarRepuesto = new Button();
            numCantidadRepuesto = new NumericUpDown();
            txtPrecio = new TextBox();
            cmbRepuesto = new ComboBox();
            lblCantidad = new Label();
            lblPrecio = new Label();
            lblRepuesto = new Label();
            grpRecepciónCliente.SuspendLayout();
            groupBox1.SuspendLayout();
            grpPresupuestoRepuestos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRepuestos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numCantidadRepuesto).BeginInit();
            SuspendLayout();
            // 
            // grpRecepciónCliente
            // 
            grpRecepciónCliente.Controls.Add(cmbEstado);
            grpRecepciónCliente.Controls.Add(dtpFecha);
            grpRecepciónCliente.Controls.Add(cmbTecnico);
            grpRecepciónCliente.Controls.Add(cmbEquipo);
            grpRecepciónCliente.Controls.Add(cmbCliente);
            grpRecepciónCliente.Controls.Add(txtRecepcion);
            grpRecepciónCliente.Controls.Add(lblEstado);
            grpRecepciónCliente.Controls.Add(lblFecha);
            grpRecepciónCliente.Controls.Add(lblRecepcion);
            grpRecepciónCliente.Controls.Add(lblTecnico);
            grpRecepciónCliente.Controls.Add(lblEquipo);
            grpRecepciónCliente.Controls.Add(lblCliente);
            grpRecepciónCliente.Location = new Point(2, 2);
            grpRecepciónCliente.Name = "grpRecepciónCliente";
            grpRecepciónCliente.Size = new Size(797, 112);
            grpRecepciónCliente.TabIndex = 0;
            grpRecepciónCliente.TabStop = false;
            grpRecepciónCliente.Text = "Recepción y Cliente";
            // 
            // cmbEstado
            // 
            cmbEstado.FormattingEnabled = true;
            cmbEstado.Location = new Point(401, 81);
            cmbEstado.Name = "cmbEstado";
            cmbEstado.Size = new Size(201, 23);
            cmbEstado.TabIndex = 11;
            // 
            // dtpFecha
            // 
            dtpFecha.CustomFormat = "dd/mm/yyyy";
            dtpFecha.Location = new Point(401, 51);
            dtpFecha.Name = "dtpFecha";
            dtpFecha.Size = new Size(200, 23);
            dtpFecha.TabIndex = 10;
            // 
            // cmbTecnico
            // 
            cmbTecnico.FormattingEnabled = true;
            cmbTecnico.Location = new Point(65, 81);
            cmbTecnico.Name = "cmbTecnico";
            cmbTecnico.Size = new Size(194, 23);
            cmbTecnico.TabIndex = 9;
            // 
            // cmbEquipo
            // 
            cmbEquipo.FormattingEnabled = true;
            cmbEquipo.Location = new Point(65, 52);
            cmbEquipo.Name = "cmbEquipo";
            cmbEquipo.Size = new Size(194, 23);
            cmbEquipo.TabIndex = 8;
            // 
            // cmbCliente
            // 
            cmbCliente.FormattingEnabled = true;
            cmbCliente.Location = new Point(65, 22);
            cmbCliente.Name = "cmbCliente";
            cmbCliente.Size = new Size(194, 23);
            cmbCliente.TabIndex = 7;
            // 
            // txtRecepcion
            // 
            txtRecepcion.Location = new Point(401, 22);
            txtRecepcion.Name = "txtRecepcion";
            txtRecepcion.ReadOnly = true;
            txtRecepcion.Size = new Size(201, 23);
            txtRecepcion.TabIndex = 6;
            // 
            // lblEstado
            // 
            lblEstado.AutoSize = true;
            lblEstado.Location = new Point(350, 85);
            lblEstado.Name = "lblEstado";
            lblEstado.Size = new Size(45, 15);
            lblEstado.TabIndex = 5;
            lblEstado.Text = "Estado:";
            // 
            // lblFecha
            // 
            lblFecha.AutoSize = true;
            lblFecha.Location = new Point(354, 54);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(41, 15);
            lblFecha.TabIndex = 4;
            lblFecha.Text = "Fecha:";
            // 
            // lblRecepcion
            // 
            lblRecepcion.AutoSize = true;
            lblRecepcion.Location = new Point(330, 24);
            lblRecepcion.Name = "lblRecepcion";
            lblRecepcion.Size = new Size(65, 15);
            lblRecepcion.TabIndex = 3;
            lblRecepcion.Text = "Recepción:";
            // 
            // lblTecnico
            // 
            lblTecnico.AutoSize = true;
            lblTecnico.Location = new Point(14, 84);
            lblTecnico.Name = "lblTecnico";
            lblTecnico.Size = new Size(50, 15);
            lblTecnico.TabIndex = 2;
            lblTecnico.Text = "Tecnico:";
            // 
            // lblEquipo
            // 
            lblEquipo.AutoSize = true;
            lblEquipo.Location = new Point(14, 55);
            lblEquipo.Name = "lblEquipo";
            lblEquipo.Size = new Size(47, 15);
            lblEquipo.TabIndex = 1;
            lblEquipo.Text = "Equipo:";
            // 
            // lblCliente
            // 
            lblCliente.AutoSize = true;
            lblCliente.Location = new Point(14, 25);
            lblCliente.Name = "lblCliente";
            lblCliente.Size = new Size(47, 15);
            lblCliente.TabIndex = 0;
            lblCliente.Text = "Cliente:";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtDiagnosticoTecnico);
            groupBox1.Controls.Add(txtPatronClave);
            groupBox1.Controls.Add(txtFallaDeclarada);
            groupBox1.Controls.Add(lblDiagnosticoTecnico);
            groupBox1.Controls.Add(lblPatronClave);
            groupBox1.Controls.Add(lblFallaDeclarada);
            groupBox1.Location = new Point(2, 112);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(797, 79);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Diagnóstico y Falla";
            // 
            // txtDiagnosticoTecnico
            // 
            txtDiagnosticoTecnico.Location = new Point(579, 44);
            txtDiagnosticoTecnico.Multiline = true;
            txtDiagnosticoTecnico.Name = "txtDiagnosticoTecnico";
            txtDiagnosticoTecnico.Size = new Size(190, 23);
            txtDiagnosticoTecnico.TabIndex = 5;
            // 
            // txtPatronClave
            // 
            txtPatronClave.Location = new Point(295, 44);
            txtPatronClave.Name = "txtPatronClave";
            txtPatronClave.Size = new Size(190, 23);
            txtPatronClave.TabIndex = 4;
            // 
            // txtFallaDeclarada
            // 
            txtFallaDeclarada.Location = new Point(10, 44);
            txtFallaDeclarada.Multiline = true;
            txtFallaDeclarada.Name = "txtFallaDeclarada";
            txtFallaDeclarada.Size = new Size(190, 23);
            txtFallaDeclarada.TabIndex = 3;
            // 
            // lblDiagnosticoTecnico
            // 
            lblDiagnosticoTecnico.AutoSize = true;
            lblDiagnosticoTecnico.Location = new Point(624, 26);
            lblDiagnosticoTecnico.Name = "lblDiagnosticoTecnico";
            lblDiagnosticoTecnico.Size = new Size(113, 15);
            lblDiagnosticoTecnico.TabIndex = 2;
            lblDiagnosticoTecnico.Text = "Diagnostico Tecnico";
            // 
            // lblPatronClave
            // 
            lblPatronClave.AutoSize = true;
            lblPatronClave.Location = new Point(350, 26);
            lblPatronClave.Name = "lblPatronClave";
            lblPatronClave.Size = new Size(85, 15);
            lblPatronClave.TabIndex = 1;
            lblPatronClave.Text = "Patrón / Clave:";
            // 
            // lblFallaDeclarada
            // 
            lblFallaDeclarada.AutoSize = true;
            lblFallaDeclarada.Location = new Point(58, 26);
            lblFallaDeclarada.Name = "lblFallaDeclarada";
            lblFallaDeclarada.Size = new Size(89, 15);
            lblFallaDeclarada.TabIndex = 0;
            lblFallaDeclarada.Text = "Falla Declarada:";
            // 
            // grpPresupuestoRepuestos
            // 
            grpPresupuestoRepuestos.Controls.Add(txtManoObra);
            grpPresupuestoRepuestos.Controls.Add(lblManoObra);
            grpPresupuestoRepuestos.Controls.Add(btnGuardarOrden);
            grpPresupuestoRepuestos.Controls.Add(btnCancelar);
            grpPresupuestoRepuestos.Controls.Add(txtToalPresupuesto);
            grpPresupuestoRepuestos.Controls.Add(lblTotalPresupuesto);
            grpPresupuestoRepuestos.Controls.Add(dgvRepuestos);
            grpPresupuestoRepuestos.Controls.Add(btnAgregarRepuesto);
            grpPresupuestoRepuestos.Controls.Add(numCantidadRepuesto);
            grpPresupuestoRepuestos.Controls.Add(txtPrecio);
            grpPresupuestoRepuestos.Controls.Add(cmbRepuesto);
            grpPresupuestoRepuestos.Controls.Add(lblCantidad);
            grpPresupuestoRepuestos.Controls.Add(lblPrecio);
            grpPresupuestoRepuestos.Controls.Add(lblRepuesto);
            grpPresupuestoRepuestos.Location = new Point(2, 185);
            grpPresupuestoRepuestos.Name = "grpPresupuestoRepuestos";
            grpPresupuestoRepuestos.Size = new Size(797, 265);
            grpPresupuestoRepuestos.TabIndex = 2;
            grpPresupuestoRepuestos.TabStop = false;
            grpPresupuestoRepuestos.Text = "Presupuesto y Repuestos";
            // 
            // txtManoObra
            // 
            txtManoObra.Location = new Point(686, 74);
            txtManoObra.Name = "txtManoObra";
            txtManoObra.Size = new Size(100, 23);
            txtManoObra.TabIndex = 13;
            // 
            // lblManoObra
            // 
            lblManoObra.AutoSize = true;
            lblManoObra.Location = new Point(586, 78);
            lblManoObra.Name = "lblManoObra";
            lblManoObra.Size = new Size(98, 15);
            lblManoObra.TabIndex = 12;
            lblManoObra.Text = "MANO DE OBRA:";
            // 
            // btnGuardarOrden
            // 
            btnGuardarOrden.Location = new Point(678, 230);
            btnGuardarOrden.Name = "btnGuardarOrden";
            btnGuardarOrden.Size = new Size(108, 23);
            btnGuardarOrden.TabIndex = 11;
            btnGuardarOrden.Text = "Guardar Orden";
            btnGuardarOrden.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(579, 230);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 23);
            btnCancelar.TabIndex = 10;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // txtToalPresupuesto
            // 
            txtToalPresupuesto.Location = new Point(686, 104);
            txtToalPresupuesto.Name = "txtToalPresupuesto";
            txtToalPresupuesto.ReadOnly = true;
            txtToalPresupuesto.Size = new Size(100, 23);
            txtToalPresupuesto.TabIndex = 9;
            // 
            // lblTotalPresupuesto
            // 
            lblTotalPresupuesto.AutoSize = true;
            lblTotalPresupuesto.Location = new Point(564, 108);
            lblTotalPresupuesto.Name = "lblTotalPresupuesto";
            lblTotalPresupuesto.Size = new Size(120, 15);
            lblTotalPresupuesto.TabIndex = 8;
            lblTotalPresupuesto.Text = "TOTAL PRESUPUESTO:";
            // 
            // dgvRepuestos
            // 
            dgvRepuestos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRepuestos.Location = new Point(10, 67);
            dgvRepuestos.Name = "dgvRepuestos";
            dgvRepuestos.Size = new Size(528, 186);
            dgvRepuestos.TabIndex = 7;
            // 
            // btnAgregarRepuesto
            // 
            btnAgregarRepuesto.Location = new Point(686, 14);
            btnAgregarRepuesto.Name = "btnAgregarRepuesto";
            btnAgregarRepuesto.Size = new Size(105, 45);
            btnAgregarRepuesto.TabIndex = 6;
            btnAgregarRepuesto.Text = "+ Agregar Repuesto";
            btnAgregarRepuesto.UseVisualStyleBackColor = true;
            // 
            // numCantidadRepuesto
            // 
            numCantidadRepuesto.Location = new Point(540, 23);
            numCantidadRepuesto.Name = "numCantidadRepuesto";
            numCantidadRepuesto.Size = new Size(120, 23);
            numCantidadRepuesto.TabIndex = 5;
            // 
            // txtPrecio
            // 
            txtPrecio.Location = new Point(336, 24);
            txtPrecio.Name = "txtPrecio";
            txtPrecio.Size = new Size(132, 23);
            txtPrecio.TabIndex = 4;
            // 
            // cmbRepuesto
            // 
            cmbRepuesto.FormattingEnabled = true;
            cmbRepuesto.Location = new Point(70, 25);
            cmbRepuesto.Name = "cmbRepuesto";
            cmbRepuesto.Size = new Size(206, 23);
            cmbRepuesto.TabIndex = 3;
            // 
            // lblCantidad
            // 
            lblCantidad.AutoSize = true;
            lblCantidad.Location = new Point(480, 27);
            lblCantidad.Name = "lblCantidad";
            lblCantidad.Size = new Size(58, 15);
            lblCantidad.TabIndex = 2;
            lblCantidad.Text = "Cantidad:";
            // 
            // lblPrecio
            // 
            lblPrecio.AutoSize = true;
            lblPrecio.Location = new Point(291, 28);
            lblPrecio.Name = "lblPrecio";
            lblPrecio.Size = new Size(43, 15);
            lblPrecio.TabIndex = 1;
            lblPrecio.Text = "Precio:";
            // 
            // lblRepuesto
            // 
            lblRepuesto.AutoSize = true;
            lblRepuesto.Location = new Point(9, 28);
            lblRepuesto.Name = "lblRepuesto";
            lblRepuesto.Size = new Size(59, 15);
            lblRepuesto.TabIndex = 0;
            lblRepuesto.Text = "Repuesto:";
            // 
            // FormTaller
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(grpPresupuestoRepuestos);
            Controls.Add(groupBox1);
            Controls.Add(grpRecepciónCliente);
            Name = "FormTaller";
            Text = "Taller";
            Load += FormTaller_Load;
            grpRecepciónCliente.ResumeLayout(false);
            grpRecepciónCliente.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            grpPresupuestoRepuestos.ResumeLayout(false);
            grpPresupuestoRepuestos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRepuestos).EndInit();
            ((System.ComponentModel.ISupportInitialize)numCantidadRepuesto).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox grpRecepciónCliente;
        private Label lblEquipo;
        private Label lblCliente;
        private Label lblTecnico;
        private Label lblEstado;
        private Label lblFecha;
        private Label lblRecepcion;
        private TextBox txtRecepcion;
        private ComboBox cmbTecnico;
        private ComboBox cmbEquipo;
        private ComboBox cmbCliente;
        private DateTimePicker dtpFecha;
        private ComboBox cmbEstado;
        private GroupBox groupBox1;
        private Label lblPatronClave;
        private Label lblFallaDeclarada;
        private TextBox txtDiagnosticoTecnico;
        private TextBox txtPatronClave;
        private TextBox txtFallaDeclarada;
        private Label lblDiagnosticoTecnico;
        private GroupBox grpPresupuestoRepuestos;
        private Label lblRepuesto;
        private Label lblCantidad;
        private Label lblPrecio;
        private NumericUpDown numCantidadRepuesto;
        private TextBox txtPrecio;
        private ComboBox cmbRepuesto;
        private DataGridView dgvRepuestos;
        private Button btnAgregarRepuesto;
        private TextBox txtToalPresupuesto;
        private Label lblTotalPresupuesto;
        private Button btnCancelar;
        private Button btnGuardarOrden;
        private TextBox txtManoObra;
        private Label lblManoObra;
    }
}