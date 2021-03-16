using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using proiect_lab_9.domain;
using proiect_lab_9.repo;
using proiect_lab_9.ui;
using proiect_lab_9.service;
using proiect_lab_9.domain.validator;

namespace proiect_lab_9
{
    class Program
    {
        static void Main(string[] args)
        {
            // In Memory Repos
            //IRepo<long, Elev> eleviInMemoryRepo = new InMemoryRepo<long, Elev>(EleviValidator.GetValidator());
            //IRepo<long, Institutie_Invatamant> scoliInMemoryRepo = new InMemoryRepo<long, Institutie_Invatamant>(ScoliValidator.GetValidator());

            IRepo<long, Elev> eleviRepo = new EleviFileRepo("../../data/Elevi.txt");
            IRepo<long, Institutie_Invatamant> scoliRepo = new ScoliFileRepo("../../data/Scoli.txt");
            IRepo<long, Echipa> echipeRepo = new EchipeFileRepo("../../data/Echipe.txt");
            IRepo<long, Jucator> jucatoriRepo = new JucatorFileRepo("../../data/Jucatori.txt");
            IRepo<long, Meci> meciuriRepo = new MeciFileRepo("../../data/Meciuri.txt");
            IRepo<(long, long), JucatorActiv> jaRepo = new JucatorActivFileRepo("../../data/JucatoriActivi.txt");

            Service service = new Service(eleviRepo, scoliRepo, echipeRepo, jucatoriRepo, meciuriRepo, jaRepo);


            Ui ui = new Ui(service);
            ui.Run();


        }
    }
}
