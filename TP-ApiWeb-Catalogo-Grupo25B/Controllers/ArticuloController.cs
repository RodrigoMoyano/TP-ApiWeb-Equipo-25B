using negocio;
using dominio;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TP_ApiWeb_Catalogo_Grupo25B.Models;
using System.Runtime.Remoting.Messaging;
using System.Web;

namespace TP_ApiWeb_Catalogo_Grupo25B.Controllers
{
    public class ArticuloController : ApiController
    {
        // GET: api/Articulo
        public HttpResponseMessage Get()
        {
            try
            {   
                ArticuloNegocio negocio = new ArticuloNegocio();
                List<Articulo> lista = negocio.listar();

                return Request.CreateResponse(HttpStatusCode.OK, lista);
            }
            catch (Exception ex)
            {

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        // GET: api/Articulo/5
        public HttpResponseMessage Get(int id)
        {
            try
            {
                ArticuloNegocio negocio = new ArticuloNegocio();
                List<Articulo> lista = negocio.listar();

                if(lista == null || lista.Count == 0)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No se encontro articulos");
                }

                Articulo hayArticulo = lista.Find(x => x.Id == id);

                if(hayArticulo == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Id de articulo incorrecto");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK, hayArticulo);
                }

            }
            catch (Exception)
            {

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Error de servidor");
            }
        }
        // POST: api/Articulo
        [HttpPost]
        [Route("api/articulo")]
        public HttpResponseMessage Post([FromBody] ArticuloDto art)
        {
            var negocio = new ArticuloNegocio();
            var categoriaNegocio = new CategoriaNegocio();
            var marcaNegocio = new MarcaNegocio();

            Categoria categoria = categoriaNegocio.listar().Find(x => x.Id == art.IdCategoria);
            Marca marca = marcaNegocio.listar().Find(x => x.Id == art.IdMarca);

            if (categoria == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "La categoria ingresada no existe.");
            }

            if (marca == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "La marca ingresada no existe.");
            }

            var nuevo = new Articulo
            {
                Codigo = art.Codigo,
                Nombre = art.Nombre,
                Descripcion = art.Descripcion,
                Marca = marca,
                Categoria = categoria,
                Precio = art.Precio
            };
            negocio.agregar(nuevo);
            return Request.CreateResponse(HttpStatusCode.OK, "Articulo agregado correctamente.");
        }

        // POST: api/Imagen
        [HttpPost]
        [Route("api/articulo/imagen")]
        public HttpResponseMessage PostImagen([FromBody] ImagenDto imagenDto)
        {
            if (imagenDto == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Campos vacíos.");

            if (string.IsNullOrWhiteSpace(imagenDto.ImagenUrl))
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Ingresar URL de Imagen.");

            var articuloNegocio = new ArticuloNegocio();
            var articulo = articuloNegocio.listar().FirstOrDefault(a => a.Id == imagenDto.IdArt);

            if (articulo == null)
                return Request.CreateResponse(HttpStatusCode.NotFound, "El artículo es inexistente.");

            try
            {
                var imagenNegocio = new ImagenNegocio();

                Imagen nueva = new Imagen
                {
                    IdArticulo = articulo,
                    ImagenUrl = imagenDto.ImagenUrl
                };

                imagenNegocio.agregar(nueva);

                var response = new
                {
                    mensaje = "Imagen agregada con exito.",
                    articuloId = imagenDto.IdArt,
                    imagenUrl = imagenDto.ImagenUrl
                };

                return Request.CreateResponse(HttpStatusCode.Created, response);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        // PUT: api/Articulo/5
        [HttpPut]
        public HttpResponseMessage Put(int id, [FromBody] ArticuloDto art)
        {
            if (art == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Campos vacios.");

            if (string.IsNullOrWhiteSpace(art.Nombre))
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Ingrese el nombre.");

            try
            {
                var negocio = new ArticuloNegocio();
                var articulos = negocio.listar();

                var existente = articulos.FirstOrDefault(a => a.Id == id);
                if (existente == null)
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Artículo no encontrado.");

                Articulo nuevo = new Articulo
                {
                    Id = id,
                    Codigo = art.Codigo,
                    Nombre = art.Nombre,
                    Descripcion = art.Descripcion,
                    Marca = new Marca { Id = art.IdMarca },
                    Categoria = new Categoria { Id = art.IdCategoria },
                    Precio = art.Precio
                };

                negocio.modificar(nuevo);

                var response = new
                {
                    mensaje = "Artículo modificado correctamente.",
                };

                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }



        // DELETE: api/Articulo/5
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                ArticuloNegocio negocio = new ArticuloNegocio();

                if(!negocio.listar().Any(a => a.Id == id))
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Articulo inexistente");
                }

                negocio.eliminar(id);

                return Request.CreateResponse(HttpStatusCode.OK, "Articulo eliminado correctamente");
            }
            catch (Exception ex)
            {

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
