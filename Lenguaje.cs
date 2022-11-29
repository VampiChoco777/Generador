//Marco Adrián Domínguez Jiménez
using System;
using System.Collections.Generic;
//Requerimiento 1. Construir un metodo para escribir en el archivo Lenguaje.cs identando el codigo
//                 "{" incrementa un tabulador, "}" decrementa un tabulador
//Requerimiento 2. Declarar un atributo "primeraProduccion" de tipo string y actualizarlo con la 
//                 primera produccion de la gramatica
//Requerimiento 3. La primera produccion es publica y el resto es privada
//Requerimiento 4. El constructor Lexico() parametrizado debe validar que 
//                 la extension del archivo a compilar sea .gen
//                 si no es .gen debe lanzar una excepcion
//Requerimiento 5. Resolver la ambiguedad de ST y SNT 
//                 Recorrer linea por linea el archivo gram para extraer el nombre de cada produccion
//Requerimiento 6. Implementar el or y la cerradura epsilon
//Requerimiento 7. Agregar el parentesis izquierdo y derecho escapados en la matriz de transiciones
namespace Generador 
{
    public class Lenguaje : Sintaxis, IDisposable
    {
       
        int tabulador = 0;
        string PrimeraProduccion;
        bool Public_Priv = true;
        List<string> listaSNT;
        
        
        public Lenguaje(string nombre) : base(nombre)
        {
            listaSNT = new List<string>();
            PrimeraProduccion = "";
            //Agregar las demas mamadas que puso Jair aqui

        }
        //Falta agregar otro metodo
        public Lenguaje()
        {
            PrimeraProduccion = "";
        }
        public void Dispose()
        {
            cerrar();
        }
        private bool esSNT(string contenido)
        {
            return listaSNT.Contains(contenido);
            //return true;
        }
        private void agregarSNT()
        {
            //Requerimiento 6. 
           
            
            /*archivo.BaseStream.Seek(posicion-9,SeekOrigin.Begin);*/
            while(archivo.ReadLine() != null){
                //Console.WriteLine(getContenido());
                Console.WriteLine(getContenido());
                listaSNT.Add(getContenido());
                NextToken();   
            }
            //archivo.
            //setPosicion(posicion);
           // archivo.Close();
           // archivo = new StreamReader("c2.gram");
            //archivo.BaseStream.Position = 0;
            //setContenido("");
            //setLinea(1);
            archivo.DiscardBufferedData();
            //archivo.BaseStream.Seek(0,System.IO.SeekOrigin.Begin);
            archivo.BaseStream.Position = archivo.BaseStream.Seek(0,System.IO.SeekOrigin.Begin);
            NextToken();
            //setLinea(1);

        }
        private void Tabulacion(string contenido)
        {
            //Requerimiento 1. 
            if (contenido == "{")
            {
                
                for (int i = 0; i < tabulador; i++)
                {
                    lenguaje.Write("\t");
                }
                tabulador++;
                lenguaje.WriteLine(contenido);
            }
            else if (contenido == "}")
            {
                tabulador--;
                for (int i = 0; i < tabulador; i++)
                {
                    lenguaje.Write("\t");
                }
                
                lenguaje.WriteLine(contenido);
            }
            else
            {
                for (int i = 0; i < tabulador; i++)
                {
                    lenguaje.Write("\t");
                }
                lenguaje.Write(contenido+"\n");
            } 
        }
        private void Programa(string produccionPrincipal)
        {
            tabulador = 0;
            //int linea_1 = getLinea();
            //int posicion_1 = getPosicion();
            //agregarSNT("Programas");
            //agregarSNT("Librerias");
            //agregarSNT("Variables");
            //agregarSNT("ListaIdentificadores",linea_1,posicion_1);
            /*agregarSNT("Programas",linea_1,posicion_1);
            agregarSNT("Librerias",linea_1,posicion_1);
            agregarSNT("Variables",linea_1,posicion_1);
            agregarSNT("ListaIdentificadores",linea_1,posicion_1);*/
            
            Tabulacion("using System;");
            Tabulacion("using System.IO;");
            Tabulacion("using System.Collections.Generic;");
            Tabulacion("");
            Tabulacion("namespace Generico");
            tabulador = 0;
            Tabulacion("{");
            Tabulacion("public class Program");
            //tabulador = 0;
            Tabulacion("{");
            Tabulacion("static void Main(string[] args)");
            Tabulacion("{");
            Tabulacion("try");
            Tabulacion("{");
            Tabulacion("using (Lenguaje a = new Lenguaje())");
            Tabulacion("{");
            Tabulacion("a." + produccionPrincipal + "();");
            Tabulacion("}");
            Tabulacion("}");
            Tabulacion("catch (Exception e)");
            Tabulacion("{");
            Tabulacion("Console.WriteLine(e.Message);");
            Tabulacion("}");
            Tabulacion("}");
            Tabulacion("}");
            Tabulacion("}");
        }
        public void gramatica()
        {
            //tabulador = 2;
            agregarSNT();
            //Console.WriteLine(getContenido());
            cabecera();
            
            PrimeraProduccion = getContenido();
            
            Programa(PrimeraProduccion);
            cabeceraLenguaje();
            listaProducciones();
            Tabulacion("}");
            Tabulacion("}");
        }
        private void cabecera()
        {
            match("Gramatica");
            match(":");
            match(Tipos.ST);
            match(Tipos.FinProduccion);
        }
        private void cabeceraLenguaje()
        {
            //int linea_1 = getLinea();
            tabulador = 0;
            Tabulacion("using System;");
            Tabulacion("using System.Collections.Generic;");
            Tabulacion("namespace Generico");
            Tabulacion("{");
            Tabulacion("public class Lenguaje : Sintaxis, IDisposable");
            Tabulacion("{");
            Tabulacion("public Lenguaje(string nombre) : base(nombre)");
            Tabulacion("{");
            Tabulacion("}");
            Tabulacion("public Lenguaje()");
            Tabulacion("{");
            Tabulacion("}");
            Tabulacion("public void Dispose()");
            Tabulacion("{");
            Tabulacion("cerrar();");
            Tabulacion("}");

        }
        private void listaProducciones()
        {
            //tabulador = 1;
            if(Public_Priv ==true)
            {
                Tabulacion("public void " + getContenido() + "()");
                Public_Priv = false;
            }
            else
            {
                Tabulacion("private void " + getContenido() + "()");
            }
            //tabulador = 1;
            Tabulacion("{");
            match(Tipos.ST);
            match(Tipos.Produce);
            simbolos();
            match(Tipos.FinProduccion);
            //tabulador = 2;
            Tabulacion("}");
            if (!FinArchivo())
            {
                listaProducciones();
            }

        }
        private void simbolos()
        {
            if(getContenido() == "\\(")
            {
                match("\\(");
                if(esTipo(getContenido()))
                {
                    Tabulacion("if(getClasificacion() == Tipos."+ getContenido() + ")");
                }
                else
                {
                    Tabulacion("if(getContenido() == \"" + getContenido() + "\")");
                }
                
                Tabulacion("{");
                simbolos();
                match("\\)");
                Tabulacion("}");
                
            }
            else if(esTipo(getContenido()))
            {
                Tabulacion("match(Tipos." + getContenido() + ");");
                match(Tipos.ST);
            }
            else if(esSNT(getContenido()))
            {
                Tabulacion(getContenido() + "();");
                match(Tipos.ST);
            }
            else if(getClasificacion() == Tipos.ST)
            {
                Tabulacion("match(\"" + getContenido() + "\");");
                match(Tipos.ST);
            }
            
            
            if (getClasificacion() != Tipos.FinProduccion && getContenido() != "\\)")
            {
                simbolos();
            }
            
        }
        private bool esTipo(string clasificacion)
        {
            switch (clasificacion)
            {
                case "Identificador":
                case "Numero":
                case "Caracter":
                case "Asignacion":
                case "Inicializacion":
                case "OperadorLogico":
                case "OperadorRelacional":
                case "OperadorTernario":
                case "OperadorTermino":
                case "OperadorFactor":
                case "IncrementoTermino":
                case "IncrementoFactor":
                case "FinSentencia":
                case "Cadena":
                case "TipoDato":
                case "Zona":
                case "Condicion":
                case "Ciclo":
                    return true;
            }
            return false;
        }
        
    }
}