using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotePadProject.UndoRedoFolder
{
    public class UndoRedoClass
    {
        Stack<string> Undo;
        Stack<string> Redo;
        public UndoRedoClass()
        {
            Stack<string> Undo = new Stack<string>();
            Stack<string> Redo = new Stack<string>();
        }
        public void Clear()
        {
            Undo.Clear();
            Redo.Clear();
        }
        public void AddItem(string item)
        {
            Undo.Push(item);
        }
        public string undo()
        {
            string item = Undo.Pop();
            Redo.Push(item);
            return Undo.First();
        }
        public string redo()
        {
            //is push empty or not?
            if (Redo.Count == 0)
                return Undo.First();
            string item = Redo.Pop();
            Undo.Push(item);
            return Undo.First();
        }
        public bool canUndo()
        {
            return Undo.Count > 1;
        }
        public bool canRedo()
        {
            return Undo.Count > 0;
        }
        public List<string> UndoList()
        {
            return Undo.ToList();
        }
        public List<string> RedoList()
        {
            return Redo.ToList();
        }
    }
}
