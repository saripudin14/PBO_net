using module_3_gudangoop.Models; // Sesuaikan namespace dengan proyek Anda
using System;
using System.Collections.Generic; // Ditambahkan untuk List dan Dictionary
using System.Linq; // Ditambahkan untuk method .FirstOrDefault()

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("--- IMPLEMENTASI MODUL 5: Collection dan Generic ---");
        Console.WriteLine("==================================================\n");

        ItemGudang item1 = new BarangKimia("KIM001", "Asam Sulfat");
        ItemGudang item2 = new BarangMakanan("MAK001", "Susu Kental", DateTime.Parse("2023-12-01"));

        item1.CetakInfo();
        Console.WriteLine(item1.EvaluasiResiko());
        item2.CetakInfo();
        Console.WriteLine(item2.EvaluasiResiko());

        if (item2 is IPeriksaKadaluarsa periksa)
        {
            Console.WriteLine(periksa.ApakahKadaluarsa() ? "Kadaluarsa" : "Masih berlaku");
        }

        Console.WriteLine("\n--- Lanjutan: Implementasi Collection dan Generic ---");

        // Langkah 1: Simpan Banyak Objek Barang ke dalam List<ItemGudang> (atau List<Barang> jika sesuai)
        // Kita bisa menambahkan item1 dan item2 ke dalam list juga
        List<ItemGudang> daftarItemGudang = new List<ItemGudang>();
        daftarItemGudang.Add(item1);
        daftarItemGudang.Add(item2);
        // Tambahkan item lainnya
        daftarItemGudang.Add(new BarangKimia("KIM002", "NaOH"));
        daftarItemGudang.Add(new BarangMakanan("MAK002", "Roti", DateTime.Now.AddDays(7)));

        Console.WriteLine("\nDaftar Item Gudang dalam List<ItemGudang>:");
        foreach (var item in daftarItemGudang)
        {
            item.CetakInfo();
            Console.WriteLine(item.EvaluasiResiko());
            if (item is IPeriksaKadaluarsa periksaItem)
            {
                Console.WriteLine(periksaItem.ApakahKadaluarsa() ? "Kadaluarsa" : "Masih berlaku");
            }
            Console.WriteLine(); // Baris kosong pemisah
        }

        // Langkah 2: Cari Item dengan .Find()
        Console.WriteLine("--- Langkah 2: Pencarian Item (.Find) ---");
        var hasilCariItem = daftarItemGudang.Find(i => i.Kode == "KIM001");
        if (hasilCariItem != null)
        {
            Console.WriteLine("Item dengan kode KIM001 ditemukan:");
            hasilCariItem.CetakInfo();
        }
        else
        {
            Console.WriteLine("Item dengan kode KIM001 TIDAK ditemukan.");
        }

        // Langkah 3: Gunakan Dictionary<string, ItemGudang>
        Console.WriteLine("\n--- Langkah 3: Dictionary<string, ItemGudang> ---");
        Dictionary<string, ItemGudang> indeksItem = new Dictionary<string, ItemGudang>();

        // Isi dictionary dari list
        foreach (var item in daftarItemGudang)
        {
            if (!indeksItem.ContainsKey(item.Kode))
            {
                indeksItem[item.Kode] = item;
            }
            else
            {
                Console.WriteLine($"Peringatan: Kode '{item.Kode}' sudah ada di Dictionary. Melewati...");
            }
        }

        // Penggunaan Dictionary: Akses cepat berdasarkan kode
        string kodeCariItem = "MAK001";
        if (indeksItem.ContainsKey(kodeCariItem))
        {
            Console.WriteLine($"Item dengan kode {kodeCariItem} (dari Dictionary):");
            indeksItem[kodeCariItem].CetakInfo();
            if (indeksItem[kodeCariItem] is IPeriksaKadaluarsa periksaDict)
            {
                Console.WriteLine(periksaDict.ApakahKadaluarsa() ? "Kadaluarsa" : "Masih berlaku");
            }
        }
        else
        {
            Console.WriteLine($"Item dengan kode {kodeCariItem} TIDAK ditemukan di Dictionary.");
        }

        // Langkah 4: Buat dan Gunakan Method Generic
        Console.WriteLine("\n--- Langkah 4: Method Generic ---");

        // Gunakan method generic CariData (asumsi didefinisikan di bawah)
        var hasilGeneric = CariData(daftarItemGudang, i => i.Kode == "KIM002");
        if (hasilGeneric != null)
        {
            Console.WriteLine("Item dengan kode 'KIM002' (dari method generic CariData):");
            hasilGeneric.CetakInfo();
        }
        else
        {
            Console.WriteLine("Item dengan kode 'KIM002' TIDAK ditemukan (dari method generic CariData).");
        }

        // B. Esai Pre-Test: Gunakan method generic AmbilPertama<T>
        var pertama = AmbilPertama(daftarItemGudang);
        Console.WriteLine($"\nItem pertama dalam list (dari method generic AmbilPertama): Kode {pertama?.Kode ?? "Tidak ada"}");

        // Contoh lain dengan method generic AmbilPertama<T> pada tipe lain
        List<string> namaItems = new List<string> { "Asam Sulfat", "Susu Kental", "NaOH" };
        var namaPertama = AmbilPertama(namaItems);
        Console.WriteLine($"Nama pertama dari list string (dari method generic AmbilPertama): {namaPertama ?? "Tidak ada"}");

    }

    // --- Definisi Method Generic ---
    public static T CariData<T>(List<T> list, Func<T, bool> predicate)
    {
        // gunakan LINQ FirstOrDefault agar menerima Func<T,bool>
        return list.FirstOrDefault(predicate);
    }

    public static T AmbilPertama<T>(List<T> list)
    {
        if (list == null || list.Count == 0)
        {
            return default(T);
        }
        return list[0];
    }
}