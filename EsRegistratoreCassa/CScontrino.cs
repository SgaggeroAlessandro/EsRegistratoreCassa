using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsRegistratoreCassa
{
    public class CScontrino
    {
        
        private DateTime data;
        private int numero;

        private CClienti cliente;
        

        private List<CArticolo> articoli;

        public double Totale
        {
            get
            {
                double tot = 0;
                foreach (CArticolo a in articoli)
                {
                    tot += a.Prezzo;

                }
                return tot;

            }
        }
        public CClienti Cliente
        {
            get
            {
                return cliente;
            }
            set
            {
                cliente = value;
            }
        }

        
        public DateTime Data
        {
            get => data;
            set
            {
                if (value > DateTime.Now.Date)
                    throw new ArgumentException("La data di emissione dello scontrino non è ancora avvenuta. Inserisci una data valida");
                data = value;
            }
        }

        public int Numero
        {
            get => numero;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Il numero dello scontrino non può essere minore o uguale a 0. Inserisci un numero consono");
                numero = value;
            }
        }

        public List<CArticolo> Articoli
        {
            get
            {
                return articoli;
            }
            set
            {
                articoli = value;
            }
        }


        public CScontrino(CClienti Cliente, DateTime Data ,int Numero, List<CArticolo> Articoli)
        {
            this.Cliente = Cliente;
            this.Data = Data;
            this.Numero = Numero;
            this.Articoli = Articoli;
        }

        public string Info()
        {
            string testo = $"Numero di scontrino : {Numero} \t Data di emissione : {Data} \t Nome del cliente: {Cliente.Nome}\n";
            
            foreach(CArticolo a in articoli)
            {
                testo += $"{a.Descrizione} - {a.Prezzo} \n";
            }


            testo += $"Totale da pagare: {Totale}";
            return testo;
            
        }

        
        
        
    }
}