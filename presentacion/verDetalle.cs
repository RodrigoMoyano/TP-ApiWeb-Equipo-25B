using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace presentacion
{
    public partial class VerDetalle : Form
    {
        private Articulo articuloSeleccionado;
        public VerDetalle(Articulo seleccionado)
        {
            InitializeComponent();

            articuloSeleccionado = seleccionado;

            lblVerCodigo.Text = seleccionado.Codigo;
            lblVerNombre.Text = seleccionado.Nombre;
            lblVerDescripcion.Text = seleccionado.Descripcion;
            lblVerPrecio.Text = seleccionado.Precio.ToString();
            lblVerMarca.Text = seleccionado.Marca.Descripcion;
            lblVerCategoria.Text = seleccionado.Categoria.Descripcion;

        }

        private void VerDetalle_Load(object sender, EventArgs e)
        {
            try
            {
                ImagenNegocio imagenNegocio = new ImagenNegocio();
                List<Imagen> imagenes = imagenNegocio.listar(articuloSeleccionado.Id);

                if (imagenes != null && imagenes.Count > 0)
                    cargarImagen(imagenes[0].ImagenUrl); // muestra la primera imagen
                else
                    cargarImagen(""); // fallback a "not available"
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la imagen: " + ex.Message);
                cargarImagen("");
            }
        }

        private void btnDetallesAceptar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cargarImagen(string url)
        {
            try
            {
                pbxDetallesImagen.Load(url);
            }
            catch
            {
                pbxDetallesImagen.Load("https://commercial.bunn.com/img/image-not-available.png");
            }
        }

    }
}