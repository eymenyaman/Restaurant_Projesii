namespace Restaurant_Projesii
{
    internal class Program
    {
        static void Main(string[] args)
        {

            /*  I'm Doing This  */


            Console.WriteLine("*********** Deryanın Anasının Babasının Lokantısına  Hoş Geldiniz ***********");
            // Yeni Masalar Oluşturdum Ve 5 Masa Olarak 
            MasaSecim.MasaListesiOlustur(5);
            // Lokanta Methodunu Çağırdım 
            LokantaK();




        }

        static void LokantaK()
        {
            while (true)
            {
                // İşlem Semek 
                Console.WriteLine("1 Sipariş Ver");
                Console.WriteLine("2 Hesap Öde");
                Console.WriteLine("3 Çıkış");
                int secim = Convert.ToInt32(Console.ReadLine());
                if (secim == 1)
                {
                    // Müşteri ekle çagırıp 2 saniye bekletip ekranı temızledm
                    MasaSecim.MusteriEkle();
                    Thread.Sleep(2000);
                    Console.Clear();

                    var bosmasa = MasaSecim.BosMasaBul();
                    if (bosmasa != null) // Boş Masa Var İse 
                    {
                        Console.WriteLine("Kaç Kişi Olucak Masa");
                        int kişi = Convert.ToInt32(Console.ReadLine());
                        for (int i = 0; i < kişi; i++)
                        {
                            Menu.SiparisAl(bosmasa);
                        }

                    }
                    // İki Saniye Bekletip Ekranı Temizledim 
                    Thread.Sleep(2000);
                    Console.Clear();


                }
                else if (secim == 2)
                {
                    // Hesap Ödeme 
                    HesapınıÖde();
                }
                else if (secim == 3)
                {   // İki Saniye Bekletip Sistemi Kappattım
                    Console.WriteLine("Çıkış Yapılıyor");
                    Thread.Sleep(2000);
                    Environment.Exit(0);
                }
                else
                {  // Hatalı Seçim
                    Console.WriteLine("Hatalı Seçim ");
                }

            }

        }
        // Method Ksmı 

        static void HesapınıÖde()
        {
            // İstedğimiz Hesabı Sorup Ödemeyi Alıyoruz
            Console.WriteLine("Lütfen Hesabını Ödemek İstediğiniz Masa Numarasını Giriniz");
            int masanumarasısecim = Convert.ToInt32(Console.ReadLine());
            // o masa var ise kontrol edilir 
            MasaSecim masa = MasaSecim.Masalar.FirstOrDefault(m => m.MasaNo == masanumarasısecim);
            if (masa != null && !masa.BosMu)// Masa Dolu ise 
            {
                double toplamhesap = masa.ToplamHesap();
                Console.WriteLine($"Masa {masa.MasaNo} İçin Toplam Hesap : {toplamhesap} Tl");
                Console.WriteLine("Hesabı Şimdi Ödemek İster Misiniz? e,h)");
                string odeme = Console.ReadLine().ToUpper();
                if (odeme == "E")
                {
                    masa.BosMu = true;
                    masa.siparisIcecek.Clear();
                    masa.siparisYiyecek.Clear();
                    Console.WriteLine("Hesabınız Başarıyla Ödendi :)");
                    Thread.Sleep(2000);
                }
                else
                {
                    Console.WriteLine("Hesap Ödenemedi Bulaşıklara Geçin");
                }
                //


            }
            else
            {
                Console.WriteLine("Geçersiz ");
            }


        }



    }
}

