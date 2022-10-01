using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp28
{
    class PriorityQueue
    {
        public List<Edge> kenarlar;  // mahalle nesnelerini tutan generic listenin oluşturulması
        public int size;  // dizinin kapasitesini tutan değişken


        public PriorityQueue(int size)  // parametre olarak kapasiteyi alan constructor
        {
            this.size = size; // kapasitenin atanması
            kenarlar = new List<Edge>(); // mahallelerin tutulduğu generic listenin oluşturulması
        }

        public void ekle(Edge nesne)  // kuyruğa eleman ekleyen metod parametre olarak eklenecek nesneyi alır
        {
            if (kenarlar.Count != size) // kuyruğun doluluk kontrolü
            {
                kenarlar.Add(nesne); // kuyruğa elemanın eklenmesi
            }
            else
            {
                Console.WriteLine("Liste Dolu");
            }

        }

        public Edge sil()  // kuyruktan eleman silen metod
        {
            int min = kenarlar[0].weight;  // teslimat sayısının tutulduğu değişken default olarak -1 atanmıştır
            int index = 0;   // silinecek olan elemanın indexi
            Edge temp = null;  // silinecek olan elemanın atandığ mahalle nesnesi


            if (bosMu())  // doluluk kontrolü
            {
                Console.WriteLine("liste Bos");
                return temp;
            }
            else
            {
                for (int i = 0; i < kenarlar.Count; i++)
                {
                    if (kenarlar[i].weight <= min)  // kuyruktaki en yüksek öncelikli elemanın bulunması
                    {
                        min = kenarlar[i].weight;  // en yüksek öncelikli elemanın teslimat sayısının atanması
                        index = i;   // en yüksek öncelikli elemanın indexinin atanması
                        temp = kenarlar[index];   // en yüksek öncelikli elemanın nesneye atılması
                    }
                }
                kenarlar.RemoveAt(index);  // en öncelikli elemanın kuyruktan silinmesi 
                return temp;  // elemanın geri döndürülmesi
            }

        }

        public bool bosMu()  // kuyruğun doluluğunu kontrol eden metod
        {


            if (kenarlar.Count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
