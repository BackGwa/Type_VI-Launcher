using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Text;
using System.Net;
using System.ComponentModel;

namespace Launcher
{
        public partial class Form1 : Form
    {

        WebClient webClient1;


        //폼 투명화
        public Form1()
        {
            InitializeComponent();
            this.TransparencyKey = Color.FromArgb(52, 105, 173);
            this.BackColor = Color.FromArgb(52, 105, 173);
            this.FormBorderStyle = FormBorderStyle.None;
        }






        //딜레이 함수 정의
            public void Delay(int ms)
        {
            DateTime dateTimeNow = DateTime.Now;
            TimeSpan duration = new TimeSpan(0, 0, 0, 0, ms);
            DateTime dateTimeAdd = dateTimeNow.Add(duration);
            while (dateTimeAdd >= dateTimeNow)
            {
                System.Windows.Forms.Application.DoEvents();
                dateTimeNow = DateTime.Now;
            }
            return;
        }






        //폰트 정의
        private void Form1_Load(object sender, EventArgs e)
        {
            label1.TextAlign = ContentAlignment.MiddleCenter;

            PrivateFontCollection privateFonts = new PrivateFontCollection();
            privateFonts.AddFontFile("FONT.TTF");

            Font font = new Font(privateFonts.Families[0], 8f);

            label1.Font = font;
        }






        //체킹 메세지 정의
        void CheckingText()
        {

            label1.Text = "Checking update package.";
            Delay(250);
            label1.Text = "Checking update package..";
            Delay(250);
            label1.Text = "Checking update package...";
            Delay(250);

        }





        private void Form1_Shown(object sender, EventArgs e)
        {



            //체킹 메세지 메세지 출력
            label1.Text = "Launcher Version : Stable1.0";
            Delay(2000);
            CheckingText();

            //설치 파일 확인
            string _Locate = @"C:\VOCALINE\VOCALINE\Content\Paks\VOCALINE-WindowsNoEditor.pak";
            System.IO.FileInfo filepath = new System.IO.FileInfo(_Locate);
            if (filepath.Exists)
            {

                launch();

            }

            else
            {

                string downloadurl = "http://vlapi.kro.kr/";
                WebClient webClient = new WebClient();
                WebClient wc = new WebClient();
                label1.Text = "Download Package Files";
                wc.DownloadFile(downloadurl, @"C:\VOCALINE\package.zip");


            }


            void launch()
            {



                //패키지 경로 지정
                string updatefile = @"C:\VOCALINE\VOCALINE\Content\Paks\clientfile.qud";
                string move = @"C:\VOCALINE\VOCALINE\Content\Paks\VOCALINE-WindowsNoEditor.pak";
                string _Filestr = @"C:\VOCALINE\VOCALINE\Content\Paks\clientfile.qud";
                string filePath = @"C:\VOCALINE\VOCALINE\Binaries\Win64\VOCALINE-Win64-Shipping.exe";
                System.IO.FileInfo fi = new System.IO.FileInfo(_Filestr);



                //업데이트 패키지가 있는가
                if (fi.Exists)
                {
                    label1.Text = "Applying a new update package...";
                    System.IO.File.Delete(move);
                    System.IO.File.Move(updatefile, move);
                    Delay(750);
                    label1.Text = "Starting the process...";
                    System.Diagnostics.Process.Start(filePath);
                    Close();
                }


                else
                {
                    label1.Text = "update package not found.";
                    Delay(750);
                    label1.Text = "Starting the process...";
                    System.Diagnostics.Process.Start(filePath);
                    Close();
                }

            }




        }
    }
}
