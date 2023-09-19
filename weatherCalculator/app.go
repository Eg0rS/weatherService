package main

import (
	"context"
	"go.uber.org/zap"
	"net/http"
	"weatherCalculator/api"
	"weatherCalculator/config"
	"weatherCalculator/service"
)

type App struct {
	logger   *zap.SugaredLogger
	settings config.Settings
	server   *http.Server
}

func NewApp(logger *zap.SugaredLogger, settings config.Settings) App {

	var (
		weatherService = service.NewService(logger)

		server = api.NewServer(logger, settings, weatherService)
	)

	return App{
		logger:   logger,
		settings: settings,
		server:   server,
	}
}

func (a App) Run() {
	go func() {
		_ = a.server.ListenAndServe()
	}()
	a.logger.Debugf("HTTP server started on %d", a.settings.Port)
}

func (a App) Stop(ctx context.Context) {
	_ = a.server.Shutdown(ctx)
	a.logger.Debugf("HTTP server stopped")
}
