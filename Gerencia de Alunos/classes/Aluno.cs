using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gerencia_de_Alunos.classes.interfaces;

namespace Gerencia_de_Alunos.classes
{
    public class Aluno : Identity
    {
        public string name { get; set; }
        public int id { get; }
        public int idade;

        public Curso curso;
        private Dictionary<string, float> notas = new Dictionary<string, float>();

       public Aluno(string name, int id, int idade, Curso curso)
        {
            this.name = name;
            this.id = id;
            this.idade = idade;
            this.curso = curso;

            init();
        }

        private void init()
        {
            foreach(string disciplina in curso.getDisciplinas())
            {
                notas.Add(disciplina, 0);
            }
        }

        public void showNotas()
        {
            foreach (string disciplina in curso.getDisciplinas())
            {
                Console.WriteLine("Disciplina: {0}\nNota:{1}\n", disciplina, notas[disciplina]);
            }
        }

        public void updateNota(string discip, float nota) => this.notas[discip] = nota;

        public void show() => Console.WriteLine( "Nome: {0}\nIdade: {1}\nMatricula: {2}\nCurso: {3}\n", name,idade,id,curso.name);
        
    }
}
