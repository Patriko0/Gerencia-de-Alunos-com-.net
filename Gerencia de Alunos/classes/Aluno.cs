using System;
using System.Collections.Generic;
using Gerencia_de_Alunos.classes.interfaces;

namespace Gerencia_de_Alunos.classes
{
    public class Aluno : Identity
    {
        public string name { get; set; }
        public int id { get; }
        private static int newId = 0;
        public int idade;

        private Curso curso;
        private Dictionary<string, float> notas = new Dictionary<string, float>();

       public Aluno(string name, int idade, Curso curso)
        {
            this.name = name;
            this.id = newId++;
            this.idade = idade;
            this.curso = curso;

            init();
        }

        private void init()
        {
            foreach(string disciplina in curso.getDisciplinasNames())
            {
                notas.Add(disciplina, 0);
            }
        }

        public void showNotas()
        {
            foreach (string disciplina in curso.getDisciplinasNames())
            {
                Console.WriteLine("\nDisciplina: {0}\nNota:{1}\n", disciplina, notas[disciplina]);
            }
        }

        public void updateNota(string discip, float nota) => this.notas[discip] = nota;

        public void updateInfo(string name) => this.name = name;

        public void changeCurso(Curso curso)
        {
            List<Disciplina> newDiscips = curso.getDisciplinas();
            foreach (Disciplina discip in this.curso.getDisciplinas()) {
                if (!(newDiscips.Contains(discip))) this.notas.Remove(discip.name);
            }
            foreach(Disciplina discip in curso.getDisciplinas())
            {
                if (notas.ContainsKey(discip.name)) continue;
                notas.Add(discip.name, 0f);
            }
            this.curso = curso;
        }

        public void show() => Console.WriteLine( "\nNome: {0}\nIdade: {1}\nMatricula: {2}\nCurso: {3}\n", name,idade,id,curso.name);

        public void removeDisciplina(string discipName)
        {
            if(this.notas.ContainsKey(discipName)) this.notas.Remove(discipName);
        }
        
        public Curso getCurso() => this.curso;
        
    }
}
