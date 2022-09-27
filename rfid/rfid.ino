

#include <SPI.h>
#include <MFRC522.h>

#define SS_PIN 10
#define RST_PIN 9
#define RED 2
#define Green 3
MFRC522 mfrc522(SS_PIN, RST_PIN);   // Create MFRC522 instance.

void setup()
{
  Serial.begin(9600);   // Initiate a serial communication
  SPI.begin();      // Initiate  SPI bus
  mfrc522.PCD_Init();   // Initiate MFRC522
  Serial.println();
  pinMode(LED_BUILTIN, OUTPUT);
  //   digitalWrite(LED_BUILTIN, LOW);    // turn the LED off by making the voltage LOW
  //   digitalWrite(Green, LOW);
  //   digitalWrite(RED, LOW);
  // set up the LCD's number of columns and rows:
  // Print a message to the LCD.

}
void loop()
{
  // Look for new cards
  if ( ! mfrc522.PICC_IsNewCardPresent())
  {
    return;
  }
  // Select one of the cards
  if ( ! mfrc522.PICC_ReadCardSerial())
  {
    return;
  }
  //Show UID on serial monitor
//  Serial.print("UID tag :");
  String content = "";
  byte letter;
  for (byte i = 0; i < mfrc522.uid.size; i++)
  {
    Serial.print(mfrc522.uid.uidByte[i] < 0x10 ? " 0" : " ");
    Serial.print(mfrc522.uid.uidByte[i], HEX);
    content.concat(String(mfrc522.uid.uidByte[i] < 0x10 ? " 0" : " "));
    content.concat(String(mfrc522.uid.uidByte[i], HEX));
  }

  content.toUpperCase();

//  Serial.println();
    if ((content.substring(1) == "04 4A 4E 79 39 61 81")|| (content.substring(1) == "04 26 46 79 39 61 80") || (content.substring(1) == "04 27 15 7A 39 61 80") ) 
    {
      Serial.println("Play");
    }
    if ((content.substring(1) == "04 0D D1 79 39 61 80") || (content.substring(1) == "04 12 44 7A 39 61 80") || (content.substring(1) == "04 D5 10 7A 39 61 80") || (content.substring(1) == "04 26 52 79 39 61 80") ) 
    {
      Serial.println("Food");
    }
        if ((content.substring(1) == "04 77 FF 79 39 61 81") || (content.substring(1) == "04 26 46 79 39 61 80") ) 
    {
      Serial.println("Water");
    }
  //
  // else   {
  //
  //    Serial.println(" Access denied");
  //     digitalWrite(LED_BUILTIN, LOW);    // turn the LED off by making the voltage LOW
  //    digitalWrite(RED, HIGH);
  //    delay(10000);
  //    digitalWrite(RED, LOW);
  //
  //  }
}
