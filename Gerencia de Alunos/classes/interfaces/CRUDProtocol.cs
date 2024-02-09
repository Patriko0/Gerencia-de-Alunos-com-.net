namespace Gerencia_de_Alunos.classes.interfaces
{
    public interface CRUDProtocol
    {
        void store(string name, int carg_hr);
        void show();
        void update(int id, string newName, int? newInfo);
        void delete(int id);
        bool find(int id);
    }
}
