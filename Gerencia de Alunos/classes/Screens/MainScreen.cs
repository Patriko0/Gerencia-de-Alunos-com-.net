using System;

namespace Gerencia_de_Alunos.classes.Screens
{
    public class MainScreen:Screen
    {
        protected AlunoScreen alunosScreen = new AlunoScreen();
        protected DisciplinaScreen disciplinaScreen = new DisciplinaScreen();
        protected CursoScreen cursoScreen = new CursoScreen();

        public MainScreen() {
            this.addAction(() => { this.cursoScreen.show(); }, "Gerenciar cursos");
            this.addAction(() => { this.disciplinaScreen.show(); }, "Gerenciar disciplinas");
            this.addAction(() => { this.alunosScreen.show(); }, "Gerenciar Alunos");
        }
    }
}
