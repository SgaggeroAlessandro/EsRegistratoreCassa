using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsRegistratoreCassa
{
    public class CClienti
    {
        private List<CScontrino> storico = new List<CScontrino>();

        private string nome;

        public bool TesseraFedeltà { get; set; }

        public string Nome
        {
            get => nome;
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Inserisci un nome appropriato");
                nome = value;
            }
        }

        public CClienti(string Nome, bool TesseraFedeltà)
        {
            this.Nome = Nome;
            this.TesseraFedeltà = TesseraFedeltà;
        }

        public string InfoCliente()
        {
            string tessera = "";
            if(TesseraFedeltà == true)
            {
                tessera = "Sì";
            }
            else
            {
                tessera = "No";
            }
            return $"Nome del cliente: {Nome} \n Dispone della carta fedeltà: {tessera}";
        }

        public bool HaComprato(long codiceBarre)
        {
            foreach (CScontrino scontrino in storico)
            {
                foreach(CArticolo articolo in scontrino.Articoli)
                {
                    if(articolo.CodiceBarre == codiceBarre)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public void AggiungiAcquisto(CScontrino scontrino)
        {
            storico.Add(scontrino);
        }
    }
}
