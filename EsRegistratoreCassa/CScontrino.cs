using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsRegistratoreCassa
{
    public class CScontrino
    {
        private double conto;
        private DateTime data;
        private int numero;

        protected double Conto
        {
            get => conto;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("L'importo non può essere negativo");
                conto = value;
            }
        }
        protected DateTime Data
        {
            get => data;
            set
            {
                if (value > DateTime.Now.Date)
                    throw new ArgumentException("La data di emissione dello scontrino non è ancora avvenuta. Inserisci una data valida");
                data = value;
            }
        }

        protected int Numero
        {
            get => numero;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Il numero dello scontrino non può essere minore o uguale a 0. Inserisci un numero consono");
                numero = value;
            }
        }

        public CScontrino(int Numero)
        {
            this.Numero = Numero;
        }

        public string Info()
        {
            return $"Importo pagato: {Conto} €\t Data di emissione: {Data:dd/MM/yyyy}\t ID giornaliero: {Numero}";
        }

        public void EmettiScontrino(double conto, DateTime data)
        {
            this.Conto = conto;
            this.Data = data;
        }
        
    }
}