using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dominio;
using negocio;



namespace presentacion
{
    public partial class Form1 : Form
    {
        private List<Articulo> listaArticulos;
        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            cargar();
            cboCampo.Items.Add("Codigo");
            cboCampo.Items.Add("Categoria");
            cboCampo.Items.Add("Precio");
        }



        private void cargar()
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            try
            {
                listaArticulos = negocio.listar();
                dgvArticulo.DataSource = listaArticulos;
                dgvArticulo.DataSource = negocio.listar();
                OcultarColumnas();


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }
        private void OcultarColumnas()
        {
            dgvArticulo.Columns["Id"].Visible = false;
            dgvArticulo.Columns["Descripcion"].Visible = false;
            dgvArticulo.Columns["Marca"].Visible = false;
            if (dgvArticulo.Columns.Contains("ImagenUrl"))
                dgvArticulo.Columns["ImagenUrl"].Visible = false;
        }



        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmAltaArticulo alta = new frmAltaArticulo();
            alta.ShowDialog();
            cargar();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Articulo seleccionado;
            seleccionado = (Articulo)dgvArticulo.CurrentRow.DataBoundItem;

            frmAltaArticulo modificar = new frmAltaArticulo(seleccionado);
            modificar.ShowDialog();
            cargar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            Articulo seleccionado;
            try
            {
                DialogResult respuesta = MessageBox.Show("Seguro queres eliminarlo?", "Eliminando", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (respuesta == DialogResult.Yes)
                {
                    seleccionado = (Articulo)dgvArticulo.CurrentRow.DataBoundItem;
                    negocio.eliminar(seleccionado.Id);
                    cargar();

                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private bool validarFiltro()
        {
            if (cboCampo.SelectedIndex < 0)
            {
                MessageBox.Show("Elija una opcion del Campo.");
                return true;
            }
            if (cboCriterio.SelectedIndex < 0)
            {
                MessageBox.Show("Elija una opcion del Criterio.");
                return true;
            }
            if (cboCampo.SelectedItem.ToString() == "Precio")
            {
                if (string.IsNullOrEmpty(txtFiltroAvanzado.Text))
                {
                    MessageBox.Show("Ingrese numeros en el filtro, por favor.");
                    return true;
                }
                if (!(soloNumeros(txtFiltroAvanzado.Text)))
                {
                    MessageBox.Show("Solo numeros por favor.");
                    return true;
                }
            }

            return false;
        }

        private bool soloNumeros(string cadena)
        {
            foreach (char caracter in cadena)
            {
                if (!(char.IsNumber(caracter)))
                    return false;
            }
            return true;
        }




        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            List<Articulo> listaFiltrada;
            string filtro = txtFiltro.Text;


            if (filtro.Length >= 3)
            {
                listaFiltrada = listaArticulos.FindAll(x => x.Nombre.ToUpper().Contains(filtro.ToUpper()) || x.Marca.Descripcion.ToUpper().Contains(filtro.ToUpper()));

            }
            else
            {
                listaFiltrada = listaArticulos;
            }


            dgvArticulo.DataSource = null;
            dgvArticulo.DataSource = listaFiltrada;
            OcultarColumnas();
        }

        private void cboCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string opcion = cboCampo.SelectedItem.ToString();
            if (opcion == "Precio")
            {

                cboCriterio.Items.Clear();
                cboCriterio.Items.Add("Mayor a");
                cboCriterio.Items.Add("Menor a");
                cboCriterio.Items.Add("Igual a");
            }
            else
            {
                cboCriterio.Items.Clear();
                cboCriterio.Items.Add("Empieza con");
                cboCriterio.Items.Add("Termina con");
                cboCriterio.Items.Add("Contiene");

            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            try
            {
                if (validarFiltro())
                    return;
                string campo = cboCampo.SelectedItem.ToString();
                string criterio = cboCriterio.SelectedItem.ToString();
                string filtro = txtFiltroAvanzado.Text;
                dgvArticulo.DataSource = negocio.filtrar(campo, criterio, filtro);

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }

        }

        private void btnVerDetalles_Click(object sender, EventArgs e)
        {
            if (dgvArticulo.CurrentRow == null)
            {
                MessageBox.Show("Por favor, seleccione un artículo antes de ver el detalle.");
                return;
            }

            Articulo seleccionado = (Articulo)dgvArticulo.CurrentRow.DataBoundItem;

            VerDetalle detalle = new VerDetalle(seleccionado);
            detalle.ShowDialog();

            cargar();
        }


    }
}
