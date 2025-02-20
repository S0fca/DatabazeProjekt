using DatabazeProjekt.Entities;
using DatabazeProjekt.UI;

namespace DatabazeProjekt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            VisitHandler.AddVisitXML("..\\..\\..\\visit.xml");
            ReportHandler.AddReportXML("..\\..\\..\\report.xml");

            ClinicConsole console = new ClinicConsole();
            console.Start();
        }
    }
}
