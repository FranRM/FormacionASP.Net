using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Practica65
{
    public class PdfFileResult : IActionResult
    {
        private readonly string _filename, _text;
        public PdfFileResult(string filename, string text) {
            _filename = filename;
            _text = text;
        }
        public async Task ExecuteResultAsync(ActionContext context)
        {
            using var stream = new MemoryStream();
            GeneratePdf(stream,_text);
            context.HttpContext.Response.ContentType = "application/text";
            context.HttpContext.Response.Headers.Add("content-disposition",$"attachment; filename={_filename}");
            await context.HttpContext.Response.BodyWriter.WriteAsync(stream.GetBuffer());
        }
        private void GeneratePdf(Stream stream, string text)
        {
            var document = new Document();
            PdfWriter.GetInstance(document, stream);
            document.Open();
            var font = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 24, BaseColor.Gray);
            document.Add(new Paragraph(text, font));
            document.Add(new Paragraph(DateTime.Now.ToString("M")));
            document.Close();
        }
    }
}
