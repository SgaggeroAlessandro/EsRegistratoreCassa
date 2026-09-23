using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsRegistratoreCassa
{
    public class CClienti
    {
        public List<CArticolo> storico = new List<CArticolo>();

        private string nome;

        public bool TesseraFedeltà { get; set; }

        protected string Nome
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
            foreach (CArticolo art in storico)
            {
                if (art.CodiceBarre == codiceBarre)
                    return true;
            }
            return false;
        }
    }
}
