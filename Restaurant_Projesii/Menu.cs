﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_Projesii
{
    internal class Menu
    {
        internal static List<MenuYiyecek> yiyeceks = new List<MenuYiyecek>()
        {
         new MenuYiyecek() { No = 1, Ad = "Mercimek Çorbası", Fiyat = 90 },
         new MenuYiyecek() { No = 2, Ad = "Ezo Gelin", Fiyat = 130 },
         new MenuYiyecek() { No = 3, Ad = "Et", Fiyat = 900 },
         new MenuYiyecek() { No = 4, Ad = " Pizza", Fiyat = 350 },
         new MenuYiyecek() { No = 5, Ad = "Bol Malzemeli Pizza", Fiyat = 150 },
         new MenuYiyecek() { No = 6, Ad = "Çoban Salata", Fiyat = 180 },
         new MenuYiyecek() { No = 7, Ad = " Sezar Salata", Fiyat = 59 },
         new MenuYiyecek() { No = 8, Ad = "Hamburger", Fiyat = 380 },
         new MenuYiyecek() { No = 9, Ad = "Sulu Köfte", Fiyat = 200 }
        };
        internal static List<MenuIcecek> Iceceks = new List<MenuIcecek>()
        {
         new MenuIcecek() { No = 1, Ad = "Rakı", Fiyat = 500 },
         new MenuIcecek() { No = 2, Ad = "Kahve", Fiyat = 80 },
         new MenuIcecek() { No = 3, Ad = "Su", Fiyat = 35 },
         new MenuIcecek() { No = 4, Ad = "Kola", Fiyat = 50 },
         new MenuIcecek() { No = 5, Ad = "Meyve Suyu", Fiyat = 50 }
        };
        internal static void MenuYazYemek()
        {
            foreach (MenuYiyecek item in yiyeceks)
            {
                Console.WriteLine(item.No + "-" + item.Ad + " / " + item.Fiyat + "tl");
            }
        }
        internal static void MenuYazIcecek()
        {
            foreach (MenuIcecek item in Iceceks)
            {
                Console.WriteLine(item.No + "-" + item.Ad + " / " + item.Fiyat + "tl");

            }
        }
        internal static void SiparisAl(MasaSecim bosMasa)
        {
            Console.WriteLine("Yiyecek Menüsü Y İçecek Menüsü I ");
            string tuslama = Console.ReadLine().ToUpper();
            if (tuslama == "Y")
            {
                Console.WriteLine("Ne Yemek İstersiniz?");
                MenuYazYemek();
                try
                {
                    int yemekSecim = Convert.ToInt32(Console.ReadLine());
                    if (yemekSecim > 0 && yemekSecim <= yiyeceks.Count)
                    {
                        var secilenYemek = yiyeceks[yemekSecim - 1];
                        bosMasa.siparisYiyecek.Add(secilenYemek); //Masanın Sipariş Listesine Yemeği Ekle

                        Console.WriteLine($"{secilenYemek.Ad} Siparişinize Eklendi");
                    }
                    else
                    {
                        Console.WriteLine("Hatalı Tuşlama Yaptınız!");
                        Console.Clear();
                        MenuYazYemek();
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Lütfen Rakam Tuşlayınız!");
                    Console.Clear();
                    MenuYazYemek();
                }
            }
            else if (tuslama == "I" || tuslama == "İ")
            {
                Console.WriteLine("Ne İçmek İstersiniz?");
                MenuYazIcecek();
                try
                {
                    int icecekSecim = Convert.ToInt32(Console.ReadLine());
                    if (icecekSecim > 0 && icecekSecim <= Iceceks.Count)
                    {
                        var secilenIcecek = Iceceks[icecekSecim - 1];
                        bosMasa.siparisIcecek.Add(secilenIcecek);
                        bosMasa.ToplamHesap();
                        Console.WriteLine($"{secilenIcecek.Ad} Siparişinize Eklendi");
                    }
                    else
                    {
                        Console.WriteLine("Hatalı Tuşlama Yaptınız!");
                        MenuYazIcecek();
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Lütfen Rakam Tuşlayınız!");
                    Console.Clear();
                    MenuYazIcecek();
                }
            }
            else
            {
                Console.WriteLine("Hatalı Seçim");
                SiparisAl(bosMasa);
            }
            Console.WriteLine("Başka Bir Arzunuz Var Mı? e/H");
            string secim = Console.ReadLine().ToUpper();
            if (secim == "E")
            {
                SiparisAl(bosMasa);
            }
            else if (secim == "H")
            {
                Console.WriteLine("Siparişiniz Başarıyla Alındı ");
            }
            else
            {
                Console.WriteLine("Hatalı Tuşlama Yaptınız");
                SiparisAl(bosMasa);
            }
        }





    }
}
