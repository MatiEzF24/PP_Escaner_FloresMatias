using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Mapa : Documento
    {
        int alto;
        public int Alto { get => this.alto; }
        int ancho;
        public int Ancho { get => this.ancho; }

        public int Superficie
        {
            get { return this.alto * this.ancho; }

        }
        public Mapa(string titulo, string autor, int anio, string barcode, string numNormalizado, int alto, int ancho)
            : base(titulo, autor, anio, barcode, numNormalizado)
        {
            this.alto = alto;
            this.ancho = ancho;
        }

        public override string ToString()
        {
            StringBuilder informe = new StringBuilder();
            informe.Append(base.ToString());
            informe.Append("Cód. de barras" + this.Barcode.ToString() + "\n");
            informe.Append("Superficie: " + this.alto.ToString() + " * " + this.ancho.ToString() + " = " + this.Superficie.ToString());
            return informe.ToString();
        }
        public static bool operator ==(Mapa a, Mapa b)
        {
            return ((a.Barcode == b.Barcode) || (a.Titulo == b.Titulo && a.Autor == b.Autor && a.Anio == b.Anio && a.Superficie == b.Superficie));
        }

        public static bool operator !=(Mapa a, Mapa b)
        {
            return !(a == b);
        }

    }
}
