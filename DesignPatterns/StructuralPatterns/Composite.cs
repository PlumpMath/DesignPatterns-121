using System;
using System.Collections.Generic;

namespace AllIn.StructuralPatterns
{
    /*
    Когда объекты должны быть реализованы в виде иерархической древовидной структуры

    Когда клиенты единообразно должны управлять как целыми объектами, так и их составными частями.
        То есть целое и его части должны реализовать один и тот же интерфейс
         */

    class Composite
    {
        //Component
        public abstract class Component
        {
            protected string Name;

            protected Component(string name)
            {
                Name = name;
            }

            public virtual void Add(Component component) { }

            public virtual void Remove(Component component) { }

            public virtual void Print()
            {
                Console.WriteLine(Name);
            }
        }

        //Composite
        public class Directory : Component
        {
            private List<Component> components = new List<Component>();

            public Directory(string name) : base(name)
            {
            }

            public override void Add(Component component)
            {
                components.Add(component);
            }

            public override void Remove(Component component)
            {
                components.Remove(component);
            }

            public override void Print()
            {
                Console.WriteLine($"Chain : {Name}");

                Console.WriteLine("Subchains: ");

                foreach (Component component in components)
                {
                    component.Print();
                }
            }

            //Leaf
            public class File : Component
            {
                public File(string name) : base(name)
                {
                }
            }
        }
        
            //static void Main(string[] args)
            //{
            //    Component fileSystem = new Directory("Файловая система");
            //    // определяем новый диск
            //    Component diskC = new Directory("Диск С");
            //    // новые файлы
            //    Component pngFile = new File("12345.png");
            //    Component docxFile = new File("Document.docx");
            //    // добавляем файлы на диск С
            //    diskC.Add(pngFile);
            //    diskC.Add(docxFile);
            //    // добавляем диск С в файловую систему
            //    fileSystem.Add(diskC);
            //    // выводим все данные
            //    fileSystem.Print();
            //    Console.WriteLine();
            //    // удаляем с диска С файл
            //    diskC.Remove(pngFile);
            //    // создаем новую папку
            //    Component docsFolder = new Directory("Мои Документы");
            //    // добавляем в нее файлы
            //    Component txtFile = new File("readme.txt");
            //    Component csFile = new File("Program.cs");
            //    docsFolder.Add(txtFile);
            //    docsFolder.Add(csFile);
            //    diskC.Add(docsFolder);

            //    fileSystem.Print();
            //
        }
}
