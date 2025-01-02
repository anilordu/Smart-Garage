import serial
import RPi.GPIO as GPIO
import time
import cv2
import yagmail
import Adafruit_DHT
import threading

def isitici(data):
    if data == "isitici:1":
        GPIO.output(21, GPIO.LOW)
        print("Isıtıcıyı çalıştır")
    elif data == "isitici:0":
        GPIO.output(21, GPIO.HIGH)
        
        print("Isıtıcıyı kapat")

def fotoCekGonder():
    camera = cv2.VideoCapture(0)
    ret, frame = camera.read()
    if ret:
        photo_path = "photo.jpg"
        cv2.imwrite(photo_path, frame)
        print("Fotoğraf çekildi ve kaydedildi.")
        ser.write("foto:1\n".encode('utf-8'))
        
    else:
        print("Fotoğraf çekilemedi!")
        ser.write("foto:0".encode('utf-8'))
        camera.release()
        exit()

    camera.release()

# E-posta gönderimi
    try:
    # E-posta bilgileri
        sender_email = "sender_email"
        sender_password = "sender_password"
        recipient_email = "recipient_email"
        subject = "Raspberry Pi Fotoğraf"
        body = "Bu fotoğraf Raspberry Pi ile çekilmiştir."

    # E-posta gönder
        yag = yagmail.SMTP(user=sender_email, password=sender_password)
        yag.send(
            to=recipient_email,
            subject=subject,
            contents=[body, photo_path]
        )
        print("E-posta başarıyla gönderildi.")
        ser.write("eposta:1\n".encode('utf-8'))
        
    except Exception as e:
        print("E-posta gönderiminde bir hata oluştu:", e)
        ser.write("eposta:0\n".encode('utf-8'))

def fan(k):
    if k == "Fan:0":
        fan1PWM.ChangeDutyCycle(0)
    elif k == "Fan:1":
        fan1PWM.ChangeDutyCycle(25)
    elif k == "Fan:2":
        fan1PWM.ChangeDutyCycle(50)
    elif k == "Fan:3":
        fan1PWM.ChangeDutyCycle(75)

def branda(k):
    if k == "Branda:0":
        brandaPWM.ChangeDutyCycle(5)
    elif k == "Branda:1":
        brandaPWM.ChangeDutyCycle(10)
    elif k == "Branda:2":
        brandaPWM.ChangeDutyCycle(15)

def sıcaklıkOku():
    global temperature, humidity
    while True:
        humidity, temperature = Adafruit_DHT.read_retry(sicaklikSensor, sicaklikSensorPin)
        if humidity is not None and temperature is not None:
            print(f"Sıcaklık: {temperature:.1f}°C")
        else:
            print("Sensörden veri alınamadı. Bağlantıları kontrol edin.")
        time.sleep(2)  # Her 2 saniyede bir ölçüm yapılır.

sicaklikSensor = Adafruit_DHT.DHT11
isiticiPin = 21
sicaklikSensorPin = 22
hareketSensor = 26
fanPin1 = 23
fanPin2 = 24
yagmurSensor = 8
brandaPin = 17
GPIO.setmode(GPIO.BCM)
GPIO.setup(fanPin1, GPIO.OUT)
GPIO.setup(fanPin2, GPIO.OUT)
GPIO.setup(brandaPin, GPIO.OUT)
GPIO.setup(isiticiPin, GPIO.OUT, initial=GPIO.HIGH)
GPIO.setup(yagmurSensor, GPIO.IN)
GPIO.setup(hareketSensor, GPIO.IN)
fan1PWM= GPIO.PWM(fanPin1, 100)
fan2PWM= GPIO.PWM(fanPin2, 100)
brandaPWM = GPIO.PWM(brandaPin, 100)
fan1PWM.start(0)
fan2PWM.start(0)
brandaPWM.start(0)

ser = serial.Serial('/dev/ttyAMA0', baudrate=9600, timeout=1)

# Sıcaklık okuma işlemi bir iş parçacığında çalıştırılır
sıcaklık_thread = threading.Thread(target=sıcaklıkOku)
sıcaklık_thread.daemon = True  # Bu iş parçacığının ana program sonlandığında sonlanmasını sağlar
sıcaklık_thread.start()

while True:
    # Diğer işlemler burada devam eder
    time.sleep(1)
    if GPIO.input(yagmurSensor) == GPIO.LOW:
        ser.write("Yagmur:1\n".encode('utf-8'))
    else:
        ser.write("Yagmur:0\n".encode('utf-8'))
    
    if GPIO.input(hareketSensor):
        ser.write("Hareket:1\n".encode('utf-8'))
    else:
        ser.write("Hareket:0\n".encode('utf-8'))

    if ser.in_waiting > 0:
        data = ser.readline().decode('utf-8').strip()
        print(f"Received: {data}")
        if data[0] == "F":
            fan(data)
        elif data[0] == "B":
            branda(data)
        elif data[0] == "i":
            isitici(data)
        elif data == "foto":
            fotoCekGonder()
        
        # Sıcaklık verisini gönder
        
    ser.write(f"{temperature:.1f}\n".encode('utf-8'))
        
        #ser.write("Acknowledged\n".encode('utf-8'))
