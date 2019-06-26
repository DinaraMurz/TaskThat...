using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace PlanAssistant
{
    public class Task : Entity
    {
        public DateTime DateTime { get; set; }
        public Frequency Frequency { get; set; }
        public object TaskType { get; set; }

        public void ChooseTaskType(string taskTypeName, string firstValue, string secondValue)
        {
            switch (taskTypeName)
            {
                case "email":
                    TaskType = new Email {To = new MailAddress(firstValue)};
                    break;
                case "downloadFile":
                    TaskType = new FileDownloader { Url = firstValue, To = secondValue};
                    break;
                case "moveCatalog":
                    TaskType = new CatalogMoving { From = firstValue, To = secondValue};
                    break;
                default:
                    throw new Exception();
            }
        }
    }
}
