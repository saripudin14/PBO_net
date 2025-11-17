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

        List<Barang> daftarBarang = new List<Barang>
        {
            new Barang("B001", "Laptop", 30, "Elektronik"),
            new Barang("B002", "Smartphone", 60, "Elektronik"),
            new Barang("B003", "Kulkas", 20, "Elektronik")
        };

        Console.WriteLine("--- Tambah Barang Baru (Refactored Input) ---");
        try
        {
            Barang bInput = InputHelper.AmbilInputBarang();
            daftarBarang.Add(bInput);
            Console.WriteLine("Barang berhasil ditambahkan ke daftar.");
        }
        catch (StokNegatifException ex)
        {
            Console.WriteLine($"ERROR: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"ERROR input: {ex.Message}");
        }

        Console.WriteLine("\n--- Cetak Info Barang Baru (via Interface) ---");
        IBarangPrinter pencetak = new PencetakBarang();
        pencetak.Cetak(daftarBarang.LastOrDefault());

        Console.WriteLine("\n--- Buat Barang Baru via Factory ---");
        Barang barangDariFactory = BarangFactory.BuatBarang("Makanan");
        daftarBarang.Add(barangDariFactory);
        Console.WriteLine("Barang dari factory berhasil ditambahkan.");

        pencetak.Cetak(barangDariFactory);

        string path = Path.Combine(Directory.GetCurrentDirectory(), "data_barang_modul7.txt");

        try
        {
            File.WriteAllText(path, "Kode\tNama\tStok\tKategori\n");
            foreach (var barang in daftarBarang)
            {
                File.AppendAllText(path, $"{barang.KodeBarang}\t{barang.NamaBarang}\t{barang.JumlahStok}\t{barang.Kategori}\n");
            }
            Console.WriteLine($"Data disimpan di: {path}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Gagal simpan: {ex.Message}");
        }

        if (File.Exists(path))
        {
            try
            {
                var isi = File.ReadAllLines(path);
                foreach (var baris in isi)
                {
                    Console.WriteLine(baris);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Gagal baca: {ex.Message}");
            }
        }
        else
        {
            Console.WriteLine($"File {path} tidak ditemukan.");
        }

        Console.WriteLine("\n--- Selesai ---");
    }
}