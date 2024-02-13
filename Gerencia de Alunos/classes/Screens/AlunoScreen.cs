using System;
using System.Collections.Generic;
using System.Linq;
using Gerencia_de_Alunos.db;
using Gerencia_de_Alunos.services;

namespace Gerencia_de_Alunos.classes.Screens
{
    public class AlunoScreen:Screen
    {
        AlunosDB alunos = AlunosDB.connect();
        CursosDB cursos = CursosDB.connect();
        public AlunoScreen() {
            this.addAction(new Action(() => { read(); }), "Mostrar alunos");
            this.addAction(new Action(() => { showNota(); }), "Mostrar notas");
            this.addAction(new Action(() => { create(); }), "Criar aluno");
            this.addAction(new Action(() => { update(); }), "Editar alunos");
            this.addAction(new Action(() => { editNota(); }), "Editar notas");
            this.addAction(new Action(() => { delete(); }), "Deletar alunos");
        }

        public void create() {
            Console.WriteLine("\nEscreva o nome do aluno: ");
            string nome = Console.ReadLine();

            Console.WriteLine("\nEscreva a idade do aluno: ");
            int idade = int.Parse(Console.ReadLine());

            Console.WriteLine("\nCursos disponiveis: ");
            cursos.show();
            Console.WriteLine("\nDigite o id do curso do aluno");
            Curso curso = cursos.getCurso(int.Parse(Console.ReadLine()));

            alunos.store(new {nome, idade, curso});
            Console.WriteLine("\nAluno criado com sucesso!");
            Enter.pressEnter();
        }
        public void read() {
            alunos.show();
            Enter.pressEnter();
        }
        public void update()
        {
            Console.WriteLine("\nDigite o id do aluno que deseja modificar: ");
            int id = int.Parse(Console.ReadLine());

            if (!this.search(id)) return;

            Console.WriteLine("\nDigite o novo nome do aluno: ");
            string newName = Console.ReadLine();

            alunos.update(id, new { newName });

            Console.WriteLine("\nAluno modificado!");
            Enter.pressEnter();
        }

        public void delete()
        {
            Console.WriteLine("\nDigite o id do aluno que deseja deletar: ");
            int id = int.Parse(Console.ReadLine());

            if (!this.search(id)) return;
            alunos.delete(id);

            Console.WriteLine("\nAluno deletado!");
            Enter.pressEnter();
        }

        public void showNota()
        {
            Console.WriteLine("\nDigite o id do aluno que deseja ver as notas: ");
            int id = int.Parse(Console.ReadLine());

            if (!this.search(id)) return;

            alunos.showNota(id);

            Enter.pressEnter();
        }

        public void editNota()
        {
            Console.WriteLine("\nDigite o id do aluno que deseja editar a nota: ");
            int idAluno = int.Parse(Console.ReadLine());
            if (!this.search(idAluno)) return;

            List<Disciplina> disciplinas = alunos.getAluno(idAluno).getCurso().getDisciplinas();

            foreach (Disciplina disciplina in disciplinas) disciplina.show();

            Console.WriteLine("Escreva o id da disciplina que queira alterar a nota: ");
            int idDiscip = int.Parse(Console.ReadLine());
            List<Disciplina> discip = disciplinas.Where((disciplina) => disciplina.id == idDiscip).ToList();
            if(discip.Count() == 0)
            {
                Console.WriteLine("Disciplina não encontrada");
                return;
            }

            Console.WriteLine("Digite a nova nota: ");
            int nota = int.Parse(Console.ReadLine());

            alunos.updateNota(idAluno, discip[0].name, nota);
        }

        public bool search(int id)
        {
            if (!alunos.find(id))
            {
                Enter.pressEnter();
                return false;
            }
            return true;
        }
    }
}
