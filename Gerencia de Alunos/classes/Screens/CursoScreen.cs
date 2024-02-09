using System;
using Gerencia_de_Alunos.db;
using Gerencia_de_Alunos.services;

namespace Gerencia_de_Alunos.classes.Screens
{
    public class CursoScreen:Screen
    {
        private static CursosDB cursos = CursosDB.connect();
        public CursoScreen()
        {
            this.addAction(new Action(() => { read(); }), "Mostrar Cursos");
            this.addAction(new Action(() => { create(); }), "Criar Cursos");
            this.addAction(new Action(() => { update(); }), "Editar Cursos");
            this.addAction(new Action(() => { delete(); }), "Deletar Cursos");
        }

        public void create() {
            Console.WriteLine("\nEscreva o nome do curso: ");
            string name = Console.ReadLine();
            cursos.store(new {name});

            Console.WriteLine("\nCurso salva!");
            Enter.pressEnter();
        }
        public void read() { 
            cursos.show();
            Enter.pressEnter();
        }
        public void update() {
            Console.WriteLine("\nDigite o id do curso que deseja modificar: ");
            int id = int.Parse(Console.ReadLine());

            if (!this.search(id)) return;

            Console.WriteLine("\nDigite o novo nome do curso: ");
            string newName = Console.ReadLine();

            cursos.update(id, new { newName });

            Console.WriteLine("\nDisciplina modificada!");
            Enter.pressEnter();
        }
        public void delete() {
            Console.WriteLine("\nDigite o id do curso que deseja deletar: ");
            int id = int.Parse(Console.ReadLine());

            if (!this.search(id)) return;
            cursos.delete(id);

            Console.WriteLine("\nCurso deletado!");
            Enter.pressEnter();
        }
        private bool search(int id)
        {
            if (!cursos.find(id))
            {
                Enter.pressEnter();
                return false;
            }
            return true;
        }
    }
}
