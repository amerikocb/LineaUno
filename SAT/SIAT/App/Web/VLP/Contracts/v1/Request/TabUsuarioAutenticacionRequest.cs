using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using VLP.ConfigureServices.NeedfulClasses.AutoMapper.Interfaces;

namespace VLP.Contracts.v1.Request
{
    public class TabUsuarioAutenticacionRequest
    {
        public string IdUsuario { get; set; }
        public string Contrasena { get; set; }
    }
}
