using module_3_gudangoop.Models;
using module_3_gudangoop.Services;
using module_3_gudangoop.Interfaces;
using module_3_gudangoop.Helpers;
using module_3_gudangoop.Factories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        string path = Path.Combine(Directory.GetCurrentDirectory(), "data_barang_modul7.txt");
        List<Barang> daftarBarang = BacaDaftarDariFile(path);

        Console.WriteLine("--- Tambah Barang Baru (Refactored Input) ---");
        try
        {
            Barang bInput = InputHelper.AmbilInputBarang();
            TambahAtauUpdateBarang(daftarBarang, bInput);
            Console.WriteLine("Barang berhasil diproses.");
        }
        catch (StokNegatifException ex) { Console.WriteLine($"ERROR: {ex.Message}"); }
        catch (Exception ex) { Console.WriteLine($"ERROR input: {ex.Message}"); }

        Console.WriteLine("\n--- Cetak Info Barang Terakhir (via Interface) ---");
        IBarangPrinter pencetak = new PencetakBarang();
        pencetak.Cetak(daftarBarang.LastOrDefault());

        Console.WriteLine("\n--- Buat Barang Baru via Factory ---");
        Barang barangDariFactory = BarangFactory.BuatBarang("Makanan");
        TambahAtauUpdateBarang(daftarBarang, barangDariFactory);
        Console.WriteLine($"Barang dari factory ({barangDariFactory.KodeBarang}) diproses.");
        pencetak.Cetak(barangDariFactory);

        SimpanDaftarKeFile(daftarBarang, path);
        Console.WriteLine("\n--- Isi File ---");
        if (File.Exists(path)) { foreach (var baris in File.ReadAllLines(path)) Console.WriteLine(baris); }
        else { Console.WriteLine("File tidak ditemukan."); }
        Console.WriteLine("\n--- Selesai ---");
    }

    static List<Barang> BacaDaftarDariFile(string path)
    {
        var list = new List<Barang>();
        if (!File.Exists(path)) return list;

        var lines = File.ReadAllLines(path);
        for (int i = lines.Length > 0 && lines[0].StartsWith("Kode") ? 1 : 0; i < lines.Length; i++)
        {
            var parts = lines[i].Split('\t');
            if (parts.Length >= 4 && int.TryParse(parts[2], out int stok))
                list.Add(new Barang(parts[0], parts[1], stok, parts[3]));
        }
        return list;
    }

    static void TambahAtauUpdateBarang(List<Barang> list, Barang item)
    {
        var existing = list.FirstOrDefault(b => b.KodeBarang == item.KodeBarang);
        if (existing != null) { existing.NamaBarang = item.NamaBarang; existing.JumlahStok = item.JumlahStok; existing.Kategori = item.Kategori; }
        else { list.Add(item); }
    }

    static void SimpanDaftarKeFile(List<Barang> list, string path)
    {
        try
        {
            var content = "Kode\tNama\tStok\tKategori\n";
            content += string.Join("\n", list.Select(b => $"{b.KodeBarang}\t{b.NamaBarang}\t{b.JumlahStok}\t{b.Kategori}"));
            File.WriteAllText(path, content);
            Console.WriteLine($"Data disimpan di: {path} (total {list.Count} barang)");
        }
        catch (Exception ex) { Console.WriteLine($"Gagal simpan: {ex.Message}"); }
    }
}