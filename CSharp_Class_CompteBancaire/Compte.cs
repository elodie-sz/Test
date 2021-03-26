using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Class_CompteBancaire
{
    class Compte
    {
        private int numCompte;
        private double solde;
        private int nbCompte;
        private Client titulaireDuCompte; //matérialise la relation compte / client, un client possede un compte 

        public int NumCompte { get => numCompte; set => numCompte = value; }

        public Compte(Client client)
        {
            titulaireDuCompte = client;
            NumCompte = nbCompte++;
        }
        public Compte(Client client, double depotOuverture)
        {
            titulaireDuCompte = client;
            NumCompte = nbCompte++;
            solde = depotOuverture;
        }

        public string InfoCompte()
        {
            return ("ID compte : " + NumCompte.ToString() + " solde restant : " + solde.ToString() + titulaireDuCompte.InfoClient());
        }

        public bool Crediter(double credit)
        {
            solde += credit;
            return true;
        }

        public bool Debiter(double debit)
        {
            bool testRetrait = false;
            if(debit <= solde)
            {
                solde -= debit;
                testRetrait = true;
            }
            return testRetrait;
        }
    }
}
