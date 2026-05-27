using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptPractice.PracticeProjects.GoogleDocs
{
    public class DocumentEditorGD
    {
        // Interface for document elements
        public interface IDocumentElement
        {
            string Render();
        }

        // Concrete implementation for text elements
        public class TextElement : IDocumentElement
        {
            private readonly string _text;

            public TextElement(string text)
            {
                _text = text;
            }

            public string Render()
            {
                return _text;
            }

        }
        public class ImageElement : IDocumentElement
        {
            private readonly string _imagePath;

            public ImageElement(string imagePath)
            {
                _imagePath = imagePath;
            }

            public string Render()
            {
                return $"[Image: {_imagePath}]";
            }
        }

        public class NewLineElement : IDocumentElement
        {
            public string Render()
            {
                return Environment.NewLine;
            }

        }

        public class TabSpaceElement : IDocumentElement
        {
            public string Render()
            {
                return "\t";
            }
        }

        public class Document
        {
            private readonly List<IDocumentElement> _documentElements;

            public Document()
            {
                _documentElements = new List<IDocumentElement>();
            }

            public void AddElement(IDocumentElement element)
            {
                _documentElements.Add(element);
            }

            public string Render()
            {
                StringBuilder result = new StringBuilder();

                foreach (IDocumentElement element in _documentElements)
                {
                    result.Append(element.Render());
                }

                return result.ToString();
            }
        }


        public interface IPersistence
        {
            void Save(string data);
        }

        public class FileStorage : IPersistence
        {
            public void Save(string data)
            {
                try
                {
                    File.WriteAllText("document.txt", data);
                    Console.WriteLine("Document saved to document.txt");
                }
                catch (IOException e)
                {
                    Console.WriteLine("Error: Unable to open file for writing.");
                }
            }
        }

        public class DatabaseStorage : IPersistence
        {
            public void Save(string data)
            {
                Console.WriteLine("Saving document in database...");
            }
        }

        public class DocumentEditor
        {
            private readonly Document _document;
            private readonly IPersistence _storage;

            private string _renderDocument;

            public DocumentEditor(Document document, IPersistence storage)
            {
                _document = document;
                _storage = storage;
                _renderDocument = string.Empty;
            }

            public void AddText(string text)
            {
                _document.AddElement(new TextElement(text));
            }

            public void AddImage(string imagePath)
            {
                _document.AddElement(new ImageElement(imagePath));
            }

            public void AddNewLine()
            {
                _document.AddElement(new NewLineElement());
            }

            public void AddTabSpace()
            {
                _document.AddElement(new TabSpaceElement());
            }

            public string RenderDocument()
            {
                if (string.IsNullOrEmpty(_renderDocument))
                {
                    _renderDocument = _document.Render();
                }

                return _renderDocument;
            }

            public void SaveDocument()
            {
                _storage.Save(RenderDocument());
            }

        }

        // Client
        public class DocumentEditorClient
        {
            public static void Run()
            {
                Document document = new Document();

                IPersistence storage = new FileStorage();

                DocumentEditor editor = new DocumentEditor(document, storage);

                editor.AddText("Hello, world!");
                editor.AddNewLine();

                editor.AddText("This is a real-world document editor example.");
                editor.AddNewLine();

                editor.AddTabSpace();
                editor.AddText("Indented text after a tab space.");
                editor.AddNewLine();

                editor.AddImage("picture.jpg");

                Console.WriteLine(editor.RenderDocument());

                editor.SaveDocument();
            }
        }
    }
}

/*
|--------------------------------------------------------------------------
| Why This Is a Better Design
|--------------------------------------------------------------------------
|
| This implementation follows SOLID principles and proper
| Object-Oriented Design practices.
|
| Compared to the previous design, this version is:
| - More scalable
| - Easier to maintain
| - Easier to test
| - Easier to extend
|
|--------------------------------------------------------------------------
| 1. Single Responsibility Principle (SRP)
|--------------------------------------------------------------------------
|
| A class should have only one reason to change.
|
| Responsibilities are properly separated:
|
| IDocumentElement
| -> Defines rendering behavior.
|
| TextElement / ImageElement / NewLineElement
| -> Handle their own rendering logic.
|
| Document
| -> Stores document elements.
|
| IPersistence
| -> Handles saving operations.
|
| DocumentEditor
| -> Coordinates editor operations.
|
| Each class now has a single responsibility.
|
|--------------------------------------------------------------------------
| 2. Open/Closed Principle (OCP)
|--------------------------------------------------------------------------
|
| Software should be open for extension
| but closed for modification.
|
| Example:
| If we want to add:
| - VideoElement
| - TableElement
| - AudioElement
|
| We simply create a new class implementing:
|
| IDocumentElement
|
| Existing code does NOT need modification.
|
| This makes the design extensible.
|
|--------------------------------------------------------------------------
| 3. Liskov Substitution Principle (LSP)
|--------------------------------------------------------------------------
|
| Any derived class should be replaceable
| without breaking application behavior.
|
| Example:
|
| IDocumentElement element = new ImageElement("pic.jpg");
|
| OR
|
| IDocumentElement element = new TextElement("Hello");
|
| Both work correctly because all implementations
| follow the Render() contract.
|
|--------------------------------------------------------------------------
| 4. Interface Segregation Principle (ISP)
|--------------------------------------------------------------------------
|
| Interfaces should be small and focused.
|
| IDocumentElement
| -> Only contains Render()
|
| IPersistence
| -> Only contains Save()
|
| Classes are not forced to implement
| unnecessary methods.
|
|--------------------------------------------------------------------------
| 5. Dependency Inversion Principle (DIP)
|--------------------------------------------------------------------------
|
| High-level modules should depend on abstractions,
| not concrete implementations.
|
| DocumentEditor depends on:
|
| IPersistence
|
| instead of:
|
| FileStorage
|
| This allows easy replacement of storage systems:
|
| - FileStorage
| - DatabaseStorage
| - CloudStorage
|
| without changing DocumentEditor.
|
|--------------------------------------------------------------------------
| 6. Polymorphism Instead of Conditional Logic
|--------------------------------------------------------------------------
|
| The old design used:
| - if conditions
| - string checks
| - file extension checks
|
| This design uses polymorphism instead.
|
| Each object decides how it renders itself.
|
| This removes unnecessary conditional logic
| and improves maintainability.
|
|--------------------------------------------------------------------------
| 7. Loose Coupling
|--------------------------------------------------------------------------
|
| Classes communicate through interfaces,
| making the system loosely coupled.
|
| Benefits:
| - Easier testing
| - Easier maintenance
| - Easier extension
| - Better scalability
|
|--------------------------------------------------------------------------
| 8. Better Testability
|--------------------------------------------------------------------------
|
| Since dependencies are abstracted,
| mocking becomes easier during unit testing.
|
| Example:
|
| MockStorage : IPersistence
|
| can be used to test DocumentEditor
| without writing files to disk.
|
|--------------------------------------------------------------------------
| Final Conclusion
|--------------------------------------------------------------------------
|
| This design follows all SOLID principles:
|
| ✔ SRP  -> Separated responsibilities
| ✔ OCP  -> Easy to extend
| ✔ LSP  -> Replaceable implementations
| ✔ ISP  -> Small focused interfaces
| ✔ DIP  -> Depends on abstractions
|
| Main Improvement:
| Replaced conditional logic with
| abstraction and polymorphism.
|
| Result:
| Cleaner, scalable, maintainable,
| and production-ready code.
|
*/