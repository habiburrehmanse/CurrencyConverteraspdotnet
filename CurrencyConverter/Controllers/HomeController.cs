using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CurrencyConverter.Models;
using System.Data.SqlClient;
using System.Data;
using Newtonsoft.Json;

namespace CurrencyConverter.Controllers
{
    public class HomeController : Controller
    {
        public DBAccess dbContext { get; set; }

        public IActionResult Index()
        {
            var model = new List<ModelDTO>();
            var dataTable = new DataTable();
            using (SqlConnection connection = new SqlConnection(DBAccess.ConnectionString))
            {
                connection.Open();
                var sql = "Select * from VehicleDetail";
                var table = new DataTable();
                using (var da = new SqlDataAdapter(sql, connection))
                {
                    da.Fill(table);
                }
               var json = JsonConvert.SerializeObject(table);
                if (table.Rows.Count > 0)
                    model = JsonConvert.DeserializeObject<List<ModelDTO>>(json);


            }

            return View(model);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }
        [HttpPost]
        public IActionResult SaveRecord(ModelDTO model)
        {

            using (SqlConnection connection = new SqlConnection(DBAccess.ConnectionString))
            {
                string sql = $"Insert Into VehicleDetail (VehicleNo, ContainerNo, Detail, Weight,Bails,Location,RateInPak,Amount,RateInAED,CostInAED,TransportInPak,TransportRate,TransportCostInAED,DOCharges,MuncipleCharges,ClearnessCharges,TAX,TransportCharges,Total,PUC,Rate,Sale,Profit) Values " +
                    $"('{model.VehicleNo}', '{model.ContainerNo}','{model.Detail}','{model.Weight}','{model.Bails}', '{model.Location}','{model.RateInPak}','{model.Amount}','{model.RateInAED}', '{model.CostInAED}','{model.TransportInPak}','{model.TransportRate}'," +
                    $"'{model.TransportCostInAED}', '{model.DoCharges}','{model.MoncipleCharges}','{model.ClearnessCharges}','{model.TAX}', '{model.TransportCharges}','{model.TotalCharges}','{model.PUC}', '{model.Rate}','{model.Sale}','{model.Profit}')";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
                return View("Index");
            }


        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }

}
