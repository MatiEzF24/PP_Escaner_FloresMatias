using System.ComponentModel.Design;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Entidades
{
    abstract public class Documento
    {
        int anio;
        public int Anio { get => this.anio; }
        string barcode;
        public string Barcode { get => this.barcode; }
        string autor;
        public string Autor { get => this.autor; }
        Paso estado = Paso.Inicio;
        public Paso Estado { get => this.estado; }
        protected string numNormalizado;
        public string NumNormalizado { get => this.numNormalizado; }
        string titulo;
        public string Titulo { get => this.titulo; }

        public Documento(string titulo, string autor, int anio, string barcode, string numNormalizado)
        {
            this.anio = anio;
            this.barcode = barcode;
            this.autor = autor;
            this.numNormalizado = numNormalizado;
            this.titulo = titulo;
        }

        string ToString()
        {
            StringBuilder informe = new StringBuilder();
            informe.Append("Titulo: " + this.titulo.ToString() + "\n");
            informe.Append("Autor: " + this.autor.ToString() + "\n");
            informe.Append("Año: " + this.anio.ToString() + "\n");

            return informe.ToString();
        }

        public bool AvanzarEstado()
        {
            if (this.estado != Paso.Terminado)
            {
                this.estado++;
                return true;
            }
            else
            {
                return false;
            }
        }

        public enum Paso
        {
            Inicio,
            Distribuido,
            EnEscaner,
            EnRevision,
            Terminado
        }


    }
}
