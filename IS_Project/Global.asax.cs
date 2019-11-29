using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using IS_Project.Models;

namespace IS_Project
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //Seed test and initial data

            InitDatabase();

        }


        void InitDatabase()
        {
            using (hospitaldbContext ctx = new hospitaldbContext())
            {

                // ctx yra visos duomenu bazes kontekstas

                // Jei DB objektas yra referencinamas per foregin key, tada galima tiesiai pasiekti per pvz: vart.Pacientas arba vart.Zinute.ToList()
                //Vartotojas vart = new Vartotojas()
                //{
                //    Vardas = "AAa",
                //    Pavarde = "bb",
                //    Elpastas = "aasd@g.com",
                //    TelNr = "8647456866",
                //    Adresas = new Adresas()
                //    {
                //        Gatve = "Skuodo",
                //        Miestas = "Skuodas",
                //        NamoNr = 21,
                //        PastoKodas = 456486,
                //    }
                //};

                //ctx.Vartotojas.Add(vart);
                //var pac = vart.Pacientas;
                //var zin = vart.Zinute.ToList();
                //ctx.SaveChanges();
                //int vartid = vart.VartotojasId; // Duombazes vartotojo id ID, veikia tik po SAVE!

                //var tmp = ctx.Vartotojas.ToList();
                Random rnd = new Random();



                //====== Mock data =======
                // ======= Drugs =========
                var drugs = new List<String>() {  "Tylenol", "Oxycodone", "Codeine", "Morphine",
                                            "Salbutamol", "Acetylsalicylic acid", "Ketamine",
                                            "Abacavir", "Abarelix", "Abemaciclib", "Abiraterone"};
                foreach (var drug in drugs)
                {
                    ctx.Vaistas.Add(new Vaistas() { Pavadinimas = drug, Kaina = (float)Math.Round(rnd.NextDouble() * 100, 2) });
                }
                ctx.SaveChanges();

                // ======= Incompability ========
                var id = ctx.Vaistas.LastOrDefault().VaistasId;
                ctx.NesuderinamasVaistas.Add(new NesuderinamasVaistas() { FkVaistasId1 = id - 6, FkVaistasId2 = id - 5 });
                ctx.NesuderinamasVaistas.Add(new NesuderinamasVaistas() { FkVaistasId1 = id - 1, FkVaistasId2 = id - 10 });
                ctx.NesuderinamasVaistas.Add(new NesuderinamasVaistas() { FkVaistasId1 = id - 1, FkVaistasId2 = id - 6 });
                ctx.SaveChanges();

                var tmp = ctx.Vaistas.ToList();

                // ======= Alergies ==========
                var alergs = new List<String>() {  "Anaphylaxis", "Penicillin alergija", "Aspirin alergija", "Morphine alergija",
                                            "Salbutamol alergija", "Acetylsalicylic acid alergija", "Ketamine alergija",
                                            "Abacavir alergija", "Abarelix alergija", "Abemaciclib alergija", "Abiraterone alergija"};
                foreach (var alergy in alergs)
                {
                    ctx.Alergija.Add(new Alergija() { Pavadinimas = alergy });
                }
                ctx.SaveChanges();

                // ======= Alergies-Drugs ======= 
                var drugId = ctx.Vaistas.LastOrDefault().VaistasId;
                var aleId = ctx.Alergija.LastOrDefault().AlergijaId;

                for (var i = 0; i < alergs.Count; i++)
                {
                    ctx.KomplikacijosAlergijaVaistas.Add(new KomplikacijosAlergijaVaistas() { FkAlergijaId = aleId - i, FkVaistasId = drugId - i });
                }
                ctx.SaveChanges();

                // ======== Sickness =========
                var sicks = new List<String>() {  "Plaučiū uždegimas", "Bronchitas", "Nekrozė", "Angina",
                                            "Smegenų sutrenkimas", "Insultas", "Širdies smugis",
                                            "Pneumonia", "HIV", "Tuberkuliozė", "Retinos atsiskyrimas"};
                foreach (var sick in sicks)
                {
                    ctx.Liga.Add(new Liga() { Pavadinimas = sick, Simptomai = "Nežinoma", IprastaTrukmeD = rnd.Next(1, 62) });
                }
                ctx.SaveChanges();

                // ====== Doctor Rooms ========
                var cnt = 100;
                for (var i = 1; i < cnt; i += 2)
                {
                    ctx.Kabinetas.Add(new Kabinetas() { KabNr = Convert.ToInt32(((i / 4).ToString() + i)) });
                }
                ctx.SaveChanges();

                // ====== Patient Rooms ========
                for (var i = 2; i < cnt; i += 2)
                {
                    ctx.Palata.Add(new Palata() { PalataNr = Convert.ToInt32(((i / 4).ToString() + i)), VietuSkaicius = rnd.Next(1, 8), UzimtaVietu = 0 });
                }
                ctx.SaveChanges();

                // ======== Users+Address =======

                var vardai = new List<String>() {   "Tomas", "Dikas", "Haris", "Jonas", "Petras", "Uruodas", "Jurgis",
                                            "Bobas", "Kentas", "Mantas", "Agne", "Karen", "Augustina", "Liveta", "Ona"};

                foreach (var vard in vardai)
                {
                    Vartotojas vart = new Vartotojas()
                    {
                        Vardas = vard,
                        Pavarde = "Mc" + vard,
                        Elpastas = vard + "@gmx.com",
                        TelNr = "+3706" + rnd.Next(1000000, 9999999),
                        Adresas = new Adresas()
                        {
                            Gatve = "Mažeikiu g.",
                            Miestas = "Kaunas",
                            NamoNr = rnd.Next(1, 199),
                            PastoKodas = rnd.Next(50000, 59999)
                        }
                    };
                    ctx.Vartotojas.Add(vart);
                }
                ctx.SaveChanges();


                // ======== Admins =======
                int uid = ctx.Vartotojas.LastOrDefault().VartotojasId;

                ctx.Administratorius.Add(new Administratorius()
                {
                    PrisijungimoAlias = ctx.Vartotojas.Find(uid - 14).Vardas + rnd.Next(1000, 9999),
                    PradetaDirbti = RandomDay(rnd),
                    Busena = (int)DarboBusenos.Dirbantis,
                    AdministratoriusId = uid - 14
                });

                ctx.Administratorius.Add(new Administratorius()
                {
                    PrisijungimoAlias = ctx.Vartotojas.Find(uid - 13).Vardas + rnd.Next(1000, 9999),
                    PradetaDirbti = RandomDay(rnd),
                    Busena = (int)DarboBusenos.Dirbantis,
                    AdministratoriusId = uid - 13
                });
                ctx.SaveChanges();


                // ======== Doctors =======
                ctx.Daktaras.Add(new Daktaras()
                {
                    Specializacija = (int)Specializacijos.Chirurgas,
                    PradetaDirbti = RandomDay(rnd),
                    Busena = (int)DarboBusenos.Dirbantis,
                    DaktarasId = uid - 12
                });

                ctx.Daktaras.Add(new Daktaras()
                {
                    Specializacija = (int)Specializacijos.Chirurgas,
                    PradetaDirbti = RandomDay(rnd),
                    Busena = (int)DarboBusenos.Dirbantis,
                    DaktarasId = uid - 11
                });

                ctx.Daktaras.Add(new Daktaras()
                {
                    Specializacija = (int)Specializacijos.Chirurgas,
                    PradetaDirbti = RandomDay(rnd),
                    Busena = (int)DarboBusenos.Dirbantis,
                    DaktarasId = uid - 10
                });

                ctx.Daktaras.Add(new Daktaras()
                {
                    Specializacija = (int)Specializacijos.Chirurgas,
                    PradetaDirbti = RandomDay(rnd),
                    Busena = (int)DarboBusenos.Dirbantis,
                    DaktarasId = uid - 9
                });

                ctx.Daktaras.Add(new Daktaras()
                {
                    Specializacija = (int)Specializacijos.Chirurgas,
                    PradetaDirbti = RandomDay(rnd),
                    Busena = (int)DarboBusenos.Dirbantis,
                    DaktarasId = uid - 8
                });
                ctx.SaveChanges();


                // ======== Patients =======
                for (var i = 0; i < vardai.Count; i++)
                {
                    ctx.Pacientas.Add(new Pacientas()
                    {
                        DraudimoNr = rnd.Next(111111111, 999999999),
                        GimimoData = RandomDay(rnd),
                        GimimoLaikas = RandomTimeSpan(rnd),
                        GimimoMiestas = "Vilnius",
                        GimLigoninėsPav = "Vilniaus ligonė",
                        PacientasId = uid - i
                    });

                    ctx.SaveChanges();
                }

            }
        }

        DateTime RandomDay(Random rnd)
        {
            DateTime start = new DateTime(1995, 1, 1);
            int range = (DateTime.Today - start).Days;
            var tmp = start.AddDays(rnd.Next(range));
            return tmp.Date;
        }

        DateTime RandomDayHour(Random rnd)
        {
            DateTime tmp = RandomDay(rnd);
            tmp = tmp.AddHours(8 + rnd.Next(0, 8));
            return tmp.Date;
        }

        TimeSpan RandomTimeSpan(Random rnd)
        {
            return new TimeSpan(0, 0, 0, rnd.Next(86400));
        }

    }
}

