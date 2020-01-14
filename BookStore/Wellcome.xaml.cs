using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using DLL;
using Server;


namespace GUI
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class WindowWelcome : Window
    {
        public WindowWelcome()
        {
            InitializeComponent();
            InitializeDbBook();
            InitializeDbJournals();
            InitializeDbEmployees();
            this.KeyDown += new KeyEventHandler(MainWindow_KeyDown);
        }

        public void InitializeDbEmployees()
        {
            DB.DbEmployees.Add(new Employee()
            {
                FirstName = "Eran",
                LastName = "Haviv",
                Password = "4321",
                Position = EPosition.Manager,
                PhoneNumber = 0542174644,
                Email = "ehaviv@hotmail.com",
                Adress = "Kibutz Tzora",
                Birthdate = new DateTime(1978, 4, 6),
            });
            DB.DbEmployees.Add(new Employee()
            {
                FirstName = "Lior",
                LastName = "Din",
                Password = "1234",
                Position = EPosition.Seller,
                PhoneNumber = 0527007007,
                Email = "DinL@gmail.com",
                Adress = "Bet Shemesh",
                Birthdate = new DateTime(1998, 1, 1),
            });
        }

        public void InitializeDbBook()
        {
            DB.DbBooks.Add(new Book()
            {
                ItemCode = 99,
                Name = "Dune",
                Author = "Frank Herbert",
                Stock = 5,
                Price = 25.99,
                Genre = BGenre.SciFi,
                Description = "Set in the distant future amidst a feudal interstellar society in which various noble houses control planetary fiefs, Dune tells the story of young Paul Atreides, whose family accepts the stewardship of the planet Arrakis. While the planet is an inhospitable and sparsely populated desert wasteland, it is the only source of melange, or \"the spice\", a drug that extends life and enhances mental abilities. Melange is also necessary for space navigation, which requires a kind of multidimensional awareness and foresight that only the drug provides.[6] As melange can only be produced on Arrakis, control of the planet is thus a coveted and dangerous undertaking. The story explores the multi-layered interactions of politics, religion, ecology, technology, and human emotion, as the factions of the empire confront each other in a struggle for the control of Arrakis and its spice.[7]",
                YearPublished = 1990,
                ISBN = 0441172717,
                Pages = 412
            });
            DB.DbBooks.Add(new Book()
            {
                ItemCode = 77,
                Name = "The English Patient",
                Author = "Michael Ondaatje",
                Stock = 2,
                Price = 39.99,
                Genre = BGenre.Novel,
                Description = "The English Patient is a 1992 novel by Michael Ondaatje. The book follows four dissimilar people brought together at an Italian villa during the Italian Campaign of World War II. The four main characters are: an unrecognisably burned man — the eponymous patient, presumed to be English; his Canadian Army nurse, a Sikh British Army sapper, and a Canadian thief. The story occurs during the North African Campaign and centres on the incremental revelations of the patient's actions prior to his injuries, and the emotional effects of these revelations on the other characters.",
                YearPublished = 1992,
                ISBN = 0771068867,
                Pages = 320
            });
            DB.DbBooks.Add(new Book()
            {
                ItemCode = 111,
                Name = "Gone with the Wind",
                Author = "Margaret Mitchell",
                Stock = 1,
                Price = 59.99,
                Genre = BGenre.Novel,
                Description = "This historical novel features a Bildungsroman or coming-of-age story",
                YearPublished = 1936,
                ISBN = 9780446365383,
                Pages = 1030
            });
            DB.DbBooks.Add(new Book()
            {
                ItemCode = 222,
                Name = "The Hobbit",
                Author = "J. R. R. Tolkien",
                Stock = 3,
                Price = 29.99,
                Genre = BGenre.Fantasy,
                Description = "The Hobbit, or There and Back Again is a children's fantasy novel by English author J. R. R. Tolkien. It was published on 21 September 1937 to wide critical acclaim, being nominated for the Carnegie Medal and awarded a prize from the New York Herald Tribune for best juvenile fiction. The book remains popular and is recognized as a classic in children's literature.",
                YearPublished = 1937,
                ISBN = 9780618260300,
                Pages = 310
            });
        }

        public void InitializeDbJournals()
        {
            DB.DbJournals.Add(new Journal()
            {
                ItemCode = 880,
                Name = "Popular Science",
                Stock = 2,
                Price = 4.99,
                Genre = JGenre.Science,
                Description = "American quarterly magazine carrying popular science content",
                Edition = 45,
                PrintDate = new DateTime(2020, 1, 1)
            });
            DB.DbJournals.Add(new Journal()
            {
                ItemCode = 890,
                Name = "Popular Science",
                Stock = 5,
                Price = 4.99,
                Genre = JGenre.Science,
                Description = "American quarterly magazine carrying popular science content",
                Edition = 46,
                PrintDate = new DateTime(2020, 2, 1)
            });
            DB.DbJournals.Add(new Journal()
            {
                ItemCode = 770,
                Name = "Vogue",
                Stock = 7,
                Price = 6.99,
                Genre = JGenre.Fusion,
                Description = " fashion and lifestyle magazine covering many topics including fashion, beauty, culture, living, and runway.",
                Edition = 86,
                PrintDate = new DateTime(2020, 1, 1)
            });
            DB.DbJournals.Add(new Journal()
            {
                ItemCode = 780,
                Name = "Vogue",
                Stock = 7,
                Price = 6.99,
                Genre = JGenre.Fusion,
                Description = " fashion and lifestyle magazine covering many topics including fashion, beauty, culture, living, and runway.",
                Edition = 87,
                PrintDate = new DateTime(2020, 2, 1)
            });

        }
        void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            EmployeeLogIn login = new EmployeeLogIn();
            login.Show();
            this.Close();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            EmployeeLogIn login = new EmployeeLogIn();
            login.Show();
            this.Close();
        }
    }
}
