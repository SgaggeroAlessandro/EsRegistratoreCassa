
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsRegistratoreCassa
{
    internal class Program
    {
        static void Main(string[] args)
        {

            List<CArticolo> storico = new List<CArticolo>();
            string fedeltà;
            do
            {
                Console.WriteLine("Possiedi una tessera fedeltà?");
                fedeltà = Console.ReadLine();
            } while (string.IsNullOrEmpty(fedeltà) || (fedeltà.ToLower() != "sì" && fedeltà.ToLower() != "si" || fedeltà.ToLower() != "no"));


            bool tessera;
            if (fedeltà.ToLower() == "no")
            {
                tessera = false;
            }
            else
            {
                tessera = true;
            }
            string nome;
            do
            {
                Console.WriteLine("Inserisci il nome del cliente");
                nome = Console.ReadLine();
            } while (string.IsNullOrEmpty(nome));
            CClienti cliente = new CClienti(nome, tessera);
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("Scrivi la descrizione dell'articolo acquistato");
                string descrizione = Console.ReadLine();

                double prezzo;
                do
                {
                    Console.WriteLine("Inserisci il prezzo dell'articolo acquistato");
                } while (!double.TryParse(Console.ReadLine(), out prezzo));

                long codice;
                do
                {
                    Console.WriteLine("Inserisci il codice a barre del prodotto");
                } while (!long.TryParse(Console.ReadLine(), out codice));
                int anno;
                do
                {
                    Console.WriteLine("Inserisci l'anno di scadenza del prodotto");
                } while (!int.TryParse(Console.ReadLine(), out anno));

                

                CAlimentari prodotto = new CAlimentari(codice, descrizione, prezzo, anno);
                
                if (tessera)
                {
                    prodotto.sconta();
                }
                prodotto.StampaInfo();
                storico.Add(prodotto);
                
                
                
            }

            for(int i = 0; i < 2; i++)
            {
                Console.WriteLine("Scrivi la descrizione dell'articolo acquistato");
                string descrizione = Console.ReadLine();

                double prezzo;
                do
                {
                    Console.WriteLine("Inserisci il prezzo dell'articolo acquistato");
                } while (!double.TryParse(Console.ReadLine(), out prezzo));

                long codice;
                do
                {
                    Console.WriteLine("Inserisci il codice a barre del prodotto");
                } while (!long.TryParse(Console.ReadLine(), out codice));

                string materiale;
                do
                {
                    Console.WriteLine("Inserisci il materiale del prodotto");
                    materiale = Console.ReadLine();
                } while (string.IsNullOrEmpty(materiale));

                CNonAlimentari prodotto = new CNonAlimentari(codice, descrizione, prezzo, materiale);
                if (tessera)
                {
                    prodotto.sconta();
                }
                prodotto.StampaInfo();
                storico.Add(prodotto);
                
                
            }
            cliente.storico = storico;
            double totale = 0;

            foreach (CArticolo art in storico)
            {
                Console.WriteLine($"{art.Descrizione} - {art.Prezzo}");
                totale += art.Prezzo;
            }
            Console.WriteLine("Totale da pagare: " + totale);
            long codiceCercato;
            do
            {
                Console.WriteLine("Inserisci il codice a barre del prodotto da cercare");
            } while (!long.TryParse(Console.ReadLine(), out codiceCercato));
            bool trovato = false;
            foreach (CArticolo articolo in storico)
            {
                ;
                if(articolo.CodiceBarre == codiceCercato)
                {
                    trovato = true;
                    break;
                }
            }
            if (trovato)
            {
                Console.WriteLine($"\nIl cliente {cliente.InfoCliente()} ha acquistato il prodotto cercato.");
            }
            else
            {
                Console.WriteLine("\nNessun acquisto trovato con questo codice a barre.");
            }
            
        }
    }
}
