using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Informes
    {
        private static void MostrarDocumentosPorEstado(Escaner e, Documento.Paso estado, out int extension, out int cantidad, out string resumen)
        {
            extension = 0;
            cantidad = 0;
            resumen = "";
            StringBuilder texto = new StringBuilder();

            foreach (Documento doc in e.ListaDocumentos)
            {
                if (doc.Estado == estado)
                {
                    if (doc is Mapa mapa)
                    {
                        extension += mapa.Superficie;
                        cantidad++;
                        texto.Append(mapa.ToString());
                    }
                    else if (doc is Libro libro)
                    {
                        extension += libro.NumPaginas;
                        cantidad++;
                        texto.Append(libro.ToString());
                    }
                }

            }
        }

        public static void MostrarDistribuidos(Escaner e, out int extencion, out int cantidad, out string resumen)
        {
            MostrarDocumentosPorEstado(e, Documento.Paso.Distribuido, out extencion, out cantidad, out resumen);
        }

        public static void MostrarEnEscaner(Escaner e, out int extencion, out int cantidad, out string resumen)
        {
            MostrarDocumentosPorEstado(e, Documento.Paso.EnEscaner, out extencion, out cantidad, out resumen);
        }

        public static void MostrarEnRevision(Escaner e, out int extencion, out int cantidad, out string resumen)
        {
            MostrarDocumentosPorEstado(e, Documento.Paso.EnRevision, out extencion, out cantidad, out resumen);
        }

        public static void MostrarTerminados(Escaner e, out int extencion, out int cantidad, out string resumen)
        {
            MostrarDocumentosPorEstado(e, Documento.Paso.Terminado, out extencion, out cantidad, out resumen);
        }
    }
}
