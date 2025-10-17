using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TP_ApiWeb_Catalogo_Grupo25B.Models
{
    public class ImagenDto
    {
        public int Id { get; set; }
        public int IdArt { get; set; }
        public string ImagenUrl { get; set; }
    }
}