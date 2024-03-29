﻿using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MyJetWallet.Sdk.Service;
using Service.Simulation.Binance.Services;

namespace Service.Simulation.Binance
{
    public class ApplicationLifetimeManager : ApplicationLifetimeManagerBase
    {
        private readonly OrderBookManager _bookManager;
        private readonly ILogger<ApplicationLifetimeManager> _logger;

        public ApplicationLifetimeManager(IHostApplicationLifetime appLifetime,
            ILogger<ApplicationLifetimeManager> logger, OrderBookManager bookManager)
            : base(appLifetime)
        {
            _logger = logger;
            _bookManager = bookManager;
        }

        protected override void OnStarted()
        {
            _logger.LogInformation("OnStarted has been called.");
            _bookManager.Start();
        }

        protected override void OnStopping()
        {
            _logger.LogInformation("OnStopping has been called.");
            _bookManager.Stop();
        }

        protected override void OnStopped()
        {
            _logger.LogInformation("OnStopped has been called.");
        }
    }
}
