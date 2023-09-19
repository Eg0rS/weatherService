package api

import (
	"context"
	"fmt"
	"github.com/gorilla/mux"
	"go.uber.org/zap"
	"net"
	"net/http"
	"weatherCalculator/api/handler"
	"weatherCalculator/config"
	"weatherCalculator/service"
)

func NewServer(logger *zap.SugaredLogger, settings config.Settings, weatherService service.Service) *http.Server {
	router := mux.NewRouter()

	router.HandleFunc("/ping", handler.Ping(logger)).Methods(http.MethodGet)

	return &http.Server{
		Addr: fmt.Sprintf(":%d", settings.Port),
		BaseContext: func(listener net.Listener) context.Context {
			return context.Background()
		},
		Handler: router,
	}
}
