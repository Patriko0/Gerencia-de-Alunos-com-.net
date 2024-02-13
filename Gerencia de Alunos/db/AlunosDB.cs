using System;
using System.Collections.Generic;
using System.Linq;
using Gerencia_de_Alunos.classes;
using Gerencia_de_Alunos.classes.interfaces;

namespace Gerencia_de_Alunos.db
{
    public class AlunosDB : CRUDProtocol
    {
        private static AlunosDB dbQuery;
        private static List<Aluno> alunos;

        private AlunosDB() {
            this.init();
        }

        private void init()
        {
            alunos = new List<Aluno>();
        }

        public static AlunosDB connect()
        {
            if (!(dbQuery is null)) return AlunosDB.dbQuery;

            AlunosDB.dbQuery = new AlunosDB();
            return AlunosDB.dbQuery;
        }

        public void delete(int id)
        {
            Aluno aluno = getAluno(id);
            alunos.Remove(aluno);

        }

        public bool find(int id)
        {
            Aluno aluno = getAluno(id);

            if (!(aluno is null)) return true;

            Console.WriteLine("\nAluno inexistente!");
            return false;
        }

        public void show()
        {
            foreach (Aluno aluno in alunos)
            {
                aluno.show();
            }
        }

        public void store(dynamic info) => alunos.Add(new Aluno(info.nome, info.idade, info.curso)); 

        public void update(int id, dynamic newInfo)
        {
            Aluno aluno = getAluno(id);
            aluno.updateInfo(newInfo.nome);
        }

        public void updateNota(int id, string disciplina, int nota)
        {
            Aluno aluno = getAluno(id);
            aluno.updateNota(disciplina, nota);
        }

        public void changeCurso(int id, Curso curso)
        {
            Aluno aluno = getAluno(id);
            aluno.changeCurso(curso);
        }

        public void showNota(int id)
        {
            Aluno aluno = getAluno(id);
            aluno.showNotas();
        }

        public static void deleteDisciplina(string discipName)
        {
            foreach (Aluno aluno in alunos) aluno.removeDisciplina(discipName);
        }

        public Aluno getAluno(int id) => alunos.Where(item => item.id == id).FirstOrDefault();
    }
}
