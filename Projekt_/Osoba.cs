﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    //public enum pozycja { Bramkarz, Napastnik, Pomocnik, Obrońca};
    public class Osoba : INotifyPropertyChanged
    {
        private string _Imie;

        public string Imie
        {
            get { return this._Imie; }
            set
            {
                if (this._Imie != value)
                {
                    this._Imie = value;
                    this.NotifyPropertyChanged("Imie");
                }
            }
        }
        private string _Nazwisko { get; set; }

        public string Nazwisko
        {
            get { return this._Nazwisko; }
            set
            {
                if (this._Nazwisko != value)
                {
                    this._Nazwisko = value;
                    this.NotifyPropertyChanged("Nazwisko");
                }
            }
        }

        private string _RodzajSportu;

        public string RodzajSportu
        {
            get { return this._RodzajSportu; }
            set
            {
                if (this._RodzajSportu != value)
                {
                    this._RodzajSportu = value;
                    this.NotifyPropertyChanged("RodzajSportu");
                }
            }
        }

        private int _Wiek;

        public int Wiek
        {
            get { return this._Wiek; }
            set
            {
                if (this._Wiek != value)
                {
                    this._Wiek = value;
                    this.NotifyPropertyChanged("Wiek");
                }
            }
        }

        private int _ID;

        public int ID
        {
            get { return this._ID; }
            set
            {
                if(this._ID!=value)
                {
                    this._ID = value;
                    this.NotifyPropertyChanged("ID");
                }
            }
        }

        private string _Pozycja;

        public string Pozycja
        {
            get { return this._Pozycja; }
            set
            {
                if (this._Pozycja != value)
                {
                    this._Pozycja = value;
                    this.NotifyPropertyChanged("Pozcyja");
                }
            }
        }

        //private pozycja _Pozycja { get; set; }
        //public pozycja Pozycja
        //{
        //    get { return this._Pozycja; }
        //    set
        //    {
        //        if (this._Pozycja != value)
        //        {
        //            this._Pozycja = value;
        //            this.NotifyPropertyChanged("Pozycja");
        //        }
        //    }
        //}


        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}

