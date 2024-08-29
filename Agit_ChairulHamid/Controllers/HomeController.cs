using Agit_ChairulHamid.Data;
using Agit_ChairulHamid.Models;
using Agit_ChairulHamid.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net;
using System.Reflection.Metadata;
using System.Data;
using Microsoft.Data.Sqlite;
using Microsoft.AspNetCore.Mvc;
using Agit_ChairulHamid.Context;
using Microsoft.EntityFrameworkCore;

namespace Agit_ChairulHamid.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private static List<VMKonversi> _koversiData = new List<VMKonversi>();
        private readonly MyContext _context;

        public HomeController(ILogger<HomeController> logger, MyContext context)
        {
            _logger = logger;
            _context = context;
        }
        #region Task 1
        public IActionResult Index()
        {
            _koversiData.Clear();
            return View();
        }
        [HttpPost]
        public IActionResult PostData([FromBody] VMKonversi model)
        {
            try
            {
                var produksiHarian = new[]
                    {
                    model.Produksi1,
                    model.Produksi2,
                    model.Produksi3,
                    model.Produksi4,
                    model.Produksi5
                }.Select(p => p.GetValueOrDefault()).ToArray();
                int totalProduksi = produksiHarian.Sum();
                int rataRata = totalProduksi / 5;
                int sisa = totalProduksi % 5;

                var produksiDiperbaiki = Enumerable.Repeat(rataRata, 5).ToArray();
                var indeksTerbesar = produksiHarian
                    .Select((value, index) => new { Value = value, Index = index })
                    .OrderByDescending(x => x.Value)
                    .Select(x => x.Index)
                    .ToList();
                foreach (var index in indeksTerbesar)
                {
                    if (sisa <= 0)
                        break;
                    produksiDiperbaiki[index]++;
                    sisa--;
                }

                model.H_Produksi1 = produksiDiperbaiki[0];
                model.H_Produksi2 = produksiDiperbaiki[1];
                model.H_Produksi3 = produksiDiperbaiki[2];
                model.H_Produksi4 = produksiDiperbaiki[3];
                model.H_Produksi5 = produksiDiperbaiki[4]; 
                _koversiData.Add(model);
                return Json(new
                {
                    status = 200,
                    message = "Data berhasil ditambahkan!",
                    data = _koversiData,
                });
            }
            catch (Exception)
            {
                return Json(new { status = 500, message = "Gagal, Data tidak dapat dibaca. Silakan dicoba kembali!", data = _koversiData });
            }
        }
        #endregion
        #region Task 2
        public IActionResult Task2()
        {
            _koversiData.Clear();
            return View();
        }
        [HttpPost]
        public IActionResult PostDataTask2([FromBody] VMKonversi model)
        {
            try
            {
                var produksiHarian = new[]
                    {
                    model.Produksi1,
                    model.Produksi2,
                    model.Produksi3,
                    model.Produksi4,
                    model.Produksi5,
                    model.Produksi6,
                    model.Produksi7
                }.Select(p => p.GetValueOrDefault()).ToArray();

                int totalProduksi = produksiHarian.Sum();
                int hariKerja = produksiHarian.Count(x => x > 0);
                if (hariKerja == 0)
                {
                    return Json(new { status = 400, message = "Semua hari adalah hari libur, tidak ada produksi." });
                }

                int rataRata = totalProduksi / hariKerja;
                int sisa = totalProduksi % hariKerja;

                int[] produksiDiperbaiki = new int[7];
                for (int i = 0; i < 7; i++)
                {
                    if (produksiHarian[i] > 0)
                        produksiDiperbaiki[i] = rataRata;
                    else
                        produksiDiperbaiki[i] = 0;
                }
                var indeksTerbesar = produksiHarian
                    .Select((value, index) => new { Value = value, Index = index })
                    .Where(x => x.Value > 0)
                    .OrderByDescending(x => x.Value)
                    .Select(x => x.Index)
                    .ToList();
                foreach (var index in indeksTerbesar)
                {
                    if (sisa <= 0)
                        break;

                    produksiDiperbaiki[index]++;
                    sisa--;
                }

                model.H_Produksi1 = produksiDiperbaiki[0];
                model.H_Produksi2 = produksiDiperbaiki[1];
                model.H_Produksi3 = produksiDiperbaiki[2];
                model.H_Produksi4 = produksiDiperbaiki[3];
                model.H_Produksi5 = produksiDiperbaiki[4];
                model.H_Produksi6 = produksiDiperbaiki[5];
                model.H_Produksi7 = produksiDiperbaiki[6];

                _koversiData.Add(model);

                return Json(new
                {
                    status = 200,
                    message = "Data berhasil ditambahkan!",
                    data = _koversiData,
                });
            }
            catch (Exception)
            {
                return Json(new { status = 500, message = "Gagal, Data tidak dapat dibaca. Silakan dicoba kembali!", data = _koversiData });
            }
        }
        #endregion


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}