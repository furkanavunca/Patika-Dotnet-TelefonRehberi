using System;
using System.Collections;
using System.Collections.Generic;

namespace TelefonRehberi
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine(" Lütfen yapmak istediğiniz işlemi seçiniz");
                Console.WriteLine(" ****************************************");
                Console.WriteLine(" (1) Yeni Numara Kaydet");
                Console.WriteLine(" (2) Varolan Numarayı Sil");
                Console.WriteLine(" (3) Varolan Numarayı Düzenle");
                Console.WriteLine(" (4) Rehberi Listele");
                Console.WriteLine(" (5) Rehberde Arama Yap");

                int secim = Convert.ToInt32(Console.ReadLine());

                Rehberde rehberliste = new Rehberde();

                switch (secim)
                {
                    case 1:
                        rehberliste.Islek1();
                        Console.ReadLine();
                        break;
                    case 2:
                        rehberliste.Islek2();
                        Console.ReadLine();
                        break;
                    case 3:
                        rehberliste.Islek3();
                        Console.ReadKey();
                        break;
                    case 4:
                        rehberliste.Islek4();
                        Console.ReadLine();
                        break;
                    case 5:
                        rehberliste.Islek5();
                        Console.ReadLine();
                        break;
                }
            }
        }

        public class Rehberde
        {
            List<Kart> KartRehberi = new List<Kart>();

            public Rehberde()
            {
                KartRehberi.Add(new Kart("Ahmet","Atar","123"));
                KartRehberi.Add(new Kart("Mehmet","Vel","234"));
                KartRehberi.Add(new Kart("Yasin","Tan","456"));
                KartRehberi.Add(new Kart("Ali","Gürsoy","678"));
                KartRehberi.Add(new Kart("Burak","Mehmet","890"));
            }

            public void Islek1()
            {
                Kart kart = new();
                Console.WriteLine("İsim Giriniz :");
                kart.Ad = Console.ReadLine();
                Console.WriteLine("Soyisim Giriniz :");
                kart.Soyad = Console.ReadLine();
                Console.WriteLine("Numara Giriniz :");
                kart.Numara = Console.ReadLine();
                KartRehberi.Add(kart);
                Console.WriteLine("Ekleme İşlemi Gerçekleştirildi ");
                Islek4();
            }

            public void Islek2()
            {
                string deger;
                int tf = 1;
                int sayac = 0;

                while (tf == 1)
                {
                    Console.WriteLine("Silinmesi istenen kişinin bilgisini giriniz : ");
                    deger = Console.ReadLine();

                    foreach (var item in KartRehberi)
                    {
                        
                        if (item.Ad != deger && item.Soyad != deger)
                        {
                            sayac++;
                            if (sayac == KartRehberi.Count)
                            {
                                int i = 1;
                                while (i == 1)
                                {
                                    Console.WriteLine("Aranılan kişi rehberde bulunamadı ");
                                    Console.WriteLine("Silme işlemine devam etmek için: 1");
                                    Console.WriteLine("Ana Menüye Dönmek için : 0' ye Basınız");
                                    string basim = Console.ReadLine();
                                    if (basim == "1")
                                    {
                                        i = 0;
                                        tf = 1;
                                    }   
                                    else if (basim == "0")
                                    {
                                        i = 0;
                                        tf = 0;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Geçerli bir parametre girilmedi");
                                    }
                                }
                            }
                        }
                        else if (item.Ad == deger || item.Soyad == deger)
                        {
                            Console.WriteLine(item.Ad + " " + item.Soyad + " "+ item.Numara + " Silmek istediğinize emin misiniz (y/n)");
                            string chose = Console.ReadLine();
                            if (chose == "y")
                            {
                                KartRehberi.RemoveAt(KartRehberi.IndexOf(item));
                                Console.WriteLine(item.Ad + " " + item.Soyad + " "+ item.Numara + " Silindi");
                                Islek4();
                                tf = 0;
                                break;
                            }
                            else if (chose == "n")
                            {
                                Console.WriteLine(item.Ad + " " + item.Soyad + " "+ item.Numara + " İçin silme işlemi ipral edildi");
                                tf = 0;
                                break;
                            }
                        }
                    }
                    sayac = 0;
                }
            }

            public void Islek3()
            {
                string deger;
                int tf = 1;
                int sayac = 0;

                while (tf == 1)
                {
                    Console.WriteLine("Numarasını güncellemek istediğiniz kişinin isim ya da soyismini giriniz: ");
                    deger = Console.ReadLine();
                    foreach (var item in KartRehberi)
                    {
                        if (item.Ad != deger && item.Soyad != deger)
                        {
                            sayac++;
                            if (sayac == KartRehberi.Count)
                            {
                                int i = 1;
                                while (i == 1)
                                {
                                    Console.WriteLine("Aranılan kişi rehberde bulunamadı ");
                                    Console.WriteLine("Arama işlemine devam etmek için: 1");
                                    Console.WriteLine("Ana Menüye Dönmek için : 0' ye Basınız");
                                    string basim = Console.ReadLine();
                                    if (basim == "1")
                                    {
                                        i = 0;
                                        tf = 1;
                                    }   
                                    else if (basim == "0")
                                    {
                                        i = 0;
                                        tf = 0;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Geçerli bir parametre girilmedi");
                                    }
                                }
                            }
                        }
                        else if (item.Ad == deger || item.Soyad == deger)
                        {
                            Console.WriteLine(item.Ad + " " + item.Soyad + " " + item.Numara + " Bilgileri güncelleme için seçildi, devam etmek istiyor musunuz? (y/n)");
                            string chose = Console.ReadLine();
                            if (chose == "y")
                            {
                                Console.WriteLine("Güncel ismi giriniz: ");
                                item.Ad = Console.ReadLine();
                                Console.WriteLine("Güncel soyismi giriniz: ");
                                item.Soyad = Console.ReadLine();
                                Console.WriteLine("Güncel numarayı giriniz");
                                item.Numara = Console.ReadLine();
                                Console.WriteLine("Kişi bilgileri isim: " + item.Ad + " soyisim: " + item.Soyad + " numara: "+ item.Numara + " olarak güncellendi");
                                Islek4();
                                tf = 0;
                                break;
                            }
                            else if (chose == "n")
                            {
                                Console.WriteLine("Güncelleme işlemi iptal edildi");
                                tf = 0;
                                break;
                            }
                        }
                    }
                    sayac = 0;
                }
            }

            public void Islek4()
            {
                Console.WriteLine(" Rehberde Kayıtlı Olan Kişi Sayısı " + KartRehberi.Count);
                foreach (var item in KartRehberi)
                {
                    Console.WriteLine(item.Ad + " " + item.Soyad + " " + item.Numara);
                }
            }

            public void Islek5()
            {
                Console.WriteLine(" Arama yapmak istediğiniz tipi seçiniz.:");
                Console.WriteLine(" ***************************************");
                Console.WriteLine(" İsim veya soyisime göre arama yapmak için: 1");
                Console.WriteLine(" Telefon numarasına göre arama yapmak için: 2");

                int type = int.Parse(Console.ReadLine());
                int tf = 1;
                int sayac = 0;
                string deger;
                while (tf == 1)
                {
                    if (type == 1)
                    {
                        Console.WriteLine("Aramak istediğiniz isim ya da soyismi girini ");
                        deger = Console.ReadLine();

                        foreach (var item in KartRehberi)
                        {
                            sayac++;
                            if (item.Ad != deger && item.Soyad != deger)
                            {
                                if (sayac == KartRehberi.Count - 1)
                                {
                                    Console.WriteLine("Aradığınız kişi rehberde bulunamadı");
                                    tf = 0;
                                }
                            }
                            else if (item.Ad == deger || item.Soyad == deger)
                            {
                                Console.WriteLine("İsim : " + item.Ad + " Soyisim : " + item.Soyad + " Numara : " + item.Numara);
                                tf = 0;
                            }
                        }
                        sayac = 0;
                    }
                    else if (type == 2)
                    {
                        Console.WriteLine("Aramak istediğiniz numarayı giriniz : ");
                        deger = Console.ReadLine();

                        foreach (var item in KartRehberi)
                        {
                            sayac++;
                            if (item.Numara != deger)
                            {
                                if (sayac == KartRehberi.Count)
                                {
                                    Console.WriteLine("Aradığınız numara rehberde bulunamadı ");
                                    tf = 0;
                                }
                            }
                            else if (item.Numara == deger)
                            {
                                Console.WriteLine("İsim : " + item.Ad + " Soyisim : " + item.Soyad + " Numara : " + item.Numara);
                                tf = 0;
                            }
                        }
                        sayac = 0;
                    }
                    else
                    {
                        tf = 0;
                    }
                }
            }
        }
        public class Kart
        {
            string ad, soyad, numara;

            public string Ad { get => ad; set => ad = value; }
            public string Soyad { get => soyad; set => soyad = value; }
            public string Numara { get => numara; set => numara = value; }

            public Kart(string ad, string soyad, string numara)
            {
                Ad = ad;
                Soyad = soyad;
                Numara = numara;
            }

            public Kart()
            {
            }
        }
    }
}
