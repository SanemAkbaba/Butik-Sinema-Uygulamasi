using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ButikSinemaUygulamasi_G023
{
    class Sinema
    {

        //encapsulation
        public string FilmAdi { get; set; }
        public int Kapasite { get; }
        public float TamBiletFiyati { get; }
        public float YarimBiletFiyati { get; }
        public int ToplamTamBiletAdedi { get; private set; }
        public int ToplamYarimBiletAdedi { get; private set; }
        public float Ciro
        {
            get
            {
                return this.ToplamTamBiletAdedi * this.TamBiletFiyati + this.ToplamYarimBiletAdedi * this.YarimBiletFiyati;
            }
        }


        //constructor oluşturulacak

        public Sinema(string filmAdi, int kapasite, float tamBiletFiyati, float yarimBiletFiyati)
        {
            this.FilmAdi = filmAdi;
            this.Kapasite = kapasite;
            this.TamBiletFiyati = tamBiletFiyati;
            this.YarimBiletFiyati = yarimBiletFiyati;
        }


        public void BiletSat(int tamBiletAdedi, int yarimBiletAdedi)
        {
            if (BosKoltukAdediGetir() >= tamBiletAdedi + yarimBiletAdedi) //Boş koltuk adedi ve satılmak istenen bilet adetleri karşılaştırılacak
            {
                this.ToplamTamBiletAdedi += tamBiletAdedi;
                this.ToplamYarimBiletAdedi += yarimBiletAdedi;
                //    CiroHesapla();
                Console.WriteLine("İşlem gerçekleştirildi.");
            }
            else
            {
                //Console.WriteLine("Yeterli sayıda bilet yok. En fazla " + BosKoltukAdediGetir() + " adet bilet satılabilir.");

                Console.WriteLine($"Yeterli sayıda bilet yok. En fazla { BosKoltukAdediGetir() } adet bilet satılabilir.");

                // Console.WriteLine("Yeterli sayıda bilet yok. En fazla {0} adet bilet satılabilir.", BosKoltukAdediGetir());

            }
        }

        public void BiletIade(int tamBiletAdedi, int yarimBiletAdedi)
        {
            //daha önce satılmış olan biletlerle şuan satılmak istenenleri karşılaştıracağız.
            if (tamBiletAdedi <= this.ToplamTamBiletAdedi && yarimBiletAdedi <= this.ToplamYarimBiletAdedi)
            {
                this.ToplamTamBiletAdedi -= tamBiletAdedi;
                this.ToplamYarimBiletAdedi -= yarimBiletAdedi;
                //   CiroHesapla();
                Console.WriteLine("İşlem gerçekleştirildi.");
            }
            else
            {
                Console.WriteLine("Satılandan fazla bilet iade edilemez.");
            }
        }

        private void CiroHesapla()
        {
            //       this.Ciro = this.ToplamTamBiletAdedi * this.TamBiletFiyati + this.ToplamYarimBiletAdedi * this.YarimBiletFiyati;
        }

        //1. adım
        //BoşKoltukAdedGetir()  metodunu yazalım
        //bu metot int tipinde değer döndürsün.
        //kaç boş koltuk kaldığını hesaplayıp döndürsün

        public int BosKoltukAdediGetir()
        {
            return this.Kapasite - this.ToplamTamBiletAdedi - this.ToplamYarimBiletAdedi;
        }



    }
}
