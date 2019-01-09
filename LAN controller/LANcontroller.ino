#include <ESP8266WiFi.h>
#include <WiFiClient.h>
#include <ESP8266WebServer.h>
#include <ESP8266mDNS.h>

#ifndef STASSID
#define STASSID "yeet"
#define STAPSK  "wordpass"
#endif

const char* ssid = STASSID;
const char* password = STAPSK;

ESP8266WebServer server(80);


void handleRoot() {
  //server.send(200, "text/plain", "hello deta");
  if(server.args() == 2)
  {
    int d = server.arg(1).toInt();
    pinMode(d, OUTPUT);
    if(server.arg(0) == "1"){
      digitalWrite(d, 1);
      server.send(200, "text/plain", String(server.arg(1))+" on");
    }else{
      digitalWrite(d, 0);
      server.send(200, "text/plain", String(server.arg(1))+" off");
    }
  }
}

void handleNotFound() {
  server.send(404, "text/plain", "404 :(");
}

void setup(void) {
  pinMode(2, OUTPUT);
  Serial.begin(115200);
  WiFi.mode(WIFI_STA);
  WiFi.begin(ssid, password);

  // Wait for connection
  while (WiFi.status() != WL_CONNECTED) {
    delay(500);
    Serial.print(".");
  }
  Serial.println("");
  Serial.print("Connected to ");
  Serial.println(ssid);
  Serial.print("IP address: ");
  Serial.println(WiFi.localIP());
  Serial.print(D4);

  if (MDNS.begin("esp8266")) {
    Serial.println("MDNS responder started");
  }

  server.on("/", handleRoot);

  server.on("/inline", []() {
    server.send(200, "text/plain", "this works as well");
  });

  server.onNotFound(handleNotFound);

  server.begin();
  Serial.println("HTTP server started");
}

void loop(void) {
  server.handleClient();
  MDNS.update();
}
