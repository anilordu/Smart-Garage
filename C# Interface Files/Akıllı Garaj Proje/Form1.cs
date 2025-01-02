using System;
using System.IO.Ports;
using System.Windows.Forms;

namespace Akıllı_Garaj_Proje
{
    public partial class Form1 : Form
    {
        private SerialPort serialPort; // Seri port nesnesi

        public Form1()
        {
            InitializeComponent();

            // Seri port ayarları
            serialPort = new SerialPort("COM3", 9600); // COM port ve baud rate ayarı

            try
            {
                serialPort.Open(); // Portu aç
                serialPort.DataReceived += new SerialDataReceivedEventHandler(SerialPort_DataReceived); // Veri alındığında tetiklenen event
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Seri port açılamadı: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Seri port üzerinden gelen veriyi işleme
        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string receivedData = serialPort.ReadLine().Trim(); // Gelen veriyi oku
            Console.WriteLine($"Gelen veri: {receivedData}"); // Debug: Gelen veriyi konsola yazdır

            // UI thread'e veri göndererek label'ı güncelle
            Invoke(new Action(() =>
            {
                UpdateRainStatus(receivedData);
            }));
        }

        // Yağmur durumunu güncelleyen fonksiyon
        private void UpdateRainStatus(string data)
        {
            // Debug: Gelen veriyi kontrol et
            Console.WriteLine($"Veri işleniyor: {data}");

            if (data == "Yagmur:1")
            {
                label1.Text = "Yağmur Yağıyor";
            }
            else if (data == "Yagmur:0")
            {
                label1.Text = "Yağmur Yağmıyor";
            }
            else if (data == "Hareket:1")
            {
                label3.Text = "Hareket Algılandı";
            }
            else if (data == "Hareket:0")
            {
                label3.Text = "Hareket Algılanmadı";
            }
            else if (data == "foto:1")
            {
                label4.Text = "Fotoğraf Çekildi ve Kaydedildi";
            }
            else if (data == "foto:0")
            {
                label4.Text = "Fotoğraf Çekilemedi!";
            }
            else if (data == "eposta:1")
            {
                label4.Text = "Mail Gönderildi";
            }
            else if (data == "eposta:0")
            {
                label4.Text = "Mail gönderilemedi";
            }
            else
            {
                label2.Text = "Sıcaklık: " + data + "°C";
            }


        }

        private void SendDataToRaspberry(string dataToSend)
        {
            try
            {
                if (serialPort.IsOpen) // Port açık mı kontrol edilir
                {
                    serialPort.WriteLine(dataToSend);
                }
                else
                {
                    MessageBox.Show("Seri port açık değil!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Veri gönderilirken bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Fan ayarını gönderme işlemi
        private void fanBar_Scroll(object sender, EventArgs e)
        {
            int fanSpeed = fanBar.Value;
            string dataToSend = "";

            if (fanSpeed == 0)
            {
                fan.Text = "Fan Kapalı";
                dataToSend = "Fan:0";
            }
            else if (fanSpeed == 1)
            {
                fan.Text = "Fan Düşük Hızda Çalışıyor";
                dataToSend = "Fan:1";
            }
            else if (fanSpeed == 2)
            {
                fan.Text = "Fan Orta Hızda Çalışıyor";
                dataToSend = "Fan:2";
            }
            else if (fanSpeed == 3)
            {
                fan.Text = "Fan Yüksek Hızda Çalışıyor";
                dataToSend = "Fan:3";
            }

            SendDataToRaspberry(dataToSend);
        }

        // Isıtıcı ayarını gönderme işlemi
        private void isiticiBar_Scroll(object sender, EventArgs e)
        {
            int isiticiSpeed = isiticiBar.Value;
            string dataToSend = "";

            if (isiticiSpeed == 0)
            {
                isitici.Text = "Isıtıcı Kapalı";
                dataToSend = "isitici:0";
            }
            else if (isiticiSpeed == 1)
            {
                isitici.Text = "Isıtıcı Açık";
                dataToSend = "isitici:1";
            }
            

            SendDataToRaspberry(dataToSend);
        }

        // Branda ayarını gönderme işlemi
        private void brandaBar_Scroll(object sender, EventArgs e)
        {
            int brandaAyari = brandaBar.Value;
            string dataToSend = "";

            if (brandaAyari == 0)
            {
                branda.Text = "Branda Kapalı";
                dataToSend = "Branda:0";
            }
            else if (brandaAyari == 1)
            {
                branda.Text = "Branda Yarım Açık";
                dataToSend = "Branda:1";
            }
            else if (brandaAyari == 2)
            {
                branda.Text = "Branda Açık";
                dataToSend = "Branda:2";
            }

            SendDataToRaspberry(dataToSend);
        }

        // Form kapanırken seri portu kapama
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (serialPort.IsOpen)
            {
                serialPort.Close(); // Uygulama kapanırken portu kapat
            }
        }

        // Fan butonuna tıklama
        private void fan_Click(object sender, EventArgs e)
        {
            // Gerekli olduğunda fan tıklama eventi eklenebilir.
        }

        // Isıtıcı butonuna tıklama
        private void isitici_Click(object sender, EventArgs e)
        {
            // Isıtıcı tıklama eventi gerektiğinde buraya eklenebilir.
        }

        // Branda butonuna tıklama
        private void branda_Click(object sender, EventArgs e)
        {
            // Branda tıklama eventi gerektiğinde buraya eklenebilir.
        }

        // Fotoğraf çekme butonu
        private void button1_Click(object sender, EventArgs e)
        {
            string dataToSend = "foto";
            SendDataToRaspberry(dataToSend);
            label4.Text = "";
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // label1 tıklama eventi gerektiğinde buraya eklenebilir.
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
