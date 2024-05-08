using SampleProjectApp.Models;

namespace SampleProjectApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //area area = new area();
            //area.area1 = "popo";
            //area.zipcode = "44332";
            dbEmployeeTrackerContext context = new dbEmployeeTrackerContext();
            //context.areas.add(area);
            //context.savechanges();

            //dbEmployeeTrackerContext context1 = new dbEmployeeTrackerContext();
            //var areas = context1.Areas.ToList();
            //foreach (var area1 in areas)
            //{
            //    Console.WriteLine(area1.Area1 + " " + area1.Zipcode);
            //}

            var areas = context.Areas.ToList();
            var area = areas.SingleOrDefault(a => a.Area1 == "FFFF");
            area.Zipcode = "00000";
            context.Areas.Update(area);
            context.SaveChanges();

            //area = areas.SingleOrDefault(a => a.Area1 == "HYHY");
            //context.Areas.Remove(area);
            //context.SaveChanges();
            //foreach (var a in areas)
            //{
            //    Console.WriteLine(a.Area1 + " " + a.Zipcode);
            //}
        }
    }
}
