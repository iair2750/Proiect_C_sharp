using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using proiect_lab_9.repo;
using proiect_lab_9.domain;

namespace proiect_lab_9.service
{
    class Service
    {
        private IRepo<long, Elev> repoElevi;
        private IRepo<long, Institutie_Invatamant> repoScoli;
        private IRepo<long, Echipa> repoEchipe;
        private IRepo<long, Jucator> repoJucatori;
        private IRepo<long, Meci> repoMeciuri;
        private IRepo<(long, long), JucatorActiv> repoJucatoriActivi;


        public Service(IRepo<long, Elev> repoElevi, IRepo<long, Institutie_Invatamant> repoScoli, IRepo<long, Echipa> repoEchipe,
            IRepo<long, Jucator> repoJucatori, IRepo<long, Meci> repoMeciuri, IRepo<(long, long), JucatorActiv> repoJucatoriActivi)
        {
            this.repoElevi = repoElevi;
            this.repoScoli = repoScoli;
            this.repoEchipe = repoEchipe;
            this.repoJucatori = repoJucatori;
            this.repoMeciuri = repoMeciuri;
            this.repoJucatoriActivi = repoJucatoriActivi;
        }

        public IEnumerable<(Elev,Institutie_Invatamant)> FindAllElevi()
        {
            return from e in repoElevi.FindAll()
                   from s in repoScoli.FindAll()
                   where e.IdScoala == s.Id
                   select (e, s);
        }

        public IEnumerable<Institutie_Invatamant> FindAllScoli()
        {
            return repoScoli.FindAll();
        }

        public IEnumerable<(Echipa, Institutie_Invatamant)> FindAllEchipe()
        {
            return from e in repoEchipe.FindAll()
                   from s in repoScoli.FindAll()
                   where e.IdScoala == s.Id
                   select (e, s);
        }

        public IEnumerable<(Jucator, Echipa, Institutie_Invatamant)> FindAllJucatori()
        {
            return from j in repoJucatori.FindAll()
                   from e in repoEchipe.FindAll()
                   from s in repoScoli.FindAll()
                   where j.IdEchipa == e.Id && j.IdScoala == s.Id
                   select (j, e, s);
        }

        public IEnumerable<(Meci, Echipa, Echipa)> FindAllMeciuri()
        {
            return from m in repoMeciuri.FindAll()
                   from e1 in repoEchipe.FindAll()
                   from e2 in repoEchipe.FindAll()
                   where m.Gazde == e1.Id && m.Oaspeti == e2.Id
                   select (m, e1, e2);
        }

        public IEnumerable<(JucatorActiv, Jucator, Meci, Echipa, Echipa)> FindAllJucatoriActivi()
        {
            return from ja in repoJucatoriActivi.FindAll()
                   from j in repoJucatori.FindAll()
                   from m in repoMeciuri.FindAll()
                   from e1 in repoEchipe.FindAll()
                   from e2 in repoEchipe.FindAll()
                   where ja.IdJucator == j.Id && ja.IdMeci == m.Id && m.Gazde == e1.Id && m.Oaspeti == e2.Id
                   select (ja, j, m, e1, e2);
        }

        public IEnumerable<Jucator> JucatoriEchipa(long id)
        {
            Echipa e = repoEchipe.FindOne(id);
            return repoJucatori.FindAll().Where(j => j.IdEchipa == e.Id);
        }

        public IEnumerable<(Jucator, JucatorActiv)> JucatoriActiviEchipaMeci(long idEchipa, long idMeci)
        {
            Echipa echipa = repoEchipe.FindOne(idEchipa);
            Meci meci = repoMeciuri.FindOne(idMeci);
            if (echipa.Id != meci.Oaspeti && echipa.Id != meci.Gazde)
                throw new ServiceException("Aceasta echipa nu a participat la acest meci\n");
            return from ja in repoJucatoriActivi.FindAll()
                   from j in repoJucatori.FindAll()
                   where ja.IdMeci == meci.Id && ja.IdJucator == j.Id && j.IdEchipa == echipa.Id
                   select (j, ja);
        }

        public IEnumerable<(Meci, Echipa, Echipa)> MeciuriPerioada(DateTime start, DateTime end)
        {
            return from m in repoMeciuri.FindAll()
                   from e1 in repoEchipe.FindAll()
                   from e2 in repoEchipe.FindAll()
                   where m.Data >= start && m.Data <= end && e1.Id == m.Gazde && e2.Id == m.Oaspeti
                   select (m, e1, e2);
        }

        public (int, int, Echipa, Echipa, Meci) ScorMeci(long idMeci)
        {
            Meci meci = repoMeciuri.FindOne(idMeci);
            int scorOaspeti = 0,
                scorGazde = 0;
            foreach (var x in (
                from ja in repoJucatoriActivi.FindAll()
                from j in repoJucatori.FindAll()
                where ja.IdMeci == meci.Id && ja.IdJucator == j.Id
                select (ja, j)
                ))
            {
                if (x.j.IdEchipa == meci.Oaspeti)
                    scorOaspeti += x.ja.PuncteInscrise;
                else
                    scorGazde += x.ja.PuncteInscrise;
            }
            return (scorGazde, scorOaspeti, repoEchipe.FindOne(meci.Gazde), repoEchipe.FindOne(meci.Oaspeti), meci);
        }

        public void AddElev(string nume, long idScoala)
        {
            Elev e = new Elev(nume, repoScoli.FindOne(idScoala).Id);
            repoElevi.Save(e);
        }

        public void AddScoala(string nume)
        {
            Institutie_Invatamant i = new Institutie_Invatamant(nume);
            repoScoli.Save(i);
        }

        public void AddEchipa(string nume, long idScoala)
        {
            Echipa e = new Echipa(nume, repoScoli.FindOne(idScoala).Id);
            repoEchipe.Save(e);
        }

        public void AddJucator(long idElev, long idEchipa)
        {
            Elev elev = repoElevi.FindOne(idElev);
            Echipa echipa = repoEchipe.FindOne(idEchipa);
            if (elev.IdScoala != echipa.IdScoala)
                throw new ServiceException("Elevul si echipa selectate nu apartin aceleiasi scoli\n");
            Jucator j = new Jucator(elev, echipa.Id);
            repoJucatori.Save(j);
        }

        public void AddMeci(long echipaGazde, long echipaOaspeti, DateTime date)
        {
            Meci m = new Meci(repoEchipe.FindOne(echipaGazde).Id, repoEchipe.FindOne(echipaOaspeti).Id, date);
            repoMeciuri.Save(m);
        }

        public void AddJucatorActiv(long idJucator, long idMeci, int puncteInscrise, string tip)
        {
            try
            {
                Tip tipCurent = (Tip)Enum.Parse(typeof(Tip), tip);
                Jucator jucator = repoJucatori.FindOne(idJucator);
                Meci meci = repoMeciuri.FindOne(idMeci);
                if (jucator.IdEchipa != meci.Oaspeti && jucator.IdEchipa != meci.Gazde)
                    throw new ServiceException("Jucatorul selectat nu participa la acest meci\n");
                JucatorActiv ja = new JucatorActiv(jucator.Id, meci.Id, puncteInscrise, tipCurent);
                repoJucatoriActivi.Save(ja);
            }
            catch (ArgumentException)
            {
                throw new ServiceException("Tip jucator activ este invalid!\n");    
            }
        }

    }
}
