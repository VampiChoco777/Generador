using System;
using System.Collections.Generic;
namespace Generico
{
	public class Lenguaje : Sintaxis, IDisposable
	{
		public Lenguaje(string nombre) : base(nombre)
		{
		}
		public Lenguaje()
		{
		}
		public void Dispose()
		{
			cerrar();
		}
		private void Programa()
		{
			match("#");
			match(Tipos.Identificador);
			match(",");
			match(Tipos.Numero);
			Librerias();
		}
		private void Librerias()
		{
			match("#");
			include();
			match("<");
			match(Tipos.Identificador);
			match(".");
			h();
			match(">");
		}
		private void Variables()
		{
			match("(");
			match(")");
		}
		private void ListaIdentificadores()
		{
			match(Tipos.Caracter);
		}
	}
}
