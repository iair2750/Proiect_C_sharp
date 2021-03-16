using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using proiect_lab_9.service;
using proiect_lab_9.repo;
using proiect_lab_9.domain.validator;

namespace proiect_lab_9.ui
{
    class Ui
    {
        private Service service;
        private string Meniu
        {
            get
            {
                return
                    "\tMeniu principal:\n" +
                    "0. Iesire\n" +
                    "1. Adauga\n" +
                    "2. Afiseaza\n" +
                    "3. Afiseaza jucatorii unei echipe\n" +
                    "4. Afiseaza jucatorii activi ai unei echipe de la un anumit meci\n" +
                    "5. Afiseaza meciurile dintr-o perioada calendaristica\n" +
                    "6. Scorul unui meci\n";
            }
        }

        private void AddElev()
        {
            try
            {
                Console.Write("Da nume elev: ");
                string nume = Console.ReadLine();
                Console.Write("Da id scoala: ");
                long idScoala = long.Parse(Console.ReadLine());
                service.AddElev(nume, idScoala);
                Console.WriteLine("Elevul a fost salvat\n");
            }
            catch (FormatException)
            {
                Console.WriteLine("Trebuie sa dati un numar\n");
            }
            catch(ValidationException ve)
            {
                Console.WriteLine(ve.Message);
            }
            catch(RepoException re)
            {
                Console.WriteLine(re.Message);
            }
        }
        
        private void AddScoala()
        {
            try
            {
                Console.Write("Da nume scoala: ");
                string nume = Console.ReadLine();
                service.AddScoala(nume);
                Console.WriteLine("Scoala a fost salvata\n");
            }
            catch (ValidationException ve)
            {
                Console.WriteLine(ve.Message);
            }
            catch (RepoException re)
            {
                Console.WriteLine(re.Message);
            }
        }
        
        private void AddEchipa()
        {
            try
            {
                Console.Write("Da nume echipa: ");
                string nume = Console.ReadLine();
                Console.Write("Da id scoala: ");
                long idScoala = long.Parse(Console.ReadLine());
                service.AddEchipa(nume, idScoala);
                Console.WriteLine("Echipa a fost salvata\n");
            }
            catch (FormatException)
            {
                Console.WriteLine("Trebuie sa dati un numar\n");
            }
            catch (ValidationException ve)
            {
                Console.WriteLine(ve.Message);
            }
            catch (RepoException re)
            {
                Console.WriteLine(re.Message);
            }
        }
        
        private void AddJucator()
        {
            try
            {
                Console.Write("Da id elev: ");
                long idElev = long.Parse(Console.ReadLine());
                Console.Write("Da id echipa: ");
                long idEchipa = long.Parse(Console.ReadLine());
                service.AddJucator(idElev, idEchipa);
                Console.WriteLine("Jucatorul a fost salvat\n");
            }
            catch (FormatException)
            {
                Console.WriteLine("Trebuie sa dati un numar\n");
            }
            catch (ValidationException ve)
            {
                Console.WriteLine(ve.Message);
            }
            catch (RepoException re)
            {
                Console.WriteLine(re.Message);
            }
        }
        
        private void AddMeci()
        {
            try
            {
                Console.Write("Da id echipa gazda: ");
                long gazda = long.Parse(Console.ReadLine());
                Console.Write("Da id echipa oaspete: ");
                long oaspete = long.Parse(Console.ReadLine());
                Console.Write("Da data: ");
                DateTime date = DateTime.Parse(Console.ReadLine());
                service.AddMeci(gazda, oaspete, date);
                Console.WriteLine("Meciul a fost salvat\n");
            }
            catch (Exception e)
            {
                if (e is FormatException || e is RepoException || e is ValidationException)
                {
                    Console.WriteLine(e.Message);
                    return;
                }
                throw e;
            }
        }
        
        private void AddJA()
        {
            try
            {
                Console.Write("Da id jucator: ");
                long idJucator = long.Parse(Console.ReadLine());
                Console.Write("Da id meci: ");
                long idMeci = long.Parse(Console.ReadLine());
                Console.Write("Da numarul de puncte inscrise: ");
                int pct = int.Parse(Console.ReadLine());
                Console.Write("Da tipul (Rezerva/Participant): ");
                string tip = Console.ReadLine();
                service.AddJucatorActiv(idJucator, idMeci, pct, tip);
                Console.WriteLine("Jucatorul activ a fost salvat\n");
            }
            catch (Exception e)
            {
                if (e is FormatException || e is RepoException || e is ValidationException || e is ServiceException)
                {
                    Console.WriteLine(e.Message);
                    return;
                }
                throw e;
            }
        }

        private void Adauga()
        {
            Console.WriteLine();
            string optiuni = "\tMeniu adaugare:\n0. Iesire\n1. Elev\n2. Scoala\n3. Echipa\n4. Jucator\n5. Meci\n6. Jucator activ\n";
            int cmd;
            Console.Write(optiuni);
            while (true)
            {
                Console.Write("Da comanda: ");
                try
                {
                    cmd = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Comanda trebuie sa fie un numar din meniu!\n");
                    Console.Write(optiuni);
                    continue;
                }
                switch (cmd)
                {
                    case 0:
                        return;
                    case 1:
                        // elev
                        AddElev();
                        break;
                    case 2:
                        //Scoala
                        AddScoala();
                        break;
                    case 3:
                        // Echipa
                        AddEchipa();
                        break;
                    case 4:
                        // Jucator
                        AddJucator();
                        break;
                    case 5:
                        // Meci
                        AddMeci();
                        break;
                    case 6:
                        // Jucator activ
                        AddJA();
                        break;
                    default:
                        Console.WriteLine("Comanda invalida!\n");
                        break;
                }
            }
        }

        private void Afiseaza()
        {
            Console.WriteLine("afis tufis");
            string optiuni = "\tMeniu afisare:\n0. Iesire\n1. Elevi\n2. Scoli\n3. Echipe\n4. Jucatori\n5. Meciuri\n6. Jucatori activi\n";
            int cmd;
            Console.Write(optiuni);
            while (true)
            {
                Console.WriteLine();
                Console.Write("Da comanda: ");
                try
                {
                    cmd = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Comanda trebuie sa fie un numar din meniu!\n");
                    Console.Write(optiuni);
                    continue;
                }
                switch (cmd)
                {
                    case 0:
                        return;
                    case 1:
                        // elevi
                        foreach (var elev in service.FindAllElevi())
                            Console.WriteLine(elev.Item1 + " (" + elev.Item2 + ')');
                        break;
                    case 2:
                        //Scoli
                        foreach (var scoala in service.FindAllScoli())
                            Console.WriteLine(scoala);
                        break;
                    case 3:
                        // Echipe
                        foreach (var echipa in service.FindAllEchipe())
                            Console.WriteLine(echipa.Item1 + " (" + echipa.Item2 + ')');
                        break;
                    case 4:
                        // Jucatori
                        foreach (var jucatori in service.FindAllJucatori())
                            Console.WriteLine(jucatori.Item1 + " - " + jucatori.Item2.Nume + " (" + jucatori.Item3 + ")");
                        break;
                    case 5:
                        // Meciuri
                        foreach (var meciuri in service.FindAllMeciuri())
                            Console.WriteLine(meciuri.Item1 + " (" + meciuri.Item2.Nume + " vs " + meciuri.Item3.Nume + ")");
                        break;
                    case 6:
                        // Jucatori activi
                        foreach (var ja in service.FindAllJucatoriActivi())
                            Console.WriteLine(ja.Item2 + " -> " + ja.Item1.TipCurent + ", " + ja.Item1.PuncteInscrise + " pct. (" +
                                ja.Item4.Nume + " vs " + ja.Item5.Nume + " -  " + ja.Item3.Data.ToShortDateString() + ")");
                        break;
                    default:
                        Console.WriteLine("Comanda invalida!\n");
                        break;
                }
            }
        }

        private void JucatoriEchipa()
        {
            try
            {
                Console.Write("Da id echipa: ");
                long id = long.Parse(Console.ReadLine());
                foreach(var jucator in service.JucatoriEchipa(id))
                    Console.WriteLine(jucator);
            }
            catch (FormatException)
            {
                Console.WriteLine("Trebuie sa dati un numar\n");
            }
            catch (RepoException re)
            {
                Console.WriteLine(re.Message);
            }
        }

        private void JucatoriActiviEchipaMeci()
        {
            try
            {
                Console.Write("Da id echipa: ");
                long idEchipa = long.Parse(Console.ReadLine());
                Console.Write("Da id meci: ");
                long idMeci = long.Parse(Console.ReadLine());
                foreach (var jucator in service.JucatoriActiviEchipaMeci(idEchipa, idMeci))
                    Console.WriteLine(jucator.Item1+" -> "+jucator.Item2.TipCurent+" "+jucator.Item2.PuncteInscrise+" pct.");
            }
            catch (FormatException)
            {
                Console.WriteLine("Trebuie sa dati un numar\n");
            }
            catch (RepoException re)
            {
                Console.WriteLine(re.Message);
            }
            catch (ServiceException n)
            {
                Console.WriteLine(n.Message);
            }
        }

        private void MeciuriPerioada()
        {
            try
            {
                Console.Write("Da data inceput perioada: ");
                DateTime start = DateTime.Parse(Console.ReadLine());
                Console.Write("Da data sfarsit perioada: ");
                DateTime end = DateTime.Parse(Console.ReadLine());
                foreach (var meci in service.MeciuriPerioada(start, end))
                    Console.WriteLine(meci.Item1 + " -> " + meci.Item2.Nume + " vs " + meci.Item3.Nume);
            }
            catch (FormatException fe)
            {
                Console.WriteLine(fe.Message);
            }
        }

        private void ScorMeci()
        {
            try
            {
                Console.Write("Da id meci: ");
                long idMeci = long.Parse(Console.ReadLine());
                var rasp = service.ScorMeci(idMeci);
                Console.WriteLine(rasp.Item1 + " - " + rasp.Item2 + " " + rasp.Item3.Nume + " vs " + rasp.Item4.Nume + " " + rasp.Item5.Data.ToShortDateString());
            }
            catch (FormatException)
            {
                Console.WriteLine("Trebuie sa dati un numar\n");
            }
            catch (RepoException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public Ui(Service service)
        {
            this.service = service;
        }

        public void Run()
        {
            Console.Write(Meniu);
            int cmd;
            while(true)
            {
                Console.WriteLine();
                Console.Write("Da comanda: ");
                try
                {
                    cmd = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Comanda trebuie sa fie un numar din meniu!\n");
                    Console.Write(Meniu);
                    continue;
                }

                switch (cmd)
                {
                    case 0:
                        return;
                    case 1:
                        Adauga();
                        Console.WriteLine();
                        Console.Write(Meniu);
                        break;
                    case 2:
                        Afiseaza();
                        Console.WriteLine();
                        Console.Write(Meniu);
                        break;
                    case 3:
                        //"3. Afiseaza jucatorii unei echipe\n"
                        JucatoriEchipa();
                        break;
                    case 4:
                        //"4. Afiseaza jucatorii activi ai unei echipe de la un anumit meci\n"
                        JucatoriActiviEchipaMeci();
                        break;
                    case 5:
                        //"5. Afiseaza meciurile dintr-o perioada calendaristica\n"
                        MeciuriPerioada();
                        break;
                    case 6:
                        //"6. Scorul unui meci\n"
                        ScorMeci();
                        break;
                    default:
                        Console.WriteLine("Comanda invalida!\n");
                        break;
                }
            }
        }

    }
}
