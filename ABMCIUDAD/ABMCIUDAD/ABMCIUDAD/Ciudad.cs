using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABMCIUDAD
{
	public class Ciudad
	{
		public int Id { get; set; }
		public string Nombre { get; set; }

		public List<Hotel> listahoteles { get; set; }
		public List<Vuelo> listavuelos { get; set; }

		public Ciudad(int id, string nombre)
		{
			Id = id;
			Nombre = nombre;

			listahoteles = new List<Hotel>();

			listavuelos = new List<Vuelo>();
		}
	}
}
