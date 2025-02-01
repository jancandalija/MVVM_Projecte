using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMarcane2.model
{
    internal class Usuari
    {
        private int usuariId;
        private string usuariNom;
        private string usuariPwd;

        public int UsuariId { get { return usuariId; } set { usuariId = value; } }
        public string UsuariNom { get { return usuariNom; } set { usuariNom = value; } }
        public string UsuariPwd { get { return usuariPwd; } set { usuariPwd = value; } }
    }
}
