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
        private List<CScontrino>[] ScontriniperMese = new List<CScontrino>[13];
        private List<CScontrino>[] ScontriniperSettimna = new List<CScontrino>[53];
        private int numeroScontrino;
        private DateTime dataCorrente;

        protected int NumeroScontrino
        {
            get
            {
                return numeroScontrino;
            }
            set
            {
                numeroScontrino = value;
            }
        }
        protected DateTime DataCorrente
        {
            get
            {
                return dataCorrente;
            }
            set
            {
                dataCorrente = value;
            }
        }
        
        public CRegistratore()
        {
            for(int i = 0; i < ScontriniperMese.Length; i++)
            {
                ScontriniperMese[i] = new List<CScontrino>();
            }
            for(int i = 0; i < ScontriniperSettimna.Length; i++)
            {
                ScontriniperSettimna[i] = new List<CScontrino>();
            }
            this.NumeroScontrino = 0;
            this.DataCorrente = DateTime.Now.Date; 
        }

        public void EmettiScontrino(double importo, int mese, int settimana)
        {
            
            if (DataCorrente != DateTime.Now.Date)
            {
                NumeroScontrino = 0;
                DataCorrente = DateTime.Now.Date;
            }
            NumeroScontrino++;
            CScontrino scontrino = new CScontrino(NumeroScontrino);
            scontrino.EmettiScontrino(importo, DataCorrente);
            Cassa.Add(scontrino);

            ScontriniperMese[mese].Add(scontrino);
            ScontriniperSettimna[settimana].Add(scontrino);

        }
        public void CancellaScontrino()
        {
            if(Cassa.Count == 0)
            {
                Console.WriteLine("Non ci sono scontrini salvati nel registratore di cassa, impossibile eliminare uno scontrino");
            }
            else
            {
                CScontrino ultimoscontrino = Cassa[Cassa.Count  - 1];
                
                Cassa.Remove(ultimoscontrino);
                foreach(var lista in ScontriniperSettimna)
                {
                    lista.Remove(ultimoscontrino);
                }

                foreach(var lista in ScontriniperMese)
                {
                    lista.Remove(ultimoscontrino);
                }
                numeroScontrino--;
            }
            
        }
        public void MostraListaScontrini()
        {
            foreach(CScontrino scontrino in Cassa)
            {
                Console.WriteLine(scontrino.Info());
            }
        }

        public void MostraScontriniDelMese(int mese)
        {
            foreach (CScontrino scontrino in ScontriniperMese[mese])
            {
                Console.WriteLine(scontrino.Info());
            }
        }

        public void MostraScontriniDellaSettimana(int settimana)
        {
            foreach (CScontrino scontrino in ScontriniperSettimna[settimana])
            {
                Console.WriteLine(scontrino.Info());
            }
        }
    }
}
