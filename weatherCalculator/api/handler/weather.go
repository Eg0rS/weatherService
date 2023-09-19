package handler

import (
	"encoding/json"
	"go.uber.org/zap"
	"net/http"
	"weatherCalculator/models"
	"weatherCalculator/service"
)

func Weather(logger *zap.SugaredLogger, service service.Service) http.HandlerFunc {
	return func(w http.ResponseWriter, r *http.Request) {
		w.Header().Set("Content-Type", "application/json")
		var point models.GeoPointRequest
		err := json.NewDecoder(r.Body).Decode(&point)
		if err != nil {
			logger.Error(err)
			w.WriteHeader(http.StatusBadRequest)
			json.NewEncoder(w).Encode(err)
			return
		}
		var result = service.GetWeatherForecast(r.Context(), point)
		json.NewEncoder(w).Encode(result)
	}
}
