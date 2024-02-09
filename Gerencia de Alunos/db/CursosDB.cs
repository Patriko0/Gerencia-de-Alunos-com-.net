using System;
using System.Collections.Generic;
using System.Linq;
using Gerencia_de_Alunos.classes;
using Gerencia_de_Alunos.classes.interfaces;

namespace Gerencia_de_Alunos.db
{
    public class CursosDB : CRUDProtocol
    {
        private static CursosDB dbQuery;
        private static List<Curso> cursos;

        private CursosDB()
        {
            init();
        }

        private void init()
        {
            cursos = new List<Curso>();
        }

        public static CursosDB connect()
        {
            if (!(dbQuery is null)) return CursosDB.dbQuery;

            CursosDB.dbQuery = new CursosDB();
            return CursosDB.dbQuery;
        }

        public void store(dynamic info) => cursos.Add(new Curso(info.name));

       
        public void show()
        {
            foreach (Curso curso in cursos)
            {
                curso.show();
            }
        }
        
        public bool find(int id)
        {
            Curso curs = getCurso(id);

            if (!(curs is null)) return true;

            Console.WriteLine("\nCurso inexistente!");
            return false;
        }

        public void delete(int id)
        {
            Curso curs = getCurso(id);
            cursos.Remove(curs);
        }


        
        public void update(int id, dynamic obj)
        {
            Curso curs = getCurso(id);
            curs.update(obj.newName);
        }


        public Curso getCurso(int id) => cursos.Where(item => item.id == id).FirstOrDefault();

    }
}
