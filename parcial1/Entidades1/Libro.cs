using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Libro : Documento
    {
        int numPaginas;
        public int NumPaginas
        {
            get => this.numPaginas;

        }

        public string ISBN
        {
            get => this.numNormalizado;
        }

        public Libro(string titulo, string autor, int anio, string barcode, string numNormalizado, int numeroPaginas)
            : base(titulo, autor, anio, barcode, numNormalizado)
        {
            this.numPaginas = numeroPaginas;
        }

        public override string ToString()
        {
            StringBuilder informe = new StringBuilder();
            informe.Append(base.ToString());
            informe.Append("ISBN: " + this.numNormalizado.ToString() + "\n");
            informe.Append("Cód. de barras" + this.Barcode.ToString() + "\n");
            informe.Append("Número de páginas: " + this.NumPaginas.ToString() + ".");

            return informe.ToString();
        }

        public static bool operator ==(Libro a, Libro b)
        {
            return a.Barcode == b.Barcode || a.ISBN == b.ISBN || a.Titulo == b.Titulo && a.Autor == b.Autor;
        }
        public static bool operator !=(Libro a, Libro b)
        {
            return !(a == b);
        }
    }
}
