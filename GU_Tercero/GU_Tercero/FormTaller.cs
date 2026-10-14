using System;
using System.Windows.Forms;

namespace GU_Tercero;

public partial class FormTaller : Form
{
    public FormTaller()
    {
        InitializeComponent();
    }

    private void FormTaller_Load(object sender, EventArgs e)
    {
    }

    private void btnCancelar_Click(object sender, EventArgs e)
    {
        DialogResult respuesta = MessageBox.Show(
            "¿Desea cancelar la orden y descartar los datos ingresados?",
            "Confirmar",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question
        );

        if (respuesta == DialogResult.Yes)
        {
            LimpiarOrden();
        }
    }

    // Vacia los datos cargados de la orden. Por ahora es solo presentacion: la pantalla
    // todavia no guarda ordenes en la base (no hay DAO ni procedures para OrdenReparacion),
    // asi que limpiar no toca ninguna tabla.
    private void LimpiarOrden()
    {
        txtFallaDeclarada.Clear();
        txtPatronClave.Clear();
        txtDiagnosticoTecnico.Clear();

        cmbRepuesto.SelectedIndex = -1;
        txtPrecio.Clear();
        numCantidadRepuesto.Value = 0;
        dgvRepuestos.Rows.Clear();

        txtManoObra.Clear();
        txtToalPresupuesto.Text = "$0,00";

        cmbCliente.SelectedIndex = -1;
        cmbEquipo.SelectedIndex = -1;
        cmbTecnico.SelectedIndex = -1;
        cmbEstado.SelectedIndex = -1;
        txtRecepcion.Clear();
    }
}