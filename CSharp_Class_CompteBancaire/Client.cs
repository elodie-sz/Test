using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Class_CompteBancaire
{
    class Client
    {
        private string nom;
        private string prenom;
        private string telephone;
        private string adresseClient;
        private string insee;

        public Client()
        {
        }

        public Client(string _nom, string _prenom, string _insee, string _tel = "00 00 00 00 00", string _adresse ="Pas communiquée")
        {
            nom = _nom;
            prenom = _prenom;
            telephone = _tel;
            adresseClient = _adresse;
            insee = _insee;
        }

        public string InfoClient()
        {
            return ("Nom: " + nom + ", prenom : " + prenom + ", adresse : " + adresseClient + ", tel : " + telephone + ", n° insee : " + insee);
        }
    }

    
}
