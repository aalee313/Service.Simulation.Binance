﻿// ReSharper disable UnusedMember.Global

using Autofac;
using Service.Simulation.Binance.Grpc;

namespace Service.Simulation.Binance.Client
{
    public static class AutofacHelper
    {
        public static void RegisterSimulationBinanceClient(this ContainerBuilder builder,
            string simulationFtxGrpcServiceUrl)
        {
            var factory = new SimulationClientFactory(simulationFtxGrpcServiceUrl);

            builder.RegisterInstance(factory.GetSimulationFtxTradingService()).As<ISimulationTradingService>()
                .SingleInstance();
            builder.RegisterInstance(factory.GetSimulationFtxTradeHistoryService()).As<ISimulationTradeHistoryService>()
                .SingleInstance();
        }
    }
}