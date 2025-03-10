using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMarcane2.model
{
	public class Filtres
	{
		private int idFiltre;
		private int idUsuari;
		private string nom;
		private string fSQL;

		public int IdFiltre { get { return idFiltre; } set { idFiltre = value; } }
		public int IdUsuari { get { return idUsuari; } set { idUsuari = value; } }
		public string Nom { get { return nom; } set { nom = value; } }
		public string FiltreSQL { get { return fSQL; } set { fSQL = value; } }
	}
}
