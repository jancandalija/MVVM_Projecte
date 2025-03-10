using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMarcane2.model;

namespace MVVMarcane2.viewmodel
{
	internal class FiltresVM : utilities.ViewModelBase
	{
		public static int MODE_OBTENIR_TOT = -1;

		// TODO: S'ha de fer el mateix a Filtres, però utilitzar un filtre temporal, per no perdre l'actual seleccionat o bé substituir i adaptar tots els checks pel del filtre fav

		private const string ID_FILTRE = "idFiltre";
		private const string ID_USUARI = "idUsuari";
		private const string NOM_FILTRE = "nom";
		private const string FILTRE_SQL = "fSQL";

		private DataBaseConnectionMySQL db;
		private Filtres filtre;
		private List<Filtres> filtresList;

		public int IdFiltre
		{
			get { return filtre.IdFiltre; }
			set { filtre.IdFiltre = value; OnProperyChanged(); }
		}

		public int IdUsuari
		{
			get { return filtre.IdUsuari; }
			set { filtre.IdUsuari = value; OnProperyChanged(); }
		}

		public string Nom
		{
			get { return filtre.Nom; }
			set { filtre.Nom = value; OnProperyChanged(); }
		}

		public string FiltreSQL
		{
			get { return filtre.FiltreSQL; }
			set { filtre.FiltreSQL= value; OnProperyChanged(); }
		}

		public FiltresVM(int idFiltre)
		{
			filtre = new Filtres();

			IdFiltre = 0;
			IdUsuari = 0;
			Nom = "";
			FiltreSQL = "";

			if (idFiltre > 0)
			{
				// Estic buscant 1 objecte

				db = new DataBaseConnectionMySQL();

				db.useSql(sqlGetById());
				db.addWithValue("@" + ID_FILTRE, idFiltre);
				db.fill();

				IdFiltre = (int)db.getPrimerResultat(ID_FILTRE);
				IdUsuari = (int)db.getPrimerResultat(ID_USUARI);
				Nom = (string)db.getPrimerResultat(NOM_FILTRE);
				FiltreSQL = (string)db.getPrimerResultat(FILTRE_SQL);
			} 
			else
			{
				// Estic buscant tots els objectes

				db = new DataBaseConnectionMySQL();

				filtresList = new List<Filtres>();

				db.useSql(sqlGetAll());
				db.fill();

				foreach (DataRow row in db.getData().Rows)
				{
					Filtres filtre = new Filtres
					{
						IdFiltre = (int)row["idFiltre"],
						IdUsuari = (int)row["idUsuari"],
						Nom = (string)row["nom"],
						FiltreSQL = (string)row["fSQL"],
					};
					filtresList.Add(filtre);
				}
			}
		}

		public void insert(string nom, string sqlFiltre)
		{
			db = new DataBaseConnectionMySQL();
			db.useSql(sqlInsert());
			db.addWithValue("@" + ID_USUARI, UserConfig.ID_USUARI);
			db.addWithValue("@" + NOM_FILTRE, nom);
			db.addWithValue("@" + FILTRE_SQL, sqlFiltre);
			db.exec();
		}

		private string sqlGetById()
		{
			return "SELECT * FROM Filtres WHERE idFiltre=@" + ID_FILTRE;
		}

		private string sqlGetAll()
		{
			return "SELECT * FROM Filtres WHERE " + ID_USUARI + "=" + UserConfig.ID_USUARI;
		}

		private string sqlInsert()
		{
			return "INSERT INTO Filtres (" +
				ID_USUARI + ", " +
				NOM_FILTRE + ", " +
				FILTRE_SQL +
				") VALUES (" +
				ID_USUARI + "=" + "@" + ID_USUARI + ", " +
				NOM_FILTRE + "=" + "@" + NOM_FILTRE + ", " +
				FILTRE_SQL + "=" + "@" + FILTRE_SQL + ", " +
				")";
		}

		internal List<Filtres> getFiltresList()
		{
			return filtresList;
		}
	}
}
