using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gerencia_de_Alunos.classes.interfaces
{
    public abstract class screenProtocol
    {
        protected abstract int qtsActions();
        protected abstract void addAction(Action newAction, string name);
        public abstract void show();
        public abstract void showOptions();
    }
}
