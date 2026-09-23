using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsRegistratoreCassa
{
    public class CNonAlimentari : CArticolo
    {
        public enum MaterialiRiciclabili
        {
            vetro,
            carta,
            plastica
        }

        private string materiale;
        protected string Materiale
        {
            get => materiale;
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Inserisci un materiale valido");
                materiale = value;
            }
        }
        
        public CNonAlimentari(long CodiceBarre, string Descrizione, double Prezzo, string Materiale) : base(CodiceBarre, Descrizione, Prezzo) 
        {
            this.Materiale = Materiale;
        
        }

        public override string StampaInfo()
        {
            return base.StampaInfo() + $"Materiale: {Materiale}";
        }

        public override void sconta()
        {
            string mat = Materiale.ToLower();
            if (mat == "vetro" || mat == "carta" || mat == "plastica")
            {
                Prezzo *= 0.90; 
            }
            else
            {
                base.sconta(); 
            }
        }
    }
}
