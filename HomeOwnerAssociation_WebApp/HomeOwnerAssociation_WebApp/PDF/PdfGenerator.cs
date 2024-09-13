using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using Microsoft.JSInterop;

namespace HomeOwnerAssociation_WebApp.PDF
{
    public class PdfGenerator
    {

        public void DownloadPdf(IJSRuntime jS, string fileName, string htmlContent, string title)
        {
            fileName = "report.pdf";
            byte[] pdfBytes = PDFReport(htmlContent, title);
            jS.InvokeVoidAsync("DownloadPdf", fileName, Convert.ToBase64String(PDFReport(htmlContent, title)));        
        }
        public void ViewPdf(IJSRuntime jS, string idIFrame, string htmlContent, string title)
        {
            jS.InvokeVoidAsync("ViewPdf", idIFrame, Convert.ToBase64String(PDFReport(htmlContent, title)));
        }
        public void ViewNewTabPdf(IJSRuntime jS, string fileName, string htmlContent, string title)
        {
            fileName = "report.pdf";
            jS.InvokeVoidAsync("OpenPdfNewTab", fileName, Convert.ToBase64String(PDFReport(htmlContent, title)));
        }
        //itextSharp Report
        private byte[] PDFReport(string html, string Title)
        {


            var memoryStream = new MemoryStream();

            float margeLeft = 0.5f;
            float margeRight = 0.5f;
            float margeTop = 1.0f;
            float margeBottom = 1.0f;

            Document pdf = new Document(
                PageSize.A4,
                margeLeft.ToDpi(),
                margeRight.ToDpi(),
                margeTop.ToDpi(),
                margeBottom.ToDpi()

                );

            //CSSResolver cssResolver = new StyleAttrCSSResolver();
            

            pdf.AddTitle(Title);
            pdf.AddAuthor("Chidubem Hillary");
            pdf.AddCreationDate();
            pdf.AddKeywords("Blazor");
            pdf.AddSubject("PDf Generator");
            pdf.AddCreationDate();
            PdfWriter writer = PdfWriter.GetInstance(pdf, memoryStream);

            //Create Header

            var fontStyle = FontFactory.GetFont("Arial", 16, BaseColor.White);
            var labelHeader = new Chunk(Title, fontStyle);

            HeaderFooter header = new HeaderFooter(new Phrase(labelHeader), false)
            {
                BackgroundColor = new BaseColor(50, 20, 120),
                Alignment = Element.ALIGN_CENTER,
                Border = Rectangle.NO_BORDER

            };
            pdf.Header = header;

            //Create footer
            var labelFooter = new Chunk("Page", fontStyle);
            HeaderFooter footer    = new HeaderFooter(new Phrase(labelHeader), true)
            {
                BackgroundColor = new BaseColor(120, 3, 120),
                Alignment = Element.ALIGN_RIGHT,
                Border = Rectangle.NO_BORDER

            };

            pdf.Footer = footer;

            //Body 
            pdf.Open();


            // Add HTML to PDF
            var htmlWorker = new HtmlWorker(pdf); 
            htmlWorker.Parse(new StringReader(html));




            var title = new Paragraph("Blazor PDF Report", new Font(Font.HELVETICA, 20, Font.BOLD));
            title.SpacingAfter = 18f;

            pdf.Add(title);

            Font _fontStyle = FontFactory.GetFont("Tahoma", 12f, Font.NORMAL);
            var _myText = "Wlecome to HOA";
            var phrase = new Phrase(_myText, _fontStyle);
            pdf.Add(phrase);

            pdf.Close();

            return memoryStream.ToArray();


        }
    }
}
