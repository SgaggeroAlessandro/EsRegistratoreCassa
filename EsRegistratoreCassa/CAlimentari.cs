using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsRegistratoreCassa
{
    public class CAlimentari : CArticolo
    {
        private int annoscadenza;

        protected int AnnoScadenza
        {
            get => annoscadenza;
            set
            {
                if (value < DateTime.Now.Year)
                    throw new ArgumentException("L'anno di scadenza inserito  è già passato");
                annoscadenza = value;
            }
        }

        public CAlimentari(long CodiceBarre, string Descrizione, double Prezzo, int AnnoScadenza) : base(CodiceBarre, Descrizione, Prezzo)
        {
            this.AnnoScadenza = AnnoScadenza;
        }

        public override string StampaInfo()
        {
            return base.StampaInfo() + $"Anno di scadenza: {AnnoScadenza}";
        }

        public override void sconta()
        {
            if (AnnoScadenza == DateTime.Now.Year)
            {
                Prezzo *= 0.80; 
            }
            else
            {
                base.sconta(); 
            }
        }
    }
}
