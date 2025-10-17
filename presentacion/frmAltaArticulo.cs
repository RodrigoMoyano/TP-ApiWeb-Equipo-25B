using dominio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using negocio;
using static System.Net.Mime.MediaTypeNames;
using System.Configuration;
using System.IO;


namespace presentacion
{
    public partial class frmAltaArticulo : Form

    {
        private Articulo articulos = null;
        private OpenFileDialog archivo = null;


        public frmAltaArticulo()
        {
            InitializeComponent();
        }

        public frmAltaArticulo(Articulo articulos)
        {
            InitializeComponent();
            this.articulos = articulos;
            Text = "Modificar Articulo";
        }




        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {


            ArticuloNegocio negocio = new ArticuloNegocio();



            try
            {
                if (articulos == null)
                    articulos = new Articulo();

                articulos.Codigo = txtCodigo.Text;
                articulos.Nombre = txtNombre.Text;
                articulos.Descripcion = txtDescripcion.Text;
                articulos.Precio = decimal.Parse(txtPrecio.Text);
                articulos.Categoria = (Categoria)cboCategoria.SelectedItem;
                articulos.Marca = (Marca)cboMarca.SelectedItem;

                if (articulos.Id != 0)
                {
                    negocio.modificar(articulos);
                    MessageBox.Show("Modificado exitosamente");

                }
                else
                {
                    negocio.agregar(articulos);
                    MessageBox.Show("Agregado exitosamente");

                }



                Close();



            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void frmAltaArticulos_Load(object sender, EventArgs e)
        {
            MarcaNegocio marcasNegocio = new MarcaNegocio();
            cboMarca.ValueMember = "Id";
            cboMarca.DisplayMember = "Descripcion";
            CategoriaNegocio categoriasNegocio = new CategoriaNegocio();
            cboCategoria.ValueMember = "Id";
            cboCategoria.DisplayMember = "Descripcion";



            try
            {
                cboCategoria.DataSource = categoriasNegocio.listar();


                cboMarca.DataSource = marcasNegocio.listar();



                if (articulos != null)
                {
                    txtCodigo.Text = articulos.Codigo;
                    txtNombre.Text = articulos.Nombre;
                    txtDescripcion.Text = articulos.Descripcion;
                    txtPrecio.Text = articulos.Precio.ToString();
                    cboCategoria.SelectedValue = articulos.Categoria.Id;
                    cboMarca.SelectedValue = articulos.Marca.Id;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }

        }

        private void txtUrlImagen_Leave(object sender, EventArgs e)
        {
            cargarImagen(txtUrlImagen.Text);
        }

        private void cargarImagen(string imagen)
        {
            try
            {
                if (!string.IsNullOrEmpty(imagen))
                    pbxArticulo.Load(imagen);
                else
                    pbxArticulo.Load("https://commercial.bunn.com/img/image-not-available.png");
            }
            catch
            {
                pbxArticulo.Load("https://commercial.bunn.com/img/image-not-available.png");
            }
        }



        private void btnAgregarImagen_Click(object sender, EventArgs e)
        {
            archivo = new OpenFileDialog();
            archivo.Filter = "jpg|*.jpg|png|*.png";
            if (archivo.ShowDialog() == DialogResult.OK)
            {
                txtUrlImagen.Text = archivo.FileName;
                cargarImagen(archivo.FileName);


            }
        }
    }
}