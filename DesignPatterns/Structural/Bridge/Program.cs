/*
 * The Bridge pattern is a structural design pattern that separates an object's interface from its implementation, 
 * allowing the two to vary independently. It allows the implementation of an object to be swapped out at runtime 
 * without affecting the clients that use the object.
 * 
 * The bridge design pattern is used to decouple the interfaces from implementation and hiding 
 * the implementation details from the client program.
 */

IDocumentRenderer pdfRenderer = new PdfRenderer();
DocumentViewer pdfViewer = new DocumentViewer(pdfRenderer);
pdfViewer.ShowDocument();

IDocumentRenderer wordRenderer = new WordRenderer();
DocumentViewer wordViewer = new DocumentViewer(wordRenderer);
wordViewer.ShowDocument();


interface IDocumentRenderer
{
    void RenderDocument();
}

class PdfRenderer : IDocumentRenderer
{
    public void RenderDocument()
    {
        Console.WriteLine("Rendering PDF document");
    }
}

class WordRenderer : IDocumentRenderer
{
    public void RenderDocument()
    {
        Console.WriteLine("Rendering Word document");
    }
}

class DocumentViewer
{
    private IDocumentRenderer _documentRenderer;
    public DocumentViewer(IDocumentRenderer documentRenderer)
    {
        _documentRenderer = documentRenderer;
    }
    public void ShowDocument()
    {
        _documentRenderer.RenderDocument();
    }
}

