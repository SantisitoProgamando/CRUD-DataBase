using ClientesApp;
using Microsoft.VisualBasic;
using System.ComponentModel;

namespace CRUD_DB
{
    public partial class Form1 : Form
    {
        private readonly RepositorioCliente _repo;
        private Cliente _ClienteSeleccionado;

        private readonly BindingList<Cliente> _clientesPendientes = new();
        public Form1()
        {
            InitializeComponent();
            _repo = new RepositorioCliente();

            dgvPrevClientes.AutoGenerateColumns = true;
            dgvPrevClientes.DataSource = _clientesPendientes;

            CargarClientes();
        }
        private Cliente PrevClienteSeleccionado => dgvPrevClientes.CurrentRow?.DataBoundItem as Cliente;
        private void CargarClientes()
        {
            List<Cliente> clientes = _repo.ObtenerClientes();
            dgvClientes.AutoGenerateColumns = true;
            dgvClientes.DataSource = clientes;
            dgvClientes.ClearSelection();
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                string nombre = Interaction.InputBox("Ingrese nombre", "Nuevo cliente");
                if (String.IsNullOrEmpty(nombre)) { throw new Exception("Ingrese nombre valido"); }
                string apellido = Interaction.InputBox("Ingrese apellido", "Nuevo cliente");
                if (String.IsNullOrEmpty(apellido)) { throw new Exception("Ingrese un apellido valido"); }
                string email = Interaction.InputBox("Ingrese un email", "Nuevo cliente");
                if (string.IsNullOrWhiteSpace(email) && string.IsNullOrEmpty(email))
                { throw new Exception("Ingrese un email valido"); }
                var nuevo = new Cliente
                {
                    Nombre = nombre,
                    Apellido = apellido,
                    Email = email
                };
                _clientesPendientes.Add(nuevo);
            }
            catch (Exception ex) { throw new Exception("Error al agregar cliente" + ex.Message); }
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (_clientesPendientes.Count == 0)
            {
                MessageBox.Show("No hay clientes para agregar a la base de datos");
                return;
            }
            try
            {
                foreach (var cli in _clientesPendientes)
                {
                    _repo.InsertarCliente(cli);
                }
                _clientesPendientes.Clear(); //Limpia el datagridview, ya que la idea es que aparezca uno solo
                CargarClientes();
                MessageBox.Show("Clientes guardados correctamente");
            }
            catch (Exception ex) { throw new Exception("Error al guardar clientes" + ex.Message); }
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(Interaction.InputBox("Ingrese el ID a eliminar"), out int IdEliminar))
                {
                    throw new Exception("Ingrese un ID valido a eliminar");
                }
                _repo.Eliminar(IdEliminar);
                CargarClientes();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        private void btnEliminarSeleccionando_Click(object sender, EventArgs e)
        {

            if (dgvClientes.CurrentCell != null)
            {
                int fila = dgvClientes.CurrentCell.RowIndex;
                int id = Convert.ToInt32(dgvClientes.Rows[fila].Cells[0].Value);
                _repo.Eliminar(id);
                CargarClientes();
            }
        }
        private void btnModificar_Click(object sender, EventArgs e)
        {

        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnEliminarClientePrevio_Click(object sender, EventArgs e)
        {
            var seleccionado = PrevClienteSeleccionado;
            if (seleccionado == null)
            {
                MessageBox.Show("Seleccione un cliente pendiente en la grilla");
                return;
            }
            var confirmado = MessageBox.Show("Seguro que quiere eliminar a este cliente pendiente?",
                "Confirmar eliminacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmado == DialogResult.Yes)
            {
                _clientesPendientes.Remove(seleccionado);
            }
        }
    }
}
