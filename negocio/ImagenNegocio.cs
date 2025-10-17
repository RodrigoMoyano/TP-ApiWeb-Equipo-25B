using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using dominio;
using negocio;

namespace negocio
{
    public class ImagenNegocio
    {
        public List<Imagen> listar(int idArticulo)
        {
            List<Imagen> lista = new List<Imagen>();
            AccesoDatos datos = new AccesoDatos();

            try 
         {
                datos.setearConsulta("Select Id, IdArticulo, ImagenUrl From Imagenes Where IdArticulo = @IdArticulo");
                datos.setearParametro("@idArticulo", idArticulo);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Imagen aux = new Imagen();
                    aux.Id = (int)datos.Lector["Id"];

                    aux.IdArticulo = new Articulo();
                    aux.IdArticulo.Id = (int)datos.Lector["IdArticulo"]
                    ;
                    aux.ImagenUrl = (string)datos.Lector["ImagenUrl"];

                    lista.Add(aux);
                }

                return lista;
	        }
	        catch (Exception ex)
	        {

		        throw ex;
	        }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void agregar(Imagen nueva)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("INSERT INTO Imagenes (IdArticulo, ImagenUrl) VALUES (@idArticulo, @imagenUrl)");
                datos.setearParametro("@idArticulo", nueva.IdArticulo.Id);
                datos.setearParametro("@imagenUrl", nueva.ImagenUrl);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }



    }
}
