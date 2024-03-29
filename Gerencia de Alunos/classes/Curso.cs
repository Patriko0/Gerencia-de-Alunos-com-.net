﻿using System;
using System.Collections.Generic;
using System.Linq;
using Gerencia_de_Alunos.classes.interfaces;

namespace Gerencia_de_Alunos.classes
{
    public class Curso : Identity
    {
        public string name { get; set; }
        public int id { get; }
        private static int newId = 0;
        readonly private List<Disciplina> disciplinas = new List<Disciplina>();

        public Curso (string name)
        {
            this.name = name;
            this.id = Curso.newId++;
        }
        public List<Disciplina> getDisciplinas() => this.disciplinas;

        public List<string> getDisciplinasNames()
        {
            List<string> disciplinas = new List<string>();

            foreach(Disciplina disc in this.disciplinas) {
                disciplinas.Add(disc.name);
            }

            return disciplinas;
        }

        public void addDisciplina(Disciplina disc)
        {
            disciplinas.Add(disc);
        }


        public void removeDisciplina(int id)
        {
            List<Disciplina> disc = this.disciplinas.Where(item => item.id == id).ToList();
            if(disc.Count > 0) disciplinas.Remove(disc[0]);
        }


        public void show() => Console.WriteLine("\nNome: {0}\nId: {1}", name, id);

        public void showDiscip()
        {
            Console.WriteLine($"\nDisciplinas em {name}:\n");
            foreach (Disciplina discip in disciplinas) Console.WriteLine("- " + discip.name + "\n");
        }

        public void update(string name) => this.name = name;
    }
}
