package models

type Summaries int

const (
	Freezing   Summaries = 0
	Bracing    Summaries = 1
	Chilly     Summaries = 2
	Cool       Summaries = 3
	Mild       Summaries = 4
	Warm       Summaries = 5
	Balmy      Summaries = 6
	Hot        Summaries = 7
	Sweltering Summaries = 8
	Scorching  Summaries = 9
)

func (s Summaries) String() string {
	return [...]string{"Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"}[s]
}

type WeatherResponse struct {
	Summaries    string `json:"Summaries"`
	TemperatureC int32  `json:"TemperatureC"`
}

type GeoPointRequest struct {
	Latitude  float64 `json:"latitude"`
	Longitude float64 `json:"longitude"`
	PointType string  `json:"pointType"`
	DateAdded string  `json:"dateAdded"`
}
