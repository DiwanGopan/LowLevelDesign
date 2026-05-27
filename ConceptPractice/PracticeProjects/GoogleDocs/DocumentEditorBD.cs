using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConceptPractice.PracticeProjects.GoogleDocs
{
    public class DocumentEditorBD
    {
        public class DocumentEditor
        {
            private List<string> _documentElements;
            private string _renderDocument;

            public DocumentEditor()
            {
                _documentElements = new List<string>();
                _renderDocument = string.Empty;
            }

            // Adds text as a plain string
            public void AddText(string text)
            {
                _documentElements.Add(text);
            }

            // Adds an image represented by its file path
            public void AddImage(string imagePath)
            {
                _documentElements.Add(imagePath);
            }

            // Renders the document by checking the type of each element at runtime
            public string RenderDocument()
            {
                if (string.IsNullOrEmpty(_renderDocument))
                {
                    StringBuilder result = new StringBuilder();

                    foreach (string element in _documentElements)
                    {
                        if (element.Length > 4 && (element.EndsWith(".jpg") || element.EndsWith(".png")))
                        {
                            result.Append("[Image: ");
                            result.Append(element);
                            result.AppendLine("]");
                        }
                        else
                        {
                            result.AppendLine(element);
                        }
                    }
                    _renderDocument = result.ToString();
                }
                return _renderDocument;
            }

            public void SaveToFile()
            {
                try
                {
                    File.WriteAllText("document.txt", RenderDocument());
                    Console.WriteLine("Document saved to document.txt");
                }
                catch (IOException e)
                {
                    Console.WriteLine("Error: Unable to open file for writing.");
                    Console.WriteLine(e.ToString());
                }
            }

        }

        // Client
        public class DocumentEditorClient
        {
            public static void Run()
            {
                DocumentEditor editor = new DocumentEditor();

                editor.AddText("Hello, World!");
                editor.AddImage("picture.jpg");
                editor.AddText("This is a document editor.");

                Console.WriteLine(editor.RenderDocument());

                editor.SaveToFile();
            }
        }
    }


    /*
    |--------------------------------------------------------------------------
    | Why This Is a Bad Design
    |--------------------------------------------------------------------------
    |
    | This implementation works, but it violates multiple SOLID principles
    | and becomes difficult to maintain as the application grows.
    |
    |--------------------------------------------------------------------------
    | 1. Single Responsibility Principle (SRP) Violation
    |--------------------------------------------------------------------------
    |
    | A class should have only ONE reason to change.
    |
    | However, DocumentEditor is handling multiple responsibilities:
    |
    | 1. Managing document elements
    | 2. Rendering document content
    | 3. Detecting element types (.jpg / .png)
    | 4. Saving files to disk
    |
    | If rendering logic changes OR file saving changes,
    | this class must be modified.
    |
    | Because of this, the class has too many responsibilities.
    |
    |--------------------------------------------------------------------------
    | 2. Open/Closed Principle (OCP) Violation
    |--------------------------------------------------------------------------
    |
    | A class should be OPEN for extension
    | but CLOSED for modification.
    |
    | Problem:
    | The editor determines element types using conditional checks:
    |
    | if (element.EndsWith(".jpg") || element.EndsWith(".png"))
    |
    | Suppose tomorrow we want to support:
    | - PDF files
    | - GIF images
    | - Videos
    | - Tables
    | - Audio
    |
    | We must continuously MODIFY RenderDocument().
    |
    | This means the existing code is not closed for modification.
    */
}