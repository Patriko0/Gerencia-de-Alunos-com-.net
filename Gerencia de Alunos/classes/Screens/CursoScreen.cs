using System;
using Gerencia_de_Alunos.services;

namespace Gerencia_de_Alunos.classes.Screens
{
    public class CursoScreen:Screen
    {
        public CursoScreen()
        {
            this.addAction(new Action(() => { Console.WriteLine("Cursos..."); Enter.pressEnter(); }), "Mostrar Cursos");
            this.addAction(new Action(() => { Console.WriteLine("Criando Cursos..."); Enter.pressEnter(); }), "Criar Cursos");
            this.addAction(new Action(() => { Console.WriteLine("Editando Curso..."); Enter.pressEnter(); }), "Editar Cursos");
            this.addAction(new Action(() => { Console.WriteLine("Deletando Curso..."); Enter.pressEnter(); }), "Deletar Cursos");
        }
    }
}
