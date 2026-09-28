
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
    //NEL MAIN SI GESTISCE SOLO INPUT E OUTPUT, LE FUNZIONI DI CALCOLO LE FA UNA CLASSE A PARTE
namespace EsRegistratoreCassa
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<CClienti> elencoClienti = new List<CClienti>();
            List<CArticolo> acquisti = new List<CArticolo>();
            CRegistratore registratore = new CRegistratore();


            string fedeltà;
            do
            {
                Console.WriteLine("Possiedi una tessera fedeltà?");
                fedeltà = Console.ReadLine();
            } while (string.IsNullOrEmpty(fedeltà) || (fedeltà.ToLower() != "sì" && fedeltà.ToLower() != "si" && fedeltà.ToLower() != "no"));


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
                Console.WriteLine("Inserisci il nome e il cognome del cliente");
                nome = Console.ReadLine();
            } while (string.IsNullOrEmpty(nome));
            CClienti cliente = new CClienti(nome, tessera);
            for (int i = 0; i < 3; i++)
            {
                try
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
                    } while (!int.TryParse(Console.ReadLine(), out anno) || anno < DateTime.Now.Year);



                    CAlimentari prodotto = new CAlimentari(codice, descrizione, prezzo, anno);

                    if (tessera)
                    {
                        prodotto.sconta();
                    }
                    Console.WriteLine(prodotto.StampaInfo());
                    acquisti.Add(prodotto);
                    
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    i--;
                }
            }

            for(int i = 0; i < 2; i++)
            {
                try
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
                    Console.WriteLine(prodotto.StampaInfo());
                    acquisti.Add(prodotto);
                    
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    i--;
                }
            }
            
            elencoClienti.Add(cliente);

            CScontrino scontrino = registratore.EmettiScontrino(cliente, acquisti);
            Console.WriteLine(scontrino.Info());

            long codiceCercato;
            do
            {
                Console.WriteLine("Inserisci il codice a barre del prodotto da cercare");
            } while (!long.TryParse(Console.ReadLine(), out codiceCercato));

            List<CClienti> clientiTrovati = new List<CClienti>();

            foreach (CClienti c in elencoClienti)
            {
                if (c.HaComprato(codiceCercato))
                    clientiTrovati.Add(c);
            }

            if (clientiTrovati.Count > 0)
            {
                Console.WriteLine($"\nClienti che hanno acquistato il prodotto con codice {codiceCercato}:");
                foreach (CClienti c in clientiTrovati)
                {
                    Console.WriteLine(c.InfoCliente() + "\n");
                   
                }
            }
            else
            {
                Console.WriteLine("\nNessun cliente ha acquistato un prodotto con questo codice a barre.");
            }

            int mese;
            do
            {
                Console.WriteLine("Inserisci il mese di cui vedere gli scontrini");
            }while(!int.TryParse(Console.ReadLine(), out mese) || mese < 1 || mese > 12);
            Console.WriteLine("Lista scontrini per mese: \n");
            List<CScontrino> scontriniMese = registratore.MostraScontriniDelMese(mese);
            if(scontriniMese.Count == 0)
            {
                Console.WriteLine("Nessuno scontrino presente");

            }
            else
            {
                foreach (CScontrino s in scontriniMese)
                {
                    Console.WriteLine(s.Info());
                }
            }

            

            int settimana;
            do
            {
                Console.WriteLine("Inserisci la settimana del mese di cui vuoi vedere gli scontrini");
            } while (!int.TryParse(Console.ReadLine(), out settimana) || settimana < 1 || settimana > 5);
            Console.WriteLine("Lista scontrini per settimana \n");
            List<CScontrino> scontriniSettimana  = registratore.MostraScontriniDellaSettimana(mese, settimana);
            if(scontriniSettimana.Count == 0)
            {
                Console.WriteLine("Nessuno scontrino presente");

            }
            else
            {
                foreach (CScontrino s in scontriniSettimana)
                {
                    Console.WriteLine(s.Info());
                }
            }


            

            string scelta;
            do
            {
                Console.WriteLine("Vuoi eliminare l'ultimo scontrino?");
                scelta = Console.ReadLine();
            } while (string.IsNullOrEmpty(scelta) || (scelta.ToLower() !=  "si" && scelta.ToLower() != "no" && scelta.ToLower() != "sì"));

            if(scelta.ToLower() != "no")
            {
                registratore.CancellaScontrino();
                Console.WriteLine("Lista scontrini dopo l'eliminazione dell'ultimo scontrino: \n");
                List<CScontrino> lista = registratore.MostraListaScontrini();
                if(lista.Count == 0)
                {
                    Console.WriteLine("Nessuno scontrino presente");

                }
                else
                {
                    foreach (CScontrino s in lista)
                    {
                        Console.WriteLine(s.Info());
                    }
                }
                
                
            }
        }
    }
}
