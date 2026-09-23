using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsRegistratoreCassa
{
    public class CArticolo
    {
        private long codicebarre;
        private string descrizione;
        private double  prezzo;

        public long CodiceBarre
        {
            get => codicebarre;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Il codice a barre non può essere negativo");
                codicebarre = value;
            }
        }

        public string Descrizione
        {
            get => descrizione;
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Scrivi una descrizione valida dell'articolo");
                descrizione = value;
            }
        }

        public double  Prezzo
        {
            get => prezzo;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Il prezzo deve essere maggiore di 0€");
                prezzo = value;
            }
        }

        public CArticolo(long CodiceBarre, string Descrizione, double  Prezzo)
        {
            this.CodiceBarre = CodiceBarre;
            this.Descrizione = Descrizione;
            this.Prezzo = Prezzo;
        }

        public virtual string StampaInfo()
        {
            return $"Codice a barre del prodotto: {CodiceBarre}\n Descrizione del prodotto: {Descrizione}  \n Prezzo: {Prezzo}\n";
        }
        public virtual void  sconta()
        {
            
             Prezzo *= 0.95;
        }
    }
}
