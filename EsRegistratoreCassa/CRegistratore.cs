using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsRegistratoreCassa
{
    public class CRegistratore
    {
        private List<CScontrino> Cassa = new List<CScontrino>();
        
        
        
        public CRegistratore()
        {
            
        }

        public CScontrino EmettiScontrino(CClienti cliente, List<CArticolo> articoli)
        {
            DateTime oggi = DateTime.Now.Date;
            int scontrini = 1;

            foreach(CScontrino s in Cassa)
            {
                if(s.Data == oggi)
                {
                    scontrini++;
                }
            }
            CScontrino scontrino = new CScontrino(cliente, oggi, scontrini, articoli);
            Cassa.Add(scontrino);
            cliente.AggiungiAcquisto(scontrino);

            return scontrino;
        }
        public void CancellaScontrino()
        {
            if(Cassa.Count == 0)
            {
                Console.WriteLine("Non ci sono scontrini salvati nel registratore di cassa, impossibile eliminare uno scontrino");
            }
            else
            {
                Cassa.RemoveAt(Cassa.Count - 1);
            }
            
        }
        public List<CScontrino> MostraListaScontrini()
        {
            List<CScontrino> risultato = new List<CScontrino>();
            DateTime oggi = DateTime.Now.Date;
            foreach(CScontrino s in Cassa)
            {
                if(s.Data == oggi)
                {
                    risultato.Add(s);
                }
            }
            return risultato;
        }

        public List<CScontrino> MostraScontriniDelMese(int mese)
        {
            List<CScontrino> raccolta = new List<CScontrino>();

            foreach (CScontrino scontrino in Cassa)
            {
                if(scontrino.Data.Month == mese)
                {
                    raccolta.Add(scontrino);
                }
            }

            return raccolta;
        }

        private int CalcoloSettimana(DateTime data)
        {
            return (data.Day - 1) / 7 + 1;
        }

        public List<CScontrino> MostraScontriniDellaSettimana(int mese, int settimana)
        {
            List<CScontrino> raccolta = new List<CScontrino>();


            foreach (CScontrino scontrino in Cassa)
            {
                if(scontrino.Data.Month == mese && CalcoloSettimana(scontrino.Data) == settimana)
                {
                    raccolta.Add(scontrino);
                }
            }

            return raccolta;
        }
    }
}
