using System;
using System.Collections.Generic;
using System.Linq;
using Gerencia_de_Alunos.classes;
using Gerencia_de_Alunos.classes.interfaces;

namespace Gerencia_de_Alunos.db
{
    public class DisciplinasDB: CRUDProtocol
    {
        private static DisciplinasDB dbQuery;
        private static List<Disciplina> disciplinas;

        private DisciplinasDB()
        {
            init();
        }

        private void init()
        {
            disciplinas = new List<Disciplina>();
        }

        public static DisciplinasDB connect()
        {
            if (!(dbQuery is null)) return DisciplinasDB.dbQuery;

            DisciplinasDB.dbQuery = new DisciplinasDB();
            return DisciplinasDB.dbQuery;
        }

        public void store(dynamic info) => disciplinas.Add(new Disciplina(info.name, info.carg_hr));

        public void update(int id, dynamic info)
        {
            Disciplina disc = getDisciplina(id);

            disc.update(info.newName, (info.newCargHr == 0) ? null : info.newCargHr);
        }

        public void delete(int id)
        {
            Disciplina disc = getDisciplina(id);
            CursosDB.deleteDisciplina(id);
            AlunosDB.deleteDisciplina(disc.name);

            disciplinas.Remove(disc);
        }

        public void show()
        {
            foreach(Disciplina disciplina in disciplinas)
            {
                disciplina.show();
            }
        }

        public bool find(int id)
        {
            Disciplina disc = getDisciplina(id);

            if (!(disc is null)) return true;
            
            Console.WriteLine("\nDisciplina inexistente!");
            return false;   
        }

        public Disciplina getDisciplina(int id) => disciplinas.Where(item => item.id == id).FirstOrDefault();
    }
}
