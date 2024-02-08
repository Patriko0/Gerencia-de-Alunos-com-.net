namespace Gerencia_de_Alunos.classes.interfaces
{
    public interface Identity
    {
        string name { get; set; }
        int id { get; }

        void show();
    }
}
