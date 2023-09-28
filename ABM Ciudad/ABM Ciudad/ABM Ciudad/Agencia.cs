using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABM_Ciudad
{
	public class Agencia
	{
		public int id { get; set; }
		public List<Ciudad> listaCiudades {  get; set; }

		public Agencia() {
			//Instancio la lista de ciudades en agencia

		listaCiudades = new List<Ciudad>();
		}

		public List<Ciudad> Ciudades() 
		{
			if (listaCiudades.Count > 0)
			{
				return listaCiudades;
			}
			return null;
		}
	}
}
