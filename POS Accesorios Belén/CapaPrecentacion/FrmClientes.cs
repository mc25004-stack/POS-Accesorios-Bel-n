using POS_Accesorios_Belén.CapaEntidades;
using POS_Accesorios_Belén.CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS_Accesorios_Belén.CapaPrecentacion
{
    public partial class FrmClientes : Form
    {
        private int idCliente;

        public FrmClientes()
        {
            InitializeComponent();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                Clientes c = new Clientes()
                {
                    Id = idCliente,//si es 0, es nuevo registro
                    Nombre = txtNombre.Text.Trim(),
                    Dui = txtDui.Text.Trim(),
                    Telefono = txtTelefono.Text.Trim(),
                    Correo = txtCorreo.Text.Trim(),
                    Estado = chkEstado.Checked
                };

                //llamamos al metodo guardar de la bll
                int id = bll.Guardar(c);
                MessageBox.Show("El Cliente se ha Guardado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarDatos();
                Limpiar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmClientes_Load(object sender, EventArgs e)
        {
            //variable para almacenar el id del ciente a modificar o eliminar
            int idCliente = 0;
            //creamos un objeto en la clase ClienteBLL para poder acceder a sus metodos
            ClienteBLL bll = new ClienteBLL();
        }
        public FrmClientes()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void FrmCliente2_Load(object sender, EventArgs e)
        {
            CargarDatos();
            Limpiar();
        }
        void CargarDatos()
        {
            dgvClientes.DataSource = bll.Listar();
        }
        void Limpiar()
        {
            idCliente = 0;
            txtNombre.Clear();
            txtDui.Clear();
            txtTelefono.Clear();
            txtCorreo.Clear();
            chkEstado.Checked = true;
            txtNombre.Focus();

        }
    }
}
