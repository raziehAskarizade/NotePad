using NotePadProject.UndoRedoFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotePadProject
{
    class EditOperation
    {
        UndoRedoClass data;
        bool txtAreaTextChangeRequare = true;
        public EditOperation()
        {
            data = new UndoRedoClass();
        }
        public bool TxtAreaTextChangeRequare { get => txtAreaTextChangeRequare; set => txtAreaTextChangeRequare = value; }
        public string UndoClicked()
        {
            txtAreaTextChangeRequare = false;
            return data.undo();
        }
        public string RedoClicked()
        {
            txtAreaTextChangeRequare = false;
            return data.redo();
        }
        public void AddItem(string item)
        {
            data.AddItem(item);
        }
        public void CanUndo()
        {
            data.canUndo();
        }
        public void CanRedo()
        {
            data.canRedo();
        }
    }
}
