using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    static class Program
    {
        /// <summary>
        /// 應用程式的主要進入點。
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
            #region 擴充方法練習 
            int money = 123456789;
            int date = 20151022;
            double p = 0.123453333;
            Console.WriteLine(money.FormatForMoney());
            Console.WriteLine(date.FormatForDate());
            Console.WriteLine(p.FormatPercent());
            #endregion

            #region list 多型 委派 練習
            List<Student> std = GetStudent();
            Console.WriteLine(std[0].id);
            std.Add(AddStudent("007", "王八"));
            foreach (Student element in std)
            {
                Console.WriteLine(element.id);
                Console.WriteLine(element.name);
            }
            Console.WriteLine("------------------------------");
            std.ForEach(delegate(Student name)
            {
                Console.WriteLine(name.id);
                Console.WriteLine(name.name);
            });
            Person jeff = new Person("jeff") { Age = 11 };
            List<Person> people = new List<Person>
            {
                new Person("aaa") {Age = 1},
                new Person("bbb") {Age = 2},
                new Person("ccc") {Age = 3}
            };

            people.ForEach(delegate(Person element)
            {
                Console.WriteLine("name:" + element.name);
                Console.WriteLine("Age:" + element.Age);
            });


            IEnumerable<int> aaa = GetCollection();
            aaa = GetCollection3(aaa);
            foreach (int element in aaa)
            {
                Console.WriteLine(element);
            }
            #endregion
            Bitmap bm = GenerateImage("2345");
            bm.Save("aaa.bmp", ImageFormat.Bmp);
        }

        public static Bitmap GenerateImage(string text) //驗證碼產生
        {
            Bitmap bitmap = new Bitmap(text.Length *18, 30, PixelFormat.Format32bppArgb);
            Graphics g = Graphics.FromImage(bitmap);
            try
            {
                Random random = new Random();
                g.Clear(Color.White);
                for (int i = 0; i < 20; i++) //draw some silver line 20 lines
                {
                    int x1 = random.Next(bitmap.Width);
                    int x2 = random.Next(bitmap.Width);
                    int y1 = random.Next(bitmap.Height);
                    int y2 = random.Next(bitmap.Height);
                    g.DrawLine(new Pen(Color.Silver), x1, y1, x2, y2); //start draw silver line
                    g.DrawEllipse(new Pen(Color.Aqua), new System.Drawing.Rectangle(x1, y1, x2, y2));
                }
                Font font = new Font("Arial", 20, FontStyle.Bold); //set word font ,size , style
                LinearGradientBrush brush = new LinearGradientBrush(new Rectangle(0, 0, bitmap.Width - 1, bitmap.Height - 1), Color.Red, Color.Blue, 30.0f, true);
                g.DrawString(text, font, brush, 2, 0); //start draw a word
                for (int i = 0; i < 200; i++) //draw noise
                {
                    int x = random.Next(bitmap.Width);
                    int y = random.Next(bitmap.Height);
                    bitmap.SetPixel(x, y, Color.FromArgb(random.Next()));
                }
                g.DrawRectangle(new Pen(Color.Black), 0, 0, bitmap.Width-1, bitmap.Height-1); //draw box
                g.Dispose();
                return bitmap;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        private static IEnumerable<int> GetCollection()
        {
            for (int i = 0; i < 10; i++)
            {
               yield return i;
            }
        }
        private static IEnumerable<int> GetCollection3(IEnumerable<int> aaa)
        {
            foreach (var number in aaa)
            {
                if (number == 3)
                    break;
                else
                    yield return number;
            }
        } 
        private static Student AddStudent(string id, string name)
        {
            return new Student() {id=id,name=name };
        }
        public class Person
        {
            public string name;
            public int Age;
            public Person(string name) {
                this.name = name;
            }
        }
        public struct Student
        {
            public string id;
            public string name;
        }
        private static List<Student> GetStudent()
        {
            return new List<Student>(new[]
            {
                new Student() {
                    id = "001",name = "張三"
                },
                new Student() {
                    id = "002",name = "李四"
                },
                new Student() {
                    id = "003",name = "王五"
                },
                new Student() {
                    id = "004",name = "陳六"
                },
                new Student() {
                    id = "005",name = "飛七"
                },
            });
        }
    }
}
