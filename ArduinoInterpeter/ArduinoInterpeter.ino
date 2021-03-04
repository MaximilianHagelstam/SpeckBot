int mq2AnalogInput = A5;

void setup()
{
  pinMode(mq2AnalogInput, INPUT);

  Serial.begin(9600);
}

void loop()
{
  int smoke = analogRead(mq2AnalogInput);
  Serial.println(smoke);

  delay(1000);
}
