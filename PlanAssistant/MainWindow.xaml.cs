using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PlanAssistant
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    
    public partial class MainWindow : Window
    {
        private Frequency typeOfFrequency;
        private List<Timer> timers = new List<Timer>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CloseButtonClick(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        private void TypeComboBoxSelected(object sender, RoutedEventArgs e)
        {
            switch (typeComboBox.SelectedIndex)
            {
                case -1:
                    firstTextBlock.Text = "";
                    secondTextBlock.Text = "";
                    break;
                case 0:
                    firstTextBlock.Text = "Введите адрес отправителя";
                    secondTextBlock.Text = "Текст сообщения";
                    break;
                case 1:
                    firstTextBlock.Text = "Введите url";
                    secondTextBlock.Text = "Путь куда скачать";
                    break;
                case 2:
                    firstTextBlock.Text = "Путь каталога";
                    secondTextBlock.Text = "Новый путь каталога";
                    break;
            }
        }

        private void ReadyButtonClick(object sender, RoutedEventArgs e)
        {
            //    try
            //    {
            //        tasks.Add(
            //        new Task
            //        {
            //            DateTime = new DateTime(datePicker.SelectedDate.Value.Ticks + timePicker.SelectedTime.Value.Ticks),
            //            Frequency = FrequrencyByNameReturing(frequencyComboBox.SelectionBoxItemStringFormat),
            //            TaskType = new object(),
            //        });

            //        switch (typeComboBox.SelectedIndex)
            //        {
            //            case 0:
            //                //tasks[tasks.Count - 1].ChooseTaskType("email", firstTextBox.Text, secondTextBox.Text);
            //                SendMessage(firstTextBox.Text, "", secondTextBox.Text);
            //                break;
            //            case 1:
            //                tasks[tasks.Count - 1].ChooseTaskType("downloadFile", firstTextBox.Text, secondTextBox.Text);
            //                break;
            //            case 2:
            //                tasks[tasks.Count - 1].ChooseTaskType("moveCatalog", firstTextBox.Text, secondTextBox.Text);
            //                break;
            //        }
            //        ////База данных не сохраняет данные, что-то одинаковое
            //        //using (var context = new AppContext())
            //        //{
            //        //    context.Tasks.Add(tasks[tasks.Count - 1]);
            //        //}
            //    }
            //    catch(Exception ex)
            //    {
            //        MessageBox.Show(ex.Message);
            //    }


            Task task = new Task();
            DateTime dateTime;
            try
            {
                var date = Convert.ToDateTime(datePicker.ToString());
                var time = timePicker.SelectedTime;
                dateTime = new DateTime(date.Year, date.Month, date.Day, time.Value.Hour, time.Value.Minute, 0);

            }
            catch (Exception)
            {
                MessageBox.Show("Select date and time!");
                return;
            }
            task.DateTime = dateTime;

            if (typeOfFrequency == Frequency.None)
            {
                MessageBox.Show("Select periodicity!");
                return;
            }
            task.Frequency = typeOfFrequency;

            int pulseHours = 0;

            switch (typeOfFrequency)
            {
                case Frequency.OneTime:
                    pulseHours = 0;
                    break;
                case Frequency.OnceADay:
                    pulseHours = 24;
                    break;
                case Frequency.OnceAWeek:
                    pulseHours = 168;
                    break;
                case Frequency.OnceAMounth:
                    pulseHours = 730;
                    break;
                case Frequency.OnceAYear:
                    pulseHours = 8760;
                    break;
            }

            switch (typeComboBox.SelectedIndex)
            {
                //case 0:
                //    Task.ChooseTaskType("email", firstTextBox.Text, secondTextBox.);
                //    Email email = new Email();
                //    email.To = new MailAddress(firstTextBox.Text);
                //    string str = "NewMessage";
                //    timers.Add(new Timer(email.SendMessage(str,secondTextBox.Text), TimeSpan.FromHours(0), TimeSpan.FromHours(pulseHours)));

                //    break;

                //case 1:
                //    
                //    break;

                //case 2:
                //   
                //    break;
                //default:
                //    MessageBox.Show("Select type!");
                //    return;
            }
        }



        private Frequency FrequrencyByNameReturing(string name)
        {
            Frequency frequency = new Frequency();

            switch (name)
            {
                case "раз в день":
                    typeOfFrequency = Frequency.OnceADay;
                    break;
                case "раз в неделю":
                    typeOfFrequency = Frequency.OnceAWeek;
                    break;
                case "раз в месяц":
                    typeOfFrequency = Frequency.OnceAMounth;
                    break;
                case "раз в год":
                    typeOfFrequency = Frequency.OnceAYear ;
                    break;
            }

            return frequency;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        
    }
}
