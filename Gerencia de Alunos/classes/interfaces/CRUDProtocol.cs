namespace Gerencia_de_Alunos.classes.interfaces
{
    public interface CRUDProtocol
    {
        void store(dynamic info);
        void show();
        void update(int id, dynamic newInfo);
        void delete(int id);
        bool find(int id);
    }
}
