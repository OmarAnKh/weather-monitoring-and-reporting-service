// See https://aka.ms/new-console-template for more information

using weather_monitoring_and_reporting_service.models.Weather;

string jsonObject = """
                     {
                      "Location": "City Name",
                      "Temperature": 23.0,
                      "Humidity": 85.0
                    }
                    """;
IWeatherParserFactory jsonFactory=new JsonParserFactory();
Client jsonClient=new Client(jsonFactory);
jsonClient.DisplayWeatherInfo(jsonObject);


const string xmlObject = "<WeatherData><Location>City Name</Location><Temperature>23.0</Temperature><Humidity>85.0</Humidity></WeatherData>";
                  
IWeatherParserFactory xmlFactory=new XmlParserFactory();
Client xmlClient=new Client(xmlFactory);
xmlClient.DisplayWeatherInfo(xmlObject);