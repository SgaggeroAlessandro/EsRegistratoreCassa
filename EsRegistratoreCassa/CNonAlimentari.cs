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
        public string Materiale
        {
            get => materiale;
            set
            {
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
            if (mat == MaterialiRiciclabili.vetro.ToString() || mat == MaterialiRiciclabili.carta.ToString() || mat == MaterialiRiciclabili.plastica.ToString())
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
