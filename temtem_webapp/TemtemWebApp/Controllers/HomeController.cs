using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TemtemWebApp.Models;

namespace TemtemWebApp.Controllers
{
    public class HomeController : Controller
    {
        // connection string to connect with database
        readonly string connectionString = @"Data Source=DESKTOP-5TAUCHM\SQLEXPRESS; database=Temtem; Trusted_Connection=yes;";

        List<TemtemStatsViewModel> getAllTemtemStats()
        {
            List<TemtemStatsViewModel> temtemStatsList = new List<TemtemStatsViewModel>();
            string query = @"SELECT * FROM TemtemStatsView";
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        temtemStatsList.Add(new TemtemStatsViewModel
                        {
                            ID = Int32.Parse(reader[0].ToString()),
                            Name = reader[1].ToString(),
                            Number = reader[2].ToString(),
                            Trait1 = reader[3].ToString(),
                            Trait2 = reader[4].ToString(),
                            Type1 = reader[5].ToString(),
                            Type2 = reader[6].ToString(),
                            HP = Int32.Parse(reader[7].ToString()),
                            STA = Int32.Parse(reader[8].ToString()),
                            SPD = Int32.Parse(reader[9].ToString()),
                            ATK = Int32.Parse(reader[10].ToString()),
                            DEF = Int32.Parse(reader[11].ToString()),
                            SPATK = Int32.Parse(reader[12].ToString()),
                            SPDEF = Int32.Parse(reader[13].ToString()),
                        });
                    }
                    reader.Close();
                }
                connection.Close();
            }

            foreach (var temtem in temtemStatsList)
            {
                temtem.Total = temtem.HP + temtem.STA + temtem.SPD + temtem.ATK + temtem.DEF + temtem.SPATK + temtem.SPDEF;
            }
            List<TemtemStatsViewModel> temtemStatsSortedList = temtemStatsList.OrderBy(o => o.Number).ToList();
            return temtemStatsSortedList;
        }

        List<TemtemSimpleViewModel> getAllTemtemSimple()
        {
            List<TemtemSimpleViewModel> temtemSimpleList= new List<TemtemSimpleViewModel>();
            string query = @"SELECT * FROM TemtemSimpleView";
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        temtemSimpleList.Add(new TemtemSimpleViewModel
                        {
                            ID = Int32.Parse(reader[0].ToString()),
                            Name = reader[1].ToString(),
                            Number = reader[2].ToString(),
                            Image = reader[3].ToString(),
                            TypeName1 = reader[4].ToString(),
                            TypeIcon1 = reader[5].ToString(),
                            TypeName2 = reader[6].ToString(),
                            TypeIcon2 = reader[7].ToString(),
                        });
                    }
                    reader.Close();
                }
                connection.Close();
            }
            List<TemtemSimpleViewModel> temtemSimpleSortedList = temtemSimpleList.OrderBy(o => o.Number).ToList();
            return temtemSimpleSortedList;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ViewTemtemSimple()
        {
            return View(getAllTemtemSimple());
        }

        public ActionResult ViewTemtemStats()
        {
            return View(getAllTemtemStats());
        }

        public ActionResult ViewTemtemDetails(int id=1)
        {
            TemtemDetailsViewModel temtemDetails = new TemtemDetailsViewModel();
            string query = @"SELECT * FROM TemtemDetailsView WHERE ID=@id";
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@id", SqlDbType.Int).Value = id;
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        temtemDetails = new TemtemDetailsViewModel
                        {
                            ID = Int32.Parse(reader[0].ToString()),
                            Name = reader[1].ToString(),
                            Number = reader[2].ToString(),
                            Image = reader[3].ToString(),
                            LumaImage = reader[4].ToString(),
                            Trait1 = reader[5].ToString(),
                            Trait2 = reader[6].ToString(),
                            Type1Name = reader[7].ToString(),
                            Type1Icon = reader[8].ToString(),
                            Type1Defense = reader[9].ToString(),
                            Type2Name = reader[10].ToString(),
                            Type2Icon = reader[11].ToString(),
                            Type2Defense = reader[12].ToString(),
                            HP = Int32.Parse(reader[13].ToString()),
                            STA = Int32.Parse(reader[14].ToString()),
                            SPD = Int32.Parse(reader[15].ToString()),
                            ATK = Int32.Parse(reader[16].ToString()),
                            DEF = Int32.Parse(reader[17].ToString()),
                            SPATK = Int32.Parse(reader[18].ToString()),
                            SPDEF = Int32.Parse(reader[19].ToString()),
                            PreEvolution = reader[20].ToString(),
                            Evolution = reader[21].ToString(),
                        };
                    }
                    reader.Close();
                }
                connection.Close();
            }

            int[] dualType = new int[12];
            if (temtemDetails.Type2Defense == "")
            {
                temtemDetails.DualTypeDefense = temtemDetails.Type1Defense;
            }
            else
            {
                for (int i = 0; i < 12; i++)
                {
                    dualType[i] = (int) Char.GetNumericValue(temtemDetails.Type1Defense[i]) +
                                  (int) Char.GetNumericValue(temtemDetails.Type2Defense[i]);
                }
                temtemDetails.DualTypeDefense = string.Join("", dualType);
            }

            return View(temtemDetails);
        }
    }
}