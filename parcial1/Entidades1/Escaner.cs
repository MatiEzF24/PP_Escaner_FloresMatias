using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Entidades.Documento;

namespace Entidades
{
    public class Escaner
    {
        List<Documento> listaDocumentos;
        public List<Documento> ListaDocumentos { get => this.listaDocumentos; }
        Departamento locacion;
        public Departamento Locacion { get => this.locacion; }
        string marca;
        public string Marca { get => this.marca; }
        TipoDoc tipo;
        public TipoDoc Tipo { get => this.tipo; }

        public Escaner(string marca, TipoDoc tipo)
        {
            this.tipo = tipo;
            this.marca = marca;
            this.listaDocumentos = new List<Documento>();
            if (tipo == TipoDoc.mapa)
            {
                locacion = Departamento.mapoteca;
            }
            else
            {
                locacion = Departamento.procesosTecnicos;
            }

        }

        public bool CambiarEstadoDocumento(Documento d)
        {
            return d.AvanzarEstado();
        }

        public static bool operator ==(Escaner e, Documento d)
        {
            bool retorno = false;
            if (e.tipo == TipoDoc.mapa && d is Mapa map)
            {
                foreach (Documento doc in e.listaDocumentos)
                {
                    if (map == (Mapa)doc)
                    {
                        retorno = true;
                    }
                }
            }
            else if (e.tipo == TipoDoc.libro && d is Libro lib)
            {
                foreach (Documento doc in e.listaDocumentos)
                {
                    if (lib == (Libro)doc)
                    {
                        retorno = true;
                    }
                }
            }
            return retorno;
        }

        public static bool operator +(Escaner escaner, Documento documento)
        {
            bool retorno = false;
            if ((documento.GetType() == typeof(Libro) && escaner.Tipo == TipoDoc.libro) || (documento.GetType() == typeof(Mapa) && escaner.Tipo == TipoDoc.mapa))
            {

                if (documento.Estado == Paso.Inicio && escaner != documento)
                {
                    if (escaner.tipo == TipoDoc.mapa)
                    {
                        escaner.listaDocumentos.Add(documento);
                        retorno = true;
                    }
                    else
                    {
                        escaner.listaDocumentos.Add(documento);
                        retorno = true;
                    }

                }
            }
            return retorno;
        }
        public static bool operator !=(Escaner e, Documento d) { return !(e == d); }

        public enum Departamento
        {
            nulo,
            mapoteca,
            procesosTecnicos

        }

        public enum TipoDoc
        {
            libro,
            mapa

        }

    }
}
