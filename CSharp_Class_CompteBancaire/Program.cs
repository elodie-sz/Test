using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Class_CompteBancaire
{
    class Program
    {
        public static Client SaisieClient()
        {
            string _nom;
            string _prenom;
            string _tel;
            string _adresse;
            string _insee;
            //saisie des caractéristiques du propriétaire du compte
            Console.WriteLine("Entrez le nom du titulaire du compte :");
            _nom = Console.ReadLine();
            Console.WriteLine("Entrez le prenom :");
            _prenom = Console.ReadLine();
            Console.WriteLine("Entrez le tel :");
            _tel = Console.ReadLine();
            Console.WriteLine("Entrez l'adresse:");
            _adresse = Console.ReadLine();
            Console.WriteLine("Entrez le numéro d'insee:");
            _insee = Console.ReadLine();

            // instanciation le nouveau Client
            Client nouveau = new Client(_nom, _prenom, _insee, _tel, _adresse);
            return nouveau; // une fois le client créer la fonction retourne l'objet client


        }

        public static int RechercherCompte(int _numCompte, List<Compte> porteFeuille)
        {
            int posCompte = -1; // postion du compte dans la liste

            for (int i = 0; i < porteFeuille.Count; i++)
            {
                if (porteFeuille.ElementAt(i).NumCompte == _numCompte)
                    posCompte = i;
            }
            return posCompte;

        }
        static void Main(string[] args)
        {
            Int16 choix;
            char saisie;
            double soldeOuverture;
            Compte compteCourant;
            bool test;
            List<Compte> portefeuilleClient = new List<Compte>();// instanciation d'une liste de compte
            int _numCompte, position;
            char continuer = 'o';
            // affichage du menu
            do
            {
                Console.WriteLine("1 : Créer un nouveau compte");
                Console.WriteLine("2 : Créditer un  compte");
                Console.WriteLine("3 : Debiter un  compte");
                Console.WriteLine("4 : Afficher la liste des comptes");
                Console.WriteLine("5 : Quitter");
                Console.WriteLine("Votre choix");
                choix = Convert.ToInt16(Console.ReadLine());


                switch (choix)
                {

                    case 1: // créer un compte
                        Console.Clear();
                        Client nouveauClient = new Client();//instanciation d'un client "vierge" 
                        nouveauClient = SaisieClient();
                        // on demande au client s'il dispose d'un depot à la création
                        Console.WriteLine("Avez-vous un apport pour créer ce compte ? (O = Oui / N = Non)");
                        saisie = char.Parse(Console.ReadLine());
                        if (saisie == 'o' || saisie == 'O')
                        {
                            Console.WriteLine("Indiquez le montant : ");
                            soldeOuverture = Convert.ToDouble(Console.ReadLine());
                            compteCourant = new Compte(nouveauClient, soldeOuverture);
                            portefeuilleClient.Add(compteCourant);// enregistrement du compte dans la liste
                        }
                        else
                        {
                            compteCourant = new Compte(nouveauClient);
                            portefeuilleClient.Add(compteCourant);// enregistrement du compte dans la liste
                        }
                        Console.WriteLine();
                        break;

                    case 2:
                        Console.Clear();
                        Console.WriteLine("Veuillez saisir votre numero de compte: ");
                        _numCompte = int.Parse(Console.ReadLine());
                        position = RechercherCompte(_numCompte, portefeuilleClient);
                        if (position >= 0)
                        {
                            Console.WriteLine("Quel montant voulez vous déposer ? ");
                            double montant = double.Parse(Console.ReadLine());

                            if (portefeuilleClient.ElementAt(position).Crediter(montant))
                            {
                                Console.WriteLine("Opération effectué !");
                            }
                            else
                            {
                                Console.WriteLine("opération échouée !");
                            }
                        }
                        Console.WriteLine();

                        //crediter le compte 
                        break;

                    case 3: // debiter un compte
                        Console.Clear();
                        Console.WriteLine("Veuillez saisir votre numero de compte: ");
                        _numCompte = int.Parse(Console.ReadLine());
                        position = RechercherCompte(_numCompte, portefeuilleClient);
                        if (position >= 0)
                        {
                            Console.WriteLine("Quel montant voulez vous retirer ? ");
                            double montant = double.Parse(Console.ReadLine());

                            if (portefeuilleClient.ElementAt(position).Debiter(montant))
                            {
                                Console.WriteLine("Opération effectué !");
                            }
                            else
                            {
                                Console.WriteLine("Retrait impossible ! solde insuffisant");
                            }
                        }
                        Console.WriteLine();
                        break;

                    case 4: // Lister les comptes existants 
                        Console.Clear();
                        for (int i = 0; i < portefeuilleClient.Count; i++)
                            Console.WriteLine(portefeuilleClient.ElementAt(i).InfoCompte());
                        break;
                    case 5: // quitter 
                        continuer = 'n';
                        break;

                    default:
                        Console.WriteLine("Commande non reconnue !");
                        break;
                }

            } while (continuer != 'n');
        }
    }
}

