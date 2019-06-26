using System;
using System.IO;

namespace PlanAssistant
{
    public class CatalogMoving : Entity
    {
        public string From { get; set; }
        public string To { get; set; }

        public void MoveCatalog()
        {
            try
            {
                if (Directory.Exists(From))
                {
                    if (Directory.Exists(To))
                    {
                        Directory.Move(To, DateTime.Now.ToString("_MMMdd_yyyy_HHmmss"));
                        Directory.Move(From, To);
                    }
                    else
                    {
                        Directory.Move(From, To);
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
