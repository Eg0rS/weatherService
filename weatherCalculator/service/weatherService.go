package service

import (
	"context"
	"go.uber.org/zap"
	"math/rand"
	"sync"
	"weatherCalculator/models"
)

type Service struct {
	logger *zap.SugaredLogger
}

func NewService(logger *zap.SugaredLogger) Service {
	return Service{
		logger: logger,
	}
}

var magicNumberTree = 42

func (s Service) GetWeatherForecast(context context.Context, point models.GeoPointRequest) models.WeatherResponse {
	var magicNumberOne = point.Latitude
	var magicNumberTwo = point.Longitude

	var wg sync.WaitGroup
	var mutex sync.Mutex
	var result models.WeatherResponse
	var l1 int
	var l2 int

	wg.Add(2)

	l1 = <-createChanL1(int(magicNumberOne), &mutex, &wg)
	l2 = <-createChanL2(int(magicNumberTwo), &wg)
	wg.Wait()

	result.TemperatureC = int32(l1 + l2)
	var f = models.Summaries(<-getRandomWeather())
	result.Summaries = f.String()
	return result
}

func getRandomWeather() chan int {
	ch := make(chan int)
	go func() {
		ch <- rand.Intn(8)
	}()
	return ch
}

func factorial(n int, ch chan int) {
	result := 1
	for i := 1; i <= n; i++ {
		result *= i
	}

	ch <- result
}

func createChanL1(n int, mutex *sync.Mutex, wg *sync.WaitGroup) chan int {
	mutex.Lock()
	magicNumberTree++
	ch := make(chan int)
	go factorial(n+magicNumberTree, ch)
	defer wg.Done()
	mutex.Unlock()
	return ch
}

func createChanL2(n int, wg *sync.WaitGroup) chan int {
	ch := make(chan int)
	go factorial(n, ch)
	defer wg.Done()
	return ch
}
