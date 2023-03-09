﻿using LearningApp.Contracts;
using LearningApp.Contracts.Services;
using Serilog;

namespace LearningApp.LoggerService;

public sealed class LoggerManager : ILoggerManager
{
    private readonly ILogger _logger;

    public LoggerManager(ILogger logger)
    {
        _logger = logger;
    }

    public void LogDebug(string message) => _logger.Debug(message);
    public void LogError(string message) => _logger.Error(message);
    public void LogInfo(string message) => _logger.Information(message);
    public void LogWarn(string message) => _logger.Warning(message);
}