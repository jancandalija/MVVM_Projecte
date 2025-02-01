using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMarcane2.model;
using MVVMarcane2.view;

namespace MVVMarcane2.viewmodel
{
    internal class UsuariVM : utilities.ViewModelBase
    {
        private const string USUARI_ID = "usuariId";
        private const string USUARI_NOM = "usuariNom";
        private const string USUARI_PWD = "usuariPwd";

        private DataBaseConnection db;
        private Usuari usuari;

        public int UsuariId
        {
            get { return usuari.UsuariId; }
            set { usuari.UsuariId = value; OnProperyChanged(); }
        }

        public string UsuariNom
        {
            get { return usuari.UsuariNom; }
            set { usuari.UsuariNom = value; OnProperyChanged(); }
        }

        public string UsuariPwd
        {
            get { return usuari.UsuariPwd; }
            set { usuari.UsuariPwd = value; OnProperyChanged(); }
        }

        public UsuariVM(int usuariId)
        {
            usuari = new Usuari();

            UsuariId = 0;
            UsuariNom = "";
            UsuariPwd = "";

            if (usuariId > 0)
            {
                db = new DataBaseConnection();

                db.useSql(sqlGetById());
                db.addWithValue("@" + USUARI_ID, usuariId);
                db.fill();

                UsuariId = (int)db.getPrimerResultat(USUARI_ID);
                UsuariNom = (string)db.getPrimerResultat(USUARI_NOM);
                UsuariId = (int)db.getPrimerResultat(USUARI_ID);
            }
        }

        public UsuariVM(string usuariNom, string usuariPwd)
        {
            usuari = new Usuari();

            UsuariId = 0;
            UsuariNom = "";
            UsuariPwd = "";

            if (usuariNom != null && usuariNom != "" && usuariPwd != null && usuariPwd != "")
            {
                db = new DataBaseConnection();

                db.useSql(sqlGetByNomIPwd());
                db.addWithValue("@" + USUARI_NOM, usuariNom);
                db.addWithValue("@" + USUARI_PWD, usuariPwd);
                db.fill();
                try
                {
                    UsuariId = (int)db.getPrimerResultat(USUARI_ID);
                    UsuariNom = (string)db.getPrimerResultat(USUARI_NOM);
                    UsuariPwd = (string)db.getPrimerResultat(USUARI_PWD);
                }
                catch (Exception e)
                {
                    UsuariId = 0;
                    UsuariNom = "";
                    UsuariPwd = "";
                }
            }
        }

        private string sqlGetById()
        {
            return "SELECT * FROM Usuaris WHERE usuariId=@" + USUARI_ID;
        }

        private string sqlGetByNomIPwd()
        {
            return "SELECT * FROM Usuaris WHERE usuariNom=@" + USUARI_NOM + " AND " + "usuariPwd=@" + USUARI_PWD;
        }
    }
}
