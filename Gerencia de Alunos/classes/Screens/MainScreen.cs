namespace Gerencia_de_Alunos.classes.Screens
{
    public class MainScreen:Screen
    {
        protected DisciplinaScreen disciplinaScreen = new DisciplinaScreen();
        protected CursoScreen cursoScreen = new CursoScreen();
        protected AlunoScreen alunosScreen = new AlunoScreen();

        public MainScreen() {
            this.addAction(() => { this.cursoScreen.show(); }, "Gerenciar cursos");
            this.addAction(() => { this.disciplinaScreen.show(); }, "Gerenciar disciplinas");
            this.addAction(() => { this.alunosScreen.show(); }, "Gerenciar Alunos");
        }
    }
}
