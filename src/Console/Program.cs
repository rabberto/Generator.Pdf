// See https://aka.ms/new-console-template for more information
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

Console.WriteLine("Hello, World!");

try
{
    QuestPDF.Settings.License = LicenseType.Community;

    Document.Create(container =>
    {
        container.Page(page =>
        {
            page.Size(PageSizes.A4);
            page.Margin(2, Unit.Centimetre);
            page.PageColor(Colors.White);
            page.DefaultTextStyle(x => x.FontSize(20));

            page.Header()
                .Text("Pdg Generator")
                .SemiBold()
                .FontSize(40);

            page.Content()
            .PaddingVertical(1, Unit.Centimetre)
            .Column(x =>
            {
                x.Item()
                    .Text(Placeholders.LoremIpsum());

                x.Item()
                    .Image(Placeholders.Image(200, 100));

            });

            page.Footer()
                .AlignCenter()
                .Text(x =>
                {
                    x.Span("Page ");
                    x.CurrentPageNumber();
                });
        });
    }).GeneratePdf("generatorpdf.pdf");

    Console.WriteLine("Pdf generated");

}
catch (Exception ex)
{
    Console.WriteLine($"Falha ao gerar Pdf: {ex.Message}");
}